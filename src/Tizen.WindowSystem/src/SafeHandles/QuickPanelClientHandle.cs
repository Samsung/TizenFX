using System;
using System.Runtime.InteropServices;


namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class QuickPanelClientHandle : SafeHandle
    {
        public QuickPanelClientHandle() : base(IntPtr.Zero, true)
        {
        }

        public QuickPanelClientHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.QuickPanelClient.Destroy(handle);
            return true;
        }
    }
}
