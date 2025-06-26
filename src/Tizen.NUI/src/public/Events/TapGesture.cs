/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
    /// A TapGesture is emitted when the user taps the screen with the stated number of fingers a stated number of times.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TapGesture : Gesture
    {

        /// <summary>
        /// Default constructor to creates a TapGesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TapGesture() : this(Interop.TapGesture.New(0), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TapGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal TapGesture(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// The number of taps property (read-only).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint NumberOfTaps
        {
            get
            {
                return numberOfTaps;
            }
        }

        /// <summary>
        /// The number of touches property (read-only).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint NumberOfTouches
        {
            get
            {
                return numberOfTouches;
            }
        }

        /// <summary>
        /// The screen point property (read-only).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenPoint
        {
            get
            {
                return screenPoint;
            }
        }

        /// <summary>
        /// The local point property (read-only).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 LocalPoint
        {
            get
            {
                return localPoint;
            }
        }

        /// <summary>
        /// The gesture source type of touches property (read-only).
        /// If you touch with a mouse button, this will tell you which mouse input you touched.
        /// Primary(Left), Secondary(Right). Tertiary(Wheel).
        /// Deprecated. This api will be deleted without notice. Please do not use it.
        /// </summary>
        [Obsolete("This property will be deleted without notice. Please do not use it. Use Gesture.SourceData instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new GestureSourceType SourceType
        {
            get
            {
                return (GestureSourceType)SourceData;
            }
        }

        private uint numberOfTaps
        {
            get
            {
                uint ret = Interop.TapGesture.NumberOfTapsGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint numberOfTouches
        {
            get
            {
                uint ret = Interop.TapGesture.NumberOfTouchesGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenPoint
        {
            get
            {
                global::System.IntPtr cPtr = Interop.TapGesture.ScreenPointGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 localPoint
        {
            get
            {
                global::System.IntPtr cPtr = Interop.TapGesture.LocalPointGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Gets the TapGesture from the pointer.
        /// </summary>
        /// <param name="cPtr">The pointer to cast.</param>
        /// <returns>The TapGesture object.</returns>
        internal static TapGesture GetTapGestureFromPtr(global::System.IntPtr cPtr)
        {
            TapGesture ret = new TapGesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TapGesture.DeleteTapGesture(swigCPtr);
        }
    }

    /// <summary>
    /// Gesture source type.
    /// Deprecated. This value will be deleted without notice. Please do not use it.
    /// </summary>
    [Obsolete("This enum will be deleted without notice. Please do not use it.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum GestureSourceType
    {
        /// <summary>
        /// invalid data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Invalid = -1,
        /// <summary>
        /// Primary.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Primary = 1,
        /// <summary>
        /// Secondary.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Secondary = 3,
        /// <summary>
        /// Third (tertiary)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Tertiary = 2,
    }

}
