using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Bible2PPT.Bibles;

namespace Bible2PPT.Sources
{
    class GodpeopleBible : BibleSource
    {
        private const string BASE_URL = "http://find.godpeople.com";
        private static readonly Encoding ENCODING = Encoding.GetEncoding("EUC-KR");

        private static readonly HttpClient client = new HttpClient
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
                },
                new Bible
                {
                    OnlineId = "ezsn",
                    Name = "쉬운성경",
                },
            });

        public override async Task<List<Book>> GetBooksOnlineAsync(Bible bible)
        {
            var data = ENCODING.GetString(await client.GetByteArrayAsync("/?page=bidx"));
            var matches = Regex.Matches(data, @"option\s.+?'(.+?)'.+?(\d+).+?>(.+?)<");
            return matches.Cast<Match>().Select(match => new Book
            {
                OnlineId = match.Groups[1].Value,
                Name = match.Groups[3].Value,
                Abbreviation = match.Groups[1].Value,
                ChapterCount = int.Parse(match.Groups[2].Value),
            }).ToList();
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
            var data = ENCODING.GetString(await client.GetByteArrayAsync($"/?page=bidx&kwrd={EncodeString(chapter.Book.OnlineId)}{chapter.OnlineId}&vers={chapter.Book.Bible.OnlineId}"));
            var matches = Regex.Matches(data, @"bidx_listTd_yak.+?>(\d+)[\s\S]+?bidx_listTd_phrase.+?>(.+?)</td");
            return matches.Cast<Match>().Select(i => new Verse
            {
                Number = int.Parse(i.Groups[1].Value),
                Text = StripHtmlTags(i.Groups[2].Value),
            }).ToList();
        }
    }
}
