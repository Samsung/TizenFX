using System;
using System.Runtime.InteropServices;


namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class TizenShellHandle : SafeHandle
    {
        public TizenShellHandle() : base(IntPtr.Zero, true)
        {
        }

        public TizenShellHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.TizenShell.Destroy(handle);
            return true;
        }
    }
}
