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

using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Tizen.Applications;
using Native = Interop.MediaControllerClient;
using NativePlaylist = Interop.MediaControllerPlaylist;

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
                NativePlaylist.GetServerMetadata(Manager.Handle, ServerAppId, out metadataHandle).
                    ThrowIfError("Failed to get metadata.");

                return new MediaControlMetadata(metadataHandle);
            }
            finally
            {
                if (metadataHandle != IntPtr.Zero)
                {
                    NativePlaylist.DestroyMetadata(metadataHandle);
                }
            }
        }

        /// <summary>
        /// Returns the all playlists.
        /// </summary>
        /// <returns>The set of <see cref="MediaControlPlaylist"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<MediaControlPlaylist> GetPlaylists()
        {
            ThrowIfStopped();

            var playlists = new List<MediaControlPlaylist>();

            NativePlaylist.PlaylistCallback playlistCallback = (handle, _) =>
            {
                playlists.Add(new MediaControlPlaylist(handle));
            };
            NativePlaylist.ForeachServerPlaylist(Manager.Handle, ServerAppId, playlistCallback, IntPtr.Zero)
                .ThrowIfError("Failed to get playlist.");

            return playlists.AsReadOnly();
        }

        /// <summary>
        /// Returns the playlist name of current playing media.
        /// </summary>
        /// <returns>The playlist name.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaylist GetPlaylistOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            // Get the playlist name of current playing media.
            try
            {
                Native.GetServerPlayback(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

                var (name, index) = NativePlaylist.GetPlaylistInfo(playbackHandle);

                return GetPlaylists().FirstOrDefault(playlist => playlist.Name == name);
            }
            finally
            {
                if (playbackHandle != IntPtr.Zero)
                {
                    Native.DestroyPlayback(playbackHandle).ThrowIfError("Failed to destroy playback handle.");
                }
            }
        }

        /// <summary>
        /// Returns the index of current playing media.
        /// </summary>
        /// <returns>The index of current playing media.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public string GetIndexOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlayback(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

                var (name, index) = NativePlaylist.GetPlaylistInfo(playbackHandle);
                return index;
            }
            finally
            {
                if (playbackHandle != IntPtr.Zero)
                {
                    Native.DestroyPlayback(playbackHandle).ThrowIfError("Failed to destroy playback handle.");
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
        /// Requests command to the server.
        /// </summary>
        /// <remarks>
        /// The client can request the server to execute <see cref="PlaybackCommand"/> or <see cref="ShuffleModeCommand"/> or
        /// <see cref="RepeatModeCommand"/> or <see cref="CustomCommand"/>, <br/>
        /// and then, the client receive the result of each request(command).
        /// </remarks>
        /// <param name="command">A <see cref="Command"/> class.</param>
        /// <returns><see cref="Bundle"/> represents the extra data from server and it can be null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public async Task<Bundle> RequestAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            ThrowIfStopped();

            command.SetRequestInformation(ServerAppId);

            var tcs = new TaskCompletionSource<MediaControllerError>();
            string reqeustId = null;
            Bundle bundle = null;

            EventHandler<CommandCompletedEventArgs> eventHandler = (s, e) =>
            {
                if (e.RequestId == reqeustId)
                {
                    bundle = e.Bundle;
                    tcs.TrySetResult(e.Result);
                }
            };

            try
            {
                CommandCompleted += eventHandler;

                reqeustId = command.Request(Manager.Handle);

                (await tcs.Task).ThrowIfError("Failed to request command");

                return bundle;
            }
            finally
            {
                CommandCompleted -= eventHandler;
            }
        }

        /// <summary>
        /// Sends the result of each command.
        /// </summary>
        /// <param name="command">The command that return to client.</param>
        /// <param name="result">The result of <paramref name="command"/>.</param>
        /// <param name="bundle">The extra data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public void Response(Command command, int result, Bundle bundle)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.Response(Manager.Handle, result, bundle);
        }

        /// <summary>
        /// Sends the result of each command.
        /// </summary>
        /// <param name="command">The command that return to client.</param>
        /// <param name="result">The result of <paramref name="command"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public void Response(Command command, int result)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.Response(Manager.Handle, result, null);
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
        [Obsolete("Please do not use! This will be deprecated. Please use Request instead.")]
        public void SendPlaybackCommand(MediaControlPlaybackCommand command)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), command, nameof(command));

            Native.SendPlaybackStateCommand(Manager.Handle, ServerAppId, command.ToNative()).
                ThrowIfError("Failed to send command.");
        }

        #region Capabilities
        /// <summary>
        /// Gets the content type of current playing media.
        /// </summary>
        /// <returns>The <see cref="MediaControlContentType"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlContentType GetContentTypeOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlayback(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

                Native.GetPlaybackContentType(playbackHandle, out MediaControlContentType type).
                    ThrowIfError("Failed to get playback content type");

                return type;
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
        /// Gets the icon path.
        /// </summary>
        /// <returns>The icon path.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public string GetIconPath()
        {
            ThrowIfStopped();

            Native.GetServerIcon(Manager.Handle, ServerAppId, out string uri).
                ThrowIfError("Failed to get icon path.");

            return uri;
        }

        /// <summary>
        /// Gets the age rating of current playing media.
        /// </summary>
        /// <returns>The Age rating of current playing media. The range is 0 to 19, inclusive.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int GetAgeRatingOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlayback(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

                Native.GetAgeRating(playbackHandle, out int ageRating).ThrowIfError("Failed to get age rating.");

                return ageRating;
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
        /// Gets the value whether <see cref="MediaControlPlaybackCommand"/> is supported or not.
        /// </summary>
        /// <returns>
        /// the set of <see cref="MediaControlPlaybackCommand"/> and <see cref="MediaControlCapabilitySupport"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public Dictionary<MediaControlPlaybackCommand, MediaControlCapabilitySupport> GetPlaybackCapabilities()
        {
            ThrowIfStopped();

            IntPtr playbackCapaHandle = IntPtr.Zero;

            var playbackCapabilities = new Dictionary<MediaControlPlaybackCommand, MediaControlCapabilitySupport>();

            try
            {
                Native.GetPlaybackCapabilityHandle(Manager.Handle, ServerAppId, out playbackCapaHandle).
                    ThrowIfError("Failed to get playback capability handle.");

                foreach (MediaControllerNativePlaybackAction action in Enum.GetValues(typeof(MediaControllerNativePlaybackAction)))
                {
                    Native.IsCapabilitySupported(playbackCapaHandle, action, out MediaControlCapabilitySupport support);
                    playbackCapabilities.Add(action.ToPublic(), support);
                }

                return playbackCapabilities;
            }
            finally
            {
                if (playbackCapaHandle != IntPtr.Zero)
                {
                    Native.DestroyCapability(playbackCapaHandle);
                }
            }
        }

        /// <summary>
        /// Gets the value whether <paramref name="action"/> is supported or not.
        /// </summary>
        /// <param name="action">A playback command.</param>
        /// <returns>A <see cref="MediaControlCapabilitySupport"/>.</returns>
        /// <exception cref="ArgumentException"><paramref name="action"/> is not valid.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlCapabilitySupport GetPlaybackCapability(MediaControlPlaybackCommand action)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), action, nameof(action));

            IntPtr playbackCapaHandle = IntPtr.Zero;

            try
            {
                Native.GetPlaybackCapabilityHandle(Manager.Handle, ServerAppId, out playbackCapaHandle).
                    ThrowIfError("Failed to get playback capability handle.");

                Native.IsCapabilitySupported(playbackCapaHandle, action.ToNative(), out MediaControlCapabilitySupport support);

                return support;
            }
            finally
            {
                if (playbackCapaHandle != IntPtr.Zero)
                {
                    Native.DestroyCapability(playbackCapaHandle);
                }
            }
        }

        /// <summary>
        /// Gets the value whether the shuffle mode is supported or not.
        /// </summary>
        /// <returns>A <see cref="MediaControlCapabilitySupport"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlCapabilitySupport GetShuffleModeCapability()
        {
            ThrowIfStopped();

            IntPtr playbackCapaHandle = IntPtr.Zero;

            try
            {
                Native.GetPlaybackCapabilityHandle(Manager.Handle, ServerAppId, out playbackCapaHandle).
                    ThrowIfError("Failed to get playback capability handle.");

                Native.GetShuffleCapability(Manager.Handle, ServerAppId, out MediaControlCapabilitySupport support);

                return support;
            }
            finally
            {
                if (playbackCapaHandle != IntPtr.Zero)
                {
                    Native.DestroyCapability(playbackCapaHandle);
                }
            }
        }

        /// <summary>
        /// Gets the value whether the repeat mode is supported or not.
        /// </summary>
        /// <returns>A <see cref="MediaControlCapabilitySupport"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed of.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlCapabilitySupport GetRepeatModeCapability()
        {
            ThrowIfStopped();

            IntPtr playbackCapaHandle = IntPtr.Zero;

            try
            {
                Native.GetPlaybackCapabilityHandle(Manager.Handle, ServerAppId, out playbackCapaHandle).
                    ThrowIfError("Failed to get playback capability handle.");

                Native.GetRepeatCapability(Manager.Handle, ServerAppId, out MediaControlCapabilitySupport support);

                return support;
            }
            finally
            {
                if (playbackCapaHandle != IntPtr.Zero)
                {
                    Native.DestroyCapability(playbackCapaHandle);
                }
            }
        }
        #endregion Capabilities
    }
}