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

    using System;
    using System.Runtime.InteropServices;
    using Tizen.NUI.BaseComponents;

    public class ScrollView : Scrollable
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;

        internal ScrollView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ScrollView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ScrollView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

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

            if (_scrollViewSnapStartedCallbackDelegate != null)
            {
                this.SnapStartedSignal().Disconnect(_scrollViewSnapStartedCallbackDelegate);
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    NDalicPINVOKE.delete_ScrollView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        /**
          * @brief Event arguments that passed via the SnapStarted signal
          *
          */
        public class SnapStartedEventArgs : EventArgs
        {
            private Tizen.NUI.ScrollView.SnapEvent _snapEvent;

            /**
              * @brief SnapEvent - is the SnapEvent information like snap or flick (it tells the target position, scale, rotation for the snap or flick).
              *
              */
            public Tizen.NUI.ScrollView.SnapEvent SnapEventInfo
            {
                get
                {
                    return _snapEvent;
                }
                set
                {
                    _snapEvent = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void SnapStartedCallbackDelegate(IntPtr data);
        private DaliEventHandler<object, SnapStartedEventArgs> _scrollViewSnapStartedEventHandler;
        private SnapStartedCallbackDelegate _scrollViewSnapStartedCallbackDelegate;

        /**
          * @brief Event for the SnapStarted signal which can be used to subscribe or unsubscribe the event handler
          * (in the type of SnapStartedEventHandler-DaliEventHandler<object,SnapStartedEventArgs>) provided by the user.
          * The SnapStarted signal is emitted when the ScrollView has started to snap or flick (it tells the target
          * position, scale, rotation for the snap or flick).
          *
          */
        public event DaliEventHandler<object, SnapStartedEventArgs> SnapStarted
        {
            add
            {
                lock (this)
                {
                    // Restricted to only one listener
                    if (_scrollViewSnapStartedEventHandler == null)
                    {
                        _scrollViewSnapStartedEventHandler += value;

                        _scrollViewSnapStartedCallbackDelegate = new SnapStartedCallbackDelegate(OnSnapStarted);
                        this.SnapStartedSignal().Connect(_scrollViewSnapStartedCallbackDelegate);
                    }
                }
            }

            remove
            {
                lock (this)
                {
                    if (_scrollViewSnapStartedEventHandler != null)
                    {
                        this.SnapStartedSignal().Disconnect(_scrollViewSnapStartedCallbackDelegate);
                    }

                    _scrollViewSnapStartedEventHandler -= value;
                }
            }
        }

        // Callback for ScrollView SnapStarted signal
        private void OnSnapStarted(IntPtr data)
        {
            SnapStartedEventArgs e = new SnapStartedEventArgs();

            // Populate all members of "e" (SnapStartedEventArgs) with real data
            e.SnapEventInfo = SnapEvent.GetSnapEventFromPtr(data);

            if (_scrollViewSnapStartedEventHandler != null)
            {
                //here we send all data to user event handlers
                _scrollViewSnapStartedEventHandler(this, e);
            }
        }

        public class SnapEvent : global::System.IDisposable
        {
            private global::System.Runtime.InteropServices.HandleRef swigCPtr;
            protected bool swigCMemOwn;

            internal SnapEvent(global::System.IntPtr cPtr, bool cMemoryOwn)
            {
                swigCMemOwn = cMemoryOwn;
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
            }

            internal static global::System.Runtime.InteropServices.HandleRef getCPtr(SnapEvent obj)
            {
                return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
            }

            //A Flag to check who called Dispose(). (By User or DisposeQueue)
            private bool isDisposeQueued = false;
            //A Flat to check if it is already disposed.
            protected bool disposed = false;


            ~SnapEvent()
            {
                if (!isDisposeQueued)
                {
                    isDisposeQueued = true;
                    DisposeQueue.Instance.Add(this);
                }
            }

            public void Dispose()
            {
                //Throw excpetion if Dispose() is called in separate thread.
                if (!Window.IsInstalled())
                {
                    throw new System.InvalidOperationException("This API called from separate thread. This API must be called from MainThread.");
                }

                if (isDisposeQueued)
                {
                    Dispose(DisposeTypes.Implicit);
                }
                else
                {
                    Dispose(DisposeTypes.Explicit);
                    System.GC.SuppressFinalize(this);
                }
            }

            protected virtual void Dispose(DisposeTypes type)
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
                        NDalicPINVOKE.delete_ScrollView_SnapEvent(swigCPtr);
                    }
                    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
                }

                disposed = true;
            }

            public static SnapEvent GetSnapEventFromPtr(global::System.IntPtr cPtr)
            {
                SnapEvent ret = new SnapEvent(cPtr, false);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                return ret;
            }

            internal SnapType type
            {
                set
                {
                    NDalicPINVOKE.ScrollView_SnapEvent_type_set(swigCPtr, (int)value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    SnapType ret = (SnapType)NDalicPINVOKE.ScrollView_SnapEvent_type_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public Vector2 position
            {
                set
                {
                    NDalicPINVOKE.ScrollView_SnapEvent_position_set(swigCPtr, Vector2.getCPtr(value));
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    global::System.IntPtr cPtr = NDalicPINVOKE.ScrollView_SnapEvent_position_get(swigCPtr);
                    Vector2 ret = (cPtr == global::System.IntPtr.Zero) ? null : new Vector2(cPtr, false);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public float duration
            {
                set
                {
                    NDalicPINVOKE.ScrollView_SnapEvent_duration_set(swigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
                get
                {
                    float ret = NDalicPINVOKE.ScrollView_SnapEvent_duration_get(swigCPtr);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    return ret;
                }
            }

            public SnapEvent() : this(NDalicPINVOKE.new_ScrollView_SnapEvent(), true)
            {
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }

        }

        public new class Property
        {
            public static readonly int WRAP_ENABLED = NDalicPINVOKE.ScrollView_Property_WRAP_ENABLED_get();
            public static readonly int PANNING_ENABLED = NDalicPINVOKE.ScrollView_Property_PANNING_ENABLED_get();
            public static readonly int AXIS_AUTO_LOCK_ENABLED = NDalicPINVOKE.ScrollView_Property_AXIS_AUTO_LOCK_ENABLED_get();
            public static readonly int WHEEL_SCROLL_DISTANCE_STEP = NDalicPINVOKE.ScrollView_Property_WHEEL_SCROLL_DISTANCE_STEP_get();
            public static readonly int SCROLL_MODE = NDalicPINVOKE.ScrollView_Property_SCROLL_MODE_get();
            public static readonly int SCROLL_POSITION = NDalicPINVOKE.ScrollView_Property_SCROLL_POSITION_get();
            public static readonly int SCROLL_PRE_POSITION = NDalicPINVOKE.ScrollView_Property_SCROLL_PRE_POSITION_get();
            public static readonly int SCROLL_PRE_POSITION_X = NDalicPINVOKE.ScrollView_Property_SCROLL_PRE_POSITION_X_get();
            public static readonly int SCROLL_PRE_POSITION_Y = NDalicPINVOKE.ScrollView_Property_SCROLL_PRE_POSITION_Y_get();
            public static readonly int SCROLL_PRE_POSITION_MAX = NDalicPINVOKE.ScrollView_Property_SCROLL_PRE_POSITION_MAX_get();
            public static readonly int SCROLL_PRE_POSITION_MAX_X = NDalicPINVOKE.ScrollView_Property_SCROLL_PRE_POSITION_MAX_X_get();
            public static readonly int SCROLL_PRE_POSITION_MAX_Y = NDalicPINVOKE.ScrollView_Property_SCROLL_PRE_POSITION_MAX_Y_get();
            public static readonly int OVERSHOOT_X = NDalicPINVOKE.ScrollView_Property_OVERSHOOT_X_get();
            public static readonly int OVERSHOOT_Y = NDalicPINVOKE.ScrollView_Property_OVERSHOOT_Y_get();
            public static readonly int SCROLL_FINAL = NDalicPINVOKE.ScrollView_Property_SCROLL_FINAL_get();
            public static readonly int SCROLL_FINAL_X = NDalicPINVOKE.ScrollView_Property_SCROLL_FINAL_X_get();
            public static readonly int SCROLL_FINAL_Y = NDalicPINVOKE.ScrollView_Property_SCROLL_FINAL_Y_get();
            public static readonly int WRAP = NDalicPINVOKE.ScrollView_Property_WRAP_get();
            public static readonly int PANNING = NDalicPINVOKE.ScrollView_Property_PANNING_get();
            public static readonly int SCROLLING = NDalicPINVOKE.ScrollView_Property_SCROLLING_get();
            public static readonly int SCROLL_DOMAIN_SIZE = NDalicPINVOKE.ScrollView_Property_SCROLL_DOMAIN_SIZE_get();
            public static readonly int SCROLL_DOMAIN_SIZE_X = NDalicPINVOKE.ScrollView_Property_SCROLL_DOMAIN_SIZE_X_get();
            public static readonly int SCROLL_DOMAIN_SIZE_Y = NDalicPINVOKE.ScrollView_Property_SCROLL_DOMAIN_SIZE_Y_get();
            public static readonly int SCROLL_DOMAIN_OFFSET = NDalicPINVOKE.ScrollView_Property_SCROLL_DOMAIN_OFFSET_get();
            public static readonly int SCROLL_POSITION_DELTA = NDalicPINVOKE.ScrollView_Property_SCROLL_POSITION_DELTA_get();
            public static readonly int START_PAGE_POSITION = NDalicPINVOKE.ScrollView_Property_START_PAGE_POSITION_get();

        }

        public ScrollView() : this(NDalicPINVOKE.ScrollView_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        public AlphaFunction GetScrollSnapAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(NDalicPINVOKE.ScrollView_GetScrollSnapAlphaFunction(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScrollSnapAlphaFunction(AlphaFunction alpha)
        {
            NDalicPINVOKE.ScrollView_SetScrollSnapAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public AlphaFunction GetScrollFlickAlphaFunction()
        {
            AlphaFunction ret = new AlphaFunction(NDalicPINVOKE.ScrollView_GetScrollFlickAlphaFunction(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScrollFlickAlphaFunction(AlphaFunction alpha)
        {
            NDalicPINVOKE.ScrollView_SetScrollFlickAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetScrollSnapDuration()
        {
            float ret = NDalicPINVOKE.ScrollView_GetScrollSnapDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScrollSnapDuration(float time)
        {
            NDalicPINVOKE.ScrollView_SetScrollSnapDuration(swigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetScrollFlickDuration()
        {
            float ret = NDalicPINVOKE.ScrollView_GetScrollFlickDuration(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScrollFlickDuration(float time)
        {
            NDalicPINVOKE.ScrollView_SetScrollFlickDuration(swigCPtr, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }


        public void SetScrollSensitive(bool sensitive)
        {
            NDalicPINVOKE.ScrollView_SetScrollSensitive(swigCPtr, sensitive);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetMaxOvershoot(float overshootX, float overshootY)
        {
            NDalicPINVOKE.ScrollView_SetMaxOvershoot(swigCPtr, overshootX, overshootY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetSnapOvershootAlphaFunction(AlphaFunction alpha)
        {
            NDalicPINVOKE.ScrollView_SetSnapOvershootAlphaFunction(swigCPtr, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetSnapOvershootDuration(float duration)
        {
            NDalicPINVOKE.ScrollView_SetSnapOvershootDuration(swigCPtr, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetViewAutoSnap(bool enable)
        {
            NDalicPINVOKE.ScrollView_SetActorAutoSnap(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetWrapMode(bool enable)
        {
            NDalicPINVOKE.ScrollView_SetWrapMode(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public int GetScrollUpdateDistance()
        {
            int ret = NDalicPINVOKE.ScrollView_GetScrollUpdateDistance(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetScrollUpdateDistance(int distance)
        {
            NDalicPINVOKE.ScrollView_SetScrollUpdateDistance(swigCPtr, distance);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool GetAxisAutoLock()
        {
            bool ret = NDalicPINVOKE.ScrollView_GetAxisAutoLock(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAxisAutoLock(bool enable)
        {
            NDalicPINVOKE.ScrollView_SetAxisAutoLock(swigCPtr, enable);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetAxisAutoLockGradient()
        {
            float ret = NDalicPINVOKE.ScrollView_GetAxisAutoLockGradient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetAxisAutoLockGradient(float gradient)
        {
            NDalicPINVOKE.ScrollView_SetAxisAutoLockGradient(swigCPtr, gradient);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFrictionCoefficient()
        {
            float ret = NDalicPINVOKE.ScrollView_GetFrictionCoefficient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFrictionCoefficient(float friction)
        {
            NDalicPINVOKE.ScrollView_SetFrictionCoefficient(swigCPtr, friction);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetFlickSpeedCoefficient()
        {
            float ret = NDalicPINVOKE.ScrollView_GetFlickSpeedCoefficient(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetFlickSpeedCoefficient(float speed)
        {
            NDalicPINVOKE.ScrollView_SetFlickSpeedCoefficient(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetMinimumDistanceForFlick()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.ScrollView_GetMinimumDistanceForFlick(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMinimumDistanceForFlick(Vector2 distance)
        {
            NDalicPINVOKE.ScrollView_SetMinimumDistanceForFlick(swigCPtr, Vector2.getCPtr(distance));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetMinimumSpeedForFlick()
        {
            float ret = NDalicPINVOKE.ScrollView_GetMinimumSpeedForFlick(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMinimumSpeedForFlick(float speed)
        {
            NDalicPINVOKE.ScrollView_SetMinimumSpeedForFlick(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public float GetMaxFlickSpeed()
        {
            float ret = NDalicPINVOKE.ScrollView_GetMaxFlickSpeed(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetMaxFlickSpeed(float speed)
        {
            NDalicPINVOKE.ScrollView_SetMaxFlickSpeed(swigCPtr, speed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetWheelScrollDistanceStep()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.ScrollView_GetWheelScrollDistanceStep(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void SetWheelScrollDistanceStep(Vector2 step)
        {
            NDalicPINVOKE.ScrollView_SetWheelScrollDistanceStep(swigCPtr, Vector2.getCPtr(step));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public Vector2 GetCurrentScrollPosition()
        {
            Vector2 ret = new Vector2(NDalicPINVOKE.ScrollView_GetCurrentScrollPosition(swigCPtr), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public uint GetCurrentPage()
        {
            uint ret = NDalicPINVOKE.ScrollView_GetCurrentPage(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public void ScrollTo(Vector2 position)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_0(swigCPtr, Vector2.getCPtr(position));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(Vector2 position, float duration)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_1(swigCPtr, Vector2.getCPtr(position), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_2(swigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(Vector2 position, float duration, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_3(swigCPtr, Vector2.getCPtr(position), duration, (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(Vector2 position, float duration, AlphaFunction alpha, DirectionBias horizontalBias, DirectionBias verticalBias)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_4(swigCPtr, Vector2.getCPtr(position), duration, AlphaFunction.getCPtr(alpha), (int)horizontalBias, (int)verticalBias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(uint page)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_5(swigCPtr, page);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(uint page, float duration)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_6(swigCPtr, page, duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(uint page, float duration, DirectionBias bias)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_7(swigCPtr, page, duration, (int)bias);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(View view)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_8(swigCPtr, View.getCPtr(view));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ScrollTo(View view, float duration)
        {
            NDalicPINVOKE.ScrollView_ScrollTo__SWIG_9(swigCPtr, View.getCPtr(view), duration);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public bool ScrollToSnapPoint()
        {
            bool ret = NDalicPINVOKE.ScrollView_ScrollToSnapPoint(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal void ApplyConstraintToChildren(SWIGTYPE_p_Dali__Constraint constraint)
        {
            NDalicPINVOKE.ScrollView_ApplyConstraintToChildren(swigCPtr, SWIGTYPE_p_Dali__Constraint.getCPtr(constraint));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void ApplyEffect(ScrollViewEffect effect)
        {
            NDalicPINVOKE.ScrollView_ApplyEffect(swigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveEffect(ScrollViewEffect effect)
        {
            NDalicPINVOKE.ScrollView_RemoveEffect(swigCPtr, ScrollViewEffect.getCPtr(effect));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveAllEffects()
        {
            NDalicPINVOKE.ScrollView_RemoveAllEffects(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void BindView(View child)
        {
            NDalicPINVOKE.ScrollView_BindActor(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void UnbindView(View child)
        {
            NDalicPINVOKE.ScrollView_UnbindActor(swigCPtr, View.getCPtr(child));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetScrollingDirection(Radian direction, Radian threshold)
        {
            NDalicPINVOKE.ScrollView_SetScrollingDirection__SWIG_0(swigCPtr, Radian.getCPtr(direction), Radian.getCPtr(threshold));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void SetScrollingDirection(Radian direction)
        {
            NDalicPINVOKE.ScrollView_SetScrollingDirection__SWIG_1(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        public void RemoveScrollingDirection(Radian direction)
        {
            NDalicPINVOKE.ScrollView_RemoveScrollingDirection(swigCPtr, Radian.getCPtr(direction));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal ScrollViewSnapStartedSignal SnapStartedSignal()
        {
            ScrollViewSnapStartedSignal ret = new ScrollViewSnapStartedSignal(NDalicPINVOKE.ScrollView_SnapStartedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        public bool WrapEnabled
        {
            get
            {
                bool temp = false;
                GetProperty(ScrollView.Property.WRAP_ENABLED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.WRAP_ENABLED, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool PanningEnabled
        {
            get
            {
                bool temp = false;
                GetProperty(ScrollView.Property.PANNING_ENABLED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.PANNING_ENABLED, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool AxisAutoLockEnabled
        {
            get
            {
                bool temp = false;
                GetProperty(ScrollView.Property.AXIS_AUTO_LOCK_ENABLED).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.AXIS_AUTO_LOCK_ENABLED, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 WheelScrollDistanceStep
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.WHEEL_SCROLL_DISTANCE_STEP).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.WHEEL_SCROLL_DISTANCE_STEP, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollPosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollPrePosition
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_PRE_POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_PRE_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollPrePositionMax
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_PRE_POSITION_MAX).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_PRE_POSITION_MAX, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float OvershootX
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ScrollView.Property.OVERSHOOT_X).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.OVERSHOOT_X, new Tizen.NUI.PropertyValue(value));
            }
        }
        public float OvershootY
        {
            get
            {
                float temp = 0.0f;
                GetProperty(ScrollView.Property.OVERSHOOT_Y).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.OVERSHOOT_Y, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollFinal
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_FINAL).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_FINAL, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool Wrap
        {
            get
            {
                bool temp = false;
                GetProperty(ScrollView.Property.WRAP).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.WRAP, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool Panning
        {
            get
            {
                bool temp = false;
                GetProperty(ScrollView.Property.PANNING).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.PANNING, new Tizen.NUI.PropertyValue(value));
            }
        }
        public bool Scrolling
        {
            get
            {
                bool temp = false;
                GetProperty(ScrollView.Property.SCROLLING).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLLING, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollDomainSize
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_DOMAIN_SIZE).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_DOMAIN_SIZE, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollDomainOffset
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_DOMAIN_OFFSET).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_DOMAIN_OFFSET, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector2 ScrollPositionDelta
        {
            get
            {
                Vector2 temp = new Vector2(0.0f, 0.0f);
                GetProperty(ScrollView.Property.SCROLL_POSITION_DELTA).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.SCROLL_POSITION_DELTA, new Tizen.NUI.PropertyValue(value));
            }
        }
        public Vector3 StartPagePosition
        {
            get
            {
                Vector3 temp = new Vector3(0.0f, 0.0f, 0.0f);
                GetProperty(ScrollView.Property.START_PAGE_POSITION).Get(temp);
                return temp;
            }
            set
            {
                SetProperty(ScrollView.Property.START_PAGE_POSITION, new Tizen.NUI.PropertyValue(value));
            }
        }

        public PropertyMap ScrollMode
        {
            get
            {
                PropertyValue value = GetProperty( ScrollView.Property.SCROLL_MODE );
                PropertyMap map = new PropertyMap();
                value.Get( map );
                return map;
            }
            set
            {
                SetProperty( ScrollView.Property.SCROLL_MODE, new PropertyValue( value ) );
            }
        }

    }

}
