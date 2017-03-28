using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
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
            internal static extern CameraError GetRotation(IntPtr handle, out CameraRotation rotation);

            [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_rotation")]
            internal static extern CameraError SetRotation(IntPtr handle, CameraRotation rotation);

            [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_flip")]
            internal static extern CameraError GetFlip(IntPtr handle, out CameraFlip flip);

            [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_flip")]
            internal static extern CameraError SetFlip(IntPtr handle, CameraFlip flip);

            [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_display_roi_area")]
            internal static extern CameraError GetRoiArea(IntPtr handle, out int x, out int y, out int width, out int height);

            [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_display_roi_area")]
            internal static extern CameraError SetRoiArea(IntPtr handle, int x, int y, int width, int height);

            [DllImport(Libraries.Camera, EntryPoint = "camera_set_display")]
            internal static extern CameraError SetInfo(IntPtr handle, CameraDisplayType displayType, IntPtr displayHandle);
        }
    }
}