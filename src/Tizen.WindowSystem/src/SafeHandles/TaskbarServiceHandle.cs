using System;
using System.Runtime.InteropServices;

namespace Tizen.WindowSystem.Shell.SafeHandles
{
    internal class TaskbarServiceHandle : SafeHandle
    {
        public TaskbarServiceHandle() : base(IntPtr.Zero, true)
        {
        }

        public TaskbarServiceHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Interop.TaskbarService.Destroy(handle);
            return true;
        }
    }
}
