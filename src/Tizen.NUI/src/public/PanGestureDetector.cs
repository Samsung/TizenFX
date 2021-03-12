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
using System;
using System.Runtime.InteropServices;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// This class emits a signals when a pan gesture occurs.<br />
    /// </summary>
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PanGestureDetector : GestureDetector
    {
        /// <summary>
        /// Creates an initialized PanGestureDetector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PanGestureDetector() : this(Interop.PanGestureDetector.PanGestureDetector_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// The copy constructor.
        /// </summary>
        /// <param name="handle">A reference to the copied handle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PanGestureDetector(PanGestureDetector handle) : this(Interop.PanGestureDetector.new_PanGestureDetector__SWIG_1(PanGestureDetector.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal PanGestureDetector(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.PanGestureDetector.PanGestureDetector_SWIGUpcast(cPtr), cMemoryOwn)
        {
        }

        private DaliEventHandler<object, DetectedEventArgs> _detectedEventHandler;
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void DetectedCallbackType(IntPtr actor, IntPtr panGesture);
        private DetectedCallbackType _detectedCallback;

        /// <summary>
        /// This signal is emitted when the specified pan is detected on the attached view.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event DaliEventHandler<object, DetectedEventArgs> Detected
        {
            add
            {
                if (_detectedEventHandler == null)
                {
                    _detectedCallback = OnPanGestureDetected;
                    DetectedSignal().Connect(_detectedCallback);
                }

                _detectedEventHandler += value;
            }

            remove
            {
                _detectedEventHandler -= value;

                if (_detectedEventHandler == null && DetectedSignal().Empty() == false)
                {
                    DetectedSignal().Disconnect(_detectedCallback);
                }
            }
        }

        /// <summary>
        /// For a left pan (-PI Radians).
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DirectionLeft
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DIRECTION_LEFT_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// For a right pan (0 Radians).
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DirectionRight
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DIRECTION_RIGHT_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// For an up pan (-0.5 * PI Radians).
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DirectionUp
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DIRECTION_UP_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// For a down pan (0.5 * PI Radians).
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DirectionDown
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DIRECTION_DOWN_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// For a left and right pan (PI Radians). Useful for AddDirection().
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DirectionHorizontal
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DIRECTION_HORIZONTAL_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// For an up and down pan (-0.5 * PI Radians). Useful for AddDirection().
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DirectionVertical
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DIRECTION_VERTICAL_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// The default threshold is PI * 0.25 radians (or 45 degrees).
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Radian DefaultThreshold
        {
            get
            {
                global::System.IntPtr cPtr = Interop.PanGestureDetector.PanGestureDetector_DEFAULT_THRESHOLD_get();
                Radian ret = (cPtr == global::System.IntPtr.Zero) ? null : new Radian(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }
        }

        /// <summary>
        /// Retrieves the screen position.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScreenPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.SCREEN_POSITION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the screen displacement.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScreenDisplacement
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.SCREEN_DISPLACEMENT).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the screen velocity.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 ScreenVelocity
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.SCREEN_VELOCITY).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the local position.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 LocalPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.LOCAL_POSITION).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the local displacement
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 LocalDisplacement
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.LOCAL_DISPLACEMENT).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the local velocity.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 LocalVelocity
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.LOCAL_VELOCITY).Get(temp);
                return temp;
            }
        }

        /// <summary>
        /// Retrieves the panning flag.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Panning
        {
            get
            {
                bool temp = false;
                Tizen.NUI.Object.GetProperty(swigCPtr, PanGestureDetector.Property.PANNING).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// This is the minimum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <param name="minimum">Minimum touches required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMinimumTouchesRequired(uint minimum)
        {
            Interop.PanGestureDetector.PanGestureDetector_SetMinimumTouchesRequired(swigCPtr, minimum);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// This is the maximum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <param name="maximum">Maximum touches required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetMaximumTouchesRequired(uint maximum)
        {
            Interop.PanGestureDetector.PanGestureDetector_SetMaximumTouchesRequired(swigCPtr, maximum);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Retrieves the minimum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <returns>The minimum touches required</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetMinimumTouchesRequired()
        {
            uint ret = Interop.PanGestureDetector.PanGestureDetector_GetMinimumTouchesRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Retrieves the maximum number of touches required for the pan gesture to be detected.
        /// </summary>
        /// <returns>The maximum touches required</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetMaximumTouchesRequired()
        {
            uint ret = Interop.PanGestureDetector.PanGestureDetector_GetMaximumTouchesRequired(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The pan gesture is only emitted if the pan occurs in the direction specified by this method with a +/- threshold allowance.<br />
        /// If an angle of 0.0 degrees is specified and the threshold is 45 degrees then the acceptable direction range is from -45 to 45 degrees.<br />
        /// The angle added using this API is only checked when the gesture first starts, after that, this detector will emit the gesture regardless of what angle the pan is moving.
        /// The user can add as many angles as they require.
        /// </summary>
        /// <param name="angle">The angle that pan should be allowed</param>
        /// <param name="threshold">The threshold around that angle</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddAngle(Radian angle, Radian threshold)
        {
            Interop.PanGestureDetector.PanGestureDetector_AddAngle__SWIG_0(swigCPtr, Radian.getCPtr(angle), Radian.getCPtr(threshold));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The pan gesture is only emitted if the pan occurs in the direction specified by this method with a +/- threshold allowance. The default threshold (PI * 0.25) is used.<br />
        /// The angle added using this API is only checked when the gesture first starts, after that, this detector will emit the gesture regardless of what angle the pan is moving.<br />
        /// The user can add as many angles as they require.<br />
        /// </summary>
        /// <param name="angle">The angle that pan should be allowed</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddAngle(Radian angle)
        {
            Interop.PanGestureDetector.PanGestureDetector_AddAngle__SWIG_1(swigCPtr, Radian.getCPtr(angle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// A helper method for adding bi-directional angles where the pan should take place.<br />
        /// In other words, if 0 is requested, then PI will also be added so that we have both left and right scrolling.<br />
        /// </summary>
        /// <param name="direction">The direction of panning required</param>
        /// <param name="threshold">The threshold</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddDirection(Radian direction, Radian threshold)
        {
            Interop.PanGestureDetector.PanGestureDetector_AddDirection__SWIG_0(swigCPtr, Radian.getCPtr(direction), Radian.getCPtr(threshold));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// A helper method for adding bi-directional angles where the pan should take place.
        /// In other words, if 0 is requested, then PI will also be added so that we have both left and right scrolling.<br />
        /// The default threshold (PI * 0.25) is used.
        /// </summary>
        /// <param name="direction">The direction of panning required</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddDirection(Radian direction)
        {
            Interop.PanGestureDetector.PanGestureDetector_AddDirection__SWIG_1(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the count of angles that this pan gesture detector emits a signal.
        /// </summary>
        /// <returns>The gesture detector has been initialized.</returns>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetAngleCount()
        {
            uint ret = Interop.PanGestureDetector.PanGestureDetector_GetAngleCount(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Clears any directional angles that are used by the gesture detector.
        /// </summary>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAngles()
        {
            Interop.PanGestureDetector.PanGestureDetector_ClearAngles(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes the angle specified from the container. This will only remove the first instance of the angle found from the container.
        /// </summary>
        /// <param name="angle">The angle to remove</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveAngle(Radian angle)
        {
            Interop.PanGestureDetector.PanGestureDetector_RemoveAngle(swigCPtr, Radian.getCPtr(angle));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Removes the two angles that make up the direction from the container.
        /// </summary>
        /// <param name="direction">The direction to remove</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveDirection(Radian direction)
        {
            Interop.PanGestureDetector.PanGestureDetector_RemoveDirection(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Allows setting of the pan properties that are returned in constraints.
        /// </summary>
        /// <param name="pan">The pan gesture to set</param>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetPanGestureProperties(PanGesture pan)
        {
            Interop.PanGestureDetector.PanGestureDetector_SetPanGestureProperties(PanGesture.getCPtr(pan));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static PanGestureDetector GetPanGestureDetectorFromPtr(global::System.IntPtr cPtr)
        {
            PanGestureDetector ret = new PanGestureDetector(cPtr, false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(PanGestureDetector obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal new static PanGestureDetector DownCast(BaseHandle handle)
        {
            PanGestureDetector ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as PanGestureDetector;
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal AngleThresholdPair GetAngle(uint index)
        {
            AngleThresholdPair ret = new AngleThresholdPair(Interop.PanGestureDetector.PanGestureDetector_GetAngle(swigCPtr, index), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PanGestureDetector Assign(PanGestureDetector rhs)
        {
            PanGestureDetector ret = new PanGestureDetector(Interop.PanGestureDetector.PanGestureDetector_Assign(swigCPtr, PanGestureDetector.getCPtr(rhs)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal PanGestureDetectedSignal DetectedSignal()
        {
            PanGestureDetectedSignal ret = new PanGestureDetectedSignal(Interop.PanGestureDetector.PanGestureDetector_DetectedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            if (_detectedCallback != null)
            {
                DetectedSignal().Disconnect(_detectedCallback);
            }

            Interop.PanGestureDetector.delete_PanGestureDetector(swigCPtr);
        }

        private void OnPanGestureDetected(IntPtr actor, IntPtr panGesture)
        {
            DetectedEventArgs e = new DetectedEventArgs();

            // Populate all members of "e" (PanGestureEventArgs) with real data
            e.View = Registry.GetManagedBaseHandleFromNativePtr(actor) as View;
            if (null == e.View)
            {
                e.View = Registry.GetManagedBaseHandleFromRefObject(actor) as View;
            }

            e.PanGesture = Tizen.NUI.PanGesture.GetPanGestureFromPtr(panGesture);

            if (_detectedEventHandler != null)
            {
                _detectedEventHandler(this, e);
            }
        }

        /// <summary>
        /// Event arguments that are passed via the PanGestureEvent signal.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class DetectedEventArgs : EventArgs
        {
            private View _view;
            private PanGesture _panGesture;
            private bool handled = true;

            /// <summary>
            /// The attached view.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public View View
            {
                get
                {
                    return _view;
                }
                set
                {
                    _view = value;
                }
            }

            /// <summary>
            /// The PanGesture.
            /// </summary>
            /// <since_tizen> 5 </since_tizen>
            /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public PanGesture PanGesture
            {
                get
                {
                    return _panGesture;
                }
                set
                {
                    _panGesture = value;
                }
            }

            /// <summary>
            /// Gets or sets a value that indicates whether the event handler has completely handled the event or whether the system should continue its own processing.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public bool Handled
            {
                get => handled;
                set
                {
                    handled = value;
                    Interop.Actor.SetNeedGesturePropagation(View.getCPtr(_view), !value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending)
                        throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        internal class Property
        {
            internal static readonly int SCREEN_POSITION = Interop.PanGestureDetector.PanGestureDetector_Property_SCREEN_POSITION_get();
            internal static readonly int SCREEN_DISPLACEMENT = Interop.PanGestureDetector.PanGestureDetector_Property_SCREEN_DISPLACEMENT_get();
            internal static readonly int SCREEN_VELOCITY = Interop.PanGestureDetector.PanGestureDetector_Property_SCREEN_VELOCITY_get();
            internal static readonly int LOCAL_POSITION = Interop.PanGestureDetector.PanGestureDetector_Property_LOCAL_POSITION_get();
            internal static readonly int LOCAL_DISPLACEMENT = Interop.PanGestureDetector.PanGestureDetector_Property_LOCAL_DISPLACEMENT_get();
            internal static readonly int LOCAL_VELOCITY = Interop.PanGestureDetector.PanGestureDetector_Property_LOCAL_VELOCITY_get();
            internal static readonly int PANNING = Interop.PanGestureDetector.PanGestureDetector_Property_PANNING_get();
        }
    }
}
