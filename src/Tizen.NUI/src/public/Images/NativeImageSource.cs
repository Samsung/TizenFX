/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System.ComponentModel;

namespace Tizen.NUI
{
    using global::System;

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NativeImageSource : NativeImageInterface
    {
        private IntPtr handle;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public NativeImageSource(uint width, uint height, ColorDepth depth) : this(Interop.NativeImageSource.NewHandle(width, height, (int)depth), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal NativeImageSource(IntPtr cPtr, bool cMemoryOwn) : base(Interop.NativeImageSource.New(cPtr), cMemoryOwn)
        {
            handle = cPtr;
        }

        /// <summary>
        /// Get URI from native image source.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                string uri = "";
                uri = Interop.NativeImageSource.GenerateUrl(this.SwigCPtr.Handle);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return uri;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NativeImageSource.Delete(handle);
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
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public IntPtr AcquireBuffer(ref int width, ref int height, ref int stride)
        {
            IntPtr ret = Interop.NativeImageSource.AcquireBuffer(this.SwigCPtr.Handle, ref width, ref height, ref stride);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReleaseBuffer()
        {
            bool ret = Interop.NativeImageSource.ReleaseBuffer(this.SwigCPtr.Handle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
