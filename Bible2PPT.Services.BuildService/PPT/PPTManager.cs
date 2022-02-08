using System.Text.RegularExpressions;
using Bible2PPT.Bibles;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.PowerPoint;
using Shape = Microsoft.Office.Interop.PowerPoint.Shape;

namespace Bible2PPT.PPT;

public partial class PPTManager
{
    public Job Job { get; }
    public string Output { get; }

    private readonly Presentation WorkingPPT;
    private readonly Slide TemplateSlide;

    public PPTManager(Application POWERPNT, Job job, string output)
    {
        Job = job;
        Output = output;
        Directory.CreateDirectory(Path.GetDirectoryName(output));

        File.Copy(job.Template.FileName, Output, true);

        WorkingPPT = POWERPNT.Presentations.Open(output, WithWindow: MsoTriState.msoFalse);
        TemplateSlide = WorkingPPT.Slides[1];
    }

    public void Save()
    {
        TemplateSlide?.Delete();
        WorkingPPT?.Save();
    }

    public void QuitAndCleanup()
    {
        WorkingPPT?.Close();
        if (Output != null && File.Exists(Output))
        {
            File.Delete(Output);
        }
    }

    private bool isFirstVerseOfChapter;

    public async Task AppendChapter(IAsyncEnumerable<IEnumerable<Verse?>> eachVerses, Book book, Chapter chapter, int startVerseNumber, int? endVerseNumber, CancellationToken token)
    {
        isFirstVerseOfChapter = true;
        await foreach (var eachVerse in eachVerses)
        {
            token.ThrowIfCancellationRequested();

            var mainVerse = eachVerse.FirstOrDefault(i => i != null);
            if (mainVerse == null)
            {
                continue;
            }

            AppendVerse(eachVerse, mainVerse, book, chapter, startVerseNumber, endVerseNumber, token);

            isFirstVerseOfChapter = false;
        }
    }

    public void AppendVerse(IEnumerable<Verse?> eachVerse, Verse mainVerse, Book book, Chapter chapter, int startVerseNumber, int? endVerseNumber, CancellationToken token) =>
        AppendVerse(eachVerse.Select(verse => verse?.Text).ToList(), mainVerse, book, chapter, startVerseNumber, endVerseNumber, token);

    private void AppendVerse(IEnumerable<string?> eachVerseText, Verse mainVerse, Book book, Chapter chapter, int startVerseNumber, int? endVerseNumber, CancellationToken token)
    {
        var slide = AppendTemplateSlide();
        var textShapes = slide.Shapes.Cast<Shape>()
                .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                .Select(i => i.TextFrame.TextRange)
                .ToList();

        foreach (var textShape in textShapes)
        {
            var text = textShape.Text;

            text = AddSuffix(text, "CHAP", $"{chapter.Number}", Job.Template.ChapterNumberVisible);
            text = AddSuffix(text, "STITLE", book.AbbreviationInfo, Job.Template.BookAbbrVisible);
            text = AddSuffix(text, "TITLE", book.NameInfo, Job.Template.BookNameVisible);
            text = text.Replace("[CPAS]", $"{startVerseNumber}");
            text = text.Replace("[CPAE]", $"{endVerseNumber}");
            text = text.Replace("[PARA]", $"{mainVerse.Number}");

            textShape.Text = text;
        }

        // 설정한 줄 수를 초과하는 성경 구절을 새 슬라이드로 분할하도록 동작
        var overflowedEachVerseText = new string[9];

        foreach (var textShape in textShapes.Where(textShape => Regex.IsMatch(textShape.Text, @"\[BODY[1-9]?\]")))
        {
            ReplaceVerseTextAndProcessOverflow(textShape, null, eachVerseText.First());

            var verseEnumerator = eachVerseText.GetEnumerator();
            for (var i = 1; i <= 9; i++)
            {
                var verse = verseEnumerator.MoveNext() ? verseEnumerator.Current : null;
                ReplaceVerseTextAndProcessOverflow(textShape, i, verse);
            }
        }

        if (!overflowedEachVerseText.All(string.IsNullOrEmpty))
        {
            AppendVerse(overflowedEachVerseText, mainVerse, book, chapter, startVerseNumber, endVerseNumber, token);
        }

        void ReplaceVerseTextAndProcessOverflow(TextRange textShape, int? index, string text)
        {
            // 치환자가 위치한 줄은 치환할 예정이므로 계산에 미포함하여 -1
            var lineCount = textShape.Lines().Count - 1;

            // 성경 구절을 PPT로 만들 때 몇 줄인지 계산할 수 있게 치환
            var replacedText = textShape.Text.Replace($"[BODY{index}]", text);
            textShape.Text = replacedText;

            // 슬라이드 분할 기능을 사용하지 않으면 이대로 종료
            if (Job.Template.NumberOfVerseLinesPerSlide < 1)
            {
                return;
            }

            // 설정한 줄 수를 초과하지 않게 뒷 부분을 잘라냄
            var trimmedText = textShape.Lines(Length: lineCount + Job.Template.NumberOfVerseLinesPerSlide).Text;
            textShape.Text = trimmedText;

            // 잘라낸 뒷 부분을 새 슬라이드로 추가하도록 저장
            var overflowedText = replacedText.Substring(trimmedText.Length).Trim();
            if (!string.IsNullOrEmpty(overflowedText))
            {
                overflowedEachVerseText[(index ?? 1) - 1] = overflowedText;
            }
        }
    }

    private SlideRange AppendTemplateSlide()
    {
        var slide = TemplateSlide.Duplicate();
        slide.MoveTo(WorkingPPT.Slides.Count);
        return slide;
    }

    private bool ShouldPrint(TemplateTextOptions templateOption) => templateOption switch
    {
        TemplateTextOptions.Always => true,
        TemplateTextOptions.FirstVerseOfChapter => isFirstVerseOfChapter,
        _ => throw new NotImplementedException(),
    };

    private string AddSuffix(string str, string toFind, string replace, TemplateTextOptions templateOption)
    {
        return Regex.Replace(str, $@"\[{toFind}(?::(.*?))?\]", ShouldPrint(templateOption) ? $"{replace}$1" : "");
    }
}
