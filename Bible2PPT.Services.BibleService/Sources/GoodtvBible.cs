using System.Globalization;
using System.Text.RegularExpressions;
using Bible2PPT.Bibles;
using Bible2PPT.Extensions;
using Bible2PPT.Services.BibleIndexService;

namespace Bible2PPT.Sources;

public class GoodtvBible : BibleSource
{
    private const string BASE_URL = "http://goodtvbible.goodtv.co.kr";

    private static readonly HttpClient client = new()
    {
        BaseAddress = new Uri(BASE_URL),
        Timeout = TimeSpan.FromSeconds(5),
    };

    public GoodtvBible()
    {
        Name = "GOODTV 성경";
    }

    public override async Task<List<Bible>> GetBiblesOnlineAsync()
    {
        var data = await client.GetStringAsync("/bible.asp").ConfigureAwait(false);
        var matches = Regex.Matches(data, @"id=""span_(\d+)"">(.+?)<");
        return matches.Cast<Match>().Select(i => new Bible
        {
            OnlineId = i.Groups[1].Value,
            Name = i.Groups[2].Value,
        }).Select(x => x with { LanguageCode = GetLanguageCode(x) }).ToList();
    }

    public override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
    {
        using var oldContent = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["bible_idx"] = "1",
            ["otnt"] = "1",
        });
        using var newContent = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["bible_idx"] = "1",
            ["otnt"] = "2",
        });
        var data = string.Join("", await Task.WhenAll(
            client.PostAndGetStringAsync("/bible_otnt_exc.asp", oldContent),
            client.PostAndGetStringAsync("/bible_otnt_exc.asp", newContent)).ConfigureAwait(false));
        var matches = Regex.Matches(data, @"""idx"":(\d+).+?""bible_name"":""(.+?)"".+?""max_jang"":(\d+)");
        return matches.Cast<Match>().Select(i => new Book
        {
            OnlineId = i.Groups[1].Value,
            Name = i.Groups[2].Value,
            ChapterCount = int.Parse(i.Groups[3].Value, CultureInfo.InvariantCulture),
        }).Select(x => x with { Key = GetBookKey(x) }).ToList();
    }

    public override Task<List<Chapter>> GetChaptersOnlineAsync(Book book) =>
        Task.FromResult(Enumerable.Range(1, book.ChapterCount)
            .Select(i => new Chapter
            {
                OnlineId = $"{i}",
                Number = i,
            }).ToList());

    private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

    public override async Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter)
    {
        using var content = new FormUrlEncodedContent(new Dictionary<string, string>
        {
            ["bible_idx"] = chapter.Book.OnlineId,
            ["jang_idx"] = chapter.OnlineId,
            ["bible_version_1"] = chapter.Book.Bible.OnlineId,
            ["bible_version_2"] = "0",
            ["bible_version_3"] = "0",
            ["count"] = "1",
        });
        var data = await client.PostAndGetStringAsync("/bible.asp", content).ConfigureAwait(false);
        data = Regex.Match(data, @"<p id=""one_jang""><b>([\s\S]+?)</b></p>").Groups[1].Value;
        var matches = Regex.Matches(data, @"<b>(\d+).*?</b>(.*?)<br>");
        return matches.Cast<Match>().Select(i => new Verse
        {
            Number = int.Parse(i.Groups[1].Value, CultureInfo.InvariantCulture),
            Text = StripHtmlTags(i.Groups[2].Value),
        }).ToList();
    }

    private static string GetLanguageCode(Bible bible) => bible.OnlineId switch
    {
        "2" or "1" or "3" or "4" or "16" => "ko",
        "6" or "7" or "8" => "en",
        "10" or "11" => "ja",
        "14" => "zh-tw",
        "15" => "zh-cn",
        "19" => "he",
        "18" => "el",
        _ => throw new NotImplementedException(),
    };

    private static BookKey GetBookKey(Book book) => book.OnlineId switch
    {
        "1" => BookKey.Genesis,
        "2" => BookKey.Exodus,
        "3" => BookKey.Leviticus,
        "4" => BookKey.Numbers,
        "5" => BookKey.Deuteronomy,
        "6" => BookKey.Joshua,
        "7" => BookKey.Judges,
        "8" => BookKey.Ruth,
        "9" => BookKey.ISamuel,
        "10" => BookKey.IISamuel,
        "11" => BookKey.IKings,
        "12" => BookKey.IIKings,
        "13" => BookKey.IChronicles,
        "14" => BookKey.IIChronicles,
        "15" => BookKey.Ezra,
        "16" => BookKey.Nehemiah,
        "17" => BookKey.Esther,
        "18" => BookKey.Job,
        "19" => BookKey.Psalms,
        "20" => BookKey.Proverbs,
        "21" => BookKey.Ecclesiastes,
        "22" => BookKey.SongOfSolomon,
        "23" => BookKey.Isaiah,
        "24" => BookKey.Jeremiah,
        "25" => BookKey.Lamentations,
        "26" => BookKey.Ezekiel,
        "27" => BookKey.Daniel,
        "28" => BookKey.Hosea,
        "29" => BookKey.Joel,
        "30" => BookKey.Amos,
        "31" => BookKey.Obadiah,
        "32" => BookKey.Jonah,
        "33" => BookKey.Micah,
        "34" => BookKey.Nahum,
        "35" => BookKey.Habakkuk,
        "36" => BookKey.Zephaniah,
        "37" => BookKey.Haggai,
        "38" => BookKey.Zechariah,
        "39" => BookKey.Malachi,
        "40" => BookKey.Matthew,
        "41" => BookKey.Mark,
        "42" => BookKey.Luke,
        "43" => BookKey.John,
        "44" => BookKey.Acts,
        "45" => BookKey.Romans,
        "46" => BookKey.ICorinthians,
        "47" => BookKey.IICorinthians,
        "48" => BookKey.Galatians,
        "49" => BookKey.Ephesians,
        "50" => BookKey.Philippians,
        "51" => BookKey.Colossians,
        "52" => BookKey.IThessalonians,
        "53" => BookKey.IIThessalonians,
        "54" => BookKey.ITimothy,
        "55" => BookKey.IITimothy,
        "56" => BookKey.Titus,
        "57" => BookKey.Philemon,
        "58" => BookKey.Hebrews,
        "59" => BookKey.James,
        "60" => BookKey.IPeter,
        "61" => BookKey.IIPeter,
        "62" => BookKey.IJohn,
        "63" => BookKey.IIJohn,
        "64" => BookKey.IIIJohn,
        "65" => BookKey.Jude,
        "66" => BookKey.Revelation,
        _ => throw new NotImplementedException(),
    };
}
