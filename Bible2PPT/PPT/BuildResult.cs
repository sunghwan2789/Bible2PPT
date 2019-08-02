using Bible2PPT.Bibles;
using Microsoft.Office.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    class BuildResult
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual Job Job { get; set; }
        
        public bool IsCompleted { get; set; }

        public string Text { get; set; }

        [NotMapped]
        public Exception Exception { get; set; }

        public string Output { get; set; }

        internal PowerPoint.Presentation WorkingPPT { get; set; }

        internal PowerPoint.Slide TemplateSlide { get; set; }

        public void Save()
        {
            TemplateSlide?.Delete();
            WorkingPPT?.Save();
            WorkingPPT?.Close();
        }

        public void QuitAndCleanup()
        {
            WorkingPPT?.Close();
            if (Output != null && File.Exists(Output))
            {
                File.Delete(Output);
            }
        }

        private bool isFirstVerseOfChapter;

        internal void AppendChapter(IEnumerable<IEnumerable<Verse>> eachVerses, Book book, Chapter chapter, CancellationToken cancellationToken)
        {
            isFirstVerseOfChapter = true;
            foreach (var eachVerse in eachVerses)
            {
                cancellationToken.ThrowIfCancellationRequested();

                var mainVerse = eachVerse.FirstOrDefault(i => i != null);
                if (mainVerse == null)
                {
                    continue;
                }

                var slide = TemplateSlide.Duplicate();
                slide.MoveTo(WorkingPPT.Slides.Count);
                foreach (var textShape in
                    slide.Shapes.Cast<PowerPoint.Shape>()
                        .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                        .Select(i => i.TextFrame.TextRange))
                {
                    var text = textShape.Text;
                    text = AddSuffix(text, "CHAP", $"{chapter.Number}", Job.TemplateChapterNumberOption);
                    text = AddSuffix(text, "STITLE", book.ShortTitle, Job.TemplateBookAbbrOption);
                    text = AddSuffix(text, "TITLE", book.Title, Job.TemplateBookNameOption);
                    //text = text.Replace("[CPAS]", $"{startVerseNumber}");
                    //text = text.Replace("[CPAE]", $"{endVerseNumber}");
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
