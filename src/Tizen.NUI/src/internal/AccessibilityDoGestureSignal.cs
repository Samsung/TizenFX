/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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

using System.Diagnostics;
using System;
using System.Drawing;

namespace Tizen.NUI
{
    using global::System;
    using global::System.ComponentModel;
    using global::System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;

    public class AccessibilityDoGestureSignal : Disposable
    {
        internal AccessibilityDoGestureSignal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn) {
        }

        static internal int ConvertParam1(global::System.IntPtr data) {
            int result = Interop.DoGestureSignal.ConvertParam1(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal int ConvertParam2(global::System.IntPtr data) {
            int result = Interop.DoGestureSignal.ConvertParam2(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal int ConvertParam3(global::System.IntPtr data) {
            int result = Interop.DoGestureSignal.ConvertParam3(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal int ConvertParam4(global::System.IntPtr data) {
            int result = Interop.DoGestureSignal.ConvertParam4(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal int ConvertParam5(global::System.IntPtr data) {
            int result = Interop.DoGestureSignal.ConvertParam5(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal int ConvertParam6(global::System.IntPtr data) {
            int result = Interop.DoGestureSignal.ConvertParam6(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal uint ConvertParam7(global::System.IntPtr data) {
            uint result = Interop.DoGestureSignal.ConvertParam7(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal uint ConvertParam8(global::System.IntPtr data) {
            uint result = Interop.DoGestureSignal.ConvertParam8(data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        static internal void SetResult(global::System.IntPtr data, int res) {
            Interop.DoGestureSignal.SetResult(data, res);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.DoGestureSignal.Delete(swigCPtr);
        }

        public AccessibilityDoGestureSignal() : this(Interop.DoGestureSignal.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool Empty()
        {
            bool ret = Interop.DoGestureSignal.Empty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = Interop.DoGestureSignal.GetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.DoGestureSignal.Connect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.DoGestureSignal.Disconnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

//        internal void Connect(ConnectionTrackerInterface connectionTracker, SWIGTYPE_p_Dali__FunctorDelegate arg1)
//        {
//            Interop.DoGestureSignal.DoGestureSignal_Connect__SWIG_4(SwigCPtr, ConnectionTrackerInterface.getCPtr(connectionTracker), SWIGTYPE_p_Dali__FunctorDelegate.getCPtr(arg1));
//            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
//        }

        public void Emit()
        {
            Interop.DoGestureSignal.Emit(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}

