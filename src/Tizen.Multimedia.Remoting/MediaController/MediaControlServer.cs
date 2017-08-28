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
    /// <summary>
    /// Provides a means to set playback information and metadata and receive commands from clients.
    /// </summary>
    /// <seealso cref="MediaControllerManager"/>
    /// <seealso cref="MediaController"/>
    public static class MediaControlServer
    {
        private static IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Gets a value indicating whether the server is running.
        /// </summary>
        /// <value>true if the server has started; otherwise, false.</value>
        /// <seealso cref="Start"/>
        /// <seealso cref="Stop"/>
        public static bool IsRunning
        {
            get => _handle != IntPtr.Zero;
        }

        private static void ThrowIfNotRunning()
        {
            if (IsRunning == false)
            {
                throw new InvalidOperationException("The server is not running.");
            }
        }

        private static IntPtr Handle
        {
            get
            {
                ThrowIfNotRunning();

                return _handle;
            }
        }

        /// <summary>
        /// Starts the media control server.
        /// </summary>
        /// <remarks>
        /// When the server starts, <see cref="MediaControllerManager.ServerStarted"/> will be raised.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediacontroller.server</privilege>
        /// <exception cref="InvalidOperationException">
        ///     The server has already started.\n
        ///     -or-\n
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">Caller does not have required privilege.</exception>
        /// <seealso cref="MediaControllerManager.ServerStarted"/>
        public static void Start()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("The server is already running.");
            }

            Native.Create(out _handle).ThrowIfError("Failed to create media controller server.");

            try
            {
                RegisterPlaybackCommandReceivedEvent();
            }
            catch
            {
                Native.Destroy(_handle);
                _playbackCommandCallback = null;
                _handle = IntPtr.Zero;
                throw;
            }
        }

        /// <summary>
        /// Stops the media control server.
        /// </summary>
        /// <remarks>
        /// When the server stops, <see cref="MediaControllerManager.ServerStopped"/> will be raised.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .\n
        ///     -or-\n
        ///     An internal error occurs.
        /// </exception>
        /// <seealso cref="MediaControllerManager.ServerStopped"/>
        public static void Stop()
        {
            ThrowIfNotRunning();

            Native.Destroy(_handle).ThrowIfError("Failed to stop the server.");

            _handle = IntPtr.Zero;
            _playbackCommandCallback = null;
        }

        /// <summary>
        /// Updates playback state and playback position.</summary>
        /// <param name="state">The playback state.</param>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <exception cref="ArgumentException"><paramref name="state"/> is not valid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="position"/> is less than zero.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .\n
        ///     -or-\n
        ///     An internal error occurs.
        /// </exception>
        public static void SetPlaybackState(MediaControlPlaybackState state, long position)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackState), state, nameof(state));

            if (position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "position can't be less than zero.");
            }

            Native.SetPlaybackState(Handle, state.ToCode()).ThrowIfError("Failed to set playback state.");

            Native.SetPlaybackPosition(Handle, (ulong)position).ThrowIfError("Failed to set playback position.");

            Native.UpdatePlayback(Handle).ThrowIfError("Failed to set playback.");
        }

        private static void SetMetadata(MediaControllerAttribute attribute, string value)
        {
            Native.SetMetadata(Handle, attribute, value).ThrowIfError($"Failed to set metadata({attribute}).");
        }

        /// <summary>
        /// Updates metadata information.
        /// </summary>
        /// <param name="metadata">The metadata to update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metadata"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .\n
        ///     -or-\n
        ///     An internal error occurs.
        /// </exception>
        public static void SetMetadata(MediaControlMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            SetMetadata(MediaControllerAttribute.Title, metadata.Title);
            SetMetadata(MediaControllerAttribute.Artist, metadata.Artist);
            SetMetadata(MediaControllerAttribute.Album, metadata.Album);
            SetMetadata(MediaControllerAttribute.Author, metadata.Author);
            SetMetadata(MediaControllerAttribute.Genre, metadata.Genre);
            SetMetadata(MediaControllerAttribute.Duration, metadata.Duration);
            SetMetadata(MediaControllerAttribute.Date, metadata.Date);
            SetMetadata(MediaControllerAttribute.Copyright, metadata.Copyright);
            SetMetadata(MediaControllerAttribute.Description, metadata.Description);
            SetMetadata(MediaControllerAttribute.TrackNumber, metadata.TrackNumber);
            SetMetadata(MediaControllerAttribute.Picture, metadata.AlbumArtPath);

            Native.UpdateMetadata(Handle).ThrowIfError("Failed to set metadata.");
        }

        /// <summary>
        /// Updates the shuffle mode.
        /// </summary>
        /// <param name="enabled">A value indicating whether the shuffle mode is enabled.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .\n
        ///     -or-\n
        ///     An internal error occurs.
        /// </exception>
        public static void SetShuffleModeEnabled(bool enabled)
        {
            Native.UpdateShuffleMode(Handle, enabled ? MediaControllerShuffleMode.On : MediaControllerShuffleMode.Off).
                ThrowIfError("Failed to set shuffle mode.");
        }

        /// <summary>
        /// Updates the repeat mode.
        /// </summary>
        /// <param name="mode">A value indicating the repeat mode.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .\n
        ///     -or-\n
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"/><paramref name="mode"/> is invalid.</exception>
        public static void SetRepeatMode(MediaControlRepeatMode mode)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), mode, nameof(mode));

            Native.UpdateRepeatMode(Handle, mode.ToNative()).ThrowIfError("Failed to set repeat mode.");
        }

        /// <summary>
        /// Occurs when a client sends playback command.
        /// </summary>
        public static event EventHandler<PlaybackCommandReceivedEventArgs> PlaybackCommandReceived;

        private static Native.PlaybackStateCommandReceivedCallback _playbackCommandCallback;

        private static void RegisterPlaybackCommandReceivedEvent()
        {
            _playbackCommandCallback = (clientName, playbackCode, _) =>
            {
                PlaybackCommandReceived?.Invoke(null, new PlaybackCommandReceivedEventArgs(clientName, playbackCode.ToCommand()));
            };
            Native.SetPlaybackStateCmdRecvCb(Handle, _playbackCommandCallback).
                ThrowIfError("Failed to init PlaybackStateCommandReceived event."); ;
        }
    }
}