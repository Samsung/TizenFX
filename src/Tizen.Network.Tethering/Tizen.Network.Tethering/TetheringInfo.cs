using System;

namespace Tizen.Network.Tethering
{
    // TODO: Impelement IDisposable Interface 
    public class TetheringExtInfo
    {
        private string _ssid;
        private string _password;

        public string SSID {
            get
            {
                return _ssid;
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
        }
   }
}
