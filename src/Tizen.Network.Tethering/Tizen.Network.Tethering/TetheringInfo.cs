using System;
using System.Runtime.InteropServices;


namespace Tizen.Network.Tethering
{

    /// <summary>
    /// This class contains tethering info.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringInfo
    {
        private string _ssid;
        private string _passphrase;

        internal TetheringInfo(IntPtr tetheringInfoPtr)
        {
            TetheringInfoStruct infoStruct = Marshal.PtrToStructure<TetheringInfoStruct>(tetheringInfoPtr);
            _ssid = infoStruct._ssid;
            _passphrase = infoStruct._passphrase;
    }

        /// <summary>
        /// Gets the IP Address of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Ssid
        {
            get
            {
                return _ssid;
            }
        }
        /// <summary>
        /// Gets the IP Address of the connected/disconnected client.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public string Passphrase
        {
            get
            {
                return _passphrase;
            }
        }
   }
}
