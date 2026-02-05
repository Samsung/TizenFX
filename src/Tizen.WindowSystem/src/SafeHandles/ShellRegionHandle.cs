using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class ShellRegionHandle : SafeHandle
    {
        public ShellRegionHandle() : base(IntPtr.Zero, true)
        {
        }

        public ShellRegionHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.TizenShellRegion.Destroy(handle);
            return true;
        }
    }
}
