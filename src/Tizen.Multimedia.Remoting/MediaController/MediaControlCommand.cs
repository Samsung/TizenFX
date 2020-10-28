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
        private string _requestId;

        /// <summary>
        /// The id for command receiver.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected string ReceiverId { get; private set; }

        /// <summary>
        /// Initializes a <see cref="Command"/> base class.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected Command() { }

        /// <summary>
        /// Sets the server information.
        /// </summary>
        /// <param name="receiverId">The receiver Id that receives command.</param>
        internal void SetRequestInformation(string receiverId)
        {
            ReceiverId = receiverId ?? throw new ArgumentNullException(nameof(receiverId));
        }

        /// <summary>
        /// Sets the client information.
        /// </summary>
        /// <param name="receiverId">The receiver Id that receives response for command.</param>
        /// <param name="requestId">The request Id for each command.</param>
        internal void SetResponseInformation(string receiverId, string requestId)
        {
            ReceiverId = receiverId ?? throw new ArgumentNullException(nameof(receiverId)); ;
            _requestId = requestId ?? throw new ArgumentNullException(nameof(requestId)); ;
        }

        /// <summary>
        /// Requests command to server.
        /// </summary>
        /// <returns>The request id for each command.</returns>
        internal abstract string Request(NativeClientHandle clientHandle);

        /// <summary>
        /// Requests command to client.
        /// </summary>
        /// <param name="serverHandle"></param>
        /// <returns>The request id for each command.</returns>
        internal virtual string Request(IntPtr serverHandle) => throw new NotImplementedException();

        /// <summary>
        /// Represents a method that is called when an response command completes.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected virtual void OnResponseCompleted() { }

        /// <summary>
        /// Responses command to the client.
        /// </summary>
        /// <param name="serverHandle">The server handle.</param>
        /// <param name="result">The result of each command.</param>
        /// <param name="bundle">The extra data.</param>
        internal void Response(IntPtr serverHandle, int result, Bundle bundle)
        {
            try
            {
                if (bundle != null)
                {
                    NativeServer.SendCommandReplyBundle(serverHandle, ReceiverId, _requestId, result, bundle.SafeBundleHandle)
                        .ThrowIfError("Failed to response command.");
                }
                else
                {
                    NativeServer.SendCommandReply(serverHandle, ReceiverId, _requestId, result, IntPtr.Zero)
                        .ThrowIfError("Failed to response command.");
                }
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException("Server is not running");
            }
            finally
            {
                OnResponseCompleted();
            }
        }

        /// <summary>
        /// Responses command to the server.
        /// </summary>
        /// <param name="clientHandle">The client handle.</param>
        /// <param name="result">The result of each command.</param>
        /// <param name="bundle">The extra data.</param>
        internal void Response(NativeClientHandle clientHandle, int result, Bundle bundle)
        {
            try
            {
                if (bundle != null)
                {
                    NativeClient.SendCustomEventReplyBundle(clientHandle, ReceiverId, _requestId, result, bundle.SafeBundleHandle)
                        .ThrowIfError("Failed to response event.");
                }
                else
                {
                    NativeClient.SendCustomEventReply(clientHandle, ReceiverId, _requestId, result, IntPtr.Zero)
                        .ThrowIfError("Failed to response event.");
                }
            }
            catch (ArgumentException)
            {
                throw new InvalidOperationException("Server is not running");
            }
            finally
            {
                OnResponseCompleted();
            }
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
        /// <exception cref="ArgumentException"><paramref name="action"/> is not valid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaybackCommand(MediaControlPlaybackCommand action)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), action, nameof(action));

            Action = action;
        }

        /// <summary>
        /// Gets the playback action.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlPlaybackCommand Action { get; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), Action, nameof(Action));

            NativeClient.SendPlaybackActionCommand(clientHandle, ReceiverId, Action.ToNative(), out string requestId)
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

        internal override string Request(NativeClientHandle clientHandle)
        {
            NativeClient.SendPlaybackPositionCommand(clientHandle, ReceiverId, Position, out string requestId)
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
        /// <exception cref="ArgumentException"><paramref name="action"/>is not valid.</exception>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is null.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public PlaylistCommand(MediaControlPlaybackCommand action, string playlistName, string index, ulong position)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), action, nameof(action));

            Action = action;
            Index = index ?? throw new ArgumentNullException(nameof(index));
            Name = playlistName ?? throw new ArgumentNullException(nameof(playlistName));
            Position = position;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PlaybackCommand"/> class.
        /// </summary>
        /// <param name="action">A <see cref="MediaControlPlaybackCommand"/>.</param>
        /// <param name="playlistName">The playlist name of the server.</param>
        /// <param name="index">The index of the media in the playlist.</param>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="playlistName"/> or <paramref name="index"/> is null.
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

        internal override string Request(NativeClientHandle clientHandle)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlPlaybackCommand), Action, nameof(Action));

            NativeClient.SendPlaylistCommand(clientHandle, ReceiverId, Name, Index, Action.ToNative(),
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

        internal override string Request(NativeClientHandle clientHandle)
        {
            var mode = Enabled ? MediaControllerNativeShuffleMode.On : MediaControllerNativeShuffleMode.Off;

            NativeClient.SendShuffleModeCommand(clientHandle, ReceiverId, mode, out string requestId).
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
        /// <exception cref="ArgumentException"><paramref name="mode"/> is not valid.</exception>
        /// <since_tizen> 5 </since_tizen>
        public RepeatModeCommand(MediaControlRepeatMode mode)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), mode, nameof(mode));

            Mode = mode;
        }

        /// <summary>
        /// Gets the repeat mode.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public MediaControlRepeatMode Mode { get; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlRepeatMode), Mode, nameof(Mode));

            NativeClient.SendRepeatModeCommand(clientHandle, ReceiverId, Mode.ToNative(), out string requestId).
                ThrowIfError("Failed to send playback repeat command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send subtitle mode command.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public sealed class SubtitleModeCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SubtitleModeCommand"/> class.
        /// </summary>
        /// <param name="isEnabled">A value indicating whether subtitle mode is enabled.</param>
        /// <since_tizen> 6 </since_tizen>
        public SubtitleModeCommand(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// Gets a value indicating whether subtitle mode is enabled or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsEnabled { get; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            NativeClient.SendSubtitleModeCommand(clientHandle, ReceiverId, IsEnabled, out string requestId).
                ThrowIfError("Failed to send subtitle mode command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send 360 mode command.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public sealed class Mode360Command : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Mode360Command"/> class.
        /// </summary>
        /// <param name="isEnabled">A value indicating whether 360 mode is enabled or not.</param>
        /// <since_tizen> 6 </since_tizen>
        public Mode360Command(bool isEnabled)
        {
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// Gets a value indicating whether 360 mode is enabled or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsEnabled { get; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            NativeClient.SendMode360Command(clientHandle, ReceiverId, IsEnabled, out string requestId).
                ThrowIfError("Failed to send 360 mode command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send display mode command.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public sealed class DisplayModeCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayModeCommand"/> class.
        /// </summary>
        /// <param name="mode">The <see cref="MediaControlDisplayMode"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="mode"/> is not valid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public DisplayModeCommand(MediaControlDisplayMode mode)
        {
            ValidationUtil.ValidateEnum(typeof(MediaControlDisplayMode), mode, nameof(mode));

            Mode = mode;
        }

        /// <summary>
        /// Gets the display mode.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public MediaControlDisplayMode Mode { get; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            NativeClient.SendDisplayModeCommand(clientHandle, ReceiverId, Mode.ToNative(), out string requestId).
                ThrowIfError("Failed to send display mode command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send display rotation command.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public sealed class DisplayRotationCommand : Command
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DisplayRotationCommand"/> class.
        /// </summary>
        /// <param name="rotation">The <see cref="Rotation"/>.</param>
        /// <exception cref="ArgumentException"><paramref name="rotation"/> is not valid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public DisplayRotationCommand(Rotation rotation)
        {
            ValidationUtil.ValidateEnum(typeof(Rotation), rotation, nameof(rotation));

            Rotation = rotation;
        }

        /// <summary>
        /// Gets the display rotation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Rotation Rotation { get; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            NativeClient.SendDisplayRotationCommand(clientHandle, ReceiverId, Rotation.ToNative(), out string requestId).
                ThrowIfError("Failed to send display rotation command.");

            return requestId;
        }
    }

    /// <summary>
    /// Provides a means to to send custom commands.
    /// </summary>
    /// <remarks>This command can be used by both client and server to send predefined command or data.</remarks>
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
            Action = action ?? throw new ArgumentNullException(nameof(action));
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

        internal override string Request(NativeClientHandle clientHandle)
        {
            string requestId = null;

            if (Bundle != null)
            {
                NativeClient.SendCustomCommandBundle(clientHandle, ReceiverId, Action, Bundle.SafeBundleHandle, out requestId).
                    ThrowIfError("Failed to send custom command.");
            }
            else
            {
                NativeClient.SendCustomCommand(clientHandle, ReceiverId, Action, IntPtr.Zero, out requestId).
                    ThrowIfError("Failed to send custom command.");
            }

            return requestId;
        }

        internal override string Request(IntPtr serverHandle)
        {
            string requestId = null;

            if (Bundle != null)
            {
                NativeServer.SendCustomEventBundle(serverHandle, ReceiverId, Action, Bundle.SafeBundleHandle, out requestId)
                    .ThrowIfError("Failed to send costom event.");
            }
            else
            {
                NativeServer.SendCustomEvent(serverHandle, ReceiverId, Action, IntPtr.Zero, out requestId)
                    .ThrowIfError("Failed to send costom event.");
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
        private readonly IntPtr _searchHandle;

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCommand"/> class.
        /// </summary>
        /// <remarks>User can search maximum 20 items once.</remarks>
        /// <exception cref="ArgumentNullException"><paramref name="conditions"/> is not set.</exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="conditions.Count"/> is greater than maximum value(20).<br/>
        ///     -or-<br/>
        ///     <paramref name="conditions.Count"/> is less than 1.
        /// </exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <param name="conditions">The set of <see cref="MediaControlSearchCondition"/>.</param>
        /// <since_tizen> 5 </since_tizen>
        public SearchCommand(List<MediaControlSearchCondition> conditions)
        {
            if (conditions == null)
            {
                throw new ArgumentNullException(nameof(conditions));
            }
            if (conditions.Count <= 0 || conditions.Count > 20)
            {
                var errMessage = $"Invalid number of search conditions. : {conditions.Count}. " +
                    $"Valid range is 1 ~ 20.";
                throw new ArgumentException(errMessage);
            }

            NativeClient.CreateSearchHandle(out _searchHandle).ThrowIfError("Failed to create search handle.");

            try
            {
                foreach (var condition in conditions)
                {
                    if (condition.Bundle != null)
                    {
                        NativeClient.SetSearchConditionBundle(_searchHandle, condition.ContentType, condition.Category,
                            condition.Keyword, condition.Bundle.SafeBundleHandle).
                            ThrowIfError("Failed to set search condition.");
                    }
                    else
                    {
                        NativeClient.SetSearchCondition(_searchHandle, condition.ContentType, condition.Category,
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
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCommand"/> class.
        /// </summary>
        /// <exception cref="ArgumentNullException"><paramref name="condition"/> is not set.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <param name="condition">The set of <see cref="MediaControlSearchCondition"/>.</param>
        /// <since_tizen> 5 </since_tizen>
        public SearchCommand(MediaControlSearchCondition condition)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            NativeClient.CreateSearchHandle(out _searchHandle).ThrowIfError("Failed to create search handle.");

            try
            {   
                if (condition.Bundle != null)
                {
                    NativeClient.SetSearchConditionBundle(_searchHandle, condition.ContentType, condition.Category,
                        condition.Keyword, condition.Bundle.SafeBundleHandle).
                        ThrowIfError("Failed to set search condition.");
                }
                else
                {
                    NativeClient.SetSearchCondition(_searchHandle, condition.ContentType, condition.Category,
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
                throw;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SearchCommand"/> class by server side.
        /// </summary>
        internal SearchCommand(List<MediaControlSearchCondition> conditions, IntPtr searchHandle)
        {
            _searchHandle = searchHandle;
            Conditions = conditions;
        }

        /// <summary>
        /// Gets or sets the search conditions.
        /// </summary>
        /// <remarks>This property is used by MediaControlServer.</remarks>
        /// <since_tizen> 5 </since_tizen>
        public IEnumerable<MediaControlSearchCondition> Conditions { get; private set; }

        internal override string Request(NativeClientHandle clientHandle)
        {
            NativeClient.SendSearchCommand(clientHandle, ReceiverId, _searchHandle, out string requestId).
                ThrowIfError("Failed to send search command.");

            return requestId;
        }

        /// <summary>
        /// Represents a method that is called when an response command completes.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected override void OnResponseCompleted()
        {
            base.OnResponseCompleted();
        }
    }
}
