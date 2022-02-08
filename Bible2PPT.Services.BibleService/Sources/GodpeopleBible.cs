using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Bible2PPT.Bibles;
using Bible2PPT.Services.BibleIndexService;

namespace Bible2PPT.Sources;

public class GodpeopleBible : BibleSource
{
    private const string BASE_URL = "http://find.godpeople.com";
    private static readonly Encoding ENCODING = Encoding.GetEncoding("EUC-KR");

    private static readonly HttpClient client = new()
    {
        BaseAddress = new Uri(BASE_URL),
        Timeout = TimeSpan.FromSeconds(5),
    };

    public GodpeopleBible()
    {
        Name = "갓피플 성경";
    }

    public override Task<List<Bible>> GetBiblesOnlineAsync() =>
        Task.FromResult(new List<Bible>
        {
            new Bible
            {
                OnlineId = "rvsn",
                Name = "개역개정",
                LanguageCode = "ko",
            },
            new Bible
            {
                OnlineId = "ezsn",
                Name = "쉬운성경",
                LanguageCode = "ko",
            },
        });

    public override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
    {
        var data = ENCODING.GetString(await client.GetByteArrayAsync("/?page=bidx").ConfigureAwait(false));
        var matches = Regex.Matches(data, @"option\s.+?'(.+?)'.+?(\d+).+?>(.+?)<");
        return matches.Cast<Match>().Select(match => new Book
        {
            OnlineId = match.Groups[1].Value,
            Name = match.Groups[3].Value,
            Abbreviation = match.Groups[1].Value,
            ChapterCount = int.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture),
        }).Select(x => x with { Key = GetBookKey(x) }).ToList();
    }

    private static string EncodeString(string s) =>
        string.Join("", ENCODING.GetBytes(s).Select(b => $"%{b:X}"));

    public override Task<List<Chapter>> GetChaptersOnlineAsync(Book book) =>
        Task.FromResult(Enumerable.Range(1, book.ChapterCount)
            .Select(i => new Chapter
            {
                OnlineId = $"{i}",
                Number = i,
            }).ToList());

    private static string StripHtmlTags(string s) => Regex.Replace(s, @"<u.+?u>|<.+?>", "", RegexOptions.Singleline);

    public override async Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter)
    {
        var data = ENCODING.GetString(await client.GetByteArrayAsync($"/?page=bidx&kwrd={EncodeString(chapter.Book.OnlineId)}{chapter.OnlineId}&vers={chapter.Book.Bible.OnlineId}").ConfigureAwait(false));
        var matches = Regex.Matches(data, @"bidx_listTd_yak.+?>(\d+)[\s\S]+?bidx_listTd_phrase.+?>(.+?)</td");
        return matches.Cast<Match>().Select(i => new Verse
        {
            Number = int.Parse(i.Groups[1].Value, CultureInfo.InvariantCulture),
            Text = StripHtmlTags(i.Groups[2].Value),
        }).ToList();
    }

    private static BookKey GetBookKey(Book book) => book.OnlineId switch
    {
        "창" => BookKey.Genesis,
        "출" => BookKey.Exodus,
        "레" => BookKey.Leviticus,
        "민" => BookKey.Numbers,
        "신" => BookKey.Deuteronomy,
        "수" => BookKey.Joshua,
        "삿" => BookKey.Judges,
        "룻" => BookKey.Ruth,
        "삼상" => BookKey.ISamuel,
        "삼하" => BookKey.IISamuel,
        "왕상" => BookKey.IKings,
        "왕하" => BookKey.IIKings,
        "대상" => BookKey.IChronicles,
        "대하" => BookKey.IIChronicles,
        "스" => BookKey.Ezra,
        "느" => BookKey.Nehemiah,
        "에" => BookKey.Esther,
        "욥" => BookKey.Job,
        "시" => BookKey.Psalms,
        "잠" => BookKey.Proverbs,
        "전" => BookKey.Ecclesiastes,
        "아" => BookKey.SongOfSolomon,
        "사" => BookKey.Isaiah,
        "렘" => BookKey.Jeremiah,
        "애" => BookKey.Lamentations,
        "겔" => BookKey.Ezekiel,
        "단" => BookKey.Daniel,
        "호" => BookKey.Hosea,
        "욜" => BookKey.Joel,
        "암" => BookKey.Amos,
        "옵" => BookKey.Obadiah,
        "욘" => BookKey.Jonah,
        "미" => BookKey.Micah,
        "나" => BookKey.Nahum,
        "합" => BookKey.Habakkuk,
        "습" => BookKey.Zephaniah,
        "학" => BookKey.Haggai,
        "슥" => BookKey.Zechariah,
        "말" => BookKey.Malachi,
        "마" => BookKey.Matthew,
        "막" => BookKey.Mark,
        "눅" => BookKey.Luke,
        "요" => BookKey.John,
        "행" => BookKey.Acts,
        "롬" => BookKey.Romans,
        "고전" => BookKey.ICorinthians,
        "고후" => BookKey.IICorinthians,
        "갈" => BookKey.Galatians,
        "엡" => BookKey.Ephesians,
        "빌" => BookKey.Philippians,
        "골" => BookKey.Colossians,
        "살전" => BookKey.IThessalonians,
        "살후" => BookKey.IIThessalonians,
        "딤전" => BookKey.ITimothy,
        "딤후" => BookKey.IITimothy,
        "딛" => BookKey.Titus,
        "몬" => BookKey.Philemon,
        "히" => BookKey.Hebrews,
        "약" => BookKey.James,
        "벧전" => BookKey.IPeter,
        "벧후" => BookKey.IIPeter,
        "요일" => BookKey.IJohn,
        "요이" => BookKey.IIJohn,
        "요삼" => BookKey.IIIJohn,
        "유" => BookKey.Jude,
        "계" => BookKey.Revelation,
        _ => throw new NotImplementedException(),
    };
}
