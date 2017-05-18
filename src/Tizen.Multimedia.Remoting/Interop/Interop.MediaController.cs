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
using Tizen.Applications;
using Tizen.Multimedia;
using Tizen.Multimedia.MediaController;

internal static partial class Interop
{
    internal static partial class MediaControllerClient
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ServerUpdatedCallback(IntPtr serverName, MediaControllerServerState serverState, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackUpdatedCallback(IntPtr serverName, IntPtr playback, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MetadataUpdatedCallback(IntPtr serverName, IntPtr metadata, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ShuffleModeUpdatedCallback(IntPtr serverName, MediaControllerShuffleMode shuffleMode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RepeatModeUpdatedCallback(IntPtr serverName, MediaControllerRepeatMode repeatMode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CommandReplyRecievedCallback(IntPtr serverName, int result, IntPtr bundle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SubscribedServerCallback(IntPtr serverName, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ActivatedServerCallback(IntPtr serverName, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_create")]
        internal static extern MediaControllerError Create(out IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_server_update_cb")]
        internal static extern MediaControllerError SetServerUpdatedCb(IntPtr handle, ServerUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_server_update_cb")]
        internal static extern MediaControllerError UnsetServerUpdatedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_playback_update_cb")]
        internal static extern MediaControllerError SetPlaybackUpdatedCb(IntPtr handle, PlaybackUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_playback_update_cb")]
        internal static extern MediaControllerError UnsetPlaybackUpdatedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_metadata_update_cb")]
        internal static extern MediaControllerError SetMetadataUpdatedCb(IntPtr handle, MetadataUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_metadata_update_cb")]
        internal static extern MediaControllerError UnsetMetadataUpdatedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_shuffle_mode_update_cb")]
        internal static extern MediaControllerError SetShuffleModeUpdatedCb(IntPtr handle, ShuffleModeUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_shuffle_mode_update_cb")]
        internal static extern MediaControllerError UnsetShuffleModeUpdatedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_repeat_mode_update_cb")]
        internal static extern MediaControllerError SetRepeatModeUpdatedCb(IntPtr handle, RepeatModeUpdatedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_repeat_mode_update_cb")]
        internal static extern MediaControllerError UnsetRepeatModeUpdatedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_subscribe")]
        internal static extern MediaControllerError Subscribe(IntPtr handle, MediaControllerSubscriptionType subscriptionType, string serverName);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unsubscribe")]
        internal static extern MediaControllerError Unsubscribe(IntPtr handle, MediaControllerSubscriptionType subscriptionType, string serverName);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_state")]
        internal static extern MediaControllerError GetPlaybackState(IntPtr playback, out MediaControllerPlaybackState state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_position")]
        internal static extern MediaControllerError GetPlaybackPosition(IntPtr playback, out ulong position);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_playback")]
        internal static extern MediaControllerError DestroyPlayback(IntPtr playback);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_metadata")]
        private static extern MediaControllerError GetMetadata(IntPtr metadata, MediaControllerAttributes attribute, out IntPtr value);

        internal static string GetMetadata(IntPtr handle, MediaControllerAttributes attr)
        {
            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                var ret = GetMetadata(handle, attr, out valuePtr);
                MediaControllerValidator.ThrowIfError(ret, "Failed to get value for " + attr);
                return Marshal.PtrToStringAnsi(valuePtr);
            }
            finally
            {
                LibcSupport.Free(valuePtr);
            }
        }

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_metadata")]
        internal static extern MediaControllerError DestroyMetadata(IntPtr metadata);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_latest_server_info")]
        internal static extern MediaControllerError GetLatestServer(IntPtr handle, out IntPtr serverName, out MediaControllerServerState serverState);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_playback_info")]
        internal static extern MediaControllerError GetServerPlayback(IntPtr handle, string serverName, out IntPtr playback);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_metadata")]
        internal static extern MediaControllerError GetServerMetadata(IntPtr handle, string serverName, out IntPtr metadata);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_shuffle_mode")]
        internal static extern MediaControllerError GetServerShuffleMode(IntPtr handle, string serverName, out MediaControllerShuffleMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_repeat_mode")]
        internal static extern MediaControllerError GetServerRepeatMode(IntPtr handle, string serverName, out MediaControllerRepeatMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_state_command")]
        internal static extern MediaControllerError SendPlaybackStateCommand(IntPtr handle, string serverName, MediaControllerPlaybackState state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_custom_command")]
        internal static extern MediaControllerError SendCustomCommand(IntPtr handle, string serverName, string command, SafeBundleHandle bundle, CommandReplyRecievedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server_subscribed")]
        internal static extern MediaControllerError ForeachSubscribedServer(IntPtr handle, MediaControllerSubscriptionType subscriptionType, SubscribedServerCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server")]
        internal static extern MediaControllerError ForeachActivatedServer(IntPtr handle, ActivatedServerCallback callback, IntPtr userData);
    }

    internal static partial class MediaControllerServer
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackStateCommandRecievedCallback(IntPtr clientName, MediaControllerPlaybackState state, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CustomCommandRecievedCallback(IntPtr clientName, IntPtr command, IntPtr bundle, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_create")]
        internal static extern MediaControllerError Create(out IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state")]
        internal static extern MediaControllerError SetPlaybackState(IntPtr handle, MediaControllerPlaybackState state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_position")]
        internal static extern MediaControllerError SetPlaybackPosition(IntPtr handle, ulong position);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_playback_info")]
        internal static extern MediaControllerError UpdatePlayback(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_metadata")]
        internal static extern MediaControllerError SetMetadata(IntPtr handle, MediaControllerAttributes attribute, string value);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_metadata")]
        internal static extern MediaControllerError UpdateMetadata(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_shuffle_mode")]
        internal static extern MediaControllerError UpdateShuffleMode(IntPtr handle, MediaControllerShuffleMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_repeat_mode")]
        internal static extern MediaControllerError UpdateRepeatMode(IntPtr handle, MediaControllerRepeatMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state_command_received_cb")]
        internal static extern MediaControllerError SetPlaybackStateCmdRecvCb(IntPtr handle, PlaybackStateCommandRecievedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playback_state_command_received_cb")]
        internal static extern MediaControllerError UnsetPlaybackStateCmdRecvCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_custom_command_received_cb")]
        internal static extern MediaControllerError SetCustomCmdRecvCb(IntPtr handle, CustomCommandRecievedCallback callback, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_custom_command_received_cb")]
        internal static extern MediaControllerError UnsetCustomCmdRecvCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_command_reply")]
        internal static extern MediaControllerError SendCommandReply(IntPtr handle, string clientName, int result, SafeBundleHandle bundle);
    }
}
