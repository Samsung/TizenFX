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
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    internal class ConnectionTrackerInterface : SignalObserver
    {
        internal ConnectionTrackerInterface(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ConnectionTrackerInterface obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        /// <summary>
        /// Dispose
        /// </summary>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ConnectionTracker.DeleteConnectionTrackerInterface(swigCPtr);
        }

        /// <summary>
        /// Called when a signal is connected.
        /// </summary>
        /// <param name="slotObserver">The slot observer i.e. a signal. Ownership is not passed</param>
        /// <param name="callback">The call back. Ownership is not passed</param>
        public virtual void SignalConnected(SlotObserver slotObserver, SWIGTYPE_p_CallbackBase callback)
        {
            Interop.ConnectionTracker.ConnectionTrackerInterfaceSignalConnected(SwigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
