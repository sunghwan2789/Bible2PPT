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
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            this.menuSetting = new FontAwesome.Sharp.IconButton();
            this.menuMake = new FontAwesome.Sharp.IconButton();
            this.menuHistory = new FontAwesome.Sharp.IconButton();
            this.menuTemplate = new FontAwesome.Sharp.IconButton();
            this.multiPanel1 = new Bible2PPT.MultiPanel();
            this.multiPanelPageMake = new Bible2PPT.MultiPanelPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.iconButton4 = new FontAwesome.Sharp.IconButton();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.multiPanelPageHistory = new Bible2PPT.MultiPanelPage();
            this.multiPanelPageTemplate = new Bible2PPT.MultiPanelPage();
            this.multiPanelPageSetting = new Bible2PPT.MultiPanelPage();
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
            tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            tableLayoutPanel3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            this.multiPanel1.SuspendLayout();
            this.multiPanelPageMake.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(flowLayoutPanel2, 0, 1);
            tableLayoutPanel3.Controls.Add(flowLayoutPanel1, 0, 0);
            tableLayoutPanel3.Controls.Add(this.multiPanel1, 1, 0);
            tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Left;
            tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            tableLayoutPanel3.Size = new System.Drawing.Size(527, 385);
            tableLayoutPanel3.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.SystemColors.MenuBar;
            flowLayoutPanel2.Controls.Add(this.menuSetting);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 337);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(48, 48);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // menuSetting
            // 
            this.menuSetting.FlatAppearance.BorderSize = 0;
            this.menuSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuSetting.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.menuSetting.ForeColor = System.Drawing.SystemColors.MenuText;
            this.menuSetting.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.menuSetting.IconColor = System.Drawing.SystemColors.MenuText;
            this.menuSetting.IconSize = 36;
            this.menuSetting.Location = new System.Drawing.Point(0, 0);
            this.menuSetting.Margin = new System.Windows.Forms.Padding(0);
            this.menuSetting.Name = "menuSetting";
            this.menuSetting.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.menuSetting.Rotation = 0D;
            this.menuSetting.Size = new System.Drawing.Size(48, 48);
            this.menuSetting.TabIndex = 2;
            this.menuSetting.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.MenuBar;
            flowLayoutPanel1.Controls.Add(this.menuMake);
            flowLayoutPanel1.Controls.Add(this.menuHistory);
            flowLayoutPanel1.Controls.Add(this.menuTemplate);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(48, 337);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // menuMake
            // 
            this.menuMake.FlatAppearance.BorderSize = 0;
            this.menuMake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuMake.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.menuMake.ForeColor = System.Drawing.SystemColors.MenuText;
            this.menuMake.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.menuMake.IconColor = System.Drawing.SystemColors.MenuText;
            this.menuMake.IconSize = 36;
            this.menuMake.Location = new System.Drawing.Point(0, 0);
            this.menuMake.Margin = new System.Windows.Forms.Padding(0);
            this.menuMake.Name = "menuMake";
            this.menuMake.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.menuMake.Rotation = 0D;
            this.menuMake.Size = new System.Drawing.Size(48, 48);
            this.menuMake.TabIndex = 1;
            this.menuMake.UseVisualStyleBackColor = true;
            // 
            // menuHistory
            // 
            this.menuHistory.FlatAppearance.BorderSize = 0;
            this.menuHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuHistory.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.menuHistory.ForeColor = System.Drawing.SystemColors.MenuText;
            this.menuHistory.IconChar = FontAwesome.Sharp.IconChar.History;
            this.menuHistory.IconColor = System.Drawing.SystemColors.MenuText;
            this.menuHistory.IconSize = 36;
            this.menuHistory.Location = new System.Drawing.Point(0, 48);
            this.menuHistory.Margin = new System.Windows.Forms.Padding(0);
            this.menuHistory.Name = "menuHistory";
            this.menuHistory.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.menuHistory.Rotation = 0D;
            this.menuHistory.Size = new System.Drawing.Size(48, 48);
            this.menuHistory.TabIndex = 2;
            this.menuHistory.UseVisualStyleBackColor = true;
            // 
            // menuTemplate
            // 
            this.menuTemplate.FlatAppearance.BorderSize = 0;
            this.menuTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.menuTemplate.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.menuTemplate.ForeColor = System.Drawing.SystemColors.MenuText;
            this.menuTemplate.IconChar = FontAwesome.Sharp.IconChar.Edit;
            this.menuTemplate.IconColor = System.Drawing.SystemColors.MenuText;
            this.menuTemplate.IconSize = 36;
            this.menuTemplate.Location = new System.Drawing.Point(0, 96);
            this.menuTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.menuTemplate.Name = "menuTemplate";
            this.menuTemplate.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.menuTemplate.Rotation = 0D;
            this.menuTemplate.Size = new System.Drawing.Size(48, 48);
            this.menuTemplate.TabIndex = 3;
            this.menuTemplate.UseVisualStyleBackColor = true;
            // 
            // multiPanel1
            // 
            this.multiPanel1.Controls.Add(this.multiPanelPageMake);
            this.multiPanel1.Controls.Add(this.multiPanelPageHistory);
            this.multiPanel1.Controls.Add(this.multiPanelPageTemplate);
            this.multiPanel1.Controls.Add(this.multiPanelPageSetting);
            this.multiPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiPanel1.Location = new System.Drawing.Point(48, 0);
            this.multiPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.multiPanel1.Name = "multiPanel1";
            tableLayoutPanel3.SetRowSpan(this.multiPanel1, 2);
            this.multiPanel1.SelectedPage = null;
            this.multiPanel1.Size = new System.Drawing.Size(479, 385);
            this.multiPanel1.TabIndex = 1;
            // 
            // multiPanelPageMake
            // 
            this.multiPanelPageMake.Controls.Add(this.label2);
            this.multiPanelPageMake.Controls.Add(this.label1);
            this.multiPanelPageMake.Controls.Add(this.iconButton4);
            this.multiPanelPageMake.Controls.Add(this.iconButton3);
            this.multiPanelPageMake.Controls.Add(this.iconButton2);
            this.multiPanelPageMake.Controls.Add(this.iconButton1);
            this.multiPanelPageMake.Controls.Add(this.iconPictureBox2);
            this.multiPanelPageMake.Controls.Add(this.iconPictureBox1);
            this.multiPanelPageMake.Controls.Add(this.listView1);
            this.multiPanelPageMake.Controls.Add(this.comboBox2);
            this.multiPanelPageMake.Controls.Add(this.comboBox1);
            this.multiPanelPageMake.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiPanelPageMake.Location = new System.Drawing.Point(0, 0);
            this.multiPanelPageMake.Name = "multiPanelPageMake";
            this.multiPanelPageMake.Size = new System.Drawing.Size(479, 385);
            this.multiPanelPageMake.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "성경";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "소스";
            // 
            // iconButton4
            // 
            this.iconButton4.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton4.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.iconButton4.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconButton4.IconSize = 24;
            this.iconButton4.Location = new System.Drawing.Point(206, 211);
            this.iconButton4.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton4.Name = "iconButton4";
            this.iconButton4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconButton4.Rotation = 0D;
            this.iconButton4.Size = new System.Drawing.Size(32, 32);
            this.iconButton4.TabIndex = 6;
            this.iconButton4.UseVisualStyleBackColor = true;
            // 
            // iconButton3
            // 
            this.iconButton3.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.iconButton3.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconButton3.IconSize = 24;
            this.iconButton3.Location = new System.Drawing.Point(174, 211);
            this.iconButton3.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconButton3.Rotation = 0D;
            this.iconButton3.Size = new System.Drawing.Size(32, 32);
            this.iconButton3.TabIndex = 6;
            this.iconButton3.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.iconButton2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconButton2.IconSize = 24;
            this.iconButton2.Location = new System.Drawing.Point(50, 210);
            this.iconButton2.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(32, 32);
            this.iconButton2.TabIndex = 6;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // iconButton1
            // 
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.AngleUp;
            this.iconButton1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconButton1.IconSize = 24;
            this.iconButton1.Location = new System.Drawing.Point(18, 210);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(32, 32);
            this.iconButton1.TabIndex = 6;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.BackColor = System.Drawing.SystemColors.Window;
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Database;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox2.IconSize = 24;
            this.iconPictureBox2.Location = new System.Drawing.Point(17, 19);
            this.iconPictureBox2.Margin = new System.Windows.Forms.Padding(0);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconPictureBox2.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox2.TabIndex = 5;
            this.iconPictureBox2.TabStop = false;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.SystemColors.Window;
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bible;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.ControlText;
            this.iconPictureBox1.IconSize = 24;
            this.iconPictureBox1.Location = new System.Drawing.Point(17, 54);
            this.iconPictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.iconPictureBox1.Size = new System.Drawing.Size(24, 24);
            this.iconPictureBox1.TabIndex = 5;
            this.iconPictureBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(17, 95);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(220, 112);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "순서";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "소스";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "성경";
            // 
            // comboBox2
            // 
            this.comboBox2.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(79, 58);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(158, 20);
            this.comboBox2.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(80, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(158, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // multiPanelPageHistory
            // 
            this.multiPanelPageHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiPanelPageHistory.Location = new System.Drawing.Point(0, 0);
            this.multiPanelPageHistory.Name = "multiPanelPageHistory";
            this.multiPanelPageHistory.Size = new System.Drawing.Size(479, 385);
            this.multiPanelPageHistory.TabIndex = 0;
            // 
            // multiPanelPageTemplate
            // 
            this.multiPanelPageTemplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiPanelPageTemplate.Location = new System.Drawing.Point(0, 0);
            this.multiPanelPageTemplate.Name = "multiPanelPageTemplate";
            this.multiPanelPageTemplate.Size = new System.Drawing.Size(479, 385);
            this.multiPanelPageTemplate.TabIndex = 0;
            // 
            // multiPanelPageSetting
            // 
            this.multiPanelPageSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiPanelPageSetting.Location = new System.Drawing.Point(0, 0);
            this.multiPanelPageSetting.Name = "multiPanelPageSetting";
            this.multiPanelPageSetting.Size = new System.Drawing.Size(479, 385);
            this.multiPanelPageSetting.TabIndex = 0;
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
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(547, 54);
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
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(893, 385);
            this.Controls.Add(tableLayoutPanel3);
            this.Controls.Add(this.splitContainer1);
            this.Name = "MainForm";
            this.Text = "성경2PPT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            tableLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            this.multiPanel1.ResumeLayout(false);
            this.multiPanelPageMake.ResumeLayout(false);
            this.multiPanelPageMake.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
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
        private FontAwesome.Sharp.IconButton menuMake;
        private MultiPanel multiPanel1;
        private MultiPanelPage multiPanelPageMake;
        private MultiPanelPage multiPanelPageHistory;
        private MultiPanelPage multiPanelPageTemplate;
        private MultiPanelPage multiPanelPageSetting;
        private FontAwesome.Sharp.IconButton menuHistory;
        private FontAwesome.Sharp.IconButton menuSetting;
        private FontAwesome.Sharp.IconButton menuTemplate;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton4;
    }
}

