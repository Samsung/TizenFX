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
using Tizen.Multimedia.Remoting;

internal static partial class Interop
{
    internal static partial class MediaControllerServer
    {
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void PlaybackStateCommandReceivedCallback(string clientName,
            MediaControllerPlaybackCode state, IntPtr userData);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_create")]
        internal static extern MediaControllerError Create(out IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_destroy")]
        internal static extern MediaControllerError Destroy(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state")]
        internal static extern MediaControllerError SetPlaybackState(IntPtr handle,
            MediaControllerPlaybackCode state);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_position")]
        internal static extern MediaControllerError SetPlaybackPosition(IntPtr handle, ulong position);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_playback_info")]
        internal static extern MediaControllerError UpdatePlayback(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_metadata")]
        internal static extern MediaControllerError SetMetadata(IntPtr handle,
            MediaControllerAttribute attribute, string value);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_metadata")]
        internal static extern MediaControllerError UpdateMetadata(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_shuffle_mode")]
        internal static extern MediaControllerError UpdateShuffleMode(IntPtr handle,
            MediaControllerShuffleMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_update_repeat_mode")]
        internal static extern MediaControllerError UpdateRepeatMode(IntPtr handle, NativeRepeatMode mode);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_set_playback_state_command_received_cb")]
        internal static extern MediaControllerError SetPlaybackStateCmdRecvCb(IntPtr handle,
            PlaybackStateCommandReceivedCallback callback, IntPtr userData = default(IntPtr));

        [DllImport(Libraries.MediaController, EntryPoint = "mc_server_unset_playback_state_command_received_cb")]
        internal static extern MediaControllerError UnsetPlaybackStateCmdRecvCb(IntPtr handle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_connect")]
        internal static extern MediaControllerError ConnectDb(out IntPtr dbHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_disconnect")]
        internal static extern MediaControllerError DisconnectDb(IntPtr dbHandle);

        [DllImport(Libraries.MediaController, EntryPoint = "mc_db_check_server_table_exist")]
        internal static extern MediaControllerError CheckServerExist(IntPtr dbHandle, string appId, out bool value);
    }
}
