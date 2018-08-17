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
using System.Collections.Generic;
using System.Diagnostics;
using Tizen.Applications;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to to send commands to and handle events from media control server.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public string ServerAppId { get; }

        /// <summary>
        /// Gets a value indicating whether the sever has been stopped.
        /// </summary>
        /// <value>true if the server has been stopped; otherwise, false.</value>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler ServerStopped;

        internal void RaiseStoppedEvent()
        {
            IsStopped = true;
            ServerStopped?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when the playback state is updated.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<ShuffleModeUpdatedEventArgs> ShuffleModeUpdated;

        internal void RaiseShuffleModeUpdatedEvent(NativeShuffleMode mode)
        {
            ShuffleModeUpdated?.Invoke(this, new ShuffleModeUpdatedEventArgs(mode == NativeShuffleMode.On));
        }

        /// <summary>
        /// Occurs when the repeat mode is updated.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<RepeatModeUpdatedEventArgs> RepeatModeUpdated;

        internal void RaiseRepeatModeUpdatedEvent(MediaControlRepeatMode mode)
        {
            RepeatModeUpdated?.Invoke(this, new RepeatModeUpdatedEventArgs(mode));
        }

        /// <summary>
        /// Occurs when the command is completed.
        /// </summary>
        /// <remarks>
        /// User can match the command and this event using <see cref="CommandCompletedEventArgs.RequestId"/> field.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<CommandCompletedEventArgs> CommandCompleted;

        internal void RaiseCommandCompletedEvent(string requestId, int result, SafeBundleHandle bundleHandle)
        {
            CommandCompleted?.Invoke(this, new CommandCompletedEventArgs(requestId, result, bundleHandle));
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
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
        /// <since_tizen> 4 </since_tizen>
        public bool IsShuffleModeEnabled()
        {
            ThrowIfStopped();

            Native.GetServerShuffleMode(Manager.Handle, ServerAppId, out var shuffleMode).
                ThrowIfError("Failed to get shuffle mode state.");

            return shuffleMode == NativeShuffleMode.On;
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
        /// <since_tizen> 4 </since_tizen>
        public MediaControlRepeatMode GetRepeatMode()
        {
            ThrowIfStopped();

            Native.GetServerRepeatMode(Manager.Handle, ServerAppId, out var repeatMode).
                ThrowIfError("Failed to get repeat mode state.");

            return repeatMode.ToPublic();
        }

        /// <summary>
        /// Sends playback command to the server.
        /// </summary>
        /// <param name="command">A playback command.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="command"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="MediaControlServer.PlaybackCommandReceived"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated. Please use SendCommand instead.")]
        public void SendPlaybackCommand(MediaControlPlaybackCommand command)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), command, nameof(command));

            Native.SendPlaybackStateCommand(Manager.Handle, ServerAppId, command.ToNativeAction()).
                ThrowIfError("Failed to send command.");
        }

        /// <summary>
        /// Sends playback command to the server.
        /// </summary>
        /// <param name="playbackCommand">A playback command.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="playbackCommand"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(MediaControlPlaybackCommand playbackCommand)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), playbackCommand, nameof(playbackCommand));

            Native.SendPlaybackActionCommand(Manager.Handle, ServerAppId, playbackCommand.ToNativeAction(), out string requestId).
                ThrowIfError("Failed to send playback command.");

            return requestId;
        }

        /// <summary>
        /// Sends repeat mode command to the server.
        /// </summary>
        /// <param name="playbackCommand">The repeat mode to send to media controller server.</param>
        /// <param name="playlistName"></param>
        /// <param name="index"></param>
        /// <param name="position"></param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="playbackCommand"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(MediaControlPlaybackCommand playbackCommand, string playlistName, string index, ulong position)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), playbackCommand, nameof(playbackCommand));

            if (playlistName == null)
            {
                throw new ArgumentNullException("Playlist is not set.");
            }
            if (index == null)
            {
                throw new ArgumentNullException("Index is not set.");
            }

            Native.SendPlaylistCommand(Manager.Handle, ServerAppId, playlistName, index, playbackCommand.ToNativeAction(),
                position, out string requestId).ThrowIfError("Failed to send playlist command.");

            return requestId;
        }

        /// <summary>
        /// Sends playback position command to the server.
        /// </summary>
        /// <param name="playbackPosition">The position of the playback in milliseconds to send to media controller server.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="playbackPosition"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(ulong playbackPosition)
        {
            ThrowIfStopped();

            Native.SendPlaybackPositionCommand(Manager.Handle, ServerAppId, playbackPosition, out string requestId).
                ThrowIfError("Failed to send playback position command.");

            return requestId;
        }

        /// <summary>
        /// Sends shuffle mode command to the server.
        /// </summary>
        /// <param name="shuffleMode">The shuffle mode to send to media controller server.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="shuffleMode"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(MediaControlShuffleMode shuffleMode)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlShuffleMode), shuffleMode, nameof(shuffleMode));

            Native.SendShuffleModeCommand(Manager.Handle, ServerAppId, shuffleMode.ToNative(), out string requestId).
                ThrowIfError("Failed to send playback shuffle command.");

            return requestId;
        }

        /// <summary>
        /// Sends repeat mode command to the server.
        /// </summary>
        /// <param name="repeatMode">The repeat mode to send to media controller server.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="repeatMode"/> is not valid.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(MediaControlRepeatMode repeatMode)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), repeatMode, nameof(repeatMode));

            Native.SendRepeatModeCommand(Manager.Handle, ServerAppId, repeatMode.ToNative(), out string requestId).
                ThrowIfError("Failed to send playback repeat command.");

            return requestId;
        }

        /// <summary>
        /// Sends custom command to the server.
        /// </summary>
        /// <param name="customCommand">A custom command.</param>
        /// <param name="bundle">The extra data.</param>
        /// <returns>
        /// The request ID for each command. The same value will be delivered for matching command and event pair,<br/>
        /// when <see cref="CommandCompleted"/> event is occurred.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="customCommand"/> is not set.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(string customCommand, Bundle bundle)
        {
            ThrowIfStopped();

            if (customCommand == null)
            {
                throw new ArgumentNullException("Custom command is not set.");
            }

            Native.SendCustomCommand(Manager.Handle, ServerAppId, customCommand, bundle?.SafeBundleHandle, out string requestId).
                ThrowIfError("Failed to send custom command.");

            return requestId;
        }

        /// <summary>
        /// Sends custom command to the server.
        /// </summary>
        /// <param name="customCommand">A custom command.</param>
        /// <returns>
        /// The request ID for each command. The same value will be delivered for matching command and event pair,<br/>
        /// when <see cref="CommandCompleted"/> event is occurred.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="customCommand"/> is not set.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <seealso cref="CommandCompleted"/>
        /// <since_tizen> 5 </since_tizen>
        public string SendCommand(string customCommand)
        {
            return SendCommand(customCommand, null);
        }
    }
}