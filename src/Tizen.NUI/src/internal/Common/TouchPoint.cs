/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// A TouchPoint represents a point on the screen that is currently being touched
    /// or where touch has stopped.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TouchPoint : Disposable
    {
        internal TouchPoint(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TouchPoint.DeleteTouchPoint(swigCPtr);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The touch device ID</param>
        /// <param name="state">The state</param>
        /// <param name="screenX">The X co-ordinate relative to the screen's origin</param>
        /// <param name="screenY">The Y co-ordinate relative to the screen's origin</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TouchPoint(int id, TouchPoint.StateType state, float screenX, float screenY) : this(Interop.TouchPoint.NewTouchPoint(id, (int)state, screenX, screenY), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">The touch device ID</param>
        /// <param name="state">The state</param>
        /// <param name="screenX">The X co-ordinate relative to the screen's origin</param>
        /// <param name="screenY">The Y co-ordinate relative to the screen's origin</param>
        /// <param name="localX">The X co-ordinate relative to the screen's origin</param>
        /// <param name="localY">The Y co-ordinate relative to the screen's origin</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TouchPoint(int id, TouchPoint.StateType state, float screenX, float screenY, float localX, float localY) : this(Interop.TouchPoint.NewTouchPoint(id, (int)state, screenX, screenY, localX, localY), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Each touch point has a unique device ID which specifies the touch device for that point.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DeviceId
        {
            set
            {
                Interop.TouchPoint.DeviceIdSet(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                int ret = Interop.TouchPoint.DeviceIdGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// State of the point.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TouchPoint.StateType State
        {
            set
            {
                Interop.TouchPoint.StateSet(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                TouchPoint.StateType ret = (TouchPoint.StateType)Interop.TouchPoint.StateGet(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The view that was underneath the touch point.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public View HitView
        {
            set
            {
                Interop.TouchPoint.HitActorSet(SwigCPtr, View.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.TouchPoint.HitActorGet(SwigCPtr);
                View ret = (cPtr == global::System.IntPtr.Zero) ? null : Registry.GetManagedBaseHandleFromNativePtr(cPtr) as View;
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The co-ordinates relative to the top-left of the hit-view.
        /// </summary>
        /// <remarks> The top-left of an view is (0.0, 0.0, 0.5).</remarks>
        /// <remarks>
        /// If you require the local coordinates of another view (e.g the parent of the hit view),
        /// then you should use View.ScreenToLocal().
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Local
        {
            set
            {
                Interop.TouchPoint.LocalSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.TouchPoint.LocalGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The co-ordinates relative to the top-left of the screen.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Screen
        {
            set
            {
                Interop.TouchPoint.ScreenSet(SwigCPtr, Vector2.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.TouchPoint.ScreenGet(SwigCPtr);
                Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Enumeration for point state type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum StateType
        {
            /// <summary>
            /// Touch or hover started
            /// </summary>
            Started,

            /// <summary>
            /// Touch or hover finished
            /// </summary>
            Finished,

            /// <summary>
            /// Screen touched
            /// </summary>
            Down = Started,

            /// <summary>
            /// Touch stopped
            /// </summary>
            Up = Finished,

            /// <summary>
            /// Finger dragged or hovered
            /// </summary>
            Motion,

            /// <summary>
            /// Leave the boundary of an actor
            /// </summary>
            Leave,

            /// <summary>
            /// No change from last event. Useful when a multi-point event occurs where
            /// all points are sent but indicates that this particular point has not changed
            /// since the last time
            /// </summary>
            Stationary,

            /// <summary>
            /// A system event has occurred which has interrupted the touch or hover event sequence.
            /// </summary>
            Interrupted,
            Last
        }
    }
}
