using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bible2PPT.Extensions;

namespace Bible2PPT.Bibles.Sources
{
    class GoodtvBible : Source
    {
        private const string BASE_URL = "http://goodtvbible.goodtv.co.kr";

        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri(BASE_URL),
            Timeout = TimeSpan.FromSeconds(5),
        };

        public GoodtvBible()
        {
            Name = "GOODTV 성경";
        }

        protected override async Task<List<Bible>> GetBiblesOnlineAsync()
        {
            var data = await client.GetStringAsync("/bible.asp");
            var matches = Regex.Matches(data, @"bible_check"".+?value=""(\d+)""[\s\S]+?<span.+?>(.+?)<");
            return matches.Cast<Match>().Select(i => new Bible
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
            }).ToList();
        }

        protected override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
        {
            // TODO: WhenAll?
            var tasks = new[]
            {
                client.PostAndGetStringAsync("/bible_otnt_exc.asp", new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("bible_idx", "1"),
                    new KeyValuePair<string, string>("otnt", "1"),
                })),
                client.PostAndGetStringAsync("/bible_otnt_exc.asp", new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("bible_idx", "1"),
                    new KeyValuePair<string, string>("otnt", "2"),
                })),
            };
            var data = string.Join("", await TaskEx.WhenAll(tasks));
            var matches = Regex.Matches(data, @"""idx"":(\d+).+?""bible_name"":""(.+?)"".+?""max_jang"":(\d+)");
            return matches.Cast<Match>().Select(i => new Book
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
                ChapterCount = int.Parse(i.Groups[3].Value),
            }).ToList();
        }

        protected override Task<List<Chapter>> GetChaptersOnlineAsync(Book book) =>
            TaskEx.FromResult(Enumerable.Range(1, book.ChapterCount)
                .Select(i => new Chapter
                {
                    OnlineId = $"{i}",
                    Number = i,
                }).ToList());

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        protected override async Task<List<Verse>> GetVersesOnlineAsync(Chapter chapter)
        {
            var data = await client.PostAndGetStringAsync("/bible.asp", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("bible_idx", chapter.Book.OnlineId),
                new KeyValuePair<string, string>("jang_idx", chapter.OnlineId),
                new KeyValuePair<string, string>("bible_version_1", chapter.Book.Bible.OnlineId),
                new KeyValuePair<string, string>("bible_version_2", "0"),
                new KeyValuePair<string, string>("bible_version_3", "0"),
                new KeyValuePair<string, string>("count", "1"),
            }));
            data = Regex.Match(data, @"<p id=""one_jang""><b>([\s\S]+?)</b></p>").Groups[1].Value;
            var matches = Regex.Matches(data, @"<b>(\d+).*?</b>(.*?)<br>");
            return matches.Cast<Match>().Select(i => new Verse
            {
                Number = int.Parse(i.Groups[1].Value),
                Text = StripHtmlTags(i.Groups[2].Value),
            }).ToList();
        }
    }
}
