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
using System.Threading;
using Native = Interop.Recorder;
using NativeHandle = Interop.RecorderHandle;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Recorder is a base class for audio and video recorders that
    /// provides the ability to control the recording of a multimedia content.<br/>
    /// <br/>
    /// Simple audio and audio/video are supported.
    /// </summary>
    public abstract partial class Recorder : IDisposable
    {
        private readonly NativeHandle _handle;
        private RecorderState _state;
        private ThreadLocal<bool> _isInAudioStreamStoring = new ThreadLocal<bool>();

        internal Recorder(NativeHandle handle)
        {
            _handle = handle;

            try
            {
                RegisterEvents();

                SetState(State);
            }
            catch (Exception)
            {
                _handle.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Finalizes an instance of the Recorder class.
        /// </summary>
        ~Recorder()
        {
            Dispose(false);
        }

        internal NativeHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(Recorder));
                }

                return _handle;
            }
        }

        #region Dispose support
        private bool _disposed;

        /// <summary>
        /// Releases the unmanaged resources used by the Recorder.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the Recorder.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _isInAudioStreamStoring?.Dispose();
                }

                _handle?.Dispose();

                _disposed = true;
            }
        }
        #endregion Dispose support

        #region State validation
        internal void ValidateState(params RecorderState[] required)
        {
            Debug.Assert(required.Length > 0);

            var curState = _state;
            if (!required.Contains(curState))
            {
                throw new InvalidOperationException("The recorder is not in a valid state. " +
                    $"Current State : { curState }, Valid State : { string.Join(", ", required) }.");
            }
        }

        private void SetState(RecorderState state)
        {
            _state = state;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets the current state of the recorder.
        /// </summary>
        /// <value>A <see cref="RecorderState"/> that specifies the state of the recorder.</value>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public RecorderState State
        {
            get
            {
                Native.GetState(Handle, out var val).ThrowIfError("Failed to get recorder state.");

                return val;
            }
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Prepares the media recorder for recording.
        /// </summary>
        /// <remarks>
        /// The recorder should be in the <see cref="RecorderState.Idle"/> state.
        /// The state of the recorder will be the <see cref="RecorderState.Ready"/> after this.
        /// It has no effect if the current state is the <see cref="RecorderState.Ready"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Prepare()
        {
            if (_state == RecorderState.Ready)
            {
                return;
            }

            ValidateState(RecorderState.Idle);

            Native.Prepare(Handle).ThrowIfError("Failed to prepare media recorder");

            SetState(RecorderState.Ready);
        }

        private void ThrowIfAccessedInAudioStreamStoring()
        {
            if (_isInAudioStreamStoring.Value)
            {
                throw new InvalidOperationException("The method can't be called in the AudioStreamStoring event");
            }
        }

        /// <summary>
        /// Resets the media recorder.
        /// </summary>
        /// <remarks>
        /// The recorder should be in the <see cref="RecorderState.Ready"/> state.
        /// The state of recorder will be the <see cref="RecorderState.Idle"/> after this.
        /// It has no effect if the current state is the <see cref="RecorderState.Idle"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Unprepare()
        {
            ThrowIfAccessedInAudioStreamStoring();

            if (_state == RecorderState.Idle)
            {
                return;
            }

            ValidateState(RecorderState.Ready);

            Native.Unprepare(Handle).ThrowIfError("Failed to reset the media recorder");

            SetState(RecorderState.Idle);
        }

        /// <summary>
        /// Starts the recording.
        /// </summary>
        /// <remarks>
        /// The recorder must be in the <see cref="RecorderState.Ready"/> state.
        /// The state of the recorder will be the <see cref="RecorderState.Recording"/> after this. <br/>
        /// <br/>
        /// If the specified path exists, the file is removed automatically and updated by new one.<br/>
        /// The mediastorage privilege(http://tizen.org/privilege/mediastorage) is required if the path is relevant to media storage.<br/>
        /// The externalstorage privilege(http://tizen.org/privilege/externalstorage) is required if the path is relevant to external storage.<br/>
        /// <br/>
        /// In the video recorder, some preview format does not support record mode.
        /// You should use the default preview format or the <see cref="CameraPixelFormat.Nv12"/> in the record mode.
        /// </remarks>
        /// <param name="savePath">The file path for recording result.</param>
        /// <privilege>http://tizen.org/privilege/recorder</privilege>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     The preview format of the camera is not supported.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="savePath"/> is null.</exception>
        /// <exception cref="ArgumentException"><paramref name="savePath"/> is a zero-length string, contains only white space.</exception>
        /// <exception cref="UnauthorizedAccessException">Caller does not have required privilege.</exception>
        /// <seealso cref="Commit"/>
        /// <seealso cref="Cancel"/>
        /// <since_tizen> 4 </since_tizen>
        public void Start(string savePath)
        {
            ValidateState(RecorderState.Ready);

            if (savePath == null)
            {
                throw new ArgumentNullException(nameof(savePath));
            }

            if (string.IsNullOrWhiteSpace(savePath))
            {
                throw new ArgumentException($"{nameof(savePath)} is an empty string.", nameof(savePath));
            }

            Native.SetFileName(Handle, savePath).ThrowIfError("Failed to set save path.");

            Native.Start(Handle).ThrowIfError("Failed to start the media recorder");

            SetState(RecorderState.Recording);
        }

        /// <summary>
        /// Resumes the recording.
        /// </summary>
        /// <remarks>
        /// The recorder should be in the <see cref="RecorderState.Paused"/> state.
        /// The state of recorder will be the <see cref="RecorderState.Recording"/> after this.
        /// It has no effect if the current state is the <see cref="RecorderState.Recording"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public void Resume()
        {
            if (_state == RecorderState.Recording)
            {
                return;
            }

            ValidateState(RecorderState.Paused);

            Native.Start(Handle).ThrowIfError("Failed to resume the media recorder");

            SetState(RecorderState.Recording);
        }

        /// <summary>
        /// Pauses the recording.
        /// </summary>
        /// <remarks>
        /// The recorder should be in the <see cref="RecorderState.Recording"/> state.
        /// The state of the recorder will be the <see cref="RecorderState.Paused"/> after this.
        /// It has no effect if the current state is the <see cref="RecorderState.Paused"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            if (_state == RecorderState.Paused)
            {
                return;
            }

            ValidateState(RecorderState.Recording);

            Native.Pause(Handle).ThrowIfError("Failed to pause the media recorder");

            SetState(RecorderState.Paused);
        }

        /// <summary>
        /// Stops recording and saves the result.
        /// </summary>
        /// <remarks>
        /// The recorder must be in the <see cref="RecorderState.Recording"/> or the <see cref="RecorderState.Paused"/> state.
        /// The state of the recorder will be the <see cref="RecorderState.Ready"/> after the operation.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     The method is called in <see cref="AudioStreamStoring"/> event.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Commit()
        {
            ThrowIfAccessedInAudioStreamStoring();

            ValidateState(RecorderState.Recording, RecorderState.Paused);

            Native.Commit(Handle).ThrowIfError("Failed to save the recorded content");

            SetState(RecorderState.Ready);
        }

        /// <summary>
        /// Cancels the recording.<br/>
        /// The recording data is discarded and not written in the recording file.
        /// </summary>
        /// <remarks>
        /// The recorder must be in the <see cref="RecorderState.Recording"/> or the <see cref="RecorderState.Paused"/> state.
        /// The state of the recorder will be the <see cref="RecorderState.Ready"/> after the operation.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     The method is called in <see cref="AudioStreamStoring"/> event.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Cancel()
        {
            ThrowIfAccessedInAudioStreamStoring();

            ValidateState(RecorderState.Recording, RecorderState.Paused);

            Native.Cancel(Handle).ThrowIfError("Failed to cancel the recording");

            SetState(RecorderState.Ready);
        }

        /// <summary>
        /// Apply the audio stream policy.
        /// </summary>
        /// <remarks>
        /// The recorder must be in the <see cref="RecorderState.Idle"/> or the <see cref="RecorderState.Ready"/> state.
        /// </remarks>
        /// <param name="policy">The policy to apply.</param>
        /// <exception cref="ArgumentNullException"><paramref name="policy"/> is null.</exception>
        /// <exception cref="InvalidOperationException">
        ///     The recorder is not in the valid state.<br/>
        ///     -or-<br/>
        ///     <paramref name="policy"/> is not supported for the recorder.<br/>
        ///     -or-<br/>
        ///     An internal error occurred.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The recorder already has been disposed of.<br/>
        ///     -or-<br/>
        ///     <paramref name="policy"/> already has been disposed of.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public void ApplyAudioStreamPolicy(AudioStreamPolicy policy)
        {
            if (policy == null)
            {
                throw new ArgumentNullException(nameof(policy));
            }

            ValidateState(RecorderState.Idle, RecorderState.Ready);

            Native.SetAudioStreamPolicy(Handle, policy.Handle).ThrowIfError("Failed to apply the audio stream policy.");
        }

        /// <summary>
        /// Returns the peak audio input level in dB since the last call to this method.
        /// </summary>
        /// <remarks>
        /// 0dB indicates the maximum input level, -300dB indicates the minimum input level.<br/>
        /// <br/>
        /// The recorder must be in the <see cref="RecorderState.Recording"/> or the <see cref="RecorderState.Paused"/> state.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The recorder already has been disposed of.</exception>
        /// <since_tizen> 4 </since_tizen>
        public double GetPeakAudioLevel()
        {
            ValidateState(RecorderState.Recording, RecorderState.Paused);

            Native.GetAudioLevel(Handle, out var level).ThrowIfError("Failed to get audio level.");

            return level;
        }

        /// <summary>
        /// Returns the state of recorder device.
        /// </summary>
        /// <exception cref="ArgumentException"><paramref name="type"/> is invalid.</exception>
        /// <since_tizen> 4 </since_tizen>
        public static RecorderDeviceState GetDeviceState(RecorderType type)
        {
            ValidationUtil.ValidateEnum(typeof(RecorderType), type, nameof(type));

            Native.GetDeviceState(type, out var state).ThrowIfError("Failed to get device state");

            return state;
        }
        #endregion
    }
}
