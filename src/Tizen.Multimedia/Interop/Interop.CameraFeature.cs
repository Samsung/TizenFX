using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class CameraFeature
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PreviewResolutionCallback(int Width, int Height, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CaptureResolutionCallback(int Width, int Height, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool CaptureFormatCallback(CameraPixelFormat format, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PreviewFormatCallback(CameraPixelFormat format, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool FpsCallback(CameraFps fps, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool FpsByResolutionCallback(CameraFps fps, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AfModeCallback(CameraAutoFocusMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ExposureModeCallback(CameraExposureMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool IsoCallback(CameraIsoLevel iso, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool TheaterModeCallback(CameraTheaterMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool WhitebalanceCallback(CameraWhitebalance whitebalance, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool EffectCallback(CameraEffectMode effect, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SceneModeCallback(CameraSceneMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool FlashModeCallback(CameraFlashMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool StreamRotationCallback(CameraRotation rotation, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool StreamFlipCallback(CameraFlip flip, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PtzTypeCallback(CameraPtzType type, IntPtr userData);


        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_continuous_capture")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool ContinuousCaptureSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_face_detection")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool FaceDetectionSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_zero_shutter_lag")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool ZeroShutterLagSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_media_packet_preview_cb")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool MediaPacketPreviewCallbackSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_hdr_capture")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool HdrCaptureSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_anti_shake")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool AntiShakeSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_video_stabilization")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool VideoStabilizationSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_auto_contrast")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool AutoContrastSupport(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_preview_resolution")]
        internal static extern int SupportedPreviewResolutions(IntPtr handle, PreviewResolutionCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_capture_resolution")]
        internal static extern int SupportedCaptureResolutions(IntPtr handle, CaptureResolutionCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_capture_format")]
        internal static extern int SupportedCaptureFormats(IntPtr handle, CaptureFormatCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_preview_format")]
        internal static extern int SupportedPreviewFormats(IntPtr handle, PreviewFormatCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_fps")]
        internal static extern int SupportedFps(IntPtr handle, FpsCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_fps_by_resolution")]
        internal static extern int SupportedFpsByResolution(IntPtr handle, int width, int height, FpsByResolutionCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_af_mode")]
        internal static extern int SupportedAfModes(IntPtr handle, AfModeCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_exposure_mode")]
        internal static extern int SupportedExposureModes(IntPtr handle, ExposureModeCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_iso")]
        internal static extern int SupportedIso(IntPtr handle, IsoCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_theater_mode")]
        internal static extern int SupportedTheaterModes(IntPtr handle, TheaterModeCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_whitebalance")]
        internal static extern int SupportedWhitebalance(IntPtr handle, WhitebalanceCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_effect")]
        internal static extern int SupportedEffects(IntPtr handle, EffectCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_scene_mode")]
        internal static extern int SupportedSceneModes(IntPtr handle, SceneModeCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_flash_mode")]
        internal static extern int SupportedFlashModes(IntPtr handle, FlashModeCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_stream_rotation")]
        internal static extern int SupportedStreamRotations(IntPtr handle, StreamRotationCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_stream_flip")]
        internal static extern int SupportedStreamFlips(IntPtr handle, StreamFlipCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_ptz_type")]
        internal static extern int SupportedPtzTypes(IntPtr handle, PtzTypeCallback callback, IntPtr userData);
    }
}
