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
    internal class SignalObserver : Disposable
    {
        internal SignalObserver(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.SignalObserver.DeleteSignalObserver(swigCPtr);
        }

        /// <summary>
        /// This method is called when the signal is disconnecting.
        /// </summary>
        /// <param name="slotObserver">The signal that has disconnected</param>
        /// <param name="callback">The callback attached to the signal disconnected</param>
        public virtual void SignalDisconnected(SlotObserver slotObserver, SWIGTYPE_p_Dali__CallbackBase callback)
        {
            Interop.SignalObserver.SignalDisconnected(SwigCPtr, SlotObserver.getCPtr(slotObserver), SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
