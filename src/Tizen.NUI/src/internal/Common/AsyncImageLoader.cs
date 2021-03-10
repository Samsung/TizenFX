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

namespace Tizen.NUI
{
    internal class AsyncImageLoader : BaseHandle
    {
        internal AsyncImageLoader(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AsyncImageLoader obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.AsyncImageLoader.DeleteAsyncImageLoader(swigCPtr);
        }

        public AsyncImageLoader() : this(Interop.AsyncImageLoader.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }
        public AsyncImageLoader(AsyncImageLoader handle) : this(Interop.AsyncImageLoader.NewAsyncImageLoader(AsyncImageLoader.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public AsyncImageLoader Assign(AsyncImageLoader handle)
        {
            AsyncImageLoader ret = new AsyncImageLoader(Interop.AsyncImageLoader.Assign(SwigCPtr, AsyncImageLoader.getCPtr(handle)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public static AsyncImageLoader DownCast(BaseHandle handle)
        {
            AsyncImageLoader ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as AsyncImageLoader;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint Load(string url)
        {
            uint ret = Interop.AsyncImageLoader.Load(SwigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint Load(string url, Uint16Pair dimensions)
        {
            uint ret = Interop.AsyncImageLoader.Load(SwigCPtr, url, Uint16Pair.getCPtr(dimensions));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint Load(string url, Uint16Pair dimensions, FittingModeType fittingMode, SamplingModeType samplingMode, bool orientationCorrection)
        {
            uint ret = Interop.AsyncImageLoader.Load(SwigCPtr, url, Uint16Pair.getCPtr(dimensions), (int)fittingMode, (int)samplingMode, orientationCorrection);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool Cancel(uint loadingTaskId)
        {
            bool ret = Interop.AsyncImageLoader.Cancel(SwigCPtr, loadingTaskId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void CancelAll()
        {
            Interop.AsyncImageLoader.CancelAll(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public SWIGTYPE_p_Dali__SignalT_void_fuint32_t_Dali__PixelDataF_t ImageLoadedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fuint32_t_Dali__PixelDataF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fuint32_t_Dali__PixelDataF_t(Interop.AsyncImageLoader.ImageLoadedSignal(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
