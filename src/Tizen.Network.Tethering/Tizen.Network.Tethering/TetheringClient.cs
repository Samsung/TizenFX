using System;

namespace Tizen.Network.Tethering
{
    // TODO: Impelement IDisposable Interface 
    public class TetheringClient
    {
        private TetheringType _interface;
        private string _ip_addr;
        private string _mac_addr;
        private string _hostname;

        public TetheringClient Clone()
        {
            TetheringClient clone = new TetheringClient();
            clone._interface = this._interface;
            clone._ip_addr = this._ip_addr;
            clone._mac_addr = this._mac_addr;
            clone._hostname = this._hostname;
            return clone;
        }

        public string IPAddress
        {
            get
            {
                return _ip_addr;
            }
        }

        public string MacAddress
        {
            get
            {
                return _ip_addr;
            }
        }

        public string Hostname
        {
            get
            {
                return _hostname;
            }
        }
    }
}