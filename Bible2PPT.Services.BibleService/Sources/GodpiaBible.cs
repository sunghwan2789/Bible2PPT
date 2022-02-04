using System.Globalization;
using System.Text.RegularExpressions;
using Bible2PPT.Bibles;

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
        }).ToList();
    }

    public override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
    {
        var data = await client.GetStringAsync($"/read/reading.asp?ver={bible.OnlineId}").ConfigureAwait(false);
        data = string.Join("", Regex.Matches(data, @"<select id=""selectBibleSub[12]"".+?</select>", RegexOptions.Singleline).Cast<Match>().Select(i => i.Groups[0].Value));
        var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
        return matches.Cast<Match>().Select(i => new Book
        {
            OnlineId = i.Groups[1].Value,
            Name = i.Groups[2].Value,
        }).ToList();
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
}
