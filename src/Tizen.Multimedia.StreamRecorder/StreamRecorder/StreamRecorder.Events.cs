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
using Native = Interop.StreamRecorder;

namespace Tizen.Multimedia
{
    public partial class StreamRecorder
    {
        /// <summary>
        /// Occurs when <see cref="StreamRecorder"/> state is changed.
        /// </summary>
        public event EventHandler<StreamRecorderStateChangedEventArgs> StateChanged;


        /// <summary>
        /// Occurs when a buffer had consumed completely.
        /// </summary>
        public event EventHandler<StreamRecorderBufferConsumedEventArgs> BufferConsumed;

        /// <summary>
        /// Occurs when recording status is changed.
        /// </summary>
        public event EventHandler<RecordingStatusChangedEventArgs> RecordingStatusChanged;

        /// <summary>
        /// Occurs when recording limit is reached.
        /// </summary>
        public event EventHandler<RecordingLimitReachedEventArgs> RecordingLimitReached;

        /// <summary>
        /// Occurs when an error occurred during a recorder operation.
        /// </summary>
        public event EventHandler<StreamRecorderErrorOccurredEventArgs> ErrorOccurred;

        private Native.RecordingLimitReachedCallback _recordingLimitReachedCallback;
        private Native.RecorderErrorCallback _recorderErrorCallback;
        private Native.RecordingStatusCallback _recordingStatusCallback;
        private Native.BufferConsumedCallback _bufferConsumedCallback;
        private Native.NotifiedCallback _notifiedCallback;

        private void RegisterStreamRecorderNotifiedEvent()
        {
            _notifiedCallback = (previous, current, notify, _) =>
            {
                if (previous == 0)
                {
                    return;
                }

                StateChanged?.Invoke(this, new StreamRecorderStateChangedEventArgs(
                    (RecorderState)previous, (RecorderState)current));
            };

            Native.SetNotifiedCallback(_handle, _notifiedCallback).
                ThrowIfError("Failed to initialize state changed event.");
        }

        private void RegisterBufferConsumedEvent()
        {
            _bufferConsumedCallback = (lockedPacketHandle, _) =>
            {
                MediaPacket packet = null;

                // Lock must be disposed here, note that the packet won't be disposed.
                using (MediaPacket.Lock packetLock =
                    MediaPacket.Lock.FromHandle(lockedPacketHandle))
                {
                    Debug.Assert(packetLock != null);

                    packet = packetLock.MediaPacket;
                }

                BufferConsumed?.Invoke(this, new StreamRecorderBufferConsumedEventArgs(packet));
            };

            Native.SetBufferConsumedCallback(_handle, _bufferConsumedCallback).
                ThrowIfError("Failed to initialize buffer consumed event.");
        }

        private void RegisterRecordingStatusChangedEvent()
        {
            _recordingStatusCallback = (elapsedTime, fileSize, _) =>
            {
                RecordingStatusChanged?.Invoke(this, new RecordingStatusChangedEventArgs((long)elapsedTime, (long)fileSize));
            };
            Native.SetStatusChangedCallback(_handle, _recordingStatusCallback).
                ThrowIfError("Failed to initialize status changed event.");
        }

        private void RegisterRecordingLimitReachedEvent()
        {
            _recordingLimitReachedCallback = (type, _) =>
            {
                RecordingLimitReached?.Invoke(this, new RecordingLimitReachedEventArgs(type));
            };

            Native.SetLimitReachedCallback(_handle, _recordingLimitReachedCallback).
                ThrowIfError("Failed to initialize limit reached event.");
        }

        private void RegisterRecordingErrorOccurredEvent()
        {
            _recorderErrorCallback = (error, currentState, _) =>
            {
                ErrorOccurred?.Invoke(this, new StreamRecorderErrorOccurredEventArgs(
                    error == StreamRecorderErrorCode.OutOfStorage ?
                    StreamRecorderError.OutOfStorage : StreamRecorderError.InternalError, currentState));
            };
            Native.SetErrorCallback(_handle, _recorderErrorCallback).
                ThrowIfError("Failed to set error callback");
        }
    }
}
