using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class CameraDisplay
    {
        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_rotation")]
        internal static extern int SetDisplayRotation(IntPtr handle, int rotation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_rotation")]
        internal static extern int GetDisplayRotation(IntPtr handle, out int rotation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_flip")]
        internal static extern int SetDisplayFlip(IntPtr handle, int flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_flip")]
        internal static extern int GetDisplayFlip(IntPtr handle, out int flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_visible")]
        internal static extern int SetDisplayVisible(IntPtr handle, bool visible);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_display_visible")]
        internal static extern int GetDisplayVisible(IntPtr handle, out bool visible);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_mode")]
        internal static extern int SetDisplayMode(IntPtr handle, int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_mode")]
        internal static extern int GetDisplayMode(IntPtr handle, out int mode);
    }
}
