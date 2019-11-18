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
using System.ComponentModel;

namespace Tizen.NUI
{

    /// <summary>
    /// A RotationGesture is emitted when the user moves two fingers in a circular motion.<br />
    /// A rotation gesture will continue to be sent to the actor under the center point of the rotation until the rotation ends.<br />
    /// </summary>
    /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RotationGesture : Gesture
    {

        internal RotationGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.RotationGesture.RotationGesture_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }


        /// <summary>
        /// The overall rotation (in radians) from the start of the rotation gesture till the latest rotation gesture.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Rotation
        {
            get
            {
                return rotation;
            }
        }

        /// <summary>
        /// The center point of the two points that caused the rotation gesture in screen coordinates.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScreenCenterPoint
        {
            get
            {
                return screenCenterPoint;
            }
        }

        /// <summary>
        /// The center point of the two points that caused the rotation gesture in local view coordinates.
        /// </summary>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 LocalCenterPoint
        {
            get
            {
                return localCenterPoint;
            }
        }

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="state">The state of the gesture.</param>
        /// This will be made public in the next tizen release after an ACR is done. Till then, it needs to be hidden as an inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RotationGesture(Gesture.StateType state) : this(Interop.RotationGesture.new_RotationGesture__SWIG_0((int)state), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private float rotation
        {
            set
            {
                Interop.RotationGesture.RotationGesture_rotation_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = Interop.RotationGesture.RotationGesture_rotation_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenCenterPoint
        {
            set
            {
                Interop.RotationGesture.RotationGesture_screenCenterPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.RotationGesture.RotationGesture_screenCenterPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 localCenterPoint
        {
            set
            {
                Interop.RotationGesture.RotationGesture_localCenterPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.RotationGesture.RotationGesture_localCenterPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(RotationGesture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static RotationGesture GetRotationGestureFromPtr(global::System.IntPtr cPtr)
        {
            RotationGesture ret = new RotationGesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.RotationGesture.delete_RotationGesture(swigCPtr);
        }
    }
}
