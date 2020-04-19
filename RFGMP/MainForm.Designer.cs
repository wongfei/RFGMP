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
            this.lobbyRequestTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.requestLobbiesBtn = new System.Windows.Forms.ToolStripButton();
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
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.optionsGrid = new System.Windows.Forms.PropertyGrid();
            this.redrawTimer = new System.Windows.Forms.Timer(this.components);
            this.lobbyUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.trayMenu.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabLobbies.SuspendLayout();
            this.tabHistory.SuspendLayout();
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
            // lobbyRequestTimer
            // 
            this.lobbyRequestTimer.Interval = 30000;
            this.lobbyRequestTimer.Tick += new System.EventHandler(this.lobbyRequestTimer_Tick);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.requestLobbiesBtn});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(484, 25);
            this.toolStrip.TabIndex = 1;
            // 
            // requestLobbiesBtn
            // 
            this.requestLobbiesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.requestLobbiesBtn.Image = ((System.Drawing.Image)(resources.GetObject("requestLobbiesBtn.Image")));
            this.requestLobbiesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.requestLobbiesBtn.Name = "requestLobbiesBtn";
            this.requestLobbiesBtn.Size = new System.Drawing.Size(23, 22);
            this.requestLobbiesBtn.Text = "Refresh";
            this.requestLobbiesBtn.Click += new System.EventHandler(this.requestLobbiesBtn_Click);
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
            this.mmLevelName,
            this.mmGameMode,
            this.mmNumPlayers});
            this.lobbiesView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lobbiesView.FullRowSelect = true;
            this.lobbiesView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lobbiesView.Location = new System.Drawing.Point(3, 3);
            this.lobbiesView.MultiSelect = false;
            this.lobbiesView.Name = "lobbiesView";
            this.lobbiesView.Size = new System.Drawing.Size(470, 404);
            this.lobbiesView.TabIndex = 2;
            this.lobbiesView.UseCompatibleStateImageBehavior = false;
            this.lobbiesView.View = System.Windows.Forms.View.Details;
            // 
            // mmHostName
            // 
            this.mmHostName.Text = "Host";
            this.mmHostName.Width = 100;
            // 
            // mmGameMode
            // 
            this.mmGameMode.Text = "Mode";
            this.mmGameMode.Width = 100;
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
            this.tabControl.Controls.Add(this.tabOptions);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 436);
            this.tabControl.TabIndex = 2;
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
            this.histLevelName,
            this.histGameMode,
            this.histPlayers,
            this.histTimestamp});
            this.histView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.histView.FullRowSelect = true;
            this.histView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.histView.Location = new System.Drawing.Point(3, 3);
            this.histView.MultiSelect = false;
            this.histView.Name = "histView";
            this.histView.Size = new System.Drawing.Size(470, 404);
            this.histView.TabIndex = 0;
            this.histView.UseCompatibleStateImageBehavior = false;
            this.histView.View = System.Windows.Forms.View.Details;
            // 
            // histHostName
            // 
            this.histHostName.Text = "Host";
            this.histHostName.Width = 100;
            // 
            // histGameMode
            // 
            this.histGameMode.Text = "Mode";
            this.histGameMode.Width = 100;
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
            this.histTimestamp.Text = "Last update";
            this.histTimestamp.Width = 115;
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
            // redrawTimer
            // 
            this.redrawTimer.Enabled = true;
            this.redrawTimer.Interval = 1000;
            this.redrawTimer.Tick += new System.EventHandler(this.redrawTimer_Tick);
            // 
            // lobbyUpdateTimer
            // 
            this.lobbyUpdateTimer.Interval = 10000;
            this.lobbyUpdateTimer.Tick += new System.EventHandler(this.lobbyUpdateTimer_Tick);
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
            this.tabOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Timer lobbyRequestTimer;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuExit;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton requestLobbiesBtn;
        private System.Windows.Forms.Timer steamTimer;
        private System.Windows.Forms.ListView lobbiesView;
        private System.Windows.Forms.ColumnHeader mmHostName;
        private System.Windows.Forms.ColumnHeader mmGameMode;
        private System.Windows.Forms.ColumnHeader mmLevelName;
        private System.Windows.Forms.ColumnHeader mmNumPlayers;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabLobbies;
        private System.Windows.Forms.TabPage tabHistory;
        private System.Windows.Forms.ListView histView;
        private System.Windows.Forms.ColumnHeader histHostName;
        private System.Windows.Forms.ColumnHeader histGameMode;
        private System.Windows.Forms.ColumnHeader histTimestamp;
        private System.Windows.Forms.ColumnHeader histLevelName;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.PropertyGrid optionsGrid;
        private System.Windows.Forms.ColumnHeader histPlayers;
        private System.Windows.Forms.Timer redrawTimer;
        private System.Windows.Forms.Timer lobbyUpdateTimer;
    }
}

