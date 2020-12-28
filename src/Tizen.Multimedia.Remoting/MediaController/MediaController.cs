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


        #region Get information
        /// <summary>
        /// Returns the playback state set by the server.
        /// </summary>
        /// <returns>The playback state.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <seealso cref="MediaControlServer.SetPlaybackState(MediaControlPlaybackState, long)"/>
        /// <since_tizen> 4 </since_tizen>
        public MediaControlPlaybackState GetPlaybackState()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlaybackHandle(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <seealso cref="MediaControlServer.SetPlaybackState(MediaControlPlaybackState, long)"/>
        /// <since_tizen> 4 </since_tizen>
        public long GetPlaybackPosition()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlaybackHandle(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<MediaControlPlaylist> GetPlaylists()
        {
            ThrowIfStopped();

            var playlists = new List<MediaControlPlaylist>();

            Exception caught = null;

            NativePlaylist.PlaylistCallback playlistCallback = (handle, _) =>
            {
                try
                {
                    playlists.Add(new MediaControlPlaylist(handle));
                    return true;
                }
                catch (Exception e)
                {
                    caught = e;
                    return false;
                }
            };

            NativePlaylist.ForeachPlaylist(ServerAppId, playlistCallback, IntPtr.Zero).
                ThrowIfError("Failed to get playlist.");

            if (caught != null)
            {
                throw caught;
            }

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaylist GetPlaylistOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            // Get the playlist name of current playing media.
            try
            {
                Native.GetServerPlaybackHandle(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public string GetIndexOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlaybackHandle(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
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
        /// Gets the content type of current playing media.
        /// </summary>
        /// <returns>The <see cref="MediaControlContentType"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlContentType GetContentTypeOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlaybackHandle(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public int GetAgeRatingOfCurrentPlayingMedia()
        {
            ThrowIfStopped();

            IntPtr playbackHandle = IntPtr.Zero;

            try
            {
                Native.GetServerPlaybackHandle(Manager.Handle, ServerAppId, out playbackHandle).ThrowIfError("Failed to get playback.");

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
        /// Gets whether the subtitle mode is enabled or not.
        /// </summary>
        /// <returns>A value indicating whether the subtitle mode is enabled or not.</returns>
        /// <value>true if the subtitle mode is enabled; otherwise, false.</value>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsSubtitleModeEnabled()
        {
            ThrowIfStopped();

            Native.IsSubtitleEnabled(Manager.Handle, ServerAppId, out var isEnabled).
                ThrowIfError("Failed to get subtitle mode state.");

            return isEnabled;
        }

        /// <summary>
        /// Gets whether the 360 mode is enabled or not.
        /// </summary>
        /// <returns>A value indicating whether the 360 mode is enabled or not.</returns>
        /// <value>true if the 360 mode is enabled; otherwise, false.</value>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsMode360Enabled()
        {
            ThrowIfStopped();

            Native.IsMode360Enabled(Manager.Handle, ServerAppId, out var isEnabled).
                ThrowIfError("Failed to get 360 mode state.");

            return isEnabled;
        }

        /// <summary>
        /// Gets the current display mode.
        /// </summary>
        /// <returns>The <see cref="MediaControlDisplayMode"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="MediaControllerManager"/> has already been disposed.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public MediaControlDisplayMode GetDisplayMode()
        {
            ThrowIfStopped();

            Native.GetDisplayMode(Manager.Handle, ServerAppId, out var mode).
                ThrowIfError("Failed to get display mode state.");

            return mode.ToPublic();
        }

        /// <summary>
        /// Gets the current display rotation.
        /// </summary>
        /// <returns>The <see cref="Rotation"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        /// The <see cref="MediaControllerManager"/> has already been disposed.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public Rotation GetDisplayRotation()
        {
            ThrowIfStopped();

            Native.GetDisplayRotation(Manager.Handle, ServerAppId, out var rotation).
                ThrowIfError("Failed to get display rotation state.");

            return rotation.ToPublic();
        }
        #endregion Get information


        #region Capability
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
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
                    Native.GetPlaybackCapability(playbackCapaHandle, action, out MediaControlCapabilitySupport support);
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
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

                Native.GetPlaybackCapability(playbackCapaHandle, action.ToNative(), out MediaControlCapabilitySupport support);

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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlCapabilitySupport GetShuffleModeCapability()
        {
            ThrowIfStopped();

            Native.GetSimpleCapability(Manager.Handle, ServerAppId, MediaControlNativeCapabilityCategory.Shuffle, out MediaControlCapabilitySupport support).
                ThrowIfError("Failed to get shuffle mode capability");

            return support;
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlCapabilitySupport GetRepeatModeCapability()
        {
            ThrowIfStopped();

            Native.GetSimpleCapability(Manager.Handle, ServerAppId, MediaControlNativeCapabilityCategory.Repeat, out MediaControlCapabilitySupport support).
                ThrowIfError("Failed to get repeat mode capability");

            return support;
        }

        /// <summary>
        /// Gets the value whether the 360 mode is supported or not.
        /// </summary>
        /// <returns>A <see cref="MediaControlCapabilitySupport"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 6 </since_tizen>
        public MediaControlCapabilitySupport GetMode360Capability()
        {
            ThrowIfStopped();

            Native.GetSimpleCapability(Manager.Handle, ServerAppId, MediaControlNativeCapabilityCategory.Mode360, out MediaControlCapabilitySupport support).
                ThrowIfError("Failed to get 360 mode capability");

            return support;
        }

        /// <summary>
        /// Gets the value whether the subtitle mode is supported or not.
        /// </summary>
        /// <returns>A <see cref="MediaControlCapabilitySupport"/>.</returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 6 </since_tizen>
        public MediaControlCapabilitySupport GetSubtitleModeCapability()
        {
            ThrowIfStopped();

            Native.GetSimpleCapability(Manager.Handle, ServerAppId, MediaControlNativeCapabilityCategory.Subtitle, out MediaControlCapabilitySupport support).
                ThrowIfError("Failed to get subtitle mode capability");

            return support;
        }

        /// <summary>
        /// Gets the value whether the repeat mode is supported or not.
        /// </summary>
        /// <returns>
        /// If there's no supported display mode by server, it will return null.
        /// otherwise, it will return the supported list of <see cref="MediaControlDisplayMode"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<MediaControlDisplayMode> GetDisplayModeCapability()
        {
            ThrowIfStopped();

            Native.GetDisplayModeCapability(Manager.Handle, ServerAppId, out uint support).
                ThrowIfError("Failed to get display mode capability");

            return support != 0 ? ((MediaControlNativeDisplayMode)support).ToPublicList() : null;
        }

        /// <summary>
        /// Gets the value whether the display mode is supported or not.
        /// </summary>
        /// <returns>
        /// If there's no supported display rotation by server, it will return null.
        /// otherwise, it will return the supported list of <see cref="Rotation"/>.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <since_tizen> 6 </since_tizen>
        public IEnumerable<Rotation> GetDisplayRotationCapability()
        {
            ThrowIfStopped();

            Native.GetDisplayRotationCapability(Manager.Handle, ServerAppId, out uint support).
                ThrowIfError("Failed to get display mode capability");

            return support != 0 ? ((MediaControlNativeDisplayRotation)support).ToPublicList() : null;
        }
        #endregion Capability


        #region Command
        /// <summary>
        /// Requests a command to the server and client receives the result of each request(command).
        /// </summary>
        /// <param name="command">A <see cref="Command"/> class.</param>
        /// <returns>
        /// The type of return value is Tuple.<br/>
        /// First item of Tuple represents the <see cref="Bundle"/> and it represents the extra data from client. It can be null.<br/>
        /// Second item of Tuple represents the result of each request(command).
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <seealso cref="PlaybackCommand"/>
        /// <seealso cref="PlaybackPositionCommand"/>
        /// <seealso cref="PlaylistCommand"/>
        /// <seealso cref="ShuffleModeCommand"/>
        /// <seealso cref="RepeatModeCommand"/>
        /// <seealso cref="SubtitleModeCommand"/>
        /// <seealso cref="Mode360Command"/>
        /// <seealso cref="DisplayModeCommand"/>
        /// <seealso cref="DisplayRotationCommand"/>
        /// <seealso cref="CustomCommand"/>
        /// <seealso cref="SearchCommand"/>
        /// <since_tizen> 8 </since_tizen>
        public async Task<(Bundle bundle, int result)> RequestCommandAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            ThrowIfStopped();

            command.SetRequestInformation(ServerAppId);

            var tcs = new TaskCompletionSource<int>();
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

                var result = await tcs.Task;

                return (bundle, result);
            }
            finally
            {
                CommandCompleted -= eventHandler;
            }
        }

        /// <summary>
        /// Requests command to the server.
        /// </summary>
        /// <param name="command">A <see cref="Command"/> class.</param>
        /// <returns><see cref="Bundle"/> represents the extra data from server and it can be null.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <seealso cref="PlaybackCommand"/>
        /// <seealso cref="PlaybackPositionCommand"/>
        /// <seealso cref="PlaylistCommand"/>
        /// <seealso cref="ShuffleModeCommand"/>
        /// <seealso cref="RepeatModeCommand"/>
        /// <seealso cref="SubtitleModeCommand"/>
        /// <seealso cref="Mode360Command"/>
        /// <seealso cref="DisplayModeCommand"/>
        /// <seealso cref="DisplayRotationCommand"/>
        /// <seealso cref="CustomCommand"/>
        /// <seealso cref="SearchCommand"/>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Deprecated since API8; Will be removed in API10. Please use RequestCommandAsync(Command command) instead.")]
        public async Task<Bundle> RequestAsync(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            ThrowIfStopped();

            command.SetRequestInformation(ServerAppId);

            var tcs = new TaskCompletionSource<int>();
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

                ((MediaControllerError)await tcs.Task).ThrowIfError("Failed to request command");

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
            Response(command, result, null);
        }

        /// <summary>
        /// Sends the result of each command.
        /// </summary>
        /// <param name="command">The command that return to client.</param>
        /// <param name="result">The <see cref="MediaControlResult"/> of <paramref name="command"/>.</param>
        /// <param name="bundle">The extra data.</param>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void Response(Command command, MediaControlResult result, Bundle bundle)
        {
            Response(command, (int)result, bundle);
        }

        /// <summary>
        /// Sends the result of each command.
        /// </summary>
        /// <param name="command">The command that return to client.</param>
        /// <param name="result">The <see cref="MediaControlResult"/> of <paramref name="command"/>.</param>
        /// <exception cref="ArgumentNullException"><paramref name="command"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 8 </since_tizen>
        public void Response(Command command, MediaControlResult result)
        {
            Response(command, (int)result, null);
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
        /// <exception cref="ObjectDisposedException">The <see cref="MediaControllerManager"/> has already been disposed.</exception>
        /// <seealso cref="MediaControlServer.PlaybackCommandReceived"/>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated. Please use Request instead.")]
        public void SendPlaybackCommand(MediaControlPlaybackCommand command)
        {
            ThrowIfStopped();

            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), command, nameof(command));

            Native.SendPlaybackActionCommandWithoutReqId(Manager.Handle, ServerAppId, command.ToNative()).
                ThrowIfError("Failed to send command.");
        }
        #endregion Command
    }
}