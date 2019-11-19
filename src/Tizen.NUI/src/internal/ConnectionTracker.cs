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
    internal class ConnectionTracker : ConnectionTrackerInterface
    {

        internal ConnectionTracker(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.ConnectionTracker.ConnectionTracker_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }


        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ConnectionTracker.delete_ConnectionTracker(swigCPtr);
        }

        public void DisconnectAll()
        {
            Interop.ConnectionTracker.ConnectionTracker_DisconnectAll(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public virtual void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            Interop.ConnectionTracker.ConnectionTracker_SignalConnected(swigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public new virtual void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            Interop.ConnectionTracker.ConnectionTracker_SignalDisconnected(swigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public uint GetConnectionCount()
        {
            uint ret = Interop.ConnectionTracker.ConnectionTracker_GetConnectionCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
