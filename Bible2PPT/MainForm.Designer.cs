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
            System.Windows.Forms.FlowLayoutPanel navBottomFlowLayoutPanel;
            System.Windows.Forms.FlowLayoutPanel navTopFlowLayoutPanel;
            System.Windows.Forms.TableLayoutPanel biblesTableLayoutPanel;
            System.Windows.Forms.TableLayoutPanel biblesButtonTableLayoutPanel;
            System.Windows.Forms.ColumnHeader columnHeader1;
            System.Windows.Forms.ColumnHeader columnHeader2;
            System.Windows.Forms.ColumnHeader columnHeader3;
            System.Windows.Forms.TableLayoutPanel bibleTableLayoutPanel;
            FontAwesome.Sharp.IconPictureBox bibleIconPictureBox;
            System.Windows.Forms.Label bibleLabel;
            System.Windows.Forms.TableLayoutPanel sourceTableLayoutPanel;
            System.Windows.Forms.Label sourceLabel;
            FontAwesome.Sharp.IconPictureBox sourceIconPictureBox;
            System.Windows.Forms.TableLayoutPanel templateBookAbbrTableLayoutPanel;
            System.Windows.Forms.Label templateBookAbbrLabel;
            System.Windows.Forms.TableLayoutPanel templateChaperNumberTableLayoutPanel;
            System.Windows.Forms.Label templateChaperNumberLabel;
            System.Windows.Forms.TableLayoutPanel templateTableLayoutPanel;
            FontAwesome.Sharp.IconPictureBox templateIconPictureBox;
            System.Windows.Forms.TableLayoutPanel templateBookNameTableLayoutPanel;
            System.Windows.Forms.Label templateBookNameLabel;
            System.Windows.Forms.TableLayoutPanel booksTableLayoutPanel;
            System.Windows.Forms.TableLayoutPanel booksSearchTableLayoutPanel;
            FontAwesome.Sharp.IconPictureBox booksSearchIconPictureBox;
            System.Windows.Forms.ColumnHeader columnHeader4;
            System.Windows.Forms.TableLayoutPanel versesTableLayoutPanel;
            FontAwesome.Sharp.IconPictureBox versesIconPictureBox;
            System.Windows.Forms.Label versesLabel;
            System.Windows.Forms.StatusStrip builderStatusStrip;
            this.settingsNav = new FontAwesome.Sharp.IconButton();
            this.buildNav = new FontAwesome.Sharp.IconButton();
            this.historyNav = new FontAwesome.Sharp.IconButton();
            this.templatesNav = new FontAwesome.Sharp.IconButton();
            this.mainMultiPanel = new Bible2PPT.MultiPanel();
            this.buildMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.buildSplitContainer = new System.Windows.Forms.SplitContainer();
            this.buildLeftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.biblesUpIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesDownIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesAddIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesRemoveIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesListView = new System.Windows.Forms.ListView();
            this.bibleComboBox = new System.Windows.Forms.ComboBox();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.templateBookAbbrComboBox = new System.Windows.Forms.ComboBox();
            this.templateChaperNumberComboBox = new System.Windows.Forms.ComboBox();
            this.templateLabel = new System.Windows.Forms.Label();
            this.templateEditButton = new System.Windows.Forms.Button();
            this.templateBookNameComboBox = new System.Windows.Forms.ComboBox();
            this.buildRightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buildFragmentCheckBox = new System.Windows.Forms.CheckBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.versesTextBox = new System.Windows.Forms.TextBox();
            this.booksSearchTextBox = new System.Windows.Forms.TextBox();
            this.booksListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.historyMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.templatesMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.btnGithub = new System.Windows.Forms.Button();
            this.settingsMultiPanelPage = new Bible2PPT.MultiPanelPage();
            this.chkUseCache = new System.Windows.Forms.CheckBox();
            this.builderToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.builderToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            navBottomFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            navTopFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            biblesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            biblesButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            bibleTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            bibleIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            bibleLabel = new System.Windows.Forms.Label();
            sourceTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            sourceLabel = new System.Windows.Forms.Label();
            sourceIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            templateBookAbbrTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            templateBookAbbrLabel = new System.Windows.Forms.Label();
            templateChaperNumberTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            templateChaperNumberLabel = new System.Windows.Forms.Label();
            templateTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            templateIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            templateBookNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            templateBookNameLabel = new System.Windows.Forms.Label();
            booksTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            booksSearchTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            booksSearchIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            versesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            versesIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            versesLabel = new System.Windows.Forms.Label();
            builderStatusStrip = new System.Windows.Forms.StatusStrip();
            mainTableLayoutPanel.SuspendLayout();
            navBottomFlowLayoutPanel.SuspendLayout();
            navTopFlowLayoutPanel.SuspendLayout();
            this.mainMultiPanel.SuspendLayout();
            this.buildMultiPanelPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buildSplitContainer)).BeginInit();
            this.buildSplitContainer.Panel1.SuspendLayout();
            this.buildSplitContainer.Panel2.SuspendLayout();
            this.buildSplitContainer.SuspendLayout();
            this.buildLeftTableLayoutPanel.SuspendLayout();
            biblesTableLayoutPanel.SuspendLayout();
            biblesButtonTableLayoutPanel.SuspendLayout();
            bibleTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(bibleIconPictureBox)).BeginInit();
            sourceTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(sourceIconPictureBox)).BeginInit();
            templateBookAbbrTableLayoutPanel.SuspendLayout();
            templateChaperNumberTableLayoutPanel.SuspendLayout();
            templateTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(templateIconPictureBox)).BeginInit();
            templateBookNameTableLayoutPanel.SuspendLayout();
            this.buildRightTableLayoutPanel.SuspendLayout();
            booksTableLayoutPanel.SuspendLayout();
            booksSearchTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(booksSearchIconPictureBox)).BeginInit();
            versesTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(versesIconPictureBox)).BeginInit();
            this.templatesMultiPanelPage.SuspendLayout();
            this.settingsMultiPanelPage.SuspendLayout();
            builderStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.Controls.Add(navBottomFlowLayoutPanel, 0, 1);
            mainTableLayoutPanel.Controls.Add(navTopFlowLayoutPanel, 0, 0);
            mainTableLayoutPanel.Controls.Add(this.mainMultiPanel, 1, 0);
            mainTableLayoutPanel.Controls.Add(builderStatusStrip, 0, 2);
            mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            mainTableLayoutPanel.Size = new System.Drawing.Size(509, 335);
            mainTableLayoutPanel.TabIndex = 3;
            // 
            // navBottomFlowLayoutPanel
            // 
            navBottomFlowLayoutPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            navBottomFlowLayoutPanel.Controls.Add(this.settingsNav);
            navBottomFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            navBottomFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            navBottomFlowLayoutPanel.Location = new System.Drawing.Point(0, 264);
            navBottomFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            navBottomFlowLayoutPanel.Name = "navBottomFlowLayoutPanel";
            navBottomFlowLayoutPanel.Size = new System.Drawing.Size(48, 48);
            navBottomFlowLayoutPanel.TabIndex = 2;
            // 
            // settingsNav
            // 
            this.settingsNav.BackColor = System.Drawing.SystemColors.Menu;
            this.settingsNav.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.toolTip.SetToolTip(this.settingsNav, "설정");
            this.settingsNav.UseVisualStyleBackColor = false;
            this.settingsNav.Click += new System.EventHandler(this.Nav_Click);
            // 
            // navTopFlowLayoutPanel
            // 
            navTopFlowLayoutPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            navTopFlowLayoutPanel.Controls.Add(this.buildNav);
            navTopFlowLayoutPanel.Controls.Add(this.historyNav);
            navTopFlowLayoutPanel.Controls.Add(this.templatesNav);
            navTopFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            navTopFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            navTopFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            navTopFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            navTopFlowLayoutPanel.Name = "navTopFlowLayoutPanel";
            navTopFlowLayoutPanel.Size = new System.Drawing.Size(48, 264);
            navTopFlowLayoutPanel.TabIndex = 0;
            // 
            // buildNav
            // 
            this.buildNav.BackColor = System.Drawing.SystemColors.Menu;
            this.buildNav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buildNav.FlatAppearance.BorderSize = 0;
            this.buildNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildNav.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.buildNav.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buildNav.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.buildNav.IconColor = System.Drawing.SystemColors.MenuText;
            this.buildNav.IconSize = 36;
            this.buildNav.Location = new System.Drawing.Point(0, 0);
            this.buildNav.Margin = new System.Windows.Forms.Padding(0);
            this.buildNav.Name = "buildNav";
            this.buildNav.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.buildNav.Rotation = 0D;
            this.buildNav.Size = new System.Drawing.Size(48, 48);
            this.buildNav.TabIndex = 1;
            this.toolTip.SetToolTip(this.buildNav, "PPT 만들기");
            this.buildNav.UseVisualStyleBackColor = false;
            this.buildNav.Click += new System.EventHandler(this.Nav_Click);
            // 
            // historyNav
            // 
            this.historyNav.BackColor = System.Drawing.SystemColors.Menu;
            this.historyNav.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.toolTip.SetToolTip(this.historyNav, "PPT 제작 기록");
            this.historyNav.UseVisualStyleBackColor = false;
            this.historyNav.Click += new System.EventHandler(this.Nav_Click);
            // 
            // templatesNav
            // 
            this.templatesNav.BackColor = System.Drawing.SystemColors.Menu;
            this.templatesNav.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.toolTip.SetToolTip(this.templatesNav, "템플릿 관리");
            this.templatesNav.UseVisualStyleBackColor = false;
            this.templatesNav.Click += new System.EventHandler(this.Nav_Click);
            // 
            // mainMultiPanel
            // 
            this.mainMultiPanel.Controls.Add(this.buildMultiPanelPage);
            this.mainMultiPanel.Controls.Add(this.historyMultiPanelPage);
            this.mainMultiPanel.Controls.Add(this.templatesMultiPanelPage);
            this.mainMultiPanel.Controls.Add(this.settingsMultiPanelPage);
            this.mainMultiPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainMultiPanel.Location = new System.Drawing.Point(48, 0);
            this.mainMultiPanel.Margin = new System.Windows.Forms.Padding(0);
            this.mainMultiPanel.Name = "mainMultiPanel";
            mainTableLayoutPanel.SetRowSpan(this.mainMultiPanel, 2);
            this.mainMultiPanel.SelectedPage = this.buildMultiPanelPage;
            this.mainMultiPanel.Size = new System.Drawing.Size(461, 312);
            this.mainMultiPanel.TabIndex = 1;
            this.mainMultiPanel.SelectedPanelChanged += new System.EventHandler(this.MainMultiPanel_SelectedPanelChanged);
            // 
            // buildMultiPanelPage
            // 
            this.buildMultiPanelPage.Controls.Add(this.buildSplitContainer);
            this.buildMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.buildMultiPanelPage.Name = "buildMultiPanelPage";
            this.buildMultiPanelPage.Size = new System.Drawing.Size(461, 312);
            this.buildMultiPanelPage.TabIndex = 0;
            this.buildMultiPanelPage.Text = "PPT 만들기";
            // 
            // buildSplitContainer
            // 
            this.buildSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.buildSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.buildSplitContainer.Margin = new System.Windows.Forms.Padding(0);
            this.buildSplitContainer.Name = "buildSplitContainer";
            // 
            // buildSplitContainer.Panel1
            // 
            this.buildSplitContainer.Panel1.Controls.Add(this.buildLeftTableLayoutPanel);
            this.buildSplitContainer.Panel1.Padding = new System.Windows.Forms.Padding(13, 10, 0, 10);
            // 
            // buildSplitContainer.Panel2
            // 
            this.buildSplitContainer.Panel2.Controls.Add(this.buildRightTableLayoutPanel);
            this.buildSplitContainer.Panel2.Padding = new System.Windows.Forms.Padding(0, 10, 13, 10);
            this.buildSplitContainer.Size = new System.Drawing.Size(461, 312);
            this.buildSplitContainer.SplitterDistance = 241;
            this.buildSplitContainer.SplitterWidth = 13;
            this.buildSplitContainer.TabIndex = 14;
            // 
            // buildLeftTableLayoutPanel
            // 
            this.buildLeftTableLayoutPanel.ColumnCount = 1;
            this.buildLeftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buildLeftTableLayoutPanel.Controls.Add(biblesTableLayoutPanel, 0, 4);
            this.buildLeftTableLayoutPanel.Controls.Add(bibleTableLayoutPanel, 0, 2);
            this.buildLeftTableLayoutPanel.Controls.Add(sourceTableLayoutPanel, 0, 0);
            this.buildLeftTableLayoutPanel.Controls.Add(templateBookAbbrTableLayoutPanel, 0, 10);
            this.buildLeftTableLayoutPanel.Controls.Add(templateChaperNumberTableLayoutPanel, 0, 12);
            this.buildLeftTableLayoutPanel.Controls.Add(templateTableLayoutPanel, 0, 6);
            this.buildLeftTableLayoutPanel.Controls.Add(templateBookNameTableLayoutPanel, 0, 8);
            this.buildLeftTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildLeftTableLayoutPanel.Location = new System.Drawing.Point(13, 10);
            this.buildLeftTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.buildLeftTableLayoutPanel.Name = "buildLeftTableLayoutPanel";
            this.buildLeftTableLayoutPanel.RowCount = 13;
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 3F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buildLeftTableLayoutPanel.Size = new System.Drawing.Size(228, 292);
            this.buildLeftTableLayoutPanel.TabIndex = 0;
            // 
            // biblesTableLayoutPanel
            // 
            biblesTableLayoutPanel.ColumnCount = 1;
            biblesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesTableLayoutPanel.Controls.Add(biblesButtonTableLayoutPanel, 0, 0);
            biblesTableLayoutPanel.Controls.Add(this.biblesListView, 0, 1);
            biblesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            biblesTableLayoutPanel.Location = new System.Drawing.Point(0, 55);
            biblesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            biblesTableLayoutPanel.Name = "biblesTableLayoutPanel";
            biblesTableLayoutPanel.RowCount = 2;
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            biblesTableLayoutPanel.Size = new System.Drawing.Size(228, 129);
            biblesTableLayoutPanel.TabIndex = 1;
            // 
            // biblesButtonTableLayoutPanel
            // 
            biblesButtonTableLayoutPanel.ColumnCount = 5;
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            biblesButtonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesUpIconButton, 0, 0);
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesDownIconButton, 1, 0);
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesAddIconButton, 3, 0);
            biblesButtonTableLayoutPanel.Controls.Add(this.biblesRemoveIconButton, 4, 0);
            biblesButtonTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            biblesButtonTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            biblesButtonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            biblesButtonTableLayoutPanel.Name = "biblesButtonTableLayoutPanel";
            biblesButtonTableLayoutPanel.RowCount = 1;
            biblesButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesButtonTableLayoutPanel.Size = new System.Drawing.Size(228, 24);
            biblesButtonTableLayoutPanel.TabIndex = 5;
            // 
            // biblesUpIconButton
            // 
            this.biblesUpIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesUpIconButton.IconChar = FontAwesome.Sharp.IconChar.AngleUp;
            this.biblesUpIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesUpIconButton.IconSize = 16;
            this.biblesUpIconButton.Location = new System.Drawing.Point(0, 0);
            this.biblesUpIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesUpIconButton.Name = "biblesUpIconButton";
            this.biblesUpIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesUpIconButton.Rotation = 0D;
            this.biblesUpIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesUpIconButton.TabIndex = 6;
            this.biblesUpIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesDownIconButton
            // 
            this.biblesDownIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesDownIconButton.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.biblesDownIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesDownIconButton.IconSize = 16;
            this.biblesDownIconButton.Location = new System.Drawing.Point(24, 0);
            this.biblesDownIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesDownIconButton.Name = "biblesDownIconButton";
            this.biblesDownIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesDownIconButton.Rotation = 0D;
            this.biblesDownIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesDownIconButton.TabIndex = 6;
            this.biblesDownIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesAddIconButton
            // 
            this.biblesAddIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesAddIconButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.biblesAddIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesAddIconButton.IconSize = 16;
            this.biblesAddIconButton.Location = new System.Drawing.Point(180, 0);
            this.biblesAddIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesAddIconButton.Name = "biblesAddIconButton";
            this.biblesAddIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesAddIconButton.Rotation = 0D;
            this.biblesAddIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesAddIconButton.TabIndex = 6;
            this.biblesAddIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesRemoveIconButton
            // 
            this.biblesRemoveIconButton.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.biblesRemoveIconButton.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.biblesRemoveIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesRemoveIconButton.IconSize = 16;
            this.biblesRemoveIconButton.Location = new System.Drawing.Point(204, 0);
            this.biblesRemoveIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesRemoveIconButton.Name = "biblesRemoveIconButton";
            this.biblesRemoveIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesRemoveIconButton.Rotation = 0D;
            this.biblesRemoveIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesRemoveIconButton.TabIndex = 6;
            this.biblesRemoveIconButton.UseVisualStyleBackColor = true;
            // 
            // biblesListView
            // 
            this.biblesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader1,
            columnHeader2,
            columnHeader3});
            this.biblesListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biblesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.biblesListView.HideSelection = false;
            this.biblesListView.Location = new System.Drawing.Point(0, 24);
            this.biblesListView.Margin = new System.Windows.Forms.Padding(0);
            this.biblesListView.Name = "biblesListView";
            this.biblesListView.Size = new System.Drawing.Size(228, 105);
            this.biblesListView.TabIndex = 4;
            this.biblesListView.UseCompatibleStateImageBehavior = false;
            this.biblesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "순서";
            columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "소스";
            columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "성경";
            columnHeader3.Width = 80;
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
            bibleTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            bibleTableLayoutPanel.Location = new System.Drawing.Point(0, 27);
            bibleTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            bibleTableLayoutPanel.Name = "bibleTableLayoutPanel";
            bibleTableLayoutPanel.RowCount = 1;
            bibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            bibleTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            bibleTableLayoutPanel.Size = new System.Drawing.Size(228, 24);
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
            this.bibleComboBox.Size = new System.Drawing.Size(164, 20);
            this.bibleComboBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.bibleComboBox, "성경 선택");
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
            // sourceTableLayoutPanel
            // 
            sourceTableLayoutPanel.ColumnCount = 3;
            sourceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            sourceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            sourceTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            sourceTableLayoutPanel.Controls.Add(sourceLabel, 1, 0);
            sourceTableLayoutPanel.Controls.Add(this.sourceComboBox, 2, 0);
            sourceTableLayoutPanel.Controls.Add(sourceIconPictureBox, 0, 0);
            sourceTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            sourceTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            sourceTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            sourceTableLayoutPanel.Name = "sourceTableLayoutPanel";
            sourceTableLayoutPanel.RowCount = 1;
            sourceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            sourceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            sourceTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            sourceTableLayoutPanel.Size = new System.Drawing.Size(228, 24);
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
            this.sourceComboBox.Size = new System.Drawing.Size(164, 20);
            this.sourceComboBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.sourceComboBox, "성경 소스 선택");
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
            // templateBookAbbrTableLayoutPanel
            // 
            templateBookAbbrTableLayoutPanel.ColumnCount = 2;
            templateBookAbbrTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateBookAbbrTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookAbbrTableLayoutPanel.Controls.Add(templateBookAbbrLabel, 0, 0);
            templateBookAbbrTableLayoutPanel.Controls.Add(this.templateBookAbbrComboBox, 1, 0);
            templateBookAbbrTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateBookAbbrTableLayoutPanel.Location = new System.Drawing.Point(0, 246);
            templateBookAbbrTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateBookAbbrTableLayoutPanel.Name = "templateBookAbbrTableLayoutPanel";
            templateBookAbbrTableLayoutPanel.RowCount = 1;
            templateBookAbbrTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookAbbrTableLayoutPanel.Size = new System.Drawing.Size(228, 21);
            templateBookAbbrTableLayoutPanel.TabIndex = 18;
            // 
            // templateBookAbbrLabel
            // 
            templateBookAbbrLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateBookAbbrLabel.AutoSize = true;
            templateBookAbbrLabel.Location = new System.Drawing.Point(3, 4);
            templateBookAbbrLabel.Name = "templateBookAbbrLabel";
            templateBookAbbrLabel.Size = new System.Drawing.Size(29, 12);
            templateBookAbbrLabel.TabIndex = 0;
            templateBookAbbrLabel.Text = "약자";
            // 
            // templateBookAbbrComboBox
            // 
            this.templateBookAbbrComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateBookAbbrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateBookAbbrComboBox.Items.AddRange(new object[] {
            "항상 보이기",
            "각 장의 첫 절에만 보이기"});
            this.templateBookAbbrComboBox.Location = new System.Drawing.Point(60, 0);
            this.templateBookAbbrComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateBookAbbrComboBox.Name = "templateBookAbbrComboBox";
            this.templateBookAbbrComboBox.Size = new System.Drawing.Size(168, 20);
            this.templateBookAbbrComboBox.TabIndex = 2;
            this.toolTip.SetToolTip(this.templateBookAbbrComboBox, "약자 표시 설정");
            this.templateBookAbbrComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbShortTitle_SelectedIndexChanged);
            // 
            // templateChaperNumberTableLayoutPanel
            // 
            templateChaperNumberTableLayoutPanel.ColumnCount = 2;
            templateChaperNumberTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateChaperNumberTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateChaperNumberTableLayoutPanel.Controls.Add(templateChaperNumberLabel, 0, 0);
            templateChaperNumberTableLayoutPanel.Controls.Add(this.templateChaperNumberComboBox, 1, 0);
            templateChaperNumberTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateChaperNumberTableLayoutPanel.Location = new System.Drawing.Point(0, 271);
            templateChaperNumberTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateChaperNumberTableLayoutPanel.Name = "templateChaperNumberTableLayoutPanel";
            templateChaperNumberTableLayoutPanel.RowCount = 1;
            templateChaperNumberTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateChaperNumberTableLayoutPanel.Size = new System.Drawing.Size(228, 21);
            templateChaperNumberTableLayoutPanel.TabIndex = 19;
            // 
            // templateChaperNumberLabel
            // 
            templateChaperNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateChaperNumberLabel.AutoSize = true;
            templateChaperNumberLabel.Location = new System.Drawing.Point(3, 4);
            templateChaperNumberLabel.Name = "templateChaperNumberLabel";
            templateChaperNumberLabel.Size = new System.Drawing.Size(45, 12);
            templateChaperNumberLabel.TabIndex = 0;
            templateChaperNumberLabel.Text = "장 번호";
            // 
            // templateChaperNumberComboBox
            // 
            this.templateChaperNumberComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateChaperNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateChaperNumberComboBox.Items.AddRange(new object[] {
            "항상 보이기",
            "각 장의 첫 절에만 보이기"});
            this.templateChaperNumberComboBox.Location = new System.Drawing.Point(60, 0);
            this.templateChaperNumberComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateChaperNumberComboBox.Name = "templateChaperNumberComboBox";
            this.templateChaperNumberComboBox.Size = new System.Drawing.Size(168, 20);
            this.templateChaperNumberComboBox.TabIndex = 3;
            this.toolTip.SetToolTip(this.templateChaperNumberComboBox, "장 번호 표시 설정");
            this.templateChaperNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbChapNum_SelectedIndexChanged);
            // 
            // templateTableLayoutPanel
            // 
            templateTableLayoutPanel.ColumnCount = 3;
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateTableLayoutPanel.Controls.Add(this.templateLabel, 1, 0);
            templateTableLayoutPanel.Controls.Add(templateIconPictureBox, 0, 0);
            templateTableLayoutPanel.Controls.Add(this.templateEditButton, 2, 0);
            templateTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateTableLayoutPanel.Location = new System.Drawing.Point(0, 194);
            templateTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateTableLayoutPanel.Name = "templateTableLayoutPanel";
            templateTableLayoutPanel.RowCount = 1;
            templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateTableLayoutPanel.Size = new System.Drawing.Size(228, 24);
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
            // templateEditButton
            // 
            this.templateEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateEditButton.Location = new System.Drawing.Point(84, 0);
            this.templateEditButton.Margin = new System.Windows.Forms.Padding(0);
            this.templateEditButton.Name = "templateEditButton";
            this.templateEditButton.Size = new System.Drawing.Size(144, 24);
            this.templateEditButton.TabIndex = 0;
            this.templateEditButton.Text = "템플릿 편집하기";
            this.templateEditButton.UseVisualStyleBackColor = true;
            this.templateEditButton.Click += new System.EventHandler(this.btnTemplate_Click);
            this.templateEditButton.MouseHover += new System.EventHandler(this.btnTemplate_MouseHover);
            // 
            // templateBookNameTableLayoutPanel
            // 
            templateBookNameTableLayoutPanel.ColumnCount = 2;
            templateBookNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateBookNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookNameTableLayoutPanel.Controls.Add(templateBookNameLabel, 0, 0);
            templateBookNameTableLayoutPanel.Controls.Add(this.templateBookNameComboBox, 1, 0);
            templateBookNameTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateBookNameTableLayoutPanel.Location = new System.Drawing.Point(0, 221);
            templateBookNameTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateBookNameTableLayoutPanel.Name = "templateBookNameTableLayoutPanel";
            templateBookNameTableLayoutPanel.RowCount = 1;
            templateBookNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookNameTableLayoutPanel.Size = new System.Drawing.Size(228, 21);
            templateBookNameTableLayoutPanel.TabIndex = 15;
            // 
            // templateBookNameLabel
            // 
            templateBookNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateBookNameLabel.AutoSize = true;
            templateBookNameLabel.Location = new System.Drawing.Point(3, 4);
            templateBookNameLabel.Name = "templateBookNameLabel";
            templateBookNameLabel.Size = new System.Drawing.Size(45, 12);
            templateBookNameLabel.TabIndex = 0;
            templateBookNameLabel.Text = "책 이름";
            // 
            // templateBookNameComboBox
            // 
            this.templateBookNameComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateBookNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateBookNameComboBox.Items.AddRange(new object[] {
            "항상 보이기",
            "각 장의 첫 절에만 보이기"});
            this.templateBookNameComboBox.Location = new System.Drawing.Point(60, 0);
            this.templateBookNameComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateBookNameComboBox.Name = "templateBookNameComboBox";
            this.templateBookNameComboBox.Size = new System.Drawing.Size(168, 20);
            this.templateBookNameComboBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.templateBookNameComboBox, "책 이름 표시 설정");
            this.templateBookNameComboBox.SelectedIndexChanged += new System.EventHandler(this.cmbLongTitle_SelectedIndexChanged);
            // 
            // buildRightTableLayoutPanel
            // 
            this.buildRightTableLayoutPanel.ColumnCount = 1;
            this.buildRightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buildRightTableLayoutPanel.Controls.Add(this.buildFragmentCheckBox, 0, 5);
            this.buildRightTableLayoutPanel.Controls.Add(this.buildButton, 0, 6);
            this.buildRightTableLayoutPanel.Controls.Add(this.versesTextBox, 0, 3);
            this.buildRightTableLayoutPanel.Controls.Add(booksTableLayoutPanel, 0, 0);
            this.buildRightTableLayoutPanel.Controls.Add(versesTableLayoutPanel, 0, 2);
            this.buildRightTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildRightTableLayoutPanel.Location = new System.Drawing.Point(0, 10);
            this.buildRightTableLayoutPanel.Name = "buildRightTableLayoutPanel";
            this.buildRightTableLayoutPanel.RowCount = 7;
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.buildRightTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.buildRightTableLayoutPanel.Size = new System.Drawing.Size(194, 292);
            this.buildRightTableLayoutPanel.TabIndex = 1;
            // 
            // buildFragmentCheckBox
            // 
            this.buildFragmentCheckBox.AutoSize = true;
            this.buildFragmentCheckBox.Location = new System.Drawing.Point(3, 244);
            this.buildFragmentCheckBox.Name = "buildFragmentCheckBox";
            this.buildFragmentCheckBox.Size = new System.Drawing.Size(128, 16);
            this.buildFragmentCheckBox.TabIndex = 5;
            this.buildFragmentCheckBox.Text = "장별로 PPT 나누기";
            this.buildFragmentCheckBox.UseVisualStyleBackColor = true;
            this.buildFragmentCheckBox.CheckedChanged += new System.EventHandler(this.chkFragment_CheckedChanged);
            // 
            // buildButton
            // 
            this.buildButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildButton.Location = new System.Drawing.Point(0, 263);
            this.buildButton.Margin = new System.Windows.Forms.Padding(0);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(194, 29);
            this.buildButton.TabIndex = 6;
            this.buildButton.Text = "PPT 만들기";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // versesTextBox
            // 
            this.versesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versesTextBox.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.versesTextBox.Location = new System.Drawing.Point(0, 202);
            this.versesTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.versesTextBox.Name = "versesTextBox";
            this.versesTextBox.Size = new System.Drawing.Size(194, 29);
            this.versesTextBox.TabIndex = 4;
            this.versesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKeyword_KeyPress);
            this.versesTextBox.MouseHover += new System.EventHandler(this.txtKeyword_MouseHover);
            // 
            // booksTableLayoutPanel
            // 
            booksTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            booksTableLayoutPanel.ColumnCount = 1;
            booksTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            booksTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            booksTableLayoutPanel.Controls.Add(booksSearchTableLayoutPanel, 0, 0);
            booksTableLayoutPanel.Controls.Add(this.booksListView, 0, 1);
            booksTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            booksTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            booksTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            booksTableLayoutPanel.Name = "booksTableLayoutPanel";
            booksTableLayoutPanel.RowCount = 2;
            booksTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            booksTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            booksTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            booksTableLayoutPanel.Size = new System.Drawing.Size(194, 168);
            booksTableLayoutPanel.TabIndex = 7;
            // 
            // booksSearchTableLayoutPanel
            // 
            booksSearchTableLayoutPanel.ColumnCount = 2;
            booksSearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            booksSearchTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            booksSearchTableLayoutPanel.Controls.Add(this.booksSearchTextBox, 0, 0);
            booksSearchTableLayoutPanel.Controls.Add(booksSearchIconPictureBox, 1, 0);
            booksSearchTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            booksSearchTableLayoutPanel.Location = new System.Drawing.Point(1, 1);
            booksSearchTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            booksSearchTableLayoutPanel.Name = "booksSearchTableLayoutPanel";
            booksSearchTableLayoutPanel.RowCount = 1;
            booksSearchTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            booksSearchTableLayoutPanel.Size = new System.Drawing.Size(192, 24);
            booksSearchTableLayoutPanel.TabIndex = 6;
            // 
            // booksSearchTextBox
            // 
            this.booksSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.booksSearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksSearchTextBox.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.booksSearchTextBox.Location = new System.Drawing.Point(3, 1);
            this.booksSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.booksSearchTextBox.Name = "booksSearchTextBox";
            this.booksSearchTextBox.Size = new System.Drawing.Size(165, 22);
            this.booksSearchTextBox.TabIndex = 0;
            this.booksSearchTextBox.Text = "책 검색...";
            this.booksSearchTextBox.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.booksSearchTextBox.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.booksSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            this.booksSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            this.booksSearchTextBox.Leave += new System.EventHandler(this.txtSearch_Leave);
            // 
            // booksSearchIconPictureBox
            // 
            booksSearchIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            booksSearchIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            booksSearchIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            booksSearchIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Search;
            booksSearchIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            booksSearchIconPictureBox.IconSize = 24;
            booksSearchIconPictureBox.Location = new System.Drawing.Point(168, 0);
            booksSearchIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            booksSearchIconPictureBox.Name = "booksSearchIconPictureBox";
            booksSearchIconPictureBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            booksSearchIconPictureBox.Size = new System.Drawing.Size(24, 24);
            booksSearchIconPictureBox.TabIndex = 5;
            booksSearchIconPictureBox.TabStop = false;
            // 
            // booksListView
            // 
            this.booksListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.booksListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.booksListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeader4,
            this.columnHeader5});
            this.booksListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksListView.FullRowSelect = true;
            this.booksListView.GridLines = true;
            this.booksListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.booksListView.HideSelection = false;
            this.booksListView.Location = new System.Drawing.Point(1, 26);
            this.booksListView.Margin = new System.Windows.Forms.Padding(0);
            this.booksListView.Name = "booksListView";
            this.booksListView.Size = new System.Drawing.Size(192, 141);
            this.booksListView.TabIndex = 0;
            this.booksListView.TabStop = false;
            this.booksListView.UseCompatibleStateImageBehavior = false;
            this.booksListView.View = System.Windows.Forms.View.Details;
            this.booksListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lstBooks_MouseClick);
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "책 이름";
            columnHeader4.Width = 98;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "약자";
            this.columnHeader5.Width = 64;
            // 
            // versesTableLayoutPanel
            // 
            versesTableLayoutPanel.ColumnCount = 2;
            versesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            versesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            versesTableLayoutPanel.Controls.Add(versesIconPictureBox, 0, 0);
            versesTableLayoutPanel.Controls.Add(versesLabel, 1, 0);
            versesTableLayoutPanel.Location = new System.Drawing.Point(0, 178);
            versesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            versesTableLayoutPanel.Name = "versesTableLayoutPanel";
            versesTableLayoutPanel.RowCount = 1;
            versesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            versesTableLayoutPanel.Size = new System.Drawing.Size(194, 24);
            versesTableLayoutPanel.TabIndex = 8;
            // 
            // versesIconPictureBox
            // 
            versesIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            versesIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            versesIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            versesIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.QuoteLeft;
            versesIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            versesIconPictureBox.IconSize = 24;
            versesIconPictureBox.Location = new System.Drawing.Point(0, 0);
            versesIconPictureBox.Margin = new System.Windows.Forms.Padding(0);
            versesIconPictureBox.Name = "versesIconPictureBox";
            versesIconPictureBox.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            versesIconPictureBox.Size = new System.Drawing.Size(24, 24);
            versesIconPictureBox.TabIndex = 5;
            versesIconPictureBox.TabStop = false;
            // 
            // versesLabel
            // 
            versesLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            versesLabel.AutoSize = true;
            versesLabel.Location = new System.Drawing.Point(24, 6);
            versesLabel.Margin = new System.Windows.Forms.Padding(0);
            versesLabel.Name = "versesLabel";
            versesLabel.Size = new System.Drawing.Size(57, 12);
            versesLabel.TabIndex = 7;
            versesLabel.Text = "성경 구절";
            // 
            // historyMultiPanelPage
            // 
            this.historyMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.historyMultiPanelPage.Name = "historyMultiPanelPage";
            this.historyMultiPanelPage.Size = new System.Drawing.Size(479, 319);
            this.historyMultiPanelPage.TabIndex = 0;
            this.historyMultiPanelPage.Text = "PPT 제작 기록";
            // 
            // templatesMultiPanelPage
            // 
            this.templatesMultiPanelPage.Controls.Add(this.btnGithub);
            this.templatesMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templatesMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.templatesMultiPanelPage.Name = "templatesMultiPanelPage";
            this.templatesMultiPanelPage.Size = new System.Drawing.Size(492, 335);
            this.templatesMultiPanelPage.TabIndex = 0;
            this.templatesMultiPanelPage.Text = "템플릿 관리";
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
            // settingsMultiPanelPage
            // 
            this.settingsMultiPanelPage.Controls.Add(this.chkUseCache);
            this.settingsMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.settingsMultiPanelPage.Name = "settingsMultiPanelPage";
            this.settingsMultiPanelPage.Size = new System.Drawing.Size(479, 319);
            this.settingsMultiPanelPage.TabIndex = 0;
            this.settingsMultiPanelPage.Text = "설정";
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
            // builderStatusStrip
            // 
            builderStatusStrip.BackColor = System.Drawing.SystemColors.Control;
            mainTableLayoutPanel.SetColumnSpan(builderStatusStrip, 2);
            builderStatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            builderStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.builderToolStripStatusLabel,
            this.builderToolStripProgressBar});
            builderStatusStrip.Location = new System.Drawing.Point(0, 312);
            builderStatusStrip.Name = "builderStatusStrip";
            builderStatusStrip.Size = new System.Drawing.Size(509, 23);
            builderStatusStrip.TabIndex = 3;
            // 
            // builderToolStripStatusLabel
            // 
            this.builderToolStripStatusLabel.Name = "builderToolStripStatusLabel";
            this.builderToolStripStatusLabel.Size = new System.Drawing.Size(494, 18);
            this.builderToolStripStatusLabel.Spring = true;
            this.builderToolStripStatusLabel.Text = "준비";
            this.builderToolStripStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // builderToolStripProgressBar
            // 
            this.builderToolStripProgressBar.Name = "builderToolStripProgressBar";
            this.builderToolStripProgressBar.Size = new System.Drawing.Size(100, 17);
            this.builderToolStripProgressBar.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(509, 335);
            this.Controls.Add(mainTableLayoutPanel);
            this.Name = "MainForm";
            this.Text = "성경2PPT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            mainTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.PerformLayout();
            navBottomFlowLayoutPanel.ResumeLayout(false);
            navTopFlowLayoutPanel.ResumeLayout(false);
            this.mainMultiPanel.ResumeLayout(false);
            this.buildMultiPanelPage.ResumeLayout(false);
            this.buildSplitContainer.Panel1.ResumeLayout(false);
            this.buildSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buildSplitContainer)).EndInit();
            this.buildSplitContainer.ResumeLayout(false);
            this.buildLeftTableLayoutPanel.ResumeLayout(false);
            biblesTableLayoutPanel.ResumeLayout(false);
            biblesButtonTableLayoutPanel.ResumeLayout(false);
            bibleTableLayoutPanel.ResumeLayout(false);
            bibleTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(bibleIconPictureBox)).EndInit();
            sourceTableLayoutPanel.ResumeLayout(false);
            sourceTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(sourceIconPictureBox)).EndInit();
            templateBookAbbrTableLayoutPanel.ResumeLayout(false);
            templateBookAbbrTableLayoutPanel.PerformLayout();
            templateChaperNumberTableLayoutPanel.ResumeLayout(false);
            templateChaperNumberTableLayoutPanel.PerformLayout();
            templateTableLayoutPanel.ResumeLayout(false);
            templateTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(templateIconPictureBox)).EndInit();
            templateBookNameTableLayoutPanel.ResumeLayout(false);
            templateBookNameTableLayoutPanel.PerformLayout();
            this.buildRightTableLayoutPanel.ResumeLayout(false);
            this.buildRightTableLayoutPanel.PerformLayout();
            booksTableLayoutPanel.ResumeLayout(false);
            booksSearchTableLayoutPanel.ResumeLayout(false);
            booksSearchTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(booksSearchIconPictureBox)).EndInit();
            versesTableLayoutPanel.ResumeLayout(false);
            versesTableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(versesIconPictureBox)).EndInit();
            this.templatesMultiPanelPage.ResumeLayout(false);
            this.settingsMultiPanelPage.ResumeLayout(false);
            this.settingsMultiPanelPage.PerformLayout();
            builderStatusStrip.ResumeLayout(false);
            builderStatusStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox templateBookAbbrComboBox;
        private System.Windows.Forms.Button templateEditButton;
        private System.Windows.Forms.TextBox versesTextBox;
        private System.Windows.Forms.ComboBox templateChaperNumberComboBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.ComboBox templateBookNameComboBox;
        private System.Windows.Forms.ListView booksListView;
        private System.Windows.Forms.TextBox booksSearchTextBox;
        private System.Windows.Forms.CheckBox buildFragmentCheckBox;
        private System.Windows.Forms.Button btnGithub;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.ComboBox bibleComboBox;
        private System.Windows.Forms.CheckBox chkUseCache;
        private FontAwesome.Sharp.IconButton buildNav;
        private MultiPanel mainMultiPanel;
        private MultiPanelPage historyMultiPanelPage;
        private MultiPanelPage templatesMultiPanelPage;
        private MultiPanelPage settingsMultiPanelPage;
        private FontAwesome.Sharp.IconButton historyNav;
        private FontAwesome.Sharp.IconButton settingsNav;
        private FontAwesome.Sharp.IconButton templatesNav;
        private MultiPanelPage buildMultiPanelPage;
        private System.Windows.Forms.Label templateLabel;
        private FontAwesome.Sharp.IconButton biblesRemoveIconButton;
        private FontAwesome.Sharp.IconButton biblesAddIconButton;
        private FontAwesome.Sharp.IconButton biblesDownIconButton;
        private FontAwesome.Sharp.IconButton biblesUpIconButton;
        private System.Windows.Forms.ListView biblesListView;
        private System.Windows.Forms.SplitContainer buildSplitContainer;
        private System.Windows.Forms.TableLayoutPanel buildLeftTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel buildRightTableLayoutPanel;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripStatusLabel builderToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar builderToolStripProgressBar;
    }
}

