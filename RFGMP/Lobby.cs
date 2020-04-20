using System;
using Steamworks;

namespace RFGMP
{
    public enum EGameMode
    {
        Unknown = 0,
        Anarchy = 1,
        TeamAnarchy = 2,
        CaptureTheFlag = 3,
        Siege = 4,
        DamageControl = 5,
        Bagman = 6,
        TeamBagman = 7,
        Demolition = 8
    }

    public class Lobby
    {
        public CSteamID LobbyID;
        public string HostName;
        public string LevelName;
        public EGameMode GameMode;
        public int NumPlayers;
        public int MaxPlayers;
        public DateTime CreateTime;
        public DateTime UpdateTime;
        public bool Alive;
        public bool UpdatePending;
        public bool UserNotified;

        public Lobby(ulong rawID)
        {
            LobbyID = new CSteamID(rawID);
            CreateTime = DateTime.Now;
        }

        public void ReadLobbyData()
        {
            string hostplayernameData = SteamMatchmaking.GetLobbyData(LobbyID, "hostplayername");
            string levelnameData = SteamMatchmaking.GetLobbyData(LobbyID, "levelname");
            string gamemodeData = SteamMatchmaking.GetLobbyData(LobbyID, "gamemode");

            HostName = string.IsNullOrEmpty(hostplayernameData) ? "" : hostplayernameData;
            LevelName = ParseLevelName(levelnameData);
            GameMode = ParseGameMode(gamemodeData);

            NumPlayers = SteamMatchmaking.GetNumLobbyMembers(LobbyID);
            MaxPlayers = Math.Max(MaxPlayers, NumPlayers);

            UpdateTime = DateTime.Now;
            Alive = true;
            UpdatePending = false;

            /*int dataCount = SteamMatchmaking.GetLobbyDataCount(lobbyID);
            for (int i = 0; i < dataCount; i++)
            {
                string Key;
                string Value;
                SteamMatchmaking.GetLobbyDataByIndex(lobbyID, i, out Key, 255, out Value, 255);
                Debug.WriteLine("Data#" + i + ": " + Key + " -> " + Value);
            }*/
        }

        public void MarkDead()
        {
            Alive = false;
            UpdatePending = false;
            UserNotified = false;
        }

        public bool IsValid()
        {
            return (
                !string.IsNullOrEmpty(HostName)
                && !string.IsNullOrEmpty(LevelName)
                && GameMode != EGameMode.Unknown);
        }

        public override string ToString()
        {
            return HostName + " ; " + LevelName + " ; " + GameMode.ToString();
        }

        public static EGameMode ParseGameMode(string value)
        {
            switch (value) // LOL, indian style
            {
                case "1": return EGameMode.Anarchy;
                case "2": return EGameMode.TeamAnarchy;
                case "3": return EGameMode.CaptureTheFlag;
                case "4": return EGameMode.Siege;
                case "5": return EGameMode.DamageControl;
                case "6": return EGameMode.Bagman;
                case "7": return EGameMode.TeamBagman;
                case "8": return EGameMode.Demolition;
            }
            return EGameMode.Unknown;
        }

        public static string ParseLevelName(string value)
        {
            if (string.IsNullOrEmpty(value)) return "";
            value = value.Replace("MENU_LEVEL_", "").Replace("MENU_WRECKING_CREW_MAP_NAME_", "");
            switch (value)
            {
                case "WC1": value = "COMPLEX"; break;
                case "WC2": value = "WATCH TOWER"; break;
                case "WC3": value = "SCRAPHEAP"; break;
                case "WC4": value = "VISTA"; break;
                case "WC5": value = "FORTRESS"; break;
                case "WC6": value = "FACTORY"; break;
                case "WC7": value = "GULCH"; break;
                case "WC8": value = "CASCADE"; break;
                case "WC9": value = "TRANSMISSION"; break;
                case "WC10": value = "PIPELINE"; break;
            }
            return value;
        }
    }
}
