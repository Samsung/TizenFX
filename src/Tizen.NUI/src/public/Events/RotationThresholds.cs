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
    /// Recognition thresholds of the rotation gesture.<br />
    /// Register a per-device set with <see cref="GestureOptions.SetRotationThresholds(GestureDeviceSelector, RotationThresholds)"/>; it applies to every
    /// rotation gesture detector in the application, including those created by components, for gestures that start on a matching device.
    /// Start from <see cref="GestureOptions.GetDefaultRotationThresholds"/> to keep the values you do not want to change.
    /// </summary>
    /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class RotationThresholds : Disposable
    {
        /// <summary>
        /// Creates a thresholds object holding the built-in default values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotationThresholds() : this(Interop.GestureThresholds.NewRotationThresholds(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal RotationThresholds(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn, false)
        {
        }

        /// <summary>
        /// Gets or sets the minimum number of touch events required before a rotation is recognized. The default is 4.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinimumTouchEvents
        {
            get
            {
                uint ret = Interop.GestureThresholds.RotationThresholdsGetMinimumTouchEvents(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.RotationThresholdsSetMinimumTouchEvents(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets or sets the minimum number of touch events between rotation updates once started. The default is 4.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint MinimumTouchEventsAfterStart
        {
            get
            {
                uint ret = Interop.GestureThresholds.RotationThresholdsGetMinimumTouchEventsAfterStart(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
            set
            {
                Interop.GestureThresholds.RotationThresholdsSetMinimumTouchEventsAfterStart(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }
        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(HandleRef swigCPtr)
        {
            Interop.GestureThresholds.DeleteRotationThresholds(swigCPtr);
        }
    }
}
