using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// This class contains information related to the connected/disconnected client.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringExtClient : IDisposable
    {
        IntPtr _client;
        private string _ipAddr;
        private string _macAddr;
        private string _hostname;
        private bool _disposed = false;

        internal TetheringExtClient(IntPtr client)
        {
            IntPtr clonedClient;
            int ret = Interop.TetheringExt.CloneClient(out clonedClient, client);
            if (ret != (int)TetheringError.None) {
                Log.Error(Globals.LogTag, "Error cloning tethering ext client: " + (TetheringError)ret);
            }
            _client = clonedClient;
        }

        /// <summary>
        /// Destructor function for the class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        ~TetheringExtClient()
        {
            Dispose(false);
        }

        /// <summary>
        /// This method releases unmanage resources and do other clean up opearations.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            Log.Info(Globals.LogTag, "TetheringExtClient Handle HashCode: " + _client.GetHashCode());
            int ret = Interop.TetheringExt.ClientDestroy(_client);
            if (ret == (int)TetheringError.None)
            {
                _client = IntPtr.Zero;
            }
            _disposed = true;
        }

        /// <summary>
        /// This function returns the IP Address of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string IPAddress
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid TetheringExt client instance(Object may have been disposed or released)");
                }
                string ipAddr;
                int ret = Interop.TetheringExt.ClientGetIPAddr(_client, out ipAddr);
                if (ret != (int)TetheringError.None)
                {
                    Log.Error(Globals.LogTag, "Error getting IP Address from client: " + (TetheringError)ret);
                    TetheringErrorFactory.ThrowTetheringException(ret, "Error getting IP Address from client");
                }
                _ipAddr = ipAddr;
                return _ipAddr;
            }
        }

        /// <summary>
        /// This function returns the MAC Address of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string MacAddress
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid TetheringExt client instance(Object may have been disposed or released)");
                }
                string macAddr;
                int ret = Interop.TetheringExt.ClientGetMacAddr(_client, out macAddr);
                if (ret != (int)TetheringError.None) {
                    Log.Error(Globals.LogTag, "Error getting Mac Address from client: " + (TetheringError)ret);
                    TetheringErrorFactory.ThrowTetheringException(ret, "Error getting Mac Address from client");
                }
                _macAddr = macAddr;
                return _macAddr;
            }
        }

        /// <summary>
        /// This function returns the Hostname of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Hostname
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException("Invalid TetheringExt client instance(Object may have been disposed or released)");
                }
                string hostname;
                int ret = Interop.TetheringExt.ClientGetName(_client, out hostname);
                if (ret != (int)TetheringError.None) {
                    Log.Error(Globals.LogTag, "Error getting hostname from client: " + (TetheringError)ret);
                    TetheringErrorFactory.ThrowTetheringException(ret, "Error getting hostname from client");
                }
                _hostname = hostname;
                return _hostname;
            }
        }
    }
}
