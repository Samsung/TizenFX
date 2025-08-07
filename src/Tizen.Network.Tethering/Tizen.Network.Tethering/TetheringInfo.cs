using System;

namespace Tizen.Network.Tethering
{

    /// <summary>
    /// This class contains tethering info.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    public class TetheringInfo
    {
        private IntPtr _info;
        internal TetheringInfo(IntPtr tetheringInfo)
        {
            _info = tetheringInfo;
        }
   }
}
