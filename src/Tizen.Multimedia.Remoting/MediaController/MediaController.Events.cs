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
    }
}