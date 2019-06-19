using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bible2PPT.Bibles.Sources
{
    class GodpiaBible : BibleSource
    {
        private const string BASE_URL = "http://bible.godpia.com";

        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(BASE_URL),
            Timeout = TimeSpan.FromSeconds(5),
        };

        public GodpiaBible()
        {
            Name = "갓피아 성경";
        }

        protected override async Task<List<Bible>> GetBiblesOnlineAsync()
        {
            var data = await client.GetStringAsync($"/index.asp");
            var matches = Regex.Matches(data, @"#(.+?)"" class=""clickReadBible"">(.+?)</");
            return matches.Cast<Match>().Select(i => new Bible
            {
                OnlineId = i.Groups[1].Value,
                Version = i.Groups[2].Value,
            }).ToList();
        }

        protected override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
        {
            var data = await client.GetStringAsync($"/read/reading.asp?ver={bible.OnlineId}");
            data = string.Join("", Regex.Matches(data, @"<select id=""selectBibleSub[12]"".+?</select>", RegexOptions.Singleline).Cast<Match>().Select(i => i.Groups[0].Value));
            var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
            var books = matches.Cast<Match>().Select(i => new Book
            {
                OnlineId = i.Groups[1].Value,
                Title = i.Groups[2].Value,
                // TODO: ChapterCount 필요하지 않게 만들기
                Bible = bible,
            }).ToList();
            var chapters = books.Select(GetChaptersAsync).ToList();
            for (var i = 0; i < books.Count; i++)
            {
                books[i].ChapterCount = (await chapters[i]).Count;
            }
            return books;
        }

        protected override async Task<List<Chapter>> GetChaptersOnlineAsync(Book book)
        {
            var data = await client.GetStringAsync($"/read/reading.asp?ver={book.Bible.OnlineId}&vol={book.OnlineId}");
            data = Regex.Match(data, @"<select id=""selectBibleSub3"".+?</select>", RegexOptions.Singleline).Groups[0].Value;
            var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
            return matches.Cast<Match>().Select(i => new Chapter
            {
                Number = int.Parse(i.Groups[1].Value),
            }).ToList();
        }

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        protected override async Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter)
        {
            var data = await client.GetStringAsync($"/read/reading.asp?ver={chapter.Book.Bible.OnlineId}&vol={chapter.Book.OnlineId}&chap={chapter.Number}");
            var matches = Regex.Matches(data, @"class=""num"">(\d+).*?</span>(.*?)</p>");
            return matches.Cast<Match>().Select(i => new Verse
            {
                Number = int.Parse(i.Groups[1].Value),
                Text = StripHtmlTags(i.Groups[2].Value),
            }).ToList();
        }
    }
}
