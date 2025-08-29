using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// This class contains information related to <see cref="TetheringExtensionManager.ConnectionStateChanged"/>.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class ConnectionStateChangedEventArgs : EventArgs
    {
        private TetheringExtensionClient _client;
        private bool _opened = false;

        internal ConnectionStateChangedEventArgs(TetheringExtensionClient client, bool opened)
        {
            _client = client;
            _opened = opened;
        }

        /// <summary>
        /// Gets TetheringExtensionClient which contains information of the connected or disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public TetheringExtensionClient Client {
            get
            {
                return _client;
            }
        }

        /// <summary>
        /// Gets whether the connection is opened or not.
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
