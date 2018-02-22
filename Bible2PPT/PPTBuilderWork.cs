using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

        public void AppendChapter(BibleChapter chapter, int startVerseNumber, int endVerseNumber, CancellationToken token)
        {
            isFirstVerseOfChapter = true;
            var paraNum = startVerseNumber;
            foreach (var paragraph in chapter.Verses.Take(endVerseNumber).Skip(startVerseNumber - 1))
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
                    text = AddSuffix(text, "CHAP", chapter.ChapterNumber + "", AppConfig.Context.ShowChapterNumber);
                    text = AddSuffix(text, "STITLE", chapter.Bible.BibleId, AppConfig.Context.ShowShortTitle);
                    text = AddSuffix(text, "TITLE", chapter.Bible.Title, AppConfig.Context.ShowLongTitle);
                    text = text.Replace("[PARA]", paraNum + "");
                    text = text.Replace("[CPAS]", startVerseNumber + "");
                    text = text.Replace("[CPAE]", endVerseNumber + "");
                    text = text.Replace("[BODY]", paragraph);
                    textShape.Text = text;
                }
                isFirstVerseOfChapter = false;
                paraNum++;
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
