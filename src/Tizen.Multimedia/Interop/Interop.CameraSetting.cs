using System;
using System.Runtime.InteropServices;
using Tizen.Multimedia;

internal static partial class Interop
{
    internal static partial class CameraSetting
    {
        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_preview_fps")]
        internal static extern int SetPreviewFps(IntPtr handle, int fps);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_preview_fps")]
        internal static extern int GetPreviewFps(IntPtr handle, out int fps);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_image_quality")]
        internal static extern int SetImageQuality(IntPtr handle, int quality);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_image_quality")]
        internal static extern int GetImageQuality(IntPtr handle, out int quality);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_encoded_preview_bitrate")]
        internal static extern int SetBitrate(IntPtr handle, int bitrate);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_encoded_preview_bitrate")]
        internal static extern int GetBitrate(IntPtr handle, out int bitrate);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_encoded_preview_gop_interval")]
        internal static extern int SetGopInterval(IntPtr handle, int interval);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_encoded_preview_gop_interval")]
        internal static extern int GetGopInterval(IntPtr handle, out int interval);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_zoom")]
        internal static extern int SetZoom(IntPtr handle, int zoom);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_zoom")]
        internal static extern int GetZoom(IntPtr handle, out int zoom);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_zoom_range")]
        internal static extern int GetZoomRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_af_mode")]
        internal static extern int SetAfMode(IntPtr handle, int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_af_mode")]
        internal static extern int GetAfMode(IntPtr handle, out int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_af_area")]
        internal static extern int SetAfArea(IntPtr handle, int x, int y);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_clear_af_area")]
        internal static extern int ClearAfArea(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_exposure_mode")]
        internal static extern int SetExposureMode(IntPtr handle, int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_exposure_mode")]
        internal static extern int GetExposureMode(IntPtr handle, out int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_exposure")]
        internal static extern int SetExposure(IntPtr handle, int value);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_exposure")]
        internal static extern int GetExposure(IntPtr handle, out int value);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_exposure_range")]
        internal static extern int GetExposureRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_iso")]
        internal static extern int SetIso(IntPtr handle, int iso);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_iso")]
        internal static extern int GetIso(IntPtr handle, out int iso);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_theater_mode")]
        internal static extern int SetTheaterMode(IntPtr handle, int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_theater_mode")]
        internal static extern int GetTheaterMode(IntPtr handle, out int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_brightness")]
        internal static extern int SetBrightness(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_brightness")]
        internal static extern int GetBrightness(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_brightness_range")]
        internal static extern int GetBrightnessRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_contrast")]
        internal static extern int SetContrast(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_contrast")]
        internal static extern int GetContrast(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_contrast_range")]
        internal static extern int GetContrastRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_whitebalance")]
        internal static extern int SetWhitebalance(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_whitebalance")]
        internal static extern int GetWhitebalance(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_effect")]
        internal static extern int SetEffect(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_effect")]
        internal static extern int GetEffect(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_scene_mode")]
        internal static extern int SetSceneMode(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_scene_mode")]
        internal static extern int GetSceneMode(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_tag")]
        internal static extern int EnableTag(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_enabled_tag")]
        internal static extern int IsEnabledTag(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tag_image_description")]
        internal static extern int SetImageDescription(IntPtr handle, string description);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tag_image_description")]
        internal static extern int GetImageDescription(IntPtr handle, out IntPtr description);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tag_software")]
        internal static extern int SetTagSoftware(IntPtr handle, string software);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tag_software")]
        internal static extern int GetTagSoftware(IntPtr handle, out IntPtr software);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tag_orientation")]
        internal static extern int SetTagOrientation(IntPtr handle, int orientation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tag_orientation")]
        internal static extern int GetTagOrientation(IntPtr handle, out int orientation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_geotag")]
        internal static extern int SetGeotag(IntPtr handle, double latitude, double longtitude, double altitude);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_geotag")]
        internal static extern int GetGeotag(IntPtr handle, out double latitude, out double longtitude, out double altitude);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_remove_geotag")]
        internal static extern int RemoveGeotag(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_flash_mode")]
        internal static extern int SetFlashMode(IntPtr handle, int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_flash_mode")]
        internal static extern int GetFlashMode(IntPtr handle, out int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_lens_orientation")]
        internal static extern int GetLensOrientation(IntPtr handle, out int angle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_stream_rotation")]
        internal static extern int SetStreamRotation(IntPtr handle, int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_stream_rotation")]
        internal static extern int GetStreamRotation(IntPtr handle, out int mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_stream_flip")]
        internal static extern int SetFlip(IntPtr handle, int flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_stream_flip")]
        internal static extern int GetFlip(IntPtr handle, out int flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_hdr_mode")]
        internal static extern int SetHdrMode(IntPtr handle, int hdr);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_hdr_mode")]
        internal static extern int GetHdrMode(IntPtr handle, out int hdr);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_anti_shake")]
        internal static extern int EnableAntiShake(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = " camera_attr_is_enabled_anti_shake")]
        internal static extern int IsEnabledAntiShake(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_video_stabilization")]
        internal static extern int EnableVideoStabilization(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_enabled_video_stabilization")]
        internal static extern int IsEnabledVideoStabilization(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_auto_contrast")]
        internal static extern int EnableAutoContrast(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_enabled_auto_contrast")]
        internal static extern int IsEnabledAutoContrast(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_disable_shutter_sound")]
        internal static extern int DisableShutterSound(IntPtr handle, bool disable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_pan")]
        internal static extern int SetPan(IntPtr handle, int type, int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_pan")]
        internal static extern int GetPan(IntPtr handle, out int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_pan_range")]
        internal static extern int GetPanRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tilt")]
        internal static extern int SetTilt(IntPtr handle, int type, int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tilt")]
        internal static extern int GetTilt(IntPtr handle, out int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tilt_range")]
        internal static extern int GetTiltRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_ptz_type")]
        internal static extern int SetPtzType(IntPtr handle, int type);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_display_roi_area")]
        internal static extern int SetDisplayRoiArea(IntPtr handle, int x, int y, int width, int height);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_display_roi_area")]
        internal static extern int GetDisplayRoiArea(IntPtr handle, out int x, out int y, out int width, out int height);
    }
}

