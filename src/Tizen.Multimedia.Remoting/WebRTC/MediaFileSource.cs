/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Diagnostics;
using NativeWebRTC = Interop.NativeWebRTC;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Represents a media source that reads media data from a file.
    /// </summary>
    /// <remarks>
    /// Depending on where the source file is located either the media storage privilege (http://tizen.org/privilege/mediastorage) is required or<br/>
    /// the external storage privilege(http://tizen.org/privilege/externalstorage) is required.
    /// </remarks>
    /// <seealso cref="WebRTC.AddSource"/>
    /// <seealso cref="WebRTC.AddSources"/>
    /// <since_tizen> 10 </since_tizen>
    public sealed class MediaFileSource : MediaSource
    {
        private string _path;

        /// <summary>
        /// Initializes a new instance of the <see cref="MediaFileSource"/> class.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// <exception cref="ArgumentNullException"><paramref name="path"/> is null.</exception>
        /// <since_tizen> 10 </since_tizen>
        public MediaFileSource(string path) : base()
        {
            _path = path ?? throw new ArgumentNullException(nameof(path), "path is null");
        }

        /// <summary>
        /// Gets or sets the looping mode of the file source.
        /// </summary>
        /// <value>
        /// true if the transfer starts again from the beginning of the file source after reaching the end of the file; otherwise, false\n
        /// The default value is false.
        /// </value>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public bool IsLooping
        {
            get
            {
                if (!SourceId.HasValue)
                {
                    return false;
                }

                NativeWebRTC.GetFileSourceLooping(WebRtc.Handle, SourceId.Value, out bool isLooping).
                    ThrowIfFailed("Failed to get looping mode");

                return isLooping;
            }
            set
            {
                if (!SourceId.HasValue)
                {
                    throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
                }

                NativeWebRTC.SetFileSourceLooping(WebRtc.Handle, SourceId.Value, value).
                    ThrowIfFailed("Failed to set looping mode");
            }
        }

        /// <summary>
        /// Gets the transceiver direction for receiving media stream.
        /// </summary>
        /// <remarks>The default value is <see cref="TransceiverDirection.SendRecv"/></remarks>
        /// <param name="type">The media type.</param>
        /// <returns>The transceiver direction.</returns>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public TransceiverDirection GetTransceiverDirection(MediaType type)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            NativeWebRTC.GetTransceiverDirection(WebRtc.Handle, SourceId.Value, type, out TransceiverDirection direction).
                ThrowIfFailed("Failed to get transceiver direction.");

            return direction;
        }

        /// <summary>
        /// Sets the transceiver direction for receiving media stream.
        /// </summary>
        /// <remarks>
        /// This method does not throw state exception anymore(Since API Leve 12). It can be called in any state.<br/>
        /// </remarks>
        /// <param name="type">The media type.</param>
        /// <param name="direction">The transceiver direction.</param>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public void SetTransceiverDirection(MediaType type, TransceiverDirection direction)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            WebRtc.ValidateWebRTCState(WebRTCState.Idle);

            NativeWebRTC.SetTransceiverDirection(WebRtc.Handle, SourceId.Value, type, direction).
                ThrowIfFailed("Failed to set transceiver direction");
        }

        /// <summary>
        /// Gets the pause status of media file source.
        /// </summary>
        /// <remarks>The default value is false.</remarks>
        /// <param name="type">The media type.</param>
        /// <returns>The pause status.</returns>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public bool GetPause(MediaType type)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            WebRtc.ValidateWebRTCState(WebRTCState.Idle);

            NativeWebRTC.GetPause(WebRtc.Handle, SourceId.Value, MediaType, out bool isPaused).
                ThrowIfFailed("Failed to get pause");

            return isPaused;
        }

        /// <summary>
        /// Sets the pause status of media file source.
        /// </summary>
        /// <param name="type">The media type.</param>
        /// <param name="isPaused">The pause status.</param>
        /// <exception cref="InvalidOperationException">MediaSource is not attached yet.</exception>
        /// <exception cref="ObjectDisposedException">The WebRTC has already been disposed.</exception>
        /// <since_tizen> 10 </since_tizen>
        public void SetPause(MediaType type, bool isPaused)
        {
            if (!SourceId.HasValue)
            {
                throw new InvalidOperationException("MediaSource is not attached yet. Call AddSource() first.");
            }

            WebRtc.ValidateWebRTCState(WebRTCState.Idle);

            NativeWebRTC.SetPause(WebRtc.Handle, SourceId.Value, type, isPaused).
                ThrowIfFailed("Failed to set pause");
        }

        internal override void OnAttached(WebRTC webRtc)
        {
            Debug.Assert(webRtc != null);

            if (WebRtc != null)
            {
                throw new InvalidOperationException("The source is has already been assigned to another WebRTC.");
            }

            NativeWebRTC.AddMediaSource(webRtc.Handle, MediaSourceType.File, out uint sourceId).
                ThrowIfFailed("Failed to add MediaFileSource.");

            NativeWebRTC.SetFileSourcePath(webRtc.Handle, sourceId, _path).
                ThrowIfFailed("Failed to set path for MediaFileSource.");

            WebRtc = webRtc;
            SourceId = sourceId;
        }

        internal override void OnDetached(WebRTC webRtc)
        {
            NativeWebRTC.RemoveMediaSource(webRtc.Handle, SourceId.Value).
                ThrowIfFailed("Failed to remove MediaFileSource.");

            WebRtc = null;
        }

        internal override MediaSourceType MediaSourceType => MediaSourceType.File;
    }
}
