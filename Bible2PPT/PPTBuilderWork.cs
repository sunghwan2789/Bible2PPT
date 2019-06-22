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

        public void AppendChapter(IEnumerable<Chapter> chapterGroup, int startVerseNumber, int endVerseNumber, CancellationToken token)
        {
            isFirstVerseOfChapter = true;
            var chapter = chapterGroup.First();
            var getVersesTasks = chapterGroup.Select(i => i.Source.GetVersesAsync(i)).ToArray();
            Task.WaitAll(getVersesTasks);
            var verses = new List<Verse>();
            foreach (var getVersesTask in getVersesTasks)
            {
                verses.AddRange(getVersesTask.Result);
            }
            foreach (var verseGroup in
                verses.Where(i => i.Number >= startVerseNumber && i.Number <= endVerseNumber)
                    .GroupBy(i => i.Number).ToList())
            {
                token.ThrowIfCancellationRequested();

                var slide = TemplateSlide.Duplicate();
                slide.MoveTo(WorkingPPT.Slides.Count);
                foreach (var textShape in
                    slide.Shapes.Cast<PowerPoint.Shape>()
                        .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                        .Select(i => i.TextFrame.TextRange))
                {
                    var text = textShape.Text;
                    text = AddSuffix(text, "CHAP", chapter.Number.ToString(), AppConfig.Context.ShowChapterNumber);
                    text = AddSuffix(text, "STITLE", chapter.Book.ShortTitle, AppConfig.Context.ShowShortTitle);
                    text = AddSuffix(text, "TITLE", chapter.Book.Title, AppConfig.Context.ShowLongTitle);
                    text = text.Replace("[CPAS]", startVerseNumber.ToString());
                    text = text.Replace("[CPAE]", endVerseNumber.ToString());
                    text = text.Replace("[PARA]", verseGroup.First().Number.ToString());
                    text = text.Replace("[BODY]", verseGroup.First().Text);

                    var verseEnumerator = verseGroup.GetEnumerator();
                    for (var i = 1; i <= 9; i++)
                    {
                        text = text.Replace(
                            $"[BODY{i}]",
                            verseEnumerator.MoveNext()
                            ? verseEnumerator.Current.Text
                            : string.Empty);
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
