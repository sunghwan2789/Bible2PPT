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

        public override List<Bible> GetBibles()
        {
            var data = client.DownloadString($"/index.asp");
            var matches = Regex.Matches(data, @"#(.+?)"" class=""clickReadBible"">(.+?)</");
            return matches.Cast<Match>().Select(i => new Bible
            {
                Source = this,
                OnlineId = i.Groups[1].Value,
                Version = i.Groups[2].Value,
            }).ToList();
        }

        public override List<BibleBook> GetBooks(Bible bible)
        {
            var data = client.DownloadString($"/read/reading.asp?ver={bible.OnlineId}");
            data = string.Join("", Regex.Matches(data, @"<select id=""selectBibleSub[12]"".+?</select>", RegexOptions.Singleline).Cast<Match>().Select(i => i.Groups[0].Value));
            var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
            return matches.Cast<Match>().Select(i => new BibleBook
            {
                Source = this,
                Bible = bible,
                BibleId = bible.Id,
                OnlineId = i.Groups[1].Value,
                Title = i.Groups[2].Value,
            }).ToList();
        }

        public override List<BibleChapter> GetChapters(BibleBook book)
        {
            var data = client.DownloadString($"/read/reading.asp?ver={book.Bible.OnlineId}&vol={book.OnlineId}");
            data = Regex.Match(data, @"<select id=""selectBibleSub3"".+?</select>", RegexOptions.Singleline).Groups[0].Value;
            var matches = Regex.Matches(data, @"<option value=""(.+?)"".+?>(.+?)</");
            return matches.Cast<Match>().Select(i => new BibleChapter
            {
                Source = this,
                Book = book,
                ChapterNumber = int.Parse(i.Groups[1].Value),
            }).ToList();
        }

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        public override List<BibleVerse> GetVerses(BibleChapter chapter)
        {
            var data = client.DownloadString($"/read/reading.asp?ver={chapter.Book.Bible.OnlineId}&vol={chapter.Book.OnlineId}&chap={chapter.ChapterNumber}");
            var matches = Regex.Matches(data, @"class=""num"".*?</span>(.*?)</p>");
            var verseNum = 0;
            return matches.Cast<Match>().Select(i => new BibleVerse
            {
                Source = this,
                Chapter = chapter,
                VerseNumber = ++verseNum,
                Text = StripHtmlTags(i.Groups[1].Value),
            }).ToList();
        }
    }
}
