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

using Tizen.Applications;
using System;
using Native = Interop.MediaControllerClient;
using NativeHandle = Interop.MediaControllerClientHandle;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to send command to media control server.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class Command
    {
        internal NativeHandle _receiverHandle;
        internal string _serverId;

        internal Command(MediaControlCommand type)
        {
            Type = type;
        }

        internal MediaControlCommand Type { get; }

        internal abstract string Send();

        internal void SetReceiver(NativeHandle receiverHandle, string serverId)
        {
            _receiverHandle = receiverHandle;
            _serverId = serverId;
        }
    }

    /// <summary>
    /// Provides a means to send playback command to media control server.
    /// </summary>
    public sealed class PlaybackCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="command">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(MediaControlPlaybackCommand command)
            : base(MediaControlCommand.Playback)
        {
            Command = command;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="command">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <param name="playlistName">The playlist name of the server.</param>
        /// <param name="index">The index of the media in the playlist.</param>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <exception cref="ArgumentException"><paramref name="index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is not vailed.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(MediaControlPlaybackCommand command, string playlistName, string index, ulong position)
            : base(MediaControlCommand.Playlist)
        {
            PlaylistIndex = index ?? throw new ArgumentNullException("Playlist index is not set.");
            if (!Int32.TryParse(PlaylistIndex, out int result))
            {
                throw new ArgumentException("Playlist index is not vaild to convert to number.");
            }

            PlaylistName = playlistName ?? throw new ArgumentNullException("Playlist name is not set.");
            Command = command;
            Position = position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="command">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <param name="playlistName">The playlist name of the server.</param>
        /// <param name="index">The index of the media in the playlist.</param>
        /// <exception cref="ArgumentException"><paramref name="index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is not set.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(MediaControlPlaybackCommand command, string playlistName, string index)
            : this(command, playlistName, index, 0)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="command">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <param name="playlist">A <see cref="Playlist"/>.</param>
        /// <exception cref="ArgumentException"><see cref="Playlist.Index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <see cref="Playlist.Index"/> or <see cref="Playlist.Name"/> is not set.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(MediaControlPlaybackCommand command, Playlist playlist)
            : this(command, playlist.Name, playlist.Index, playlist.Position)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(ulong position)
            : base(MediaControlCommand.PlaybackPosition)
        {
            Position = position;
        }

        private MediaControlPlaybackCommand Command { get; }

        private string PlaylistIndex { get; }

        private string PlaylistName { get; }

        private ulong Position { get; } = default(ulong);

        internal override string Send()
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), Command, nameof(MediaControlPlaybackCommand));

            string requestId = null;

            switch (Type)
            {
                case MediaControlCommand.Playback:
                    Native.SendPlaybackActionCommand(_receiverHandle, _serverId, Command.ToNative(), out requestId)
                        .ThrowIfError("Failed to send playback command.");

                    break;
                case MediaControlCommand.PlaybackPosition:
                    Native.SendPlaybackPositionCommand(_receiverHandle, _serverId, Position, out requestId)
                        .ThrowIfError("Failed to send playback position command.");

                    break;
                case MediaControlCommand.Playlist:
                    Native.SendPlaylistCommand(_receiverHandle, _serverId, PlaylistName, PlaylistIndex, Command.ToNative(),
                        Position, out requestId).ThrowIfError("Failed to send playlist command.");
                    break;
            }

            return requestId;
        }
    }


    /// <summary>
    /// Provides a means to to send shuffle mode commands.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public sealed class ShuffleModeCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShuffleModeCommand"/> class.
        /// </summary>
        /// <param name="mode">The <see cref="MediaControlRepeatMode"/>.</param>
        /// <since_tizen> 5 </since_tizen>
        public ShuffleModeCommand(MediaControlShuffleMode mode)
            : base(MediaControlCommand.ShuffleMode)
        {
            Mode = mode;
        }

        private MediaControlShuffleMode Mode { get; }

        internal override string Send()
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlShuffleMode), Mode, nameof(MediaControlShuffleMode));

            Native.SendShuffleModeCommand(_receiverHandle, _serverId, Mode.ToNative(), out string requestId).
                ThrowIfError("Failed to send playback shuffle command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send repeat mode commands.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public sealed class RepeatModeCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepeatModeCommand"/> class.
        /// </summary>
        /// <param name="mode">The <see cref="MediaControlRepeatMode"/>.</param>
        /// <since_tizen> 5 </since_tizen>
        public RepeatModeCommand(MediaControlRepeatMode mode)
            : base(MediaControlCommand.RepeatMode)
        {
            Mode = mode;
        }

        private MediaControlRepeatMode Mode { get; }

        internal override string Send()
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), Mode, nameof(MediaControlRepeatMode));

            Native.SendRepeatModeCommand(_receiverHandle, _serverId, Mode.ToNative(), out string requestId).
                ThrowIfError("Failed to send playback repeat command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send custom commands.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public sealed class CustomCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCommand"/> class.
        /// </summary>
        /// <param name="command">A predefined custom command.</param>
        /// <since_tizen> 5 </since_tizen>
        public CustomCommand(string command)
            : base(MediaControlCommand.Custom)
        {
            Command = command ?? throw new ArgumentNullException("Custom command is not set.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCommand"/> class.
        /// </summary>
        /// <param name="command">A predefined custom command.</param>
        /// <param name="bundle">The extra data for custom command.</param>
        /// <since_tizen> 5 </since_tizen>
        public CustomCommand(string command, Bundle bundle)
            : this(command)
        {
            Bundle = bundle;
        }

        private string Command { get; }

        private Bundle Bundle { get; }

        internal override string Send()
        {
            Native.SendCustomCommand(_receiverHandle, _serverId, Command, Bundle?.SafeBundleHandle, out string requestId).
                ThrowIfError("Failed to send custom command.");

            return requestId;
        }
    }
}