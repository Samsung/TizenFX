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
    internal class NativeImage : Image
    {

        internal NativeImage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.NativeImageInterface.NativeImage_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NativeImage obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.NativeImageInterface.delete_NativeImage(swigCPtr);
        }

        public NativeImage(NativeImageInterface nativeImageInterface) : this(Interop.NativeImageInterface.NativeImage_New(NativeImageInterface.getCPtr(nativeImageInterface)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public NativeImage(NativeImage handle) : this(Interop.NativeImageInterface.new_NativeImage__SWIG_1(NativeImage.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public NativeImage Assign(NativeImage rhs)
        {
            NativeImage ret = new NativeImage(Interop.NativeImageInterface.NativeImage_Assign(swigCPtr, NativeImage.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void CreateGlTexture()
        {
            Interop.NativeImageInterface.NativeImage_CreateGlTexture(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new static NativeImage DownCast(BaseHandle handle)
        {
            NativeImage ret =  Registry.GetManagedBaseHandleFromNativePtr(handle) as NativeImage;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetCustomFragmentPreFix()
        {
            string ret = Interop.NativeImageInterface.NativeImage_GetCustomFragmentPreFix(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public string GetCustomSamplerTypename()
        {
            string ret = Interop.NativeImageInterface.NativeImage_GetCustomSamplerTypename(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
