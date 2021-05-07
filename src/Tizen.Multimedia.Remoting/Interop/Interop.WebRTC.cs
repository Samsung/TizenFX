/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen;
using Tizen.Applications;
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class NativeWebRTC
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ErrorOccurredCallback(IntPtr handle, WebRTCErrorCode error, WebRTCState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void StateChangedCallback(IntPtr handle, WebRTCState previous, WebRTCState current, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MediaPacketBufferStatusCallback(uint sourceId, MediaPacketBufferStatus status, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void NegotiationNeededCallback(IntPtr handle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void IceCandidateCallback(IntPtr handle, string candidate, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void TrackAddedCallback(IntPtr handle, MediaType type, uint id, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void FrameEncodedCallback(IntPtr handle, MediaType type, uint trackId, IntPtr packetHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SupportedMediaFormatCallback(int format, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void IceGatheringStateChangedCallback(IntPtr handle, WebRTCIceGatheringState state, IntPtr userData);


        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_create")]
        internal static extern WebRTCErrorCode Create(out WebRTCHandle handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_destroy")]
        internal static extern WebRTCErrorCode Destroy(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_start")]
        internal static extern WebRTCErrorCode Start(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_stop")]
        internal static extern WebRTCErrorCode Stop(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_get_state")]
        internal static extern WebRTCErrorCode GetState(IntPtr handle, out WebRTCState state);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_get_ice_gathering_state")]
        internal static extern WebRTCErrorCode GetIceGatheringState(IntPtr handle, out WebRTCIceGatheringState state);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_add_media_source")]
        internal static extern WebRTCErrorCode AddMediaSource(IntPtr handle, MediaSourceType type, out uint sourceId);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_remove_media_source")]
        internal static extern WebRTCErrorCode RemoveMediaSource(IntPtr handle, uint sourceId);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_media_packet_source_set_format")]
        internal static extern WebRTCErrorCode SetMediaPacketSourceInfo(IntPtr handle, uint sourceId, IntPtr packet);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_media_packet_source_push_packet")]
        internal static extern WebRTCErrorCode PushMediaPacket(IntPtr handle, IntPtr packet);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_get_transceiver_direction")]
        internal static extern WebRTCErrorCode GetTransceiverDirection(IntPtr handle, uint sourceId, MediaType type, out TransceiverDirection mode);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_transceiver_direction")]
        internal static extern WebRTCErrorCode SetTransceiverDirection(IntPtr handle, uint sourceId, MediaType type, TransceiverDirection mode);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_display")]
        internal static extern WebRTCErrorCode SetDisplay(IntPtr handle, uint trackId, WebRTCDisplayType type, IntPtr display);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_ecore_wl_display")]
        internal static extern WebRTCErrorCode SetEcoreDisplay(IntPtr handle, uint trackId, IntPtr display);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_get_stun_server")]
        internal static extern WebRTCErrorCode GetStunServer(IntPtr handle, out string server);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_stun_server")]
        internal static extern WebRTCErrorCode SetStunServer(IntPtr handle, string server);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_create_offer")]
        internal static extern WebRTCErrorCode CreateSDPOffer(IntPtr handle, SafeBundleHandle bundle, out string offer);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_create_answer")]
        internal static extern WebRTCErrorCode CreateSDPAnswer(IntPtr handle, SafeBundleHandle bundle, out string offer);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_local_description")]
        internal static extern WebRTCErrorCode SetLocalDescription(IntPtr handle, string description);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_remote_description")]
        internal static extern WebRTCErrorCode SetRemoteDescription(IntPtr handle, string description);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_add_ice_candidate")]
        internal static extern WebRTCErrorCode AddIceCandidate(IntPtr handle, string candidate);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_foreach_media_source_supported_format")]
        internal static extern WebRTCErrorCode SupportedMediaSourceFormat(IntPtr handle, SupportedMediaFormatCallback callback, IntPtr userData);


        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_error_cb")]
        internal static extern WebRTCErrorCode SetErrorOccurredCb(IntPtr handle, ErrorOccurredCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_error_cb")]
        internal static extern WebRTCErrorCode UnsetErrorOccurredCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_state_changed_cb")]
        internal static extern WebRTCErrorCode SetStateChangedCb(IntPtr handle, StateChangedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_state_changed_cb")]
        internal static extern WebRTCErrorCode UnsetStateChangedCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_media_packet_source_set_buffer_state_changed_cb")]
        internal static extern WebRTCErrorCode SetBufferStateChangedCb(IntPtr handle, uint sourceId, MediaPacketBufferStatusCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_media_packet_source_unset_buffer_state_changed_cb")]
        internal static extern WebRTCErrorCode UnsetBufferStateChangedCb(IntPtr handle, uint sourceId);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_negotiation_needed_cb")]
        internal static extern WebRTCErrorCode SetNegotiationNeededCb(IntPtr handle, NegotiationNeededCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_negotiation_needed_cb")]
        internal static extern WebRTCErrorCode UnsetNegotiationNeededCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_ice_candidate_cb")]
        internal static extern WebRTCErrorCode SetIceCandidateCb(IntPtr handle, IceCandidateCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_ice_candidate_cb")]
        internal static extern WebRTCErrorCode UnsetIceCandidateCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_track_added_cb")]
        internal static extern WebRTCErrorCode SetTrackAddedCb(IntPtr handle, TrackAddedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_track_added_cb")]
        internal static extern WebRTCErrorCode UnsetTrackAddedCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_encoded_audio_frame_cb")]
        internal static extern WebRTCErrorCode SetAudioFrameEncodedCb(IntPtr handle, FrameEncodedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_encoded_audio_frame_cb")]
        internal static extern WebRTCErrorCode UnsetAudioFrameEncodedCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_encoded_video_frame_cb")]
        internal static extern WebRTCErrorCode SetVideoFrameEncodedCb(IntPtr handle, FrameEncodedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_encoded_video_frame_cb")]
        internal static extern WebRTCErrorCode UnsetVideoFrameEncodedCb(IntPtr handle);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_set_ice_gathering_state_change_cb")]
        internal static extern WebRTCErrorCode SetIceGatheringStateChangedCb(IntPtr handle, IceGatheringStateChangedCallback callback, IntPtr userData = default);

        [DllImport(Libraries.WebRTC, EntryPoint = "webrtc_unset_ice_gathering_state_change_cb")]
        internal static extern WebRTCErrorCode UnsetIceGatheringStateChangedCb(IntPtr handle);
    }

    internal class WebRTCHandle : SafeHandle
    {
        protected WebRTCHandle()
          : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = NativeWebRTC.Destroy(handle);
            if (ret != WebRTCErrorCode.None)
            {
                return true;
            }

            Log.Debug(GetType().FullName, $"Failed to release native {GetType().Name}");
            return false;
        }
    }

}
