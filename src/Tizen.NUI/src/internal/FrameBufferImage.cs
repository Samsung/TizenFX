/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    internal class FrameBufferImage : Image
    {

        internal FrameBufferImage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.FrameBufferImage.FrameBufferImage_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(FrameBufferImage obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.FrameBufferImage.delete_FrameBufferImage(swigCPtr);
        }

        public FrameBufferImage(uint width, uint height, PixelFormat pixelFormat, RenderBufferFormat bufferFormat) : this(Interop.FrameBufferImage.FrameBufferImage_New__SWIG_0(width, height, (int)pixelFormat, (int)bufferFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage(uint width, uint height, PixelFormat pixelFormat) : this(Interop.FrameBufferImage.FrameBufferImage_New__SWIG_1(width, height, (int)pixelFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage(uint width, uint height) : this(Interop.FrameBufferImage.FrameBufferImage_New__SWIG_2(width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage(uint width) : this(Interop.FrameBufferImage.FrameBufferImage_New__SWIG_3(width), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage() : this(Interop.FrameBufferImage.FrameBufferImage_New__SWIG_4(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage(NativeImageInterface image) : this(Interop.FrameBufferImage.FrameBufferImage_New__SWIG_5(NativeImageInterface.getCPtr(image)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new static FrameBufferImage DownCast(BaseHandle handle)
        {
            FrameBufferImage ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as FrameBufferImage;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public FrameBufferImage(FrameBufferImage handle) : this(Interop.FrameBufferImage.new_FrameBufferImage__SWIG_1(FrameBufferImage.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public FrameBufferImage Assign(FrameBufferImage rhs)
        {
            FrameBufferImage ret = new FrameBufferImage(Interop.FrameBufferImage.FrameBufferImage_Assign(swigCPtr, FrameBufferImage.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
