using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Microsoft.Office.Core;
using PowerPoint = Microsoft.Office.Interop.PowerPoint;

namespace Bible2PPT
{
    internal partial class Main : Form
    {
        private readonly string CONFIG = Application.ExecutablePath + ".cfg";
        private readonly string TEMPLATE = Application.ExecutablePath + ".pptx";
        private readonly Encoding ENCODING = Encoding.GetEncoding("EUC-KR");
        private const string SOURCE = "http://find.godpeople.com/?page=bidx&kwrd=";

        private readonly PowerPoint.Application POWERPNT;

        public Main()
        {
            try
            {
                POWERPNT = new PowerPoint.Application();
                try
                {
                    POWERPNT.Visible = MsoTriState.msoFalse;
                }
                catch {}
            }
            catch
            {
                MessageBox.Show(@"마이크로소프트 파워포인트가 설치되어 있나요?", @"프로그램 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            InitializeComponent();

            try
            {
                var config = File.OpenRead(CONFIG).ReadByte();
                cmbLongTitle.SelectedIndex = config & 1;
                cmbShortTitle.SelectedIndex = config >> 1 & 1;
                cmbChapNum.SelectedIndex = config >> 2 & 1;
                radEasy.Checked = (config >> 3 & 1) == 1;
            }
            catch
            {
                cmbLongTitle.SelectedIndex = cmbShortTitle.SelectedIndex = cmbChapNum.SelectedIndex = 0;
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(
                () => Regex.Matches(new WebClient().DownloadString(SOURCE), @"option\s.+?'(.+?)'.+?(\d+).+?>(.+?)<"))
                .ContinueWith(
                    data =>
                    {
                        if (data.Exception != null)
                        {
                            MessageBox.Show(@"인터넷에 연결되어 있나요?", @"목록 초기화 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Application.Exit();
                            return;
                        }

                        foreach (Match bible in data.Result)
                        {
                            var item = lstBible.Items.Add(bible.Groups[1].Value);
                            item.SubItems.Add(bible.Groups[3].Value);
                            item.SubItems.Add(bible.Groups[2].Value);
                        }
                        txtKeyword.Clear();
                        lstBible.Enabled = txtSearch.Enabled = txtKeyword.Enabled = btnMake.Enabled = btnAllMake.Enabled = true;
                        Cursor = DefaultCursor;
                    });
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (POWERPNT != null && POWERPNT.Presentations.Count == 0)
            {
                POWERPNT.Quit();
            }
            try
            {
                File.OpenWrite(CONFIG)
                    .WriteByte(
                        (byte)
                            ((radEasy.Checked ? 8 : 0) + (cmbChapNum.SelectedIndex << 2) +
                             (cmbShortTitle.SelectedIndex << 1) + cmbLongTitle.SelectedIndex));
            }
            catch {}
        }



        private void AppendShortTitle()
        {
            try
            {
                txtKeyword.AppendText((txtKeyword.Text.Length > 0 ? " " : "") + lstBible.SelectedItems[0].Text);
                txtKeyword.Focus();
            }
            catch {}
        }

        private void lstBible_MouseClick(object sender, MouseEventArgs e)
        {
            AppendShortTitle();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.Clear();
        }

        private void SelectBible(ListViewItem bible)
        {
            lstBible.SelectedItems.Clear();
            bible.Selected = true;
            lstBible.TopItem = bible;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
            {
                return;
            }

            foreach (ListViewItem bible in lstBible.Items)
            {
                if (bible.SubItems[1].Text.StartsWith(txtSearch.Text))
                {
                    SelectBible(bible);
                    return;
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                {
                    e.SuppressKeyPress = true;
                    try
                    {
                        SelectBible(lstBible.Items[lstBible.SelectedIndices[0] - 1]);
                    }
                    catch
                    {
                        if (lstBible.Items.Count > 0)
                        {
                            SelectBible(lstBible.Items[lstBible.Items.Count - 1]);
                        }
                    }
                    break;
                }
                case Keys.Down:
                {
                    e.SuppressKeyPress = true;
                    try
                    {
                        SelectBible(lstBible.Items[lstBible.SelectedIndices[0] + 1]);
                    }
                    catch
                    {
                        if (lstBible.Items.Count > 0)
                        {
                            SelectBible(lstBible.Items[0]);
                        }
                    }
                    break;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                AppendShortTitle();
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = @"검색...";
        }



        private void ExtractTemplate()
        {
            if (File.Exists(TEMPLATE))
            {
                return;
            }

            using (var src = Assembly.GetExecutingAssembly().GetManifestResourceStream("Bible2PPT.Template.pptx"))
            using (var dst = new FileStream(TEMPLATE, FileMode.Create))
            {
                src.CopyTo(dst);
            }
        }

        private void btnTemplate_Click(object sender, EventArgs e)
        {
            ExtractTemplate();
            Process.Start(TEMPLATE);
        }

        private void txtKeyword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnMake.PerformClick();
                btnAllMake.PerformClick();
            }
        }

        private CancellationTokenSource CTS;

        private void btnMake_Click(object sender, EventArgs e)
        {
            if (btnMake.Text == @"PPT 만드는 중...")
            {
                CTS.Cancel();
                return;
            }

            btnMake.Text = @"PPT 만드는 중...";

            Cursor = Cursors.AppStarting;
            lstBible.Enabled =
                txtSearch.Enabled =
                    radRevision.Enabled =
                        radEasy.Enabled =
                            cmbChapNum.Enabled =
                                cmbLongTitle.Enabled = cmbShortTitle.Enabled = txtKeyword.Enabled = false;

            var tmp = Path.GetTempFileName();            
            ExtractTemplate();
            File.Copy(TEMPLATE, tmp, true);

            CTS = new CancellationTokenSource();
            Task.Factory.StartNew(
                () =>
                {   
                    var ppt = POWERPNT.Presentations.Open(tmp, WithWindow: MsoTriState.msoFalse);
                    var template = ppt.Slides[1];                    
                    try
                    {
                        var as1 = cmbChapNum.SelectedIndex == 0;
                        var as2 = cmbLongTitle.SelectedIndex == 0;
                        var as3 = cmbShortTitle.SelectedIndex == 0;

                        foreach (var keyword in txtKeyword.Text.Split())
                        {
                            
                            CTS.Token.ThrowIfCancellationRequested();

                            var data = Regex.Match(
                                keyword,
                                @"(?<bible>[^\d\s]+)(?<chapFrom>\d+)(?::(?<paraFrom>\d+))?(?:-(?:(?<chapTo>\d+):)?(?<paraTo>\d+))?");
                            if (!data.Success)
                            {
                                continue;
                            }
                            var item = lstBible.FindItemWithText(data.Groups["bible"].Value);

                            var title = item.SubItems[1].Text;
                            var chapters = Convert.ToInt32(item.SubItems[2].Text);

                            int chapFrom, paraFrom, chapTo, paraTo;

                            chapFrom = Convert.ToInt32(data.Groups["chapFrom"].Value);
                            if (chapFrom > chapters)
                            {
                                continue;
                            }
                            if (string.IsNullOrEmpty(data.Groups["paraFrom"].Value))
                            {
                                paraFrom = 1;
                                if (string.IsNullOrEmpty(data.Groups["chapTo"].Value))
                                {
                                    chapTo = string.IsNullOrEmpty(data.Groups["paraTo"].Value)
                                        ? chapFrom
                                        : Convert.ToInt32(data.Groups["paraTo"].Value);
                                    paraTo = -1;
                                }
                                else
                                {
                                    chapTo = Convert.ToInt32(data.Groups["chapTo"].Value);
                                    paraTo = Convert.ToInt32(data.Groups["paraTo"].Value);
                                }
                            }
                            else
                            {
                                paraFrom = Convert.ToInt32(data.Groups["paraFrom"].Value);
                                if (paraFrom < 1)
                                {
                                    paraFrom = 1;
                                }
                                chapTo = string.IsNullOrEmpty(data.Groups["chapTo"].Value)
                                    ? chapFrom
                                    : Convert.ToInt32(data.Groups["chapTo"].Value);
                                paraTo = string.IsNullOrEmpty(data.Groups["paraTo"].Value)
                                    ? paraFrom
                                    : Convert.ToInt32(data.Groups["paraTo"].Value);
                            }
                            if (chapTo > chapters)
                            {
                                chapTo = chapters;
                            }
                            
                            for ( var chapter = chapFrom; chapter <= chapTo; chapter++)
                            {   
                                var chapCon = chapter;
                                Invoke(new MethodInvoker(() => Text = @"성경2PPT - " + title + " " + chapCon + "장"));

                                var bible = DownloadBible(data.Groups["bible"].Value, chapter, radRevision.Checked);
                                var paragraphs = chapter == chapTo && paraTo != -1 && paraTo < bible.Count
                                    ? paraTo
                                    : bible.Count;

                                var isFirst = true;
                                for (var paragraph = chapter == chapFrom ? paraFrom : 1;
                                    paragraph <= paragraphs;
                                    paragraph++)
                                {
                                    CTS.Token.ThrowIfCancellationRequested();

                                    var slide = template.Duplicate();
                                    slide.MoveTo(ppt.Slides.Count);
                                    foreach (var textShape in
                                        slide.Shapes.Cast<PowerPoint.Shape>()
                                            .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                                            .Select(i => i.TextFrame.TextRange))
                                    {
                                        textShape.Text =
                                            AddSuffix(
                                                AddSuffix(
                                                    AddSuffix(textShape.Text, @"CHAP", as1 || isFirst, chapter + ""),
                                                    "STITLE", as3 || isFirst, data.Groups["bible"].Value), "TITLE",
                                                as2 || isFirst, title)
                                                .Replace("[PARA]", paragraph + "")
                                                .Replace("[BODY]", bible[paragraph - 1]);
                                    }
                                    isFirst = false;
                                }                                                          
                            }                            
                        }
                    }
                    catch {}
                    template.Delete();
                    ppt.Save();                
                    ppt.Close();
                }, CTS.Token).ContinueWith(
                    result =>
                    {
                        File.Move(tmp, tmp + ".pptx");
                        Process.Start(tmp + ".pptx");

                        lstBible.Enabled =
                            txtSearch.Enabled =
                                radRevision.Enabled =
                                    radEasy.Enabled =
                                        cmbChapNum.Enabled =
                                            cmbLongTitle.Enabled = cmbShortTitle.Enabled = txtKeyword.Enabled = true;
                        Cursor = DefaultCursor;

                        btnMake.Text = @"PPT 만들기";
                        Text = @"성경2PPT";

                        if (result.Exception != null)
                        {
                            MessageBox.Show(result.Exception.GetBaseException() + "");
                        }
                    });
        }

        private static string AddSuffix(string str, string toFind, bool bReplace, string replace)
        {
            return Regex.Replace(str, @"\[" + toFind + @"(?::(.*?))?\]", bReplace ? replace + "$1" : "");
        }

        private IList<string> DownloadBible(string bible, int page, bool easy)
        {
            return
                Regex.Matches(
                    new WebClient().DownloadString(
                        SOURCE + HttpUtility.UrlEncode(bible, ENCODING) + page + "&vers=" + (easy ? "rvsn" : "ezsn")),
                    @"bidx_listTd_phrase.+?>(.+?)</td")
                    .Cast<Match>()
                    .Select(i => Regex.Replace(i.Groups[1].Value, @"<u.+?u>|<.+?>", "", RegexOptions.Singleline))
                    .ToList();
        }

        private void btnTemplate_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(@"[TITLE]: 긴 제목*
[STITLE]: 짧은 제목*
[CHAP]: 장 번호*
[PARA]: 절 번호
[BODY]: 내용

* 표시: 접미사 사용 가능
예) [CHAP:장] -> n장", btnTemplate, Int16.MaxValue);
        }

        private void txtKeyword_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show(@"예) 창1   = 창세기 1장
롬1-3     = 로마서 1장 - 3장
레1-3:9   = 레위기 1장 - 3장 9절
스1:3-9   = 에스라 1장 3절 - 1장 9절
사1:3-3:9 = 이사야 1장 3절 - 3장 9절", txtKeyword, Int16.MaxValue);
        }

        private void btnAllMake_Click(object sender, EventArgs e)
        {
            if (btnAllMake.Text == @"PPT 만드는 중...")
            {
                CTS.Cancel();
                return;
            }

            btnAllMake.Text = @"PPT 만드는 중...";

            Cursor = Cursors.AppStarting;
            lstBible.Enabled =
                txtSearch.Enabled =
                    radRevision.Enabled =
                        radEasy.Enabled =
                            cmbChapNum.Enabled =
                                cmbLongTitle.Enabled = cmbShortTitle.Enabled = txtKeyword.Enabled = false;

            var tmp = Path.GetTempFileName();
            ExtractTemplate();
            File.Copy(TEMPLATE, tmp, true);

            CTS = new CancellationTokenSource();
            Task.Factory.StartNew(
                () =>
                {
                    //var ppt = POWERPNT.Presentations.Open(tmp, WithWindow: MsoTriState.msoFalse);
                    //var template = ppt.Slides[1];                    
                    try
                    {
                        var as1 = cmbChapNum.SelectedIndex == 0;
                        var as2 = cmbLongTitle.SelectedIndex == 0;
                        var as3 = cmbShortTitle.SelectedIndex == 0;

                        foreach (var keyword in txtKeyword.Text.Split())
                        {

                            CTS.Token.ThrowIfCancellationRequested();

                            bool OnlyTitle = false;
                            var data = Regex.Match(
                                keyword,
                                @"(?<bible>[^\d\s]+)(?<chapFrom>\d+)(?::(?<paraFrom>\d+))?(?:-(?:(?<chapTo>\d+):)?(?<paraTo>\d+))?");                            

                            if (!data.Success)
                            {
                                var data1 = Regex.Match(
                                keyword,
                                @"(?<bible>[^\d\s]+)");
                                if (!data1.Success)
                                {   
                                    continue;
                                }
                                OnlyTitle = true;
                                data = data1;
                            }
                            var item = lstBible.FindItemWithText(data.Groups["bible"].Value);

                            var title = item.SubItems[1].Text;
                            var chapters = Convert.ToInt32(item.SubItems[2].Text);                            

                            int chapFrom, paraFrom, chapTo, paraTo;

                            if (OnlyTitle) {
                                chapFrom = 1;                                
                            }
                            else chapFrom = Convert.ToInt32(data.Groups["chapFrom"].Value);
                                                        
                            if (chapFrom > chapters)
                            {   
                                continue;
                            }
                            if (string.IsNullOrEmpty(data.Groups["paraFrom"].Value))
                            {
                                paraFrom = 1;
                                if (string.IsNullOrEmpty(data.Groups["chapTo"].Value))
                                {
                                    chapTo = string.IsNullOrEmpty(data.Groups["paraTo"].Value)
                                        ? chapFrom
                                        : Convert.ToInt32(data.Groups["paraTo"].Value);
                                    paraTo = -1;
                                }
                                else
                                {
                                    chapTo = Convert.ToInt32(data.Groups["chapTo"].Value);
                                    paraTo = Convert.ToInt32(data.Groups["paraTo"].Value);
                                }
                            }
                            else
                            {
                                paraFrom = Convert.ToInt32(data.Groups["paraFrom"].Value);
                                if (paraFrom < 1)
                                {
                                    paraFrom = 1;
                                }
                                chapTo = string.IsNullOrEmpty(data.Groups["chapTo"].Value)
                                    ? chapFrom
                                    : Convert.ToInt32(data.Groups["chapTo"].Value);
                                paraTo = string.IsNullOrEmpty(data.Groups["paraTo"].Value)
                                    ? paraFrom
                                    : Convert.ToInt32(data.Groups["paraTo"].Value);
                            }
                            if (chapTo > chapters)
                            {
                                chapTo = chapters;
                            }

                            if (OnlyTitle)
                            {                             
                                chapTo = chapters;                             
                            }

                            for (var chapter = chapFrom; chapter <= chapTo; chapter++)
                            {
                                var ppt = POWERPNT.Presentations.Open(tmp, WithWindow: MsoTriState.msoFalse);
                                var template = ppt.Slides[1];

                                var chapCon = chapter;
                                Invoke(new MethodInvoker(() => Text = @"성경2PPT - " + title + " " + chapCon + "장"));

                                var bible = DownloadBible(data.Groups["bible"].Value, chapter, radRevision.Checked);
                                var paragraphs = chapter == chapTo && paraTo != -1 && paraTo < bible.Count
                                    ? paraTo
                                    : bible.Count;

                                var isFirst = true;
                                for (var paragraph = chapter == chapFrom ? paraFrom : 1;
                                    paragraph <= paragraphs;
                                    paragraph++)
                                {
                                    CTS.Token.ThrowIfCancellationRequested();

                                    var slide = template.Duplicate();
                                    slide.MoveTo(ppt.Slides.Count);
                                    foreach (var textShape in
                                        slide.Shapes.Cast<PowerPoint.Shape>()
                                            .Where(i => i.HasTextFrame == MsoTriState.msoTrue)
                                            .Select(i => i.TextFrame.TextRange))
                                    {
                                        textShape.Text =
                                            AddSuffix(
                                                AddSuffix(
                                                    AddSuffix(textShape.Text, @"CHAP", as1 || isFirst, chapter + ""),
                                                    "STITLE", as3 || isFirst, data.Groups["bible"].Value), "TITLE",
                                                as2 || isFirst, title)
                                                .Replace("[PARA]", paragraph + "")
                                                .Replace("[BODY]", bible[paragraph - 1]);
                                    }
                                    isFirst = false;
                                }                                
                                template.Delete();                                

                                string path = String.Format("{0}{1:D2} {2}\\", System.AppDomain.CurrentDomain.BaseDirectory, item.Index, title);                                
                                if (!System.IO.Directory.Exists(path))
                                {
                                    System.IO.Directory.CreateDirectory(path);
                                }
                                path += String.Format("{0:D3}.pptx",chapter);
                                ppt.SaveAs(path);
                                ppt.Close();
                            }

                        }
                    }
                    catch { }
                    //template.Delete();
                    //ppt.Save();                    
                    //ppt.Close();
                }, CTS.Token).ContinueWith(
                    result =>
                    {
                        File.Move(tmp, tmp + ".pptx");
                        Process.Start(tmp + ".pptx");

                        lstBible.Enabled =
                            txtSearch.Enabled =
                                radRevision.Enabled =
                                    radEasy.Enabled =
                                        cmbChapNum.Enabled =
                                            cmbLongTitle.Enabled = cmbShortTitle.Enabled = txtKeyword.Enabled = true;
                        Cursor = DefaultCursor;

                        btnAllMake.Text = @"PPT 만들기";
                        Text = @"성경2PPT";

                        if (result.Exception != null)
                        {
                            MessageBox.Show(result.Exception.GetBaseException() + "");
                        }
                    });
        }
    }
}