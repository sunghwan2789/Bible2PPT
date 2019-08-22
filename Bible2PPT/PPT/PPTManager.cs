using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using Bible2PPT.Bibles;
using Bible2PPT.Engine;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT.PPT
{
    class PPTManager : IDisposable
    {
        public Job Job { get; }
        public string Output { get; }

        private readonly PowerPoint.Presentation WorkingPPT;
        private readonly PowerPoint.Slide TemplateSlide;

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

        public void AppendChapter(IEnumerable<IEnumerable<Verse>> eachVerses, Book book, Chapter chapter, VerseQuery query, CancellationToken token)
        {
            var engine = new TemplateEngine();
            engine.Register("QCHS", query.StartChapterNumber.ToString());
            engine.Register("QVSS", query.StartVerseNumber.ToString());
            engine.Register("QCHE", query.EndChapterNumber?.ToString());
            engine.Register("QVSE", query.EndVerseNumber?.ToString());

            isFirstVerseOfChapter = true;
            foreach (var eachVerse in eachVerses)
            {
                token.ThrowIfCancellationRequested();

                var mainVerse = eachVerse.FirstOrDefault(i => i != null);
                if (mainVerse == null)
                {
                    continue;
                }

                engine.Register("CHAP", ShouldPrint(Job.TemplateChapterNumberOption) ? $"{chapter.Number}" : null);
                engine.Register("STITLE", ShouldPrint(Job.TemplateBookAbbrOption) ? book.Abbreviation : null);
                engine.Register("TITLE", ShouldPrint(Job.TemplateBookNameOption) ? book.Name : null);
                engine.Register("PARA", mainVerse.Number.ToString());
                engine.Register("BODY", eachVerse.First()?.Text);
                var verseEnumerator = eachVerse.GetEnumerator();
                for (var i = 1; i <= 9; i++)
                {
                    var verse = verseEnumerator.MoveNext() ? verseEnumerator.Current : null;
                    engine.Register($"BODY{i}", verse?.Text);
                }

                var slide = TemplateSlide.Duplicate();
                slide.MoveTo(WorkingPPT.Slides.Count);
                foreach (var textShape in
                    slide.Shapes.Cast<PowerPoint.Shape>()
                        .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                        .Select(i => i.TextFrame.TextRange))
                {
                    textShape.Text = engine.Process(textShape.Text);
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    WorkingPPT?.Close();
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
