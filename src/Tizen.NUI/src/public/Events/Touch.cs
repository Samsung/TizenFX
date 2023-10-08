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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Touch events are a collection of points at a specific moment in time.<br />
    /// When a multi-touch event occurs, each point represents the points that are currently being
    /// touched or the points where a touch has stopped.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Touch : BaseHandle
    {
        /// <summary>
        /// An uninitialized touch instance.<br />
        /// Calling member functions with an uninitialized touch handle is not allowed.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Touch() : this(Interop.Touch.NewTouch(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Touch(Touch other) : this(Interop.Touch.NewTouch(Touch.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Touch(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, true)
        {
        }

        internal Touch(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(cPtr, cMemoryOwn, cRegister)
        {
        }

        /// <summary>
        /// Returns the time (in ms) that the touch event occurred.
        /// </summary>
        /// <returns>The time (in ms) that the touch event occurred.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetTime()
        {
            uint ret = Interop.Touch.GetTime(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the total number of points in this TouchData.
        /// Point means the touched point.
        /// If there is one touch point, the point index is 0.
        /// If there are two touch points, the point index has 0 and 1.
        /// </summary>
        /// <returns>The total number of points.</returns>
        /// <since_tizen> 3 </since_tizen>
        public uint GetPointCount()
        {
            uint ret = Interop.Touch.GetPointCount(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the ID of the device used for the point specified.<br />
        /// Each point has a unique device ID, which specifies the device used for that
        /// point. This is returned by this method.<br />
        /// If a point is greater than GetPointCount(), then this method will return -1.<br />
        /// </summary>
        /// <param name="point">The index of a touch point</param>
        /// <returns>The device ID of this point.</returns>
        /// <since_tizen> 3 </since_tizen>
        public int GetDeviceId(uint point)
        {
            int ret = Interop.Touch.GetDeviceId(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the state of the point specified.<br />
        /// If a point is greater than GetPointCount(), then this method will return PointState.Finished.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The state of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public PointStateType GetState(uint point)
        {
            PointStateType ret = (PointStateType)Interop.Touch.GetState(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the view that was underneath the point specified.<br />
        /// If a point is greater than GetPointCount(), then this method will return an empty handle.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The view that was underneath the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public View GetHitView(uint point)
        {
            //to fix memory leak issue, match the handle count with native side.
            global::System.IntPtr cPtr = Interop.Touch.GetHitActor(SwigCPtr, point);
            View ret = this.GetInstanceSafely<View>(cPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the coordinates relative to the top-left of the hit view at the point specified.<br />
        /// The top-left of an view is (0.0, 0.0, 0.5).<br />
        /// If you require the local coordinates of another view (for example, the parent of the hit view),
        /// then you should use ScreenToLocal().<br />
        /// If a point is greater than GetPointCount(), then this method will return Vector2.Zero.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The coordinates relative to the top-left of the hit view of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetLocalPosition(uint point)
        {
            Vector2 ret = new Vector2(Interop.Touch.GetLocalPosition(SwigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the coordinates relative to the top-left of the screen of the point specified.<br />
        /// If a point is greater than GetPointCount(), then this method will return Vector2.Zero.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The coordinates relative to the top-left of the screen of the point specified.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetScreenPosition(uint point)
        {
            Vector2 ret = new Vector2(Interop.Touch.GetScreenPosition(SwigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the radius of the press point.<br />
        /// This is the average of both the horizontal and vertical radii of the press point.<br />
        /// If point is greater than GetPointCount(), then this method will return 0.0f.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The radius of the press point.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetRadius(uint point)
        {
            float ret = Interop.Touch.GetRadius(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves both the horizontal and the vertical radii of the press point.<br />
        /// If a point is greater than GetPointCount(), then this method will return Vector2.Zero.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The horizontal and vertical radii of the press point.</returns>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 GetEllipseRadius(uint point)
        {
            Vector2 ret = new Vector2(Interop.Touch.GetEllipseRadius(SwigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the touch pressure.<br />
        /// The pressure range starts at 0.0f.<br />
        /// Normal pressure is defined as 1.0f.<br />
        /// A value between 0.0f and 1.0f means light pressure has been applied.<br />
        /// A value greater than 1.0f means more pressure than normal has been applied.<br />
        /// If point is greater than GetPointCount(), then this method will return 1.0f.<br />
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns>The touch pressure.</returns>
        /// <since_tizen> 3 </since_tizen>
        public float GetPressure(uint point)
        {
            float ret = Interop.Touch.GetPressure(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Get mouse device's button value (for example, right or left button)
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public MouseButton GetMouseButton(uint point)
        {
            int ret = Interop.Touch.GetMouseButton(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (MouseButton)ret;
        }

        /// <summary>
        /// Gets the device class type from which the mouse/touch event is originated.
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceClassType GetDeviceClass(uint point)
        {
            int ret = Interop.Touch.GetDeviceClass(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (DeviceClassType)ret;
        }

        /// <summary>
        /// Gets the subclass type of the device from which the mouse/touch event is originated.
        /// </summary>
        /// <param name="point">The index of a touch point.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DeviceSubClassType GetDeviceSubClass(uint point)
        {
            int ret = Interop.Touch.GetDeviceSubClass(SwigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return (DeviceSubClassType)ret;
        }


        internal static Touch GetTouchFromPtr(global::System.IntPtr cPtr)
        {
            Touch ret = new Touch(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will be public opened in tizen_next after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Degree GetAngle(uint point)
        {
            Degree ret = new Degree(Interop.Touch.GetAngle(SwigCPtr, point), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.Touch.DeleteTouch(swigCPtr);
        }
    }

    /// <summary>
    /// Mouse device button type.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum MouseButton
    {
        /// <summary>
        /// No mouse button event or invalid data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Invalid = -1,
        /// <summary>
        /// Primary(Left) mouse button.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Primary = 1,
        /// <summary>
        /// Secondary(Right) mouse button.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Secondary = 3,
        /// <summary>
        /// Center(Wheel) mouse button.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Tertiary = 2,
    }
}
