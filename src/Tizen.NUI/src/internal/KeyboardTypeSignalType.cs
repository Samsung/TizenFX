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
    /// <summary>
    /// KeyboardTypeSignalType
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Obsolete("Deprecated in API6, Will be removed in API9, " + 
        "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class KeyboardTypeSignalType : Disposable
    {

        internal KeyboardTypeSignalType(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        /// This will be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.KeyboardTypeSignalType.delete_KeyboardTypeSignalType(swigCPtr);
        }

        /// <summary>
        /// Queries whether there are any connected slots.
        /// </summary>
        /// <returns>True if there are any slots connected to the signal</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " + 
            "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Empty()
        {
            bool ret = Interop.KeyboardTypeSignalType.KeyboardTypeSignalType_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the number of slots.
        /// </summary>
        /// <returns>The number of slots connected to this signal</returns>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " + 
            "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetConnectionCount()
        {
            uint ret = Interop.KeyboardTypeSignalType.KeyboardTypeSignalType_GetConnectionCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Connects a function.
        /// </summary>
        /// <param name="func">The function to connect</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " + 
            "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.KeyboardTypeSignalType.KeyboardTypeSignalType_Connect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Disconnects a function.
        /// </summary>
        /// <param name="func">The function to disconnect</param>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " + 
            "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate<System.Delegate>(func);
            {
                Interop.KeyboardTypeSignalType.KeyboardTypeSignalType_Disconnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Connects a member function.
        /// </summary>
        /// <param name="arg">The member function to connect</param>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " + 
            "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Emit(InputMethodContext.KeyboardType arg)
        {
            Interop.KeyboardTypeSignalType.KeyboardTypeSignalType_Emit(swigCPtr, (int)arg);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The contructor.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API6, Will be removed in API9, " + 
            "Please use InputMethodContext.KeyboardTypeChanged event instead!")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public KeyboardTypeSignalType() : this(Interop.KeyboardTypeSignalType.new_KeyboardTypeSignalType(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
