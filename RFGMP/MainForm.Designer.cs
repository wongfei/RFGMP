namespace RFGMP
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lobbyTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripRefresh = new System.Windows.Forms.ToolStripButton();
            this.steamTimer = new System.Windows.Forms.Timer(this.components);
            this.lobbiesView = new System.Windows.Forms.ListView();
            this.mmHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mmGameMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mmLevelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mmNumPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabLobbies = new System.Windows.Forms.TabPage();
            this.tabHistory = new System.Windows.Forms.TabPage();
            this.histView = new System.Windows.Forms.ListView();
            this.histHostName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.histGameMode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.histLevelName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.histPlayers = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.histTimestamp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabStats = new System.Windows.Forms.TabPage();
            this.statsView = new System.Windows.Forms.ListView();
            this.statKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.trayMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabLobbies.SuspendLayout();
            this.tabHistory.SuspendLayout();
            this.tabStats.SuspendLayout();
            this.tabOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "RFGMP";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuExit});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(93, 26);
            // 
            // trayMenuExit
            // 
            this.trayMenuExit.Name = "trayMenuExit";
            this.trayMenuExit.Size = new System.Drawing.Size(92, 22);
            this.trayMenuExit.Text = "Exit";
            this.trayMenuExit.Click += new System.EventHandler(this.trayMenuExit_Click);
            // 
            // lobbyTimer
            // 
            this.lobbyTimer.Interval = 30000;
            this.lobbyTimer.Tick += new System.EventHandler(this.lobbyUpdateTimer_Tick);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripRefresh});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(484, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // toolStripRefresh
            // 
            this.toolStripRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripRefresh.Image")));
            this.toolStripRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripRefresh.Name = "toolStripRefresh";
            this.toolStripRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripRefresh.Text = "Refresh";
            this.toolStripRefresh.Click += new System.EventHandler(this.toolStripRefresh_Click);
            // 
            // steamTimer
            // 
            this.steamTimer.Interval = 200;
            this.steamTimer.Tick += new System.EventHandler(this.steamTimer_Tick);
            // 
            // lobbiesView
            // 
            this.lobbiesView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lobbiesView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.mmHostName,
            this.mmGameMode,
            this.mmLevelName,
            this.mmNumPlayers});
            this.lobbiesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lobbiesView.FullRowSelect = true;
            this.lobbiesView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lobbiesView.Location = new System.Drawing.Point(3, 3);
            this.lobbiesView.Name = "lobbiesView";
            this.lobbiesView.Size = new System.Drawing.Size(470, 404);
            this.lobbiesView.TabIndex = 2;
            this.lobbiesView.UseCompatibleStateImageBehavior = false;
            this.lobbiesView.View = System.Windows.Forms.View.Details;
            // 
            // mmHostName
            // 
            this.mmHostName.Text = "Host";
            this.mmHostName.Width = 120;
            // 
            // mmGameMode
            // 
            this.mmGameMode.Text = "Mode";
            this.mmGameMode.Width = 80;
            // 
            // mmLevelName
            // 
            this.mmLevelName.Text = "Level";
            this.mmLevelName.Width = 100;
            // 
            // mmNumPlayers
            // 
            this.mmNumPlayers.Text = "Players";
            this.mmNumPlayers.Width = 50;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabLobbies);
            this.tabControl.Controls.Add(this.tabHistory);
            this.tabControl.Controls.Add(this.tabStats);
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 436);
            this.tabControl.TabIndex = 2;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabLobbies
            // 
            this.tabLobbies.Controls.Add(this.lobbiesView);
            this.tabLobbies.Location = new System.Drawing.Point(4, 22);
            this.tabLobbies.Name = "tabLobbies";
            this.tabLobbies.Padding = new System.Windows.Forms.Padding(3);
            this.tabLobbies.Size = new System.Drawing.Size(476, 410);
            this.tabLobbies.TabIndex = 0;
            this.tabLobbies.Text = "Lobbies";
            this.tabLobbies.UseVisualStyleBackColor = true;
            // 
            // tabHistory
            // 
            this.tabHistory.Controls.Add(this.histView);
            this.tabHistory.Location = new System.Drawing.Point(4, 22);
            this.tabHistory.Name = "tabHistory";
            this.tabHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tabHistory.Size = new System.Drawing.Size(476, 410);
            this.tabHistory.TabIndex = 2;
            this.tabHistory.Text = "History";
            this.tabHistory.UseVisualStyleBackColor = true;
            // 
            // histView
            // 
            this.histView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.histView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.histHostName,
            this.histGameMode,
            this.histLevelName,
            this.histPlayers,
            this.histTimestamp});
            this.histView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histView.FullRowSelect = true;
            this.histView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.histView.Location = new System.Drawing.Point(3, 3);
            this.histView.Name = "histView";
            this.histView.Size = new System.Drawing.Size(470, 404);
            this.histView.TabIndex = 0;
            this.histView.UseCompatibleStateImageBehavior = false;
            this.histView.View = System.Windows.Forms.View.Details;
            // 
            // histHostName
            // 
            this.histHostName.Text = "Host";
            this.histHostName.Width = 120;
            // 
            // histGameMode
            // 
            this.histGameMode.Text = "Mode";
            this.histGameMode.Width = 80;
            // 
            // histLevelName
            // 
            this.histLevelName.Text = "Level";
            this.histLevelName.Width = 100;
            // 
            // histPlayers
            // 
            this.histPlayers.Text = "Players";
            this.histPlayers.Width = 50;
            // 
            // histTimestamp
            // 
            this.histTimestamp.Text = "Time";
            this.histTimestamp.Width = 115;
            // 
            // tabStats
            // 
            this.tabStats.Controls.Add(this.statsView);
            this.tabStats.Location = new System.Drawing.Point(4, 22);
            this.tabStats.Name = "tabStats";
            this.tabStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabStats.Size = new System.Drawing.Size(476, 410);
            this.tabStats.TabIndex = 1;
            this.tabStats.Text = "Stats";
            this.tabStats.UseVisualStyleBackColor = true;
            // 
            // statsView
            // 
            this.statsView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.statKey,
            this.statValue});
            this.statsView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statsView.FullRowSelect = true;
            this.statsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.statsView.Location = new System.Drawing.Point(3, 3);
            this.statsView.Name = "statsView";
            this.statsView.Size = new System.Drawing.Size(470, 404);
            this.statsView.TabIndex = 2;
            this.statsView.UseCompatibleStateImageBehavior = false;
            this.statsView.View = System.Windows.Forms.View.Details;
            // 
            // statKey
            // 
            this.statKey.Text = "Key";
            this.statKey.Width = 150;
            // 
            // statValue
            // 
            this.statValue.Text = "Value";
            this.statValue.Width = 100;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.optionsGrid);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Padding = new System.Windows.Forms.Padding(3);
            this.tabOptions.Size = new System.Drawing.Size(476, 410);
            this.tabOptions.TabIndex = 3;
            this.tabOptions.Text = "Options";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // optionsGrid
            // 
            this.optionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGrid.HelpVisible = false;
            this.optionsGrid.Location = new System.Drawing.Point(3, 3);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.optionsGrid.Size = new System.Drawing.Size(470, 404);
            this.optionsGrid.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.toolStrip);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "RFGMP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.trayMenu.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabLobbies.ResumeLayout(false);
            this.tabHistory.ResumeLayout(false);
            this.tabStats.ResumeLayout(false);
            this.tabOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Timer lobbyTimer;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripRefresh;
        private System.Windows.Forms.Timer steamTimer;
        private System.Windows.Forms.ListView lobbiesView;
        private System.Windows.Forms.ColumnHeader mmHostName;
        private System.Windows.Forms.ColumnHeader mmGameMode;
        private System.Windows.Forms.ColumnHeader mmLevelName;
        private System.Windows.Forms.ColumnHeader mmNumPlayers;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLobbies;
        private System.Windows.Forms.TabPage tabStats;
        private System.Windows.Forms.ListView statsView;
        private System.Windows.Forms.ColumnHeader statKey;
        private System.Windows.Forms.ColumnHeader statValue;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.ListView histView;
        private System.Windows.Forms.ColumnHeader histHostName;
        private System.Windows.Forms.ColumnHeader histGameMode;
        private System.Windows.Forms.ColumnHeader histTimestamp;
        private System.Windows.Forms.ColumnHeader histLevelName;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.PropertyGrid optionsGrid;
        private System.Windows.Forms.ColumnHeader histPlayers;
    }
}

