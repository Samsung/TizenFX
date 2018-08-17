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
using Native = Interop.MediaControllerClient;

namespace Tizen.Multimedia.Remoting
{
    public partial class MediaControllerManager
    {
        private Native.ServerUpdatedCallback _serverUpdatedCallback;
        private Native.PlaybackUpdatedCallback _playbackUpdatedCallback;
        private Native.MetadataUpdatedCallback _metadataUpdatedCallback;
        private Native.ShuffleModeUpdatedCallback _shufflemodeUpdatedCallback;
        private Native.RepeatModeUpdatedCallback _repeatmodeUpdatedCallback;
        private Native.CommandCompletedCallback _commandCompletedCallback;

        /// <summary>
        /// Occurs when a server is started.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<MediaControlServerStartedEventArgs> ServerStarted;

        /// <summary>
        /// Occurs when a server is stopped.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<MediaControlServerStoppedEventArgs> ServerStopped;

        private void InitializeEvents()
        {
            RegisterPlaybackUpdatedEvent();
            RegisterServerUpdatedEvent();
            RegisterMetadataUpdatedEvent();
            RegisterShuffleModeUpdatedEvent();
            RegisterRepeatModeUpdatedEvent();
        }

        private void RaiseServerChangedEvent(MediaControllerServerState state, MediaController controller)
        {
            if (controller == null)
            {
                return;
            }

            if (state == MediaControllerServerState.Activated)
            {
                ServerStarted?.Invoke(this, new MediaControlServerStartedEventArgs(controller));
            }
            else
            {
                controller.RaiseStoppedEvent();
                ServerStopped?.Invoke(this, new MediaControlServerStoppedEventArgs(controller.ServerAppId));
            }
        }

        private void RegisterServerUpdatedEvent()
        {
            _serverUpdatedCallback = (serverName, state, _) =>
            {
                RaiseServerChangedEvent(state, HandleServerUpdated(serverName, state));
            };

            Native.SetServerUpdatedCb(Handle, _serverUpdatedCallback).ThrowIfError("Failed to init server changed event.");
        }

        private void RegisterPlaybackUpdatedEvent()
        {
            _playbackUpdatedCallback = (serverName, playback, _) =>
            {
                GetController(serverName)?.RaisePlaybackUpdatedEvent(playback);
            };

            Native.SetPlaybackUpdatedCb(Handle, _playbackUpdatedCallback).ThrowIfError("Failed to init PlaybackUpdated event.");
        }


        private void RegisterMetadataUpdatedEvent()
        {
            _metadataUpdatedCallback = (serverName, metadata, _) =>
            {
                GetController(serverName)?.RaiseMetadataUpdatedEvent(metadata);
            };

            Native.SetMetadataUpdatedCb(Handle, _metadataUpdatedCallback).ThrowIfError("Failed to init MetadataUpdated event.");
        }

        private void RegisterShuffleModeUpdatedEvent()
        {
            _shufflemodeUpdatedCallback = (serverName, shuffleMode, _) =>
            {
                GetController(serverName)?.RaiseShuffleModeUpdatedEvent(shuffleMode);
            };

            Native.SetShuffleModeUpdatedCb(Handle, _shufflemodeUpdatedCallback).
                ThrowIfError("Failed to init ShuffleModeUpdated event.");
        }

        private void RegisterRepeatModeUpdatedEvent()
        {
            _repeatmodeUpdatedCallback = (serverName, repeatMode, _) =>
            {
                GetController(serverName)?.RaiseRepeatModeUpdatedEvent(repeatMode.ToPublic());
            };

            Native.SetRepeatModeUpdatedCb(Handle, _repeatmodeUpdatedCallback).
                ThrowIfError("Failed to init RepeatModeUpdated event.");
        }

        private void RegisterCommandCompletedEvent()
        {
            _commandCompletedCallback = (serverName, requestId, result, bundle, _) =>
            {
                GetController(serverName)?.RaiseCommandCompletedEvent(requestId, result, bundle);
            };

            Native.SetCommandCompletedCb(Handle, _commandCompletedCallback).
                ThrowIfError("Failed to init CommandCompleted event.");
        }
    }
}