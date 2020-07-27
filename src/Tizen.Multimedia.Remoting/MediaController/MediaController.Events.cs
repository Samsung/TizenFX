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
using System.Linq;
using System.Collections.Generic;
using Tizen.Applications;
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides a means to to send commands to and handle events from media control server.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public partial class MediaController
    {
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

        #region Updated event
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

                return new PlaybackStateUpdatedEventArgs(playbackCode.ToPublic(), (long)position);
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
        /// Occurs when the playlist is updated.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<PlaylistUpdatedEventArgs> PlaylistUpdated;

        internal void RaisePlaylistUpdatedEvent(MediaControlPlaylistMode mode, string name, IntPtr playlistHandle)
        {
            PlaylistUpdated?.Invoke(this, new PlaylistUpdatedEventArgs(mode, name, new MediaControlPlaylist(playlistHandle)));
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

        internal void RaiseShuffleModeUpdatedEvent(MediaControllerNativeShuffleMode mode)
        {
            ShuffleModeUpdated?.Invoke(this, new ShuffleModeUpdatedEventArgs(mode == MediaControllerNativeShuffleMode.On));
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
        /// Occurs when the subtitle mode is updated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<SubtitleModeUpdatedEventArgs> SubtitleModeUpdated;
        internal void RaiseSubtitleModeUpdatedEvent(bool isEnabled)
        {
            SubtitleModeUpdated?.Invoke(this, new SubtitleModeUpdatedEventArgs(isEnabled));
        }

        /// <summary>
        /// Occurs when the 360 mode is updated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<Mode360UpdatedEventArgs> Mode360Updated;
        internal void RaiseMode360UpdatedEvent(bool isEnabled)
        {
            Mode360Updated?.Invoke(this, new Mode360UpdatedEventArgs(isEnabled));
        }

        /// <summary>
        /// Occurs when the display mode is updated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<DisplayModeUpdatedEventArgs> DisplayModeUpdated;
        internal void RaiseDisplayModeUpdatedEvent(MediaControlNativeDisplayMode mode)
        {
            DisplayModeUpdated?.Invoke(this, new DisplayModeUpdatedEventArgs(mode.ToPublic()));
        }

        /// <summary>
        /// Occurs when the display rotation is updated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<DisplayRotationUpdatedEventArgs> DisplayRotationUpdated;
        internal void RaiseDisplayRotationUpdatedEvent(MediaControlNativeDisplayRotation rotation)
        {
            DisplayRotationUpdated?.Invoke(this, new DisplayRotationUpdatedEventArgs(rotation.ToPublic()));
        }
        #endregion


        #region Capability updated event
        /// <summary>
        /// Occurs when the playback capabilities are updated.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<PlaybackCapabilityUpdatedEventArgs> PlaybackCapabilityUpdated;

        private PlaybackCapabilityUpdatedEventArgs CreatePlaybackCapabilityUpdatedEventArgs(IntPtr playbackCapaHandle)
        {
            var capabilities = new Dictionary<MediaControlPlaybackCommand, MediaControlCapabilitySupport>();
            try
            {
                foreach (MediaControllerNativePlaybackAction action in Enum.GetValues(typeof(MediaControllerNativePlaybackAction)))
                {
                    Native.GetPlaybackCapability(playbackCapaHandle, action, out MediaControlCapabilitySupport support);
                    capabilities.Add(action.ToPublic(), support);
                }

                return new PlaybackCapabilityUpdatedEventArgs(capabilities);
            }
            catch (Exception e)
            {
                Log.Error(GetType().FullName, e.ToString());
            }
            return null;
        }

        internal void RaisePlaybackCapabilityUpdatedEvent(IntPtr playbackCapaHandle)
        {
            var eventHandler = PlaybackCapabilityUpdated;

            if (eventHandler == null)
            {
                return;
            }

            var args = CreatePlaybackCapabilityUpdatedEventArgs(playbackCapaHandle);

            if (args != null)
            {
                eventHandler.Invoke(this, args);
            }
        }

        /// <summary>
        /// Occurs when the repeat mode capabilities are updated.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<RepeatModeCapabilityUpdatedEventArgs> RepeatModeCapabilityUpdated;

        internal void RaiseRepeatModeCapabilityUpdatedEvent(MediaControlCapabilitySupport support)
        {
            RepeatModeCapabilityUpdated?.Invoke(this, new RepeatModeCapabilityUpdatedEventArgs(support));
        }

        /// <summary>
        /// Occurs when the shuffle mode capabilities are updated.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<ShuffleModeCapabilityUpdatedEventArgs> ShuffleModeCapabilityUpdated;

        internal void RaiseShuffleModeCapabilityUpdatedEvent(MediaControlCapabilitySupport support)
        {
            ShuffleModeCapabilityUpdated?.Invoke(this, new ShuffleModeCapabilityUpdatedEventArgs(support));
        }

        /// <summary>
        /// Occurs when the display mode capabilities are updated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<DisplayModeCapabilityUpdatedEventArgs> DisplayModeCapabilityUpdated;

        internal void RaiseDisplayModeCapabilityUpdatedEvent(MediaControlNativeDisplayMode modes)
        {
            DisplayModeCapabilityUpdated?.Invoke(this, new DisplayModeCapabilityUpdatedEventArgs(modes.ToPublicList()));
        }

        /// <summary>
        /// Occurs when the display rotation capabilities are updated.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<DisplayRotationCapabilityUpdatedEventArgs> DisplayRotationCapabilityUpdated;

        internal void RaiseDisplayRotationCapabilityUpdatedEvent(MediaControlNativeDisplayRotation rotations)
        {
            DisplayRotationCapabilityUpdated?.Invoke(this, new DisplayRotationCapabilityUpdatedEventArgs(rotations.ToPublicList()));
        }
        #endregion


        #region Command
        /// <summary>
        /// Occurs when the command is completed.
        /// </summary>
        /// <remarks>
        /// User can match the command and this event using <see cref="CommandCompletedEventArgs.RequestId"/> field.
        /// </remarks>
        /// <since_tizen> 5 </since_tizen>
        internal event EventHandler<CommandCompletedEventArgs> CommandCompleted;

        internal void RaiseCommandCompletedEvent(string requestId, int result, IntPtr bundleHandle)
        {
            if (bundleHandle != IntPtr.Zero)
            {
                CommandCompleted?.Invoke(this, new CommandCompletedEventArgs(requestId, result, new Bundle(new SafeBundleHandle(bundleHandle, true))));
            }
            else
            {
                CommandCompleted?.Invoke(this, new CommandCompletedEventArgs(requestId, result));
            }
        }

        /// <summary>
        /// Occurs when a server sends custom event.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public event EventHandler<CustomCommandReceivedEventArgs> CustomCommandReceived;

        internal void RaiseCustomCommandReceivedEvent(CustomCommand command)
        {
            CustomCommandReceived?.Invoke(this, new CustomCommandReceivedEventArgs(command));
        }
        #endregion
    }
}