using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

namespace ElmSharp
{
    public class GestureLayer : EvasObject
    {
        private readonly Interop.Elementary.GestureEventCallback _gestureCallback;

        // Important: don't remove items from _handlers list
        // The list can grow up to (number of GestureType) * (number of GestureState)
        // but all gestures share the callback and you don't want to desynchronize mapping
        private readonly List<NativeCallback> _handlers = new List<NativeCallback>();

        public GestureLayer(EvasObject parent) : base(parent)
        {
            _gestureCallback = new Interop.Elementary.GestureEventCallback(GestureCallbackHandler);
        }

        public enum GestureType
        {
            Tap = 1,
            LongTap,
            DoubleTap,
            TripleTap,
            Momentum,
            Line,
            Flick,
            Zoom,
            Rotate,
        }

        public enum GestureState
        {
            Undefined = -1,
            Start,
            Move,
            End,
            Abort,
        }

        #region Properties
        public bool HoldEvents
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_hold_events_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_hold_events_set(Handle, value);
            }
        }

        public bool Continues
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_continues_enable_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_continues_enable_set(Handle, value);
            }
        }

        public int TapFingerSize
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_tap_finger_size_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_tap_finger_size_set(Handle, value);
            }
        }

        public double LongTapTimeout
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_long_tap_start_timeout_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_long_tap_start_timeout_set(Handle, value);
            }
        }

        public double DoubleTapTimeout
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_double_tap_timeout_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_double_tap_timeout_set(Handle, value);
            }
        }

        public int FlickTimeLimit
        {
            get
            {
                return (int)Interop.Elementary.elm_gesture_layer_flick_time_limit_ms_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_flick_time_limit_ms_set(Handle, (UInt32)value);
            }
        }

        public int MinimumLineLength
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_line_min_length_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_line_min_length_set(Handle, value);
            }
        }

        public double LineAngularTolerance
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_line_angular_tolerance_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_line_angular_tolerance_set(Handle, value);
            }
        }

        public int LineDistanceTolerance
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_line_distance_tolerance_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_line_distance_tolerance_set(Handle, value);
            }
        }

        public double RotateStep
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_rotate_step_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_rotate_step_set(Handle, value);
            }
        }

        public double RotateAngularTolerance
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_rotate_angular_tolerance_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_rotate_angular_tolerance_set(Handle, value);
            }
        }

        public double ZoomStep
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_zoom_step_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_zoom_step_set(Handle, value);
            }
        }

        public int ZoomDistanceTolerance
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_zoom_distance_tolerance_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_zoom_distance_tolerance_set(Handle, value);
            }
        }

        public double ZoomFingerFactor
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_zoom_finger_factor_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_zoom_finger_factor_set(Handle, value);
            }
        }

        public double ZoomWheelFactor
        {
            get
            {
                return Interop.Elementary.elm_gesture_layer_zoom_wheel_factor_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_gesture_layer_zoom_wheel_factor_set(Handle, value);
            }
        }
        #endregion Properties

        public void Attach(EvasObject target)
        {
            Interop.Elementary.elm_gesture_layer_attach(Handle, target.Handle);
        }

        public void SetGestureCallback(GestureType type, GestureState state, Action<object> action)
        {
            lock (_handlers)
            {
                bool found = false;
                int i = 0;
                // if this (type, state) already exists in _handlers, we will reuse it
                foreach (var handler in _handlers)
                {
                    if (handler.Type == type && handler.State == state)
                    {
                        found = true;
                        break;
                    }
                    i++;
                }
                if (found)
                {
                    // if we are changing null -> not-null, or not-null -> null, then inform the EFL
                    if (_handlers[i].Action == null ^ action == null)
                        Interop.Elementary.elm_gesture_layer_cb_set(Handle, type, state, action == null ? null : _gestureCallback, new IntPtr(i));
                    // overwrite previous action
                    _handlers[i].Action = action;
                }
                else
                {
                    if (action == null)
                    {
                        // ignore unsetting a handler for event which was not registered yet?
                        return;
                    }
                    // (type, state) was not found, so we are adding a new entry and registering the callback
                    _handlers.Add(new NativeCallback(type, state, action));
                    // callback is always the same, the event is recognised by the index in _handler list (the index is passed as data)
                    Interop.Elementary.elm_gesture_layer_cb_set(Handle, type, state, _gestureCallback, new IntPtr(i));
                }
            }
        }

        public void ClearCallbacks()
        {
            lock (_handlers)
            {
                int i = 0;
                foreach (var handler in _handlers)
                {
                    if (handler.Action != null)
                    {
                        Interop.Elementary.elm_gesture_layer_cb_set(Handle, handler.Type, handler.State, null, new IntPtr(i));
                        handler.Action = null;
                    }
                    i++;
                }
            }
        }

        #region Typed callback setting methods
        // Following methods have been added for convenience, so the user will not have to convert Info structures himself
        public void SetTapCallback(GestureType type, GestureState state, Action<TapData> action)
        {
            SetCallback(type, state, action);
        }

        public void SetMomentumCallback(GestureState state, Action<MomentumData> action)
        {
            SetCallback(GestureType.Momentum, state, action);
        }

        public void SetLineCallback(GestureState state, Action<LineData> action)
        {
            SetCallback(GestureType.Line, state, action);
        }

        public void SetFlickCallback(GestureState state, Action<LineData> action)
        {
            SetCallback(GestureType.Flick, state, action);
        }

        public void SetZoomCallback(GestureState state, Action<ZoomData> action)
        {
            SetCallback(GestureType.Zoom, state, action);
        }

        public void SetRotateCallback(GestureState state, Action<RotateData> action)
        {
            SetCallback(GestureType.Rotate, state, action);
        }
        #endregion Typed callback setting methods

        protected override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_gesture_layer_add(parent);
        }

        protected override void OnUnrealize()
        {
            ClearCallbacks();
            base.OnUnrealize();
        }

        private void SetCallback<T>(GestureType type, GestureState state, Action<T> action)
        {
            if (action == null)
                SetGestureCallback(type, state, null);
            else
                SetGestureCallback(type, state, new Action<object>((info) => action((T)info)));
        }

        private void GestureCallbackHandler(IntPtr data, IntPtr event_info)
        {
            // so EFL called our callback, lets use data to find the right Action to call
            var handlerIndex = (int)data;
            // thanks to the fact that we never remove item from _handlers, we don't need a lock here
            if (handlerIndex < 0 || handlerIndex >= _handlers.Count)
                return;
            Action<object> action = _handlers[handlerIndex].Action;
            if (action == null)
                return;
            // the interpretation of the event_info struct pointer depends on the GestureType
            switch (_handlers[handlerIndex].Type)
            {
                case GestureType.Tap:
                case GestureType.LongTap:
                case GestureType.DoubleTap:
                case GestureType.TripleTap:
                    action(Marshal.PtrToStructure<TapData>(event_info));
                    break;
                case GestureType.Momentum:
                    action(Marshal.PtrToStructure<MomentumData>(event_info));
                    break;
                case GestureType.Line:
                case GestureType.Flick:
                    action(Marshal.PtrToStructure<LineData>(event_info));
                    break;
                case GestureType.Zoom:
                    action(Marshal.PtrToStructure<ZoomData>(event_info));
                    break;
                case GestureType.Rotate:
                    action(Marshal.PtrToStructure<RotateData>(event_info));
                    break;
            }
        }

        #region Info structures

        [StructLayout(LayoutKind.Sequential)]
        public struct TapData
        {
            /// <summary>
            /// The x coordinate of the center point.
            /// </summary>
            public Int32 X;

            /// <summary>
            /// The y coordinate of the center point.
            /// </summary>
            public Int32 Y;

            #pragma warning disable 3003
            /// <summary>
            /// The number of fingers tapped.
            /// </summary>
            public UInt32 FingersCount;

            /// <summary>
            /// The timestamp.
            /// </summary>
            public UInt32 Timestamp;
            #pragma warning restore 3003
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MomentumData
        {
            /// <summary>
            /// Final-swipe direction starting point on X.
            /// </summary>
            public Int32 X1;

            /// <summary>
            /// Final-swipe direction starting point on Y.
            /// </summary>
            public Int32 Y1;

            /// <summary>
            /// Final-swipe direction ending point on X.
            /// </summary>
            public Int32 X2;

            /// <summary>
            /// Final-swipe direction ending point on Y
            /// </summary>
            public Int32 Y2;

            #pragma warning disable 3003
            /// <summary>
            /// Timestamp of start of final x-swipe.
            /// </summary>
            public UInt32 HorizontalSwipeTimestamp;

            /// <summary>
            /// Timestamp of start of final y-swipe.
            /// </summary>
            public UInt32 VerticalSwipeTimestamp;

            /// <summary>
            /// Momentum on X.
            /// </summary>
            public Int32 HorizontalMomentum;

            /// <summary>
            /// Momentum on Y.
            /// </summary>
            public Int32 VerticalMomentum;

            /// <summary>
            /// Number of fingers.
            /// </summary>
            public UInt32 FingersCount;
            #pragma warning restore 3003
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LineData
        {
            /// <summary>
            /// Final-swipe direction starting point on X.
            /// </summary>
            public Int32 X1;

            /// <summary>
            /// Final-swipe direction starting point on Y.
            /// </summary>
            public Int32 Y1;

            /// <summary>
            /// Final-swipe direction ending point on X.
            /// </summary>
            public Int32 X2;

            /// <summary>
            /// Final-swipe direction ending point on Y
            /// </summary>
            public Int32 Y2;

            #pragma warning disable 3003
            /// <summary>
            /// Timestamp of start of final x-swipe.
            /// </summary>
            public UInt32 HorizontalSwipeTimestamp;

            /// <summary>
            /// Timestamp of start of final y-swipe.
            /// </summary>
            public UInt32 VerticalSwipeTimestamp;

            /// <summary>
            /// Momentum on X.
            /// </summary>
            public Int32 HorizontalMomentum;

            /// <summary>
            /// Momentum on Y.
            /// </summary>
            public Int32 VerticalMomentum;

            /// <summary>
            /// Number of fingers.
            /// </summary>
            public UInt32 FingersCount;
            #pragma warning restore 3003

            /// <summary>
            /// Angle (direction) of lines.
            /// </summary>
            public double Angle;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct ZoomData
        {
            /// <summary>
            /// The x coordinate of zoom center point reported to user.
            /// </summary>
            public Int32 X;

            /// <summary>
            /// The y coordinate of zoom center point reported to user.
            /// </summary>
            public Int32 Y;

            /// <summary>
            /// The radius (distance) between fingers reported to user.
            /// </summary>
            public Int32 Radius;

            /// <summary>
            /// The zoom value. 1.0 means no zoom.
            /// </summary>
            public double Zoom;

            /// <summary>
            /// Zoom momentum: zoom growth per second (NOT YET SUPPORTED).
            /// </summary>
            private double Momentum;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RotateData
        {
            /// <summary>
            /// The x coordinate of rotation center point reported to user.
            /// </summary>
            public Int32 X;

            /// <summary>
            /// The y coordinate of rotation center point reported to user.
            /// </summary>
            public Int32 Y;

            /// <summary>
            /// The radius (distance) between fingers reported to user.
            /// </summary>
            public Int32 Radius;

            /// <summary>
            /// The start-angle.
            /// </summary>
            public double BaseAngle;

            /// <summary>
            /// The rotation value. 0.0 means no rotation.
            /// </summary>
            public double Angle;

            /// <summary>
            /// Rotation momentum: rotation done per second (NOT YET SUPPORTED).
            /// </summary>
            private double Momentum;
        }

        #endregion Info structures

        public static class Config
        {
            public static double DefaultLongTapTimeout
            {
                get {
                    return Interop.Elementary.elm_config_glayer_long_tap_start_timeout_get();
                }
                set {
                    Interop.Elementary.elm_config_glayer_long_tap_start_timeout_set(value);
                }
            }

            public static double DefaultDoubleTapTimeout
            {
                get {
                    return Interop.Elementary.elm_config_glayer_double_tap_timeout_get();
                }
                set {
                    Interop.Elementary.elm_config_glayer_double_tap_timeout_set(value);
                }
            }
        }

        private class NativeCallback
        {
            public readonly GestureType Type;
            public readonly GestureState State;
            public Action<object> Action;

            public NativeCallback(GestureType type, GestureState state, Action<object> action)
            {
                Type = type;
                State = state;
                Action = action;
            }
        }
    }
}
