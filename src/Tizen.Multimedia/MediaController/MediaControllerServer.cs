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
using System.Runtime.InteropServices;
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
                    throw new ObjectDisposedException(nameof(MediaControllerServer), "Fail to operate MediaControllerServer");
                }

                return _handle;
            }
        }

        /// <summary>
        /// The constructor of MediaControllerServer class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the access is denied for media controller client</exception>
        public MediaControllerServer()
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.Create(out _handle), "Create  server failed");
        }

        ~MediaControllerServer()
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
                if (_playbackCommand == null)
                {
                    RegisterPlaybackCmdRecvEvent();
                }

                _playbackCommand += value;

            }

            remove
            {
                _playbackCommand -= value;
                if (_playbackCommand == null)
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
                if (_customCommand == null)
                {
                    RegisterCustomCommandEvent();
                }

                _customCommand += value;

            }

            remove
            {
                _customCommand -= value;
                if (_customCommand == null)
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
                Interop.MediaControllerServer.SetPlaybackState(SafeHandle, playback.State), "Set Playback state failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetPlaybackPosition(SafeHandle, playback.Position), "Set Playback position failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdatePlayback(SafeHandle), "Update Playback failed");
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
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Title, metadata.Title), "Set Title failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Artist, metadata.Artist), "Set Artist failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Album, metadata.Album), "Set Album failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Author, metadata.Author), "Set Author failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Genre, metadata.Genre), "Set Genre failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Duration, metadata.Duration), "Set Duration failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Date, metadata.Date), "Set Date failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Copyright, metadata.Copyright), "Set Copyright failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Description, metadata.Description), "Set Description failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.TrackNumber, metadata.TrackNumber), "Set TrackNumber failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SetMetadata(SafeHandle, MediaControllerAttributes.Picture, metadata.Picture), "Set Picture failed");

            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdateMetadata(SafeHandle), "UpdateMetadata Metadata failed");
        }

        /// <summary>
        /// Update shuffle mode </summary>
        /// <param name="mode"> shuffle mode  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void UpdateShuffleMode(MediaControllerShuffleMode mode)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdateShuffleMode(SafeHandle, mode), "Update Shuffle Mode failed");
        }

        /// <summary>
        /// Update repeat mode </summary>
        /// <param name="mode"> repeat mode  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void UpdateRepeatMode(MediaControllerRepeatMode mode)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.UpdateRepeatMode(SafeHandle, mode), "Update Repeat Mode failed");
        }

        /// <summary>
        /// Send reply for command from server to client </summary>
        /// <param name="clientName"> client name to recieve reply  </param>
        /// <param name="result"> result to run command  </param>
        /// <param name="bundle"> Bundle to send various data  </param>
        /// <exception cref="ArgumentException">Thrown when an invalid argument is used</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid for the current state</exception>
        public void SendCustomCommandReply(string clientName, int result, Bundle bundle)
        {
            MediaControllerValidator.ThrowIfError(
                Interop.MediaControllerServer.SendCommandReply(SafeHandle, clientName, result, bundle.SafeBundleHandle), "Send reply for command failed");
        }

        private void RegisterPlaybackCmdRecvEvent()
        {
            _playbackCommandCallback = (IntPtr clientName, MediaControllerPlaybackState state, IntPtr userData) =>
            {
                PlaybackStateCommandEventArgs eventArgs = new PlaybackStateCommandEventArgs(Marshal.PtrToStringAnsi(clientName), state);
                _playbackCommand?.Invoke(this, eventArgs);
            };
            Interop.MediaControllerServer.SetPlaybackStateCmdRecvCb(SafeHandle, _playbackCommandCallback, IntPtr.Zero);
        }

        private void UnregisterPlaybackCmdRecvEvent()
        {
            Interop.MediaControllerServer.UnsetPlaybackStateCmdRecvCb(SafeHandle);
        }

        private void RegisterCustomCommandEvent()
        {
            _customCommandCallback = (IntPtr clientName, IntPtr command, IntPtr bundle, IntPtr userData) =>
            {
                SafeBundleHandle safeBundleHandle = new SafeBundleHandle(bundle, true);
                Bundle bundleData = new Bundle(safeBundleHandle);
                CustomCommandEventArgs eventArgs = new CustomCommandEventArgs(Marshal.PtrToStringAnsi(clientName), Marshal.PtrToStringAnsi(command), bundleData);
                _customCommand?.Invoke(this, eventArgs);
        };
            Interop.MediaControllerServer.SetCustomCmdRecvCb(SafeHandle, _customCommandCallback, IntPtr.Zero);
        }

        private void UnregisterCustomCommandEvent()
        {
            Interop.MediaControllerServer.UnsetCustomCmdRecvCb(SafeHandle);
        }
    }
}

