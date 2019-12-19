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
    internal class EncodedBufferImage : Image
    {

        internal EncodedBufferImage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.BufferImage.EncodedBufferImage_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(EncodedBufferImage obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.BufferImage.delete_EncodedBufferImage(swigCPtr);
        }

        public EncodedBufferImage(SWIGTYPE_p_uint8_t encodedImage, uint encodedImageByteCount) : this(Interop.BufferImage.EncodedBufferImage_New__SWIG_0(SWIGTYPE_p_uint8_t.getCPtr(encodedImage), encodedImageByteCount), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public EncodedBufferImage(SWIGTYPE_p_uint8_t encodedImage, uint encodedImageByteCount, Uint16Pair size, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection) : this(Interop.BufferImage.EncodedBufferImage_New__SWIG_1(SWIGTYPE_p_uint8_t.getCPtr(encodedImage), encodedImageByteCount, Uint16Pair.getCPtr(size), (int)fittingMode, (int)samplingMode, orientationCorrection), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public EncodedBufferImage(SWIGTYPE_p_uint8_t encodedImage, uint encodedImageByteCount, Uint16Pair size, FittingModeType fittingMode, SamplingModeType samplingMode) : this(Interop.BufferImage.EncodedBufferImage_New__SWIG_2(SWIGTYPE_p_uint8_t.getCPtr(encodedImage), encodedImageByteCount, Uint16Pair.getCPtr(size), (int)fittingMode, (int)samplingMode), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public new static EncodedBufferImage DownCast(BaseHandle handle)
        {
            EncodedBufferImage ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as EncodedBufferImage;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public EncodedBufferImage(EncodedBufferImage handle) : this(Interop.BufferImage.new_EncodedBufferImage__SWIG_1(EncodedBufferImage.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public EncodedBufferImage Assign(EncodedBufferImage rhs)
        {
            EncodedBufferImage ret = new EncodedBufferImage(Interop.BufferImage.EncodedBufferImage_Assign(swigCPtr, EncodedBufferImage.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
