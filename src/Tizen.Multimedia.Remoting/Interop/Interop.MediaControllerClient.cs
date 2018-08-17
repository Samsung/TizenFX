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
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ServerUpdatedCallback(string serverName, MediaControllerServerState serverState,
            IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackUpdatedCallback(string serverName, IntPtr playback, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void MetadataUpdatedCallback(string serverName, IntPtr metadata, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void ShuffleModeUpdatedCallback(string serverName, NativeShuffleMode shuffleMode,
            IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RepeatModeUpdatedCallback(string serverName, NativeRepeatMode repeatMode, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ActivatedServerCallback(string serverName, IntPtr userData);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void CommandCompletedCallback(string serverName, string requestId, int result,
            SafeBundleHandle bundleHandle, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_create")]
        internal static extern MediaControllerError Create(out MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_server_update_cb")]
        internal static extern MediaControllerError SetServerUpdatedCb(MediaControllerClientHandle handle,
            ServerUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_server_update_cb")]
        internal static extern MediaControllerError UnsetServerUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_playback_update_cb")]
        internal static extern MediaControllerError SetPlaybackUpdatedCb(MediaControllerClientHandle handle,
            PlaybackUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_playback_update_cb")]
        internal static extern MediaControllerError UnsetPlaybackUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_metadata_update_cb")]
        internal static extern MediaControllerError SetMetadataUpdatedCb(MediaControllerClientHandle handle,
            MetadataUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_metadata_update_cb")]
        internal static extern MediaControllerError UnsetMetadataUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_shuffle_mode_update_cb")]
        internal static extern MediaControllerError SetShuffleModeUpdatedCb(MediaControllerClientHandle handle,
            ShuffleModeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_shuffle_mode_update_cb")]
        internal static extern MediaControllerError UnsetShuffleModeUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_repeat_mode_update_cb")]
        internal static extern MediaControllerError SetRepeatModeUpdatedCb(MediaControllerClientHandle handle,
            RepeatModeUpdatedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_repeat_mode_update_cb")]
        internal static extern MediaControllerError UnsetRepeatModeUpdatedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_set_cmd_reply_received_cb")]
        internal static extern MediaControllerError SetCommandCompletedCb(MediaControllerClientHandle handle,
            CommandCompletedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_unset_cmd_reply_received_cb")]
        internal static extern MediaControllerError UnsetCommandCompletedCb(MediaControllerClientHandle handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_state")]
        internal static extern MediaControllerError GetPlaybackState(IntPtr playback, out MediaControllerPlaybackNativeState state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_playback_position")]
        internal static extern MediaControllerError GetPlaybackPosition(IntPtr playback, out ulong position);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_playback")]
        internal static extern MediaControllerError DestroyPlayback(IntPtr playback);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_metadata")]
        private static extern MediaControllerError GetMetadata(IntPtr metadata, MediaControllerAttribute attribute,
            out IntPtr value);

        internal static string GetMetadata(IntPtr handle, MediaControllerAttribute attr)
        {
            IntPtr valuePtr = IntPtr.Zero;

            try
            {
                GetMetadata(handle, attr, out valuePtr).ThrowIfError($"Failed to get value for {attr}.");
                return Marshal.PtrToStringAnsi(valuePtr);
            }
            finally
            {
                Tizen.Multimedia.LibcSupport.Free(valuePtr);
            }
        }

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_destroy_metadata")]
        internal static extern MediaControllerError DestroyMetadata(IntPtr metadata);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_latest_server_info")]
        internal static extern MediaControllerError GetLatestServer(MediaControllerClientHandle handle,
            out IntPtr serverName, out MediaControllerServerState serverState);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_playback_info")]
        internal static extern MediaControllerError GetServerPlayback(MediaControllerClientHandle handle,
            string serverName, out IntPtr playback);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_metadata")]
        internal static extern MediaControllerError GetServerMetadata(MediaControllerClientHandle handle,
            string serverName, out IntPtr metadata);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_shuffle_mode")]
        internal static extern MediaControllerError GetServerShuffleMode(MediaControllerClientHandle handle,
            string serverName, out NativeShuffleMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_get_server_repeat_mode")]
        internal static extern MediaControllerError GetServerRepeatMode(MediaControllerClientHandle handle,
            string serverName, out NativeRepeatMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_state_command")]
        internal static extern MediaControllerError SendPlaybackStateCommand(MediaControllerClientHandle handle,
            string serverName, MediaControllerPlaybackNativeAction command);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_custom_cmd")]
        internal static extern MediaControllerError SendCustomCommand(MediaControllerClientHandle handle,
            string serverName, string command, SafeBundleHandle bundleHandle, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_action_cmd")]
        internal static extern MediaControllerError SendPlaybackActionCommand(MediaControllerClientHandle handle,
            string serverName, MediaControllerPlaybackNativeAction action, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playback_position_cmd")]
        internal static extern MediaControllerError SendPlaybackPositionCommand(MediaControllerClientHandle handle,
            string serverName, ulong playbackPosition, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_shuffle_mode_cmd")]
        internal static extern MediaControllerError SendShuffleModeCommand(MediaControllerClientHandle handle,
            string serverName, NativeShuffleMode mode, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_repeat_mode_cmd")]
        internal static extern MediaControllerError SendRepeatModeCommand(MediaControllerClientHandle handle,
            string serverName, NativeRepeatMode mode, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_send_playlist_cmd")]
        internal static extern MediaControllerError SendPlaylistCommand(MediaControllerClientHandle handle,
            string serverName, string playlistName, string index, MediaControllerPlaybackNativeAction mode,
            ulong position, out string requestId);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_client_foreach_server")]
        internal static extern MediaControllerError ForeachActivatedServer(MediaControllerClientHandle handle,
            ActivatedServerCallback callback, IntPtr userData);
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
