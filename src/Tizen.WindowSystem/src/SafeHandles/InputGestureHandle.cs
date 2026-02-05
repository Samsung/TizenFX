using System;
using System.Runtime.InteropServices;
using Tizen.WindowSystem;



namespace Tizen.WindowSystem.SafeHandles
{
    internal class InputGestureHandle : SafeHandle
    {
        public InputGestureHandle() : base(IntPtr.Zero, true)
        {
        }

        public InputGestureHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Tizen.WindowSystem.Interop.InputGesture.Deinitialize(handle);
            return true;
        }
    }
}
