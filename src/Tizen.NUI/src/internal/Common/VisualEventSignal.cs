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

using global::System;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal class VisualEventSignal : Disposable
    {
        public VisualEventSignal() : this(Interop.VisualEventSignal.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.VisualEventSignal.Delete(swigCPtr);
        }

        public bool Empty()
        {
            bool ret = Interop.VisualEventSignal.Empty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetConnectionCount()
        {
            uint ret = Interop.VisualEventSignal.GetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void Connect(Delegate func)
        {
            NUILog.Debug("VisualEventSignal.Connect()!");

            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Interop.VisualEventSignal.Connect(SwigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Disconnect(Delegate func)
        {
            NUILog.Debug("VisualEventSignal.Disconnect()!");

            IntPtr ip = Marshal.GetFunctionPointerForDelegate<Delegate>(func);
            {
                Interop.VisualEventSignal.Disconnect(SwigCPtr, new HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        public void Emit(BaseComponents.View target, int visualIndex, int signalId)
        {
            Interop.VisualEventSignal.Emit(SwigCPtr, BaseComponents.View.getCPtr(target), visualIndex, signalId);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal VisualEventSignal(IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static HandleRef getCPtr(VisualEventSignal obj)
        {
            return (obj == null) ? new HandleRef(null, IntPtr.Zero) : obj.SwigCPtr;
        }
    }
}
