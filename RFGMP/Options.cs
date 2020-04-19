using System.ComponentModel;

namespace RFGMP
{
    public class Options
    {
        //[Browsable(bool)] – to show property or not
        //[ReadOnly(bool)] – possibility to edit property
        //[Category(string)] – groups of property
        //[Description(string)] – property description.It is something like a hint.
        //[DisplayName(string)] – display property
        //[Range(10, 1000)]
        //[IntegerValidator(MinValue = 10, MaxValue = 1000)]

        [Category("App")]
        public bool AutostartEnabled { get; set; } = false;

        [Category("App")]
        public bool UpdateWhilePlaying { get; set; } = true;

        [Category("App")]
        public int LobbyRequestInterval { get; set; } = 30;

        [Category("App")]
        public int LobbyUpdateInterval { get; set; } = 10;

        // NOTIFY

        [Category("Notify")]
        public bool NotifyEnabled { get; set; } = true;

        [Category("Notify")]
        public int NotifyBalloonTimeout { get; set; } = 1;

        [Category("Notify")]
        public int NotifyInterval { get; set; } = 60;

        [Category("Notify")]
        public int NotifyMinPlayers { get; set; } = 1;

        // TRAY

        [Category("Tray")]
        public int TrayMinPlayers { get; set; } = 1;

        // ADVANCED

        [Category("Advanced")]
        public int SteamTickMs { get; set; } = 200;
    }
}
