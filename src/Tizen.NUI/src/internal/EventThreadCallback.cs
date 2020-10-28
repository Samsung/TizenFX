/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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
using System.ComponentModel;

namespace Tizen.NUI
{
    internal class EventThreadCallback : Disposable
    {
        /// <since_tizen> 3 </since_tizen>
        public delegate void CallbackDelegate();

        internal EventThreadCallback(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            //NDalicManualPINVOKE.delete_EventThreadCallback(swigCPtr);
        }

        public EventThreadCallback(CallbackDelegate func) : this(Interop.EventThreadCallback.new_EventThreadCallback(func), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void Trigger()
        {
            if ((System.IntPtr)swigCPtr != global::System.IntPtr.Zero)
            {
                Interop.EventThreadCallback.EventThreadCallback_Trigger(swigCPtr);
            }

            if (NDalicPINVOKE.SWIGPendingException.Pending)
                throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
