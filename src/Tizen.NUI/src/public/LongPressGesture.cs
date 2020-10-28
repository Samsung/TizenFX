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
    /// A long press gesture is emitted when the user holds the screen with the stated number of fingers.<br />
    /// A long press gesture finishes when all touches have been released.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class LongPressGesture : Gesture
    {

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="state">The state of the gesture</param>
        /// <since_tizen> 3 </since_tizen>
        public LongPressGesture(Gesture.StateType state) : this(Interop.LongPressGesture.new_LongPressGesture__SWIG_0((int)state), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal LongPressGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.LongPressGesture.LongPressGesture_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// The number of touch points in this long press gesture, i.e., the number of fingers the user had
        /// on the screen to generate the long press gesture.<br />
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
        /// This is the point, in screen coordinates, where the long press occurred.<br />
        /// If a multi-touch long press, then this is the centroid of all the touch points.<br />
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
        /// This is the point, in local actor coordinates, where the long press occurred.<br />
        /// If a multi-touch long press, then this is the centroid of all the touch points.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 LocalPoint
        {
            get
            {
                return localPoint;
            }
        }


        private uint numberOfTouches
        {
            set
            {
                Interop.LongPressGesture.LongPressGesture_numberOfTouches_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.LongPressGesture.LongPressGesture_numberOfTouches_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenPoint
        {
            set
            {
                Interop.LongPressGesture.LongPressGesture_screenPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.LongPressGesture.LongPressGesture_screenPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 localPoint
        {
            set
            {
                Interop.LongPressGesture.LongPressGesture_localPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.LongPressGesture.LongPressGesture_localPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(LongPressGesture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static LongPressGesture GetLongPressGestureFromPtr(global::System.IntPtr cPtr)
        {
            LongPressGesture ret = new LongPressGesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.LongPressGesture.delete_LongPressGesture(swigCPtr);
        }
    }
}