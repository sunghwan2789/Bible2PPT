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
            System.Windows.Forms.TableLayoutPanel mainTableLayoutPanel;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
            System.Windows.Forms.TableLayoutPanel makeLeftTableLayoutPanel;
            System.Windows.Forms.TableLayoutPanel biblesTableLayoutPanel;
            System.Windows.Forms.TableLayoutPanel biblesButtonTableLayoutPanel;
            System.Windows.Forms.TableLayoutPanel bibleTableLayoutPanel;
            FontAwesome.Sharp.IconPictureBox bibleIconPictureBox;
            System.Windows.Forms.Label bibleLabel;
            System.Windows.Forms.TableLayoutPanel sourceTableLayoutPanel;
            System.Windows.Forms.Label sourceLabel;
            FontAwesome.Sharp.IconPictureBox sourceIconPictureBox;
            System.Windows.Forms.TableLayoutPanel templateTableLayoutPanel;
            FontAwesome.Sharp.IconPictureBox templateIconPictureBox;
            System.Windows.Forms.TableLayoutPanel makeRightTableLayoutPanel;
            this.settingsNav = new FontAwesome.Sharp.IconButton();
            this.makeNav = new FontAwesome.Sharp.IconButton();
            this.historyNav = new FontAwesome.Sharp.IconButton();
            this.templatesNav = new FontAwesome.Sharp.IconButton();
            this.mainMultiPanel = new Bible2PPT.MultiPanel();
            this.makeMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.makeSplitContainer = new System.Windows.Forms.SplitContainer();
            this.biblesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.biblesUpIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesDownIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesAddIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesRemoveIconButton = new FontAwesome.Sharp.IconButton();
            this.bibleComboBox = new System.Windows.Forms.ComboBox();
            this.templateChaperNumberComboBox = new System.Windows.Forms.ComboBox();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.templateShortTitleComboBox = new System.Windows.Forms.ComboBox();
            this.templateLongTitleComboBox = new System.Windows.Forms.ComboBox();
            this.templateLabel = new System.Windows.Forms.Label();
            this.templateComboBox = new System.Windows.Forms.ComboBox();
            this.booksSearchTextBox = new System.Windows.Forms.TextBox();
            this.booksListView = new System.Windows.Forms.ListView();
            this.title = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.length = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.makeFragmentCheckBox = new System.Windows.Forms.CheckBox();
            this.makeButton = new System.Windows.Forms.Button();
            this.makeKeywordTextBox = new System.Windows.Forms.TextBox();
            this.historyMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.templatesMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.btnGithub = new System.Windows.Forms.Button();
            this.btnTemplate = new System.Windows.Forms.Button();
            this.settingsMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.chkUseCache = new System.Windows.Forms.CheckBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            makeLeftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            biblesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            biblesButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            bibleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            bibleIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            bibleLabel = new System.Windows.Forms.Label();
            sourceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            sourceLabel = new System.Windows.Forms.Label();
            sourceIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            templateTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            templateIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            makeRightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            mainTableLayoutPanel.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            this.mainMultiPanel.SuspendLayout();
            this.makeMultiPanelPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.makeSplitContainer)).BeginInit();
            this.makeSplitContainer.Panel1.SuspendLayout();
            this.makeSplitContainer.Panel2.SuspendLayout();
            this.makeSplitContainer.SuspendLayout();
            makeLeftTableLayoutPanel.SuspendLayout();
            biblesTableLayoutPanel.SuspendLayout();
            biblesButtonTableLayoutPanel.SuspendLayout();
            bibleTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(bibleIconPictureBox)).BeginInit();
            sourceTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(sourceIconPictureBox)).BeginInit();
            templateTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(templateIconPictureBox)).BeginInit();
            makeRightTableLayoutPanel.SuspendLayout();
            this.templatesMultiPanelPage.SuspendLayout();
            this.settingsMultiPanelPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.Controls.Add(flowLayoutPanel2, 0, 1);
            mainTableLayoutPanel.Controls.Add(flowLayoutPanel1, 0, 0);
            mainTableLayoutPanel.Controls.Add(this.mainMultiPanel, 1, 0);
            mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 2;
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainTableLayoutPanel.Size = new System.Drawing.Size(540, 335);
            mainTableLayoutPanel.TabIndex = 3;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.BackColor = System.Drawing.SystemColors.MenuBar;
            flowLayoutPanel2.Controls.Add(this.settingsNav);
            flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            flowLayoutPanel2.Location = new System.Drawing.Point(0, 287);
            flowLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new System.Drawing.Size(48, 48);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // settingsNav
            // 
            this.settingsNav.BackColor = System.Drawing.SystemColors.Menu;
            this.settingsNav.FlatAppearance.BorderSize = 0;
            this.settingsNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsNav.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.settingsNav.ForeColor = System.Drawing.SystemColors.MenuText;
            this.settingsNav.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.settingsNav.IconColor = System.Drawing.SystemColors.MenuText;
            this.settingsNav.IconSize = 36;
            this.settingsNav.Location = new System.Drawing.Point(0, 0);
            this.settingsNav.Margin = new System.Windows.Forms.Padding(0);
            this.settingsNav.Name = "settingsNav";
            this.settingsNav.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.settingsNav.Rotation = 0D;
            this.settingsNav.Size = new System.Drawing.Size(48, 48);
            this.settingsNav.TabIndex = 2;
            this.settingsNav.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = System.Drawing.SystemColors.MenuBar;
            flowLayoutPanel1.Controls.Add(this.makeNav);
            flowLayoutPanel1.Controls.Add(this.historyNav);
            flowLayoutPanel1.Controls.Add(this.templatesNav);
            flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new System.Drawing.Size(48, 287);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // makeNav
            // 
            this.makeNav.BackColor = System.Drawing.SystemColors.Menu;
            this.makeNav.FlatAppearance.BorderSize = 0;
            this.makeNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.makeNav.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.makeNav.ForeColor = System.Drawing.SystemColors.MenuText;
            this.makeNav.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.makeNav.IconColor = System.Drawing.SystemColors.MenuText;
            this.makeNav.IconSize = 36;
            this.makeNav.Location = new System.Drawing.Point(0, 0);
            this.makeNav.Margin = new System.Windows.Forms.Padding(0);
            this.makeNav.Name = "makeNav";
            this.makeNav.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.makeNav.Rotation = 0D;
            this.makeNav.Size = new System.Drawing.Size(48, 48);
            this.makeNav.TabIndex = 1;
            this.makeNav.UseVisualStyleBackColor = false;
            // 
            // historyNav
            // 
            this.historyNav.BackColor = System.Drawing.SystemColors.Menu;
            this.historyNav.FlatAppearance.BorderSize = 0;
            this.historyNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyNav.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.historyNav.ForeColor = System.Drawing.SystemColors.MenuText;
            this.historyNav.IconChar = FontAwesome.Sharp.IconChar.History;
            this.historyNav.IconColor = System.Drawing.SystemColors.MenuText;
            this.historyNav.IconSize = 36;
            this.historyNav.Location = new System.Drawing.Point(0, 48);
            this.historyNav.Margin = new System.Windows.Forms.Padding(0);
            this.historyNav.Name = "historyNav";
            this.historyNav.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.historyNav.Rotation = 0D;
            this.historyNav.Size = new System.Drawing.Size(48, 48);
            this.historyNav.TabIndex = 2;
            this.historyNav.UseVisualStyleBackColor = false;
            // 
            // templatesNav
            // 
            this.templatesNav.BackColor = System.Drawing.SystemColors.Menu;
            this.templatesNav.FlatAppearance.BorderSize = 0;
            this.templatesNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templatesNav.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.templatesNav.ForeColor = System.Drawing.SystemColors.MenuText;
            this.templatesNav.IconChar = FontAwesome.Sharp.IconChar.Images;
            this.templatesNav.IconColor = System.Drawing.SystemColors.MenuText;
            this.templatesNav.IconSize = 36;
            this.templatesNav.Location = new System.Drawing.Point(0, 96);
            this.templatesNav.Margin = new System.Windows.Forms.Padding(0);
            this.templatesNav.Name = "templatesNav";
            this.templatesNav.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.templatesNav.Rotation = 0D;
            this.templatesNav.Size = new System.Drawing.Size(48, 48);
            this.templatesNav.TabIndex = 3;
            this.templatesNav.UseVisualStyleBackColor = false;
            // 
            // mainMultiPanel
            // 
            this.mainMultiPanel.Controls.Add(this.makeMultiPanelPage);
            this.mainMultiPanel.Controls.Add(this.historyMultiPanelPage);
            this.mainMultiPanel.Controls.Add(this.templatesMultiPanelPage);
            this.mainMultiPanel.Controls.Add(this.settingsMultiPanelPage);
            this.mainMultiPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMultiPanel.Location = new System.Drawing.Point(48, 0);
            this.mainMultiPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainMultiPanel.Name = "mainMultiPanel";
            mainTableLayoutPanel.SetRowSpan(this.mainMultiPanel, 2);
            this.mainMultiPanel.SelectedPage = this.makeMultiPanelPage;
            this.mainMultiPanel.Size = new System.Drawing.Size(492, 335);
            this.mainMultiPanel.TabIndex = 1;
            // 
            // makeMultiPanelPage
            // 
            this.makeMultiPanelPage.Controls.Add(this.makeSplitContainer);
            this.makeMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.makeMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.makeMultiPanelPage.Name = "makeMultiPanelPage";
            this.makeMultiPanelPage.Size = new System.Drawing.Size(492, 335);
            this.makeMultiPanelPage.TabIndex = 0;
            // 
            // makeSplitContainer
            // 
            this.makeSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.makeSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.makeSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.makeSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.makeSplitContainer.Name = "makeSplitContainer";
            // 
            // makeSplitContainer.Panel1
            // 
            this.makeSplitContainer.Panel1.Controls.Add(makeLeftTableLayoutPanel);
            this.makeSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(13, 10, 0, 10);
            // 
            // makeSplitContainer.Panel2
            // 
            this.makeSplitContainer.Panel2.Controls.Add(makeRightTableLayoutPanel);
            this.makeSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 10, 13, 10);
            this.makeSplitContainer.Size = new System.Drawing.Size(492, 335);
            this.makeSplitContainer.SplitterDistance = 238;
            this.makeSplitContainer.SplitterWidth = 13;
            this.makeSplitContainer.TabIndex = 14;
            // 
            // makeLeftTableLayoutPanel
            // 
            makeLeftTableLayoutPanel.ColumnCount = 1;
            makeLeftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            makeLeftTableLayoutPanel.Controls.Add(biblesTableLayoutPanel, 0, 4);
            makeLeftTableLayoutPanel.Controls.Add(bibleTableLayoutPanel, 0, 2);
            makeLeftTableLayoutPanel.Controls.Add(this.templateChaperNumberComboBox, 0, 12);
            makeLeftTableLayoutPanel.Controls.Add(sourceTableLayoutPanel, 0, 0);
            makeLeftTableLayoutPanel.Controls.Add(this.templateShortTitleComboBox, 0, 10);
            makeLeftTableLayoutPanel.Controls.Add(this.templateLongTitleComboBox, 0, 8);
            makeLeftTableLayoutPanel.Controls.Add(templateTableLayoutPanel, 0, 6);
            makeLeftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            makeLeftTableLayoutPanel.Location = new System.Drawing.Point(13, 10);
            makeLeftTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            makeLeftTableLayoutPanel.Name = "makeLeftTableLayoutPanel";
            makeLeftTableLayoutPanel.RowCount = 13;
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            makeLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            makeLeftTableLayoutPanel.Size = new System.Drawing.Size(225, 315);
            makeLeftTableLayoutPanel.TabIndex = 0;
            // 
            // biblesTableLayoutPanel
            // 
            biblesTableLayoutPanel.ColumnCount = 1;
            biblesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesTableLayoutPanel.Controls.Add(this.biblesListView, 0, 0);
            biblesTableLayoutPanel.Controls.Add(biblesButtonTableLayoutPanel, 0, 2);
            biblesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            biblesTableLayoutPanel.Location = new System.Drawing.Point(0, 54);
            biblesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            biblesTableLayoutPanel.Name = "biblesTableLayoutPanel";
            biblesTableLayoutPanel.RowCount = 3;
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            biblesTableLayoutPanel.Size = new System.Drawing.Size(225, 153);
            biblesTableLayoutPanel.TabIndex = 1;
            // 
            // biblesListView
            // 
            this.biblesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.biblesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biblesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.biblesListView.HideSelection = false;
            this.biblesListView.Location = new System.Drawing.Point(0, 0);
            this.biblesListView.Margin = new System.Windows.Forms.Padding(0);
            this.biblesListView.Name = "biblesListView";
            this.biblesListView.Size = new System.Drawing.Size(225, 118);
            this.biblesListView.TabIndex = 4;
            this.biblesListView.UseCompatibleStateImageBehavior = false;
            this.biblesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "순서";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "소스";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "성경";
            this.columnHeader3.Width = 80;
            // 
            // biblesButtonTableLayoutPanel
            // 
            biblesButtonTableLayoutPanel.ColumnCount = 5;
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesUpIconButton, 0, 0);
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesDownIconButton, 1, 0);
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesAddIconButton, 3, 0);
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesRemoveIconButton, 4, 0);
            biblesButtonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            biblesButtonTableLayoutPanel.Location = new System.Drawing.Point(0, 121);
            biblesButtonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            biblesButtonTableLayoutPanel.Name = "biblesButtonTableLayoutPanel";
            biblesButtonTableLayoutPanel.RowCount = 1;
            biblesButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesButtonTableLayoutPanel.Size = new System.Drawing.Size(225, 32);
            biblesButtonTableLayoutPanel.TabIndex = 5;
            // 
            // biblesUpIconButton
            // 
            this.biblesUpIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesUpIconButton.IconChar = FontAwesome.Sharp.IconChar.AngleUp;
            this.biblesUpIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesUpIconButton.IconSize = 24;
            this.biblesUpIconButton.Location = new System.Drawing.Point(0, 0);
            this.biblesUpIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesUpIconButton.Name = "biblesUpIconButton";
            this.biblesUpIconButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.biblesUpIconButton.Rotation = 0D;
            this.biblesUpIconButton.Size = new System.Drawing.Size(32, 32);
            this.biblesUpIconButton.TabIndex = 6;
            this.biblesUpIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesDownIconButton
            // 
            this.biblesDownIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesDownIconButton.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.biblesDownIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesDownIconButton.IconSize = 24;
            this.biblesDownIconButton.Location = new System.Drawing.Point(32, 0);
            this.biblesDownIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesDownIconButton.Name = "biblesDownIconButton";
            this.biblesDownIconButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.biblesDownIconButton.Rotation = 0D;
            this.biblesDownIconButton.Size = new System.Drawing.Size(32, 32);
            this.biblesDownIconButton.TabIndex = 6;
            this.biblesDownIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesAddIconButton
            // 
            this.biblesAddIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesAddIconButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.biblesAddIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesAddIconButton.IconSize = 24;
            this.biblesAddIconButton.Location = new System.Drawing.Point(161, 0);
            this.biblesAddIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesAddIconButton.Name = "biblesAddIconButton";
            this.biblesAddIconButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.biblesAddIconButton.Rotation = 0D;
            this.biblesAddIconButton.Size = new System.Drawing.Size(32, 32);
            this.biblesAddIconButton.TabIndex = 6;
            this.biblesAddIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesRemoveIconButton
            // 
            this.biblesRemoveIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesRemoveIconButton.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.biblesRemoveIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesRemoveIconButton.IconSize = 24;
            this.biblesRemoveIconButton.Location = new System.Drawing.Point(193, 0);
            this.biblesRemoveIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesRemoveIconButton.Name = "biblesRemoveIconButton";
            this.biblesRemoveIconButton.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.biblesRemoveIconButton.Rotation = 0D;
            this.biblesRemoveIconButton.Size = new System.Drawing.Size(32, 32);
            this.biblesRemoveIconButton.TabIndex = 6;
            this.biblesRemoveIconButton.UseVisualStyleBackColor = true;
            // 
            // bibleTableLayoutPanel
            // 
            bibleTableLayoutPanel.ColumnCount = 3;
            bibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            bibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            bibleTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            bibleTableLayoutPanel.Controls.Add(this.bibleComboBox, 2, 0);
            bibleTableLayoutPanel.Controls.Add(bibleIconPictureBox, 0, 0);
            bibleTableLayoutPanel.Controls.Add(bibleLabel, 1, 0);
            bibleTableLayoutPanel.Location = new System.Drawing.Point(0, 27);
            bibleTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            bibleTableLayoutPanel.Name = "bibleTableLayoutPanel";
            bibleTableLayoutPanel.RowCount = 1;
            bibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            bibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            bibleTableLayoutPanel.Size = new System.Drawing.Size(225, 24);
            bibleTableLayoutPanel.TabIndex = 0;
            // 
            // bibleComboBox
            // 
            this.bibleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bibleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bibleComboBox.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.bibleComboBox.FormattingEnabled = true;
            this.bibleComboBox.Location = new System.Drawing.Point(64, 2);
            this.bibleComboBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.bibleComboBox.Name = "bibleComboBox";
            this.bibleComboBox.Size = new System.Drawing.Size(161, 20);
            this.bibleComboBox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.bibleComboBox, "성경 선택");
            this.bibleComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbBibleVersion_SelectedIndexChanged);
            // 
            // bibleIconPictureBox
            // 
            bibleIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            bibleIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            bibleIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            bibleIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Bible;
            bibleIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            bibleIconPictureBox.IconSize = 24;
            bibleIconPictureBox.Location = new System.Drawing.Point(0, 0);
            bibleIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            bibleIconPictureBox.Name = "bibleIconPictureBox";
            bibleIconPictureBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            bibleIconPictureBox.Size = new System.Drawing.Size(24, 24);
            bibleIconPictureBox.TabIndex = 5;
            bibleIconPictureBox.TabStop = false;
            // 
            // bibleLabel
            // 
            bibleLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            bibleLabel.AutoSize = true;
            bibleLabel.Location = new System.Drawing.Point(24, 6);
            bibleLabel.Margin = new System.Windows.Forms.Padding(0);
            bibleLabel.Name = "bibleLabel";
            bibleLabel.Size = new System.Drawing.Size(29, 12);
            bibleLabel.TabIndex = 7;
            bibleLabel.Text = "성경";
            // 
            // templateChaperNumberComboBox
            // 
            this.templateChaperNumberComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateChaperNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateChaperNumberComboBox.Items.AddRange(new object[] {
            "장 번호 표시",
            "각 장의 첫 절에만 표시"});
            this.templateChaperNumberComboBox.Location = new System.Drawing.Point(0, 294);
            this.templateChaperNumberComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateChaperNumberComboBox.Name = "templateChaperNumberComboBox";
            this.templateChaperNumberComboBox.Size = new System.Drawing.Size(225, 20);
            this.templateChaperNumberComboBox.TabIndex = 3;
            this.toolTip1.SetToolTip(this.templateChaperNumberComboBox, "장 번호 표시 설정");
            this.templateChaperNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbChapNum_SelectedIndexChanged);
            // 
            // sourceTableLayoutPanel
            // 
            sourceTableLayoutPanel.ColumnCount = 3;
            sourceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            sourceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            sourceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            sourceTableLayoutPanel.Controls.Add(sourceLabel, 1, 0);
            sourceTableLayoutPanel.Controls.Add(this.sourceComboBox, 2, 0);
            sourceTableLayoutPanel.Controls.Add(sourceIconPictureBox, 0, 0);
            sourceTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            sourceTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            sourceTableLayoutPanel.Name = "sourceTableLayoutPanel";
            sourceTableLayoutPanel.RowCount = 1;
            sourceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            sourceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            sourceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            sourceTableLayoutPanel.Size = new System.Drawing.Size(225, 24);
            sourceTableLayoutPanel.TabIndex = 0;
            // 
            // sourceLabel
            // 
            sourceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            sourceLabel.AutoSize = true;
            sourceLabel.Location = new System.Drawing.Point(24, 6);
            sourceLabel.Margin = new System.Windows.Forms.Padding(0);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new System.Drawing.Size(29, 12);
            sourceLabel.TabIndex = 7;
            sourceLabel.Text = "소스";
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.sourceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.sourceComboBox.FormattingEnabled = true;
            this.sourceComboBox.Location = new System.Drawing.Point(64, 2);
            this.sourceComboBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(161, 20);
            this.sourceComboBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.sourceComboBox, "성경 소스 선택");
            this.sourceComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbBibleSource_SelectedIndexChanged);
            // 
            // sourceIconPictureBox
            // 
            sourceIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            sourceIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            sourceIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            sourceIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Database;
            sourceIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            sourceIconPictureBox.IconSize = 24;
            sourceIconPictureBox.Location = new System.Drawing.Point(0, 0);
            sourceIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            sourceIconPictureBox.Name = "sourceIconPictureBox";
            sourceIconPictureBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            sourceIconPictureBox.Size = new System.Drawing.Size(24, 24);
            sourceIconPictureBox.TabIndex = 5;
            sourceIconPictureBox.TabStop = false;
            // 
            // templateShortTitleComboBox
            // 
            this.templateShortTitleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateShortTitleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateShortTitleComboBox.Items.AddRange(new object[] {
            "짧은 제목 표시",
            "각 장의 첫 절에만 표시"});
            this.templateShortTitleComboBox.Location = new System.Drawing.Point(0, 269);
            this.templateShortTitleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateShortTitleComboBox.Name = "templateShortTitleComboBox";
            this.templateShortTitleComboBox.Size = new System.Drawing.Size(225, 20);
            this.templateShortTitleComboBox.TabIndex = 2;
            this.toolTip1.SetToolTip(this.templateShortTitleComboBox, "짧은 제목 표시 설정");
            this.templateShortTitleComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbShortTitle_SelectedIndexChanged);
            // 
            // templateLongTitleComboBox
            // 
            this.templateLongTitleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateLongTitleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateLongTitleComboBox.Items.AddRange(new object[] {
            "긴 제목 표시",
            "각 장의 첫 절에만 표시"});
            this.templateLongTitleComboBox.Location = new System.Drawing.Point(0, 244);
            this.templateLongTitleComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateLongTitleComboBox.Name = "templateLongTitleComboBox";
            this.templateLongTitleComboBox.Size = new System.Drawing.Size(225, 20);
            this.templateLongTitleComboBox.TabIndex = 1;
            this.toolTip1.SetToolTip(this.templateLongTitleComboBox, "긴 제목 표시 설정");
            this.templateLongTitleComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbLongTitle_SelectedIndexChanged);
            // 
            // templateTableLayoutPanel
            // 
            templateTableLayoutPanel.ColumnCount = 3;
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateTableLayoutPanel.Controls.Add(this.templateLabel, 1, 0);
            templateTableLayoutPanel.Controls.Add(this.templateComboBox, 2, 0);
            templateTableLayoutPanel.Controls.Add(templateIconPictureBox, 0, 0);
            templateTableLayoutPanel.Location = new System.Drawing.Point(0, 217);
            templateTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateTableLayoutPanel.Name = "templateTableLayoutPanel";
            templateTableLayoutPanel.RowCount = 1;
            templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateTableLayoutPanel.Size = new System.Drawing.Size(225, 24);
            templateTableLayoutPanel.TabIndex = 14;
            // 
            // templateLabel
            // 
            this.templateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.templateLabel.AutoSize = true;
            this.templateLabel.Location = new System.Drawing.Point(24, 6);
            this.templateLabel.Margin = new System.Windows.Forms.Padding(0);
            this.templateLabel.Name = "templateLabel";
            this.templateLabel.Size = new System.Drawing.Size(41, 12);
            this.templateLabel.TabIndex = 8;
            this.templateLabel.Text = "템플릿";
            // 
            // templateComboBox
            // 
            this.templateComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.templateComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateComboBox.FormattingEnabled = true;
            this.templateComboBox.Location = new System.Drawing.Point(84, 2);
            this.templateComboBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.templateComboBox.Name = "templateComboBox";
            this.templateComboBox.Size = new System.Drawing.Size(141, 20);
            this.templateComboBox.TabIndex = 9;
            // 
            // templateIconPictureBox
            // 
            templateIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            templateIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            templateIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Image;
            templateIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            templateIconPictureBox.IconSize = 24;
            templateIconPictureBox.Location = new System.Drawing.Point(0, 0);
            templateIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            templateIconPictureBox.Name = "templateIconPictureBox";
            templateIconPictureBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            templateIconPictureBox.Size = new System.Drawing.Size(24, 24);
            templateIconPictureBox.TabIndex = 5;
            templateIconPictureBox.TabStop = false;
            // 
            // makeRightTableLayoutPanel
            // 
            makeRightTableLayoutPanel.ColumnCount = 1;
            makeRightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            makeRightTableLayoutPanel.Controls.Add(this.booksSearchTextBox, 0, 0);
            makeRightTableLayoutPanel.Controls.Add(this.booksListView, 0, 1);
            makeRightTableLayoutPanel.Controls.Add(this.makeFragmentCheckBox, 0, 5);
            makeRightTableLayoutPanel.Controls.Add(this.makeButton, 0, 6);
            makeRightTableLayoutPanel.Controls.Add(this.makeKeywordTextBox, 0, 3);
            makeRightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            makeRightTableLayoutPanel.Location = new System.Drawing.Point(0, 10);
            makeRightTableLayoutPanel.Name = "makeRightTableLayoutPanel";
            makeRightTableLayoutPanel.RowCount = 7;
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            makeRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            makeRightTableLayoutPanel.Size = new System.Drawing.Size(228, 315);
            makeRightTableLayoutPanel.TabIndex = 1;
            // 
            // booksSearchTextBox
            // 
            this.booksSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.booksSearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksSearchTextBox.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.booksSearchTextBox.Location = new System.Drawing.Point(0, 0);
            this.booksSearchTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.booksSearchTextBox.Name = "booksSearchTextBox";
            this.booksSearchTextBox.Size = new System.Drawing.Size(228, 22);
            this.booksSearchTextBox.TabIndex = 0;
            this.booksSearchTextBox.Text = "검색...";
            this.booksSearchTextBox.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.booksSearchTextBox.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.booksSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.booksSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.booksSearchTextBox.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // booksListView
            // 
            this.booksListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.booksListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.booksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.title,
            this.length,
            this.columnHeader4});
            this.booksListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksListView.FullRowSelect = true;
            this.booksListView.GridLines = true;
            this.booksListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.booksListView.HideSelection = false;
            this.booksListView.Location = new System.Drawing.Point(0, 23);
            this.booksListView.Margin = new System.Windows.Forms.Padding(0);
            this.booksListView.Name = "booksListView";
            this.booksListView.Size = new System.Drawing.Size(228, 192);
            this.booksListView.TabIndex = 0;
            this.booksListView.TabStop = false;
            this.booksListView.UseCompatibleStateImageBehavior = false;
            this.booksListView.View = System.Windows.Forms.View.Details;
            this.booksListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstBooks_MouseClick);
            // 
            // title
            // 
            this.title.Text = "긴 제목";
            this.title.Width = 98;
            // 
            // length
            // 
            this.length.Text = "장수";
            this.length.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.length.Width = 10;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "키워드";
            // 
            // makeFragmentCheckBox
            // 
            this.makeFragmentCheckBox.AutoSize = true;
            this.makeFragmentCheckBox.Location = new System.Drawing.Point(3, 267);
            this.makeFragmentCheckBox.Name = "makeFragmentCheckBox";
            this.makeFragmentCheckBox.Size = new System.Drawing.Size(128, 16);
            this.makeFragmentCheckBox.TabIndex = 5;
            this.makeFragmentCheckBox.Text = "장별로 PPT 나누기";
            this.makeFragmentCheckBox.UseVisualStyleBackColor = true;
            this.makeFragmentCheckBox.CheckedChanged += new System.EventHandler(this.chkFragment_CheckedChanged);
            // 
            // makeButton
            // 
            this.makeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.makeButton.Location = new System.Drawing.Point(0, 286);
            this.makeButton.Margin = new System.Windows.Forms.Padding(0);
            this.makeButton.Name = "makeButton";
            this.makeButton.Size = new System.Drawing.Size(228, 29);
            this.makeButton.TabIndex = 6;
            this.makeButton.Text = "PPT 만들기";
            this.makeButton.UseVisualStyleBackColor = true;
            this.makeButton.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // makeKeywordTextBox
            // 
            this.makeKeywordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.makeKeywordTextBox.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.makeKeywordTextBox.Location = new System.Drawing.Point(0, 225);
            this.makeKeywordTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.makeKeywordTextBox.Name = "makeKeywordTextBox";
            this.makeKeywordTextBox.Size = new System.Drawing.Size(228, 29);
            this.makeKeywordTextBox.TabIndex = 4;
            this.makeKeywordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
            this.makeKeywordTextBox.MouseHover += new System.EventHandler(this.txtKeyword_MouseHover);
            // 
            // historyMultiPanelPage
            // 
            this.historyMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.historyMultiPanelPage.Name = "historyMultiPanelPage";
            this.historyMultiPanelPage.Size = new System.Drawing.Size(479, 319);
            this.historyMultiPanelPage.TabIndex = 0;
            // 
            // templatesMultiPanelPage
            // 
            this.templatesMultiPanelPage.Controls.Add(this.btnGithub);
            this.templatesMultiPanelPage.Controls.Add(this.btnTemplate);
            this.templatesMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templatesMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.templatesMultiPanelPage.Name = "templatesMultiPanelPage";
            this.templatesMultiPanelPage.Size = new System.Drawing.Size(479, 319);
            this.templatesMultiPanelPage.TabIndex = 0;
            // 
            // btnGithub
            // 
            this.btnGithub.BackgroundImage = global::Bible2PPT.Properties.Resources.GitHub_Mark_32px;
            this.btnGithub.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGithub.Location = new System.Drawing.Point(143, 203);
            this.btnGithub.Margin = new System.Windows.Forms.Padding(0);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(29, 29);
            this.btnGithub.TabIndex = 0;
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.btnGithub_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(88, 96);
            this.btnTemplate.Margin = new System.Windows.Forms.Padding(0);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(124, 29);
            this.btnTemplate.TabIndex = 0;
            this.btnTemplate.Text = "템플릿 열기";
            this.btnTemplate.UseVisualStyleBackColor = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            this.btnTemplate.MouseHover += new System.EventHandler(this.btnTemplate_MouseHover);
            // 
            // settingsMultiPanelPage
            // 
            this.settingsMultiPanelPage.Controls.Add(this.chkUseCache);
            this.settingsMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.settingsMultiPanelPage.Name = "settingsMultiPanelPage";
            this.settingsMultiPanelPage.Size = new System.Drawing.Size(479, 319);
            this.settingsMultiPanelPage.TabIndex = 0;
            // 
            // chkUseCache
            // 
            this.chkUseCache.AutoSize = true;
            this.chkUseCache.Location = new System.Drawing.Point(33, 33);
            this.chkUseCache.Name = "chkUseCache";
            this.chkUseCache.Size = new System.Drawing.Size(128, 16);
            this.chkUseCache.TabIndex = 1;
            this.chkUseCache.Text = "오프라인 캐시 사용";
            this.chkUseCache.UseVisualStyleBackColor = true;
            this.chkUseCache.CheckedChanged += new System.EventHandler(this.chkUseCache_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(540, 335);
            this.Controls.Add(mainTableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "성경2PPT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            mainTableLayoutPanel.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            this.mainMultiPanel.ResumeLayout(false);
            this.makeMultiPanelPage.ResumeLayout(false);
            this.makeSplitContainer.Panel1.ResumeLayout(false);
            this.makeSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.makeSplitContainer)).EndInit();
            this.makeSplitContainer.ResumeLayout(false);
            makeLeftTableLayoutPanel.ResumeLayout(false);
            biblesTableLayoutPanel.ResumeLayout(false);
            biblesButtonTableLayoutPanel.ResumeLayout(false);
            bibleTableLayoutPanel.ResumeLayout(false);
            bibleTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(bibleIconPictureBox)).EndInit();
            sourceTableLayoutPanel.ResumeLayout(false);
            sourceTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(sourceIconPictureBox)).EndInit();
            templateTableLayoutPanel.ResumeLayout(false);
            templateTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(templateIconPictureBox)).EndInit();
            makeRightTableLayoutPanel.ResumeLayout(false);
            makeRightTableLayoutPanel.PerformLayout();
            this.templatesMultiPanelPage.ResumeLayout(false);
            this.settingsMultiPanelPage.ResumeLayout(false);
            this.settingsMultiPanelPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ComboBox templateShortTitleComboBox;
        private System.Windows.Forms.Button btnTemplate;
        private System.Windows.Forms.TextBox makeKeywordTextBox;
        private System.Windows.Forms.ComboBox templateChaperNumberComboBox;
        private System.Windows.Forms.Button makeButton;
        private System.Windows.Forms.ComboBox templateLongTitleComboBox;
        private System.Windows.Forms.ColumnHeader title;
        private System.Windows.Forms.ColumnHeader length;
        private System.Windows.Forms.ListView booksListView;
        private System.Windows.Forms.TextBox booksSearchTextBox;
        private System.Windows.Forms.CheckBox makeFragmentCheckBox;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.ComboBox bibleComboBox;
        private System.Windows.Forms.CheckBox chkUseCache;
        private FontAwesome.Sharp.IconButton makeNav;
        private MultiPanel mainMultiPanel;
        private MultiPanelPage historyMultiPanelPage;
        private MultiPanelPage templatesMultiPanelPage;
        private MultiPanelPage settingsMultiPanelPage;
        private FontAwesome.Sharp.IconButton historyNav;
        private FontAwesome.Sharp.IconButton settingsNav;
        private FontAwesome.Sharp.IconButton templatesNav;
        private MultiPanelPage makeMultiPanelPage;
        private System.Windows.Forms.ComboBox templateComboBox;
        private System.Windows.Forms.Label templateLabel;
        private FontAwesome.Sharp.IconButton biblesRemoveIconButton;
        private FontAwesome.Sharp.IconButton biblesAddIconButton;
        private FontAwesome.Sharp.IconButton biblesDownIconButton;
        private FontAwesome.Sharp.IconButton biblesUpIconButton;
        private System.Windows.Forms.ListView biblesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.SplitContainer makeSplitContainer;
    }
}

