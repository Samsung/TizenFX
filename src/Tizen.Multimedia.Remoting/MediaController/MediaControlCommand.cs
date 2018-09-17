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
using System.Collections.Generic;
using NativeClient = Interop.MediaControllerClient;
using NativeServer = Interop.MediaControllerServer;
using NativeClientHandle = Interop.MediaControllerClientHandle;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to send command to media control server.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class Command
    {
        /// <summary>
        /// The request id for each command.
        /// </summary>
        protected string _requestId;

        internal NativeClientHandle _clientHandle;

        /// <summary>
        /// The client id.
        /// </summary>
        protected string _clientId;

        /// <summary>
        /// The server id.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected string _serverId;

        /// <summary>
        /// Initializes a <see cref="Command"/> base class.
        /// </summary>
        protected Command() { }

        internal abstract string Request();

        internal virtual void Response(IntPtr handle, int result, Bundle bundle)
        {
            if (bundle != null)
            {
                NativeServer.SendCommandReplyBundle(handle, _clientId, _requestId, result, bundle.SafeBundleHandle)
                    .ThrowIfError("Failed to response command.");
            }
            else
            {
                NativeServer.SendCommandReply(handle, _clientId, _requestId, result, IntPtr.Zero)
                    .ThrowIfError("Failed to response command.");
            }
        }

        /// <summary>
        /// Sets the server information.
        /// </summary>
        /// <param name="clientrHandle">The client handle.</param>
        /// <param name="serverId">The server Id that receives command.</param>
        internal void SetServerInfo(NativeClientHandle clientrHandle, string serverId)
        {
            _serverId = serverId;
            _clientHandle = clientrHandle;
        }

        /// <summary>
        /// Sets the client information.
        /// </summary>
        /// <param name="clientId">The client Id that will be received response.</param>
        /// <param name="requestId">The request Id for each command.</param>
        internal void SetClientInfo(string clientId, string requestId)
        {
            _clientId = clientId;
            _requestId = requestId;
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
        /// <param name="action">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(MediaControlPlaybackCommand action)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the playback action.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaybackCommand Action { get; }

        internal override string Request()
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), Action, nameof(MediaControlPlaybackCommand));

            NativeClient.SendPlaybackActionCommand(_clientHandle, _serverId, Action.ToNative(), out string requestId)
                .ThrowIfError("Failed to send playback command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to send playback command to order specific time position.
    /// </summary>
    public sealed class PlaybackPositionCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackPositionCommand"/> class.
        /// </summary>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackPositionCommand(ulong position)
        {
            Position = position;
        }

        /// <summary>
        /// Gets the position to play.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ulong Position { get; }

        internal override string Request()
        {
            NativeClient.SendPlaybackPositionCommand(_clientHandle, _serverId, Position, out string requestId)
                .ThrowIfError("Failed to send playback position command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to send playback command with playlist information.
    /// </summary>
    public sealed class PlaylistCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="action">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <param name="playlistName">The playlist name of the server.</param>
        /// <param name="index">The index of the media in the playlist.</param>
        /// <param name="position">The playback position in milliseconds.</param>
        /// <exception cref="ArgumentException"><paramref name="index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is not vailed.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaylistCommand(MediaControlPlaybackCommand action, string playlistName, string index, ulong position)
        {
            Action = action;
            Index = index ?? throw new ArgumentNullException("Playlist index is not set.");
            Name = playlistName ?? throw new ArgumentNullException("Playlist name is not set.");
            Position = position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="action">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <param name="playlistName">The playlist name of the server.</param>
        /// <param name="index">The index of the media in the playlist.</param>
        /// <exception cref="ArgumentException"><paramref name="index"/> cannot be converted to number.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is not set.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaylistCommand(MediaControlPlaybackCommand action, string playlistName, string index)
            : this(action, playlistName, index, 0)
        {
        }

        /// <summary>
        /// Gets the playback action.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaybackCommand Action { get; }

        /// <summary>
        /// Gets the position to play.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public ulong Position { get; }

        /// <summary>
        /// Gets the index of playlist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Index { get; }

        /// <summary>
        /// Gets the name of playlist.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Name { get; }

        internal override string Request()
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), Action, nameof(MediaControlPlaybackCommand));

            NativeClient.SendPlaylistCommand(_clientHandle, _serverId, Name, Index, Action.ToNative(),
                Position, out string requestId).ThrowIfError("Failed to send playlist command.");

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
        /// <param name="enabled">A shuffle mode.</param>
        /// <since_tizen> 5 </since_tizen>
        public ShuffleModeCommand(bool enabled)
        {
            Enabled = enabled;
        }

        /// <summary>
        /// Gets a value indicating whether the shuffle mode is enabled.
        /// </summary>
        public bool Enabled { get; }

        internal override string Request()
        {
            var mode = Enabled ? MediaControllerNativeShuffleMode.On : MediaControllerNativeShuffleMode.Off;

            NativeClient.SendShuffleModeCommand(_clientHandle, _serverId, mode, out string requestId).
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
        {
            Mode = mode;
        }

        /// <summary>
        /// Gets the repeat mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlRepeatMode Mode { get; }

        internal override string Request()
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), Mode, nameof(MediaControlRepeatMode));

            NativeClient.SendRepeatModeCommand(_clientHandle, _serverId, Mode.ToNative(), out string requestId).
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
        /// <param name="action">A predefined custom command.</param>
        /// <since_tizen> 5 </since_tizen>
        public CustomCommand(string action)
        {
            Action = action ?? throw new ArgumentNullException("Custom command is not set.");
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomCommand"/> class.
        /// </summary>
        /// <param name="action">A predefined custom command.</param>
        /// <param name="bundle">The extra data for custom command.</param>
        /// <since_tizen> 5 </since_tizen>
        public CustomCommand(string action, Bundle bundle)
            : this(action)
        {
            Bundle = bundle;
        }

        ///<summary>
        /// Gets the custom action.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string Action { get; }

        /// <summary>
        /// Gets the extra data.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public Bundle Bundle { get; }

        internal override string Request()
        {
            string requestId = null;

            if (Bundle != null)
            {
                NativeClient.SendCustomCommandBundle(_clientHandle, _serverId, Action, Bundle.SafeBundleHandle, out requestId).
                    ThrowIfError("Failed to send custom command.");
            }
            else
            {
                NativeClient.SendCustomCommand(_clientHandle, _serverId, Action, IntPtr.Zero, out requestId).
                    ThrowIfError("Failed to send custom command.");
            }

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send search commands.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public sealed class SearchCommand : Command
    {
        private IntPtr _searchHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCommand"/> class.
        /// </summary>
        /// <remarks>User can search maximum 20 items once.</remarks>
        /// <exception cref="ArgumentException">
        ///     <paramref name="conditions"/> is greater than maximum value(20).<br/>
        ///     -or-<br/>
        ///     <paramref name="conditions"/> is less than 1.
        /// </exception>
        /// <param name="conditions">The set of <see cref="MediaControlSearchCondition"/>.</param>
        public SearchCommand(List<MediaControlSearchCondition> conditions)
        {
            if (conditions.Count <= 0)
            {
                throw new ArgumentException("Search condition is not set.");
            }
            if (conditions.Count > 20)
            {
                throw new ArgumentException("So many search items.");
            }

            NativeClient.CreateSearchHandle(out _searchHandle).ThrowIfError("Failed to create search handle.");

            try
            {
                foreach (var condition in conditions)
                {
                    if (condition.Bundle != null)
                    {
                        NativeClient.SetSearchConditionBundle(_searchHandle, condition.ContentType,
                            condition.Category == 0 ? MediaControlNativeSearchCategory.NoCategory : condition.Category.ToNative(),
                            condition.Keyword, condition.Bundle.SafeBundleHandle).
                            ThrowIfError("Failed to set search condition.");
                    }
                    else
                    {
                        NativeClient.SetSearchCondition(_searchHandle, condition.ContentType,
                            condition.Category == 0 ? MediaControlNativeSearchCategory.NoCategory : condition.Category.ToNative(),
                            condition.Keyword, IntPtr.Zero).
                            ThrowIfError("Failed to set search condition.");
                    }
                }
            }
            catch
            {
                if (_searchHandle != IntPtr.Zero)
                {
                    NativeClient.DestroySearchHandle(_searchHandle).ThrowIfError("Failed to destroy search handle");
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCommand"/> class.
        /// </summary>
        /// <param name="condition">The set of <see cref="MediaControlSearchCondition"/>.</param>
        public SearchCommand(MediaControlSearchCondition condition)
        {
            NativeClient.CreateSearchHandle(out _searchHandle).ThrowIfError("Failed to create search handle.");

            try
            {   
                if (condition.Bundle != null)
                {
                    NativeClient.SetSearchConditionBundle(_searchHandle, condition.ContentType,
                        condition.Category == 0 ? MediaControlNativeSearchCategory.NoCategory : condition.Category.ToNative(),
                        condition.Keyword, condition.Bundle.SafeBundleHandle).
                        ThrowIfError("Failed to set search condition.");
                }
                else
                {
                    NativeClient.SetSearchCondition(_searchHandle, condition.ContentType,
                        condition.Category == 0 ? MediaControlNativeSearchCategory.NoCategory : condition.Category.ToNative(),
                        condition.Keyword, IntPtr.Zero).
                        ThrowIfError("Failed to set search condition.");
                }
            }
            catch
            {
                if (_searchHandle != IntPtr.Zero)
                {
                    NativeClient.DestroySearchHandle(_searchHandle).ThrowIfError("Failed to destroy search handle");
                }
            }
        }

        internal SearchCommand(List<MediaControlSearchCondition> conditions, IntPtr searchHandle)
        {
            _searchHandle = searchHandle;

            try
            {
                foreach (var condition in conditions)
                {
                    if (condition.Bundle != null)
                    {
                        NativeClient.SetSearchConditionBundle(_searchHandle, condition.ContentType,
                            condition.Category == 0 ? MediaControlNativeSearchCategory.NoCategory : condition.Category.ToNative(),
                            condition.Keyword, condition.Bundle.SafeBundleHandle).
                            ThrowIfError("Failed to set search condition.");
                    }
                    else
                    {
                        NativeClient.SetSearchCondition(_searchHandle, condition.ContentType,
                            condition.Category == 0 ? MediaControlNativeSearchCategory.NoCategory : condition.Category.ToNative(),
                            condition.Keyword, IntPtr.Zero).
                            ThrowIfError("Failed to set search condition.");
                    }
                }
            }
            catch
            {
                if (_searchHandle != IntPtr.Zero)
                {
                    NativeClient.DestroySearchHandle(_searchHandle).ThrowIfError("Failed to destroy search handle");
                }
            }
        }

        internal override string Request()
        {
            NativeClient.SendSearchCommand(_clientHandle, _serverId, _searchHandle, out string requestId).
                ThrowIfError("Failed to send search command.");

            if (_searchHandle != IntPtr.Zero)
            {
                NativeClient.DestroySearchHandle(_searchHandle).ThrowIfError("Failed to destroy search handle");
            }

            return requestId;
        }

        internal override void Response(IntPtr handle, int result, Bundle bundle)
        {
            try
            {
                if (bundle != null)
                {
                    NativeServer.SendCommandReplyBundle(handle, _clientId, _requestId, result, bundle.SafeBundleHandle)
                        .ThrowIfError("Failed to response command.");
                }
                else
                {
                    NativeServer.SendCommandReply(handle, _clientId, _requestId, result, IntPtr.Zero)
                        .ThrowIfError("Failed to response command.");
                }
            }
            finally
            {
                if (_searchHandle != IntPtr.Zero)
                {
                    NativeClient.DestroySearchHandle(_searchHandle).ThrowIfError("Failed to destroy search handle");
                }
            }
        }
    }
}