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
    internal class BufferImage : Image
    {

        internal BufferImage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.BufferImage.BufferImage_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(BufferImage obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.BufferImage.delete_BufferImage(swigCPtr);
        }

        public BufferImage(uint width, uint height, PixelFormat pixelformat) : this(Interop.BufferImage.BufferImage_New__SWIG_0(width, height, (int)pixelformat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public BufferImage(uint width, uint height) : this(Interop.BufferImage.BufferImage_New__SWIG_1(width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public BufferImage(byte[] pixelBuffer, uint width, uint height, PixelFormat pixelFormat, uint stride) : this(Interop.BufferImage.BufferImage_New__SWIG_2(pixelBuffer, width, height, (int)pixelFormat, stride), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public BufferImage(byte[] pixelBuffer, uint width, uint height, PixelFormat pixelFormat) : this(Interop.BufferImage.BufferImage_New__SWIG_3(pixelBuffer, width, height, (int)pixelFormat), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public BufferImage(byte[] pixelBuffer, uint width, uint height) : this(Interop.BufferImage.BufferImage_New__SWIG_4(pixelBuffer, width, height), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new static BufferImage DownCast(BaseHandle handle)
        {
            BufferImage ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as BufferImage;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public BufferImage(BufferImage handle) : this(Interop.BufferImage.new_BufferImage__SWIG_1(BufferImage.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public BufferImage Assign(BufferImage rhs)
        {
            BufferImage ret = new BufferImage(Interop.BufferImage.BufferImage_Assign(swigCPtr, BufferImage.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static BufferImage WHITE()
        {
            BufferImage ret = new BufferImage(Interop.BufferImage.BufferImage_WHITE(), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_unsigned_char GetBuffer()
        {
            global::System.IntPtr cPtr = Interop.BufferImage.BufferImage_GetBuffer(swigCPtr);
            SWIGTYPE_p_unsigned_char ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_char(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetBufferSize()
        {
            uint ret = Interop.BufferImage.BufferImage_GetBufferSize(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetBufferStride()
        {
            uint ret = Interop.BufferImage.BufferImage_GetBufferStride(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public PixelFormat GetPixelFormat()
        {
            PixelFormat ret = (PixelFormat)Interop.BufferImage.BufferImage_GetPixelFormat(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Update()
        {
            Interop.BufferImage.BufferImage_Update__SWIG_0(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Update(SWIGTYPE_p_Dali__RectT_unsigned_int_t updateArea)
        {
            Interop.BufferImage.BufferImage_Update__SWIG_1(swigCPtr, SWIGTYPE_p_Dali__RectT_unsigned_int_t.getCPtr(updateArea));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool IsDataExternal()
        {
            bool ret = Interop.BufferImage.BufferImage_IsDataExternal(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
