using System;
using System.Runtime.InteropServices;
using Tizen.WindowSystem;



namespace Tizen.WindowSystem.SafeHandles
{
    internal class InputGeneratorHandle : SafeHandle
    {
        public InputGeneratorHandle() : base(IntPtr.Zero, true)
        {
        }

        public InputGeneratorHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            Tizen.WindowSystem.Interop.InputGenerator.Deinit(handle);
            return true;
        }
    }
}
