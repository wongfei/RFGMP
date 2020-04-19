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
        private bool appShutdownFlag = false;
        private Options options = new Options();
        private DateTime lastNotifTime = new DateTime();

        #region FORM

        public MainForm()
        {
            InitializeComponent();

            SetDoubleBuffered(lobbiesView, true);
            SetDoubleBuffered(histView, true);
            optionsGrid.SelectedObject = options;
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "RFGMP ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            InitNotifier();
            InitLobby();
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

        #endregion

        #region STEAM

        // https://github.com/famishedmammal/Steamworks.NET-matchmaking-lobbies-example/blob/master/lobbyserverTEST.cs

        private bool steamInitialized = false;
        private SteamAPIWarningMessageHook_t steamWarningCallback;
        private Callback<LobbyMatchList_t> lobbyMatchListCallback;
        private Callback<LobbyDataUpdate_t> lobbyDataUpdateCallback;

        private bool InitSteam()
        {
            Debug.WriteLine("InitSteam");

            steamInitialized = SteamAPI.Init();
            if (!steamInitialized)
                return false;

            steamWarningCallback = new SteamAPIWarningMessageHook_t(OnSteamWarning);
            SteamClient.SetWarningMessageHook(steamWarningCallback);

            SteamMatchmaking.AddRequestLobbyListDistanceFilter(ELobbyDistanceFilter.k_ELobbyDistanceFilterWorldwide);

            lobbyMatchListCallback = Callback<LobbyMatchList_t>.Create(OnLobbyMatchList);
            lobbyDataUpdateCallback = Callback<LobbyDataUpdate_t>.Create(OnLobbyDataUpdate);

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

        private static void OnSteamWarning(int nSeverity, System.Text.StringBuilder pchDebugText)
        {
            Debug.WriteLine("STEAM: " + pchDebugText);
        }

        #endregion

        #region LOBBY

        private Dictionary<ulong, Lobby> lobbies = new Dictionary<ulong, Lobby>();

        private void InitLobby()
        {
            lobbyUpdateTimer.Start();
            RequestLobbies();
        }

        private void requestLobbiesBtn_Click(object sender, EventArgs e)
        {
            RequestLobbies();
        }

        private void lobbyRequestTimer_Tick(object sender, EventArgs e)
        {
            if (options.UpdateWhilePlaying || !IsGameRunning())
                RequestLobbies();
        }

        private void lobbyUpdateTimer_Tick(object sender, EventArgs e)
        {
            foreach (var lobby in lobbies.Values)
            {
                if (lobby.Alive && (DateTime.Now - lobby.UpdateTime).TotalSeconds > options.LobbyUpdateInterval)
                {
                    RequestLobbyData(lobby.LobbyID);
                }
            }
        }

        private void RequestLobbies()
        {
            requestLobbiesBtn.Enabled = false;
            lobbyRequestTimer.Stop();

            SteamMatchmaking.RequestLobbyList();
        }

        private void OnLobbyMatchList(LobbyMatchList_t result)
        {
            Debug.WriteLine("OnLobbyMatchList: count=" + result.m_nLobbiesMatching);

            for (int i = 0; i < result.m_nLobbiesMatching; i++)
            {
                CSteamID lobbyID = SteamMatchmaking.GetLobbyByIndex(i);
                if (lobbyID.IsValid())
                {
                    RequestLobbyData(lobbyID);
                }
                else
                {
                    Debug.WriteLine("OnLobbyMatchList: invalid lobbyID at index: " + i);
                }
            }

            requestLobbiesBtn.Enabled = true;
            lobbyRequestTimer.Start();
        }

        private void RequestLobbyData(CSteamID lobbyID)
        {
            if (!SteamMatchmaking.RequestLobbyData(lobbyID))
            {
                MarkLobbyDead(lobbyID.m_SteamID);
            }
        }

        private void OnLobbyDataUpdate(LobbyDataUpdate_t result)
        {
            var rawID = result.m_ulSteamIDLobby;
            //Debug.WriteLine("OnLobbyDataUpdate: rawID=" + rawID + " success=" + result.m_bSuccess);

            if (result.m_bSuccess == 1)
            {
                UpdateLobby(rawID);
            }
            else
            {
                MarkLobbyDead(rawID);
            }
        }

        private void UpdateLobby(ulong rawID)
        {
            Lobby lobby;
            if (!lobbies.ContainsKey(rawID))
            {
                lobby = new Lobby(rawID);
                if (lobby.IsValid())
                {
                    Debug.WriteLine("AddLobby: rawID=" + rawID.ToString() + " # " + lobby.ToString());
                    lobbies.Add(rawID, lobby);
                }
            }
            else
            {
                lobby = lobbies[rawID];
                lobby.ReadLobbyData();
            }
        }

        private void MarkLobbyDead(ulong rawID)
        {
            Debug.WriteLine("MarkLobbyDead: rawID=" + rawID.ToString());

            if (lobbies.ContainsKey(rawID))
            {
                lobbies[rawID].Alive = false;
            }
        }

        #endregion

        #region VIEWS

        private void redrawTimer_Tick(object sender, EventArgs e)
        {
            if (this.Visible && this.WindowState != FormWindowState.Minimized)
                UpdateViews();

            NotifyOnActivity();
        }

        private void UpdateViews()
        {
            UpdateLobbiesView();
            UpdateHistoryView();
        }

        private void UpdateLobbiesView()
        {
            int totalLobbies = 0;
            int totalPlayers = 0;

            List<Lobby> sorted = new List<Lobby>();
            sorted.AddRange(lobbies.Values);
            sorted.Sort((a, b) => a.LobbyID.CompareTo(b.LobbyID));

            lobbiesView.BeginUpdate();
            lobbiesView.Items.Clear();

            foreach (var lobby in sorted)
            {
                if (lobby.Alive && ((DateTime.Now - lobby.UpdateTime).TotalSeconds <= options.LobbyUpdateInterval))
                {
                    var cols = new string[] { lobby.HostName, lobby.LevelName, lobby.GameMode.ToString(), lobby.NumPlayers.ToString() };
                    var item = new ListViewItem(cols);
                    lobbiesView.Items.Add(item);

                    ++totalLobbies;
                    totalPlayers += lobby.NumPlayers;
                }
            }

            lobbiesView.EndUpdate();

            bool trayActive = (totalPlayers >= options.TrayMinPlayers);
            trayIcon.Icon = trayActive ? RFGMP.Resources.hammer_on : RFGMP.Resources.hammer_ghost;
        }

        private void UpdateHistoryView()
        {
            List<Lobby> sorted = new List<Lobby>();
            sorted.AddRange(lobbies.Values);
            sorted.Sort((a, b) => a.UpdateTime.CompareTo(b.UpdateTime));

            histView.BeginUpdate();
            histView.Items.Clear();

            foreach (var lobby in sorted)
            {
                var dur = lobby.UpdateTime - lobby.CreateTime;
                int totalSec = (int)dur.TotalSeconds;
                int totalMin = (int)dur.TotalMinutes;
                string durStr = totalMin > 0 ? totalMin.ToString() + "m" : totalSec.ToString() + "s";
                var ts = lobby.UpdateTime.ToString("MM/dd HH:mm", CultureInfo.InvariantCulture) + " (" + durStr + ")";

                string playersStr = lobby.NumPlayers.ToString() + " (" + lobby.MaxPlayers.ToString() + ")";

                histView.Items.Add(new ListViewItem(new string[] { lobby.HostName, lobby.LevelName, lobby.GameMode.ToString(), playersStr, ts }));
            }

            histView.EndUpdate();
        }

        private void InitNotifier()
        {
            lastNotifTime = DateTime.Now.Subtract(new TimeSpan(0, 0, options.NotifyInterval));
        }

        private void NotifyOnActivity()
        {
            if (options.NotifyEnabled && ((DateTime.Now - lastNotifTime).TotalSeconds > options.NotifyInterval))
            {
                int numActivePlayers = 0;

                foreach (var lobby in lobbies.Values)
                {
                    // count only recently created lobbies
                    if (lobby.Alive && (DateTime.Now - lobby.CreateTime).TotalSeconds <= options.LobbyUpdateInterval)
                    {
                        numActivePlayers += lobby.NumPlayers;
                    }
                }

                if (numActivePlayers >= options.NotifyMinPlayers)
                {
                    Debug.WriteLine("NotifyOnActivity");
                    lastNotifTime = DateTime.Now;

                    //if (!!IsGameRunning())
                    {
                        trayIcon.Icon = RFGMP.Resources.hammer_on;
                        trayIcon.BalloonTipIcon = ToolTipIcon.None;
                        trayIcon.BalloonTipTitle = "";
                        trayIcon.BalloonTipText = "RFG alive!";
                        trayIcon.ShowBalloonTip(options.NotifyBalloonTimeout * 1000);
                    }
                }
            }
        }

        #endregion

        #region UTILS

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
            lobbyRequestTimer.Interval = options.LobbyRequestInterval * 1000;
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

        private bool IsGameRunning()
        {
            return Process.GetProcessesByName("rfg").Length > 0;
        }

        private void SetDoubleBuffered(ListView listView, bool value)
        {
            listView.GetType()
                .GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic)
                .SetValue(listView, value);
        }

        #endregion

        ///
    }
}
