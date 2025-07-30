using System;

namespace Tizen.Network.Tethering
{
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        private TetheringExtClient _client;
        private bool _opened = false;

        internal ConnectionStateChangedEventArgs(TetheringExtClient client, bool opened)
        {
            _client = client;
            _opened = opened;
        }

        public TetheringExtClient Client {
            get
            {
                return _client;
            }
        }

        public bool isOpened {
            get
            {
                return _opened;
            }
        }
    } 
}
