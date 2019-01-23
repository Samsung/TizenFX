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
    /// A PinchGesture is emitted when the user moves two fingers towards or away from each other.<br />
    /// A pinch gesture will continue to be sent to the actor under the center point of the pinch until the pinch ends.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PinchGesture : Gesture
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal PinchGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.PinchGesture_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }


        /// <summary>
        /// The scale factor from the start of the pinch gesture till the latest pinch gesture.<br />
        /// If the user is moving their fingers away from each other, then
        /// this value increases. Conversely, if the user is moving their
        /// fingers towards each other, this value will decrease.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Scale
        {
            get
            {
                return scale;
            }
        }

        /// <summary>
        /// The speed at which the user is moving their fingers.<br />
        /// This is the pixel movement per second.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float Speed
        {
            get
            {
                return speed;
            }
        }

        /// <summary>
        /// The center point of the two points that caused the pinch gesture in screen coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenCenterPoint
        {
            get
            {
                return screenCenterPoint;
            }
        }

        /// <summary>
        /// The center point of the two points that caused the pinch gesture in local actor coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// This will be public opened in next tizen after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PinchGesture(Gesture.StateType state) : this(NDalicPINVOKE.new_PinchGesture__SWIG_0((int)state), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private float scale
        {
            set
            {
                NDalicPINVOKE.PinchGesture_scale_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PinchGesture_scale_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private float speed
        {
            set
            {
                NDalicPINVOKE.PinchGesture_speed_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                float ret = NDalicPINVOKE.PinchGesture_speed_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenCenterPoint
        {
            set
            {
                NDalicPINVOKE.PinchGesture_screenCenterPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.PinchGesture_screenCenterPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 localCenterPoint
        {
            set
            {
                NDalicPINVOKE.PinchGesture_localCenterPoint_set(swigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = NDalicPINVOKE.PinchGesture_localCenterPoint_get(swigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PinchGesture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static PinchGesture GetPinchGestureFromPtr(global::System.IntPtr cPtr)
        {
            PinchGesture ret = new PinchGesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_PinchGesture(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

    }

}