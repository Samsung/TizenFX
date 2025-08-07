using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// This class contains information related to Connection State.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        private TetheringExtClient _client;
        private bool _opened = false;

        internal ConnectionStateChangedEventArgs(TetheringExtClient client, bool opened)
        {
            _client = client;
            _opened = opened;
        }

        /// <summary>
        /// This method returs TetheringExtClient which contains information of the connected or disconected client
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public TetheringExtClient Client {
            get
            {
                return _client;
            }
        }

        /// <summary>
        /// This method contains information of the connected or disconected client
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public bool isOpened {
            get
            {
                return _opened;
            }
        }
    } 
}
