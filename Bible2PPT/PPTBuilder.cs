using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Bible2PPT
{
    class PPTBuilder
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

        ~PPTBuilder()
        {
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



        private bool isTemporaryTask;
        private string workingFile;
        private PowerPoint.Presentation workingPPT;
        private PowerPoint.Slide templateSlide;

        private bool everyChapter;
        private bool everyLongTitle;
        private bool everyShortTitle;

        public void ApplyConfig(bool everyChapter, bool everyLongTitle, bool everyShortTitle)
        {
            this.everyChapter = everyChapter;
            this.everyLongTitle = everyLongTitle;
            this.everyShortTitle = everyShortTitle;
        }

        public void BeginBuild(string destination = null)
        {
            isTemporaryTask = string.IsNullOrEmpty(destination);
            workingFile = isTemporaryTask ? Path.GetTempFileName() : destination;
            ExtractTemplate();
            File.Copy(templatePath, workingFile, true);

            workingPPT = POWERPNT.Presentations.Open(workingFile, WithWindow: MsoTriState.msoFalse);
            templateSlide = workingPPT.Slides[1];
        }

        public void AppendChapter(Bible bible, int chapter, int paraNum, IEnumerable<string> chapterContent, CancellationToken token)
        {
            var isFirst = true;
            foreach (var paragraph in chapterContent)
            {
                token.ThrowIfCancellationRequested();

                var slide = templateSlide.Duplicate();
                slide.MoveTo(workingPPT.Slides.Count);
                foreach (var textShape in
                    slide.Shapes.Cast<PowerPoint.Shape>()
                        .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                        .Select(i => i.TextFrame.TextRange))
                {
                    var text = textShape.Text;
                    text = AddSuffix(text, "CHAP", everyChapter || isFirst, chapter + "");
                    text = AddSuffix(text, "STITLE", everyShortTitle || isFirst, bible.shortTitle);
                    text = AddSuffix(text, "TITLE", everyLongTitle || isFirst, bible.longTitle);
                    text = text.Replace("[PARA]", paraNum + "");
                    text = text.Replace("[BODY]", paragraph);
                    textShape.Text = text;
                }
                isFirst = false;
                paraNum++;
            }
        }

        private static string AddSuffix(string str, string toFind, bool bReplace, string replace)
        {
            return Regex.Replace(str, @"\[" + toFind + @"(?::(.*?))?\]", bReplace ? replace + "$1" : "");
        }

        public string CommitBuild()
        {
            templateSlide.Delete();
            workingPPT.Save();
            workingPPT.Close();

            if (isTemporaryTask)
            {
                File.Move(workingFile, workingFile + ".pptx");
                workingFile += ".pptx";
            }
            return workingFile;
        }

        public void OpenLastBuild()
        {
            Process.Start(workingFile);
        }
    }
}
