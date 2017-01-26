using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Bible2PPT
{
    class DAO
    {
        private WebClient loader = new WebClient();
        private const string SOURCE = "http://find.godpeople.com/?page=bidx&kwrd={0}&vers={1}";
        private readonly Encoding ENCODING = Encoding.GetEncoding("EUC-KR");

        public DAO()
        {
        }

        public Task<IEnumerable<Bible>> getBiblesAsync()
        {
            return Task.Factory.StartNew(() =>
            {
                var data = loader.DownloadString(SOURCE);
                var matches = Regex.Matches(data, @"option\s.+?'(.+?)'.+?(\d+).+?>(.+?)<");
                return matches.Cast<Match>().Select(match =>
                {
                    return new Bible(match.Groups[3].Value,
                                     match.Groups[1].Value,
                                     Convert.ToInt32(match.Groups[2].Value));
                });
            });
        }

        public Task<IEnumerable<string>> getBibleChapterAsync(string bible, int chapter, bool easy)
        {
            return Task.Factory.StartNew(() =>
            {
                var data = loader.DownloadString(string.Format(
                    SOURCE,
                    HttpUtility.UrlEncode(bible + chapter, ENCODING),
                    easy ? "rvsn" : "ezsn"));
                var matches = Regex.Matches(data, @"bidx_listTd_phrase.+?>(.+?)</td");
                return matches.Cast<Match>().Select(i => Regex.Replace(i.Groups[1].Value, @"<u.+?u>|<.+?>", "", RegexOptions.Singleline));
            });
        }
    }
}
