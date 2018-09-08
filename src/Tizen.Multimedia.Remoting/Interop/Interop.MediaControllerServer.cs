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
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class MediaControllerServer
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackStateCommandReceivedCallback(string clientName,
            MediaControllerNativePlaybackAction nativeAction, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackActionCommandReceivedCallback(string clientName,
            string requestId, MediaControllerNativePlaybackAction nativeAction, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackPositionCommandReceivedCallback(string clientName,
            string requestId, ulong playbackPosition, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaylistCommandReceivedCallback(string clientName,
            string requestId, string playlistName, string index, MediaControllerNativePlaybackAction nativeAction,
            ulong playbackPosition, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ShuffleModeCommandReceivedCallback(string clientName,
            string requestId, MediaControllerNativeShuffleMode shuffleMode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RepeatModeCommandReceivedCallback(string clientName,
            string requestId, MediaControllerNativeRepeatMode repeatMode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CustomCommandReceivedCallback(string clientName,
            string requestId, string customCommand, SafeBundleHandle bundleHandle, IntPtr userData);


        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_create")]
        internal static extern MediaControllerError Create(out IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state")]
        internal static extern MediaControllerError SetPlaybackState(IntPtr handle,
            MediaControllerNativePlaybackState state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_position")]
        internal static extern MediaControllerError SetPlaybackPosition(IntPtr handle, ulong position);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_playback_info")]
        internal static extern MediaControllerError UpdatePlayback(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_metadata")]
        internal static extern MediaControllerError SetMetadata(IntPtr handle,
            MediaControllerNativeAttribute attribute, string value);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_metadata")]
        internal static extern MediaControllerError UpdateMetadata(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_shuffle_mode")]
        internal static extern MediaControllerError UpdateShuffleMode(IntPtr handle,
            MediaControllerNativeShuffleMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_repeat_mode")]
        internal static extern MediaControllerError UpdateRepeatMode(IntPtr handle, MediaControllerNativeRepeatMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state_command_received_cb")]
        internal static extern MediaControllerError SetPlaybackStateCommandReceivedCb(IntPtr handle,
            PlaybackStateCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playback_state_command_received_cb")]
        internal static extern MediaControllerError UnsetPlaybackStateCmdRecvCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_action_cmd_received_cb")]
        internal static extern MediaControllerError SetPlaybackActionCommandReceivedCb(IntPtr handle,
            PlaybackActionCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playback_action_cmd_received_cb")]
        internal static extern MediaControllerError UnsetPlaybackActionCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_position_cmd_received_cb")]
        internal static extern MediaControllerError SetPlaybackPosotionCommandReceivedCb(IntPtr handle,
            PlaybackPositionCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playback_position_cmd_received_cb")]
        internal static extern MediaControllerError UnsetPlaybackPositionCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playlist_cmd_received_cb")]
        internal static extern MediaControllerError SetPlaylistCommandReceivedCb(IntPtr handle,
            PlaylistCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playlist_cmd_received_cb")]
        internal static extern MediaControllerError UnsetPlaylistCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_shuffle_mode_cmd_received_cb")]
        internal static extern MediaControllerError SetShuffleModeCommandReceivedCb(IntPtr handle,
            ShuffleModeCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_shuffle_mode_cmd_received_cb")]
        internal static extern MediaControllerError UnsetShuffleModeCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_repeat_mode_cmd_received_cb")]
        internal static extern MediaControllerError SetRepeatModeCommandReceivedCb(IntPtr handle,
            RepeatModeCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_repeat_mode_cmd_received_cb")]
        internal static extern MediaControllerError UnsetRepeatModeCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_custom_cmd_received_cb")]
        internal static extern MediaControllerError SetCustomCommandReceivedCb(IntPtr handle,
            CustomCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_custom_cmd_received_cb")]
        internal static extern MediaControllerError UnsetCustomCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_cmd_reply")]
        internal static extern MediaControllerError SendCommandReply(IntPtr handle,
            string appId, string requestID, int result, SafeBundleHandle bundleHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_connect")]
        internal static extern MediaControllerError ConnectDb(out IntPtr dbHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_disconnect")]
        internal static extern MediaControllerError DisconnectDb(IntPtr dbHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_check_server_table_exist")]
        internal static extern MediaControllerError CheckServerExist(IntPtr dbHandle, string appId, out bool value);
    }
}
