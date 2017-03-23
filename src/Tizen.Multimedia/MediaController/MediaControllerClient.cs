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
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Tizen.Applications;

namespace Tizen.Multimedia.MediaController
{

    /// <summary>
    /// The MediaControllerClient class provides APIs required for media-controller-client.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/mediacontroller.client
    /// </privilege>
    /// <remarks>
    /// The MediaControllerClient APIs provides functions to get media information from server.
    /// </remarks>
    public class MediaControllerClient : IDisposable
    {
        internal IntPtr _handle = IntPtr.Zero;

        private bool _disposed = false;
        private EventHandler<ServerUpdatedEventArgs> _serverUpdated;
        private Interop.MediaControllerClient.ServerUpdatedCallback _serverUpdatedCallback;
        private EventHandler<PlaybackUpdatedEventArgs> _playbackUpdated;
        private Interop.MediaControllerClient.PlaybackUpdatedCallback _playbackUpdatedCallback;
        private EventHandler<MetadataUpdatedEventArgs> _metadataUpdated;
        private Interop.MediaControllerClient.MetadataUpdatedCallback _metadataUpdatedCallback;
        private EventHandler<ShuffleModeUpdatedEventArgs> _shufflemodeUpdated;
        private Interop.MediaControllerClient.ShuffleModeUpdatedCallback _shufflemodeUpdatedCallback;
        private EventHandler<RepeatModeUpdatedEventArgs> _repeatmodeUpdated;
        private Interop.MediaControllerClient.RepeatModeUpdatedCallback _repeatmodeUpdatedCallback;
        private EventHandler<CustomCommandReplyEventArgs> _customcommandReply;
        private Interop.MediaControllerClient.CommandReplyRecievedCallback _customcommandReplyCallback;

        private bool IsValidHandle
        {
            get { return (_handle != IntPtr.Zero); }
        }

        private IntPtr SafeHandle
        {
            get
            {
                if (!IsValidHandle)
                {
                    throw new ObjectDisposedException(nameof(MediaControllerClient), "Fail to operate MediaControllerClient");
                }

                return _handle;
            }
        }

        /// <summary>
        /// The constructor of MediaControllerClient class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the access is denied for media controller client</exception>
        public MediaControllerClient()
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.Create(out _handle), "Create client failed");
        }

        ~MediaControllerClient()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // To be used if there are any other disposable objects
                }

                if (IsValidHandle)
                {
                    Interop.MediaControllerClient.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// ServerUpdated event is raised when server is changed
        /// </summary>
        public event EventHandler<ServerUpdatedEventArgs> ServerUpdated
        {
            add
            {
                if (_serverUpdated == null)
                {
                    RegisterServerUpdatedEvent();
                }

                _serverUpdated += value;

            }

            remove
            {
                _serverUpdated -= value;
                if (_serverUpdated == null)
                {
                    UnregisterServerUpdatedEvent();
                }
            }
        }

        /// <summary>
        /// PlaybackUpdated event is raised when playback is changed
        /// </summary>
        public event EventHandler<PlaybackUpdatedEventArgs> PlaybackUpdated
        {
            add
            {
                if (_playbackUpdated == null)
                {
                    RegisterPlaybackUpdatedEvent();
                }

                _playbackUpdated += value;

            }

            remove
            {
                _playbackUpdated -= value;
                if (_playbackUpdated == null)
                {
                    UnregisterPlaybackUpdatedEvent();
                }
            }
        }

        /// <summary>
        /// MetadataUpdated event is raised when metadata is changed
        /// </summary>
        public event EventHandler<MetadataUpdatedEventArgs> MetadataUpdated
        {
            add
            {
                if (_metadataUpdated == null)
                {
                    RegisterMetadataUpdatedEvent();
                }

                _metadataUpdated += value;

            }

            remove
            {
                _metadataUpdated -= value;
                if (_metadataUpdated == null)
                {
                    UnregisterMetadataUpdatedEvent();
                }
            }
        }

        /// <summary>
        /// ShuffleModeUpdated event is raised when shuffle mode is changed
        /// </summary>
        public event EventHandler<ShuffleModeUpdatedEventArgs> ShuffleModeUpdated
        {
            add
            {
                if (_shufflemodeUpdated == null)
                {
                    RegisterShuffleModeUpdatedEvent();
                }

                _shufflemodeUpdated += value;

            }

            remove
            {
                _shufflemodeUpdated -= value;
                if (_shufflemodeUpdated == null)
                {
                    UnregisterShuffleModeUpdatedEvent();
                }
            }
        }

        /// <summary>
        /// RepeatModeUpdated event is raised when server is changed
        /// </summary>
        public event EventHandler<RepeatModeUpdatedEventArgs> RepeatModeUpdated
        {
            add
            {
                if (_repeatmodeUpdated == null)
                {
                    RegisterRepeatModeUpdatedEvent();
                }

                _repeatmodeUpdated += value;
            }

            remove
            {
                _repeatmodeUpdated -= value;
                if (_repeatmodeUpdated == null)
                {
                    UnregisterRepeatModeUpdatedEvent();
                }
            }
        }

        /// <summary>
        /// CommandReply event is raised when reply for command is recieved
        /// </summary>
        public event EventHandler<CustomCommandReplyEventArgs> CustomCommandReply
        {
            add
            {
                if (_customcommandReply == null)
                {
                    _customcommandReplyCallback = (IntPtr serverName, int result, IntPtr bundle, IntPtr userData) =>
                    {
                        SafeBundleHandle safeBundleHandle = new SafeBundleHandle(bundle, true);
                        Bundle bundleData = new Bundle(safeBundleHandle);
                        CustomCommandReplyEventArgs eventArgs = new CustomCommandReplyEventArgs(Marshal.PtrToStringAnsi(serverName), result, bundleData);
                        _customcommandReply?.Invoke(this, eventArgs);
                    };
                }

                _customcommandReply += value;

            }

            remove
            {
                _customcommandReply -= value;
                if (_customcommandReply == null)
                {
                    _customcommandReplyCallback = null;
                }
            }
        }

        /// <summary>
        /// gets latest server information </summary>
        /// <returns>The name and state of the latest media controller server application: ServerInformation object</returns>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public ServerInformation GetLatestServer()
        {
            IntPtr name = IntPtr.Zero;
            MediaControllerServerState state = MediaControllerServerState.None;

            try
            {
                MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetLatestServer(SafeHandle, out name, out state), "Get Latest server failed");
                return new ServerInformation(Marshal.PtrToStringAnsi(name), (MediaControllerServerState)state);
            }
            finally
            {
                Interop.Libc.Free(name);
            }
        }

        /// <summary>
        /// gets playback information for specific server </summary>
        /// <param name="serverName"> Server Name  </param>
        /// <returns>The playback state and playback position of the specific media controller server application:MediaControllerPlayback object</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public MediaControllerPlayback GetPlayback(string serverName)
        {
            IntPtr playbackHandle = IntPtr.Zero;
            MediaControllerPlayback playback = null;

            try
            {
                MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetServerPlayback(SafeHandle, serverName, out playbackHandle), "Get Playback handle failed");
                playback = new MediaControllerPlayback(playbackHandle);
            }
            finally
            {
                if (playbackHandle != IntPtr.Zero)
                {
                    MediaControllerValidator.ThrowIfError(
                        Interop.MediaControllerClient.DestroyPlayback(playbackHandle), "Destroy playback failed");
                }
            }

            return playback;
        }

        /// <summary>
        /// gets metadata information for specific server </summary>
        /// <param name="serverName"> Server Name  </param>
        /// <returns>The metadata information of the specific media controller server application:MediaControllerMetadata object</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public MediaControllerMetadata GetMetadata(string serverName)
        {
            IntPtr metadataHandle = IntPtr.Zero;
            MediaControllerMetadata metadata = null;

            try
            {
                MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.GetServerMetadata(SafeHandle, serverName, out metadataHandle), "Get Metadata handle failed");
                metadata = new MediaControllerMetadata(metadataHandle);
            }
            finally
            {
                if (metadataHandle != IntPtr.Zero)
                {
                    MediaControllerValidator.ThrowIfError(
                    Interop.MediaControllerClient.DestroyMetadata(metadataHandle), "Destroy metadata failed");
                }
            }

            return metadata;
        }

        /// <summary>
        /// gets shuffle mode for specific server </summary>
        /// <param name="serverName"> Server Name  </param>
        /// <returns>The shuffle mode of the specific media controller server application:MediaControllerShuffleMode enum</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public MediaControllerShuffleMode GetShuffleMode(string serverName)
        {
            MediaControllerShuffleMode shuffleMode = MediaControllerShuffleMode.Off;

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.GetServerShuffleMode(SafeHandle, serverName, out shuffleMode), "Get ShuffleMode failed");

            return shuffleMode;
        }

        /// <summary>
        /// gets repeat mode for specific server </summary>
        /// <param name="serverName"> Server Name  </param>
        /// <returns>The repeat mode of the specific media controller server application:MediaControllerRepeatMode enum</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public MediaControllerRepeatMode GetRepeatMode(string serverName)
        {
            MediaControllerRepeatMode repeatMode = MediaControllerRepeatMode.Off;

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.GetServerRepeatMode(SafeHandle, serverName, out repeatMode), "Get RepeatMode failed");

            return repeatMode;
        }

        /// <summary>
        /// Send command of playback state to server application </summary>
        /// <param name="serverName"> Server Name  </param>
        /// <param name="state"> Playback State  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void SendPlaybackStateCommand(string serverName, MediaControllerPlaybackState state)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.SendPlaybackStateCommand(SafeHandle, serverName, state), "Send playback state command failed");
        }

        /// <summary>
        /// Send customized command to server application </summary>
        /// <param name="serverName"> Server Name  </param>
        /// <param name="command"> Command  </param>
        /// <param name="bundle"> Bundle data  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void SendCustomCommand(string serverName, string command, Bundle bundle)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.SendCustomCommand(SafeHandle, serverName, command, bundle.SafeBundleHandle, _customcommandReplyCallback, IntPtr.Zero),
                "Send custom command failed");
        }

        /// <summary>
        /// Subscribe subscription type from specific server application </summary>
        /// <param name="type"> Subscription Type  </param>
        /// <param name="serverName"> Server Name  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        public void Subscribe(MediaControllerSubscriptionType type, string serverName)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.Subscribe(SafeHandle, type, serverName), "Subscribe failed");
        }

        /// <summary>
        /// Subscribe subscription type from specific server application </summary>
        /// <param name="type"> Subscription Type  </param>
        /// <param name="serverName"> Server Name  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        public void Unsubscribe(MediaControllerSubscriptionType type, string serverName)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.Unsubscribe(SafeHandle, type, serverName), "Unsubscribe failed");
        }

        /// <summary>
        /// gets activated server list </summary>
        /// <returns>The list of activated media controller server applications: IEnumerable of string</returns>
        public Task<IEnumerable<string>> GetActivatedServerList()
        {
            var task = new TaskCompletionSource<IEnumerable<string>>();

            List<string> collectionList = ForEachActivatedServer(SafeHandle);
            task.TrySetResult((IEnumerable<string>)collectionList);

            return task.Task;
        }

        /// <summary>
        /// gets subscribed server list </summary>
        /// <param name="subscriptionType"> Subscription Type  </param>
        /// <returns>The list of subscribed media controller server applications: IEnumerable of string</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public Task<IEnumerable<string>> GetSubscribedServerList(MediaControllerSubscriptionType subscriptionType)
        {
            var task = new TaskCompletionSource<IEnumerable<string>>();

            List<string> collectionList = ForEachSubscribedServer(SafeHandle, subscriptionType);
            task.TrySetResult((IEnumerable<string>)collectionList);

            return task.Task;
        }

        private void RegisterServerUpdatedEvent()
        {
            _serverUpdatedCallback = (IntPtr serverName, MediaControllerServerState serverState, IntPtr userData) =>
            {
                ServerUpdatedEventArgs eventArgs = new ServerUpdatedEventArgs(Marshal.PtrToStringAnsi(serverName), serverState);
                _serverUpdated?.Invoke(this, eventArgs);
            };
            Interop.MediaControllerClient.SetServerUpdatedCb(SafeHandle, _serverUpdatedCallback, IntPtr.Zero);
        }

        private void UnregisterServerUpdatedEvent()
        {
            Interop.MediaControllerClient.UnsetServerUpdatedCb(SafeHandle);
        }

        private void RegisterPlaybackUpdatedEvent()
        {
            _playbackUpdatedCallback = (IntPtr serverName, IntPtr playback, IntPtr userData) =>
            {
                PlaybackUpdatedEventArgs eventArgs = new PlaybackUpdatedEventArgs(Marshal.PtrToStringAnsi(serverName), playback);
                _playbackUpdated?.Invoke(this, eventArgs);
            };
            Interop.MediaControllerClient.SetPlaybackUpdatedCb(SafeHandle, _playbackUpdatedCallback, IntPtr.Zero);
        }

        private void UnregisterPlaybackUpdatedEvent()
        {
            Interop.MediaControllerClient.UnsetPlaybackUpdatedCb(SafeHandle);
        }

        private void RegisterMetadataUpdatedEvent()
        {
            _metadataUpdatedCallback = (IntPtr serverName, IntPtr metadata, IntPtr userData) =>
            {
                MetadataUpdatedEventArgs eventArgs = new MetadataUpdatedEventArgs(Marshal.PtrToStringAnsi(serverName), metadata);
                _metadataUpdated?.Invoke(this, eventArgs);
            };
            Interop.MediaControllerClient.SetMetadataUpdatedCb(SafeHandle, _metadataUpdatedCallback, IntPtr.Zero);
        }

        private void UnregisterMetadataUpdatedEvent()
        {
            Interop.MediaControllerClient.UnsetMetadataUpdatedCb(SafeHandle);
        }

        private void RegisterShuffleModeUpdatedEvent()
        {
            _shufflemodeUpdatedCallback = (IntPtr serverName, MediaControllerShuffleMode shuffleMode, IntPtr userData) =>
            {
                ShuffleModeUpdatedEventArgs eventArgs = new ShuffleModeUpdatedEventArgs(Marshal.PtrToStringAnsi(serverName), shuffleMode);
                _shufflemodeUpdated?.Invoke(this, eventArgs);
            };

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.SetShuffleModeUpdatedCb(SafeHandle, _shufflemodeUpdatedCallback, IntPtr.Zero),
                "Set ShuffleModeUpdated callback failed");
        }

        private void UnregisterShuffleModeUpdatedEvent()
        {
            Interop.MediaControllerClient.UnsetShuffleModeUpdatedCb(SafeHandle);
        }

        private void RegisterRepeatModeUpdatedEvent()
        {
            _repeatmodeUpdatedCallback = (IntPtr serverName, MediaControllerRepeatMode repeatMode, IntPtr userData) =>
            {
                RepeatModeUpdatedEventArgs eventArgs = new RepeatModeUpdatedEventArgs(Marshal.PtrToStringAnsi(serverName), repeatMode);
                _repeatmodeUpdated?.Invoke(this, eventArgs);
            };

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.SetRepeatModeUpdatedCb(SafeHandle, _repeatmodeUpdatedCallback, IntPtr.Zero),
                "Set RepeatModeUpdated callback failed");
        }

        private void UnregisterRepeatModeUpdatedEvent()
        {
            Interop.MediaControllerClient.UnsetRepeatModeUpdatedCb(SafeHandle);
        }

        private static List<string> ForEachSubscribedServer(IntPtr handle, MediaControllerSubscriptionType subscriptionType)
        {
            List<string> subscribedServerCollections = new List<string>();

            Interop.MediaControllerClient.SubscribedServerCallback serverCallback = (IntPtr serverName, IntPtr userData) =>
            {
                subscribedServerCollections.Add(Marshal.PtrToStringAnsi(serverName));
                return true;
            };

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.ForeachSubscribedServer(handle, subscriptionType, serverCallback, IntPtr.Zero),
                "Foreach Subscribed server failed");

            return subscribedServerCollections;
        }

        private static List<string> ForEachActivatedServer(IntPtr handle)
        {
            List<string> activatedServerCollections = new List<string>();

            Interop.MediaControllerClient.ActivatedServerCallback serverCallback = (IntPtr serverName, IntPtr userData) =>
            {
                activatedServerCollections.Add(Marshal.PtrToStringAnsi(serverName));
                return true;
            };

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerClient.ForeachActivatedServer(handle, serverCallback, IntPtr.Zero),
                "Foreach Activated server failed");

            return activatedServerCollections;
        }
    }
}

