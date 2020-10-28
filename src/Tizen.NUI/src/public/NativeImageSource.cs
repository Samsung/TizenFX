
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    using global::System;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NativeImageSource : NativeImageInterface
    {

        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageSource(uint width, uint height, ColorDepth depth) : this(Interop.NativeImageSource.NewHandle(width, height, (int)depth), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private IntPtr Handle;
        internal NativeImageSource(IntPtr cPtr, bool cMemoryOwn) : base(Interop.NativeImageSource.Upcast(Interop.NativeImageSource.New(cPtr)), cMemoryOwn)
        {
            Handle = cPtr;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NativeImageSource.Delete(Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ColorDepth
        {
            Default,
            Bits8,
            Bits16,
            Bits24,
            Bits32,
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NativeImageSource obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr AcquireBuffer(ref int width, ref int height, ref int stride) {
            IntPtr ret = Interop.NativeImageSource.AcquireBuffer(this.swigCPtr.Handle, ref width, ref height, ref stride);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReleaseBuffer() {
            bool ret = Interop.NativeImageSource.ReleaseBuffer(this.swigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}