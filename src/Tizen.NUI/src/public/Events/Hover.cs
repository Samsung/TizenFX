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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Hover events are a collection of points at a specific moment in time.<br />
    /// When a multi-event occurs, each point represents the points that are currently being
    /// hovered or the points where a hover has stopped.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Hover : BaseHandle
    {

        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Hover() : this(Interop.Hover.New(0u), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <param name="time">The time the event occurred.</param>
        internal Hover(uint time) : this(Interop.Hover.New(time), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Hover(Hover other) : this(Interop.Hover.NewHover(Hover.getCPtr(other)), true)
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
                uint ret = Interop.Hover.GetTime(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw new InvalidOperationException("FATAL: get Exception", NDalicPINVOKE.SWIGPendingException.Retrieve());
                return ret;
            }
        }

        /// <summary>
        /// Returns the ID of the device used for the point specified.<br />
        /// Each point has a unique device ID which specifies the device used for that
        /// point. This is returned by this method.<br />
        /// If a point is greater than GetPointCount(), then this method will return -1.<br />
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The device ID of this point.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetDeviceId(uint point)
        {
            int ret = Interop.Hover.GetDeviceId(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the state of the point specified.<br />
        /// If a point is greater than GetPointCount(), then this method will return PointState.Finished.<br />
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The state of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PointStateType GetState(uint point)
        {
            PointStateType ret = (PointStateType)Interop.Hover.GetState(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the view that was underneath the point specified.<br />
        /// If a point is greater than GetPointCount(), then this method will return an empty handle.<br />
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The view that was underneath the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View GetHitView(uint point)
        {
            global::System.IntPtr cPtr = Interop.Hover.GetHitActor(SwigCPtr, point);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the coordinates relative to the top-left of the hit-view at the point specified.
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The coordinates relative to the top-left of the hit-view of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetLocalPosition(uint point)
        {
            Vector2 ret = new Vector2(Interop.Hover.GetLocalPosition(SwigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the coordinates relative to the top-left of the screen of the point specified.
        /// </summary>
        /// <param name="point">The point required.</param>
        /// <returns>The coordinates relative to the top-left of the screen of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetScreenPosition(uint point)
        {
            Vector2 ret = new Vector2(Interop.Hover.GetScreenPosition(SwigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the total number of points.
        /// </summary>
        /// <returns>Total number of points.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetPointCount()
        {
            uint ret = Interop.Hover.GetPointCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Hover obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal static Hover GetHoverFromPtr(global::System.IntPtr cPtr)
        {
            Hover ret = new Hover(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Hover.DeleteHover(swigCPtr);
        }
    }
}
