using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bible2PPT.Bibles.Sources
{
    class GodpiaBible : BibleSource
    {
        private const string BASE_URL = "http://bible.godpia.com";

        private BetterWebClient client = new BetterWebClient
        {
            BaseAddress = BASE_URL,
            Encoding = Encoding.UTF8,
        };

        public GodpiaBible()
        {
            Name = "갓피아 성경";
        }

        protected override List<BibleVersion> GetBiblesOnline()
        {
            var data = client.DownloadString($"/index.asp");
            var matches = Regex.Matches(data, @"#(.+?)"" class=""clickReadBible"">(.+?)</");
            return matches.Cast<Match>().Select(i => new BibleVersion
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
            }).ToList();
        }

        protected override List<BibleBook> GetBooksOnline(BibleVersion bible)
        {
            var data = client.DownloadString($"/read/reading.asp?ver={bible.OnlineId}");
            data = string.Join("", Regex.Matches(data, @"<select id=""selectBibleSub[12]"".+?</select>", RegexOptions.Singleline).Cast<Match>().Select(i => i.Groups[0].Value));
            var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
            return matches.Cast<Match>().Select(i => new BibleBook
            {
                OnlineId = i.Groups[1].Value,
                Title = i.Groups[2].Value,
            }).ToList();
        }

        protected override List<BibleChapter> GetChaptersOnline(BibleBook book)
        {
            var data = client.DownloadString($"/read/reading.asp?ver={book.Bible.OnlineId}&vol={book.OnlineId}");
            data = Regex.Match(data, @"<select id=""selectBibleSub3"".+?</select>", RegexOptions.Singleline).Groups[0].Value;
            var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
            return matches.Cast<Match>().Select(i => new BibleChapter
            {
                Number = int.Parse(i.Groups[1].Value),
            }).ToList();
        }

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        protected override List<BibleVerse> GetVersesOnline(BibleChapter chapter)
        {
            var data = client.DownloadString($"/read/reading.asp?ver={chapter.Book.Bible.OnlineId}&vol={chapter.Book.OnlineId}&chap={chapter.Number}");
            var matches = Regex.Matches(data, @"class=""num"".*?</span>(.*?)</p>");
            var verseNum = 0;
            return matches.Cast<Match>().Select(i => new BibleVerse
            {
                Number = ++verseNum,
                Text = StripHtmlTags(i.Groups[1].Value),
            }).ToList();
        }
    }
}
