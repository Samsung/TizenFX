using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class QuickPanelServiceHandle : SafeHandle
    {
        public QuickPanelServiceHandle() : base(IntPtr.Zero, true)
        {
        }

        public QuickPanelServiceHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.QuickPanelService.Destroy(handle);
            return true;
        }
    }
}
