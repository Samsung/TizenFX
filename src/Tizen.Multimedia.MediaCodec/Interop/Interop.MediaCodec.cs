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
using Tizen.Multimedia.MediaCodec;

internal static partial class Interop
{
    internal static partial class MediaCodec
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void InputBufferUsedCallback(IntPtr mediaPacket, IntPtr arg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void OutputBufferAvailableCallback(IntPtr mediaPacket, IntPtr arg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ErrorCallback(int errorCode, IntPtr arg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void EosCallback(IntPtr arg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void BufferStatusCallback(MediaCodecStatus statusCode, IntPtr arg);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedCodecCallback(int codecType, IntPtr arg);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_create")]
        internal static partial MediaCodecErrorCode Create(out IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_destroy")]
        internal static partial MediaCodecErrorCode Destroy(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_codec")]
        internal static partial MediaCodecErrorCode Configure(IntPtr handle, int codecType, int flags);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_vdec_info")]
        internal static partial MediaCodecErrorCode SetVideoDecoderInfo(IntPtr handle, int width, int height);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_venc_info")]
        internal static partial MediaCodecErrorCode SetVideoEncoderInfo(IntPtr handle, int width, int height,
            int fps, int targetBits);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_adec_info")]
        internal static partial MediaCodecErrorCode SetAudioDecoderInfo(IntPtr handle, int sampleRate, int channel,
            int bit);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_aenc_info")]
        internal static partial MediaCodecErrorCode SetAudioEncoderInfo(IntPtr handle, int sampleRate, int channel,
            int bit, int bitRate);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_prepare")]
        internal static partial MediaCodecErrorCode Prepare(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unprepare")]
        internal static partial MediaCodecErrorCode Unprepare(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_process_input")]
        internal static partial MediaCodecErrorCode Process(IntPtr handle, IntPtr mediaPacket, ulong timeoutInUs);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_get_output")]
        internal static partial MediaCodecErrorCode GetOutput(IntPtr handle, out IntPtr packet, ulong timeoutInUs);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_flush_buffers")]
        internal static partial MediaCodecErrorCode FlushBuffers(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_input_buffer_used_cb")]
        internal static partial MediaCodecErrorCode SetInputBufferUsedCb(IntPtr handle,
            InputBufferUsedCallback cb, IntPtr arg = default(IntPtr));

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_input_buffer_used_cb")]
        internal static partial MediaCodecErrorCode UnsetInputBufferUsedCb(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_output_buffer_available_cb")]
        internal static partial MediaCodecErrorCode SetOutputBufferAvailableCb(IntPtr handle,
            OutputBufferAvailableCallback cb, IntPtr arg = default(IntPtr));

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_output_buffer_available_cb")]
        internal static partial MediaCodecErrorCode UnsetOutputBufferAvailableCb(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_error_cb")]
        internal static partial MediaCodecErrorCode SetErrorCb(IntPtr handle, ErrorCallback cb, IntPtr arg = default(IntPtr));

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_error_cb")]
        internal static partial MediaCodecErrorCode UnsetErrorCb(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_eos_cb")]
        internal static partial MediaCodecErrorCode SetEosCb(IntPtr handle, EosCallback cb, IntPtr arg = default(IntPtr));

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_eos_cb")]
        internal static partial MediaCodecErrorCode UnsetEosCb(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_buffer_status_cb")]
        internal static partial MediaCodecErrorCode SetBufferStatusCb(IntPtr handle, BufferStatusCallback cb,
            IntPtr arg = default(IntPtr));

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_buffer_status_cb")]
        internal static partial MediaCodecErrorCode UnsetBufferStatusCb(IntPtr handle);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_get_supported_type")]
        internal static partial MediaCodecErrorCode GetSupportedType(IntPtr handle, int codecType, [MarshalAs(UnmanagedType.U1)] bool isEncoder,
            out int value);

        [LibraryImport(Libraries.MediaCodec, EntryPoint = "mediacodec_foreach_supported_codec_static")]
        internal static partial MediaCodecErrorCode ForeachSupportedCodec(SupportedCodecCallback cb, IntPtr arg);
    }
}


