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
using System.ComponentModel;

namespace Tizen.NUI
{
    ///<summary>
    /// Signal connection class for PropertyNotification
    ///</summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated in API6, Will be removed in API9, " +
        "Please use PropertyNotification.Notified event instead!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PropertyNotifySignal : Disposable
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification.Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyNotifySignal() : this(Interop.PropertyNotifySignal.NewPropertyNotifySignal(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PropertyNotifySignal(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Queries whether there are any connected slots.
        /// </summary>
        /// <returns>True if there are any slots connected to the signal.</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification.Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Empty()
        {
            bool ret = Interop.PropertyNotifySignal.Empty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the number of slots.
        /// </summary>
        /// <returns>The number of slots connected to this signal</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification.Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetConnectionCount()
        {
            uint ret = Interop.PropertyNotifySignal.GetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Connects a function.
        /// </summary>
        /// <param name="func">The function to connect</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification.Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.PropertyNotifySignal.Connect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Disconnects a function.
        /// </summary>
        /// <param name="func">The function to disconnect.</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification.Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.PropertyNotifySignal.Disconnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Emits a signal with 1 parameter.
        /// </summary>
        /// <param name="arg">The first value to pass to callbacks.</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " +
            "Please use PropertyNotification.Notified event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Emit(PropertyNotification arg)
        {
            Interop.PropertyNotifySignal.Emit(SwigCPtr, PropertyNotification.getCPtr(arg));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PropertyNotifySignal.DeletePropertyNotifySignal(swigCPtr);
        }
    }
}
