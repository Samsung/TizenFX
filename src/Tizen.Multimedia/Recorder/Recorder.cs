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
using System.Linq;
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    static internal class RecorderLog
    {
        internal const string Tag = "Tizen.Multimedia.Recorder";
    }

    /// <summary>
    /// The recorder class provides methods to create audio/video recorder,
    ///  to start, stop and save the recorded content. It also provides methods
    ///  to get/set various attributes and capabilities of recorder.
    /// </summary>
    /// <privilege>
    /// http://tizen.org/privilege/recorder
    /// </privilege>
    public class Recorder : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private RecorderState _state = RecorderState.None;

        /// <summary>
        /// Audio recorder constructor.
        /// </summary>
        /// /// <privilege>
        /// http://tizen.org/privilege/microphone
        /// </privilege>
        public Recorder()
        {
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Create(out _handle),
                "Failed to create Audio recorder");

            Feature = new RecorderFeatures(this);
            Setting = new RecorderSettings(this);

            RegisterCallbacks();

            SetState(RecorderState.Created);
        }

        /// <summary>
        /// Video recorder constructor.
        /// </summary>
        /// <param name="camera">
        /// The camera object.
        /// </param>
        /// <privilege>
        /// http://tizen.org/privilege/camera
        /// </privilege>
        public Recorder(Camera camera)
        {
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.CreateVideo(camera.GetHandle(), out _handle),
                "Failed to create Video recorder.");

            Feature = new RecorderFeatures(this);
            Setting = new RecorderSettings(this);

            RegisterCallbacks();

            SetState(RecorderState.Created);
        }

        /// <summary>
        /// Recorder destructor.
        /// </summary>
        ~Recorder()
        {
            Dispose (false);
        }

        internal IntPtr GetHandle()
        {
            ValidateNotDisposed();
            return _handle;
        }

#region Dispose support
        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
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
                    // to be used if there are any other disposable objects
                }
                if (_handle != IntPtr.Zero)
                {
                    Interop.Recorder.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }

        internal void ValidateNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(Recorder));
            }
        }
#endregion Dispose support

#region Check recorder state
        internal void ValidateState(params RecorderState[] required)
        {
            ValidateNotDisposed();

            Debug.Assert(required.Length > 0);

            var curState = _state;
            if (!required.Contains(curState))
            {
                throw new InvalidOperationException($"The recorder is not in a valid state. " +
                    $"Current State : { curState }, Valid State : { string.Join(", ", required) }.");
            }
        }

        internal void SetState(RecorderState state)
        {
            _state = state;
        }
#endregion Check recorder state

#region EventHandlers
        /// <summary>
        /// Event that occurs when an error occurs during recorder operation.
        /// </summary>
        public event EventHandler<RecordingErrorOccurredEventArgs> ErrorOccurred;
        private Interop.Recorder.RecorderErrorCallback _errorOccuredCallback;

        /// <summary>
        /// Event that occurs when recorder is interrupted.
        /// </summary>
        public event EventHandler<RecorderInterruptedEventArgs> Interrupted;
        private Interop.Recorder.InterruptedCallback _interruptedCallback;

        /// <summary>
        /// This event occurs when recorder state is changed.
        /// </summary>
        public event EventHandler<RecorderStateChangedEventArgs> StateChanged;
        private Interop.Recorder.StatechangedCallback _stateChangedCallback;

        /// <summary>
        /// Event that occurs when recording information changes.
        /// </summary>
        public event EventHandler<RecordingProgressEventArgs> RecordingProgress;
        private Interop.Recorder.RecordingProgressCallback _recordingProgressCallback;

        /// <summary>
        /// Event that occurs when audio stream data is being delivered.
        /// </summary>
        public event EventHandler<AudioStreamDeliveredEventArgs> AudioStreamDelivered;
        private Interop.Recorder.AudioStreamCallback _audioStreamCallback;

        /// <summary>
        /// Event that occurs when recording limit is reached.
        /// </summary>
        public event EventHandler<RecordingLimitReachedEventArgs> RecordingLimitReached;
        private Interop.Recorder.RecordingLimitReachedCallback _recordingLimitReachedCallback;

        /// <summary>
        /// Event that occurs when muxed stream data is being delivered.
        /// </summary>
        public event EventHandler<MuxedStreamDeliveredEventArgs> MuxedStreamDelivered;
        private Interop.Recorder.MuxedStreamCallback _muxedStreamCallback;
#endregion EventHandlers

#region Properties
        /// <summary>
        /// Gets the various recorder features.
        /// </summary>
        public RecorderFeatures Feature { get; }

        /// <summary>
        /// Get/Set the various recorder settings.
        /// </summary>
        public RecorderSettings Setting { get; }

        /// <summary>
        /// The current state of the recorder.
        /// </summary>
        /// <value>A <see cref="RecorderState"/> that specifies the state of recorder.</value>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public RecorderState State
        {
            get
            {
                ValidateNotDisposed();

                RecorderState val = 0;

                RecorderErrorFactory.ThrowIfError(Interop.Recorder.GetState(_handle, out val),
                    "Failed to get recorder state.");

                return val;
            }
        }
#endregion Properties

#region Methods
        /// <summary>
        /// Prepare the media recorder for recording.
        /// The recorder must be in the <see cref="RecorderState.Created"/> state.
        /// After this method is finished without any exception,
        /// The state of recorder will be changed to <see cref="RecorderState.Ready"/> state.
        /// </summary>
        /// <remarks>
        /// Before calling the function, it is required to set AudioEncoder,
        /// videoencoder and fileformat properties of recorder.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/camera or http://tizen.org/privilege/microphone
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void Prepare()
        {
            ValidateState(RecorderState.Created);

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Prepare(_handle),
                "Failed to prepare media recorder for recording");

            SetState(RecorderState.Ready);
        }

        /// <summary>
        /// Resets the media recorder.
        /// The recorder must be in the <see cref="RecorderState.Ready"/> state.
        /// After this method is finished without any exception,
        /// The state of recorder will be changed to <see cref="RecorderState.Created"/> state.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera or http://tizen.org/privilege/microphone
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void Unprepare()
        {
            ValidateState(RecorderState.Ready);

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Unprepare(_handle),
                "Failed to reset the media recorder");

            SetState(RecorderState.Created);
        }

        /// <summary>
        /// Starts the recording.
        /// The recorder must be in the <see cref="RecorderState.Ready"/> state.
        /// After this method is finished without any exception,
        /// The state of recorder will be changed to <see cref="RecorderState.Recording"/> state.
        /// </summary>
        /// <remarks>
        /// If file path has been set to an existing file, this file is removed automatically and updated by new one.
        /// In the video recorder, some preview format does not support record mode. It will return InvalidOperation error.
        ///	You should use default preview format or CameraPixelFormatNv12 in the record mode.
        ///	The filename should be set before this function is invoked.
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/camera or http://tizen.org/privilege/microphone
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void Start()
        {
            ValidateState(RecorderState.Ready);

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Start(_handle),
                "Failed to start the media recorder");

            SetState(RecorderState.Recording);
        }

        /// <summary>
        /// Pause the recording.
        /// The recorder must be in the <see cref="RecorderState.Recording"/> state.
        /// After this method is finished without any exception,
        /// The state of recorder will be changed to <see cref="RecorderState.Paused"/> state.
        /// </summary>
        /// <remarks>
        /// Recording can be resumed with Start().
        /// </remarks>
        /// <privilege>
        /// http://tizen.org/privilege/camera or http://tizen.org/privilege/microphone
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void Pause()
        {
            ValidateState(RecorderState.Recording);

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Pause(_handle),
                "Failed to pause the media recorder");

            SetState(RecorderState.Paused);
        }

        /// <summary>
        /// Stops recording and saves the result.
        /// The recorder must be in the <see cref="RecorderState.Recording"/> or <see cref="RecorderState.Paused"/> state.
        /// After this method is finished without any exception,
        /// The state of recorder will be changed to <see cref="RecorderState.Ready"/> state.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera or http://tizen.org/privilege/microphone
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void Commit()
        {
            ValidateState(RecorderState.Recording, RecorderState.Paused);

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Commit(_handle),
                "Failed to save the recorded content");

            SetState(RecorderState.Ready);
        }

        /// <summary>
        /// Cancels the recording.
        /// The recording data is discarded and not written in the recording file.
        /// The recorder must be in the <see cref="RecorderState.Recording"/> or <see cref="RecorderState.Paused"/> state.
        /// After this method is finished without any exception,
        /// The state of recorder will be changed to <see cref="RecorderState.Ready"/> state.
        /// </summary>
        /// <privilege>
        /// http://tizen.org/privilege/camera or http://tizen.org/privilege/microphone
        /// </privilege>
        /// <exception cref="InvalidOperationException">In case of any invalid operations.</exception>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void Cancel()
        {
            ValidateState(RecorderState.Recording, RecorderState.Paused);

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.Cancel(_handle),
                "Failed to cancel the recording");

            SetState(RecorderState.Ready);
        }

        /// <summary>
        /// Sets the audio stream policy.
        /// </summary>
        /// <param name="policy">Policy.</param>
        /// <exception cref="ObjectDisposedException">The camera already has been disposed.</exception>
        public void SetAudioStreamPolicy(AudioStreamPolicy policy)
        {
            ValidateNotDisposed();

            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetAudioStreamPolicy(_handle, policy.Handle),
                "Failed to set audio stream policy");
        }
#endregion Methods

#region Callback registrations
        private void RegisterCallbacks()
        {
            RegisterErrorCallback();
            RegisterInterruptedCallback();
            RegisterStateChangedCallback();
            RegisterRecordingProgressCallback();
            RegisterAudioStreamDeliveredCallback();
            RegisterRecordingLimitReachedEvent();
            RegisterMuxedStreamEvent();
        }

        private void RegisterErrorCallback()
        {
            _errorOccuredCallback = (RecorderErrorCode error, RecorderState current, IntPtr userData) =>
            {
                ErrorOccurred?.Invoke(this, new RecordingErrorOccurredEventArgs(error, current));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetErrorCallback(_handle, _errorOccuredCallback, IntPtr.Zero),
                "Setting Error callback failed");
        }

        private void RegisterInterruptedCallback()
        {
            _interruptedCallback = (RecorderPolicy policy, RecorderState previous, RecorderState current, IntPtr userData) =>
            {
                Interrupted?.Invoke(this, new RecorderInterruptedEventArgs(policy, previous, current));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetInterruptedCallback(_handle, _interruptedCallback, IntPtr.Zero),
                "Setting Interrupted callback failed");
        }

        private void RegisterStateChangedCallback()
        {
            _stateChangedCallback = (RecorderState previous, RecorderState current, bool byPolicy, IntPtr userData) =>
            {
                SetState(current);
                Log.Info(RecorderLog.Tag, "Recorder state changed " + previous.ToString() + " -> " + current.ToString());
                StateChanged?.Invoke(this, new RecorderStateChangedEventArgs(previous, current, byPolicy));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero),
                "Setting state changed callback failed");
        }

        private void RegisterRecordingProgressCallback()
        {
            _recordingProgressCallback = (ulong elapsedTime, ulong fileSize, IntPtr userData) =>
            {
                RecordingProgress?.Invoke(this, new RecordingProgressEventArgs(elapsedTime, fileSize));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetRecordingProgressCallback(_handle, _recordingProgressCallback, IntPtr.Zero),
                "Setting status changed callback failed");
        }

        private void RegisterAudioStreamDeliveredCallback()
        {
            _audioStreamCallback = (IntPtr stream, int streamSize, AudioSampleType type, int channel, uint recordingTime, IntPtr userData) =>
            {
                AudioStreamDelivered?.Invoke(this, new AudioStreamDeliveredEventArgs(stream, streamSize, type, channel, recordingTime));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetAudioStreamCallback(_handle, _audioStreamCallback, IntPtr.Zero),
                "Setting audiostream callback failed");
        }

        private void RegisterRecordingLimitReachedEvent()
        {
            _recordingLimitReachedCallback = (RecordingLimitType type, IntPtr userData) =>
            {
                RecordingLimitReached?.Invoke(this, new RecordingLimitReachedEventArgs(type));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetLimitReachedCallback(_handle, _recordingLimitReachedCallback, IntPtr.Zero),
                "Setting limit reached callback failed");
        }

        private void RegisterMuxedStreamEvent()
        {
            _muxedStreamCallback = (IntPtr stream, int streamSize, ulong offset, IntPtr userData) =>
            {
                MuxedStreamDelivered?.Invoke(this, new MuxedStreamDeliveredEventArgs(stream, streamSize, offset));
            };
            RecorderErrorFactory.ThrowIfError(Interop.Recorder.SetMuxedStreamCallback(_handle, _muxedStreamCallback, IntPtr.Zero),
                "Setting muxed stream callback failed");
        }
#endregion Callback registrations
    }
}
