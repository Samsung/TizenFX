/*
 * Copyright(c) 2017 Samsung Electronics Co., Ltd.
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
        /// Creates a TapGesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TapGesture() : this(Interop.TapGesture.new_TapGesture__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TapGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.TapGesture.TapGesture_SWIGUpcast(cPtr), cMemoryOwn)
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

        private uint numberOfTaps
        {
            set
            {
                Interop.TapGesture.TapGesture_numberOfTaps_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.TapGesture.TapGesture_numberOfTaps_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint numberOfTouches
        {
            set
            {
                Interop.TapGesture.TapGesture_numberOfTouches_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.TapGesture.TapGesture_numberOfTouches_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenPoint
        {
            set
            {
                Interop.TapGesture.TapGesture_screenPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.TapGesture.TapGesture_screenPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 localPoint
        {
            set
            {
                Interop.TapGesture.TapGesture_localPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.TapGesture.TapGesture_localPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TapGesture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
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
            Interop.TapGesture.delete_TapGesture(swigCPtr);
        }
    }
}