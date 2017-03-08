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
using Tizen.Applications;

namespace Tizen.Multimedia.MediaController
{

    /// <summary>
    /// The MediaControllerServer class provides APIs required for media-controller-server.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/mediacontroller.server
    /// </privilege>
    /// <remarks>
    /// The MediaControllerServer APIs provides functions to update media information.
    /// </remarks>
    public class MediaControllerServer : IDisposable
    {
        internal IntPtr _handle = IntPtr.Zero;

        private bool _disposed = false;
        private EventHandler<PlaybackStateCommandEventArgs> _playbackCommand;
        private Interop.MediaControllerServer.PlaybackStateCommandRecievedCallback _playbackCommandCallback;
        private EventHandler<CustomCommandEventArgs> _customCommand;
        private Interop.MediaControllerServer.CustomCommandRecievedCallback _customCommandCallback;

        /// <summary>
        /// The constructor of MediaControllerServer class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the access is denied for media controller client</exception>
        public MediaControllerServer ()
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.Create(out _handle), "Create  server failed");
        }

        ~MediaControllerServer ()
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
            if(!_disposed)
            {
                if(disposing)
                {
                    // To be used if there are any other disposable objects
                }
                if(_handle != IntPtr.Zero)
                {
                    Interop.MediaControllerServer.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// PlaybackStateCommandRecieved event is raised when client send command for playback
        /// </summary>
        public event EventHandler<PlaybackStateCommandEventArgs> PlaybackStateCommand
        {
            add
            {
                if(_playbackCommand == null)
                {
                    RegisterPlaybackCmdRecvEvent();
                }
                _playbackCommand += value;

            }
            remove
            {
                _playbackCommand -= value;
                if(_playbackCommand == null)
                {
                    UnregisterPlaybackCmdRecvEvent();
                }
            }
        }

        /// <summary>
        /// CustomCommandRecieved event is raised when client send customized command
        /// </summary>
        public event EventHandler<CustomCommandEventArgs> CustomCommand
        {
            add
            {
                if(_customCommand == null)
                {
                    RegisterCustomCommandEvent();
                }
                _customCommand += value;

            }
            remove
            {
                _customCommand -= value;
                if(_customCommand == null)
                {
                    UnregisterCustomCommandEvent();
                }
            }
        }

        /// <summary>
        /// Update playback state and playback position</summary>
        /// <param name="playback"> playback state and playback position  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void UpdatePlayback(MediaControllerPlayback playback)
        {
            if (playback == null)
            {
                throw new ArgumentNullException("playback is null");
            }

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetPlaybackState(_handle, playback.State), "Set Playback state failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetPlaybackPosition(_handle, playback.Position), "Set Playback position failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdatePlayback(_handle), "Update Playback failed");
        }

        /// <summary>
        /// Update metadata information </summary>
        /// <param name="metadata"> metadata information  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void UpdateMetadata(MediaControllerMetadata metadata)
        {
            if (metadata == null)
            {
                throw new ArgumentNullException("metadata is null");
            }

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Title, metadata.Title), "Set Title failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Artist, metadata.Artist), "Set Artist failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Album, metadata.Album), "Set Album failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Author, metadata.Author), "Set Author failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Genre, metadata.Genre), "Set Genre failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Duration, metadata.Duration), "Set Duration failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Date, metadata.Date), "Set Date failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Copyright, metadata.Copyright), "Set Copyright failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Description, metadata.Description), "Set Description failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.TrackNumber, metadata.TrackNumber), "Set TrackNumber failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(_handle, MediaControllerAttributes.Picture, metadata.Picture), "Set Picture failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdateMetadata(_handle), "UpdateMetadata Metadata failed");
        }

        /// <summary>
        /// Update shuffle mode </summary>
        /// <param name="mode"> shuffle mode  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void UpdateShuffleMode(MediaControllerShuffleMode mode)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdateShuffleMode(_handle, mode), "Update Shuffle Mode failed");
        }

        /// <summary>
        /// Update repeat mode </summary>
        /// <param name="mode"> repeat mode  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void UpdateRepeatMode(MediaControllerRepeatMode mode)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdateRepeatMode(_handle, mode), "Update Repeat Mode failed");
        }

        /// <summary>
        /// Send reply for command from server to client </summary>
        /// <param name="clientName"> client name to recieve reply  </param>
        /// <param name="result"> result to run command  </param>
        /// <param name="bundleData"> Bundle data  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void SendCustomCommandReply(string clientName, int result, Bundle bundle)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SendCommandReply(_handle, clientName, result, bundle.SafeBundleHandle), "Send reply for command failed");
        }

        private void RegisterPlaybackCmdRecvEvent()
        {
            _playbackCommandCallback = (string clientName, MediaControllerPlaybackState state, IntPtr userData) =>
            {
                PlaybackStateCommandEventArgs eventArgs = new PlaybackStateCommandEventArgs(clientName, state);
                _playbackCommand?.Invoke(this, eventArgs);
            };
            Interop.MediaControllerServer.SetPlaybackStateCmdRecvCb(_handle, _playbackCommandCallback, IntPtr.Zero);
        }

        private void UnregisterPlaybackCmdRecvEvent()
        {
            Interop.MediaControllerServer.UnsetPlaybackStateCmdRecvCb(_handle);
        }

        private void RegisterCustomCommandEvent()
        {
            _customCommandCallback = (string clientName, string command, IntPtr bundle, IntPtr userData) =>
            {
                SafeBundleHandle bundleHandle = new SafeBundleHandle(bundle, true);
                Applications.Bundle _bundle = new Bundle(bundleHandle);
                CustomCommandEventArgs eventArgs = new CustomCommandEventArgs(clientName, command, _bundle);
                _customCommand?.Invoke(this, eventArgs);
            };
            Interop.MediaControllerServer.SetCustomCmdRecvCb(_handle, _customCommandCallback, IntPtr.Zero);
        }

        private void UnregisterCustomCommandEvent()
        {
            Interop.MediaControllerServer.UnsetCustomCmdRecvCb(_handle);
        }
    }
}

