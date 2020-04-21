using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RFGMP
{
    public class Options
    {
        //[Browsable(bool)] to show property or not
        //[ReadOnly(bool)] possibility to edit property
        //[Category(string)] groups of property
        //[Description(string)] property description.It is something like a hint.
        //[DisplayName(string)] display property

        [Category("App")]
        public bool UpdateWhilePlaying { get; set; } = true;

        [Category("App")]
        [Range(1, 3600)]
        public int LobbyRequestInterval { get; set; } = 30; // sec

        [Category("App")]
        [Range(1, 3600)]
        public int LobbyUpdateInterval { get; set; } = 5; // sec

        // NOTIFY

        [Category("Notify")]
        public bool NotifyEnabled { get; set; } = false;

        [Category("Notify")]
        [Range(1, 3600)]
        public int NotifyInterval { get; set; } = 5 * 60; // sec

        [Category("Notify")]
        [Range(1, 3600)]
        public int NotifyBalloonTimeout { get; set; } = 1; // sec

        [Category("Notify")]
        [Range(1, 3600)]
        public int NotifyMinLobbyDuration { get; set; } = 10; // sec

        [Category("Notify")]
        [Range(0, int.MaxValue)]
        public int NotifyMinPlayers { get; set; } = 1;

        // TRAY

        [Category("Tray")]
        [Range(0, int.MaxValue)]
        public int TrayMinPlayers { get; set; } = 1;

        // ADVANCED

        [Category("Advanced")]
        [Range(100, 1000)]
        public int SteamTickMs { get; set; } = 200; // millisec

        [Category("Advanced")]
        [Range(100, 10000)]
        public int RedrawTickMs { get; set; } = 1000; // millisec
    }
}
