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
using System.Collections.Generic;
using System.Threading.Tasks;
using Tizen.Applications;
using Native = Interop.MediaControllerServer;
using NativePlaylist = Interop.MediaControllerPlaylist;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to set playback information and metadata and receive commands from clients.
    /// </summary>
    /// <seealso cref="MediaControllerManager"/>
    /// <seealso cref="MediaController"/>
    /// <since_tizen> 4 </since_tizen>
    public static partial class MediaControlServer
    {
        private static IntPtr _handle;
        private static bool? _isRunning;
        private static string _serverName;

        /// <summary>
        /// Gets a value indicating whether the server is running.
        /// </summary>
        /// <value>true if the server has started; otherwise, false.</value>
        /// <seealso cref="Start"/>
        /// <seealso cref="Stop"/>
        /// <since_tizen> 4 </since_tizen>
        public static bool IsRunning
        {
            get
            {
                if (_isRunning.HasValue == false)
                {
                    _isRunning = GetRunningState();
                }

                return _isRunning.Value;
            }
        }

        private static bool GetRunningState()
        {
            IntPtr handle = IntPtr.Zero;
            try
            {
                Native.ConnectDb(out handle).ThrowIfError("Failed to retrieve the running state.");

                Native.CheckServerExist(handle, Applications.Application.Current.ApplicationInfo.ApplicationId,
                    out var value).ThrowIfError("Failed to retrieve the running state.");

                return value;
            }
            finally
            {
                if (handle != IntPtr.Zero)
                {
                    Native.DisconnectDb(handle);
                }
            }
        }

        private static void EnsureInitializedIfRunning()
        {
            if (_handle != IntPtr.Zero)
            {
                return;
            }

            if (IsRunning == false)
            {
                throw new InvalidOperationException("The server is not running.");
            }

            Initialize();
        }

        private static IntPtr Handle
        {
            get
            {
                EnsureInitializedIfRunning();

                return _handle;
            }
        }

        private static void Initialize()
        {
            Native.Create(out _handle).ThrowIfError("Failed to create media controller server.");

            try
            {
                RegisterPlaybackActionCommandReceivedEvent();
                RegisterPlaybackPositionCommandReceivedEvent();
                RegisterPlaylistCommandReceivedEvent();
                RegisterShuffleModeCommandReceivedEvent();
                RegisterRepeatModeCommandReceivedEvent();
                RegisterSubtitleModeCommandReceivedEvent();
                RegisterMode360CommandReceivedEvent();
                RegisterDisplayModeCommandReceivedEvent();
                RegisterDisplayRotationCommandReceivedEvent();
                RegisterCustomCommandReceivedEvent();
                RegisterCommandCompletedEvent();
                RegisterSearchCommandReceivedEvent();

                _serverName = Application.Current.ApplicationInfo.ApplicationId;
                _isRunning = true;
            }
            catch
            {
                Native.Destroy(_handle);
                _handle = IntPtr.Zero;
                _serverName = null;
                throw;
            }
        }

        /// <summary>
        /// Starts the media control server.
        /// </summary>
        /// <remarks>
        /// When the server starts, <see cref="MediaControllerManager.ServerStarted"/> will be raised.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediacontroller.server</privilege>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="UnauthorizedAccessException">Caller does not have required privilege.</exception>
        /// <seealso cref="MediaControllerManager.ServerStarted"/>
        /// <since_tizen> 4 </since_tizen>
        public static void Start()
        {
            Initialize();
        }

        /// <summary>
        /// Stops the media control server.
        /// </summary>
        /// <remarks>
        /// When the server stops, <see cref="MediaControllerManager.ServerStopped"/> will be raised.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <seealso cref="MediaControllerManager.ServerStopped"/>
        /// <since_tizen> 4 </since_tizen>
        public static void Stop()
        {
            EnsureInitializedIfRunning();

            Native.Destroy(_handle).ThrowIfError("Failed to stop the server.");

            _handle = IntPtr.Zero;
            _isRunning = false;
        }

        /// <summary>
        /// Gets the active clients.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <returns>the activated client ids.</returns>
        /// <since_tizen> 5 </since_tizen>
        public static IEnumerable<string> GetActivatedClients()
        {
            var clientIds = new List<string>();

            Native.ActivatedClientCallback activatedClientCallback = (name, _) =>
            {
                clientIds.Add(name);
                return true;
            };

            Native.ForeachActivatedClient(Handle, activatedClientCallback).
                ThrowIfError("Failed to get activated client.");

            return clientIds.AsReadOnly();
        }


        #region Set information
        /// <summary>
        /// Updates playback state and playback position.</summary>
        /// <param name="state">The playback state.</param>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <exception cref="ArgumentException"><paramref name="state"/> is not valid.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="position"/> is less than zero.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void SetPlaybackState(MediaControlPlaybackState state, long position)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackState), state, nameof(state));

            if (position < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(position), position, "position can't be less than zero.");
            }

            Native.SetPlaybackState(Handle, state.ToNative()).ThrowIfError("Failed to set playback state.");

            Native.SetPlaybackPosition(Handle, (ulong)position).ThrowIfError("Failed to set playback position.");

            Native.UpdatePlayback(Handle).ThrowIfError("Failed to set playback.");
        }

        private static void SetMetadata(MediaControllerNativeAttribute attribute, string value)
        {
            if (value != null)
            {
                Native.SetMetadata(Handle, attribute, value).ThrowIfError($"Failed to set metadata({attribute}).");
            }
        }

        /// <summary>
        /// Updates metadata information.
        /// </summary>
        /// <param name="metadata">The metadata to update.</param>
        /// <exception cref="ArgumentNullException"><paramref name="metadata"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void SetMetadata(MediaControlMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException(nameof(metadata));
            }

            SetMetadata(MediaControllerNativeAttribute.Title, metadata.Title);
            SetMetadata(MediaControllerNativeAttribute.Artist, metadata.Artist);
            SetMetadata(MediaControllerNativeAttribute.Album, metadata.Album);
            SetMetadata(MediaControllerNativeAttribute.Author, metadata.Author);
            SetMetadata(MediaControllerNativeAttribute.Genre, metadata.Genre);
            SetMetadata(MediaControllerNativeAttribute.Duration, metadata.Duration);
            SetMetadata(MediaControllerNativeAttribute.Date, metadata.Date);
            SetMetadata(MediaControllerNativeAttribute.Copyright, metadata.Copyright);
            SetMetadata(MediaControllerNativeAttribute.Description, metadata.Description);
            SetMetadata(MediaControllerNativeAttribute.TrackNumber, metadata.TrackNumber);
            SetMetadata(MediaControllerNativeAttribute.Picture, metadata.AlbumArtPath);
            SetMetadata(MediaControllerNativeAttribute.Season, metadata.EncodedSeason);
            SetMetadata(MediaControllerNativeAttribute.Episode, metadata.EncodedEpisode);
            SetMetadata(MediaControllerNativeAttribute.Resolution, metadata.EncodedResolution);

            Native.UpdateMetadata(Handle).ThrowIfError("Failed to set metadata.");
        }

        /// <summary>
        /// Updates the shuffle mode.
        /// </summary>
        /// <param name="enabled">A value indicating whether the shuffle mode is enabled.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public static void SetShuffleModeEnabled(bool enabled)
        {
            Native.UpdateShuffleMode(Handle, enabled ? MediaControllerNativeShuffleMode.On : MediaControllerNativeShuffleMode.Off).
                ThrowIfError("Failed to set shuffle mode.");
        }

        /// <summary>
        /// Updates the repeat mode.
        /// </summary>
        /// <param name="mode">A value indicating the repeat mode.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="mode"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static void SetRepeatMode(MediaControlRepeatMode mode)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), mode, nameof(mode));

            Native.UpdateRepeatMode(Handle, mode.ToNative()).ThrowIfError("Failed to set repeat mode.");
        }

        /// <summary>
        /// Sets the playlist name and index of current playing media.
        /// </summary>
        /// <param name="playlistName">The playlist name of current playing media.</param>
        /// <param name="index">The index of current playing media.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetInfoOfCurrentPlayingMedia(string playlistName, string index)
        {
            if (playlistName == null)
            {
                throw new ArgumentNullException(nameof(playlistName));
            }
            if (index == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            Native.SetInfoOfCurrentPlayingMedia(Handle, playlistName, index)
                .ThrowIfError("Failed to set the playlist name and index of current playing media");

            Native.UpdatePlayback(Handle).ThrowIfError("Failed to set playback.");
        }

        /// <summary>
        /// Sets the age rating of latest played media.
        /// </summary>
        /// <param name="ageRating">
        /// The Age rating of latest played media. The valid range is 0 to 19, inclusive.
        /// Especially, 0 means that media is suitable for all ages.
        /// </param>
        /// <exception cref="ArgumentOutOfRangeException">The specified <paramref name="ageRating"/> is not valid.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetAgeRating(int ageRating)
        {
            if (ageRating < 0 || ageRating > 19)
            {
                throw new ArgumentOutOfRangeException(nameof(ageRating));
            }

            Native.SetAgeRating(Handle, ageRating).ThrowIfError("Failed to set age rating.");

            Native.UpdatePlayback(Handle).ThrowIfError("Failed to set playback.");
        }

        /// <summary>
        /// Sets the subtitle mode.
        /// </summary>
        /// <param name="isEnabled">A value indicating whether the subtitle mode is enabled.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetSubtitleMode(bool isEnabled)
        {
            Native.UpdateSubtitleMode(Handle, isEnabled).ThrowIfError("Failed to set subtitle mode.");
        }

        /// <summary>
        /// Sets the 360 mode.
        /// </summary>
        /// <param name="isEnabled">A value indicating whether the 360 mode is enabled.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetMode360(bool isEnabled)
        {
            Native.UpdateMode360(Handle, isEnabled).ThrowIfError("Failed to set 360 mode.");
        }

        /// <summary>
        /// Sets the display mode.
        /// </summary>
        /// <param name="mode">A value indicating the <see cref="MediaControlDisplayMode"/>.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDisplayMode(MediaControlDisplayMode mode)
        {
            Native.UpdateDisplayMode(Handle, mode.ToNative()).ThrowIfError("Failed to set display mode.");
        }

        /// <summary>
        /// Sets the display rotation.
        /// </summary>
        /// <param name="rotation">A value indicating the <see cref="Rotation"/>.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDisplayRotation(Rotation rotation)
        {
            Native.UpdateDisplayRotaton(Handle, rotation.ToNative()).ThrowIfError("Failed to set display rotation.");
        }

        /// <summary>
        /// Sets the index of current playing media.
        /// </summary>
        /// <param name="index">The index of current playing media.</param>
        /// <exception cref="ArgumentNullException"><paramref name="index"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Please do not use! This will be deprecated. Please use SetInfoOfCurrentPlayingMedia instead.")]
        public static void SetIndexOfCurrentPlayingMedia(string index)
        {
            if (index == null)
            {
                throw new ArgumentNullException(nameof(index));
            }

            Native.SetIndexOfCurrentPlayingMedia(Handle, index)
                .ThrowIfError("Failed to set the index of current playing media");

            Native.UpdatePlayback(Handle).ThrowIfError("Failed to set playback.");
        }
        #endregion Set information


        #region Playlist
        /// <summary>
        /// Delete playlist.
        /// </summary>
        /// <remarks>Currently, only server can remove the playlist.</remarks>
        /// <param name="playlist">The name of playlist.</param>
        /// <exception cref="ArgumentNullException"><paramref name="playlist"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static void RemovePlaylist(MediaControlPlaylist playlist)
        {
            if (playlist == null)
            {
                throw new ArgumentNullException(nameof(playlist));
            }

            Native.DeletePlaylist(Handle, playlist.Handle);
            playlist.Dispose();
        }

        // Saves the playlist to the persistent storage.
        internal static void SavePlaylist(IntPtr playlistHandle)
        {
            Native.SavePlaylist(Handle, playlistHandle).ThrowIfError("Failed to save playlist");
        }

        // Gets the playlist handle by name.
        internal static IntPtr GetPlaylistHandle(string name)
        {
            NativePlaylist.GetPlaylistHandle(_serverName, name, out IntPtr playlistHandle).
                ThrowIfError("Failed to get playlist handle by name");

            return playlistHandle;
        }
        #endregion Playlist


        #region Capability
        /// <summary>
        /// Sets the content type of latest played media.
        /// </summary>
        /// <param name="type">A value indicating the content type of the latest played media.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="type"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetPlaybackContentType(MediaControlContentType type)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlContentType), type, nameof(type));

            Native.SetPlaybackContentType(Handle, type).ThrowIfError("Failed to set playback content type.");

            Native.UpdatePlayback(Handle).ThrowIfError("Failed to set playback.");
        }

        /// <summary>
        /// Sets the path of icon.
        /// </summary>
        /// <param name="path">The path of icon.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetIconPath(string path)
        {
            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            Native.SetIconPath(Handle, path).ThrowIfError("Failed to set uri path.");
        }

        /// <summary>
        /// Sets the capabilities by <see cref="MediaControlPlaybackCommand"/>.
        /// </summary>
        /// <param name="capabilities">The set of <see cref="MediaControlPlaybackCommand"/> and <see cref="MediaControlCapabilitySupport"/>.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="capabilities"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetPlaybackCapabilities(Dictionary<MediaControlPlaybackCommand, MediaControlCapabilitySupport> capabilities)
        {
            foreach (var pair in capabilities)
            {
                ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), pair.Key, nameof(pair.Key));
                ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), pair.Value, nameof(pair.Value));

                SetPlaybackCapability(pair.Key, pair.Value);
                Native.SetPlaybackCapability(Handle, pair.Key.ToNative(), pair.Value).
                    ThrowIfError("Failed to set playback capability.");
            }

            Native.SaveAndNotifyPlaybackCapabilityUpdated(Handle).ThrowIfError("Failed to update playback capability.");
        }

        /// <summary>
        /// Sets the capabilities by <see cref="MediaControlPlaybackCommand"/>.
        /// </summary>
        /// <param name="action">A playback command.</param>
        /// <param name="support">A value indicating whether the <paramref name="action"/> is supported or not.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="action"/> or <paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetPlaybackCapability(MediaControlPlaybackCommand action, MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), action, nameof(action));
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Native.SetPlaybackCapability(Handle, action.ToNative(), support).ThrowIfError("Failed to set playback capability.");

            Native.SaveAndNotifyPlaybackCapabilityUpdated(Handle).ThrowIfError("Failed to update playback capability.");
        }

        /// <summary>
        /// Sets the <see cref="MediaControlCapabilitySupport"/> indicating shuffle mode is supported or not.
        /// </summary>
        /// <param name="support">A value indicating whether the shuffle mode is supported or not.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetShuffleModeCapability(MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Native.SetSimpleCapability(Handle, MediaControlNativeCapabilityCategory.Shuffle, support).
                ThrowIfError("Failed to set shuffle mode capability.");
        }

        /// <summary>
        /// Sets the <see cref="MediaControlCapabilitySupport"/> indicating repeat mode is supported or not.
        /// </summary>
        /// <param name="support">A value indicating whether the <see cref="MediaControlRepeatMode"/> is supported or not.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public static void SetRepeatModeCapability(MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Native.SetSimpleCapability(Handle, MediaControlNativeCapabilityCategory.Repeat, support).
                ThrowIfError("Failed to set repeat mode capability.");
        }

        /// <summary>
        /// Sets the <see cref="MediaControlCapabilitySupport"/> indicating whether 360 mode is supported or not.
        /// </summary>
        /// <param name="support">A value indicating whether the 360 mode is supported or not.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetMode360Capability(MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Native.SetSimpleCapability(Handle, MediaControlNativeCapabilityCategory.Mode360, support).
                ThrowIfError("Failed to set 360 mode capability.");
        }

        /// <summary>
        /// Sets the <see cref="MediaControlCapabilitySupport"/> indicating whether subtitle mode is supported or not.
        /// </summary>
        /// <param name="support">A value indicating whether the subtitle mode is supported or not.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetSubtitleModeCapability(MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            Native.SetSimpleCapability(Handle, MediaControlNativeCapabilityCategory.Subtitle, support).
                ThrowIfError("Failed to set subtitle mode capability.");
        }

        /// <summary>
        /// Sets the supported list of <see cref="MediaControlDisplayMode"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="MediaControlCapabilitySupport.NotDecided"/> is not allowed in display mode capability.
        /// The default value of each <see cref="MediaControlDisplayMode"/> is not supported.
        /// </remarks>
        /// <param name="capabilities">The supported list of <see cref="MediaControlDisplayMode"/>.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="capabilities"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDisplayModeCapabilities(IDictionary<MediaControlDisplayMode, MediaControlCapabilitySupport> capabilities)
        {
            foreach (var pair in capabilities)
            {
                SetDisplayModeCapability(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Sets the <paramref name="mode"/> is supported or not.
        /// </summary>
        /// <remarks>
        /// <see cref="MediaControlCapabilitySupport.NotDecided"/> is not allowed in display mode capability.<br/>
        /// The default value of each <see cref="MediaControlDisplayMode"/> is not supported.
        /// </remarks>
        /// <param name="mode">The <see cref="MediaControlDisplayMode"/>.</param>
        /// <param name="support">A value indicating whether the <paramref name="mode"/> is supported or not.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="mode"/> or <paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDisplayModeCapability(MediaControlDisplayMode mode, MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlDisplayMode), mode, nameof(mode));
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            if (support == MediaControlCapabilitySupport.NotDecided)
            {
                throw new ArgumentException($"NotDecided is not allowed in {mode} capability.");
            }

            Native.SetDisplayModeCapability(Handle, (uint)mode.ToNative(), support).
                ThrowIfError("Failed to set display mode capability.");
        }

        /// <summary>
        /// Sets the supported list of <see cref="Rotation"/>.
        /// </summary>
        /// <remarks>
        /// <see cref="MediaControlCapabilitySupport.NotDecided"/> is not allowed in display rotation capability.<br/>
        /// The default value of each <see cref="Rotation"/> is not supported.
        /// </remarks>
        /// <param name="capabilities">The supported list of <see cref="Rotation"/>.</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="capabilities"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDisplayRotationCapabilities(IDictionary<Rotation, MediaControlCapabilitySupport> capabilities)
        {
            foreach (var pair in capabilities)
            {
                SetDisplayRotationCapability(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Sets the <paramref name="rotation"/> is supported or not.
        /// </summary>
        /// <remarks>
        /// <see cref="MediaControlCapabilitySupport.NotDecided"/> is not allowed in display rotation capability.<br/>
        /// The default value of each <see cref="Rotation"/> is not supported.
        /// </remarks>
        /// <param name="rotation">The <see cref="Rotation"/>.</param>
        /// <param name="support">A value indicating whether the <paramref name="rotation"/> is supported or not..</param>
        /// <exception cref="InvalidOperationException">
        ///     The server is not running .<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentException"><paramref name="rotation"/> or <paramref name="support"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public static void SetDisplayRotationCapability(Rotation rotation, MediaControlCapabilitySupport support)
        {
            ValidationUtil.ValidateEnum(typeof(Rotation), rotation, nameof(rotation));
            ValidationUtil.ValidateEnum(typeof(MediaControlCapabilitySupport), support, nameof(support));

            if (support == MediaControlCapabilitySupport.NotDecided)
            {
                throw new ArgumentException($"NotDecided is not allowed in {rotation} capability.");
            }

            Native.SetDisplayRotationCapability(Handle, (uint)rotation.ToNative(), support).
                ThrowIfError("Failed to set display rotation capability.");
        }
        #endregion Capability


        #region Command
        /// <summary>
        /// Requests a command to the client and server receives the result of each request(command).
        /// </summary>
        /// <param name="command">A <see cref="Command"/> class.</param>
        /// <param name="clientId">The client Id to send command.</param>
        /// <returns>
        /// The type of return value is Tuple.<br/>
        /// First item of Tuple represents the <see cref="Bundle"/> and it represents the extra data from client. It can be null.<br/>
        /// Second item of Tuple represents the result of each request(command).
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="command"/> or <paramref name="clientId"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="NotImplementedException">The command which is not supported is used.</exception>
        /// <seealso cref="CustomCommand"/>
        /// <since_tizen> 8 </since_tizen>
        public static async Task<(Bundle bundle, int result)> RequestCommandAsync(Command command, string clientId)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            command.SetRequestInformation(clientId);

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

                reqeustId = command.Request(Handle);

                var result = await tcs.Task;

                return (bundle, result);
            }
            finally
            {
                CommandCompleted -= eventHandler;
            }
        }

        /// <summary>
        /// Requests commands to the client.
        /// </summary>
        /// <param name="command">A <see cref="Command"/> class.</param>
        /// <param name="clientId">The client Id to send command.</param>
        /// <returns><see cref="Bundle"/> represents the extra data from client and it can be null.</returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="command"/> or <paramref name="clientId"/> is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     The server has already been stopped.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <seealso cref="CustomCommand"/>
        /// <since_tizen> 5 </since_tizen>
        [Obsolete("Deprecated since API8; Will be removed in API10. Please use RequestCommandAsync(Command command) instead.")]
        public static async Task<Bundle> RequestAsync(Command command, string clientId)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
            if (clientId == null)
            {
                throw new ArgumentNullException(nameof(clientId));
            }

            command.SetRequestInformation(clientId);

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

                reqeustId = command.Request(Handle);

                ((MediaControllerError)await tcs.Task).ThrowIfError("Failed to request event.");

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
        public static void Response(Command command, int result, Bundle bundle)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.Response(Handle, result, bundle);
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
        public static void Response(Command command, int result)
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
        public static void Response(Command command, MediaControlResult result, Bundle bundle)
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
        public static void Response(Command command, MediaControlResult result)
        {
            Response(command, (int)result, null);
        }
        #endregion Command
    }
}