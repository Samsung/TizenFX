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
using Native = Interop.Recorder;

namespace Tizen.Multimedia
{
    public partial class Recorder
    {
        /// <summary>
        /// Occurs when an error occurs during recorder operation.
        /// </summary>
        public event EventHandler<RecordingErrorOccurredEventArgs> ErrorOccurred;
        private Native.RecorderErrorCallback _errorOccurredCallback;

        /// <summary>
        /// Occurs after interrupt handling is completed.
        /// </summary>
        public event EventHandler<RecorderInterruptedEventArgs> Interrupted;
        private Native.InterruptedCallback _interruptedCallback;

        /// <summary>
        /// This event occurs when recorder state is changed.
        /// </summary>
        public event EventHandler<RecorderStateChangedEventArgs> StateChanged;
        private Native.StatechangedCallback _stateChangedCallback;

        /// <summary>
        /// Occurs when recording information changes.
        /// </summary>
        public event EventHandler<RecordingStatusChangedEventArgs> RecordingStatusChanged;
        private Native.RecordingProgressCallback _recordingProgressCallback;

        //TODO need to test dispose while event handler is running.
        /// <summary>
        /// Occurs when audio stream data is being delivered.
        /// </summary>
        /// <remarks>
        /// Do not call <see cref="Commit"/> and <see cref="Cancel"/> in this event.
        /// </remarks>
        public event EventHandler<AudioStreamStoringEventArgs> AudioStreamStoring;
        private Native.AudioStreamCallback _audioStreamCallback;

        /// <summary>
        /// Occurs when recording limit is reached.
        /// </summary>
        /// <remarks>
        /// After this event is raised, recording data is discarded and not written in the recording file.
        /// </remarks>
        public event EventHandler<RecordingLimitReachedEventArgs> RecordingLimitReached;
        private Native.RecordingLimitReachedCallback _recordingLimitReachedCallback;

        /// <summary>
        /// Occurs when muxed stream data is being delivered.
        /// </summary>
        public event EventHandler<MuxedStreamDeliveredEventArgs> MuxedStreamDelivered;
        private Native.MuxedStreamCallback _muxedStreamCallback;

        private void RegisterEvents()
        {
            RegisterErrorCallback();
            RegisterInterruptedEvent();
            RegisterStateChangedEvent();
            RegisterRecordingProgressEvent();
            RegisterAudioStreamDeliveredEvent();
            RegisterRecordingLimitReachedEvent();
            RegisterMuxedStreamEvent();
            RegisterInterruptingEvent();
        }

        private void RegisterErrorCallback()
        {
            _errorOccurredCallback = (error, state, _) =>
            {
                ErrorOccurred?.Invoke(this, new RecordingErrorOccurredEventArgs(error, state));
            };

            Native.SetErrorCallback(_handle, _errorOccurredCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize ErrorOccurred event");
        }

        private void RegisterInterruptedEvent()
        {
            _interruptedCallback = (policy, previousState, currentState, _) =>
            {
                Interrupted?.Invoke(this, new RecorderInterruptedEventArgs(policy, previousState, currentState));
            };
            Native.SetInterruptedCallback(_handle, _interruptedCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize Interrupted event");
        }

        private void RegisterStateChangedEvent()
        {
            _stateChangedCallback = (RecorderState previous, RecorderState current, bool byPolicy, IntPtr userData) =>
            {
                SetState(current);
                StateChanged?.Invoke(this, new RecorderStateChangedEventArgs(previous, current, byPolicy));
            };

            Native.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize StateChanged event");
        }

        private void RegisterRecordingProgressEvent()
        {
            _recordingProgressCallback = (ulong elapsedTime, ulong fileSize, IntPtr userData) =>
            {
                RecordingStatusChanged?.Invoke(this, new RecordingStatusChangedEventArgs((long)elapsedTime, (long)fileSize));
            };

            Native.SetRecordingProgressCallback(_handle, _recordingProgressCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize RecordingStatusChanged event");
        }

        private void RegisterAudioStreamDeliveredEvent()
        {
            _audioStreamCallback = (stream, streamSize, type, channel, recordingTime, _) =>
            {
                var handler = AudioStreamStoring;
                if (handler != null)
                {
                    _isInAudioStreamStoring.Value = true;

                    using (var buffer = new ScopedMediaBuffer(stream, streamSize))
                    {
                        handler.Invoke(this,
                            new AudioStreamStoringEventArgs(buffer, type, channel, recordingTime));
                    }
                }
            };

            Native.SetAudioStreamCallback(_handle, _audioStreamCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize AudioStreamStoring event");
        }

        private void RegisterRecordingLimitReachedEvent()
        {
            _recordingLimitReachedCallback = (RecordingLimitType type, IntPtr userData) =>
            {
                RecordingLimitReached?.Invoke(this, new RecordingLimitReachedEventArgs(type));
            };

            Native.SetLimitReachedCallback(_handle, _recordingLimitReachedCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize RecordingLimitReached event");
        }

        private void RegisterMuxedStreamEvent()
        {
            _muxedStreamCallback = (IntPtr stream, int streamSize, ulong offset, IntPtr userData) =>
            {
                using (var buffer = new ScopedMediaBuffer(stream, streamSize, true))
                {
                    MuxedStreamDelivered?.Invoke(this, new MuxedStreamDeliveredEventArgs(buffer, offset));
                }
            };

            Native.SetMuxedStreamCallback(_handle, _muxedStreamCallback, IntPtr.Zero).
                ThrowIfError("Failed to initialize MuxedStreamDelivered event");
        }

        /// <summary>
        /// Occurs before interrupt handling is started.
        /// </summary>
        public event EventHandler<RecorderInterruptingEventArgs> Interrupting;
        private Native.InterruptStartedCallback _interruptingCallback;

        private void RegisterInterruptingEvent()
        {
            _interruptingCallback = (policy, state, _) =>
            {
                Interrupting?.Invoke(this, new RecorderInterruptingEventArgs(policy, state));
            };

            Native.SetInterruptStartedCallback(_handle, _interruptingCallback).
                ThrowIfError("Failed to initialize Interrupting event");
        }

        #region DeviceStateChanged

        private static object _deviceStateChangedLock = new object();
        private static EventHandler<RecorderDeviceStateChangedEventArgs> _deviceStateChanged;
        private static Native.DeviceStateChangedCallback _deviceStateChangedCallback;
        private static int _deviceStateChangedId;

        /// <summary>
        /// Occurs when a recorder device state changes.
        /// </summary>
        public static event EventHandler<RecorderDeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                if (value == null)
                {
                    return;
                }

                lock (_deviceStateChangedLock)
                {
                    if (_deviceStateChanged == null)
                    {
                        RegisterDeviceStateChangedEvent();
                    }

                    _deviceStateChanged += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }

                lock (_deviceStateChangedLock)
                {
                    if (_deviceStateChanged == value)
                    {
                        UnregisterDeviceStateChangedEvent();
                    }

                    _deviceStateChanged -= value;
                }
            }
        }

        private static void RegisterDeviceStateChangedEvent()
        {
            _deviceStateChangedCallback = (type, state, _) =>
            {
                _deviceStateChanged?.Invoke(null, new RecorderDeviceStateChangedEventArgs(type, state));
            };

            Native.AddDeviceStateChangedCallback(_deviceStateChangedCallback, IntPtr.Zero, out _deviceStateChangedId).
                ThrowIfError("Failed to add the event handler.");
        }

        private static void UnregisterDeviceStateChangedEvent()
        {
            Native.RemoveDeviceStateChangedCallback(_deviceStateChangedId).
                ThrowIfError("Failed to remove the event handler.");

            _deviceStateChangedCallback = null;
        }
        #endregion
    }
}
