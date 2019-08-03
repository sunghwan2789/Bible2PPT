using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Bible2PPT.Bibles;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    class PPTManager : IDisposable
    {
        private readonly PowerPoint.Application POWERPNT;

        public Job Job { get; }
        public string Output { get; }

        private readonly PowerPoint.Presentation WorkingPPT;
        private readonly PowerPoint.Slide TemplateSlide;

        public PPTManager(PowerPoint.Application POWERPNT, Job job) : this(POWERPNT, job, Path.GetTempFileName() + ".pptx") { }

        public PPTManager(PowerPoint.Application POWERPNT, Job job, string output)
        {
            Job = job;
            Output = output;

            ExtractTemplate();
            File.Copy(AppConfig.TemplatePath, Output, true);

            WorkingPPT = POWERPNT.Presentations.Open(output, WithWindow: MsoTriState.msoFalse);
            TemplateSlide = WorkingPPT.Slides[1];
        }

        private static void ExtractTemplate()
        {
            if (File.Exists(AppConfig.TemplatePath))
            {
                return;
            }

            using (var ms = new MemoryStream(Properties.Resources.Template))
            using (var fs = File.OpenWrite(AppConfig.TemplatePath))
            {
                ms.CopyTo(fs);
            }
        }
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

        public void AppendChapter(IEnumerable<IEnumerable<Verse>> eachVerses, Book book, Chapter chapter, CancellationToken token)
        {
            isFirstVerseOfChapter = true;
            foreach (var eachVerse in eachVerses)
            {
                token.ThrowIfCancellationRequested();

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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PPTManager()
        // {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
