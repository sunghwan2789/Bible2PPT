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

        public void BeginBuild(string destination = null)
        {
            isTemporaryTask = string.IsNullOrEmpty(destination);
            workingFile = isTemporaryTask ? Path.GetTempFileName() : destination;
            ExtractTemplate();
            File.Copy(templatePath, workingFile, true);

            workingPPT = POWERPNT.Presentations.Open(workingFile, WithWindow: MsoTriState.msoFalse);
            templateSlide = workingPPT.Slides[1];
        }

        private bool isFirstVerseOfChapter;

        public void AppendChapter(BibleChapter chapter, int startVerseNumber, int endVerseNumber, CancellationToken token)
        {
            isFirstVerseOfChapter = true;
            var paraNum = startVerseNumber;
            foreach (var paragraph in chapter.Verses.Take(endVerseNumber).Skip(startVerseNumber - 1))
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
                    text = AddSuffix(text, "CHAP", chapter.ChapterNumber + "", AppConfig.Context.ShowChapterNumber);
                    text = AddSuffix(text, "STITLE", chapter.Bible.BibleId, AppConfig.Context.ShowShortTitle);
                    text = AddSuffix(text, "TITLE", chapter.Bible.Title, AppConfig.Context.ShowLongTitle);
                    text = text.Replace("[PARA]", paraNum + "");
                    text = text.Replace("[BODY]", paragraph);
                    textShape.Text = text;
                }
                isFirstVerseOfChapter = false;
                paraNum++;
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
