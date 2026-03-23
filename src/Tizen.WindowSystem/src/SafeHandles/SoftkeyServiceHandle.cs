using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class SoftkeyServiceHandle : SafeHandle
    {
        public SoftkeyServiceHandle() : base(IntPtr.Zero, true)
        {
        }

        public SoftkeyServiceHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.SoftkeyService.Destroy(handle);
            return true;
        }
    }
}
