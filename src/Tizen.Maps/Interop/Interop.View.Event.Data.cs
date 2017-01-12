/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;
using ElmSharp;

internal static partial class Interop
{
    internal enum ViewAction
    {
        None, // MAPS_VIEW_ACTION_NONE
        Scroll, // MAPS_VIEW_ACTION_SCROLL
        Zoom, // MAPS_VIEW_ACTION_ZOOM
        ZoomIn, // MAPS_VIEW_ACTION_ZOOM_IN
        ZoomOut, // MAPS_VIEW_ACTION_ZOOM_OUT
        ZoomAndScroll, // MAPS_VIEW_ACTION_ZOOM_AND_SCROLL
        Rotate, // MAPS_VIEW_ACTION_ROTATE
    }

    internal enum ViewGesture
    {
        None, // MAPS_VIEW_GESTURE_NONE
        Scroll, // MAPS_VIEW_GESTURE_SCROLL
        Zoom, // MAPS_VIEW_GESTURE_ZOOM
        Tap, // MAPS_VIEW_GESTURE_TAP
        DoubleTap, // MAPS_VIEW_GESTURE_DOUBLE_TAP
        TwoFingerTap, // MAPS_VIEW_GESTURE_2_FINGER_TAP
        Rotate, // MAPS_VIEW_GESTURE_ROTATE
        LongPress, // MAPS_VIEW_GESTURE_LONG_PRESS
    }

    internal enum ViewEventType
    {
        Gesture, // MAPS_VIEW_EVENT_GESTURE
        Action, // MAPS_VIEW_EVENT_ACTION
        Object, // MAPS_VIEW_EVENT_OBJECT
        Ready, // MAPS_VIEW_EVENT_READY
    }

    internal static partial class ViewEventData
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_view_event_data_h */ origin, out IntPtr /* maps_view_event_data_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_center")]
        internal static extern ErrorCode GetCenter(IntPtr /* maps_view_event_data_h */ viewEvent, out IntPtr /* maps_coordinates_h */ center);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_delta")]
        internal static extern ErrorCode GetDelta(IntPtr /* maps_view_event_data_h */ viewEvent, out int deltaX, out int deltaY);
    }

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_type")]
    internal static extern ErrorCode GetType(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out ViewEventType /* maps_view_event_type_e */ eventType);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_gesture_type")]
    internal static extern ErrorCode GetGestureType(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out ViewGesture /* maps_view_gesture_e */ gestureType);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_action_type")]
    internal static extern ErrorCode GetActionType(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out ViewAction /* maps_view_action_e */ actionType);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_position")]
    internal static extern ErrorCode GetPosition(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out int x, out int y);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_fingers")]
    internal static extern ErrorCode GetFingers(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out int fingers);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_object")]
    internal static extern ErrorCode GetObject(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out IntPtr /* maps_view_object_h */ viewEventDataObject);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_coordinates")]
    internal static extern ErrorCode GetCoordinates(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out IntPtr /* maps_coordinates_h */ coordinates);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_zoom_factor")]
    internal static extern ErrorCode GetZoomFactor(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out double zoomFactor);

    [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_rotation_angle")]
    internal static extern ErrorCode GetRotationAngle(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out double rotationAngle);

    internal static ErrorCode GetPosition(this EventDataHandle /* maps_view_event_data_h */ viewEvent, out Point position)
    {
        position = new Point();
        return GetPosition(viewEvent, out position.X, out position.Y);
    }

    internal class EventDataHandle : SafeMapsHandle
    {
        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_view_event_data_h */ viewEvent);

        internal ViewEventType Type
        {
            get { return NativeGet<ViewEventType>(this.GetType); }
        }

        // event_data will be released automatically after this callback is terminated.
        internal EventDataHandle(IntPtr handle) : base(handle, false, Destroy)
        {
        }
    }

    internal class ObjectEventDataHandle : EventDataHandle
    {
        internal ViewGesture GestureType
        {
            get { return NativeGet<ViewGesture>(this.GetGestureType); }
        }

        internal Point Position
        {
            get { return NativeGet<Point>(this.GetPosition); }
        }

        internal int FingerCount
        {
            get { return NativeGet<int>(this.GetFingers); }
        }

        internal ViewObjectHandle ViewObject
        {
            get { return NativeGet(this.GetObject, ViewObjectHandle.Create); }
        }

        // event_data will be released automatically after this callback is terminated.
        internal ObjectEventDataHandle(IntPtr handle) : base(handle)
        {
        }
    }

    internal class GestureEventDataHandle : EventDataHandle
    {
        internal ViewGesture GestureType
        {
            get { return NativeGet<ViewGesture>(this.GetGestureType); }
        }

        internal Point Position
        {
            get { return NativeGet<Point>(this.GetPosition); }
        }

        internal int FingerCount
        {
            get { return NativeGet<int>(this.GetFingers); }
        }

        internal double ZoomFactor
        {
            get { return NativeGet<double>(this.GetZoomFactor); }
        }

        internal double RotationAngle
        {
            get { return NativeGet<double>(this.GetRotationAngle); }
        }

        internal CoordinatesHandle Coordinates
        {
            get { return NativeGet(this.GetCoordinates, CoordinatesHandle.Create); }
        }

        internal GestureEventDataHandle(IntPtr handle) : base(handle)
        {
        }
    }
}
