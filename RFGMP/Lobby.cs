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
        public EGameMode GameMode;
        public string LevelName;
        public int NumPlayers;

        public Lobby(CSteamID ID)
        {
            LobbyID = ID;

            string hostplayernameStr = SteamMatchmaking.GetLobbyData(LobbyID, "hostplayername");
            string gamemodeStr = SteamMatchmaking.GetLobbyData(LobbyID, "gamemode");
            string levelnameStr = SteamMatchmaking.GetLobbyData(LobbyID, "levelname");

            HostName = hostplayernameStr;
            GameMode = ParseGameMode(gamemodeStr);
            LevelName = levelnameStr.Replace("MENU_LEVEL_", "");

            NumPlayers = SteamMatchmaking.GetNumLobbyMembers(LobbyID);
        }

        public override string ToString()
        {
            return
                LobbyID.m_SteamID.ToString() + " ; " +
                HostName + " ; " +
                GameMode.ToString() + " ; " +
                LevelName + " ; " +
                NumPlayers.ToString()
                ;
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

    public class PersistentLobby
    {
        public string HostName;
        public EGameMode GameMode;
        public string LevelName;
        public int NumPlayers;
        public int MaxPlayers;
        public DateTime CreateDate;
        public DateTime UpdateDate;
        public bool IsNew;
    }
}
