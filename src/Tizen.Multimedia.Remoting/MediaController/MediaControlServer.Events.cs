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
using Native = Interop.MediaControllerServer;

namespace Tizen.Multimedia.Remoting
{
    public static partial class MediaControlServer
    {
        private static Native.PlaybackStateCommandReceivedCallback _playbackCommandCallback;
        private static Native.PlaybackActionCommandReceivedCallback _playbackActionCommandCallback;
        private static Native.PlaybackPositionCommandReceivedCallback _playbackPositionCommandCallback;
        private static Native.PlaylistCommandReceivedCallback _playlistCommandCallback;
        private static Native.ShuffleModeCommandReceivedCallback _shuffleModeCommandCallback;
        private static Native.RepeatModeCommandReceivedCallback _repeatModeCommandCallback;
        private static Native.CustomCommandReceivedCallback _customCommandCallback;

        /// <summary>
        /// Occurs when a client sends playback command.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated. Please use PlaybackActionCommandReceived instead.")]
        public static event EventHandler<PlaybackCommandReceivedEventArgs> PlaybackCommandReceived;

        /// <summary>
        /// Occurs when a client sends playback command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<PlaybackActionCommandReceivedEventArgs> PlaybackActionCommandReceived;

        /// <summary>
        /// Occurs when a client sends playback position command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<PlaybackPositionCommandReceivedEventArgs> PlaybackPositionCommandReceived;

        /// <summary>
        /// Occurs when a client sends playlist command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<PlaylistCommandReceivedEventArgs> PlaylistCommandReceived;

        /// <summary>
        /// Occurs when a client sends shuffle mode command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<ShuffleModeCommandReceivedEventArgs> ShuffleModeCommandReceived;

        /// <summary>
        /// Occurs when a client sends repeat mode command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<RepeatModeCommandReceivedEventArgs> RepeatModeCommandReceived;

        /// <summary>
        /// Occurs when a client sends custom command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<CustomCommandReceivedEventArgs> CustomCommandReceived;

        private static void RegisterPlaybackCommandReceivedEvent()
        {
            _playbackCommandCallback = (clientName, playbackCode, _) =>
            {
                PlaybackCommandReceived?.Invoke(null, new PlaybackCommandReceivedEventArgs(clientName, playbackCode.ToPublic()));
            };
            Native.SetPlaybackStateCmdRecvCb(Handle, _playbackCommandCallback).
                ThrowIfError("Failed to init PlaybackStateCommandReceived event.");
        }

        private static void RegisterPlaybackActionCommandReceivedEvent()
        {
            _playbackActionCommandCallback = (clientName, requestId, playbackCommand, _) =>
            {
                PlaybackActionCommandReceived?.Invoke(null, new PlaybackActionCommandReceivedEventArgs(clientName, requestId, playbackCommand.ToPublic()));
            };
            Native.SetPlaybackActionCommandReceivedCb(Handle, _playbackActionCommandCallback).
                ThrowIfError("Failed to init PlaybackActionCommandReceived event.");
        }

        private static void RegisterPlaybackPositionCommandReceivedEvent()
        {
            _playbackPositionCommandCallback = (clientName, requestId, playbackPosition, _) =>
            {
                PlaybackPositionCommandReceived?.Invoke(null, new PlaybackPositionCommandReceivedEventArgs(clientName, requestId, playbackPosition));
            };
            Native.SetPlaybackPosotionCommandReceivedCb(Handle, _playbackPositionCommandCallback).
                ThrowIfError("Failed to init PlaybackPositionCommandReceived event.");
        }

        private static void RegisterPlaylistCommandReceivedEvent()
        {
            _playlistCommandCallback = (clientName, requestId, playlist, index, command, playbackPosition, _) =>
            {
                PlaylistCommandReceived?.Invoke(null, new PlaylistCommandReceivedEventArgs(clientName, requestId, playlist, index, command.ToPublic(), playbackPosition));
            };
            Native.SetPlaylistCommandReceivedCb(Handle, _playlistCommandCallback).
                ThrowIfError("Failed to init PlaylistCommandReceived event.");
        }

        private static void RegisterShuffleModeCommandReceivedEvent()
        {
            _shuffleModeCommandCallback = (clientName, requestId, mode, _) =>
            {
                ShuffleModeCommandReceived?.Invoke(null, new ShuffleModeCommandReceivedEventArgs(clientName, requestId, mode.ToPublic()));
            };
            Native.SetShuffleModeCommandReceivedCb(Handle, _shuffleModeCommandCallback).
                ThrowIfError("Failed to init ShuffleModeCommandReceived event.");
        }

        private static void RegisterRepeatModeCommandReceivedEvent()
        {
            _repeatModeCommandCallback = (clientName, requestId, mode, _) =>
            {
                RepeatModeCommandReceived?.Invoke(null, new RepeatModeCommandReceivedEventArgs(clientName, requestId, mode.ToPublic()));
            };
            Native.SetRepeatModeCommandReceivedCb(Handle, _repeatModeCommandCallback).
                ThrowIfError("Failed to init RepeatModeCommandReceived event.");
        }

        private static void RegisterCustomCommandReceivedEvent()
        {
            _customCommandCallback = (clientName, requestId, command, bundleHandle, _) =>
            {
                CustomCommandReceived?.Invoke(null, new CustomCommandReceivedEventArgs(clientName, requestId, command, bundleHandle));
            };
            Native.SetCustomCommandReceivedCb(Handle, _customCommandCallback).
                ThrowIfError("Failed to init CustomCommandReceived event.");
        }
    }
}