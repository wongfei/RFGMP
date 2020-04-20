using System;
using System.ComponentModel;

namespace RFGMP
{
    public class Stats
    {
        // counters
        public int RequestLobbyListCount { get; set; }
        public int OnLobbyMatchListCount { get; set; }
        public int RequestLobbyDataCount { get; set; }
        public int OnLobbyDataUpdateCount { get; set; }
        public int NumNotifications { get; set; }

        // records
        public int MaxLiveLobbies { get; set; }
        public int MaxLivePlayers { get; set; }
        public int MaxMatchDuration { get; set; } // sec
    }
}
