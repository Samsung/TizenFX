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
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class CameraDisplay
    {
        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_mode")]
        internal static extern CameraError GetMode(IntPtr handle, out CameraDisplayMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_mode")]
        internal static extern CameraError SetMode(IntPtr handle, CameraDisplayMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_display_visible")]
        internal static extern CameraError GetVisible(IntPtr handle, out bool visible);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_visible")]
        internal static extern CameraError SetVisible(IntPtr handle, bool visible);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_rotation")]
        internal static extern CameraError GetRotation(IntPtr handle, out Rotation rotation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_rotation")]
        internal static extern CameraError SetRotation(IntPtr handle, Rotation rotation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_flip")]
        internal static extern CameraError GetFlip(IntPtr handle, out Flips flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_flip")]
        internal static extern CameraError SetFlip(IntPtr handle, Flips flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_display_roi_area")]
        internal static extern CameraError GetRoiArea(IntPtr handle, out int x, out int y, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_display_roi_area")]
        internal static extern CameraError SetRoiArea(IntPtr handle, int x, int y, int width, int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display")]
        internal static extern CameraError SetTarget(IntPtr handle, DisplayType displayType, IntPtr displayHandle);
    }
}
