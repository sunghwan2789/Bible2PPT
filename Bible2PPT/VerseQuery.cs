using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Bible2PPT
{
    class VerseQuery
    {
        public string BookAbbreviation { get; set; }
        public int StartChapterNumber { get; set; } = 1;
        public int StartVerseNumber { get; set; } = 1;
        public int? EndChapterNumber { get; set; }
        public int? EndVerseNumber { get; set; }

        public static VerseQuery Parse(string s)
        {
            // TODO: 대표 책 이름 약자 수정 기능
            var m = Regex.Match(s, @"(?<book>[가-힣]+)(?<range>(?<chapFrom>\d+)(?::(?<versFrom>\d+))?(?:-(?<chapTo>\d+)(?::(?<versTo>\d+))?)?)?");
            if (!m.Success || m.Value != s)
            {
                throw new FormatException($@"""{s}""은 잘못된 형식입니다.");
            }

            var q = new VerseQuery
            {
                BookAbbreviation = m.Groups["book"].Value
            };

            // PPT 범위를 전체로 설정했을 때
            // 예) 창        = 창세기 전체
            if (string.IsNullOrEmpty(m.Groups["range"].Value))
            {
                return q;
            }

            // PPT 범위를 한 장으로 설정했을 때
            // 예) 창1       = 창세기 1장 전체
            q.StartChapterNumber = int.Parse(m.Groups["chapFrom"].Value, CultureInfo.InvariantCulture);
            q.EndChapterNumber = q.StartChapterNumber;
            if (string.IsNullOrEmpty(m.Groups["versFrom"].Value))
            {
                if (string.IsNullOrEmpty(m.Groups["chapTo"].Value))
                {
                    return q;
                }

                // PPT 범위를 여러 장으로 설정했을 때
                // 예) 롬1-3     = 로마서 1장 1절 - 3장 전체
                q.EndChapterNumber = int.Parse(m.Groups["chapTo"].Value, CultureInfo.InvariantCulture);
                if (string.IsNullOrEmpty(m.Groups["versTo"].Value))
                {
                    return q;
                }

                // PPT 범위를 여러 장과 여러 절을 설정했을 때
                // 예) 레1-3:9   = 레위기 1장 1절 - 3장 9절
                q.EndVerseNumber = int.Parse(m.Groups["versTo"].Value, CultureInfo.InvariantCulture);
                return q;
            }

            // PPT 범위를 한 절로 설정했을 때
            // 예) 전1:3     = 전도서 1장 3절
            q.StartVerseNumber = int.Parse(m.Groups["versFrom"].Value, CultureInfo.InvariantCulture);
            q.EndVerseNumber = q.StartVerseNumber;
            if (string.IsNullOrEmpty(m.Groups["chapTo"].Value))
            {
                return q;
            }

            // PPT 범위를 한 장에 여러 절로 설정했을 때
            // 예) 스1:3-9   = 에스라 1장 3절 - 1장 9절
            if (string.IsNullOrEmpty(m.Groups["versTo"].Value))
            {
                q.EndVerseNumber = int.Parse(m.Groups["chapTo"].Value, CultureInfo.InvariantCulture);
                return q;
            }

            // PPT 범위를 여러 장에 여러 절로 설정했을 때
            // 예) 사1:3-3:9 = 이사야 1장 3절 - 3장 9절
            q.EndChapterNumber = int.Parse(m.Groups["chapTo"].Value, CultureInfo.InvariantCulture);
            q.EndVerseNumber = int.Parse(m.Groups["versTo"].Value, CultureInfo.InvariantCulture);
            return q;
        }
    }
}
