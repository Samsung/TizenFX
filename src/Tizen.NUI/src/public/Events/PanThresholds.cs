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
    /// Recognition thresholds of the pan gesture.<br />
    /// Register a per-device set with <see cref="GestureOptions.SetPanThresholds(GestureDeviceSelector, PanThresholds)"/>; it applies to every
    /// pan gesture detector in the application, including those created by components, for gestures that start on a matching device.
    /// Start from <see cref="GestureOptions.GetDefaultPanThresholds"/> to keep the values you do not want to change.
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class PanThresholds : Disposable
    {
        /// <summary>
        /// Creates a thresholds object holding the built-in default values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PanThresholds() : this(Interop.GestureThresholds.NewPanThresholds(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PanThresholds(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// <summary>
        /// Gets or sets the minimum distance, in pixels, a touch must move before a pan is recognized. The default is 15.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinimumDistance
        {
            get
            {
                int ret = Interop.GestureThresholds.PanThresholdsGetMinimumDistance(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.PanThresholdsSetMinimumDistance(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of motion events required before a pan is recognized. The default is 3.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int MinimumPanEvents
        {
            get
            {
                int ret = Interop.GestureThresholds.PanThresholdsGetMinimumPanEvents(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.PanThresholdsSetMinimumPanEvents(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.GestureThresholds.DeletePanThresholds(swigCPtr);
        }
    }
}
