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

        public Lobby(ulong rawID)
        {
            LobbyID = new CSteamID(rawID);
            CreateTime = DateTime.Now;
            ReadLobbyData();
        }

        public void ReadLobbyData()
        {
            string hostplayernameData = SteamMatchmaking.GetLobbyData(LobbyID, "hostplayername");
            string levelnameData = SteamMatchmaking.GetLobbyData(LobbyID, "levelname");
            string gamemodeData = SteamMatchmaking.GetLobbyData(LobbyID, "gamemode");

            HostName = string.IsNullOrEmpty(hostplayernameData) ? "" : hostplayernameData;
            LevelName = string.IsNullOrEmpty(levelnameData) ? "" : levelnameData.Replace("MENU_LEVEL_", "");
            GameMode = ParseGameMode(gamemodeData);

            NumPlayers = SteamMatchmaking.GetNumLobbyMembers(LobbyID);
            MaxPlayers = Math.Max(MaxPlayers, NumPlayers);

            UpdateTime = DateTime.Now;
            Alive = true;

            /*int dataCount = SteamMatchmaking.GetLobbyDataCount(lobbyID);
            for (int i = 0; i < dataCount; i++)
            {
                string Key;
                string Value;
                SteamMatchmaking.GetLobbyDataByIndex(lobbyID, i, out Key, 255, out Value, 255);
                Debug.WriteLine("Data#" + i + ": " + Key + " -> " + Value);
            }*/
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

        public static EGameMode ParseGameMode(string Value)
        {
            switch (Value) // LOL, indian style
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
    }
}
