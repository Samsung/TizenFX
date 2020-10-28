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

namespace Tizen.NUI
{
    internal class ushortp : Disposable
    {

        internal ushortp(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }


        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.ushortp.delete_ushortp(swigCPtr);
        }

        public ushortp() : this(Interop.ushortp.new_ushortp(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void assign(ushort value)
        {
            Interop.ushortp.ushortp_assign(swigCPtr, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public ushort value()
        {
            ushort ret = Interop.ushortp.ushortp_value(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public SWIGTYPE_p_unsigned_short cast()
        {
            global::System.IntPtr cPtr = Interop.ushortp.ushortp_cast(swigCPtr);
            SWIGTYPE_p_unsigned_short ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_unsigned_short(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static ushortp frompointer(SWIGTYPE_p_unsigned_short t)
        {
            global::System.IntPtr cPtr = Interop.ushortp.ushortp_frompointer(SWIGTYPE_p_unsigned_short.getCPtr(t));
            ushortp ret = (cPtr == global::System.IntPtr.Zero) ? null : new ushortp(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
