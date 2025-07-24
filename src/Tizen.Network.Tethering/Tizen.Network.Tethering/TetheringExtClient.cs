using System;

namespace Tizen.Network.TetheringExt
{
    // TODO: Impelement IDisposable Interface 
    public class TetheringExtClient
    {
        private TetheringType _interface;
        private string _ipAddr;
        private string _macAddr;
        private string _hostname;

        public TetheringExtClient Clone()
        {
            TetheringExtClient clone = new TetheringExtClient();
            clone._interface = this._interface;
            clone._ipAddr = this._ipAddr;
            clone._macAddr = this._macAddr;
            clone._hostname = this._hostname;
            return clone;
        }

        public string IPAddress
        {
            get
            {
                return _ipAddr;
            }
        }

        public string MacAddress
        {
            get
            {
                return _macAddr;
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
