using System.Threading.Channels;
using Bible2PPT.Bibles;
using Bible2PPT.Services;
using Bible2PPT.Services.BibleIndexService;
using Bible2PPT.Services.BibleService;
using Bible2PPT.Services.BuildService;
using Microsoft.EntityFrameworkCore;

namespace Bible2PPT.PPT;

public class Builder : JobManager
{
    private readonly HiddenPowerPoint _powerPoint;
    private readonly ZippedBibleService _zippedBibleService;
    private readonly VerseQueryParser _verseQueryParser;
    private readonly IDbContextFactory<BuildContext> _dbFactory;

    public Builder(HiddenPowerPoint ppt, ZippedBibleService bibleService, VerseQueryParser verseQueryParser, IDbContextFactory<BuildContext> dbFactory)
    {
        _powerPoint = ppt;
        _zippedBibleService = bibleService;
        _verseQueryParser = verseQueryParser;
        _dbFactory = dbFactory;
    }

    protected override async Task ProcessAsync(Job job, CancellationToken token)
    {
        await base.ProcessAsync(job, token).ConfigureAwait(false);

        var channel = Channel.CreateBounded<(IAsyncEnumerable<IEnumerable<Verse?>> targetEachVerses, Book mainBook, Chapter mainChapter, int startVerseNumber, int? endVerseNumber)>(new BoundedChannelOptions(1)
        {
            FullMode = BoundedChannelFullMode.Wait,
        });

        var queries = _verseQueryParser.ParseVerseQueries(job.QueryString);
        var queriesDoneCount = 0;
        var queriesCount = queries.Count();
        var chaptersDoneCount = 0;
        var chaptersCount = 0;
        OnJobProgress(new JobProgressEventArgs(job, null, queriesDoneCount, queriesCount, chaptersDoneCount, chaptersCount));

        async Task ProduceAsync()
        {
            foreach (var query in queries)
            {
                var targetEachBook = await _zippedBibleService.FindBookAsync(job.Bibles, query.BookKey, token).ConfigureAwait(false);

                // 해당 책이 있는 성경에서 해당 책을 대표로 사용
                var mainBook = targetEachBook.FirstOrDefault(i => i is not null);
                if (mainBook is null)
                {
                    goto PROGRESS_QUERY;
                }

                // 장 번호를 기준으로 각 성경의 책을 순회하도록 관리
                var targetEachChapters = _zippedBibleService.GetChaptersAsync(targetEachBook, token)
                    .Where(eachChapter => eachChapter.Any(chapter =>
                        (query.EndChapterNumber == null)
                        ? (chapter.Number >= query.StartChapterNumber)
                        : (chapter.Number >= query.StartChapterNumber) && (chapter.Number <= query.EndChapterNumber)
                    ));
                var originalChaptersCount = chaptersCount;
                var chapterCount = 0;
                await foreach (var targetEachChapter in targetEachChapters)
                {
                    chapterCount += 1;
                    chaptersCount = originalChaptersCount + query switch
                    {
                        { EndChapterNumber: null } => chapterCount,
                        _ => query.EndChapterNumber.Value - query.StartChapterNumber + 1,
                    };

                    // 해당 장이 있는 성경의 책에서 해당 장을 대표로 사용
                    var mainChapter = targetEachChapter.FirstOrDefault(i => i is not null);
                    if (mainChapter is null)
                    {
                        continue;
                    }

                    var startVerseNumber = (mainChapter.Number == query.StartChapterNumber) ? query.StartVerseNumber : 1;
                    var endVerseNumber = (mainChapter.Number == query.EndChapterNumber) ? query.EndVerseNumber : null;

                    var targetEachVerses = _zippedBibleService.GetVersesAsync(targetEachChapter, token)
                        .Where(eachVerse => eachVerse.Any(verse =>
                            (endVerseNumber == null)
                            ? (verse.Number >= startVerseNumber)
                            : (verse.Number >= startVerseNumber) && (verse.Number <= endVerseNumber)
                        ));
                    await channel.Writer.WriteAsync((targetEachVerses, mainBook, mainChapter, startVerseNumber, endVerseNumber), token).ConfigureAwait(false);
                }

                chaptersCount = originalChaptersCount + chapterCount;

            PROGRESS_QUERY:
                queriesDoneCount += 1;
            }

            channel.Writer.Complete();
        }

        var produce = ProduceAsync();

        if (job.SplitChaptersIntoFiles)
        {
            while (!channel.Reader.Completion.IsCompleted)
            {
                _ = await Task.WhenAny(channel.Reader.WaitToReadAsync(token).AsTask(), produce).ConfigureAwait(false);
                if (!channel.Reader.TryRead(out var item))
                {
                    break;
                }

                var (targetEachVerses, mainBook, mainChapter, startVerseNumber, endVerseNumber) = item;
                var output = Path.Combine(job.OutputDestination, mainBook.Name, $"{mainChapter.Number:000}.pptx");
                using var ppt = new PPTManager(_powerPoint.Instance, job, output);
                await ppt.AppendChapter(targetEachVerses, mainBook, mainChapter, startVerseNumber, endVerseNumber, token).ConfigureAwait(false);
                chaptersDoneCount += 1;
                ppt.Save();
                OnJobProgress(new JobProgressEventArgs(job, null, queriesDoneCount, queriesCount, chaptersDoneCount, chaptersCount));
            }
        }
        else
        {
            using var ppt = new PPTManager(_powerPoint.Instance, job, job.OutputDestination);
            while (!channel.Reader.Completion.IsCompleted)
            {
                _ = await Task.WhenAny(channel.Reader.WaitToReadAsync(token).AsTask(), produce).ConfigureAwait(false);
                if (!channel.Reader.TryRead(out var item))
                {
                    break;
                }

                var (targetEachVerses, mainBook, mainChapter, startVerseNumber, endVerseNumber) = item;
                await ppt.AppendChapter(targetEachVerses, mainBook, mainChapter, startVerseNumber, endVerseNumber, token).ConfigureAwait(false);
                chaptersDoneCount += 1;
                OnJobProgress(new JobProgressEventArgs(job, null, queriesDoneCount, queriesCount, chaptersDoneCount, chaptersCount));
            }
            ppt.Save();
        }
        await produce.ConfigureAwait(false);
    }

    public new void Queue(Job job)
    {
        using (var db = _dbFactory.CreateDbContext())
        {
            db.Jobs.Add(job);
            db.SaveChanges();
        }

        base.Queue(job);
    }

    public async ValueTask RemoveJobAsync(Job job)
    {
        Cancel(job);

        using var db = _dbFactory.CreateDbContext();
        if (await db.Jobs.ContainsAsync(job).ConfigureAwait(false))
        {
            db.Jobs.Remove(job);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }
    }

    public IEnumerable<Job> GetJobs()
    {
        using var db = _dbFactory.CreateDbContext();
        return db.Jobs.ToList();
    }
}
