using System;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
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
            internal delegate void BufferStatusCallback(int statusCode, IntPtr arg);

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool SupportedCodecCallback(int codecType, IntPtr arg);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_create")]
            internal static extern int Create(out IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_destroy")]
            internal static extern int Destroy(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_codec")]
            internal static extern int Configure(IntPtr handle, int codecType, int flags);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_vdec_info")]
            internal static extern int SetVideoDecoderInfo(IntPtr handle, int width, int height);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_venc_info")]
            internal static extern int SetVideoEncoderInfo(IntPtr handle, int width, int height,
                int fps, int targetBits);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_adec_info")]
            internal static extern int SetAudioDecoderInfo(IntPtr handle, int sampleRate, int channel,
                int bit);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_aenc_info")]
            internal static extern int SetAudioEncoderInfo(IntPtr handle, int sampleRate, int channel,
                int bit, int bitRate);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_prepare")]
            internal static extern int Prepare(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unprepare")]
            internal static extern int Unprepare(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_process_input")]
            internal static extern int Process(IntPtr handle, IntPtr mediaPacket, ulong timeoutInUs);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_get_output")]
            internal static extern int GetOutput(IntPtr handle, out IntPtr packet, ulong timeoutInUs);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_flush_buffers")]
            internal static extern int FlushBuffers(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_input_buffer_used_cb")]
            internal static extern int SetInputBufferUsedCb(IntPtr handle,
                InputBufferUsedCallback cb, IntPtr arg);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_input_buffer_used_cb")]
            internal static extern int UnsetInputBufferUsedCb(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_output_buffer_available_cb")]
            internal static extern int SetOutputBufferAvaiableCb(IntPtr handle,
                OutputBufferAvailableCallback cb, IntPtr arg);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_output_buffer_available_cb")]
            internal static extern int UnsetOutputBufferAvaiableCb(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_error_cb")]
            internal static extern int SetErrorCb(IntPtr handle, ErrorCallback cb, IntPtr arg);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_error_cb")]
            internal static extern int UnsetErrorCb(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_eos_cb")]
            internal static extern int SetEosCb(IntPtr handle, EosCallback cb, IntPtr arg);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_eos_cb")]
            internal static extern int UnsetEosCb(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_set_buffer_status_cb")]
            internal static extern int SetBufferStatusCb(IntPtr handle, BufferStatusCallback cb,
                IntPtr arg);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_unset_buffer_status_cb")]
            internal static extern int UnsetBufferStatusCb(IntPtr handle);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_get_supported_type")]
            internal static extern int GetSupportedType(IntPtr handle, int codecType, bool isEncoder,
                out int value);

            [DllImport(Libraries.MediaCodec, EntryPoint = "mediacodec_foreach_supported_codec_static")]
            internal static extern int ForeachSupportedCodec(SupportedCodecCallback cb, IntPtr arg);
        }
    }
}