using Bible2PPT.Bibles;
using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT
{
    class PPTBuilderWork
    {
        public string Output { get; set; }
        public PowerPoint.Presentation WorkingPPT { get; set; }
        public PowerPoint.Slide TemplateSlide { get; set; }
        //public CancellationToken CancellationToken { get; set; }

        private bool isFirstVerseOfChapter;

        public void AppendChapter(IEnumerable<Chapter> eachChapter, int startVerseNumber, int? endVerseNumber, CancellationToken token)
        {
            isFirstVerseOfChapter = true;

            var mainChapter = eachChapter.First(i => i != null);

            var eachTargetVerses = eachChapter
                .Select(chapter => chapter?.Source.GetVersesAsync(chapter)).ToList().Select(i => i?.Result)
                .Select(i => i ?? new List<Verse>())
                .Select(verses => verses.Where(verse =>
                    (endVerseNumber != null)
                    ? (verse.Number >= startVerseNumber) && (verse.Number <= endVerseNumber)
                    : (verse.Number >= startVerseNumber)).ToList())
                .ToList();

            var targetEachVerses = new List<IEnumerable<Verse>>();
            // GetEnumerator() 반환형이 struct라 값 복사로 무한 반복되기를 예방하기 위해 캐스팅
            var targetVerseEnumerators = eachTargetVerses.Select(i => (IEnumerator<Verse>)i.GetEnumerator()).ToList();
            for (var verseNumber = startVerseNumber; ;)
            {
                // 다음 절이 있는지 확인
                var moved = new Dictionary<IEnumerator<Verse>, bool>();
                var nextVerseNumber = verseNumber;
                foreach (var i in targetVerseEnumerators)
                {
                    if (i.MoveNext())
                    {
                        moved[i] = true;
                        nextVerseNumber = Math.Max(nextVerseNumber, i.Current.Number);
                    }
                }

                // 현재 절이 마지막이었으면 종료
                if (!moved.Any())
                {
                    break;
                }

                for (; verseNumber <= nextVerseNumber; verseNumber++)
                {
                    var eachVerse = new List<Verse>();
                    foreach (var i in targetVerseEnumerators)
                    {
                        // 범위를 넘어가면 더 페이지가 없음
                        if (i.Current == null)
                        {
                            eachVerse.Add(null);
                            continue;
                        }

                        // 절 번호가 앞서가면 앞 절이 비었음
                        if (i.Current.Number > verseNumber)
                        {
                            eachVerse.Add(null);
                            continue;
                        }

                        if (!moved[i])
                        {
                            i.MoveNext();
                        }
                        eachVerse.Add(i.Current);
                        moved[i] = false;
                    }
                    targetEachVerses.Add(eachVerse);
                }
            }

            foreach (var eachVerse in targetEachVerses)
            {
                token.ThrowIfCancellationRequested();

                var mainVerse = eachVerse.First(i => i != null);

                var slide = TemplateSlide.Duplicate();
                slide.MoveTo(WorkingPPT.Slides.Count);
                foreach (var textShape in
                    slide.Shapes.Cast<PowerPoint.Shape>()
                        .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                        .Select(i => i.TextFrame.TextRange))
                {
                    var text = textShape.Text;
                    text = AddSuffix(text, "CHAP", $"{mainChapter.Number}", AppConfig.Context.ShowChapterNumber);
                    text = AddSuffix(text, "STITLE", mainChapter.Book.ShortTitle, AppConfig.Context.ShowShortTitle);
                    text = AddSuffix(text, "TITLE", mainChapter.Book.Title, AppConfig.Context.ShowLongTitle);
                    text = text.Replace("[CPAS]", $"{startVerseNumber}");
                    text = text.Replace("[CPAE]", $"{endVerseNumber}");
                    text = text.Replace("[PARA]", $"{mainVerse.Number}");
                    text = text.Replace("[BODY]", eachVerse.First()?.Text);

                    var verseEnumerator = eachVerse.GetEnumerator();
                    for (var i = 1; i <= 9; i++)
                    {
                        var verse = verseEnumerator.MoveNext() ? verseEnumerator.Current : null;
                        text = text.Replace($"[BODY{i}]", verse?.Text);
                    }

                    textShape.Text = text;
                }
                isFirstVerseOfChapter = false;
            }
        }

        public void Save()
        {
            TemplateSlide.Delete();
            WorkingPPT.Save();
            WorkingPPT.Close();
        }

        public void QuitAndCleanup()
        {
            WorkingPPT.Close();
            File.Delete(Output);
        }

        private bool ShouldPrint(TemplateTextOptions templateOption)
        {
            switch (templateOption)
            {
                case TemplateTextOptions.Always:
                    return true;
                case TemplateTextOptions.FirstVerseOfChapter:
                    return isFirstVerseOfChapter;
                default:
                    throw new NotImplementedException();
            }
        }

        private string AddSuffix(string str, string toFind, string replace, TemplateTextOptions templateOption)
        {
            return Regex.Replace(str, @"\[" + toFind + @"(?::(.*?))?\]", ShouldPrint(templateOption) ? replace + "$1" : "");
        }
    }
}
