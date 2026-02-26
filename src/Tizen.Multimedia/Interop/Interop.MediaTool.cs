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
using System.Runtime.InteropServices.Marshalling;

namespace Tizen.Multimedia
{
    internal static partial class Interop
    {
        internal static partial class MediaPacket
        {
            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void DisposedCallback(IntPtr handle, IntPtr userData);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Create(IntPtr format, IntPtr finalizeCb, IntPtr cbData, out IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_alloc", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Alloc(IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_destroy", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Destroy(IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_new", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int New(IntPtr format, IntPtr disposedCb, IntPtr cbData, out IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_ref", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Ref(IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_unref", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Unref(IntPtr handle);

            [DllImport(Libraries.MediaTool, EntryPoint = "media_packet_add_dispose_cb", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int AddDisposedCallback(IntPtr handle, DisposedCallback disposedCb, IntPtr userData, out int callbackId);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_format", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetFormat(IntPtr handle, out IntPtr format);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_buffer_data_ptr", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetBufferData(IntPtr handle, out IntPtr dataHandle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_buffer_size", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetBufferSize(IntPtr handle, out ulong size);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_buffer_size", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetBufferSize(IntPtr handle, ulong size);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_allocated_buffer_size", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetAllocatedBufferSize(IntPtr handle, out int size);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_number_of_video_planes", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetNumberOfVideoPlanes(IntPtr handle, out uint num);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_video_stride_width", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetVideoStrideWidth(IntPtr handle, int planeIndex, out int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_video_stride_height", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetVideoStrideHeight(IntPtr handle, int planeIndex, out int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_video_plane_data_ptr", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetVideoPlaneData(IntPtr handle, int planeIndex, out IntPtr dataHandle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_is_encoded", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int IsEncoded(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_flags", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetBufferFlags(IntPtr handle, out MediaPacketBufferFlags value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_flags", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetBufferFlags(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_reset_flags", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int ResetBufferFlags(IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_pts", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetPts(IntPtr handle, out ulong value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_dts", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetDts(IntPtr handle, out ulong value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_pts", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetPts(IntPtr handle, ulong value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_dts", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetDts(IntPtr handle, ulong value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_extra", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetExtra(IntPtr handle, IntPtr value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_extra", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetExtra(IntPtr handle, out IntPtr value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_rotate_method", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetRotation(IntPtr handle, RotationFlip rotationFlip);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_rotate_method", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetRotation(IntPtr handle, out RotationFlip rotationFlip);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_set_duration", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetDuration(IntPtr handle, ulong value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_duration", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetDuration(IntPtr handle, out ulong value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_get_tbm_surface", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetTbmSurface(IntPtr handle, out IntPtr surface);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_packet_has_tbm_surface_buffer", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int HasTbmSurface(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool hasTbmSurface);

        }

        internal static partial class MediaFormat
        {
            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_create", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Create(out IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_unref", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int Unref(IntPtr handle);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetType(IntPtr handle, out MediaFormatType type);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_container_mime", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetContainerMimeType(IntPtr handle,
                out MediaFormatContainerMimeType mimeType);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_container_mime", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetContainerMimeType(IntPtr handle,
                MediaFormatContainerMimeType mimeType);

            #region Video apis
            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_video_info", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetVideoInfo(IntPtr handle, out MediaFormatVideoMimeType mimeType,
                out int width, out int height, out int averageBps, out int maxBps);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_video_frame_rate", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetVideoFrameRate(IntPtr handle, out int frameRate);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_video_mime", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetVideoMimeType(IntPtr handle, MediaFormatVideoMimeType value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_video_width", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetVideoWidth(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_video_height", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetVideoHeight(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_video_avg_bps", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetVideoAverageBps(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_video_max_bps", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetVideoMaxBps(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_video_frame_rate", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetVideoFrameRate(IntPtr handle, int value);
            #endregion

            #region Audio apis
            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_audio_info", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetAudioInfo(IntPtr handle, out MediaFormatAudioMimeType mimeType,
                out int channel, out int sampleRate, out int bit, out int averageBps);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_audio_aac_header_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetAudioAacType(IntPtr handle, out MediaFormatAacType aacType);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_mime", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioMimeType(IntPtr handle, MediaFormatAudioMimeType value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_channel", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioChannel(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_samplerate", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioSampleRate(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_bit", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioBit(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_avg_bps", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioAverageBps(IntPtr handle, int value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_aac_header_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioAacType(IntPtr handle, MediaFormatAacType value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_audio_channel_mask", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetAudioChannelMask(IntPtr handle, ulong mask);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_audio_channel_mask", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetAudioChannelMask(IntPtr handle, out ulong mask);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_is_little_endian", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int IsLittleEndian(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool isLittleEndian);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_audio_bit_depth", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetAudioBitDepth(IntPtr handle, out int bitDepth);

            [DllImport(Libraries.MediaTool, EntryPoint = "media_format_channel_positions_from_mask", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int GetChannelPositionFromMask(IntPtr handle, ulong mask,
                ref MediaFormatAudioChannelPosition[] position);

            [DllImport(Libraries.MediaTool, EntryPoint = "media_format_channel_positions_to_mask", CallingConvention = CallingConvention.Cdecl)]
            internal static extern int GetMaskFromChannelPosition(IntPtr handle,
                MediaFormatAudioChannelPosition[] position, out ulong mask);
            #endregion

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_get_text_info", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int GetTextInfo(IntPtr handle,
                out MediaFormatTextMimeType mimeType, out MediaFormatTextType textType);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_text_mime", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetTextMimeType(IntPtr handle, MediaFormatTextMimeType value);

            [LibraryImport(Libraries.MediaTool, EntryPoint = "media_format_set_text_type", StringMarshalling = StringMarshalling.Utf8)]
            internal static partial int SetTextType(IntPtr handle, MediaFormatTextType value);
        }
    }
}
