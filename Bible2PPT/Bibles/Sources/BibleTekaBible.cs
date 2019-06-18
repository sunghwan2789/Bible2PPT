using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bible2PPT.Bibles.Sources
{
    class BibleTekaBible : BibleSource
    {
        private const string BASE_URL = "https://bible-teka.com";

        private BetterWebClient client = new BetterWebClient
        {
            BaseAddress = BASE_URL,
            Encoding = Encoding.UTF8,
        };

        public BibleTekaBible()
        {
            Name = "Библия онлайн";
        }

        protected override List<BibleVersion> GetBiblesOnline()
        {
            var data = client.DownloadString($"/");
            var matches = Regex.Matches(data, @"<div class=""col-xs-10""><p class=""plus""><a href=""/(.+?)/.+?>(.+?)</");
            return matches.Cast<Match>().Select(i => new BibleVersion
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
            }).ToList();
        }

        protected override List<BibleBook> GetBooksOnline(BibleVersion bible)
        {
            var data = client.DownloadString($"/{bible.OnlineId}/");
            var matches = Regex.Matches(data, $@"/{bible.OnlineId}/(\d+)/.+?>(.+?)</a");
            return matches.Cast<Match>().Select(match => new BibleBook
            {
                OnlineId = match.Groups[1].Value,
                Title = match.Groups[2].Value,
            }).ToList();
        }

        protected override List<BibleChapter> GetChaptersOnline(BibleBook book) =>
            Enumerable.Range(1, book.ChapterCount)
                .Select(i => new BibleChapter
                {
                    Number = i,
                }).ToList();

        private static string StripHtmlTags(string s) => Regex.Replace(s, @"<.+?>", "", RegexOptions.Singleline);

        protected override List<BibleVerse> GetVersesOnline(BibleChapter chapter)
        {
            throw new NotImplementedException();
        }
    }
}
