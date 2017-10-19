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
using System.Diagnostics;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to to send commands to and handle events from media control server.
    /// </summary>
    public class MediaController
    {
        internal MediaController(MediaControllerManager manager, string serverAppId)
        {
            Debug.Assert(manager != null);
            Debug.Assert(serverAppId != null);

            Manager = manager;
            ServerAppId = serverAppId;
        }

        private MediaControllerManager Manager { get; }

        /// <summary>
        /// Gets the application id of the server.
        /// </summary>
        /// <value>The server application id.</value>
        public string ServerAppId { get; }

        /// <summary>
        /// Gets a value indicating whether the sever has been stopped.
        /// </summary>
        /// <value>true if the server has been stopped; otherwise, false.</value>
        public bool IsStopped
        {
            get;
            private set;
        }

        private void ThrowIfStopped()
        {
            if (IsStopped)
            {
                throw new InvalidOperationException("The server has already been stopped.");
            }
        }

        /// <summary>
        /// Occurs when the server is stopped.
        /// </summary>
        public event EventHandler ServerStopped;

        internal void RaiseStoppedEvent()
        {
            IsStopped = true;
            ServerStopped?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when the playback state is updated.
        /// </summary>
        public event EventHandler<PlaybackStateUpdatedEventArgs> PlaybackStateUpdated;

        private PlaybackStateUpdatedEventArgs CreatePlaybackUpdatedEventArgs(IntPtr playbackHandle)
        {
            try
            {
                Native.GetPlaybackState(playbackHandle, out var playbackCode).ThrowIfError("Failed to get state.");

                Native.GetPlaybackPosition(playbackHandle, out var position).ThrowIfError("Failed to get position.");

                return new PlaybackStateUpdatedEventArgs(playbackCode.ToState(), (long)position);
            }
            catch (Exception e)
            {
                Log.Error(GetType().FullName, e.ToString());
            }
            return null;
        }

        internal void RaisePlaybackUpdatedEvent(IntPtr playbackHandle)
        {
            var eventHandler = PlaybackStateUpdated;

            if (eventHandler == null)
            {
                return;
            }

            var args = CreatePlaybackUpdatedEventArgs(playbackHandle);

            if (args != null)
            {
                eventHandler.Invoke(this, args);
            }
        }

        /// <summary>
        /// Occurs when the metadata is updated.
        /// </summary>
        public event EventHandler<MetadataUpdatedEventArgs> MetadataUpdated;

        private MetadataUpdatedEventArgs CreateMetadataUpdatedEventArgs(IntPtr metadataHandle)
        {
            try
            {
                return new MetadataUpdatedEventArgs(new MediaControlMetadata(metadataHandle));
            }
            catch (Exception e)
            {
                Log.Error(GetType().FullName, e.ToString());
            }
            return null;
        }

        internal void RaiseMetadataUpdatedEvent(IntPtr metadataHandle)
        {
            var eventHandler = MetadataUpdated;

            if (eventHandler == null)
            {
                return;
            }

            var args = CreateMetadataUpdatedEventArgs(metadataHandle);

            if (args != null)
            {
                eventHandler.Invoke(this, args);
            }
        }

        /// <summary>
        /// Occurs when the shuffle mode is updated.
        /// </summary>
        public event EventHandler<ShuffleModeUpdatedEventArgs> ShuffleModeUpdated;

        internal void RaiseShuffleModeUpdatedEvent(MediaControllerShuffleMode mode)
        {
            ShuffleModeUpdated?.Invoke(this, new ShuffleModeUpdatedEventArgs(mode == MediaControllerShuffleMode.On));
        }

        /// <summary>
        /// Occurs when the repeat mode is updated.
        /// </summary>
        public event EventHandler<RepeatModeUpdatedEventArgs> RepeatModeUpdated;

        internal void RaiseRepeatModeUpdatedEvent(MediaControlRepeatMode mode)
        {
            RepeatModeUpdated?.Invoke(this, new RepeatModeUpdatedEventArgs(mode));
        }

        /// <summary>
        /// Returns the playback state set by the server.
        /// </summary>
        /// <returns>The playback state.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.SetPlaybackState(MediaControlPlaybackState, long)"/>
        public MediaControlPlaybackState GetPlaybackState()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlayback(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

                Native.GetPlaybackState(playbackHandle, out var playbackCode).ThrowIfError("Failed to get state.");

                return playbackCode.ToState();
            }
            finally
            {
                if (playbackHandle != IntPtr.Zero)
                {
                    Native.DestroyPlayback(playbackHandle);
                }
            }
        }

        /// <summary>
        /// Returns the playback position set by the server.
        /// </summary>
        /// <returns>The playback position in milliseconds.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.SetPlaybackState(MediaControlPlaybackState, long)"/>
        public long GetPlaybackPosition()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlayback(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

                Native.GetPlaybackPosition(playbackHandle, out var position).ThrowIfError("Failed to get position.");

                return (long)position;
            }
            finally
            {
                if (playbackHandle != IntPtr.Zero)
                {
                    Native.DestroyPlayback(playbackHandle);
                }
            }
        }

        /// <summary>
        /// Returns the metadata set by the server.
        /// </summary>
        /// <returns>The metadata.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.SetMetadata(MediaControlMetadata)"/>
        public MediaControlMetadata GetMetadata()
        {
            ThrowIfStopped();

            IntPtr metadataHandle = IntPtr.Zero;

            try
            {
                Native.GetServerMetadata(Manager.Handle, ServerAppId, out metadataHandle).
                    ThrowIfError("Failed to get metadata.");

                return new MediaControlMetadata(metadataHandle);
            }
            finally
            {
                if (metadataHandle != IntPtr.Zero)
                {
                    Native.DestroyMetadata(metadataHandle);
                }
            }
        }

        /// <summary>
        /// Returns whether the shuffle mode is enabled.
        /// </summary>
        /// <returns>A value indicating whether the shuffle mode is enabled.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.SetShuffleModeEnabled(bool)"/>
        public bool IsShuffleModeEnabled()
        {
            ThrowIfStopped();

            Native.GetServerShuffleMode(Manager.Handle, ServerAppId, out var shuffleMode).
                ThrowIfError("Failed to get shuffle mode state.");

            return shuffleMode == MediaControllerShuffleMode.On;
        }

        /// <summary>
        /// Returns the repeat mode.
        /// </summary>
        /// <returns>A <see cref="MediaControlRepeatMode"/> set by the server.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.SetRepeatMode(MediaControlRepeatMode)"/>
        public MediaControlRepeatMode GetRepeatMode()
        {
            ThrowIfStopped();

            Native.GetServerRepeatMode(Manager.Handle, ServerAppId, out var repeatMode).
                ThrowIfError("Failed to get repeat mode state.");

            return repeatMode.ToPublic();
        }

        /// <summary>
        /// Sends playback command to the server.</summary>
        /// <param name="command">A playback command.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="command"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.PlaybackCommandReceived"/>
        public void SendPlaybackCommand(MediaControlPlaybackCommand command)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), command, nameof(command));

            Native.SendPlaybackStateCommand(Manager.Handle, ServerAppId, command.ToCode()).
                ThrowIfError("Failed to send command.");
        }
    }
}