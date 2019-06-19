using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bible2PPT.Bibles.Sources
{
    class GoodtvBible : BibleSource
    {
        private const string BASE_URL = "http://goodtvbible.goodtv.co.kr";

        private BetterWebClient client = new BetterWebClient
        {
            BaseAddress = BASE_URL,
            Encoding = Encoding.UTF8,
        };

        public GoodtvBible()
        {
            Name = "GOODTV 성경";
        }

        protected override List<Bible> GetBiblesOnline()
        {
            var data = client.DownloadString("/bible.asp");
            var matches = Regex.Matches(data, @"bible_check"".+?value=""(\d+)""[\s\S]+?<span.+?>(.+?)<");
            return matches.Cast<Match>().Select(i => new Bible
            {
                OnlineId = i.Groups[1].Value,
                Version = i.Groups[2].Value,
            }).ToList();
        }

        protected override List<Book> GetBooksOnline(Bible bible)
        {
            var oldData = client.UploadValues("/bible_otnt_exc.asp", new System.Collections.Specialized.NameValueCollection
            {
                { "bible_idx", "1" },
                { "otnt", "1" },
            });
            var newData = client.UploadValues("/bible_otnt_exc.asp", new System.Collections.Specialized.NameValueCollection
            {
                { "bible_idx", "1" },
                { "otnt", "2" },
            });
            var data = Encoding.UTF8.GetString(oldData) + Encoding.UTF8.GetString(newData);
            var matches = Regex.Matches(data, @"""idx"":(\d+).+?""bible_name"":""(.+?)"".+?""max_jang"":(\d+)");
            return matches.Cast<Match>().Select(i => new Book
            {
                OnlineId = i.Groups[1].Value,
                Title = i.Groups[2].Value,
                ChapterCount = int.Parse(i.Groups[3].Value),
            }).ToList();
        }

        protected override List<Chapter> GetChaptersOnline(Book book) =>
            Enumerable.Range(1, book.ChapterCount)
                .Select(i => new Chapter
                {
                    Number = i,
                }).ToList();
        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        protected override List<Verse> GetVersesOnline(Chapter chapter)
        {
            var data = Encoding.UTF8.GetString(client.UploadValues("/bible.asp", new System.Collections.Specialized.NameValueCollection
            {
                { "bible_idx", chapter.Book.OnlineId },
                { "jang_idx", chapter.Number.ToString() },
                { "bible_version_1", chapter.Book.Bible.OnlineId },
                { "bible_version_2", "0" },
                { "bible_version_3", "0" },
                { "count", "1" },
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
