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
            System.Windows.Forms.FlowLayoutPanel navTopFlowLayoutPanel;
            System.Windows.Forms.StatusStrip builderStatusStrip;
            System.Windows.Forms.TableLayoutPanel numberOfVerseLinesPerSlideTableLayoutPanel;
            System.Windows.Forms.Label numberOfVerseLinesPerSlideLabel;
            System.Windows.Forms.TableLayoutPanel biblesTableLayoutPanel;
            System.Windows.Forms.TableLayoutPanel biblesButtonTableLayoutPanel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
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
            System.Windows.Forms.Label templateLabel;
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
            System.Windows.Forms.TableLayoutPanel historyTableLayoutPanel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.FlowLayoutPanel historyFlowLayoutPanel;
            System.Windows.Forms.FlowLayoutPanel navBottomFlowLayoutPanel;
            this.buildNavButton = new FontAwesome.Sharp.IconButton();
            this.historyNavButton = new FontAwesome.Sharp.IconButton();
            this.templatesNavButton = new FontAwesome.Sharp.IconButton();
            this.builderToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.builderToolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.mainMultiPanel = new Bible2PPT.Controls.MultiPanel();
            this.buildMultiPanelPage = new Bible2PPT.Controls.MultiPanelPage();
            this.buildSplitContainer = new System.Windows.Forms.SplitContainer();
            this.buildLeftTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.numberOfVerseLinesPerSlideComboBox = new System.Windows.Forms.ComboBox();
            this.biblesUpIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesDownIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesAddIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesRemoveIconButton = new FontAwesome.Sharp.IconButton();
            this.biblesDataGridView = new System.Windows.Forms.DataGridView();
            this.biblesSourceDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.biblesBibleDataGridViewColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bibleComboBox = new System.Windows.Forms.ComboBox();
            this.sourceComboBox = new System.Windows.Forms.ComboBox();
            this.templateBookAbbrComboBox = new System.Windows.Forms.ComboBox();
            this.templateChapterNumberComboBox = new System.Windows.Forms.ComboBox();
            this.templateEditButton = new System.Windows.Forms.Button();
            this.templateBookNameComboBox = new System.Windows.Forms.ComboBox();
            this.buildRightTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buildSplitChaptersIntoFilesCheckBox = new System.Windows.Forms.CheckBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.versesTextBox = new System.Windows.Forms.TextBox();
            this.booksSearchTextBox = new System.Windows.Forms.TextBox();
            this.booksListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.historyMultiPanelPage = new Bible2PPT.Controls.MultiPanelPage();
            this.historyDataGridView = new System.Windows.Forms.DataGridView();
            this.historyCreatedAtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyQueryStringColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyBiblesColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historySplitChaptersIntoFileColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.historyJobProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyDeleteButton = new System.Windows.Forms.Button();
            this.historyLoadButton = new System.Windows.Forms.Button();
            this.historyOpenResultButton = new System.Windows.Forms.Button();
            this.autoOpenCheckBox = new System.Windows.Forms.CheckBox();
            this.templatesMultiPanelPage = new Bible2PPT.Controls.MultiPanelPage();
            this.settingsMultiPanelPage = new Bible2PPT.Controls.MultiPanelPage();
            this.updateButton = new System.Windows.Forms.Button();
            this.cleanCacheButton = new System.Windows.Forms.Button();
            this.settingsNavButton = new FontAwesome.Sharp.IconButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            mainTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            navTopFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            builderStatusStrip = new System.Windows.Forms.StatusStrip();
            numberOfVerseLinesPerSlideTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            numberOfVerseLinesPerSlideLabel = new System.Windows.Forms.Label();
            biblesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            biblesButtonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
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
            templateLabel = new System.Windows.Forms.Label();
            templateIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            templateBookNameTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            templateBookNameLabel = new System.Windows.Forms.Label();
            booksTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            booksSearchTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            booksSearchIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            columnHeader4 = new System.Windows.Forms.ColumnHeader();
            versesTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            versesIconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            versesLabel = new System.Windows.Forms.Label();
            historyTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            historyFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            navBottomFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            mainTableLayoutPanel.SuspendLayout();
            navTopFlowLayoutPanel.SuspendLayout();
            builderStatusStrip.SuspendLayout();
            this.mainMultiPanel.SuspendLayout();
            this.buildMultiPanelPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buildSplitContainer)).BeginInit();
            this.buildSplitContainer.Panel1.SuspendLayout();
            this.buildSplitContainer.Panel2.SuspendLayout();
            this.buildSplitContainer.SuspendLayout();
            this.buildLeftTableLayoutPanel.SuspendLayout();
            numberOfVerseLinesPerSlideTableLayoutPanel.SuspendLayout();
            biblesTableLayoutPanel.SuspendLayout();
            biblesButtonTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.biblesDataGridView)).BeginInit();
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
            this.historyMultiPanelPage.SuspendLayout();
            historyTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).BeginInit();
            historyFlowLayoutPanel.SuspendLayout();
            this.settingsMultiPanelPage.SuspendLayout();
            navBottomFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTableLayoutPanel
            // 
            mainTableLayoutPanel.ColumnCount = 2;
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.Controls.Add(navTopFlowLayoutPanel, 0, 0);
            mainTableLayoutPanel.Controls.Add(builderStatusStrip, 0, 2);
            mainTableLayoutPanel.Controls.Add(this.mainMultiPanel, 1, 0);
            mainTableLayoutPanel.Controls.Add(navBottomFlowLayoutPanel, 0, 1);
            mainTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            mainTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            mainTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            mainTableLayoutPanel.Name = "mainTableLayoutPanel";
            mainTableLayoutPanel.RowCount = 3;
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            mainTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            mainTableLayoutPanel.Size = new System.Drawing.Size(509, 335);
            mainTableLayoutPanel.TabIndex = 0;
            // 
            // navTopFlowLayoutPanel
            // 
            navTopFlowLayoutPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            navTopFlowLayoutPanel.Controls.Add(this.buildNavButton);
            navTopFlowLayoutPanel.Controls.Add(this.historyNavButton);
            navTopFlowLayoutPanel.Controls.Add(this.templatesNavButton);
            navTopFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            navTopFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            navTopFlowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            navTopFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            navTopFlowLayoutPanel.Name = "navTopFlowLayoutPanel";
            navTopFlowLayoutPanel.Size = new System.Drawing.Size(48, 264);
            navTopFlowLayoutPanel.TabIndex = 0;
            // 
            // buildNavButton
            // 
            this.buildNavButton.BackColor = System.Drawing.SystemColors.Menu;
            this.buildNavButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buildNavButton.FlatAppearance.BorderSize = 0;
            this.buildNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buildNavButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.buildNavButton.IconChar = FontAwesome.Sharp.IconChar.Desktop;
            this.buildNavButton.IconColor = System.Drawing.SystemColors.MenuText;
            this.buildNavButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.buildNavButton.IconSize = 36;
            this.buildNavButton.Location = new System.Drawing.Point(0, 0);
            this.buildNavButton.Margin = new System.Windows.Forms.Padding(0);
            this.buildNavButton.Name = "buildNavButton";
            this.buildNavButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.buildNavButton.Size = new System.Drawing.Size(48, 48);
            this.buildNavButton.TabIndex = 1;
            this.toolTip.SetToolTip(this.buildNavButton, "PPT 만들기");
            this.buildNavButton.UseVisualStyleBackColor = false;
            this.buildNavButton.Click += new System.EventHandler(this.Nav_Click);
            // 
            // historyNavButton
            // 
            this.historyNavButton.BackColor = System.Drawing.SystemColors.Menu;
            this.historyNavButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.historyNavButton.FlatAppearance.BorderSize = 0;
            this.historyNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.historyNavButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.historyNavButton.IconChar = FontAwesome.Sharp.IconChar.History;
            this.historyNavButton.IconColor = System.Drawing.SystemColors.MenuText;
            this.historyNavButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.historyNavButton.IconSize = 36;
            this.historyNavButton.Location = new System.Drawing.Point(0, 48);
            this.historyNavButton.Margin = new System.Windows.Forms.Padding(0);
            this.historyNavButton.Name = "historyNavButton";
            this.historyNavButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.historyNavButton.Size = new System.Drawing.Size(48, 48);
            this.historyNavButton.TabIndex = 2;
            this.toolTip.SetToolTip(this.historyNavButton, "PPT 제작 기록");
            this.historyNavButton.UseVisualStyleBackColor = false;
            this.historyNavButton.Click += new System.EventHandler(this.Nav_Click);
            // 
            // templatesNavButton
            // 
            this.templatesNavButton.BackColor = System.Drawing.SystemColors.Menu;
            this.templatesNavButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.templatesNavButton.FlatAppearance.BorderSize = 0;
            this.templatesNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.templatesNavButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.templatesNavButton.IconChar = FontAwesome.Sharp.IconChar.Images;
            this.templatesNavButton.IconColor = System.Drawing.SystemColors.MenuText;
            this.templatesNavButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.templatesNavButton.IconSize = 36;
            this.templatesNavButton.Location = new System.Drawing.Point(0, 96);
            this.templatesNavButton.Margin = new System.Windows.Forms.Padding(0);
            this.templatesNavButton.Name = "templatesNavButton";
            this.templatesNavButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.templatesNavButton.Size = new System.Drawing.Size(48, 48);
            this.templatesNavButton.TabIndex = 3;
            this.toolTip.SetToolTip(this.templatesNavButton, "템플릿 관리");
            this.templatesNavButton.UseVisualStyleBackColor = false;
            this.templatesNavButton.Visible = false;
            this.templatesNavButton.Click += new System.EventHandler(this.Nav_Click);
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
            this.mainMultiPanel.TabIndex = 2;
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
            this.buildSplitContainer.SplitterDistance = 251;
            this.buildSplitContainer.SplitterWidth = 13;
            this.buildSplitContainer.TabIndex = 0;
            // 
            // buildLeftTableLayoutPanel
            // 
            this.buildLeftTableLayoutPanel.ColumnCount = 1;
            this.buildLeftTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buildLeftTableLayoutPanel.Controls.Add(numberOfVerseLinesPerSlideTableLayoutPanel, 0, 14);
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
            this.buildLeftTableLayoutPanel.RowCount = 15;
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
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.buildLeftTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.buildLeftTableLayoutPanel.Size = new System.Drawing.Size(238, 292);
            this.buildLeftTableLayoutPanel.TabIndex = 0;
            // 
            // numberOfVerseLinesPerSlideTableLayoutPanel
            // 
            numberOfVerseLinesPerSlideTableLayoutPanel.ColumnCount = 2;
            numberOfVerseLinesPerSlideTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            numberOfVerseLinesPerSlideTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            numberOfVerseLinesPerSlideTableLayoutPanel.Controls.Add(numberOfVerseLinesPerSlideLabel, 0, 0);
            numberOfVerseLinesPerSlideTableLayoutPanel.Controls.Add(this.numberOfVerseLinesPerSlideComboBox, 1, 0);
            numberOfVerseLinesPerSlideTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            numberOfVerseLinesPerSlideTableLayoutPanel.Location = new System.Drawing.Point(0, 271);
            numberOfVerseLinesPerSlideTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            numberOfVerseLinesPerSlideTableLayoutPanel.Name = "numberOfVerseLinesPerSlideTableLayoutPanel";
            numberOfVerseLinesPerSlideTableLayoutPanel.RowCount = 1;
            numberOfVerseLinesPerSlideTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            numberOfVerseLinesPerSlideTableLayoutPanel.Size = new System.Drawing.Size(238, 21);
            numberOfVerseLinesPerSlideTableLayoutPanel.TabIndex = 7;
            // 
            // numberOfVerseLinesPerSlideLabel
            // 
            numberOfVerseLinesPerSlideLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            numberOfVerseLinesPerSlideLabel.AutoSize = true;
            numberOfVerseLinesPerSlideLabel.Location = new System.Drawing.Point(3, 0);
            numberOfVerseLinesPerSlideLabel.Name = "numberOfVerseLinesPerSlideLabel";
            numberOfVerseLinesPerSlideLabel.Size = new System.Drawing.Size(143, 21);
            numberOfVerseLinesPerSlideLabel.TabIndex = 0;
            numberOfVerseLinesPerSlideLabel.Text = "슬라이드당 성경 구절 줄 수";
            // 
            // numberOfVerseLinesPerSlideComboBox
            // 
            this.numberOfVerseLinesPerSlideComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numberOfVerseLinesPerSlideComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.numberOfVerseLinesPerSlideComboBox.Items.AddRange(new object[] {
            "제한 없음",
            "1줄",
            "2줄",
            "3줄",
            "4줄",
            "5줄",
            "6줄",
            "7줄",
            "8줄",
            "9줄"});
            this.numberOfVerseLinesPerSlideComboBox.Location = new System.Drawing.Point(160, 0);
            this.numberOfVerseLinesPerSlideComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.numberOfVerseLinesPerSlideComboBox.Name = "numberOfVerseLinesPerSlideComboBox";
            this.numberOfVerseLinesPerSlideComboBox.Size = new System.Drawing.Size(78, 23);
            this.numberOfVerseLinesPerSlideComboBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.numberOfVerseLinesPerSlideComboBox, "성경 구절 줄 수 설정");
            this.numberOfVerseLinesPerSlideComboBox.SelectedIndexChanged += new System.EventHandler(this.NumberOfVerseLinesPerSlideComboBox_SelectedIndexChanged);
            // 
            // biblesTableLayoutPanel
            // 
            biblesTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            biblesTableLayoutPanel.ColumnCount = 1;
            biblesTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesTableLayoutPanel.Controls.Add(biblesButtonTableLayoutPanel, 0, 0);
            biblesTableLayoutPanel.Controls.Add(this.biblesDataGridView, 0, 1);
            biblesTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            biblesTableLayoutPanel.Location = new System.Drawing.Point(0, 55);
            biblesTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            biblesTableLayoutPanel.Name = "biblesTableLayoutPanel";
            biblesTableLayoutPanel.RowCount = 2;
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            biblesTableLayoutPanel.Size = new System.Drawing.Size(238, 104);
            biblesTableLayoutPanel.TabIndex = 2;
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
            biblesButtonTableLayoutPanel.Location = new System.Drawing.Point(1, 1);
            biblesButtonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            biblesButtonTableLayoutPanel.Name = "biblesButtonTableLayoutPanel";
            biblesButtonTableLayoutPanel.RowCount = 1;
            biblesButtonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            biblesButtonTableLayoutPanel.Size = new System.Drawing.Size(236, 24);
            biblesButtonTableLayoutPanel.TabIndex = 0;
            // 
            // biblesUpIconButton
            // 
            this.biblesUpIconButton.IconChar = FontAwesome.Sharp.IconChar.AngleUp;
            this.biblesUpIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesUpIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.biblesUpIconButton.IconSize = 16;
            this.biblesUpIconButton.Location = new System.Drawing.Point(0, 0);
            this.biblesUpIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesUpIconButton.Name = "biblesUpIconButton";
            this.biblesUpIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesUpIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesUpIconButton.TabIndex = 0;
            this.biblesUpIconButton.UseVisualStyleBackColor = true;
            this.biblesUpIconButton.Click += new System.EventHandler(this.BiblesUpIconButton_Click);
            // 
            // biblesDownIconButton
            // 
            this.biblesDownIconButton.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.biblesDownIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesDownIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.biblesDownIconButton.IconSize = 16;
            this.biblesDownIconButton.Location = new System.Drawing.Point(24, 0);
            this.biblesDownIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesDownIconButton.Name = "biblesDownIconButton";
            this.biblesDownIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesDownIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesDownIconButton.TabIndex = 1;
            this.biblesDownIconButton.UseVisualStyleBackColor = true;
            this.biblesDownIconButton.Click += new System.EventHandler(this.BiblesDownIconButton_Click);
            // 
            // biblesAddIconButton
            // 
            this.biblesAddIconButton.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.biblesAddIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesAddIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.biblesAddIconButton.IconSize = 16;
            this.biblesAddIconButton.Location = new System.Drawing.Point(188, 0);
            this.biblesAddIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesAddIconButton.Name = "biblesAddIconButton";
            this.biblesAddIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesAddIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesAddIconButton.TabIndex = 2;
            this.biblesAddIconButton.UseVisualStyleBackColor = true;
            this.biblesAddIconButton.Click += new System.EventHandler(this.BiblesAddIconButton_Click);
            // 
            // biblesRemoveIconButton
            // 
            this.biblesRemoveIconButton.IconChar = FontAwesome.Sharp.IconChar.Minus;
            this.biblesRemoveIconButton.IconColor = System.Drawing.SystemColors.ControlText;
            this.biblesRemoveIconButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.biblesRemoveIconButton.IconSize = 16;
            this.biblesRemoveIconButton.Location = new System.Drawing.Point(212, 0);
            this.biblesRemoveIconButton.Margin = new System.Windows.Forms.Padding(0);
            this.biblesRemoveIconButton.Name = "biblesRemoveIconButton";
            this.biblesRemoveIconButton.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.biblesRemoveIconButton.Size = new System.Drawing.Size(24, 24);
            this.biblesRemoveIconButton.TabIndex = 3;
            this.biblesRemoveIconButton.UseVisualStyleBackColor = true;
            this.biblesRemoveIconButton.Click += new System.EventHandler(this.BiblesRemoveIconButton_Click);
            // 
            // biblesDataGridView
            // 
            this.biblesDataGridView.AllowUserToAddRows = false;
            this.biblesDataGridView.AllowUserToDeleteRows = false;
            this.biblesDataGridView.AllowUserToResizeRows = false;
            this.biblesDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.biblesDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.biblesDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.biblesDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.biblesDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.biblesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.biblesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.biblesSourceDataGridViewColumn,
            this.biblesBibleDataGridViewColumn});
            this.biblesDataGridView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.biblesDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.biblesDataGridView.Location = new System.Drawing.Point(1, 26);
            this.biblesDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.biblesDataGridView.MultiSelect = false;
            this.biblesDataGridView.Name = "biblesDataGridView";
            this.biblesDataGridView.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.biblesDataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.biblesDataGridView.RowHeadersWidth = 30;
            this.biblesDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.biblesDataGridView.RowTemplate.Height = 18;
            this.biblesDataGridView.RowTemplate.ReadOnly = true;
            this.biblesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.biblesDataGridView.Size = new System.Drawing.Size(236, 77);
            this.biblesDataGridView.StandardTab = true;
            this.biblesDataGridView.TabIndex = 1;
            this.biblesDataGridView.CurrentCellChanged += new System.EventHandler(this.BiblesDataGridView_CurrentCellChanged);
            this.biblesDataGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.BiblesDataGridView_RowPostPaint);
            // 
            // biblesSourceDataGridViewColumn
            // 
            this.biblesSourceDataGridViewColumn.HeaderText = "소스";
            this.biblesSourceDataGridViewColumn.Name = "biblesSourceDataGridViewColumn";
            this.biblesSourceDataGridViewColumn.ReadOnly = true;
            // 
            // biblesBibleDataGridViewColumn
            // 
            this.biblesBibleDataGridViewColumn.HeaderText = "성경";
            this.biblesBibleDataGridViewColumn.Name = "biblesBibleDataGridViewColumn";
            this.biblesBibleDataGridViewColumn.ReadOnly = true;
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
            bibleTableLayoutPanel.Size = new System.Drawing.Size(238, 24);
            bibleTableLayoutPanel.TabIndex = 1;
            // 
            // bibleComboBox
            // 
            this.bibleComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bibleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bibleComboBox.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bibleComboBox.FormattingEnabled = true;
            this.bibleComboBox.Location = new System.Drawing.Point(64, 2);
            this.bibleComboBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.bibleComboBox.Name = "bibleComboBox";
            this.bibleComboBox.Size = new System.Drawing.Size(174, 20);
            this.bibleComboBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.bibleComboBox, "성경 선택");
            this.bibleComboBox.SelectedValueChanged += new System.EventHandler(this.BibleComboBox_SelectedValueChanged);
            // 
            // bibleIconPictureBox
            // 
            bibleIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            bibleIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            bibleIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            bibleIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Bible;
            bibleIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            bibleIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
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
            bibleLabel.Location = new System.Drawing.Point(24, 4);
            bibleLabel.Margin = new System.Windows.Forms.Padding(0);
            bibleLabel.Name = "bibleLabel";
            bibleLabel.Size = new System.Drawing.Size(31, 15);
            bibleLabel.TabIndex = 0;
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
            sourceTableLayoutPanel.Size = new System.Drawing.Size(238, 24);
            sourceTableLayoutPanel.TabIndex = 0;
            // 
            // sourceLabel
            // 
            sourceLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            sourceLabel.AutoSize = true;
            sourceLabel.Location = new System.Drawing.Point(24, 4);
            sourceLabel.Margin = new System.Windows.Forms.Padding(0);
            sourceLabel.Name = "sourceLabel";
            sourceLabel.Size = new System.Drawing.Size(31, 15);
            sourceLabel.TabIndex = 0;
            sourceLabel.Text = "소스";
            // 
            // sourceComboBox
            // 
            this.sourceComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sourceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sourceComboBox.Location = new System.Drawing.Point(64, 2);
            this.sourceComboBox.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.sourceComboBox.Name = "sourceComboBox";
            this.sourceComboBox.Size = new System.Drawing.Size(174, 23);
            this.sourceComboBox.TabIndex = 1;
            this.sourceComboBox.SelectedValueChanged += new System.EventHandler(this.SourceComboBox_SelectedValueChanged);
            // 
            // sourceIconPictureBox
            // 
            sourceIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            sourceIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            sourceIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            sourceIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Database;
            sourceIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            sourceIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
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
            templateBookAbbrTableLayoutPanel.Location = new System.Drawing.Point(0, 221);
            templateBookAbbrTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateBookAbbrTableLayoutPanel.Name = "templateBookAbbrTableLayoutPanel";
            templateBookAbbrTableLayoutPanel.RowCount = 1;
            templateBookAbbrTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookAbbrTableLayoutPanel.Size = new System.Drawing.Size(238, 21);
            templateBookAbbrTableLayoutPanel.TabIndex = 5;
            // 
            // templateBookAbbrLabel
            // 
            templateBookAbbrLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateBookAbbrLabel.AutoSize = true;
            templateBookAbbrLabel.Location = new System.Drawing.Point(3, 3);
            templateBookAbbrLabel.Name = "templateBookAbbrLabel";
            templateBookAbbrLabel.Size = new System.Drawing.Size(31, 15);
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
            this.templateBookAbbrComboBox.Size = new System.Drawing.Size(178, 23);
            this.templateBookAbbrComboBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.templateBookAbbrComboBox, "약자 표시 설정");
            this.templateBookAbbrComboBox.SelectedIndexChanged += new System.EventHandler(this.TemplateBookAbbrComboBox_SelectedIndexChanged);
            // 
            // templateChaperNumberTableLayoutPanel
            // 
            templateChaperNumberTableLayoutPanel.ColumnCount = 2;
            templateChaperNumberTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateChaperNumberTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateChaperNumberTableLayoutPanel.Controls.Add(templateChaperNumberLabel, 0, 0);
            templateChaperNumberTableLayoutPanel.Controls.Add(this.templateChapterNumberComboBox, 1, 0);
            templateChaperNumberTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateChaperNumberTableLayoutPanel.Location = new System.Drawing.Point(0, 246);
            templateChaperNumberTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateChaperNumberTableLayoutPanel.Name = "templateChaperNumberTableLayoutPanel";
            templateChaperNumberTableLayoutPanel.RowCount = 1;
            templateChaperNumberTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateChaperNumberTableLayoutPanel.Size = new System.Drawing.Size(238, 21);
            templateChaperNumberTableLayoutPanel.TabIndex = 6;
            // 
            // templateChaperNumberLabel
            // 
            templateChaperNumberLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateChaperNumberLabel.AutoSize = true;
            templateChaperNumberLabel.Location = new System.Drawing.Point(3, 3);
            templateChaperNumberLabel.Name = "templateChaperNumberLabel";
            templateChaperNumberLabel.Size = new System.Drawing.Size(47, 15);
            templateChaperNumberLabel.TabIndex = 0;
            templateChaperNumberLabel.Text = "장 번호";
            // 
            // templateChapterNumberComboBox
            // 
            this.templateChapterNumberComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templateChapterNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.templateChapterNumberComboBox.Items.AddRange(new object[] {
            "항상 보이기",
            "각 장의 첫 절에만 보이기"});
            this.templateChapterNumberComboBox.Location = new System.Drawing.Point(60, 0);
            this.templateChapterNumberComboBox.Margin = new System.Windows.Forms.Padding(0);
            this.templateChapterNumberComboBox.Name = "templateChapterNumberComboBox";
            this.templateChapterNumberComboBox.Size = new System.Drawing.Size(178, 23);
            this.templateChapterNumberComboBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.templateChapterNumberComboBox, "장 번호 표시 설정");
            this.templateChapterNumberComboBox.SelectedIndexChanged += new System.EventHandler(this.TemplateChapterNumberComboBox_SelectedIndexChanged);
            // 
            // templateTableLayoutPanel
            // 
            templateTableLayoutPanel.ColumnCount = 3;
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateTableLayoutPanel.Controls.Add(templateLabel, 1, 0);
            templateTableLayoutPanel.Controls.Add(templateIconPictureBox, 0, 0);
            templateTableLayoutPanel.Controls.Add(this.templateEditButton, 2, 0);
            templateTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateTableLayoutPanel.Location = new System.Drawing.Point(0, 169);
            templateTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateTableLayoutPanel.Name = "templateTableLayoutPanel";
            templateTableLayoutPanel.RowCount = 1;
            templateTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateTableLayoutPanel.Size = new System.Drawing.Size(238, 24);
            templateTableLayoutPanel.TabIndex = 3;
            // 
            // templateLabel
            // 
            templateLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateLabel.AutoSize = true;
            templateLabel.Location = new System.Drawing.Point(24, 4);
            templateLabel.Margin = new System.Windows.Forms.Padding(0);
            templateLabel.Name = "templateLabel";
            templateLabel.Size = new System.Drawing.Size(43, 15);
            templateLabel.TabIndex = 0;
            templateLabel.Text = "템플릿";
            // 
            // templateIconPictureBox
            // 
            templateIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            templateIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            templateIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Image;
            templateIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            templateIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
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
            this.templateEditButton.Size = new System.Drawing.Size(154, 24);
            this.templateEditButton.TabIndex = 1;
            this.templateEditButton.Text = "템플릿 편집하기";
            this.templateEditButton.UseVisualStyleBackColor = true;
            this.templateEditButton.Click += new System.EventHandler(this.TemplateEditButton_Click);
            this.templateEditButton.MouseHover += new System.EventHandler(this.TemplateEditButton_MouseHover);
            // 
            // templateBookNameTableLayoutPanel
            // 
            templateBookNameTableLayoutPanel.ColumnCount = 2;
            templateBookNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            templateBookNameTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookNameTableLayoutPanel.Controls.Add(templateBookNameLabel, 0, 0);
            templateBookNameTableLayoutPanel.Controls.Add(this.templateBookNameComboBox, 1, 0);
            templateBookNameTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            templateBookNameTableLayoutPanel.Location = new System.Drawing.Point(0, 196);
            templateBookNameTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            templateBookNameTableLayoutPanel.Name = "templateBookNameTableLayoutPanel";
            templateBookNameTableLayoutPanel.RowCount = 1;
            templateBookNameTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            templateBookNameTableLayoutPanel.Size = new System.Drawing.Size(238, 21);
            templateBookNameTableLayoutPanel.TabIndex = 4;
            // 
            // templateBookNameLabel
            // 
            templateBookNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            templateBookNameLabel.AutoSize = true;
            templateBookNameLabel.Location = new System.Drawing.Point(3, 3);
            templateBookNameLabel.Name = "templateBookNameLabel";
            templateBookNameLabel.Size = new System.Drawing.Size(47, 15);
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
            this.templateBookNameComboBox.Size = new System.Drawing.Size(178, 23);
            this.templateBookNameComboBox.TabIndex = 1;
            this.toolTip.SetToolTip(this.templateBookNameComboBox, "책 이름 표시 설정");
            this.templateBookNameComboBox.SelectedIndexChanged += new System.EventHandler(this.TemplateBookNameComboBox_SelectedIndexChanged);
            // 
            // buildRightTableLayoutPanel
            // 
            this.buildRightTableLayoutPanel.ColumnCount = 1;
            this.buildRightTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.buildRightTableLayoutPanel.Controls.Add(this.buildSplitChaptersIntoFilesCheckBox, 0, 5);
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
            this.buildRightTableLayoutPanel.Size = new System.Drawing.Size(184, 292);
            this.buildRightTableLayoutPanel.TabIndex = 0;
            // 
            // buildSplitChaptersIntoFilesCheckBox
            // 
            this.buildSplitChaptersIntoFilesCheckBox.AutoSize = true;
            this.buildSplitChaptersIntoFilesCheckBox.Location = new System.Drawing.Point(3, 244);
            this.buildSplitChaptersIntoFilesCheckBox.Name = "buildSplitChaptersIntoFilesCheckBox";
            this.buildSplitChaptersIntoFilesCheckBox.Size = new System.Drawing.Size(126, 16);
            this.buildSplitChaptersIntoFilesCheckBox.TabIndex = 2;
            this.buildSplitChaptersIntoFilesCheckBox.Text = "장별로 PPT 나누기";
            this.buildSplitChaptersIntoFilesCheckBox.UseVisualStyleBackColor = true;
            this.buildSplitChaptersIntoFilesCheckBox.CheckedChanged += new System.EventHandler(this.BuildFragmentCheckBox_CheckedChanged);
            // 
            // buildButton
            // 
            this.buildButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buildButton.Location = new System.Drawing.Point(0, 263);
            this.buildButton.Margin = new System.Windows.Forms.Padding(0);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(184, 29);
            this.buildButton.TabIndex = 3;
            this.buildButton.Text = "PPT 만들기";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // versesTextBox
            // 
            this.versesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.versesTextBox.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.versesTextBox.Location = new System.Drawing.Point(0, 202);
            this.versesTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.versesTextBox.Name = "versesTextBox";
            this.versesTextBox.Size = new System.Drawing.Size(184, 29);
            this.versesTextBox.TabIndex = 1;
            this.versesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.VersesTextBox_KeyPress);
            this.versesTextBox.MouseHover += new System.EventHandler(this.VersesTextBox_MouseHover);
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
            booksTableLayoutPanel.Size = new System.Drawing.Size(184, 168);
            booksTableLayoutPanel.TabIndex = 0;
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
            booksSearchTableLayoutPanel.Size = new System.Drawing.Size(182, 24);
            booksSearchTableLayoutPanel.TabIndex = 0;
            // 
            // booksSearchTextBox
            // 
            this.booksSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.booksSearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.booksSearchTextBox.Font = new System.Drawing.Font("Gulim", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.booksSearchTextBox.Location = new System.Drawing.Point(3, 1);
            this.booksSearchTextBox.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.booksSearchTextBox.Name = "booksSearchTextBox";
            this.booksSearchTextBox.Size = new System.Drawing.Size(155, 22);
            this.booksSearchTextBox.TabIndex = 0;
            this.booksSearchTextBox.Text = "책 검색...";
            this.booksSearchTextBox.TextChanged += new System.EventHandler(this.BooksSearchTextBox_TextChanged);
            this.booksSearchTextBox.Enter += new System.EventHandler(this.BooksSearchTextBox_Enter);
            this.booksSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BooksSearchTextBox_KeyDown);
            this.booksSearchTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.BooksSearchTextBox_KeyPress);
            this.booksSearchTextBox.Leave += new System.EventHandler(this.BooksSearchTextBox_Leave);
            // 
            // booksSearchIconPictureBox
            // 
            booksSearchIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            booksSearchIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            booksSearchIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            booksSearchIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Search;
            booksSearchIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            booksSearchIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            booksSearchIconPictureBox.IconSize = 24;
            booksSearchIconPictureBox.Location = new System.Drawing.Point(158, 0);
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
            this.booksListView.Location = new System.Drawing.Point(1, 26);
            this.booksListView.Margin = new System.Windows.Forms.Padding(0);
            this.booksListView.Name = "booksListView";
            this.booksListView.Size = new System.Drawing.Size(182, 141);
            this.booksListView.TabIndex = 1;
            this.booksListView.TabStop = false;
            this.booksListView.UseCompatibleStateImageBehavior = false;
            this.booksListView.View = System.Windows.Forms.View.Details;
            this.booksListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.BooksListView_MouseClick);
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
            versesTableLayoutPanel.Size = new System.Drawing.Size(159, 24);
            versesTableLayoutPanel.TabIndex = 8;
            // 
            // versesIconPictureBox
            // 
            versesIconPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            versesIconPictureBox.BackColor = System.Drawing.SystemColors.Window;
            versesIconPictureBox.ForeColor = System.Drawing.SystemColors.ControlText;
            versesIconPictureBox.IconChar = FontAwesome.Sharp.IconChar.QuoteLeft;
            versesIconPictureBox.IconColor = System.Drawing.SystemColors.ControlText;
            versesIconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
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
            versesLabel.Location = new System.Drawing.Point(24, 4);
            versesLabel.Margin = new System.Windows.Forms.Padding(0);
            versesLabel.Name = "versesLabel";
            versesLabel.Size = new System.Drawing.Size(59, 15);
            versesLabel.TabIndex = 0;
            versesLabel.Text = "성경 구절";
            // 
            // historyMultiPanelPage
            // 
            this.historyMultiPanelPage.Controls.Add(historyTableLayoutPanel);
            this.historyMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.historyMultiPanelPage.Name = "historyMultiPanelPage";
            this.historyMultiPanelPage.Size = new System.Drawing.Size(461, 312);
            this.historyMultiPanelPage.TabIndex = 0;
            this.historyMultiPanelPage.Text = "PPT 제작 기록";
            // 
            // historyTableLayoutPanel
            // 
            historyTableLayoutPanel.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            historyTableLayoutPanel.ColumnCount = 1;
            historyTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            historyTableLayoutPanel.Controls.Add(this.historyDataGridView, 0, 1);
            historyTableLayoutPanel.Controls.Add(historyFlowLayoutPanel, 0, 0);
            historyTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            historyTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            historyTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            historyTableLayoutPanel.Name = "historyTableLayoutPanel";
            historyTableLayoutPanel.Padding = new System.Windows.Forms.Padding(13, 10, 13, 10);
            historyTableLayoutPanel.RowCount = 2;
            historyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            historyTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            historyTableLayoutPanel.Size = new System.Drawing.Size(461, 312);
            historyTableLayoutPanel.TabIndex = 0;
            // 
            // historyDataGridView
            // 
            this.historyDataGridView.AllowUserToAddRows = false;
            this.historyDataGridView.AllowUserToDeleteRows = false;
            this.historyDataGridView.AllowUserToOrderColumns = true;
            this.historyDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.historyDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.historyDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.historyDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.historyDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.historyCreatedAtColumn,
            this.historyQueryStringColumn,
            this.historyBiblesColumn,
            this.historySplitChaptersIntoFileColumn,
            this.historyJobProgress});
            this.historyDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyDataGridView.Location = new System.Drawing.Point(14, 36);
            this.historyDataGridView.Margin = new System.Windows.Forms.Padding(0);
            this.historyDataGridView.Name = "historyDataGridView";
            this.historyDataGridView.ReadOnly = true;
            this.historyDataGridView.RowHeadersVisible = false;
            this.historyDataGridView.RowTemplate.Height = 23;
            this.historyDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyDataGridView.Size = new System.Drawing.Size(433, 265);
            this.historyDataGridView.StandardTab = true;
            this.historyDataGridView.TabIndex = 0;
            this.historyDataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.HistoryDataGridView_CellFormatting);
            // 
            // historyCreatedAtColumn
            // 
            this.historyCreatedAtColumn.HeaderText = "만든 날짜";
            this.historyCreatedAtColumn.Name = "historyCreatedAtColumn";
            this.historyCreatedAtColumn.ReadOnly = true;
            this.historyCreatedAtColumn.Width = 80;
            // 
            // historyQueryStringColumn
            // 
            this.historyQueryStringColumn.HeaderText = "구절";
            this.historyQueryStringColumn.Name = "historyQueryStringColumn";
            this.historyQueryStringColumn.ReadOnly = true;
            this.historyQueryStringColumn.Width = 70;
            // 
            // historyBiblesColumn
            // 
            this.historyBiblesColumn.HeaderText = "성경";
            this.historyBiblesColumn.Name = "historyBiblesColumn";
            this.historyBiblesColumn.ReadOnly = true;
            this.historyBiblesColumn.Width = 130;
            // 
            // historySplitChaptersIntoFileColumn
            // 
            this.historySplitChaptersIntoFileColumn.HeaderText = "장별로 나누기";
            this.historySplitChaptersIntoFileColumn.Name = "historySplitChaptersIntoFileColumn";
            this.historySplitChaptersIntoFileColumn.ReadOnly = true;
            this.historySplitChaptersIntoFileColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.historySplitChaptersIntoFileColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.historySplitChaptersIntoFileColumn.Width = 24;
            // 
            // historyJobProgress
            // 
            this.historyJobProgress.HeaderText = "상태";
            this.historyJobProgress.Name = "historyJobProgress";
            this.historyJobProgress.ReadOnly = true;
            // 
            // historyFlowLayoutPanel
            // 
            historyFlowLayoutPanel.Controls.Add(this.historyDeleteButton);
            historyFlowLayoutPanel.Controls.Add(this.historyLoadButton);
            historyFlowLayoutPanel.Controls.Add(this.historyOpenResultButton);
            historyFlowLayoutPanel.Controls.Add(this.autoOpenCheckBox);
            historyFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            historyFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            historyFlowLayoutPanel.Location = new System.Drawing.Point(14, 11);
            historyFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            historyFlowLayoutPanel.Name = "historyFlowLayoutPanel";
            historyFlowLayoutPanel.Size = new System.Drawing.Size(433, 24);
            historyFlowLayoutPanel.TabIndex = 1;
            // 
            // historyDeleteButton
            // 
            this.historyDeleteButton.Location = new System.Drawing.Point(358, 0);
            this.historyDeleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.historyDeleteButton.Name = "historyDeleteButton";
            this.historyDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.historyDeleteButton.TabIndex = 2;
            this.historyDeleteButton.Text = "삭제";
            this.historyDeleteButton.UseVisualStyleBackColor = true;
            this.historyDeleteButton.Click += new System.EventHandler(this.HistoryDeleteButton_Click);
            // 
            // historyLoadButton
            // 
            this.historyLoadButton.Location = new System.Drawing.Point(283, 0);
            this.historyLoadButton.Margin = new System.Windows.Forms.Padding(0);
            this.historyLoadButton.Name = "historyLoadButton";
            this.historyLoadButton.Size = new System.Drawing.Size(75, 23);
            this.historyLoadButton.TabIndex = 1;
            this.historyLoadButton.Text = "불러오기";
            this.historyLoadButton.UseVisualStyleBackColor = true;
            this.historyLoadButton.Click += new System.EventHandler(this.HistoryLoadButton_Click);
            // 
            // historyOpenResultButton
            // 
            this.historyOpenResultButton.Location = new System.Drawing.Point(208, 0);
            this.historyOpenResultButton.Margin = new System.Windows.Forms.Padding(0);
            this.historyOpenResultButton.Name = "historyOpenResultButton";
            this.historyOpenResultButton.Size = new System.Drawing.Size(75, 23);
            this.historyOpenResultButton.TabIndex = 0;
            this.historyOpenResultButton.Text = "열기";
            this.historyOpenResultButton.UseVisualStyleBackColor = true;
            this.historyOpenResultButton.Click += new System.EventHandler(this.HistoryOpenResultButton_Click);
            // 
            // autoOpenCheckBox
            // 
            this.autoOpenCheckBox.AutoSize = true;
            this.autoOpenCheckBox.Checked = true;
            this.autoOpenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoOpenCheckBox.Location = new System.Drawing.Point(83, 3);
            this.autoOpenCheckBox.Name = "autoOpenCheckBox";
            this.autoOpenCheckBox.Size = new System.Drawing.Size(122, 19);
            this.autoOpenCheckBox.TabIndex = 3;
            this.autoOpenCheckBox.Text = "완료 후 자동 열기";
            this.autoOpenCheckBox.UseVisualStyleBackColor = true;
            this.autoOpenCheckBox.CheckedChanged += new System.EventHandler(this.AutoOpenCheckBox_CheckedChanged);
            // 
            // templatesMultiPanelPage
            // 
            this.templatesMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.templatesMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.templatesMultiPanelPage.Name = "templatesMultiPanelPage";
            this.templatesMultiPanelPage.Size = new System.Drawing.Size(461, 312);
            this.templatesMultiPanelPage.TabIndex = 0;
            this.templatesMultiPanelPage.Text = "템플릿 관리";
            // 
            // settingsMultiPanelPage
            // 
            this.settingsMultiPanelPage.Controls.Add(this.updateButton);
            this.settingsMultiPanelPage.Controls.Add(this.cleanCacheButton);
            this.settingsMultiPanelPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.settingsMultiPanelPage.Location = new System.Drawing.Point(0, 0);
            this.settingsMultiPanelPage.Name = "settingsMultiPanelPage";
            this.settingsMultiPanelPage.Size = new System.Drawing.Size(461, 312);
            this.settingsMultiPanelPage.TabIndex = 0;
            this.settingsMultiPanelPage.Text = "설정";
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(25, 72);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(102, 35);
            this.updateButton.TabIndex = 4;
            this.updateButton.Text = "업데이트 확인";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // cleanCacheButton
            // 
            this.cleanCacheButton.Location = new System.Drawing.Point(25, 24);
            this.cleanCacheButton.Name = "cleanCacheButton";
            this.cleanCacheButton.Size = new System.Drawing.Size(102, 34);
            this.cleanCacheButton.TabIndex = 3;
            this.cleanCacheButton.Text = "캐시 지우기";
            this.cleanCacheButton.UseVisualStyleBackColor = true;
            this.cleanCacheButton.Click += new System.EventHandler(this.CleanCacheButton_Click);
            // 
            // navBottomFlowLayoutPanel
            // 
            navBottomFlowLayoutPanel.BackColor = System.Drawing.SystemColors.MenuBar;
            navBottomFlowLayoutPanel.Controls.Add(this.settingsNavButton);
            navBottomFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            navBottomFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            navBottomFlowLayoutPanel.Location = new System.Drawing.Point(0, 264);
            navBottomFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            navBottomFlowLayoutPanel.Name = "navBottomFlowLayoutPanel";
            navBottomFlowLayoutPanel.Size = new System.Drawing.Size(48, 48);
            navBottomFlowLayoutPanel.TabIndex = 1;
            // 
            // settingsNavButton
            // 
            this.settingsNavButton.BackColor = System.Drawing.SystemColors.Menu;
            this.settingsNavButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settingsNavButton.FlatAppearance.BorderSize = 0;
            this.settingsNavButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsNavButton.ForeColor = System.Drawing.SystemColors.MenuText;
            this.settingsNavButton.IconChar = FontAwesome.Sharp.IconChar.Cog;
            this.settingsNavButton.IconColor = System.Drawing.SystemColors.MenuText;
            this.settingsNavButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.settingsNavButton.IconSize = 36;
            this.settingsNavButton.Location = new System.Drawing.Point(0, 0);
            this.settingsNavButton.Margin = new System.Windows.Forms.Padding(0);
            this.settingsNavButton.Name = "settingsNavButton";
            this.settingsNavButton.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.settingsNavButton.Size = new System.Drawing.Size(48, 48);
            this.settingsNavButton.TabIndex = 0;
            this.toolTip.SetToolTip(this.settingsNavButton, "설정");
            this.settingsNavButton.UseVisualStyleBackColor = false;
            this.settingsNavButton.Click += new System.EventHandler(this.Nav_Click);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            mainTableLayoutPanel.ResumeLayout(false);
            mainTableLayoutPanel.PerformLayout();
            navTopFlowLayoutPanel.ResumeLayout(false);
            builderStatusStrip.ResumeLayout(false);
            builderStatusStrip.PerformLayout();
            this.mainMultiPanel.ResumeLayout(false);
            this.buildMultiPanelPage.ResumeLayout(false);
            this.buildSplitContainer.Panel1.ResumeLayout(false);
            this.buildSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buildSplitContainer)).EndInit();
            this.buildSplitContainer.ResumeLayout(false);
            this.buildLeftTableLayoutPanel.ResumeLayout(false);
            numberOfVerseLinesPerSlideTableLayoutPanel.ResumeLayout(false);
            numberOfVerseLinesPerSlideTableLayoutPanel.PerformLayout();
            biblesTableLayoutPanel.ResumeLayout(false);
            biblesButtonTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.biblesDataGridView)).EndInit();
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
            this.historyMultiPanelPage.ResumeLayout(false);
            historyTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.historyDataGridView)).EndInit();
            historyFlowLayoutPanel.ResumeLayout(false);
            historyFlowLayoutPanel.PerformLayout();
            this.settingsMultiPanelPage.ResumeLayout(false);
            navBottomFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ComboBox templateBookAbbrComboBox;
        private System.Windows.Forms.Button templateEditButton;
        private System.Windows.Forms.TextBox versesTextBox;
        private System.Windows.Forms.ComboBox templateChapterNumberComboBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.ComboBox templateBookNameComboBox;
        private System.Windows.Forms.ListView booksListView;
        private System.Windows.Forms.TextBox booksSearchTextBox;
        private System.Windows.Forms.CheckBox buildSplitChaptersIntoFilesCheckBox;
        private System.Windows.Forms.ComboBox sourceComboBox;
        private System.Windows.Forms.ComboBox bibleComboBox;
        private FontAwesome.Sharp.IconButton buildNavButton;
        private Bible2PPT.Controls.MultiPanel mainMultiPanel;
        private Bible2PPT.Controls.MultiPanelPage historyMultiPanelPage;
        private Bible2PPT.Controls.MultiPanelPage templatesMultiPanelPage;
        private Bible2PPT.Controls.MultiPanelPage settingsMultiPanelPage;
        private FontAwesome.Sharp.IconButton historyNavButton;
        private FontAwesome.Sharp.IconButton settingsNavButton;
        private FontAwesome.Sharp.IconButton templatesNavButton;
        private Bible2PPT.Controls.MultiPanelPage buildMultiPanelPage;
        private FontAwesome.Sharp.IconButton biblesRemoveIconButton;
        private FontAwesome.Sharp.IconButton biblesAddIconButton;
        private FontAwesome.Sharp.IconButton biblesDownIconButton;
        private FontAwesome.Sharp.IconButton biblesUpIconButton;
        private System.Windows.Forms.TableLayoutPanel buildLeftTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel buildRightTableLayoutPanel;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripStatusLabel builderToolStripStatusLabel;
        private System.Windows.Forms.ToolStripProgressBar builderToolStripProgressBar;
        private System.Windows.Forms.SplitContainer buildSplitContainer;
        private System.Windows.Forms.DataGridView biblesDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn biblesSourceDataGridViewColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn biblesBibleDataGridViewColumn;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button cleanCacheButton;
        private System.Windows.Forms.DataGridView historyDataGridView;
        private System.Windows.Forms.Button historyOpenResultButton;
        private System.Windows.Forms.Button historyLoadButton;
        private System.Windows.Forms.Button historyDeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyCreatedAtColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyQueryStringColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyBiblesColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn historySplitChaptersIntoFileColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn historyJobProgress;
        private System.Windows.Forms.CheckBox autoOpenCheckBox;
        private System.Windows.Forms.ComboBox numberOfVerseLinesPerSlideComboBox;
    }
}

