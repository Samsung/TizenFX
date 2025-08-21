using System;

namespace Tizen.Network.Tethering
{
    /// <summary>
    /// This class contains information related to the connected/disconnected client.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringExtensionClient : IDisposable
    {
        IntPtr _client;
        private string _ipAddr;
        private string _macAddr;
        private string _hostname;
        private bool _disposed = false;

        internal TetheringExtensionClient(IntPtr client)
        {
            IntPtr clonedClient;
            int ret = Interop.TetheringExtension.CloneClient(out clonedClient, client);
            if (ret != (int)TetheringError.None) {
                Log.Error(Globals.LogTag, "Error cloning tethering ext client: " + (TetheringError)ret);
            }
            _client = clonedClient;
        }

        /// <summary>
        /// Destructor function for the class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        ~TetheringExtensionClient()
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

            Log.Info(Globals.LogTag, "TetheringExtensionClient Handle HashCode: " + _client.GetHashCode());
            int ret = Interop.TetheringExtension.ClientDestroy(_client);
            if (ret == (int)TetheringError.None)
            {
                _client = IntPtr.Zero;
            }
            _disposed = true;
        }

        /// <summary>
        /// This method returns the IP Address of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string GetIPAddress()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid TetheringExtension client instance(Object may have been disposed or released)");
            }
            string ipAddr;
            int ret = Interop.TetheringExtension.ClientGetIPAddr(_client, out ipAddr);
            if (ret != (int)TetheringError.None)
            {
                Log.Error(Globals.LogTag, "Error getting IP Address from client: " + (TetheringError)ret);
                TetheringErrorFactory.ThrowTetheringException(ret, "Error getting IP Address from client");
            }
            _ipAddr = ipAddr;
            return _ipAddr;
        }

        /// <summary>
        /// This method returns the MAC Address of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string GetMacAddress()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid TetheringExtension client instance(Object may have been disposed or released)");
            }
            string macAddr;
            int ret = Interop.TetheringExtension.ClientGetMacAddr(_client, out macAddr);
            if (ret != (int)TetheringError.None) {
                Log.Error(Globals.LogTag, "Error getting Mac Address from client: " + (TetheringError)ret);
                TetheringErrorFactory.ThrowTetheringException(ret, "Error getting Mac Address from client");
            }
            _macAddr = macAddr;
            return _macAddr;
        }

        /// <summary>
        /// This method returns the Hostname of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string GetHostname()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException("Invalid TetheringExtension client instance(Object may have been disposed or released)");
            }
            string hostname;
            int ret = Interop.TetheringExtension.ClientGetName(_client, out hostname);
            if (ret != (int)TetheringError.None) {
                Log.Error(Globals.LogTag, "Error getting hostname from client: " + (TetheringError)ret);
                TetheringErrorFactory.ThrowTetheringException(ret, "Error getting hostname from client");
            }
            _hostname = hostname;
            return _hostname;
        }
    }
}
