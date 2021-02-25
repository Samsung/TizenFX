/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
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
    /// <summary>
    /// LowBatterySignalType.
    /// </summary>
    internal class LowBatterySignalType : Disposable
    {
        internal LowBatterySignalType(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.LowBatterySignal.DeleteLowBatterySignalType(swigCPtr);
        }

        /// <summary>
        /// Empty 
        /// </summary>
        /// <returns>true if there is no signal attached</returns>
        public bool Empty()
        {
            bool ret = Interop.LowBatterySignal.LowBatterySignalTypeEmpty(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// GetConnectionCount
        /// </summary>
        /// <returns>number of attached signals</returns>
        public uint GetConnectionCount()
        {
            uint ret = Interop.LowBatterySignal.LowBatterySignalTypeGetConnectionCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// signal connect
        /// </summary>
        /// <param name="func"></param>
        public void Connect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.LowBatterySignal.LowBatterySignalTypeConnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// signal disconnect
        /// </summary>
        /// <param name="func"></param>
        public void Disconnect(System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.LowBatterySignal.LowBatterySignalTypeDisconnect(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        internal void Emit(Application.BatteryStatus arg)
        {
            Interop.LowBatterySignal.LowBatterySignalTypeEmit(SwigCPtr, (int)arg);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// LowBatterySignalType
        /// </summary>
        public LowBatterySignalType() : this(Interop.LowBatterySignal.NewLowBatterySignalType(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}

