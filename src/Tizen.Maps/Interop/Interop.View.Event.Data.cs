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
        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_destroy")]
        internal static extern ErrorCode Destroy(IntPtr /* maps_view_event_data_h */ viewEvent);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_clone")]
        internal static extern ErrorCode Clone(IntPtr /* maps_view_event_data_h */ origin, out IntPtr /* maps_view_event_data_h */ cloned);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_type")]
        internal static extern ErrorCode GetType(IntPtr /* maps_view_event_data_h */ viewEvent, out ViewEventType /* maps_view_event_type_e */ eventType);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_gesture_type")]
        internal static extern ErrorCode GetGestureType(IntPtr /* maps_view_event_data_h */ viewEvent, out ViewGesture /* maps_view_gesture_e */ gestureType);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_action_type")]
        internal static extern ErrorCode GetActionType(IntPtr /* maps_view_event_data_h */ viewEvent, out ViewAction /* maps_view_action_e */ actionType);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_center")]
        internal static extern ErrorCode GetCenter(IntPtr /* maps_view_event_data_h */ viewEvent, out IntPtr /* maps_coordinates_h */ center);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_delta")]
        internal static extern ErrorCode GetDelta(IntPtr /* maps_view_event_data_h */ viewEvent, out int deltaX, out int deltaY);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_position")]
        internal static extern ErrorCode GetPosition(IntPtr /* maps_view_event_data_h */ viewEvent, out int x, out int y);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_coordinates")]
        internal static extern ErrorCode GetCoordinates(IntPtr /* maps_view_event_data_h */ viewEvent, out IntPtr /* maps_coordinates_h */ coordinates);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_fingers")]
        internal static extern ErrorCode GetFingers(IntPtr /* maps_view_event_data_h */ viewEvent, out int fingers);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_zoom_factor")]
        internal static extern ErrorCode GetZoomFactor(IntPtr /* maps_view_event_data_h */ viewEvent, out double zoomFactor);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_rotation_angle")]
        internal static extern ErrorCode GetRotationAngle(IntPtr /* maps_view_event_data_h */ viewEvent, out double rotationAngle);

        [DllImport(Libraries.MapService, EntryPoint = "maps_view_event_data_get_object")]
        internal static extern ErrorCode GetObject(IntPtr /* maps_view_event_data_h */ viewEvent, out IntPtr /* maps_view_object_h */ viewEventDataObject);
    }
}
