using System;
using System.Runtime.InteropServices;
using Tizen.Internals;



namespace Tizen.Network.Tethering
{
    [NativeStruct("_tethering_ext_tethering_info", Include="tethering_ext_internal.h", PkgConfig="capi-network-tethering")]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TetheringInfoStruct
    {
        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _ssid;

        [MarshalAsAttribute(UnmanagedType.LPStr)]
        internal string _passphrase;
    }
}
