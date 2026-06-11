using System;
using System.Runtime.InteropServices;
using Tizen.WindowSystem;



namespace Tizen.WindowSystem.SafeHandles
{
    internal sealed class InputGeneratorHandle : SafeHandle
    {
        private readonly int _creationThreadId;

        public InputGeneratorHandle() : base(IntPtr.Zero, true)
        {
            _creationThreadId = Environment.CurrentManagedThreadId;
        }

        public InputGeneratorHandle(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle)
        {
            SetHandle(handle);
            _creationThreadId = Environment.CurrentManagedThreadId;
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            if (Environment.CurrentManagedThreadId != _creationThreadId)
            {
                Tizen.Log.Error("Tizen.WindowSystem", "InputGeneratorHandle: ReleaseHandle called from a different thread or finalizer. Wayland resource destruction is thread-affine and must be done on the creation thread. Skipping cleanup to avoid crash.");
                return true;
            }
            Tizen.WindowSystem.Interop.InputGenerator.Destroy(handle);
            return true;
        }
    }
}
