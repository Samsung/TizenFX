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
    internal static partial class CameraSettings
    {
        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_preview_fps")]
        internal static extern CameraError SetPreviewFps(IntPtr handle, CameraFps fps);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_preview_fps")]
        internal static extern CameraError GetPreviewFps(IntPtr handle, out CameraFps fps);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_image_quality")]
        internal static extern CameraError SetImageQuality(IntPtr handle, int quality);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_image_quality")]
        internal static extern CameraError GetImageQuality(IntPtr handle, out int quality);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_encoded_preview_bitrate")]
        internal static extern CameraError SetBitrate(IntPtr handle, int bitrate);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_encoded_preview_bitrate")]
        internal static extern CameraError GetBitrate(IntPtr handle, out int bitrate);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_encoded_preview_gop_interval")]
        internal static extern CameraError SetGopInterval(IntPtr handle, int interval);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_encoded_preview_gop_interval")]
        internal static extern CameraError GetGopInterval(IntPtr handle, out int interval);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_zoom")]
        internal static extern CameraError SetZoom(IntPtr handle, int zoom);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_zoom")]
        internal static extern CameraError GetZoom(IntPtr handle, out int zoom);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_zoom_range")]
        internal static extern CameraError GetZoomRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_af_mode")]
        internal static extern CameraError SetAutoFocusMode(IntPtr handle, CameraAutoFocusMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_af_mode")]
        internal static extern CameraError GetAutoFocusMode(IntPtr handle, out CameraAutoFocusMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_af_area")]
        internal static extern CameraError SetAutoFocusArea(IntPtr handle, int x, int y);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_clear_af_area")]
        internal static extern CameraError ClearAutoFocusArea(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_exposure_mode")]
        internal static extern CameraError SetExposureMode(IntPtr handle, CameraExposureMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_exposure_mode")]
        internal static extern CameraError GetExposureMode(IntPtr handle, out CameraExposureMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_exposure")]
        internal static extern CameraError SetExposure(IntPtr handle, int value);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_exposure")]
        internal static extern CameraError GetExposure(IntPtr handle, out int value);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_exposure_range")]
        internal static extern CameraError GetExposureRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_iso")]
        internal static extern CameraError SetIso(IntPtr handle, CameraIsoLevel iso);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_iso")]
        internal static extern CameraError GetIso(IntPtr handle, out CameraIsoLevel iso);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_theater_mode")]
        internal static extern CameraError SetTheaterMode(IntPtr handle, CameraTheaterMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_theater_mode")]
        internal static extern CameraError GetTheaterMode(IntPtr handle, out CameraTheaterMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_brightness")]
        internal static extern CameraError SetBrightness(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_brightness")]
        internal static extern CameraError GetBrightness(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_brightness_range")]
        internal static extern CameraError GetBrightnessRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_contrast")]
        internal static extern CameraError SetContrast(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_contrast")]
        internal static extern CameraError GetContrast(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_contrast_range")]
        internal static extern CameraError GetContrastRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_hue")]
        internal static extern CameraError SetHue(IntPtr handle, int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_hue")]
        internal static extern CameraError GetHue(IntPtr handle, out int level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_hue_range")]
        internal static extern CameraError GetHueRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_whitebalance")]
        internal static extern CameraError SetWhitebalance(IntPtr handle, CameraWhiteBalance level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_whitebalance")]
        internal static extern CameraError GetWhiteBalance(IntPtr handle, out CameraWhiteBalance level);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_effect")]
        internal static extern CameraError SetEffect(IntPtr handle, CameraEffectMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_effect")]
        internal static extern CameraError GetEffect(IntPtr handle, out CameraEffectMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_scene_mode")]
        internal static extern CameraError SetSceneMode(IntPtr handle, CameraSceneMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_scene_mode")]
        internal static extern CameraError GetSceneMode(IntPtr handle, out CameraSceneMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_tag")]
        internal static extern CameraError EnableTag(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_enabled_tag")]
        internal static extern CameraError IsEnabledTag(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tag_image_description")]
        internal static extern CameraError SetImageDescription(IntPtr handle, string description);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tag_image_description")]
        internal static extern CameraError GetImageDescription(IntPtr handle, out IntPtr description);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tag_software")]
        internal static extern CameraError SetTagSoftware(IntPtr handle, string software);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tag_software")]
        internal static extern CameraError GetTagSoftware(IntPtr handle, out IntPtr software);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tag_orientation")]
        internal static extern CameraError SetTagOrientation(IntPtr handle, CameraTagOrientation orientation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tag_orientation")]
        internal static extern CameraError GetTagOrientation(IntPtr handle, out CameraTagOrientation orientation);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_geotag")]
        internal static extern CameraError SetGeotag(IntPtr handle, double latitude, double longtitude, double altitude);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_geotag")]
        internal static extern CameraError GetGeotag(IntPtr handle, out double latitude, out double longtitude, out double altitude);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_remove_geotag")]
        internal static extern CameraError RemoveGeotag(IntPtr handle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_flash_mode")]
        internal static extern CameraError SetFlashMode(IntPtr handle, CameraFlashMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_flash_mode")]
        internal static extern CameraError GetFlashMode(IntPtr handle, out CameraFlashMode mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_lens_orientation")]
        internal static extern CameraError GetLensOrientation(IntPtr handle, out int angle);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_stream_rotation")]
        internal static extern CameraError SetStreamRotation(IntPtr handle, Rotation mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_stream_rotation")]
        internal static extern CameraError GetStreamRotation(IntPtr handle, out Rotation mode);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_stream_flip")]
        internal static extern CameraError SetFlip(IntPtr handle, Flips flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_stream_flip")]
        internal static extern CameraError GetFlip(IntPtr handle, out Flips flip);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_hdr_mode")]
        internal static extern CameraError SetHdrMode(IntPtr handle, CameraHdrMode hdr);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_hdr_mode")]
        internal static extern CameraError GetHdrMode(IntPtr handle, out CameraHdrMode hdr);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_anti_shake")]
        internal static extern CameraError EnableAntiShake(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = " camera_attr_is_enabled_anti_shake")]
        internal static extern CameraError IsEnabledAntiShake(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_video_stabilization")]
        internal static extern CameraError EnableVideoStabilization(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_enabled_video_stabilization")]
        internal static extern CameraError IsEnabledVideoStabilization(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_enable_auto_contrast")]
        internal static extern CameraError EnableAutoContrast(IntPtr handle, bool enable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_is_enabled_auto_contrast")]
        internal static extern CameraError IsEnabledAutoContrast(IntPtr handle, out bool enabled);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_disable_shutter_sound")]
        internal static extern CameraError DisableShutterSound(IntPtr handle, bool disable);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_pan")]
        internal static extern CameraError SetPan(IntPtr handle, CameraPtzMoveType type, int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_pan")]
        internal static extern CameraError GetPan(IntPtr handle, out int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_pan_range")]
        internal static extern CameraError GetPanRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_tilt")]
        internal static extern CameraError SetTilt(IntPtr handle, CameraPtzMoveType type, int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tilt")]
        internal static extern CameraError GetTilt(IntPtr handle, out int step);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_tilt_range")]
        internal static extern CameraError GetTiltRange(IntPtr handle, out int min, out int max);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_ptz_type")]
        internal static extern CameraError SetPtzType(IntPtr handle, CameraPtzType type);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_set_extra_preview_bitrate")]
        internal static extern CameraError SetExtraPreviewBitrate(IntPtr handle, int streamId, int bitrate);

        [DllImport(Libraries.Camera, EntryPoint = "camera_attr_get_extra_preview_bitrate")]
        internal static extern CameraError GetExtraPreviewBitrate(IntPtr handle, int streamId, out int bitrate);
    }
}
