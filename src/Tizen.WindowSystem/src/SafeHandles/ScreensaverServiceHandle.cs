using System;
using System.Runtime.InteropServices;


namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class ScreensaverServiceHandle : SafeHandle
    {
        public ScreensaverServiceHandle() : base(IntPtr.Zero, true)
        {
        }

        public ScreensaverServiceHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.ScreensaverService.Destroy(handle);
            return true;
        }
    }
}
