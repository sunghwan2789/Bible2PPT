namespace Bible2PPT
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmbShortTitle = new System.Windows.Forms.ComboBox();
            this.cmbLongTitle = new System.Windows.Forms.ComboBox();
            this.cmbChapNum = new System.Windows.Forms.ComboBox();
            this.cmbBibleSource = new System.Windows.Forms.ComboBox();
            this.cmbBibleVersion = new System.Windows.Forms.ComboBox();
            this.btnMake = new System.Windows.Forms.Button();
            this.txtKeyword = new System.Windows.Forms.TextBox();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnGithub = new System.Windows.Forms.Button();
            this.chkFragment = new System.Windows.Forms.CheckBox();
            this.lstBooks = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkUseCache = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbShortTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbShortTitle, 3);
            this.cmbShortTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbShortTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShortTitle.Items.AddRange(new object[] {
            "짧은 제목 표시",
            "각 장의 첫 절에만 표시"});
            this.cmbShortTitle.Location = new System.Drawing.Point(10, 74);
            this.cmbShortTitle.Margin = new System.Windows.Forms.Padding(0);
            this.cmbShortTitle.Name = "cmbShortTitle";
            this.cmbShortTitle.Size = new System.Drawing.Size(156, 20);
            this.cmbShortTitle.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmbShortTitle, "짧은 제목 표시 설정");
            this.cmbShortTitle.SelectedIndexChanged += new System.EventHandler(this.cmbShortTitle_SelectedIndexChanged);
            // 
            // cmbLongTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbLongTitle, 3);
            this.cmbLongTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLongTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLongTitle.Items.AddRange(new object[] {
            "긴 제목 표시",
            "각 장의 첫 절에만 표시"});
            this.cmbLongTitle.Location = new System.Drawing.Point(10, 49);
            this.cmbLongTitle.Margin = new System.Windows.Forms.Padding(0);
            this.cmbLongTitle.Name = "cmbLongTitle";
            this.cmbLongTitle.Size = new System.Drawing.Size(156, 20);
            this.cmbLongTitle.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cmbLongTitle, "긴 제목 표시 설정");
            this.cmbLongTitle.SelectedIndexChanged += new System.EventHandler(this.cmbLongTitle_SelectedIndexChanged);
            // 
            // cmbChapNum
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cmbChapNum, 3);
            this.cmbChapNum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbChapNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChapNum.Items.AddRange(new object[] {
            "장 번호 표시",
            "각 장의 첫 절에만 표시"});
            this.cmbChapNum.Location = new System.Drawing.Point(10, 99);
            this.cmbChapNum.Margin = new System.Windows.Forms.Padding(0);
            this.cmbChapNum.Name = "cmbChapNum";
            this.cmbChapNum.Size = new System.Drawing.Size(156, 20);
            this.cmbChapNum.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmbChapNum, "장 번호 표시 설정");
            this.cmbChapNum.SelectedIndexChanged += new System.EventHandler(this.cmbChapNum_SelectedIndexChanged);
            // 
            // cmbBibleSource
            // 
            this.cmbBibleSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBibleSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBibleSource.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbBibleSource.FormattingEnabled = true;
            this.cmbBibleSource.Location = new System.Drawing.Point(0, 22);
            this.cmbBibleSource.Margin = new System.Windows.Forms.Padding(0);
            this.cmbBibleSource.Name = "cmbBibleSource";
            this.cmbBibleSource.Size = new System.Drawing.Size(151, 20);
            this.cmbBibleSource.TabIndex = 2;
            this.toolTip1.SetToolTip(this.cmbBibleSource, "성경 소스 선택");
            this.cmbBibleSource.SelectedIndexChanged += new System.EventHandler(this.cmbBibleSource_SelectedIndexChanged);
            // 
            // cmbBibleVersion
            // 
            this.cmbBibleVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbBibleVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBibleVersion.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbBibleVersion.FormattingEnabled = true;
            this.cmbBibleVersion.Location = new System.Drawing.Point(0, 47);
            this.cmbBibleVersion.Margin = new System.Windows.Forms.Padding(0);
            this.cmbBibleVersion.Name = "cmbBibleVersion";
            this.cmbBibleVersion.Size = new System.Drawing.Size(151, 20);
            this.cmbBibleVersion.TabIndex = 3;
            this.toolTip1.SetToolTip(this.cmbBibleVersion, "성경 선택");
            this.cmbBibleVersion.SelectedIndexChanged += new System.EventHandler(this.cmbBibleVersion_SelectedIndexChanged);
            // 
            // btnMake
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnMake, 3);
            this.btnMake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMake.Location = new System.Drawing.Point(10, 191);
            this.btnMake.Margin = new System.Windows.Forms.Padding(0);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(156, 29);
            this.btnMake.TabIndex = 6;
            this.btnMake.Text = "PPT 만들기";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // txtKeyword
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtKeyword, 3);
            this.txtKeyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyword.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtKeyword.Location = new System.Drawing.Point(10, 130);
            this.txtKeyword.Margin = new System.Windows.Forms.Padding(0);
            this.txtKeyword.Name = "txtKeyword";
            this.txtKeyword.Size = new System.Drawing.Size(156, 29);
            this.txtKeyword.TabIndex = 4;
            this.txtKeyword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
            this.txtKeyword.MouseHover += new System.EventHandler(this.txtKeyword_MouseHover);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnTemplate.Location = new System.Drawing.Point(10, 10);
            this.btnTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(124, 29);
            this.btnTemplate.TabIndex = 0;
            this.btnTemplate.Text = "템플릿 열기";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            this.btnTemplate.MouseHover += new System.EventHandler(this.btnTemplate_MouseHover);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Controls.Add(this.btnGithub, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnTemplate, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtKeyword, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmbChapNum, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnMake, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.cmbLongTitle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbShortTitle, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.chkFragment, 1, 11);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(179, 249);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnGithub
            // 
            this.btnGithub.BackgroundImage = global::Bible2PPT.Properties.Resources.GitHub_Mark_32px;
            this.btnGithub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGithub.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGithub.Location = new System.Drawing.Point(137, 10);
            this.btnGithub.Margin = new System.Windows.Forms.Padding(0);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(29, 29);
            this.btnGithub.TabIndex = 0;
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // chkFragment
            // 
            this.chkFragment.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.chkFragment, 3);
            this.chkFragment.Location = new System.Drawing.Point(13, 172);
            this.chkFragment.Name = "chkFragment";
            this.chkFragment.Size = new System.Drawing.Size(128, 16);
            this.chkFragment.TabIndex = 5;
            this.chkFragment.Text = "장별로 PPT 나누기";
            this.chkFragment.UseVisualStyleBackColor = true;
            this.chkFragment.CheckedChanged += new System.EventHandler(this.chkFragment_CheckedChanged);
            // 
            // lstBooks
            // 
            this.lstBooks.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lstBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstBooks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.length});
            this.lstBooks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstBooks.FullRowSelect = true;
            this.lstBooks.GridLines = true;
            this.lstBooks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstBooks.HideSelection = false;
            this.lstBooks.Location = new System.Drawing.Point(0, 95);
            this.lstBooks.Margin = new System.Windows.Forms.Padding(0);
            this.lstBooks.Name = "lstBooks";
            this.lstBooks.Size = new System.Drawing.Size(151, 154);
            this.lstBooks.TabIndex = 0;
            this.lstBooks.TabStop = false;
            this.lstBooks.UseCompatibleStateImageBehavior = false;
            this.lstBooks.View = System.Windows.Forms.View.Details;
            this.lstBooks.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstBooks_MouseClick);
            // 
            // title
            // 
            this.title.Text = "제목";
            this.title.Width = 98;
            // 
            // length
            // 
            this.length.Text = "장수";
            this.length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.length.Width = 36;
            // 
            // txtSearch
            // 
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtSearch.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(0, 72);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(151, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.Text = "검색...";
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.chkUseCache, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lstBooks, 0, 6);
            this.tableLayoutPanel2.Controls.Add(this.txtSearch, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.cmbBibleSource, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbBibleVersion, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(151, 249);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chkUseCache
            // 
            this.chkUseCache.AutoSize = true;
            this.chkUseCache.Location = new System.Drawing.Point(3, 3);
            this.chkUseCache.Name = "chkUseCache";
            this.chkUseCache.Size = new System.Drawing.Size(128, 16);
            this.chkUseCache.TabIndex = 1;
            this.chkUseCache.Text = "오프라인 캐시 사용";
            this.chkUseCache.UseVisualStyleBackColor = true;
            this.chkUseCache.CheckedChanged += new System.EventHandler(this.chkUseCache_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1MinSize = 0;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.Size = new System.Drawing.Size(334, 249);
            this.splitContainer1.SplitterDistance = 151;
            this.splitContainer1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(334, 249);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "성경2PPT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox cmbShortTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.TextBox txtKeyword;
        private System.Windows.Forms.ComboBox cmbChapNum;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.ComboBox cmbLongTitle;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader length;
        private System.Windows.Forms.ListView lstBooks;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkFragment;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmbBibleSource;
        private System.Windows.Forms.ComboBox cmbBibleVersion;
        private System.Windows.Forms.CheckBox chkUseCache;
    }
}

