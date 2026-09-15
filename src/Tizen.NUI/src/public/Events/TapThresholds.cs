/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// Recognition thresholds of the tap gesture.<br />
    /// Register a per-device set with <see cref="GestureOptions.SetTapThresholds(GestureDeviceSelector, TapThresholds)"/>; it applies to every
    /// tap gesture detector in the application, including those created by components, for gestures that start on a matching device.
    /// Start from <see cref="GestureOptions.GetDefaultTapThresholds"/> to keep the values you do not want to change.
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class TapThresholds : Disposable
    {
        /// <summary>
        /// Creates a thresholds object holding the built-in default values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TapThresholds() : this(Interop.GestureThresholds.NewTapThresholds(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TapThresholds(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// <summary>
        /// Gets or sets the maximum interval, in milliseconds, between taps of a multi-tap sequence. The default is 330.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MaximumMultiTapInterval
        {
            get
            {
                uint ret = Interop.GestureThresholds.TapThresholdsGetMaximumMultiTapInterval(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.TapThresholdsSetMaximumMultiTapInterval(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets or sets the maximum time, in milliseconds, a touch may be held down and still count as a tap. The default is 330.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MaximumHoldingTime
        {
            get
            {
                uint ret = Interop.GestureThresholds.TapThresholdsGetMaximumHoldingTime(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.TapThresholdsSetMaximumHoldingTime(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets or sets the maximum distance, in pixels, a touch may move between down and up and still count as a tap. The default is 20.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MaximumMotionDistance
        {
            get
            {
                float ret = Interop.GestureThresholds.TapThresholdsGetMaximumMotionDistance(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.TapThresholdsSetMaximumMotionDistance(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.GestureThresholds.DeleteTapThresholds(swigCPtr);
        }
    }
}
