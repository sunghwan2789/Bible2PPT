using System.Globalization;
using System.Text.RegularExpressions;
using Bible2PPT.Bibles;
using Bible2PPT.Services.BibleIndexService;

namespace Bible2PPT.Sources;

public class GodpiaBible : BibleSource
{
    private const string BASE_URL = "http://bible.godpia.com";

    private static readonly HttpClient client = new()
    {
        BaseAddress = new Uri(BASE_URL),
        Timeout = TimeSpan.FromSeconds(5),
    };

    public GodpiaBible()
    {
        Name = "갓피아 성경";
    }

    public override async Task<List<Bible>> GetBiblesOnlineAsync()
    {
        var data = await client.GetStringAsync($"/index.asp").ConfigureAwait(false);
        var matches = Regex.Matches(data, @"#(.+?)"" class=""clickReadBible"">(.+?)</");
        return matches.Cast<Match>().Select(i => new Bible
        {
            OnlineId = i.Groups[1].Value,
            Name = i.Groups[2].Value,
        }).Select(x => x with { LanguageCode = GetLanguageCode(x) }).ToList();
    }

    public override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
    {
        var data = await client.GetStringAsync($"/read/reading.asp?ver={bible.OnlineId}").ConfigureAwait(false);
        data = string.Join("", Regex.Matches(data, @"id=""bibleTab([12])"".+?class=""(.+?)""").Cast<Match>()
            .Where(x => !x.Groups[2].Value.Contains("noEvent"))
            .Select(x => Regex.Match(data, @$"<select id=""selectBibleSub{x.Groups[1].Value}""[\s\S]+?</select>").Groups[0].Value));
        var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
        return matches.Cast<Match>().Select(i => new Book
        {
            OnlineId = i.Groups[1].Value,
            Name = i.Groups[2].Value,
        }).Select(x => x with { Key = GetBookKey(x) }).ToList();
    }

    public override async Task<List<Chapter>> GetChaptersOnlineAsync(Book book)
    {
        var data = await client.GetStringAsync($"/read/reading.asp?ver={book.Bible.OnlineId}&vol={book.OnlineId}").ConfigureAwait(false);
        data = Regex.Match(data, @"<select id=""selectBibleSub3"".+?</select>", RegexOptions.Singleline).Groups[0].Value;
        var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
        return matches.Cast<Match>().Select(i => new Chapter
        {
            OnlineId = i.Groups[1].Value,
            Number = int.Parse(i.Groups[1].Value, CultureInfo.InvariantCulture),
        }).ToList();
    }

    private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

    public override async Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter)
    {
        var data = await client.GetStringAsync($"/read/reading.asp?ver={chapter.Book.Bible.OnlineId}&vol={chapter.Book.OnlineId}&chap={chapter.OnlineId}").ConfigureAwait(false);
        var matches = Regex.Matches(data, @"class=""num"">(\d+).*?</span>(.*?)</p>");
        return matches.Cast<Match>().Select(i => new Verse
        {
            Number = int.Parse(i.Groups[1].Value, CultureInfo.InvariantCulture),
            Text = StripHtmlTags(i.Groups[2].Value),
        }).ToList();
    }

    private static string GetLanguageCode(Bible bible) => bible.OnlineId switch
    {
        "gae" or "han" or "easy" or "cognew" or "hyun" or "saenew" => "ko",
        "niv" => "en",
        "hebrew" => "he",
        "greek" => "el",
        _ => throw new NotImplementedException(),
    };

    private static BookKey GetBookKey(Book book) => book.OnlineId switch
    {
        "gen" => BookKey.Genesis,
        "exo" => BookKey.Exodus,
        "lev" => BookKey.Leviticus,
        "num" => BookKey.Numbers,
        "deu" => BookKey.Deuteronomy,
        "jos" => BookKey.Joshua,
        "jdg" => BookKey.Judges,
        "rut" => BookKey.Ruth,
        "1sa" => BookKey.ISamuel,
        "2sa" => BookKey.IISamuel,
        "1ki" => BookKey.IKings,
        "2ki" => BookKey.IIKings,
        "1ch" => BookKey.IChronicles,
        "2ch" => BookKey.IIChronicles,
        "ezr" => BookKey.Ezra,
        "neh" => BookKey.Nehemiah,
        "est" => BookKey.Esther,
        "job" => BookKey.Job,
        "psa" => BookKey.Psalms,
        "pro" => BookKey.Proverbs,
        "ecc" => BookKey.Ecclesiastes,
        "sng" => BookKey.SongOfSolomon,
        "isa" => BookKey.Isaiah,
        "jer" => BookKey.Jeremiah,
        "lam" => BookKey.Lamentations,
        "ezk" => BookKey.Ezekiel,
        "dan" => BookKey.Daniel,
        "hos" => BookKey.Hosea,
        "jol" => BookKey.Joel,
        "amo" => BookKey.Amos,
        "oba" => BookKey.Obadiah,
        "jnh" => BookKey.Jonah,
        "mic" => BookKey.Micah,
        "nam" => BookKey.Nahum,
        "hab" => BookKey.Habakkuk,
        "zep" => BookKey.Zephaniah,
        "hag" => BookKey.Haggai,
        "zec" => BookKey.Zechariah,
        "mal" => BookKey.Malachi,
        "mat" => BookKey.Matthew,
        "mrk" => BookKey.Mark,
        "luk" => BookKey.Luke,
        "jhn" => BookKey.John,
        "act" => BookKey.Acts,
        "rom" => BookKey.Romans,
        "1co" => BookKey.ICorinthians,
        "2co" => BookKey.IICorinthians,
        "gal" => BookKey.Galatians,
        "eph" => BookKey.Ephesians,
        "php" => BookKey.Philippians,
        "col" => BookKey.Colossians,
        "1th" => BookKey.IThessalonians,
        "2th" => BookKey.IIThessalonians,
        "1ti" => BookKey.ITimothy,
        "2ti" => BookKey.IITimothy,
        "tit" => BookKey.Titus,
        "phm" => BookKey.Philemon,
        "heb" => BookKey.Hebrews,
        "jas" => BookKey.James,
        "1pe" => BookKey.IPeter,
        "2pe" => BookKey.IIPeter,
        "1jn" => BookKey.IJohn,
        "2jn" => BookKey.IIJohn,
        "3jn" => BookKey.IIIJohn,
        "jud" => BookKey.Jude,
        "rev" => BookKey.Revelation,
        _ => throw new NotImplementedException(),
    };
}
