using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System;

namespace Bible2PPT
{
    class PPTBuilder : IDisposable
    {
        private static PowerPoint.Application POWERPNT;

        public string resourceName { get; private set; }
        public string templatePath { get; private set; }

        public PPTBuilder(string resourceName, string templatePath)
        {
            if (POWERPNT == null)
            {
                POWERPNT = new PowerPoint.Application();
                try
                {
                    POWERPNT.Visible = MsoTriState.msoFalse;
                }
                catch { }
            }

            this.resourceName = resourceName;
            this.templatePath = templatePath;
        }

        private void ExtractTemplate()
        {
            if (File.Exists(templatePath))
            {
                return;
            }

            using (var src = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName))
            using (var dst = new FileStream(templatePath, FileMode.Create))
            {
                src.CopyTo(dst);
            }
        }

        public void OpenTemplate()
        {
            ExtractTemplate();
            Process.Start(templatePath);
        }




        public PPTBuilderWork BeginBuild() => BeginBuild(Path.GetTempFileName() + ".pptx");

        public PPTBuilderWork BeginBuild(string output)
        {
            ExtractTemplate();
            File.Copy(templatePath, output, true);

            var workingPPT = POWERPNT.Presentations.Open(output, WithWindow: MsoTriState.msoFalse);
            return new PPTBuilderWork
            {
                Output = output,
                WorkingPPT = workingPPT,
                TemplateSlide = workingPPT.Slides[1],
            };
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
                    try
                    {
                        if (POWERPNT != null && POWERPNT.Presentations.Count == 0)
                        {
                            POWERPNT.Quit();
                            POWERPNT = null;
                        }
                    }
                    catch { }
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~PPTBuilder() {
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
