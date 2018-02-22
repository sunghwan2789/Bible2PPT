using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Bible2PPT
{
    class BibleQuery
    {
        public string BibleId { get; set; }
        public int StartChapterNumber { get; set; } = 1;
        public int StartVerseNumber { get; set; } = 1;
        public int? EndChapterNumber { get; set; }
        public int? EndVerseNumber { get; set; }

        public static BibleQuery ParseQuery(string s)
        {
            var m = Regex.Match(s, @"(?<bible>[가-힣]+)(?<range>(?<chapFrom>\d+)(?::(?<paraFrom>\d+))?(?:-(?<chapTo>\d+)(?::(?<paraTo>\d+))?)?)?");
            if (!m.Success)
            {
                throw new FormatException("올바르지 않은 형식: " + s);
            }

            var q = new BibleQuery
            {
                BibleId = m.Groups["bible"].Value
            };

            // PPT 범위를 전체로 설정했을 때
            // 예) 창        = 창세기 전체
            if (string.IsNullOrEmpty(m.Groups["range"].Value))
            {
                return q;
            }

            // PPT 범위를 한 장으로 설정했을 때
            // 예) 창1       = 창세기 1장 전체
            q.EndChapterNumber = q.StartChapterNumber = Convert.ToInt32(m.Groups["chapFrom"].Value);
            if (string.IsNullOrEmpty(m.Groups["paraFrom"].Value))
            {
                if (string.IsNullOrEmpty(m.Groups["chapTo"].Value))
                {
                    return q;
                }

                // PPT 범위를 여러 장으로 설정했을 때
                // 예) 롬1-3     = 로마서 1장 1절 - 3장 전체
                q.EndChapterNumber = Convert.ToInt32(m.Groups["chapTo"].Value);

                // PPT 범위를 여러 장과 여러 절을 설정했을 때
                // 예) 레1-3:9   = 레위기 1장 1절 - 3장 9절
                if (!string.IsNullOrEmpty(m.Groups["paraTo"].Value))
                {
                    q.EndVerseNumber = Convert.ToInt32(m.Groups["paraTo"].Value);
                }
                return q;
            }
            
            // PPT 범위를 한 절로 설정했을 때
            // 예) 창1:1     = 창세기 1장 1절
            q.EndVerseNumber = q.StartVerseNumber = Convert.ToInt32(m.Groups["paraFrom"].Value);
            if (string.IsNullOrEmpty(m.Groups["chapTo"].Value))
            {
                return q;
            }

            // PPT 범위를 한 장에 여러 절로 설정했을 때
            // 예) 스1:3-9   = 에스라 1장 3절 - 1장 9절
            if (string.IsNullOrEmpty(m.Groups["paraTo"].Value))
            {
                q.EndVerseNumber = Convert.ToInt32(m.Groups["chapTo"].Value);
                return q;
            }

            // PPT 범위를 여러 장에 여러 절로 설정했을 때
            // 예) 사1:3-3:9 = 이사야 1장 3절 - 3장 9절
            q.EndChapterNumber = Convert.ToInt32(m.Groups["chapTo"].Value);
            q.EndVerseNumber = Convert.ToInt32(m.Groups["paraTo"].Value);
            return q;
        }
    }
}
