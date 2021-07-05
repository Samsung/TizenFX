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
using Tizen.Internals;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class Camera
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void FaceDetectedCallback(IntPtr faces, int count, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(CameraState previous, CameraState current, bool byPolicy, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptedCallback(CameraPolicy policy, CameraState previous, CameraState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InterruptStartedCallback(CameraPolicy policy, CameraState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void FocusStateChangedCallback(CameraFocusState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ErrorCallback(CameraErrorCode error, CameraState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CapturingCallback(IntPtr image, IntPtr postview, IntPtr thumbnail, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CaptureCompletedCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PreviewCallback(IntPtr frame, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ExtraPreviewCallback(IntPtr frame, int streamId, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaPacketPreviewCallback(IntPtr mediaPacketHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void HdrCaptureProgressCallback(int percent, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DeviceStateChangedCallback(CameraDevice device, CameraDeviceState state, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_create")]
        internal static extern CameraError Create(CameraDevice device, out IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint ="camera_create_network")]
        internal static extern CameraError CreateNetworkCamera(CameraDevice device, out IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_change_device")]
        internal static extern CameraError ChangeDevice(IntPtr handle, CameraDevice device);

        [DllImport(Libraries.Camera, EntryPoint = "camera_destroy")]
        internal static extern CameraError Destroy(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_device_count")]
        internal static extern CameraError GetDeviceCount(IntPtr handle, out int count);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_preview")]
        internal static extern CameraError StartPreview(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_stop_preview")]
        internal static extern CameraError StopPreview(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_device_state")]
        internal static extern CameraError GetDeviceState(CameraDevice device, out CameraDeviceState state);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_capture")]
        internal static extern CameraError StartCapture(IntPtr handle, CapturingCallback captureCallback,
                                                CaptureCompletedCallback completedCallback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_continuous_capture")]
        internal static extern CameraError StartContinuousCapture(IntPtr handle, int count, int interval,
                                                          CapturingCallback captureCallback, CaptureCompletedCallback completedCallback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_stop_continuous_capture")]
        internal static extern CameraError StopContinuousCapture(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_state")]
        internal static extern CameraError GetState(IntPtr handle, out CameraState state);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_focusing")]
        internal static extern CameraError StartFocusing(IntPtr handle, bool continuous);

        [DllImport(Libraries.Camera, EntryPoint = "camera_cancel_focusing")]
        internal static extern CameraError CancelFocusing(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_preview_resolution")]
        internal static extern CameraError SetPreviewResolution(IntPtr handle, int width, int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_preview_resolution")]
        internal static extern CameraError GetPreviewResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_recommended_preview_resolution")]
        internal static extern CameraError GetRecommendedPreviewResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_face_detection")]
        internal static extern CameraError StartFaceDetection(IntPtr handle, FaceDetectedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_stop_face_detection")]
        internal static extern CameraError StopFaceDetection(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_reuse_hint")]
        internal static extern CameraError SetDisplayReuseHint(IntPtr handle, bool hint);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_reuse_hint")]
        internal static extern CameraError GetDisplayReuseHint(IntPtr handle, out bool hint);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_capture_resolution")]
        internal static extern CameraError SetCaptureResolution(IntPtr handle, int width, int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_capture_resolution")]
        internal static extern CameraError GetCaptureResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_capture_format")]
        internal static extern CameraError SetCaptureFormat(IntPtr handle, CameraPixelFormat format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_capture_format")]
        internal static extern CameraError GetCaptureFormat(IntPtr handle, out CameraPixelFormat format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_preview_format")]
        internal static extern CameraError SetPreviewPixelFormat(IntPtr handle, CameraPixelFormat format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_preview_format")]
        internal static extern CameraError GetPreviewPixelFormat(IntPtr handle, out CameraPixelFormat format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_facing_direction")]
        internal static extern CameraError GetFacingDirection(IntPtr handle, out CameraFacingDirection direction);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_flash_state")]
        internal static extern CameraError GetFlashState(CameraDevice device, out CameraFlashState state);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_extra_preview_stream_format")]
        internal static extern CameraError SetExtraPreviewStreamFormat(IntPtr handle, int streamId, CameraPixelFormat format,
            int width, int height, int fps);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_extra_preview_stream_format")]
        internal static extern CameraError GetExtraPreviewStreamFormat(IntPtr handle, int streamId, out CameraPixelFormat format,
            out int width, out int height, out int fps);


        [DllImport(Libraries.Camera, EntryPoint = "camera_set_preview_cb")]
        internal static extern CameraError SetPreviewCallback(IntPtr handle, PreviewCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_preview_cb")]
        internal static extern CameraError UnsetPreviewCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_media_packet_preview_cb")]
        internal static extern CameraError SetMediaPacketPreviewCallback(IntPtr handle, MediaPacketPreviewCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_media_packet_preview_cb")]
        internal static extern CameraError UnsetMediaPacketPreviewCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_extra_preview_cb")]
        internal static extern CameraError SetExtraPreviewCallback(IntPtr handle, ExtraPreviewCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_extra_preview_cb")]
        internal static extern CameraError UnsetExtraPreviewCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_state_changed_cb")]
        internal static extern CameraError SetStateChangedCallback(IntPtr handle, StateChangedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_state_changed_cb")]
        internal static extern CameraError UnsetStateChangedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_add_device_state_changed_cb")]
        internal static extern CameraError SetDeviceStateChangedCallback(DeviceStateChangedCallback callback, IntPtr userData, out int callbackId);

        [DllImport(Libraries.Camera, EntryPoint = "camera_remove_device_state_changed_cb")]
        internal static extern CameraError UnsetDeviceStateChangedCallback(int cbId);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_interrupt_started_cb")]
        internal static extern CameraError SetInterruptStartedCallback(IntPtr handle, InterruptStartedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_interrupt_started_cb")]
        internal static extern CameraError UnsetInterruptStartedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_interrupted_cb")]
        internal static extern CameraError SetInterruptedCallback(IntPtr handle, InterruptedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_interrupted_cb")]
        internal static extern CameraError UnsetInterruptedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_focus_changed_cb")]
        internal static extern CameraError SetFocusStateChangedCallback(IntPtr handle, FocusStateChangedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_focus_changed_cb")]
        internal static extern CameraError UnsetFocusChangedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_error_cb")]
        internal static extern CameraError SetErrorCallback(IntPtr handle, ErrorCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_error_cb")]
        internal static extern CameraError UnsetErrorCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_hdr_capture_progress_cb")]
        internal static extern CameraError SetHdrCaptureProgressCallback(IntPtr handle, HdrCaptureProgressCallback callback, IntPtr userData = default);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_unset_hdr_capture_progress_cb")]
        internal static extern CameraError UnsetHdrCaptureProgressCallback(IntPtr handle);


        [NativeStruct("camera_image_data_s", Include="camera.h", PkgConfig="capi-media-camera")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct StillImageDataStruct
        {
            internal IntPtr Data;
            internal uint DataLength;
            internal int Width;
            internal int Height;
            internal CameraPixelFormat Format;
            internal IntPtr Exif;
            internal uint ExifLength;
        }

        [NativeStruct("camera_detected_face_s", Include="camera.h", PkgConfig="capi-media-camera")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct DetectedFaceStruct
        {
            internal int Id;
            internal int Score;
            internal int X;
            internal int Y;
            internal int Width;
            internal int Height;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SinglePlaneStruct
        {
            internal IntPtr Data;
            internal uint DataLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DoublePlaneStruct
        {
            internal IntPtr Y;
            internal IntPtr UV;
            internal uint YLength;
            internal uint UVLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct TriplePlaneStruct
        {
            internal IntPtr Y;
            internal IntPtr U;
            internal IntPtr V;
            internal uint YLength;
            internal uint ULength;
            internal uint VLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct EncodedPlaneStruct
        {
            internal IntPtr Data;
            internal uint DataLength;
            internal bool IsDeltaFrame;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DepthPlaneStruct
        {
            internal IntPtr Data;
            internal uint DataLength;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct RgbPlaneStruct
        {
            internal IntPtr Data;
            internal uint DataLength;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct PreviewPlaneStruct
        {
            [FieldOffsetAttribute(0)]
            internal SinglePlaneStruct SinglePlane;
            [FieldOffsetAttribute(0)]
            internal DoublePlaneStruct DoublePlane;
            [FieldOffsetAttribute(0)]
            internal TriplePlaneStruct TriplePlane;
            [FieldOffsetAttribute(0)]
            internal EncodedPlaneStruct EncodedPlane;
            [FieldOffsetAttribute(0)]
            internal DepthPlaneStruct DepthPlane;
            [FieldOffsetAttribute(0)]
            internal RgbPlaneStruct RgbPlane;
        }

        [NativeStruct("camera_preview_data_s", Include="camera.h", PkgConfig="capi-media-camera")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct CameraPreviewDataStruct
        {
            internal CameraPixelFormat Format;
            internal int Width;
            internal int Height;
            internal int NumOfPlanes;
            internal uint TimeStamp;
            internal PreviewPlaneStruct Plane;
        }
    }

    internal static partial class CameraDeviceManager
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DeviceConnectionChangedCallback(ref CameraDeviceStruct device, bool status, IntPtr userData);


        [DllImport(Libraries.Camera, EntryPoint = "camera_device_manager_initialize")]
        internal static extern CameraError Initialize(out IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_device_manager_deinitialize")]
        internal static extern CameraError Deinitialize(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_device_manager_get_device_list")]
        internal static extern CameraError GetDeviceList(IntPtr handle, ref CameraDeviceListStruct deviceList);

        [DllImport(Libraries.Camera, EntryPoint = "camera_device_manager_add_device_connection_changed_cb")]
        internal static extern CameraError SetDeviceConnectionChangedCallback(IntPtr handle, DeviceConnectionChangedCallback callback, IntPtr userData, out int id);

        [DllImport(Libraries.Camera, EntryPoint = "camera_device_manager_remove_device_connection_changed_cb")]
        internal static extern CameraError UnsetDeviceConnectionChangedCallback(IntPtr handle, int id);


        [NativeStruct("camera_device_s", Include="camera_internal.h", PkgConfig="capi-media-camera")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct CameraDeviceStruct
        {
            internal CameraDeviceType Type;

            internal CameraDevice device;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            internal string name;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            internal string id;

            internal int extraStreamNum;
        }

        [NativeStruct("camera_device_list_s", Include="camera_internal.h", PkgConfig="capi-media-camera")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct CameraDeviceListStruct
        {
            internal uint count;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            internal CameraDeviceStruct[] device;
        }
    }
}