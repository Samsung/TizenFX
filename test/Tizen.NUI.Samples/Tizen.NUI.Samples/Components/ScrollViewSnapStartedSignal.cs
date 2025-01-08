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

using global::System.Runtime.InteropServices;
using global::System;

namespace Tizen.NUI.Samples
{
    internal class ScrollViewSnapStartedSignal : Disposable
    {
        internal ScrollViewSnapStartedSignal(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Tizen.NUI.Interop.ScrollView.DeleteScrollViewSnapStartedSignal(swigCPtr);
        }

        public bool Empty()
        {
            bool ret = Tizen.NUI.Interop.ScrollView.ScrollViewSnapStartedSignalEmpty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = Tizen.NUI.Interop.ScrollView.ScrollViewSnapStartedSignalGetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(Delegate func)
        {
            IntPtr ip = global::System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Tizen.NUI.Interop.ScrollView.ScrollViewSnapStartedSignalConnect(SwigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(Delegate func)
        {
            IntPtr ip = global::System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Tizen.NUI.Interop.ScrollView.ScrollViewSnapStartedSignalDisconnect(SwigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Emit(ScrollView.SnapEvent arg)
        {
            Tizen.NUI.Interop.ScrollView.ScrollViewSnapStartedSignalEmit(SwigCPtr, ScrollView.SnapEvent.getCPtr(arg));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ScrollViewSnapStartedSignal() : this(Tizen.NUI.Interop.ScrollView.NewScrollViewSnapStartedSignal(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
