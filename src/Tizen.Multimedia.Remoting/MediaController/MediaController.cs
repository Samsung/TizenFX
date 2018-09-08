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
using System.Threading.Tasks;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to send commands to and handle events from media control server.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public partial class MediaController
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

                return playbackCode.ToPublic();
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

            return shuffleMode == MediaControllerNativeShuffleMode.On;
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

            Native.SendPlaybackStateCommand(Manager.Handle, ServerAppId, command.ToNative()).
                ThrowIfError("Failed to send command.");
        }

        /// <summary>
        /// Requests command to the server.
        /// </summary>
        /// <remarks>
        /// The client can request the server to execute <see cref="PlaybackCommand"/> or <see cref="ShuffleModeCommand"/> or
        /// <see cref="RepeatModeCommand"/> or <see cref="CustomCommand"/>, <br/>
        /// and then, the client receive the result of each request(command) by <see cref="CommandCompleted"/> event.
        /// </remarks>
        /// <param name="command">A <see cref="Command"/> class.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <returns>The request ID for <paramref name="command"/>.
        /// User have to keep it and can match it later with request ID of <see cref="CommandCompleted"/> event.</returns>
        /// <since_tizen> 5 </since_tizen>
        public string Request(Command command)
        {
            ThrowIfStopped();

            command.SetReceiver(Manager.Handle, ServerAppId);

            return command.Send();
        }
    }
}