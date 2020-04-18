using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

using Steamworks;

namespace RFGMP
{
    public partial class MainForm : Form
    {
        private Options options = new Options();
        private bool appShutdownFlag = false;

        private int statNumUpdates = 0;
        private int statMaxLobbies = 0;
        private int statMaxPlayers = 0;

        public MainForm()
        {
            InitializeComponent();
            optionsGrid.SelectedObject = options;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            LoadConfig();

            if (!InitSteam())
            {
                ShowError("InitSteam failed");
                ShutdownApp();
                return;
            }

            UpdateLobbies();
        }

        private void ShutdownApp()
        {
            appShutdownFlag = true;
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // hide to tray on X button
            if (e.CloseReason == CloseReason.UserClosing && !appShutdownFlag)
            {
                Hide();
                e.Cancel = true;
                return;
            }

            // real shutdown
            ShutdownSteam();
            SaveConfig();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name == "tabHistory")
            {
                updateHistory();
            }
        }

        //
        // TRAY
        //

        private void trayIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (!this.Visible)
                    Show();

                if (this.WindowState == FormWindowState.Minimized)
                    this.WindowState = FormWindowState.Normal;
            }
        }

        private void trayMenuExit_Click(object sender, EventArgs e)
        {
            ShutdownApp();
        }

        //
        // LOBBY
        //

        private bool steamInitialized = false;
        private Callback<LobbyMatchList_t> Callback_lobbyList;

        private List<Lobby> liveLobbies = new List<Lobby>();
        private HashSet<string> uniqHosters = new HashSet<string>();
        private Dictionary<ulong, PersistentLobby> persLobbies = new Dictionary<ulong, PersistentLobby>();

        private bool IsGameRunning()
        {
            return Process.GetProcessesByName("rfg").Length > 0;
        }

        private bool InitSteam()
        {
            Debug.WriteLine("InitSteam");

            steamInitialized = SteamAPI.Init();
            if (!steamInitialized)
                return false;

            SteamMatchmaking.AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide);
            Callback_lobbyList = Callback<LobbyMatchList_t>.Create(OnGetLobbiesList);

            steamTimer.Start();

            return true;
        }

        private void ShutdownSteam()
        {
            Debug.WriteLine("ShutdownSteam");

            if (steamInitialized)
            {
                steamInitialized = false;
                steamTimer.Stop();
                SteamAPI.Shutdown();
            }
        }

        private void steamTimer_Tick(object sender, EventArgs e)
        {
            if (steamInitialized)
                SteamAPI.RunCallbacks();
        }

        private void lobbyUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (options.UpdateWhilePlaying || !IsGameRunning())
                UpdateLobbies();
        }

        private void toolStripRefresh_Click(object sender, EventArgs e)
        {
            UpdateLobbies();
        }

        private void UpdateLobbies()
        {
            toolStripRefresh.Enabled = false;
            lobbyTimer.Stop();

            SteamMatchmaking.RequestLobbyList();
        }

        private void OnGetLobbiesList(LobbyMatchList_t result)
        {
            // https://github.com/famishedmammal/Steamworks.NET-matchmaking-lobbies-example/blob/master/lobbyserverTEST.cs

            ++statNumUpdates;

            // lobby view

            liveLobbies.Clear();
            int totalPlayers = 0;

            lobbiesView.BeginUpdate();
            lobbiesView.Items.Clear();

            Debug.WriteLine("NumLobbies: " + result.m_nLobbiesMatching);
            for (int i = 0; i < result.m_nLobbiesMatching; i++)
            {
                CSteamID lobbyID = SteamMatchmaking.GetLobbyByIndex(i);

                var lobby = new Lobby(lobbyID);
                liveLobbies.Add(lobby);
                updateLobby(lobby);

                totalPlayers += lobby.NumPlayers;
            }

            lobbiesView.EndUpdate();

            updateHistory();

            // stats

            statMaxLobbies = Math.Max(statMaxLobbies, liveLobbies.Count);
            statMaxPlayers = Math.Max(statMaxPlayers, totalPlayers);

            updateStats();

            // tray

            bool trayActive = (liveLobbies.Count >= options.TrayMinLobbies && totalPlayers >= options.TrayMinPlayers);
            trayIcon.Icon = trayActive ? RFGMP.Resources.hammer_on : RFGMP.Resources.hammer_ghost;

            notify();

            // continue

            toolStripRefresh.Enabled = true;
            lobbyTimer.Start();
        }

        private void updateLobby(Lobby lobby)
        {
            var lobbySID = lobby.LobbyID.m_SteamID;

            Debug.WriteLine(lobby.ToString());
            var cols = new string[] { lobby.HostName, lobby.GameMode.ToString(), lobby.LevelName, lobby.NumPlayers.ToString() };
            var item = new ListViewItem(cols);
            lobbiesView.Items.Add(item);

            PersistentLobby persLobby;
            if (persLobbies.ContainsKey(lobbySID))
            {
                persLobby = persLobbies[lobbySID];
            }
            else
            {
                persLobby = new PersistentLobby();
                persLobby.CreateDate = DateTime.Now;
                persLobby.IsNew = true;
                persLobbies.Add(lobbySID, persLobby);
            }

            persLobby.HostName = lobby.HostName;
            persLobby.GameMode = lobby.GameMode;
            persLobby.LevelName = lobby.LevelName;
            persLobby.NumPlayers = lobby.NumPlayers;
            persLobby.MaxPlayers = Math.Max(persLobby.MaxPlayers, lobby.NumPlayers);
            persLobby.UpdateDate = DateTime.Now;

            if (!uniqHosters.Contains(lobby.HostName))
                uniqHosters.Add(lobby.HostName);
        }

        private void updateHistory()
        {
            histView.BeginUpdate();
            histView.Items.Clear();

            foreach (var pair in persLobbies)
            {
                var lobby = pair.Value;

                var dur = lobby.UpdateDate - lobby.CreateDate;
                int totalSec = (int)dur.TotalSeconds;
                int totalMin = (int)dur.TotalMinutes;
                string durStr = totalMin > 0 ? totalMin.ToString() + "m" : totalSec.ToString() + "s";
                var ts = lobby.CreateDate.ToString("MM/dd HH:mm", CultureInfo.InvariantCulture) + " ~" + durStr;

                histView.Items.Add(new ListViewItem(new string[] { lobby.HostName, lobby.GameMode.ToString(), lobby.LevelName, lobby.MaxPlayers.ToString(), ts }));
            }

            histView.EndUpdate();
        }

        private void updateStats()
        {
            statsView.BeginUpdate();
            statsView.Items.Clear();

            statsView.Items.Add(new ListViewItem(new string[] { "Num Updates", statNumUpdates.ToString() }));
            statsView.Items.Add(new ListViewItem(new string[] { "Max Lobbies", statMaxLobbies.ToString() }));
            statsView.Items.Add(new ListViewItem(new string[] { "Max Players", statMaxPlayers.ToString() }));
            statsView.Items.Add(new ListViewItem(new string[] { "Uniq Hosters", uniqHosters.Count.ToString() }));

            statsView.EndUpdate();
        }

        private void notify()
        {
            if (options.NotifyEnabled)
            {
                int numNewLobbies = 0;
                foreach (var pair in persLobbies)
                {
                    var lobby = pair.Value;
                    int durationSec = (int)(lobby.UpdateDate - lobby.CreateDate).TotalSeconds;

                    if (lobby.IsNew && durationSec >= options.NotifyMinDurationSec && lobby.NumPlayers >= options.NotifyMinPlayers)
                    {
                        pair.Value.IsNew = false;
                        ++numNewLobbies;
                    }
                }

                if (numNewLobbies >= options.NotifyMinLobbies && !IsGameRunning())
                {
                    trayIcon.BalloonTipIcon = ToolTipIcon.None;
                    trayIcon.BalloonTipTitle = "";
                    trayIcon.BalloonTipText = "RFG alive!";
                    trayIcon.ShowBalloonTip(options.NotifyBalloonSec * 1000);
                }
            }
        }

        //
        // UTILS
        //

        private void LoadConfig()
        {
            PropertyInfo[] properties = typeof(Options).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                try
                {
                    var str = GetConfigString(property.Name);
                    if (str != null)
                    {
                        var value = Convert.ChangeType(str, property.PropertyType);
                        if (value != null)
                        {
                            property.SetValue(options, value);
                        }
                    }
                }
                catch (Exception) { }
            }

            steamTimer.Interval = options.SteamTickMs;
            lobbyTimer.Interval = options.LobbyRefreshSec * 1000;
        }

        private void SaveConfig()
        {
            PropertyInfo[] properties = typeof(Options).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(options);
                SetConfigVar(property.Name, value);
            }

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var settings = config.AppSettings.Settings;

            foreach (string key in ConfigurationManager.AppSettings)
            {
                string value = ConfigurationManager.AppSettings[key];

                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
            }

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);
        }

        private void SetConfigVar(string key, object value)
        {
            ConfigurationManager.AppSettings[key] = value.ToString();
        }

        private string GetConfigString(string key)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[key]);
        }

        private bool GetConfigBool(string key)
        {
            bool value = false;
            bool.TryParse(GetConfigString(key), out value);
            return value;
        }

        private int GetConfigInt(string key)
        {
            int value = 0;
            int.TryParse(GetConfigString(key), out value);
            return value;
        }

        private float GetConfigFloat(string key)
        {
            float value = 0;
            float.TryParse(GetConfigString(key), out value);
            return value;
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "RFGMP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        ///
    }
}
