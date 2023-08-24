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
    internal static partial class MediaControllerClient
    {
        #region Callback delegate
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ActivatedServerCallback(string serverName, IntPtr userData);


        // Updated callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ServerUpdatedCallback(string serverName, MediaControllerNativeServerState serverState,
            IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackUpdatedCallback(string serverName, IntPtr playback, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ShuffleModeUpdatedCallback(string serverName, MediaControllerNativeShuffleMode shuffleMode,
            IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RepeatModeUpdatedCallback(string serverName, MediaControllerNativeRepeatMode repeatMode,
            IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DisplayModeUpdatedCallback(string serverName, MediaControlNativeDisplayMode isEnabned, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void DisplayRotationUpdatedCallback(string serverName, MediaControlNativeDisplayRotation isEnabned, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void BoolAttributeUpdatedCallback(string serverName, bool isEnabled, IntPtr userData);


        // Capability updated callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackCapabilityUpdatedCallback(string serverName, IntPtr capaHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CategoryAttributeCapabilityUpdatedCallback(string serverName, uint updatedItem,
            IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void SimpleCapabilityUpdatedCallback(string serverName, MediaControlNativeCapabilityCategory category,
            MediaControlCapabilitySupport support, IntPtr userData);


        // Command callbacks
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CommandCompletedCallback(string serverName, string requestId, int result,
            IntPtr bundleHandle, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CustomCommandReceivedCallback(string serverName, string requestId, string customEvent, IntPtr bundleHandle, IntPtr userData);
        #endregion Callback delegate


        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_create")]
        internal static extern MediaControllerError Create(out MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_playback")]
        internal static extern MediaControllerError DestroyPlayback(IntPtr playback);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server")]
        internal static extern MediaControllerError ForeachActivatedServer(MediaControllerClientHandle handle,
            ActivatedServerCallback callback, IntPtr userData);


        #region Get information
        // Playback information
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_playback_info")]
        internal static extern MediaControllerError GetServerPlaybackHandle(MediaControllerClientHandle handle,
            string serverName, out IntPtr playback);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_state")]
        internal static extern MediaControllerError GetPlaybackState(IntPtr playbackHandle, out MediaControllerNativePlaybackState state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_position")]
        internal static extern MediaControllerError GetPlaybackPosition(IntPtr playbackHandle, out ulong position);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_age_rating")]
        internal static extern MediaControllerError GetAgeRating(IntPtr playbackHandle, out int rating);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_content_type")]
        internal static extern MediaControllerError GetPlaybackContentType(IntPtr playbackHandle,
            out MediaControlContentType type);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_latest_server_info")]
        internal static extern MediaControllerError GetLatestServer(MediaControllerClientHandle handle,
            out IntPtr serverName, out MediaControllerNativeServerState serverState);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_shuffle_mode")]
        internal static extern MediaControllerError GetServerShuffleMode(MediaControllerClientHandle handle,
            string serverName, out MediaControllerNativeShuffleMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_repeat_mode")]
        internal static extern MediaControllerError GetServerRepeatMode(MediaControllerClientHandle handle,
            string serverName, out MediaControllerNativeRepeatMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_icon")]
        internal static extern MediaControllerError GetServerIcon(MediaControllerClientHandle clientHandle,
            string serverName, out string uri);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_subtitles_enabled")]
        internal static extern MediaControllerError IsSubtitleEnabled(MediaControllerClientHandle clientHandle,
            string serverName, out bool isEnabled);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_360_mode_enabled")]
        internal static extern MediaControllerError IsMode360Enabled(MediaControllerClientHandle clientHandle,
            string serverName, out bool isEnabled);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_display_mode")]
        internal static extern MediaControllerError GetDisplayMode(MediaControllerClientHandle clientHandle,
            string serverName, out MediaControlNativeDisplayMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_display_rotation")]
        internal static extern MediaControllerError GetDisplayRotation(MediaControllerClientHandle clientHandle,
            string serverName, out MediaControlNativeDisplayRotation mode);
        #endregion Get information


        #region Updated callback
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_server_updated_cb")]
        internal static extern MediaControllerError SetServerUpdatedCb(MediaControllerClientHandle handle,
            ServerUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_server_updated_cb")]
        internal static extern MediaControllerError UnsetServerUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_playback_updated_cb")]
        internal static extern MediaControllerError SetPlaybackUpdatedCb(MediaControllerClientHandle handle,
            PlaybackUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_playback_updated_cb")]
        internal static extern MediaControllerError UnsetPlaybackUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_shuffle_mode_updated_cb")]
        internal static extern MediaControllerError SetShuffleModeUpdatedCb(MediaControllerClientHandle handle,
            ShuffleModeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_shuffle_mode_updated_cb")]
        internal static extern MediaControllerError UnsetShuffleModeUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_repeat_mode_updated_cb")]
        internal static extern MediaControllerError SetRepeatModeUpdatedCb(MediaControllerClientHandle handle,
            RepeatModeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_repeat_mode_updated_cb")]
        internal static extern MediaControllerError UnsetRepeatModeUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_subtitles_updated_cb")]
        internal static extern MediaControllerError SetSubtitleUpdatedCb(MediaControllerClientHandle handle,
            BoolAttributeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_360_mode_updated_cb")]
        internal static extern MediaControllerError SetMode360UpdatedCb(MediaControllerClientHandle handle,
            BoolAttributeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_display_mode_updated_cb")]
        internal static extern MediaControllerError SetDisplayModeUpdatedCb(MediaControllerClientHandle handle,
            DisplayModeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_display_rotation_updated_cb")]
        internal static extern MediaControllerError SetDisplayRotationUpdatedCb(MediaControllerClientHandle handle,
            DisplayRotationUpdatedCallback callback, IntPtr userData = default(IntPtr));
        #endregion Updated callback


        #region Capability
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_playback_ability")]
        internal static extern MediaControllerError GetPlaybackCapabilityHandle(MediaControllerClientHandle clientHandle,
            string serverName, out IntPtr capaHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playback_action_is_supported")]
        internal static extern MediaControllerError GetPlaybackCapability(IntPtr capaHandle,
            MediaControllerNativePlaybackAction action, out MediaControlCapabilitySupport support);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playback_ability_destroy")]
        internal static extern MediaControllerError DestroyCapability(IntPtr capaHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_playback_ability_clone")]
        internal static extern MediaControllerError CloneCapability(IntPtr capaSrcHandle, out IntPtr capaDstHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_display_mode_ability")]
        internal static extern MediaControllerError GetDisplayModeCapability(MediaControllerClientHandle clientHandle,
            string serverName, out uint support);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_display_rotation_ability")]
        internal static extern MediaControllerError GetDisplayRotationCapability(MediaControllerClientHandle clientHandle,
            string serverName, out uint support);

        // Common
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_ability_support")]
        internal static extern MediaControllerError GetSimpleCapability(MediaControllerClientHandle clientHandle,
            string serverName, MediaControlNativeCapabilityCategory category, out MediaControlCapabilitySupport type);
        #endregion Capability


        #region Capability updated callback
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_playback_ability_updated_cb")]
        internal static extern MediaControllerError SetPlaybackCapabilityUpdatedCb(MediaControllerClientHandle clientHandle,
            PlaybackCapabilityUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_playback_ability_updated_cb")]
        internal static extern MediaControllerError UnsetPlaybackCapabilityUpdatedCb(MediaControllerClientHandle clientHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_display_mode_ability_updated_cb")]
        internal static extern MediaControllerError SetDisplayModeCapabilityUpdatedCb(MediaControllerClientHandle clientHandle,
            CategoryAttributeCapabilityUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_display_rotation_ability_updated_cb")]
        internal static extern MediaControllerError SetDisplayRotationCapabilityUpdatedCb(MediaControllerClientHandle clientHandle,
            CategoryAttributeCapabilityUpdatedCallback callback, IntPtr userData = default(IntPtr));

        // Common
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_ability_support_updated_cb")]
        internal static extern MediaControllerError SetCategoryCapabilityUpdatedCb(MediaControllerClientHandle clientHandle,
            SimpleCapabilityUpdatedCallback callback, IntPtr userData = default(IntPtr));
        #endregion Capability updated callback


        #region Search
        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_create")]
        internal static extern MediaControllerError CreateSearchHandle(out IntPtr searchHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_set_condition")]
        internal static extern MediaControllerError SetSearchCondition(IntPtr searchHandle,
            MediaControlContentType type, MediaControlSearchCategory category, string keyword, IntPtr bundle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_set_condition")]
        internal static extern MediaControllerError SetSearchConditionBundle(IntPtr searchHandle,
            MediaControlContentType type, MediaControlSearchCategory category, string keyword, SafeBundleHandle bundle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_search_destroy")]
        internal static extern MediaControllerError DestroySearchHandle(IntPtr searchHandle);
        #endregion Search


        #region Command
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_action_cmd")]
        internal static extern MediaControllerError SendPlaybackActionCommand(MediaControllerClientHandle handle,
            string serverName, MediaControllerNativePlaybackAction action, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_action_cmd")]
        internal static extern MediaControllerError SendPlaybackActionCommandWithoutReqId(MediaControllerClientHandle handle,
            string serverName, MediaControllerNativePlaybackAction action, string requestId = default(string));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_position_cmd")]
        internal static extern MediaControllerError SendPlaybackPositionCommand(MediaControllerClientHandle handle,
            string serverName, ulong playbackPosition, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_shuffle_mode_cmd")]
        internal static extern MediaControllerError SendShuffleModeCommand(MediaControllerClientHandle handle,
            string serverName, MediaControllerNativeShuffleMode mode, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_repeat_mode_cmd")]
        internal static extern MediaControllerError SendRepeatModeCommand(MediaControllerClientHandle handle,
            string serverName, MediaControllerNativeRepeatMode mode, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playlist_cmd")]
        internal static extern MediaControllerError SendPlaylistCommand(MediaControllerClientHandle handle,
            string serverName, string playlistName, string index, MediaControllerNativePlaybackAction mode,
            ulong position, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_search_cmd")]
        internal static extern MediaControllerError SendSearchCommand(MediaControllerClientHandle handle,
            string serverName, IntPtr searchHandle, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_subtitles_cmd")]
        internal static extern MediaControllerError SendSubtitleModeCommand(MediaControllerClientHandle handle,
            string serverName, bool isEnabled, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_360_mode_cmd")]
        internal static extern MediaControllerError SendMode360Command(MediaControllerClientHandle handle,
            string serverName, bool isEnabled, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_display_mode_cmd")]
        internal static extern MediaControllerError SendDisplayModeCommand(MediaControllerClientHandle handle,
            string serverName, MediaControlNativeDisplayMode mode, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_display_rotation_cmd")]
        internal static extern MediaControllerError SendDisplayRotationCommand(MediaControllerClientHandle handle,
            string serverName, MediaControlNativeDisplayRotation mode, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_custom_cmd")]
        internal static extern MediaControllerError SendCustomCommandBundle(MediaControllerClientHandle handle,
            string serverName, string command, SafeBundleHandle bundleHandle, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_custom_cmd")]
        internal static extern MediaControllerError SendCustomCommand(MediaControllerClientHandle handle,
            string serverName, string command, IntPtr bundleHandle, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_cmd_reply_received_cb")]
        internal static extern MediaControllerError SetCommandCompletedCb(MediaControllerClientHandle handle,
            CommandCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_cmd_reply_received_cb")]
        internal static extern MediaControllerError UnsetCommandCompletedCb(MediaControllerClientHandle handle);
        #endregion Command


        #region Event
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_custom_event_received_cb")]
        internal static extern MediaControllerError SetCustomEventCb(MediaControllerClientHandle handle,
            CustomCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_custom_event_received_cb")]
        internal static extern MediaControllerError UnsetCustomEventCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_event_reply")]
        internal static extern MediaControllerError SendCustomEventReply(MediaControllerClientHandle handle,
            string serverName, string requestId, int result, IntPtr bundleHandle);
        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_event_reply")]
        internal static extern MediaControllerError SendCustomEventReplyBundle(MediaControllerClientHandle handle,
            string serverName, string requestId, int result, SafeBundleHandle bundleHandle);
        #endregion Event
    }

    internal class MediaControllerClientHandle : SafeHandle
    {
        protected MediaControllerClientHandle() : base(IntPtr.Zero, true)
        {
        }

        public override bool IsInvalid => handle == IntPtr.Zero;

        protected override bool ReleaseHandle()
        {
            var ret = MediaControllerClient.Destroy(handle);
            if (ret != MediaControllerError.None)
            {
                Tizen.Log.Debug(GetType().FullName, $"Failed to release native {GetType().Name}");
                return false;
            }

            return true;
        }
    }
}
