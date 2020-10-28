/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
        #region Callback delegate
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ActivatedClientCallback(string clientName, IntPtr userData);


        // Received callbacks
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
            string requestId, MediaControllerNativeShuffleMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RepeatModeCommandReceivedCallback(string clientName,
            string requestId, MediaControllerNativeRepeatMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DisplayModeCommandReceivedCallback(string clientName,
            string requestId, MediaControlNativeDisplayMode mode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DisplayRotationCommandReceivedCallback(string clientName,
            string requestId, MediaControlNativeDisplayRotation rotation, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SimpleCommandReceivedCallback(string clientName,
            string requestId, bool isEnabled, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CustomCommandReceivedCallback(string clientName,
            string requestId, string customCommand, IntPtr bundleHandle, IntPtr userData);


        // Command callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CommandCompletedCallback(string clientName, string requestId, int result, IntPtr bundleHandle,
            IntPtr userData = default(IntPtr));

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SearchCommandReceivedCallback(string clientName, string requestId, IntPtr searchHandle,
            IntPtr userData = default(IntPtr));


        // Search callback
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool SearchItemCallback(MediaControlContentType type, MediaControlSearchCategory category,
            string keyword, IntPtr bundleHandle, IntPtr userData = default(IntPtr));
        #endregion Callback delegate


        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_create")]
        internal static extern MediaControllerError Create(out IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_foreach_client")]
        internal static extern MediaControllerError ForeachActivatedClient(IntPtr handle, ActivatedClientCallback callback,
            IntPtr userData = default(IntPtr));


        #region Set information
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

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_content_age_rating")]
        internal static extern MediaControllerError SetAgeRating(IntPtr handle, int rating);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_subtitles_enabled")]
        internal static extern MediaControllerError UpdateSubtitleMode(IntPtr handle, bool isEnabled);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_360_mode_enabled")]
        internal static extern MediaControllerError UpdateMode360(IntPtr handle, bool isEnabled);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_display_mode")]
        internal static extern MediaControllerError UpdateDisplayMode(IntPtr handle, MediaControlNativeDisplayMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_display_rotation")]
        internal static extern MediaControllerError UpdateDisplayRotaton(IntPtr handle, MediaControlNativeDisplayRotation rotation);
        #endregion Set information


        #region Received callback
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

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_subtitles_cmd_received_cb")]
        internal static extern MediaControllerError SetSubtitleModeCommandReceivedCb(IntPtr handle,
            SimpleCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_360_mode_cmd_received_cb")]
        internal static extern MediaControllerError SetMode360CommandReceivedCb(IntPtr handle,
            SimpleCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_display_mode_cmd_received_cb")]
        internal static extern MediaControllerError SetDisplayModeCommandReceivedCb(IntPtr handle,
            DisplayModeCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_display_rotation_cmd_received_cb")]
        internal static extern MediaControllerError SetDisplayRotationCommandReceivedCb(IntPtr handle,
            DisplayRotationCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_custom_cmd_received_cb")]
        internal static extern MediaControllerError SetCustomCommandReceivedCb(IntPtr handle,
            CustomCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_custom_cmd_received_cb")]
        internal static extern MediaControllerError UnsetCustomCommandReceivedCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_search_cmd_received_cb")]
        internal static extern MediaControllerError SetSearchCommandReceivedCb(IntPtr handle,
            SearchCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_search_cmd_received_cb")]
        internal static extern MediaControllerError UnsetSearchCommandReceivedCb(IntPtr handle);
        #endregion Received callback


        #region Database
        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_connect")]
        internal static extern MediaControllerError ConnectDb(out IntPtr dbHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_disconnect")]
        internal static extern MediaControllerError DisconnectDb(IntPtr dbHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_check_server_table_exist")]
        internal static extern MediaControllerError CheckServerExist(IntPtr dbHandle, string appId, out bool value);
        #endregion Database


        #region Playlist
        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_create_playlist")]
        internal static extern MediaControllerError CreatePlaylist(IntPtr handle, string name, out IntPtr playlist);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_delete_playlist")]
        internal static extern MediaControllerError DeletePlaylist(IntPtr handle, IntPtr playlist);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playlist_item_index")]
        internal static extern MediaControllerError SetIndexOfCurrentPlayingMedia(IntPtr handle, string index);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playlist_item_info")]
        internal static extern MediaControllerError SetInfoOfCurrentPlayingMedia(IntPtr handle, string name, string index);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_add_item_to_playlist")]
        internal static extern MediaControllerError AddItemToPlaylist(IntPtr handle,
            IntPtr playlist, string index, MediaControllerNativeAttribute attribute, string value);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_playlist_done")]
        internal static extern MediaControllerError SavePlaylist(IntPtr handle, IntPtr playlist);
        #endregion Playlist


        #region Capability
        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_content_type")]
        internal static extern MediaControllerError SetPlaybackContentType(IntPtr serverHandle,
            MediaControlContentType type);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_icon")]
        internal static extern MediaControllerError SetIconPath(IntPtr serverHandle, string uri);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_ability")]
        internal static extern MediaControllerError SetPlaybackCapability(IntPtr serverHandle,
            MediaControllerNativePlaybackAction action, MediaControlCapabilitySupport support);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_playback_ability")]
        internal static extern MediaControllerError SaveAndNotifyPlaybackCapabilityUpdated(IntPtr serverHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_display_mode_ability")]
        internal static extern MediaControllerError SetDisplayModeCapability(IntPtr serverHandle,
            uint modes, MediaControlCapabilitySupport support);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_display_rotation_ability")]
        internal static extern MediaControllerError SetDisplayRotationCapability(IntPtr serverHandle,
            uint rotations, MediaControlCapabilitySupport support);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_ability_support")]
        internal static extern MediaControllerError SetSimpleCapability(IntPtr serverHandle,
            MediaControlNativeCapabilityCategory category, MediaControlCapabilitySupport support);
        #endregion Capability


        #region Search
        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_foreach_condition")]
        internal static extern MediaControllerError ForeachSearchCondition(IntPtr serverHandle,
            SearchItemCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_clone")]
        internal static extern MediaControllerError CloneSearchHandle(IntPtr srcHandle, out IntPtr dstHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_destroy")]
        internal static extern MediaControllerError DestroySearchHandle(IntPtr searchHandle);

        #endregion Search


        #region Command
        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_cmd_reply")]
        internal static extern MediaControllerError SendCommandReplyBundle(IntPtr handle,
            string appId, string requestID, int result, SafeBundleHandle bundleHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_cmd_reply")]
        internal static extern MediaControllerError SendCommandReply(IntPtr handle,
            string appId, string requestID, int result, IntPtr bundleHandle);
        #endregion Command


        #region Event
        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_custom_event")]
        internal static extern MediaControllerError SendCustomEvent(IntPtr handle, string appId, string customEvent,
            IntPtr bundle, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_send_custom_event")]
        internal static extern MediaControllerError SendCustomEventBundle(IntPtr handle, string appId, string customEvent,
            SafeBundleHandle bundle, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_event_reply_received_cb")]
        internal static extern MediaControllerError SetEventReceivedCb(IntPtr handle, CommandCompletedCallback callback,
            IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_event_reply_received_cb")]
        internal static extern MediaControllerError UnsetEventReceivedCb(IntPtr handle);
        #endregion Event
    }
}
