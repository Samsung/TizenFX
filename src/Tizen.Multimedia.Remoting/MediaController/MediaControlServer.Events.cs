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

using Tizen.Applications;
using System;
using System.Collections.Generic;
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
        private static Native.SearchCommandReceivedCallback _searchCommandCallback;
        private static Native.EventCompletedCallback _eventCompletedCallback;

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

        /// <summary>
        /// Occurs when a client sends search command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<SearchCommandReceivedEventArgs> SearchCommandReceived;

        /// <summary>
        /// Occurs when a client sends custom command.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        internal static event EventHandler<EventCompletedEventArgs> EventCompleted;

        private static void RegisterPlaybackCommandReceivedEvent()
        {
            _playbackCommandCallback = (clientName, playbackCode, _) =>
            {
                PlaybackCommandReceived?.Invoke(null, new PlaybackCommandReceivedEventArgs(clientName, playbackCode.ToPublic()));
            };
            Native.SetPlaybackStateCommandReceivedCb(Handle, _playbackCommandCallback).
                ThrowIfError("Failed to init PlaybackStateCommandReceived event.");
        }

        private static void RegisterPlaybackActionCommandReceivedEvent()
        {
            _playbackActionCommandCallback = (clientName, requestId, playbackCommand, _) =>
            {
                var command = new PlaybackCommand(playbackCommand.ToPublic());
                command.SetResponseInformation(clientName, requestId);

                PlaybackActionCommandReceived?.Invoke(null, new PlaybackActionCommandReceivedEventArgs(command));
            };
            Native.SetPlaybackActionCommandReceivedCb(Handle, _playbackActionCommandCallback).
                ThrowIfError("Failed to init PlaybackActionCommandReceived event.");
        }

        private static void RegisterPlaybackPositionCommandReceivedEvent()
        {
            _playbackPositionCommandCallback = (clientName, requestId, playbackPosition, _) =>
            {
                var command = new PlaybackPositionCommand(playbackPosition);
                command.SetResponseInformation(clientName, requestId);

                PlaybackPositionCommandReceived?.Invoke(null, new PlaybackPositionCommandReceivedEventArgs(command));
            };
            Native.SetPlaybackPosotionCommandReceivedCb(Handle, _playbackPositionCommandCallback).
                ThrowIfError("Failed to init PlaybackPositionCommandReceived event.");
        }

        private static void RegisterPlaylistCommandReceivedEvent()
        {
            _playlistCommandCallback = (clientName, requestId, playlistName, index, playbackCommand, playbackPosition, _) =>
            {
                var command = new PlaylistCommand(playbackCommand.ToPublic(), playlistName, index, playbackPosition);
                command.SetResponseInformation(clientName, requestId);

                PlaylistCommandReceived?.Invoke(null, new PlaylistCommandReceivedEventArgs(command));
            };
            Native.SetPlaylistCommandReceivedCb(Handle, _playlistCommandCallback).
                ThrowIfError("Failed to init PlaylistCommandReceived event.");
        }

        private static void RegisterShuffleModeCommandReceivedEvent()
        {
            _shuffleModeCommandCallback = (clientName, requestId, mode, _) =>
            {
                var command = new ShuffleModeCommand(mode == MediaControllerNativeShuffleMode.On ? true : false);
                command.SetResponseInformation(clientName, requestId);

                ShuffleModeCommandReceived?.Invoke(null, new ShuffleModeCommandReceivedEventArgs(command));
            };
            Native.SetShuffleModeCommandReceivedCb(Handle, _shuffleModeCommandCallback).
                ThrowIfError("Failed to init ShuffleModeCommandReceived event.");
        }

        private static void RegisterRepeatModeCommandReceivedEvent()
        {
            _repeatModeCommandCallback = (clientName, requestId, mode, _) =>
            {
                var command = new RepeatModeCommand(mode.ToPublic());
                command.SetResponseInformation(clientName, requestId);

                RepeatModeCommandReceived?.Invoke(null, new RepeatModeCommandReceivedEventArgs(command));
            };
            Native.SetRepeatModeCommandReceivedCb(Handle, _repeatModeCommandCallback).
                ThrowIfError("Failed to init RepeatModeCommandReceived event.");
        }

        private static void RegisterCustomCommandReceivedEvent()
        {
            _customCommandCallback = (clientName, requestId, customCommand, bundleHandle, _) =>
            {
                CustomCommand command = null;
                if (bundleHandle != IntPtr.Zero)
                {
                    command = new CustomCommand(customCommand, new Bundle(new SafeBundleHandle(bundleHandle, true)));
                }
                else
                {
                    command = new CustomCommand(customCommand);
                }

                command.SetResponseInformation(clientName, requestId);

                CustomCommandReceived?.Invoke(null, new CustomCommandReceivedEventArgs(command));
            };
            Native.SetCustomCommandReceivedCb(Handle, _customCommandCallback).
                ThrowIfError("Failed to init CustomCommandReceived event.");
        }
        
        private static SearchCommand CreateSearchCommandReceivedEventArgs(IntPtr searchHandle)
        {
            List<MediaControlSearchCondition> searchConditions = null;

            Native.SearchItemCallback searchItemCallback = (type, category, keyword, bundleHandle, _) =>
            {
                Bundle bundle = null;
                if (bundleHandle != IntPtr.Zero)
                {
                    bundle = new Bundle(new SafeBundleHandle(bundleHandle, true));
                }

                searchConditions.Add(new MediaControlSearchCondition(type, category, keyword, bundle));

                return true;
            };
            Native.ForeachSearchCondition(searchHandle, searchItemCallback).
                ThrowIfError("Failed to get search items.");

            return new SearchCommand(searchConditions, searchHandle);
        }

        private static void RegisterSearchCommandReceivedEvent()
        {
            _searchCommandCallback = (clientName, requestId, searchHandle, _) =>
            {
                var command = CreateSearchCommandReceivedEventArgs(searchHandle);

                command.SetResponseInformation(clientName, requestId);

                SearchCommandReceived?.Invoke(null, new SearchCommandReceivedEventArgs(command));
            };
            Native.SetSearchCommandReceivedCb(Handle, _searchCommandCallback).
                ThrowIfError("Failed to init SearchCommandReceived event.");
        }

        private static void RegisterEventCompletedEvent()
        {
            _eventCompletedCallback = (clientName, requestId, result, bundleHandle, _) =>
            {
                if (bundleHandle != IntPtr.Zero)
                {
                    EventCompleted?.Invoke(null, new EventCompletedEventArgs(requestId, result, new Bundle(new SafeBundleHandle(bundleHandle, true))));
                }
                else
                {
                    EventCompleted?.Invoke(null, new EventCompletedEventArgs(requestId, result));
                }
            };
            Native.SetEventReceivedCb(Handle, _eventCompletedCallback).
                ThrowIfError("Failed to init RegisterEventCompletedEvent.");
        }
    }
}