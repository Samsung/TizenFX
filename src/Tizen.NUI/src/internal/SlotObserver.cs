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
using System;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen.NUI
{
    internal class SlotObserver : Disposable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        /// <summary>swigCMemOwn.</summary>
        /// <since_tizen> 4 </since_tizen>
        protected bool swigCMemOwn;

        internal SlotObserver(global::System.IntPtr cPtr, bool cMemoryOwn)
        {
            swigCMemOwn = cMemoryOwn;
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SlotObserver obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    delete_SlotObserver(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /// <summary>
        /// This method is called when the slot is disconnecting.
        /// </summary>
        /// <param name="callback">The callback attached to the signal disconnected.</param>
        /// <since_tizen> 4 </since_tizen>
        public virtual void SlotDisconnected(SWIGTYPE_p_Dali__CallbackBase callback)
        {
            SlotObserver_SlotDisconnected(swigCPtr, SWIGTYPE_p_Dali__CallbackBase.getCPtr(callback));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_SlotObserver")]
        public static extern void delete_SlotObserver(global::System.Runtime.InteropServices.HandleRef jarg1);

        [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_SlotObserver_SlotDisconnected")]
        public static extern void SlotObserver_SlotDisconnected(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
    }
}
