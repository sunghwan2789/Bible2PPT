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

        protected override List<BibleVersion> GetBiblesOnline()
        {
            var data = client.DownloadString("/bible.asp");
            var matches = Regex.Matches(data, @"bible_check"".+?value=""(\d+)""[\s\S]+?<span.+?>(.+?)<");
            return matches.Cast<Match>().Select(i => new BibleVersion
            {
                OnlineId = i.Groups[1].Value,
                Name = i.Groups[2].Value,
            }).ToList();
        }

        protected override List<BibleBook> GetBooksOnline(BibleVersion bible)
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
            return matches.Cast<Match>().Select(i => new BibleBook
            {
                OnlineId = i.Groups[1].Value,
                Title = i.Groups[2].Value,
                ChapterCount = int.Parse(i.Groups[3].Value),
            }).ToList();
        }

        protected override List<BibleChapter> GetChaptersOnline(BibleBook book) => throw new NotImplementedException();
        protected override List<BibleVerse> GetVersesOnline(BibleChapter chapter) => throw new NotImplementedException();
    }
}
