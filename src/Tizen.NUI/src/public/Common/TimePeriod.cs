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

using global::System;
using global::System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// TimePeriod is used to define delay and duration of a process such as <see cref="Transition"/>.
    /// TimePeriod is composed of Delay and Duration in milliseconds
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class TimePeriod : Disposable
    {
        internal TimePeriod(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TimePeriod obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TimePeriod.DeleteTimePeriod(swigCPtr);
        }

        /// <summary>
        /// The constructor.
        /// Creates an time peroid object with the user-defined alpha function.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TimePeriod(int durationMilliSeconds) : this(Interop.TimePeriod.NewTimePeriod((float)durationMilliSeconds / 1000.0f), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// Creates an time peroid object with the user-defined alpha function.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public TimePeriod(float delayMilliSeconds, float durationMilliSeconds) : this(Interop.TimePeriod.NewTimePeriod((float)delayMilliSeconds / 1000.0f, (float)durationMilliSeconds / 1000.0f), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// A delay before the time period in milliseconds
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int DelayMilliseconds
        {
            set
            {
                Interop.TimePeriod.DelaySecondsSet(SwigCPtr, MilliSecondsToSeconds(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = SecondsToMilliSeconds(Interop.TimePeriod.DelaySecondsGet(SwigCPtr));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The duration of the time period in milliseconds
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public int DurationMilliseconds
        {
            set
            {
                Interop.TimePeriod.DurationSecondsSet(SwigCPtr, MilliSecondsToSeconds(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = SecondsToMilliSeconds(Interop.TimePeriod.DurationSecondsGet(SwigCPtr));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float MilliSecondsToSeconds(int millisec)
        {
            return (float)millisec / 1000.0f;
        }

        private int SecondsToMilliSeconds(float sec)
        {
            return (int)(sec * 1000);
        }
    }
}
