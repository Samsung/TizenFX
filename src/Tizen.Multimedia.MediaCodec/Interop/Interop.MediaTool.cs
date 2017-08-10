using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia.MediaCodec
{
    internal static partial class Interop
    {
        internal static class MediaPacket
        {
            [DllImport(Libraries.MediaTool, EntryPoint = "media_packet_destroy")]
            internal static extern int Destroy(IntPtr handle);
        }
    }
}
