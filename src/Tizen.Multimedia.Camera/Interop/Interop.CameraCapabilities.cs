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
    internal static partial class CameraCapabilities
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
        internal delegate bool WhitebalanceCallback(CameraWhiteBalance whitebalance, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool EffectCallback(CameraEffectMode effect, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SceneModeCallback(CameraSceneMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool FlashModeCallback(CameraFlashMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool StreamRotationCallback(Rotation rotation, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool StreamFlipCallback(Flips flip, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool PtzTypeCallback(CameraPtzType type, IntPtr userData);


        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_continuous_capture")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsContinuousCaptureSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_face_detection")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsFaceDetectionSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_zero_shutter_lag")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsZeroShutterLagSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_is_supported_media_packet_preview_cb")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsMediaPacketPreviewCallbackSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_hdr_capture")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsHdrCaptureSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_anti_shake")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsAntiShakeSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_video_stabilization")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsVideoStabilizationSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_supported_auto_contrast")]
        [return: MarshalAs(UnmanagedType.I1)]
        internal static extern bool IsAutoContrastSupported(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_preview_resolution")]
        internal static extern CameraError SupportedPreviewResolutions(IntPtr handle, PreviewResolutionCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_capture_resolution")]
        internal static extern CameraError SupportedCaptureResolutions(IntPtr handle, CaptureResolutionCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_capture_format")]
        internal static extern CameraError SupportedCapturePixelFormats(IntPtr handle, CaptureFormatCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_foreach_supported_preview_format")]
        internal static extern CameraError SupportedPreviewPixelFormats(IntPtr handle, PreviewFormatCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_fps")]
        internal static extern CameraError SupportedPreviewFps(IntPtr handle, FpsCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_fps_by_resolution")]
        internal static extern CameraError SupportedPreviewFpsByResolution(IntPtr handle, int width, int height, FpsByResolutionCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_af_mode")]
        internal static extern CameraError SupportedAutoFocusModes(IntPtr handle, AfModeCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_exposure_mode")]
        internal static extern CameraError SupportedExposureModes(IntPtr handle, ExposureModeCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_iso")]
        internal static extern CameraError SupportedIso(IntPtr handle, IsoCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_theater_mode")]
        internal static extern CameraError SupportedTheaterModes(IntPtr handle, TheaterModeCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_whitebalance")]
        internal static extern CameraError SupportedWhitebalance(IntPtr handle, WhitebalanceCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_effect")]
        internal static extern CameraError SupportedEffects(IntPtr handle, EffectCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_scene_mode")]
        internal static extern CameraError SupportedSceneModes(IntPtr handle, SceneModeCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_flash_mode")]
        internal static extern CameraError SupportedFlashModes(IntPtr handle, FlashModeCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_stream_rotation")]
        internal static extern CameraError SupportedStreamRotations(IntPtr handle, StreamRotationCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_stream_flip")]
        internal static extern CameraError SupportedStreamFlips(IntPtr handle, StreamFlipCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_foreach_supported_ptz_type")]
        internal static extern CameraError SupportedPtzTypes(IntPtr handle, PtzTypeCallback callback, IntPtr userData = default);
    }
}
