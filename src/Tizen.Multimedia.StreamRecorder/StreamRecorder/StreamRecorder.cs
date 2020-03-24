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
using System.Diagnostics;
using System.Linq;
using NativeHandle = Interop.StreamRecorderHandle;
using Native = Interop.StreamRecorder;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to record user buffer from application.
    /// </summary>
    /// <seealso cref="Recorder"/>
    public partial class StreamRecorder : IDisposable
    {
        private NativeHandle _handle;
        private bool _disposed = false;

        private bool _audioEnabled;
        private bool _videoEnabled;
        private StreamRecorderVideoFormat _sourceFormat;
        private const string Feature = "http://tizen.org/feature/multimedia.stream_recorder";

        private static bool IsSupported()
        {
            return System.Information.TryGetValue(Feature, out bool isSupported) && isSupported;
        }

        /// <summary>
        /// Initialize a new instance of the <see cref="StreamRecorder"/> class.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.stream_recorder </feature>
        public StreamRecorder()
        {
            if (IsSupported() == false)
            {
                throw new NotSupportedException(
                    $"The feature({Feature}) is not supported on the current device.");
            }

            try
            {
                Native.Create(out _handle).ThrowIfError("Failed to create stream recorder.");
            }
            catch (TypeLoadException)
            {
                throw new NotSupportedException("StreamRecorder is not supported.");
            }

            LoadCapabilities();

            RegisterStreamRecorderNotifiedEvent();
            RegisterBufferConsumedEvent();
            RegisterRecordingStatusChangedEvent();
            RegisterRecordingErrorOccurredEvent();
            RegisterRecordingLimitReachedEvent();
        }

        internal NativeHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(StreamRecorder));
                }

                return _handle;
            }
        }

        /// <summary>
        /// Gets the current state of the stream recorder.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public RecorderState State
        {
            get
            {
                Native.GetState(Handle, out var val).ThrowIfError("Failed to get the stream recorder state.");

                return val;
            }
        }

        private void ValidateState(params RecorderState[] required)
        {
            Debug.Assert(required.Length > 0);

            var curState = State;
            if (!required.Contains(curState))
            {
                throw new InvalidOperationException($"The stream recorder is not in a valid state. " +
                    $"Current State : { curState }, Valid State : { string.Join(", ", required) }.");
            }
        }

        #region Operation methods
        /// <summary>
        /// Prepares the stream recorder with the specified options.
        /// </summary>
        /// <remarks>The recorder must be <see cref="RecorderState.Idle"/>.</remarks>
        /// <param name="options">The options for recording.</param>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ArgumentException">Both <see cref="StreamRecorderOptions.Audio"/> and
        ///     <see cref="StreamRecorderOptions.Video"/> are null.
        /// </exception>
        /// <exception cref="NotSupportedException"><paramref name="options"/> contains a value which is not supported.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <seealso cref="Unprepare"/>
        /// <seealso cref="Start"/>
        /// <seealso cref="StreamRecorderOptions"/>
        /// <seealso cref="StreamRecorderAudioOptions"/>
        /// <seealso cref="StreamRecorderVideoOptions"/>
        /// <since_tizen> 4 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Prepare(StreamRecorderOptions options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            ValidateState(RecorderState.Idle);

            options.Apply(this);

            Native.Prepare(Handle).ThrowIfError("Failed to prepare stream recorder.");

            _audioEnabled = options.Audio != null;
            _videoEnabled = options.Video != null;

            if (options.Video != null)
            {
                _sourceFormat = options.Video.SourceFormat;
            }
        }

        /// <summary>
        /// Unprepares the stream recorder.
        /// </summary>
        /// <remarks>
        /// The recorder state must be <see cref="RecorderState.Ready"/> state by
        /// <see cref="Prepare(StreamRecorderOptions)"/>, <see cref="Cancel"/> and <see cref="Commit"/>.<br/>
        /// The recorder state will be <see cref="RecorderState.Idle"/>.<br/>
        /// <br/>
        /// It has no effect if the recorder is already in the <see cref="RecorderState.Idle"/> state.
        /// </remarks>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <seealso cref="Prepare"/>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Unprepare()
        {
            if (State == RecorderState.Idle)
            {
                return;
            }

            ValidateState(RecorderState.Ready);

            Native.Unprepare(Handle).ThrowIfError("Failed to reset the stream recorder.");
        }

        /// <summary>
        /// Starts recording.
        /// </summary>
        /// <remarks>
        /// The recorder state must be <see cref="RecorderState.Ready"/> state by
        /// <see cref="Prepare(StreamRecorderOptions)"/> or
        /// <see cref="RecorderState.Paused"/> state by <see cref="Pause"/>.<br/>
        /// <br/>
        /// It has no effect if the recorder is already in the <see cref="RecorderState.Recording"/> state.
        /// </remarks>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="UnauthorizedAccessException">The access of the resources can not be granted.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <seealso cref="Pause"/>
        /// <seealso cref="Commit"/>
        /// <seealso cref="Cancel"/>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Start()
        {
            if (State == RecorderState.Recording)
            {
                return;
            }

            ValidateState(RecorderState.Ready, RecorderState.Paused);

            Native.Start(Handle).ThrowIfError("Failed to start the stream recorder.");
        }

        /// <summary>
        /// Pauses recording.
        /// </summary>
        /// <remarks>
        /// Recording can be resumed with <see cref="Start"/>.<br/>
        /// <br/>
        /// The recorder state must be <see cref="RecorderState.Recording"/> state by <see cref="Start"/>.<br/>
        /// <br/>
        /// It has no effect if the recorder is already in the <see cref="RecorderState.Paused"/> state.
        /// </remarks>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <seealso cref="Start"/>
        /// <seealso cref="Commit"/>
        /// <seealso cref="Cancel"/>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Pause()
        {
            if (State == RecorderState.Paused)
            {
                return;
            }

            ValidateState(RecorderState.Recording);

            Native.Pause(Handle).ThrowIfError("Failed to pause the stream recorder.");
        }

        /// <summary>
        /// Stops recording and saves the result.
        /// </summary>
        /// <remarks>
        /// The recorder state must be <see cref="RecorderState.Recording"/> state by <see cref="Start"/> or
        /// <see cref="RecorderState.Paused"/> state by <see cref="Pause"/>.<br/>
        /// <br/>
        /// The recorder state will be <see cref="RecorderState.Ready"/> after commit.
        /// <para>
        /// http://tizen.org/privilege/mediastorage is needed if the save path are relevant to media storage.
        /// http://tizen.org/privilege/externalstorage is needed if the save path are relevant to external storage.
        /// </para>
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="UnauthorizedAccessException">The access to the resources can not be granted.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <seealso cref="Start"/>
        /// <seealso cref="Pause"/>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Commit()
        {
            ValidateState(RecorderState.Paused, RecorderState.Recording);

            Native.Commit(Handle).ThrowIfError("Failed to commit.");
        }

        /// <summary>
        /// Cancels recording.
        /// The recording data is discarded and not written.
        /// </summary>
        /// <remarks>
        /// The recorder state must be <see cref="RecorderState.Recording"/> state by <see cref="Start"/> or
        /// <see cref="RecorderState.Paused"/> state by <see cref="Pause"/>.
        /// </remarks>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">The recorder is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <seealso cref="Start"/>
        /// <seealso cref="Pause"/>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Cancel()
        {
            ValidateState(RecorderState.Paused, RecorderState.Recording);

            Native.Cancel(Handle).ThrowIfError("Failed to cancel recording.");
        }

        private static bool AreVideoTypesMatched(StreamRecorderVideoFormat videoFormat, MediaFormatVideoMimeType mimeType)
        {
            return (videoFormat == StreamRecorderVideoFormat.Nv12 && mimeType == MediaFormatVideoMimeType.NV12) ||
                (videoFormat == StreamRecorderVideoFormat.Nv21 && mimeType == MediaFormatVideoMimeType.NV21) ||
                (videoFormat == StreamRecorderVideoFormat.I420 && mimeType == MediaFormatVideoMimeType.I420);
        }

        /// <summary>
        /// Pushes a packet as recording raw data.
        /// </summary>
        /// <param name="packet">An audio or video packet to record.</param>
        /// <remarks>
        /// The recorder state must be <see cref="RecorderState.Recording"/> state by <see cref="Start"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     <paramref name="packet"/> is an audio packet but audio recording is not enabled(See <see cref="StreamRecorderOptions.Audio"/>).<br/>
        ///     -or-<br/>
        ///     <paramref name="packet"/> is a video packet but video recording is not enabled(See <see cref="StreamRecorderOptions.Video"/>).<br/>
        ///     -or-<br/>
        ///     <paramref name="packet"/> is a video packet but the <see cref="VideoMediaFormat.MimeType"/> does not match the video source format.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The <see cref="StreamRecorder"/> has already been disposed.</exception>
        /// <see cref="Prepare(StreamRecorderOptions)"/>
        /// <seealso cref="StreamRecorderOptions.Audio"/>
        /// <seealso cref="StreamRecorderOptions.Video"/>
        /// <seealso cref="StreamRecorderVideoOptions.SourceFormat"/>
        /// <since_tizen> 3 </since_tizen>
        public void PushBuffer(MediaPacket packet)
        {
            if (packet == null)
            {
                throw new ArgumentNullException(nameof(packet));
            }

            ValidateState(RecorderState.Recording);

            switch (packet.Format.Type)
            {
                case MediaFormatType.Audio:
                    if (_audioEnabled == false)
                    {
                        throw new InvalidOperationException("Audio option is not set.");
                    }
                    break;

                case MediaFormatType.Video:
                    if (_videoEnabled == false)
                    {
                        throw new InvalidOperationException("Video option is not set.");
                    }

                    if (AreVideoTypesMatched(_sourceFormat, (packet.Format as VideoMediaFormat).MimeType) == false)
                    {
                        throw new InvalidOperationException("Video format does not match.");
                    }

                    break;

                default:
                    throw new ArgumentException("Packet is not valid.");
            }

            Native.PushStreamBuffer(Handle, MediaPacket.Lock.Get(packet).GetHandle())
                .ThrowIfError("Failed to push buffer.");
        }

        #endregion

        #region Dispose support
        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <exception cref="NotSupportedException">The feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        /// <feature> http://tizen.org/feature/multimedia.streamrecorder.record </feature>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Releases the resources used by the StreamRecorder.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _handle?.Dispose();

                _disposed = true;
            }
        }
        #endregion
    }
}
