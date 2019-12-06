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
    internal class ContentReceivedSignalType : Disposable
    {
        /// <summary>
        /// ContentReceivedSignalType
        /// </summary>

        internal ContentReceivedSignalType(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        /// <summary>
        /// Dispose
        /// </summary>
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ContentReceivedSignalType.delete_ContentReceivedSignalType(swigCPtr);
        }

        /// <summary>
        /// Queries whether there are any connected slots.
        /// </summary>
        /// <returns>True if there are any slots connected to the signal</returns>
        public bool Empty()
        {
            bool ret = Interop.ContentReceivedSignalType.ContentReceivedSignalType_Empty(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Queries the number of slots.
        /// </summary>
        /// <returns>The number of slots connected to this signal</returns>
        public uint GetConnectionCount()
        {
            uint ret = Interop.ContentReceivedSignalType.ContentReceivedSignalType_GetConnectionCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Connects a function.
        /// </summary>
        /// <param name="func">The function to connect</param>
        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.ContentReceivedSignalType.ContentReceivedSignalType_Connect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Disconnects a function.
        /// </summary>
        /// <param name="func">The function to disconnect</param>
        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.ContentReceivedSignalType.ContentReceivedSignalType_Disconnect(swigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Connects a member function.
        /// </summary>
        /// <param name="arg1">The member function to connect</param>
        /// <param name="arg2">The member function to connect</param>
        /// <param name="arg3">The member function to connect</param>
        public void Emit(string arg1, string arg2, string arg3)
        {
            Interop.ContentReceivedSignalType.ContentReceivedSignalType_Emit(swigCPtr, arg1, arg2, arg3);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The contructor.
        /// </summary>
        public ContentReceivedSignalType() : this(Interop.ContentReceivedSignalType.new_ContentReceivedSignalType(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
