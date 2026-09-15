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
    /// Recognition thresholds of the pinch gesture.<br />
    /// Register a per-device set with <see cref="GestureOptions.SetPinchThresholds(GestureDeviceSelector, PinchThresholds)"/>; it applies to every
    /// pinch gesture detector in the application, including those created by components, for gestures that start on a matching device.
    /// Start from <see cref="GestureOptions.GetDefaultPinchThresholds"/> to keep the values you do not want to change.
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class PinchThresholds : Disposable
    {
        /// <summary>
        /// Creates a thresholds object holding the built-in default values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinchThresholds() : this(Interop.GestureThresholds.NewPinchThresholds(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PinchThresholds(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// <summary>
        /// Gets or sets the minimum change of distance, in pixels, between two touches before a pinch is recognized. A negative value selects the DPI-based default.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinimumDistance
        {
            get
            {
                float ret = Interop.GestureThresholds.PinchThresholdsGetMinimumDistance(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.PinchThresholdsSetMinimumDistance(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of touch events required before a pinch is recognized. The default is 4.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinimumTouchEvents
        {
            get
            {
                uint ret = Interop.GestureThresholds.PinchThresholdsGetMinimumTouchEvents(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.PinchThresholdsSetMinimumTouchEvents(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of touch events between pinch updates once started. The default is 4.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinimumTouchEventsAfterStart
        {
            get
            {
                uint ret = Interop.GestureThresholds.PinchThresholdsGetMinimumTouchEventsAfterStart(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.PinchThresholdsSetMinimumTouchEventsAfterStart(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.GestureThresholds.DeletePinchThresholds(swigCPtr);
        }
    }
}
