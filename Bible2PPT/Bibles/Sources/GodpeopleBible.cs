using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Bible2PPT.Bibles.Sources
{
    class GodpeopleBible : BibleSource
    {
        private const string BASE_URL = "http://find.godpeople.com";
        private static readonly Encoding ENCODING = Encoding.GetEncoding("EUC-KR");

        private BetterWebClient client = new BetterWebClient
        {
            BaseAddress = BASE_URL,
            Encoding = ENCODING,
        };

        public GodpeopleBible()
        {
            Name = "갓피플 성경";
        }

        protected override List<BibleVersion> GetBiblesOnline() => new List<BibleVersion>
        {
            new BibleVersion
            {
                OnlineId = "rvsn",
                Name = "개역개정",
            },
            new BibleVersion
            {
                OnlineId = "ezsn",
                Name = "쉬운성경",
            },
        };

        protected override List<BibleBook> GetBooksOnline(BibleVersion bible)
        {
            var data = client.DownloadString("/?page=bidx");
            var matches = Regex.Matches(data, @"option\s.+?'(.+?)'.+?(\d+).+?>(.+?)<");
            return matches.Cast<Match>().Select(match => new BibleBook
            {
                OnlineId = match.Groups[1].Value,
                Title = match.Groups[3].Value,
                ShortTitle = match.Groups[1].Value,
                ChapterCount = int.Parse(match.Groups[2].Value),
            }).ToList();
        }

        private static string EncodeString(string s) =>
            string.Join("", ENCODING.GetBytes(s).Select(b => $"%{b.ToString("X")}"));

        protected override List<BibleChapter> GetChaptersOnline(BibleBook book) =>
            Enumerable.Range(1, book.ChapterCount)
                .Select(i => new BibleChapter
                {
                    Number = i,
                }).ToList();

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<u.+?u>|<.+?>", "", RegexOptions.Singleline);

        protected override List<BibleVerse> GetVersesOnline(BibleChapter chapter)
        {
            var data = client.DownloadString($"/?page=bidx&kwrd={EncodeString(chapter.Book.OnlineId)}{chapter.Number}&vers={chapter.Book.Bible.OnlineId}");
            var matches = Regex.Matches(data, @"bidx_listTd_yak.+?>(\d+)[\s\S]+?bidx_listTd_phrase.+?>(.+?)</td");
            return matches.Cast<Match>().Select(i => new BibleVerse
            {
                Number = int.Parse(i.Groups[1].Value),
                Text = StripHtmlTags(i.Groups[2].Value),
            }).ToList();
        }
    }
}
