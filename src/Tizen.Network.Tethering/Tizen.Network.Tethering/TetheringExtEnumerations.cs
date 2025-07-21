using System;
using System.ComponentModel;


namespace Tizen.Network.Tethering
{
    public enum TetheringType
    {
        All = 0,
        USB = 1,
        WiFi = 2,
        BT = 3,
    }

    public enum TetheringDisabledCause
    {
        FlightMode = 1,
        LowBattery = 2,
        NetworkClose = 3,
        Timeout = 4,
        Others = 5,
        Request = 6,
        WiFiOn = 7,
    }
}
