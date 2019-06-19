using Bible2PPT.Bibles;
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

        public void AppendChapter(Chapter chapter, int startVerseNumber, int endVerseNumber, CancellationToken token)
        {
            isFirstVerseOfChapter = true;
            foreach (var paragraph in chapter.Verses.Where(i => i.Number >= startVerseNumber && i.Number <= endVerseNumber))
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
                    text = text.Replace("[PARA]", paragraph.Number.ToString());
                    text = text.Replace("[CPAS]", startVerseNumber.ToString());
                    text = text.Replace("[CPAE]", endVerseNumber.ToString());
                    text = text.Replace("[BODY]", paragraph.Text);
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
