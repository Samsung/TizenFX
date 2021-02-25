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
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// A PanGesture is emitted when the user moves one or more fingers in a particular direction.<br />
    /// A pan gesture will end in the following ways:<br />
    /// - User releases the primary finger (the first touch).<br />
    /// - User has more fingers on the screen than the maximum specified.<br />
    /// - User has less fingers on the screen than the minimum specified.<br />
    /// - Cancelled by the system.<br />
    /// A pan gesture will continue to be sent to the actor under than initial pan until it ends.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class PanGesture : Gesture
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PanGesture() : this(Interop.PanGestureDetector.PanGestureNew(0), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="state">The state of the gesture</param>
        internal PanGesture(Gesture.StateType state) : this(Interop.PanGestureDetector.PanGestureNew((int)state), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PanGesture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PanGestureDetector.PanGestureUpcast(cPtr), cMemoryOwn)
        {
        }

        /// <summary>
        /// The velocity at which the user is moving their fingers.<br />
        /// This is represented as a Vector2 and is the pixel movement per millisecond.<br />
        /// A positive x value shows that the user is panning to the right, a negative x value means the opposite.<br />
        /// A positive y value shows that the user is panning downwards, a negative y values means upwards.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
        }

        /// <summary>
        /// This is a Vector2 showing how much the user has panned (dragged) since the last pan gesture or,
        /// if the gesture has just started, then the amount panned since the user touched the screen.<br />
        /// A positive x value shows that the user is panning to the right, a negative x value means the opposite.<br />
        /// A positive y value shows that the user is panning downwards, a negative y value means upwards.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Displacement
        {
            get
            {
                return displacement;
            }
        }

        /// <summary>
        /// The current touch position of the primary touch point in local actor coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        /// <summary>
        /// The velocity at which the user is moving their fingers.<br />
        /// This is represented as a Vector2 and is the pixel movement per millisecond.<br />
        /// A positive x value shows that the user is panning to the right, a negative x value means the opposite.<br />
        /// A positive y value shows that the user is panning downwards, a negative y values means upwards.<br />
        /// This value represents the screen coordinates.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenVelocity
        {
            get
            {
                return screenVelocity;
            }
        }

        /// <summary>
        /// This is a Vector2 showing how much the user has panned (dragged) since the last pan gesture or,
        /// if the gesture has just started, then the amount panned since the user touched the screen.<br />
        /// A positive x value shows that the user is panning to the right, a negative x value means the opposite.<br />
        /// A positive y value shows that the user is panning downwards, a negative y value means upwards.<br />
        /// This value is in screen coordinates.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenDisplacement
        {
            get
            {
                return screenDisplacement;
            }
        }

        /// <summary>
        /// The current touch position of the primary touch point in screen coordinates.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ScreenPosition
        {
            get
            {
                return screenPosition;
            }
        }

        /// <summary>
        /// The total number of fingers touching the screen in a pan gesture.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint NumberOfTouches
        {
            get
            {
                return numberOfTouches;
            }
        }


        private Vector2 velocity
        {
            set
            {
                Interop.PanGestureDetector.PanGestureVelocitySet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureVelocityGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 displacement
        {
            set
            {
                Interop.PanGestureDetector.PanGestureDisplacementSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDisplacementGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 position
        {
            set
            {
                Interop.PanGestureDetector.PanGesturePositionSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGesturePositionGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenVelocity
        {
            set
            {
                Interop.PanGestureDetector.PanGestureScreenVelocitySet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureScreenVelocityGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenDisplacement
        {
            set
            {
                Interop.PanGestureDetector.PanGestureScreenDisplacementSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureScreenDisplacementGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private Vector2 screenPosition
        {
            set
            {
                Interop.PanGestureDetector.PanGestureScreenPositionSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureScreenPositionGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint numberOfTouches
        {
            set
            {
                Interop.PanGestureDetector.PanGestureNumberOfTouchesSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.PanGestureDetector.PanGestureNumberOfTouchesGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }


        /// <summary>
        /// Returns the speed at which the user is moving their fingers.<br />
        /// This is the pixel movement per millisecond.<br />
        /// </summary>
        /// <returns>The speed of the pan (in pixels per millisecond).</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetSpeed()
        {
            float ret = Interop.PanGestureDetector.PanGestureGetSpeed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the distance the user has panned (dragged) since the last pan gesture or,
        /// if the gesture has just started, then the distance moved since the user touched the screen.<br />
        /// This is always a positive value.<br />
        /// </summary>
        /// <returns>The distance, as a float, a user's finger has panned.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetDistance()
        {
            float ret = Interop.PanGestureDetector.PanGestureGetDistance(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the speed at which the user is moving their fingers relative to screen coordinates.<br />
        /// This is the pixel movement per millisecond.<br />
        /// </summary>
        /// <returns>The speed of the pan (in pixels per millisecond).</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetScreenSpeed()
        {
            float ret = Interop.PanGestureDetector.PanGestureGetScreenSpeed(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the distance the user has panned (dragged) since the last pan gesture in screen
        /// coordinates or, if the gesture has just started, then the distance in screen coordinates moved
        /// since the user touched the screen.<br />
        /// This is always a positive value.<br />
        /// </summary>
        /// <returns>The distance, as a float, a user's finger has panned.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetScreenDistance()
        {
            float ret = Interop.PanGestureDetector.PanGestureGetScreenDistance(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PanGesture obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static PanGesture GetPanGestureFromPtr(global::System.IntPtr cPtr)
        {
            PanGesture ret = new PanGesture(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.PanGestureDetector.DeletePanGesture(swigCPtr);
        }
    }
}
