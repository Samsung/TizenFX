using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class SoftkeyClientHandle : SafeHandle
    {
        public SoftkeyClientHandle() : base(IntPtr.Zero, true)
        {
        }

        public SoftkeyClientHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.SoftkeyClient.Destroy(handle);
            return true;
        }
    }
}
