/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    using Tizen.NUI.BaseComponents;
    /// <summary>
    /// Touch events are a collection of points at a specific moment in time.<br>
    /// When a multi-touch event occurs, each point represents the points that are currently being
    /// touched or the points where a touch has stopped.<br>
    /// </summary>
    public class Touch : BaseHandle
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal Touch(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Touch_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Touch obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        protected override void Dispose(DisposeTypes type)
        {
            if(disposed)
            {
                return;
            }

            if(type == DisposeTypes.Explicit)
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

                    //Unreference this instance from Registry.
                    Registry.Unregister(this);

                    NDalicPINVOKE.delete_Touch(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }


        internal static Touch GetTouchFromPtr(global::System.IntPtr cPtr)
        {
            Touch ret = new Touch(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// An uninitialized Touch instance.<br>
        /// Calling member functions with an uninitialized Touch handle is not allowed.<br>
        /// </summary>
        public Touch() : this(NDalicPINVOKE.new_Touch__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal Touch(Touch other) : this(NDalicPINVOKE.new_Touch__SWIG_1(Touch.getCPtr(other)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the time (in ms) that the touch event occurred.
        /// </summary>
        /// <returns>The time (in ms) that the touch event occurred</returns>
        public uint GetTime()
        {
            uint ret = NDalicPINVOKE.Touch_GetTime(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the total number of points in this TouchData.
        /// </summary>
        /// <returns>Total number of Points</returns>
        public uint GetPointCount()
        {
            uint ret = NDalicPINVOKE.Touch_GetPointCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns the ID of the device used for the Point specified.<br>
        /// Each point has a unique device ID which specifies the device used for that
        /// point. This is returned by this method.<br>
        /// If point is greater than GetPointCount() then this method will return -1.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The Device ID of this point</returns>
        public int GetDeviceId(uint point)
        {
            int ret = NDalicPINVOKE.Touch_GetDeviceId(swigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the State of the point specified.<br>
        /// If point is greater than GetPointCount() then this method will return PointState.Finished.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The state of the point specified</returns>
        public PointStateType GetState(uint point)
        {
            PointStateType ret = (PointStateType)NDalicPINVOKE.Touch_GetState(swigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the actor that was underneath the point specified.<br>
        /// If point is greater than GetPointCount() then this method will return an empty handle.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The actor that was underneath the point specified</returns>
        public View GetHitView(uint point)
        {
            View ret = new View(NDalicPINVOKE.Touch_GetHitActor(swigCPtr, point), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the co-ordinates relative to the top-left of the hit-actor at the point specified.<br>
        /// The top-left of an actor is (0.0, 0.0, 0.5).<br>
        /// If you require the local coordinates of another actor (e.g the parent of the hit actor),
        /// then you should use Actor::ScreenToLocal().<br>
        /// If point is greater than GetPointCount() then this method will return Vector2.Zero.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The co-ordinates relative to the top-left of the hit-actor of the point specified</returns>
        public Vector2 GetLocalPosition(uint point)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Touch_GetLocalPosition(swigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the co-ordinates relative to the top-left of the screen of the point specified.<br>
        /// If point is greater than GetPointCount() then this method will return Vector2.Zero.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The co-ordinates relative to the top-left of the screen of the point specified</returns>
        public Vector2 GetScreenPosition(uint point)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Touch_GetScreenPosition(swigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the radius of the press point.<br>
        /// This is the average of both the horizontal and vertical radii of the press point.<br>
        /// If point is greater than GetPointCount() then this method will return 0.0f.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The radius of the press point</returns>
        public float GetRadius(uint point)
        {
            float ret = NDalicPINVOKE.Touch_GetRadius(swigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves BOTH the horizontal and the vertical radii of the press point.<br>
        /// If point is greater than GetPointCount() then this method will return Vector2.Zero.<br>
        /// </summary>
        /// <param name="point">The point required</param>
        /// <returns>The horizontal and vertical radii of the press point</returns>
        public Vector2 GetEllipseRadius(uint point)
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.Touch_GetEllipseRadius(swigCPtr, point), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the touch pressure.<br>
        /// The pressure range starts at 0.0f.<br>
        /// Normal pressure is defined as 1.0f.<br>
        /// A value between 0.0f and 1.0f means light pressure has been applied.<br>
        /// A value greater than 1.0f means more pressure than normal has been applied.<br>
        /// If point is greater than GetPointCount() then this method will return 1.0f.<br>
        /// </summary>
        /// <param name="point">point The point required</param>
        /// <returns>The touch pressure</returns>
        public float GetPressure(uint point)
        {
            float ret = NDalicPINVOKE.Touch_GetPressure(swigCPtr, point);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal Degree GetAngle(uint point)
        {
            Degree ret = new Degree(NDalicPINVOKE.Touch_GetAngle(swigCPtr, point), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

    }
}
