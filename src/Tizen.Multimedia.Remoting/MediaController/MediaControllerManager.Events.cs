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
using Tizen.Applications;
using Native = Interop.MediaControllerClient;
using NativePlaylist = Interop.MediaControllerPlaylist;

namespace Tizen.Multimedia.Remoting
{
    public partial class MediaControllerManager
    {
        // Updated event
        private Native.ServerUpdatedCallback _serverUpdatedCallback;
        private Native.PlaybackUpdatedCallback _playbackUpdatedCallback;
        private NativePlaylist.PlaylistUpdatedCallback _playlistUpdatedCallback;
        private NativePlaylist.MetadataUpdatedCallback _metadataUpdatedCallback;
        private Native.ShuffleModeUpdatedCallback _shufflemodeUpdatedCallback;
        private Native.RepeatModeUpdatedCallback _repeatmodeUpdatedCallback;
        private Native.BoolAttributeUpdatedCallback _subtitleModeUpdatedCallback;
        private Native.BoolAttributeUpdatedCallback _mode360UpdatedCallback;
        private Native.DisplayModeUpdatedCallback _displayModeUpdatedCallback;
        private Native.DisplayRotationUpdatedCallback _displayRotationUpdatedCallback;

        // Capability updated event
        private Native.PlaybackCapabilityUpdatedCallback _playbackCapabilityUpdatedCallback;
        private Native.SimpleCapabilityUpdatedCallback _categoryCapabilityUpdatedCallback;
        private Native.CategoryAttributeCapabilityUpdatedCallback _displayModeCapabilityUpdatedCallback;
        private Native.CategoryAttributeCapabilityUpdatedCallback _displayRotationCapabilityUpdatedCallback;

        // Command
        private Native.CommandCompletedCallback _commandCompletedCallback;
        private Native.CustomCommandReceivedCallback _customEventReceivedCallback;


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
            RegisterPlaylistUpdatedEvent();
            RegisterSubtitleModeUpdateEvent();
            RegisterMode360UpdateEvent();
            RegisterDisplayModeUpdateEvent();
            RegisterDisplayRotationUpdateEvent();

            RegisterPlaybackCapabilitiesEvent();
            RegisterDisplayModeCapabilityUpdatedEvent();
            RegisterDisplayRotationCapabilityUpdatedEvent();
            RegisterSimpleCapabilityUpdatedEvent();

            RegisterCommandCompletedEvent();
            RegisterCustomCommandReceivedEvent();
        }

        private void RaiseServerChangedEvent(MediaControllerNativeServerState state, MediaController controller)
        {
            if (controller == null)
            {
                return;
            }

            if (state == MediaControllerNativeServerState.Activated)
            {
                ServerStarted?.Invoke(this, new MediaControlServerStartedEventArgs(controller));
            }
            else
            {
                controller.RaiseStoppedEvent();
                ServerStopped?.Invoke(this, new MediaControlServerStoppedEventArgs(controller.ServerAppId));
            }
        }


        #region Updated event
        private void RegisterServerUpdatedEvent()
        {
            _serverUpdatedCallback = (serverName, state, _) =>
            {
                RaiseServerChangedEvent(state, HandleServerUpdated(serverName, state));
            };

            Native.SetServerUpdatedCb(Handle, _serverUpdatedCallback).
                ThrowIfError("Failed to register server changed event.");
        }

        private void RegisterPlaybackUpdatedEvent()
        {
            _playbackUpdatedCallback = (serverName, playbackHandle, _) =>
            {
                GetController(serverName)?.RaisePlaybackUpdatedEvent(playbackHandle);
            };

            Native.SetPlaybackUpdatedCb(Handle, _playbackUpdatedCallback).
                ThrowIfError("Failed to register PlaybackUpdated event.");
        }

        private void RegisterPlaylistUpdatedEvent()
        {
            _playlistUpdatedCallback = (serverName, playlistMode, name, playlistHandle, _) =>
            {
                GetController(serverName)?.RaisePlaylistUpdatedEvent(playlistMode, name, playlistHandle);
            };

            NativePlaylist.SetPlaylistModeUpdatedCb(Handle, _playlistUpdatedCallback).
                ThrowIfError("Failed to register PlaylistUpdated event.");
        }

        private void RegisterMetadataUpdatedEvent()
        {
            _metadataUpdatedCallback = (serverName, metadata, _) =>
            {
                GetController(serverName)?.RaiseMetadataUpdatedEvent(metadata);
            };

            NativePlaylist.SetMetadataUpdatedCb(Handle, _metadataUpdatedCallback).
                ThrowIfError("Failed to register MetadataUpdated event.");
        }

        private void RegisterShuffleModeUpdatedEvent()
        {
            _shufflemodeUpdatedCallback = (serverName, shuffleMode, _) =>
            {
                GetController(serverName)?.RaiseShuffleModeUpdatedEvent(shuffleMode);
            };

            Native.SetShuffleModeUpdatedCb(Handle, _shufflemodeUpdatedCallback).
                ThrowIfError("Failed to register ShuffleModeUpdated event.");
        }

        private void RegisterRepeatModeUpdatedEvent()
        {
            _repeatmodeUpdatedCallback = (serverName, repeatMode, _) =>
            {
                GetController(serverName)?.RaiseRepeatModeUpdatedEvent(repeatMode.ToPublic());
            };

            Native.SetRepeatModeUpdatedCb(Handle, _repeatmodeUpdatedCallback).
                ThrowIfError("Failed to register RepeatModeUpdated event.");
        }

        private void RegisterSubtitleModeUpdateEvent()
        {
            _subtitleModeUpdatedCallback = (serverName, isEnabled, _) =>
            {
                GetController(serverName)?.RaiseSubtitleModeUpdatedEvent(isEnabled);
            };

            Native.SetSubtitleUpdatedCb(Handle, _subtitleModeUpdatedCallback).
                ThrowIfError("Failed to register SubtitleModeUpdated event.");
        }

        private void RegisterMode360UpdateEvent()
        {
            _mode360UpdatedCallback = (serverName, isEnabled, _) =>
            {
                GetController(serverName)?.RaiseMode360UpdatedEvent(isEnabled);
            };

            Native.SetMode360UpdatedCb(Handle, _mode360UpdatedCallback).
                ThrowIfError("Failed to register Mode360Updated event.");
        }

        private void RegisterDisplayModeUpdateEvent()
        {
            _displayModeUpdatedCallback = (serverName, mode, _) =>
            {
                GetController(serverName)?.RaiseDisplayModeUpdatedEvent(mode);
            };

            Native.SetDisplayModeUpdatedCb(Handle, _displayModeUpdatedCallback).
                ThrowIfError("Failed to register DisplayModeUpdated event.");
        }

        private void RegisterDisplayRotationUpdateEvent()
        {
            _displayRotationUpdatedCallback = (serverName, rotation, _) =>
            {
                GetController(serverName)?.RaiseDisplayRotationUpdatedEvent(rotation);
            };

            Native.SetDisplayRotationUpdatedCb(Handle, _displayRotationUpdatedCallback).
                ThrowIfError("Failed to register DisplayRotationUpdated event.");
        }
        #endregion


        #region Command
        private void RegisterCommandCompletedEvent()
        {
            _commandCompletedCallback = (serverName, requestId, result, bundleHandle, _) =>
            {
                // SafeHandles cannot be marshaled from unmanaged to managed.
                // So we use IntPtr type for 'bundleHandle' in native callback.
                GetController(serverName)?.RaiseCommandCompletedEvent(requestId, result, bundleHandle);
            };

            Native.SetCommandCompletedCb(Handle, _commandCompletedCallback).
                ThrowIfError("Failed to register CommandCompleted event.");
        }

        private void RegisterCustomCommandReceivedEvent()
        {
            _customEventReceivedCallback = (serverName, requestId, customEvent, bundleHandle, _) =>
            {
                CustomCommand command = null;
                if (bundleHandle != IntPtr.Zero)
                {
                    command = new CustomCommand(customEvent, new Bundle(new SafeBundleHandle(bundleHandle, true)));
                }
                else
                {
                    command = new CustomCommand(customEvent);
                }

                command.SetResponseInformation(serverName, requestId);

                GetController(serverName)?.RaiseCustomCommandReceivedEvent(command);
            };

            Native.SetCustomEventCb(Handle, _customEventReceivedCallback).
                ThrowIfError("Failed to register CustomCommandReceived event.");
        }
        #endregion


        #region Capability updated event
        private void RegisterPlaybackCapabilitiesEvent()
        {
            _playbackCapabilityUpdatedCallback = (serverName, playbackCapaHandle, _) =>
            {
                GetController(serverName)?.RaisePlaybackCapabilityUpdatedEvent(playbackCapaHandle);
            };

            Native.SetPlaybackCapabilityUpdatedCb(Handle, _playbackCapabilityUpdatedCallback).
                ThrowIfError("Failed to register PlaybackCapabilityUpdated event.");
        }

        private void RegisterDisplayModeCapabilityUpdatedEvent()
        {
            _displayModeCapabilityUpdatedCallback = (serverName, modes, _) =>
            {
                GetController(serverName)?.RaiseDisplayModeCapabilityUpdatedEvent(
                    (MediaControlNativeDisplayMode)modes);
            };

            Native.SetDisplayModeCapabilityUpdatedCb(Handle, _displayModeCapabilityUpdatedCallback).
                ThrowIfError("Failed to register DisplayModeCapabilityUpdated event.");
        }

        private void RegisterDisplayRotationCapabilityUpdatedEvent()
        {
            _displayRotationCapabilityUpdatedCallback = (serverName, rotations, _) =>
            {
                GetController(serverName)?.RaiseDisplayRotationCapabilityUpdatedEvent(
                    (MediaControlNativeDisplayRotation)rotations);
            };

            Native.SetDisplayRotationCapabilityUpdatedCb(Handle, _displayRotationCapabilityUpdatedCallback).
                ThrowIfError("Failed to register DisplayRotationCapabilityUpdated event.");
        }

        private void RegisterSimpleCapabilityUpdatedEvent()
        {
            _categoryCapabilityUpdatedCallback = (serverName, category, support, _) =>
            {
                switch (category)
                {
                    case MediaControlNativeCapabilityCategory.Repeat:
                        GetController(serverName)?.RaiseRepeatModeCapabilityUpdatedEvent(support);
                        break;
                    case MediaControlNativeCapabilityCategory.Shuffle:
                        GetController(serverName)?.RaiseShuffleModeCapabilityUpdatedEvent(support);
                        break;
                }
            };

            Native.SetCategoryCapabilityUpdatedCb(Handle, _categoryCapabilityUpdatedCallback).
                ThrowIfError("Failed to register capability updated event.");
        }
        #endregion
    }
}