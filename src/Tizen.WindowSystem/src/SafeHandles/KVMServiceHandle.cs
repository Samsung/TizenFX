using System;
using System.Runtime.InteropServices;


namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class KVMServiceHandle : SafeHandle
    {
        public KVMServiceHandle() : base(IntPtr.Zero, true)
        {
        }

        public KVMServiceHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.KVMService.Destroy(handle);
            return true;
        }
    }
}
