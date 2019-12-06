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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Hover events are a collection of points at a specific moment in time.<br />
    /// When a multi-event occurs, each point represents the points that are currently being
    /// hovered or the points where a hover has stopped.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Hover : Disposable
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Hover() : this(Interop.Hover.new_Hover__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="time">The time the event occurred.</param>
        internal Hover(uint time) : this(Interop.Hover.new_Hover__SWIG_1(time), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Hover(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// The time (in ms) that the hover event occurred.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint Time
        {
            get
            {
                return time;
            }
        }

        private TouchPointContainer points
        {
            set
            {
                Interop.Hover.Hover_points_set(swigCPtr, TouchPointContainer.getCPtr(value));
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                global::System.IntPtr cPtr = Interop.Hover.Hover_points_get(swigCPtr);
                TouchPointContainer ret = (cPtr == global::System.IntPtr.Zero) ? null : new TouchPointContainer(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        private uint time
        {
            set
            {
                Interop.Hover.Hover_time_set(swigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            get
            {
                uint ret = Interop.Hover.Hover_time_get(swigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Returns the ID of the device used for the point specified.<br />
        /// Each point has a unique device ID which specifies the device used for that
        /// point. This is returned by this method.<br />
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The device ID of this point.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetDeviceId(uint point)
        {
            if (point < points.Count)
            {
                return points[(int)point].DeviceId;
            }
            return -1;
        }

        /// <summary>
        /// Retrieves the state of the point specified.
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The state of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PointStateType GetState(uint point)
        {
            if (point < points.Count)
            {
                return (Tizen.NUI.PointStateType)(points[(int)point].State);
            }
            return PointStateType.Finished;
        }

        /// <summary>
        /// Retrieves the view that was underneath the point specified.
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The view that was underneath the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View GetHitView(uint point)
        {
            if (point < points.Count)
            {
                return points[(int)point].HitView;
            }
            else
            {
                // Return a native empty handle
                View view = new View();
                view.Reset();
                return view;
            }
        }

        /// <summary>
        /// Retrieves the coordinates relative to the top-left of the hit-view at the point specified.
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The coordinates relative to the top-left of the hit-view of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetLocalPosition(uint point)
        {
            if (point < points.Count)
            {
                return points[(int)point].Local;
            }
            return new Vector2(0.0f, 0.0f);
        }

        /// <summary>
        /// Retrieves the coordinates relative to the top-left of the screen of the point specified.
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The coordinates relative to the top-left of the screen of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetScreenPosition(uint point)
        {
            if (point < points.Count)
            {
                return points[(int)point].Screen;
            }
            return new Vector2(0.0f, 0.0f);
        }

        /// <summary>
        /// Returns the total number of points.
        /// </summary>
        /// <returns>Total number of points.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetPointCount()
        {
            uint ret = Interop.Hover.Hover_GetPointCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Hover obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal static Hover GetHoverFromPtr(global::System.IntPtr cPtr)
        {
            Hover ret = new Hover(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal TouchPoint GetPoint(uint point)
        {
            TouchPoint ret = new TouchPoint(Interop.Hover.Hover_GetPoint(swigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Hover.delete_Hover(swigCPtr);
        }
    }
}