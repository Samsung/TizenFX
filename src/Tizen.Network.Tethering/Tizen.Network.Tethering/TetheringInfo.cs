using System;

namespace Tizen.Network.Tethering
{
    public class TetheringInfo
    {
        private IntPtr _info;
        internal TetheringInfo(IntPtr tetheringInfo)
        {
            _info = tetheringInfo;
        }
   }
}
