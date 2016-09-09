using System;

namespace Tizen.Multimedia
{
    [Flags]
    public enum MediaPacketBufferFlags
    {
        CodecConfig = 0x1,
        EndOfStream = 0x2,
        SyncFrame = 0x4,
    }
}
