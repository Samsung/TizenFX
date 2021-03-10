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
    internal class AngleThresholdPair : Disposable
    {

        internal AngleThresholdPair(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AngleThresholdPair obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.AngleThresholdPair.DeleteAngleThresholdPair(swigCPtr);
        }

        public AngleThresholdPair() : this(Interop.AngleThresholdPair.NewAngleThresholdPair(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public AngleThresholdPair(Radian t, Radian u) : this(Interop.AngleThresholdPair.NewAngleThresholdPair(Radian.getCPtr(t), Radian.getCPtr(u)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public AngleThresholdPair(AngleThresholdPair p) : this(Interop.AngleThresholdPair.NewAngleThresholdPair(AngleThresholdPair.getCPtr(p)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Radian first
        {
            set
            {
                Interop.AngleThresholdPair.FirstSet(SwigCPtr, Radian.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.AngleThresholdPair.FirstGet(SwigCPtr);
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        public Radian second
        {
            set
            {
                Interop.AngleThresholdPair.SecondSet(SwigCPtr, Radian.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.AngleThresholdPair.SecondGet(SwigCPtr);
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }
    }
}
