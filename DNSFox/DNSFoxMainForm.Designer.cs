namespace DNSFox
{
    partial class DNSFoxMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
            System.Windows.Forms.ToolStripLabel toolStripLabel2;
            System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            PresentationControls.CheckBoxProperties checkBoxProperties1 = new PresentationControls.CheckBoxProperties();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DNSFoxMainForm));
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.labelServerStatusTitle = new System.Windows.Forms.Label();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel_QueryCountTitle = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_QueryCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_ServerTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_Console = new System.Windows.Forms.TabPage();
            this.listBoxConsole = new System.Windows.Forms.ListBox();
            this.toolStripConsole = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonConsoleRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tab_Incoming = new System.Windows.Forms.TabPage();
            this.dataGridViewIncoming = new System.Windows.Forms.DataGridView();
            this.cDomainRequestor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDomainClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDomainType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDomainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDomainTimestamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripIncoming = new System.Windows.Forms.ToolStrip();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.tab_Domains = new System.Windows.Forms.TabPage();
            this.dataGridViewDomains = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripDomains = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.tab_Filter = new System.Windows.Forms.TabPage();
            this.tab_Outgoing = new System.Windows.Forms.TabPage();
            this.tab_Stats = new System.Windows.Forms.TabPage();
            this.tab_Graphs = new System.Windows.Forms.TabPage();
            this.tab_Settings = new System.Windows.Forms.TabPage();
            this.imageListConsoleLogType = new System.Windows.Forms.ImageList(this.components);
            this.comboBoxIPListenerSelection = new PresentationControls.CheckBoxComboBox();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tab_Console.SuspendLayout();
            this.toolStripConsole.SuspendLayout();
            this.tab_Incoming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncoming)).BeginInit();
            this.toolStripIncoming.SuspendLayout();
            this.tab_Domains.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomains)).BeginInit();
            this.toolStripDomains.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new System.Drawing.Size(45, 22);
            toolStripLabel2.Text = "Search:";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(824, 441);
            this.shapeContainer1.TabIndex = 2;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 12;
            this.lineShape1.X2 = 811;
            this.lineShape1.Y1 = 45;
            this.lineShape1.Y2 = 45;
            // 
            // updateTimer
            // 
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStopServer.Enabled = false;
            this.buttonStopServer.Location = new System.Drawing.Point(738, 11);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStopServer.TabIndex = 4;
            this.buttonStopServer.Text = "S&top";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartServer.Location = new System.Drawing.Point(657, 11);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStartServer.TabIndex = 5;
            this.buttonStartServer.Text = "&Start";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // labelServerStatusTitle
            // 
            this.labelServerStatusTitle.Location = new System.Drawing.Point(13, 8);
            this.labelServerStatusTitle.Name = "labelServerStatusTitle";
            this.labelServerStatusTitle.Size = new System.Drawing.Size(78, 13);
            this.labelServerStatusTitle.TabIndex = 6;
            this.labelServerStatusTitle.Text = "Server is:";
            this.labelServerStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerStatus.ForeColor = System.Drawing.Color.DarkRed;
            this.labelServerStatus.Location = new System.Drawing.Point(13, 21);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(78, 13);
            this.labelServerStatus.TabIndex = 7;
            this.labelServerStatus.Text = "Stopped";
            this.labelServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // statusStrip
            // 
            this.statusStrip.AllowMerge = false;
            this.statusStrip.AutoSize = false;
            this.statusStrip.BackColor = System.Drawing.Color.LightCoral;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_QueryCountTitle,
            this.toolStripStatusLabel_QueryCount,
            this.toolStripStatusLabel_ServerTime});
            this.statusStrip.Location = new System.Drawing.Point(0, 419);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(824, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            // 
            // toolStripStatusLabel_QueryCountTitle
            // 
            this.toolStripStatusLabel_QueryCountTitle.Name = "toolStripStatusLabel_QueryCountTitle";
            this.toolStripStatusLabel_QueryCountTitle.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel_QueryCountTitle.Text = "Lifetime Queries:";
            this.toolStripStatusLabel_QueryCountTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStripStatusLabel_QueryCount
            // 
            this.toolStripStatusLabel_QueryCount.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_QueryCount.Name = "toolStripStatusLabel_QueryCount";
            this.toolStripStatusLabel_QueryCount.Size = new System.Drawing.Size(0, 17);
            this.toolStripStatusLabel_QueryCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel_ServerTime
            // 
            this.toolStripStatusLabel_ServerTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel_ServerTime.Name = "toolStripStatusLabel_ServerTime";
            this.toolStripStatusLabel_ServerTime.Size = new System.Drawing.Size(713, 17);
            this.toolStripStatusLabel_ServerTime.Spring = true;
            this.toolStripStatusLabel_ServerTime.Text = "[SERVER TIME HERE]";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_Console);
            this.tabControl1.Controls.Add(this.tab_Incoming);
            this.tabControl1.Controls.Add(this.tab_Domains);
            this.tabControl1.Controls.Add(this.tab_Filter);
            this.tabControl1.Controls.Add(this.tab_Outgoing);
            this.tabControl1.Controls.Add(this.tab_Stats);
            this.tabControl1.Controls.Add(this.tab_Graphs);
            this.tabControl1.Controls.Add(this.tab_Settings);
            this.tabControl1.HotTrack = true;
            this.tabControl1.Location = new System.Drawing.Point(12, 53);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(0, 0);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(803, 355);
            this.tabControl1.TabIndex = 10;
            // 
            // tab_Console
            // 
            this.tab_Console.BackColor = System.Drawing.Color.Transparent;
            this.tab_Console.Controls.Add(this.listBoxConsole);
            this.tab_Console.Controls.Add(this.toolStripConsole);
            this.tab_Console.Location = new System.Drawing.Point(4, 22);
            this.tab_Console.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Console.Name = "tab_Console";
            this.tab_Console.Size = new System.Drawing.Size(795, 329);
            this.tab_Console.TabIndex = 6;
            this.tab_Console.Text = "Console";
            this.tab_Console.Enter += new System.EventHandler(this.tab_Console_Enter);
            // 
            // listBoxConsole
            // 
            this.listBoxConsole.BackColor = System.Drawing.Color.Black;
            this.listBoxConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxConsole.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxConsole.ForeColor = System.Drawing.Color.GreenYellow;
            this.listBoxConsole.FormattingEnabled = true;
            this.listBoxConsole.ItemHeight = 12;
            this.listBoxConsole.Location = new System.Drawing.Point(0, 25);
            this.listBoxConsole.Margin = new System.Windows.Forms.Padding(0);
            this.listBoxConsole.Name = "listBoxConsole";
            this.listBoxConsole.Size = new System.Drawing.Size(795, 304);
            this.listBoxConsole.TabIndex = 0;
            // 
            // toolStripConsole
            // 
            this.toolStripConsole.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripConsole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            toolStripSeparator2,
            this.toolStripButtonConsoleRefresh,
            toolStripSeparator1,
            toolStripLabel2,
            this.toolStripTextBox1});
            this.toolStripConsole.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStripConsole.Location = new System.Drawing.Point(0, 0);
            this.toolStripConsole.Name = "toolStripConsole";
            this.toolStripConsole.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripConsole.Size = new System.Drawing.Size(795, 25);
            this.toolStripConsole.Stretch = true;
            this.toolStripConsole.TabIndex = 1;
            // 
            // toolStripButtonConsoleRefresh
            // 
            this.toolStripButtonConsoleRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonConsoleRefresh.Image = global::DNSFox.Properties.Resources.arrow_refresh;
            this.toolStripButtonConsoleRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConsoleRefresh.Name = "toolStripButtonConsoleRefresh";
            this.toolStripButtonConsoleRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonConsoleRefresh.Text = "Refresh";
            this.toolStripButtonConsoleRefresh.ToolTipText = "Refresh Console Log";
            this.toolStripButtonConsoleRefresh.Click += new System.EventHandler(this.toolStripButtonConsoleRefresh_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            this.toolStripTextBox1.ToolTipText = "Search";
            // 
            // tab_Incoming
            // 
            this.tab_Incoming.Controls.Add(this.dataGridViewIncoming);
            this.tab_Incoming.Controls.Add(this.toolStripIncoming);
            this.tab_Incoming.Location = new System.Drawing.Point(4, 22);
            this.tab_Incoming.Margin = new System.Windows.Forms.Padding(0);
            this.tab_Incoming.Name = "tab_Incoming";
            this.tab_Incoming.Size = new System.Drawing.Size(795, 329);
            this.tab_Incoming.TabIndex = 0;
            this.tab_Incoming.Text = "Incoming";
            this.tab_Incoming.UseVisualStyleBackColor = true;
            this.tab_Incoming.Enter += new System.EventHandler(this.tab_Incoming_Enter);
            // 
            // dataGridViewIncoming
            // 
            this.dataGridViewIncoming.AllowUserToAddRows = false;
            this.dataGridViewIncoming.AllowUserToDeleteRows = false;
            this.dataGridViewIncoming.AllowUserToOrderColumns = true;
            this.dataGridViewIncoming.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewIncoming.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewIncoming.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewIncoming.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewIncoming.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIncoming.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cDomainRequestor,
            this.cDomainClass,
            this.cDomainType,
            this.cDomainName,
            this.cDomainTimestamp});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewIncoming.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewIncoming.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewIncoming.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewIncoming.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewIncoming.MultiSelect = false;
            this.dataGridViewIncoming.Name = "dataGridViewIncoming";
            this.dataGridViewIncoming.ReadOnly = true;
            this.dataGridViewIncoming.RowHeadersVisible = false;
            this.dataGridViewIncoming.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewIncoming.ShowEditingIcon = false;
            this.dataGridViewIncoming.Size = new System.Drawing.Size(795, 304);
            this.dataGridViewIncoming.TabIndex = 0;
            // 
            // cDomainRequestor
            // 
            this.cDomainRequestor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.cDomainRequestor.FillWeight = 10F;
            this.cDomainRequestor.HeaderText = "Requestor";
            this.cDomainRequestor.MinimumWidth = 85;
            this.cDomainRequestor.Name = "cDomainRequestor";
            this.cDomainRequestor.ReadOnly = true;
            this.cDomainRequestor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cDomainRequestor.Width = 85;
            // 
            // cDomainClass
            // 
            this.cDomainClass.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cDomainClass.DefaultCellStyle = dataGridViewCellStyle2;
            this.cDomainClass.FillWeight = 10F;
            this.cDomainClass.HeaderText = "";
            this.cDomainClass.MinimumWidth = 20;
            this.cDomainClass.Name = "cDomainClass";
            this.cDomainClass.ReadOnly = true;
            this.cDomainClass.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cDomainClass.Width = 20;
            // 
            // cDomainType
            // 
            this.cDomainType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cDomainType.DefaultCellStyle = dataGridViewCellStyle3;
            this.cDomainType.FillWeight = 10F;
            this.cDomainType.HeaderText = "";
            this.cDomainType.MinimumWidth = 50;
            this.cDomainType.Name = "cDomainType";
            this.cDomainType.ReadOnly = true;
            this.cDomainType.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.cDomainType.Width = 50;
            // 
            // cDomainName
            // 
            this.cDomainName.FillWeight = 50F;
            this.cDomainName.HeaderText = "Domain Name";
            this.cDomainName.Name = "cDomainName";
            this.cDomainName.ReadOnly = true;
            // 
            // cDomainTimestamp
            // 
            this.cDomainTimestamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.cDomainTimestamp.DefaultCellStyle = dataGridViewCellStyle4;
            this.cDomainTimestamp.FillWeight = 1F;
            this.cDomainTimestamp.HeaderText = "Timestamp";
            this.cDomainTimestamp.MinimumWidth = 150;
            this.cDomainTimestamp.Name = "cDomainTimestamp";
            this.cDomainTimestamp.ReadOnly = true;
            this.cDomainTimestamp.Width = 150;
            // 
            // toolStripIncoming
            // 
            this.toolStripIncoming.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripIncoming.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton2,
            this.toolStripSeparator3,
            this.toolStripLabel1,
            this.toolStripComboBox1});
            this.toolStripIncoming.Location = new System.Drawing.Point(0, 0);
            this.toolStripIncoming.Name = "toolStripIncoming";
            this.toolStripIncoming.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripIncoming.Size = new System.Drawing.Size(795, 25);
            this.toolStripIncoming.TabIndex = 1;
            this.toolStripIncoming.Text = "toolStrip1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::DNSFox.Properties.Resources.arrow_refresh;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Refresh";
            this.toolStripButton2.ToolTipText = "Refresh Console Log";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Show:";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "10",
            "50",
            "100",
            "200",
            "1000"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(75, 25);
            this.toolStripComboBox1.Text = "200";
            // 
            // tab_Domains
            // 
            this.tab_Domains.Controls.Add(this.dataGridViewDomains);
            this.tab_Domains.Controls.Add(this.toolStripDomains);
            this.tab_Domains.Location = new System.Drawing.Point(4, 22);
            this.tab_Domains.Name = "tab_Domains";
            this.tab_Domains.Size = new System.Drawing.Size(795, 329);
            this.tab_Domains.TabIndex = 7;
            this.tab_Domains.Text = "Domains";
            this.tab_Domains.UseVisualStyleBackColor = true;
            // 
            // dataGridViewDomains
            // 
            this.dataGridViewDomains.AllowUserToAddRows = false;
            this.dataGridViewDomains.AllowUserToDeleteRows = false;
            this.dataGridViewDomains.AllowUserToOrderColumns = true;
            this.dataGridViewDomains.AllowUserToResizeRows = false;
            this.dataGridViewDomains.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewDomains.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewDomains.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDomains.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn1});
            this.dataGridViewDomains.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewDomains.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridViewDomains.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewDomains.MultiSelect = false;
            this.dataGridViewDomains.Name = "dataGridViewDomains";
            this.dataGridViewDomains.RowHeadersVisible = false;
            this.dataGridViewDomains.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewDomains.ShowEditingIcon = false;
            this.dataGridViewDomains.Size = new System.Drawing.Size(795, 304);
            this.dataGridViewDomains.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Type";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Domain Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // toolStripDomains
            // 
            this.toolStripDomains.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripDomains.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStripDomains.Location = new System.Drawing.Point(0, 0);
            this.toolStripDomains.Name = "toolStripDomains";
            this.toolStripDomains.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStripDomains.Size = new System.Drawing.Size(795, 25);
            this.toolStripDomains.TabIndex = 2;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::DNSFox.Properties.Resources.arrow_refresh;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // tab_Filter
            // 
            this.tab_Filter.Location = new System.Drawing.Point(4, 22);
            this.tab_Filter.Name = "tab_Filter";
            this.tab_Filter.Padding = new System.Windows.Forms.Padding(3);
            this.tab_Filter.Size = new System.Drawing.Size(795, 329);
            this.tab_Filter.TabIndex = 1;
            this.tab_Filter.Text = "Filters & Rules";
            this.tab_Filter.UseVisualStyleBackColor = true;
            // 
            // tab_Outgoing
            // 
            this.tab_Outgoing.Location = new System.Drawing.Point(4, 22);
            this.tab_Outgoing.Name = "tab_Outgoing";
            this.tab_Outgoing.Size = new System.Drawing.Size(795, 329);
            this.tab_Outgoing.TabIndex = 2;
            this.tab_Outgoing.Text = "Outgoing";
            this.tab_Outgoing.UseVisualStyleBackColor = true;
            // 
            // tab_Stats
            // 
            this.tab_Stats.Location = new System.Drawing.Point(4, 22);
            this.tab_Stats.Name = "tab_Stats";
            this.tab_Stats.Size = new System.Drawing.Size(795, 329);
            this.tab_Stats.TabIndex = 3;
            this.tab_Stats.Text = "Statistics";
            this.tab_Stats.UseVisualStyleBackColor = true;
            // 
            // tab_Graphs
            // 
            this.tab_Graphs.Location = new System.Drawing.Point(4, 22);
            this.tab_Graphs.Name = "tab_Graphs";
            this.tab_Graphs.Size = new System.Drawing.Size(795, 329);
            this.tab_Graphs.TabIndex = 5;
            this.tab_Graphs.Text = "Graphs";
            this.tab_Graphs.UseVisualStyleBackColor = true;
            // 
            // tab_Settings
            // 
            this.tab_Settings.Location = new System.Drawing.Point(4, 22);
            this.tab_Settings.Name = "tab_Settings";
            this.tab_Settings.Size = new System.Drawing.Size(795, 329);
            this.tab_Settings.TabIndex = 4;
            this.tab_Settings.Text = "Settings";
            this.tab_Settings.UseVisualStyleBackColor = true;
            // 
            // imageListConsoleLogType
            // 
            this.imageListConsoleLogType.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListConsoleLogType.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListConsoleLogType.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // comboBoxIPListenerSelection
            // 
            this.comboBoxIPListenerSelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            checkBoxProperties1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBoxIPListenerSelection.CheckBoxProperties = checkBoxProperties1;
            this.comboBoxIPListenerSelection.DisplayMemberSingleItem = "";
            this.comboBoxIPListenerSelection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIPListenerSelection.FormattingEnabled = true;
            this.comboBoxIPListenerSelection.Location = new System.Drawing.Point(97, 12);
            this.comboBoxIPListenerSelection.MinimumSize = new System.Drawing.Size(240, 0);
            this.comboBoxIPListenerSelection.Name = "comboBoxIPListenerSelection";
            this.comboBoxIPListenerSelection.Size = new System.Drawing.Size(554, 21);
            this.comboBoxIPListenerSelection.TabIndex = 9;
            // 
            // DNSFoxMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.comboBoxIPListenerSelection);
            this.Controls.Add(this.labelServerStatus);
            this.Controls.Add(this.labelServerStatusTitle);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.shapeContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(584, 368);
            this.Name = "DNSFoxMainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DNSFox";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DNSFoxMainForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.DNSFoxMainForm_VisibleChanged);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tab_Console.ResumeLayout(false);
            this.tab_Console.PerformLayout();
            this.toolStripConsole.ResumeLayout(false);
            this.toolStripConsole.PerformLayout();
            this.tab_Incoming.ResumeLayout(false);
            this.tab_Incoming.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIncoming)).EndInit();
            this.toolStripIncoming.ResumeLayout(false);
            this.toolStripIncoming.PerformLayout();
            this.tab_Domains.ResumeLayout(false);
            this.tab_Domains.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDomains)).EndInit();
            this.toolStripDomains.ResumeLayout(false);
            this.toolStripDomains.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.Timer updateTimer;
        private System.Windows.Forms.Button buttonStopServer;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.Label labelServerStatusTitle;
        private System.Windows.Forms.Label labelServerStatus;
        private PresentationControls.CheckBoxComboBox comboBoxIPListenerSelection;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_QueryCount;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_QueryCountTitle;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_ServerTime;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_Incoming;
        private System.Windows.Forms.TabPage tab_Filter;
        private System.Windows.Forms.TabPage tab_Outgoing;
        private System.Windows.Forms.TabPage tab_Stats;
        private System.Windows.Forms.TabPage tab_Settings;
        private System.Windows.Forms.TabPage tab_Console;
        private System.Windows.Forms.TabPage tab_Graphs;
        private System.Windows.Forms.ListBox listBoxConsole;
        private System.Windows.Forms.DataGridView dataGridViewIncoming;
        private System.Windows.Forms.TabPage tab_Domains;
        private System.Windows.Forms.DataGridView dataGridViewDomains;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStrip toolStripDomains;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStrip toolStripIncoming;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.ToolStrip toolStripConsole;
        private System.Windows.Forms.ImageList imageListConsoleLogType;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButtonConsoleRefresh;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDomainRequestor;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDomainClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDomainType;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDomainName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDomainTimestamp;
    }
}

