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
using Tizen.Multimedia.MediaCodec;

internal static partial class Interop
{
    internal static class MediaCodec
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

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_create")]
        internal static extern MediaCodecErrorCode Create(out IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_destroy")]
        internal static extern MediaCodecErrorCode Destroy(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_codec")]
        internal static extern MediaCodecErrorCode Configure(IntPtr handle, int codecType, int flags);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_vdec_info")]
        internal static extern MediaCodecErrorCode SetVideoDecoderInfo(IntPtr handle, int width, int height);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_venc_info")]
        internal static extern MediaCodecErrorCode SetVideoEncoderInfo(IntPtr handle, int width, int height,
            int fps, int targetBits);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_adec_info")]
        internal static extern MediaCodecErrorCode SetAudioDecoderInfo(IntPtr handle, int sampleRate, int channel,
            int bit);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_aenc_info")]
        internal static extern MediaCodecErrorCode SetAudioEncoderInfo(IntPtr handle, int sampleRate, int channel,
            int bit, int bitRate);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_prepare")]
        internal static extern MediaCodecErrorCode Prepare(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unprepare")]
        internal static extern MediaCodecErrorCode Unprepare(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_process_input")]
        internal static extern MediaCodecErrorCode Process(IntPtr handle, IntPtr mediaPacket, ulong timeoutInUs);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_get_output")]
        internal static extern MediaCodecErrorCode GetOutput(IntPtr handle, out IntPtr packet, ulong timeoutInUs);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_flush_buffers")]
        internal static extern MediaCodecErrorCode FlushBuffers(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_input_buffer_used_cb")]
        internal static extern MediaCodecErrorCode SetInputBufferUsedCb(IntPtr handle,
            InputBufferUsedCallback cb, IntPtr arg = default(IntPtr));

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_input_buffer_used_cb")]
        internal static extern MediaCodecErrorCode UnsetInputBufferUsedCb(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_output_buffer_available_cb")]
        internal static extern MediaCodecErrorCode SetOutputBufferAvailableCb(IntPtr handle,
            OutputBufferAvailableCallback cb, IntPtr arg = default(IntPtr));

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_output_buffer_available_cb")]
        internal static extern MediaCodecErrorCode UnsetOutputBufferAvailableCb(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_error_cb")]
        internal static extern MediaCodecErrorCode SetErrorCb(IntPtr handle, ErrorCallback cb, IntPtr arg = default(IntPtr));

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_error_cb")]
        internal static extern MediaCodecErrorCode UnsetErrorCb(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_eos_cb")]
        internal static extern MediaCodecErrorCode SetEosCb(IntPtr handle, EosCallback cb, IntPtr arg = default(IntPtr));

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_eos_cb")]
        internal static extern MediaCodecErrorCode UnsetEosCb(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_buffer_status_cb")]
        internal static extern MediaCodecErrorCode SetBufferStatusCb(IntPtr handle, BufferStatusCallback cb,
            IntPtr arg = default(IntPtr));

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_buffer_status_cb")]
        internal static extern MediaCodecErrorCode UnsetBufferStatusCb(IntPtr handle);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_get_supported_type")]
        internal static extern MediaCodecErrorCode GetSupportedType(IntPtr handle, int codecType, bool isEncoder,
            out int value);

        [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_foreach_supported_codec_static")]
        internal static extern MediaCodecErrorCode ForeachSupportedCodec(SupportedCodecCallback cb, IntPtr arg);
    }
}

