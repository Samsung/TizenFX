using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
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
        internal delegate void FocusChangedCallback(CameraFocusState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ErrorCallback(CameraErrorCode error, CameraState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CapturingCallback(IntPtr image, IntPtr postview, IntPtr thumbnail, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CaptureCompletedCallback(IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PreviewCallback(IntPtr frame, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaPacketPreviewCallback(IntPtr mediaPacketHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void HdrCaptureProgressCallback(int percent, IntPtr userData);


        [DllImport(Libraries.Camera, EntryPoint = "camera_create")]
        internal static extern int Create(int device, out IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_change_device")]
        internal static extern int ChangeDevice(IntPtr handle, int device);

        [DllImport(Libraries.Camera, EntryPoint = "camera_destroy")]
        internal static extern int Destroy(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_device_count")]
        internal static extern int GetDeviceCount(IntPtr handle, out int count);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_preview")]
        internal static extern int StartPreview(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_stop_preview")]
        internal static extern int StopPreview(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_device_state")]
        internal static extern int GetDeviceState(CameraDevice device, out int state);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_capture")]
        internal static extern int StartCapture(IntPtr handle, CapturingCallback captureCallback,
                                                CaptureCompletedCallback completedCallback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_continuous_capture")]
        internal static extern int StartContinuousCapture(IntPtr handle, int count, int interval,
                                                          CapturingCallback captureCallback, CaptureCompletedCallback completedCallback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_stop_continuous_capture")]
        internal static extern int StopContinuousCapture(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_state")]
        internal static extern int GetState(IntPtr handle, out int state);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_focusing")]
        internal static extern int StartFocusing(IntPtr handle, bool continuous);

        [DllImport(Libraries.Camera, EntryPoint = "camera_cancel_focusing")]
        internal static extern int CancelFocusing(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display")]
        internal static extern int SetDisplay(IntPtr handle, int displayType, IntPtr displayHandle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_preview_resolution")]
        internal static extern int SetPreviewResolution(IntPtr handle, int width, int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_preview_resolution")]
        internal static extern int GetPreviewResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_recommended_preview_resolution")]
        internal static extern int GetRecommendedPreviewResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_start_face_detection")]
        internal static extern int StartFaceDetection(IntPtr handle, FaceDetectedCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_stop_face_detection")]
        internal static extern int StopFaceDetection(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_display_reuse_hint")]
        internal static extern int SetDisplayReuseHint(IntPtr handle, bool hint);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_display_reuse_hint")]
        internal static extern int GetDisplayReuseHint(IntPtr handle, out bool hint);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_capture_resolution")]
        internal static extern int SetCaptureResolution(IntPtr handle, int width, int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_capture_resolution")]
        internal static extern int GetCaptureResolution(IntPtr handle, out int width, out int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_capture_format")]
        internal static extern int SetCaptureFormat(IntPtr handle, int format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_capture_format")]
        internal static extern int GetCaptureFormat(IntPtr handle, out int format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_preview_format")]
        internal static extern int SetPreviewFormat(IntPtr handle, int format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_preview_format")]
        internal static extern int GetPreviewFormat(IntPtr handle, out int format);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_facing_direction")]
        internal static extern int GetFacingDirection(IntPtr handle, out int direction);

        [DllImport(Libraries.Camera, EntryPoint = "camera_get_flash_state")]
        internal static extern int GetFlashState(IntPtr handle, out int state);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_preview_cb")]
        internal static extern int SetPreviewCallback(IntPtr handle, PreviewCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_preview_cb")]
        internal static extern int UnsetPreviewCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_media_packet_preview_cb")]
        internal static extern int SetMediaPacketPreviewCallback(IntPtr handle, MediaPacketPreviewCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_media_packet_preview_cb")]
        internal static extern int UnsetMediaPacketPreviewCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_state_changed_cb")]
        internal static extern int SetStateChangedCallback(IntPtr handle, StateChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_state_changed_cb")]
        internal static extern int UnsetStateChangedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_remove_device_state_changed_cb")]
        internal static extern int UnsetDeviceStateChangedCallback(int cbId);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_interrupted_cb")]
        internal static extern int SetInterruptedCallback(IntPtr handle, InterruptedCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_interrupted_cb")]
        internal static extern int UnsetInterruptedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_focus_changed_cb")]
        internal static extern int SetFocusChangedCallback(IntPtr handle, FocusChangedCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_focus_changed_cb")]
        internal static extern int UnsetFocusChangedCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_set_error_cb")]
        internal static extern int SetErrorCallback(IntPtr handle, ErrorCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_unset_error_cb")]
        internal static extern int UnsetErrorCallback(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_hdr_capture_progress_cb")]
        internal static extern int SetHdrCaptureProgressCallback(IntPtr handle, HdrCaptureProgressCallback callback, IntPtr userData);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_unset_hdr_capture_progress_cb")]
        internal static extern int UnsetHdrCaptureProgressCallback(IntPtr handle);

        [StructLayout(LayoutKind.Sequential)]
        internal struct ImageDataStruct
        {
            internal IntPtr data;
            internal uint size;
            internal int width;
            internal int height;
            internal CameraPixelFormat format;
            internal IntPtr exif;
            internal uint exifSize;
        }

        internal static ImageDataStruct IntPtrToImageDataStruct(IntPtr unmanagedVariable)
        {
            ImageDataStruct ImageStruct = Marshal.PtrToStructure<ImageDataStruct>(unmanagedVariable);
            return ImageStruct;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DetectedFaceStruct
        {
            internal int id;
            internal int score;
            internal int x;
            internal int y;
            internal int width;
            internal int height;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct SinglePlane
        {
            internal IntPtr yuv;
            internal uint yuvsize;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct DoublePlane
        {
            internal IntPtr y;
            internal IntPtr uv;
            internal uint ysize;
            internal uint uvsize;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct TriplePlane
        {
            internal IntPtr y;
            internal IntPtr u;
            internal IntPtr v;
            internal uint ysize;
            internal uint usize;
            internal uint vsize;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct EncodedPlane
        {
            internal IntPtr data;
            internal uint size;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct PlaneData
        {
            [FieldOffsetAttribute(0)]
            internal SinglePlane singlePlane;
            [FieldOffsetAttribute(0)]
            internal DoublePlane doublePlane;
            [FieldOffsetAttribute(0)]
            internal TriplePlane triplePlane;
            [FieldOffsetAttribute(0)]
            internal EncodedPlane encodedPlane;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal struct CameraPreviewDataStruct
        {
            internal CameraPixelFormat format;
            internal int width;
            internal int height;
            internal int numOfPlanes;
            internal uint timestamp;
            internal PlaneData frameData;
        }

        internal static CameraPreviewDataStruct IntPtrToCameraPreviewDataStruct(IntPtr unmanagedVariable)
        {
            CameraPreviewDataStruct PreviewDataStruct = Marshal.PtrToStructure<CameraPreviewDataStruct>(unmanagedVariable);
            return PreviewDataStruct;
        }
    }
}
