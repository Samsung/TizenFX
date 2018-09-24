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
using static Interop.AudioIO;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to directly manage the system audio input devices.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/recorder</privilege>
    /// <since_tizen> 3 </since_tizen>
    public abstract class AudioCaptureBase : IDisposable
    {
        /// <summary>
        /// Specifies the minimum value allowed for the audio capture, in Hertz (Hz).
        /// </summary>
        /// <seealso cref="SampleRate"/>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MinSampleRate = 8000;

        /// <summary>
        /// Specifies the maximum value allowed for the audio capture, in Hertz (Hz).
        /// </summary>
        /// <seealso cref="SampleRate"/>
        /// <since_tizen> 3 </since_tizen>
        public static readonly int MaxSampleRate = 192000;

        internal IntPtr _handle = IntPtr.Zero;

        private AudioIOState _state = AudioIOState.Idle;

        internal AudioCaptureBase(int sampleRate, AudioChannel channel, AudioSampleType sampleType)
        {
            if (sampleRate < MinSampleRate || MaxSampleRate < sampleRate)
            {
                throw new ArgumentOutOfRangeException(nameof(sampleRate), sampleRate,
                    $"Valid sampleRate range is { MinSampleRate } <= x <= { MaxSampleRate }.");
            }

            ValidationUtil.ValidateEnum(typeof(AudioChannel), channel, nameof(channel));
            ValidationUtil.ValidateEnum(typeof(AudioSampleType), sampleType, nameof(sampleType));

            SampleRate = sampleRate;
            Channel = channel;
            SampleType = sampleType;

            AudioInput.Create(SampleRate, (int)Channel, (int)SampleType, out _handle)
                .ThrowIfFailed("Failed to create audio capture instance.");

            RegisterStateChangedCallback();
        }

        /// <summary>
        /// Finalizes an instance of the AudioCaptureBase class.
        /// </summary>
        ~AudioCaptureBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Occurs when the state of the AudioCapture is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AudioIOStateChangedEventArgs> StateChanged;

        private AudioStateChangedCallback _stateChangedCallback;

        private void RegisterStateChangedCallback()
        {
            _stateChangedCallback = (IntPtr handle, int previous, int current, bool byPolicy, IntPtr _) =>
            {
                _state = (AudioIOState)current;

                StateChanged?.Invoke(this,
                    new AudioIOStateChangedEventArgs((AudioIOState)previous, _state, byPolicy));
            };

            AudioInput.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero)
                .ThrowIfFailed("Failed to set state changed callback.");
        }

        #region Dispose support
        private bool _isDisposed = false;

        /// <summary>
        /// Releases all resources used by the <see cref="AudioCaptureBase"/> object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="AudioCaptureBase"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (_handle != IntPtr.Zero)
            {
                if (_state != AudioIOState.Idle)
                {
                    try
                    {
                        Unprepare();
                    }
                    catch (Exception)
                    {
                    }
                }

                AudioInput.Destroy(_handle);
                _handle = IntPtr.Zero;
                _isDisposed = true;
            }
        }

        internal void ValidateNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        #endregion

        internal void ValidateState(params AudioIOState[] desiredStates)
        {
            ValidateNotDisposed();

            AudioIOUtil.ValidateState(_state, desiredStates);
        }

        /// <summary>
        /// Gets the sample rate of the audio input data stream, in Hertz (Hz).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int SampleRate { get; }

        /// <summary>
        /// Gets the channel type of the audio input data stream.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AudioChannel Channel { get; }

        /// <summary>
        /// Gets the sample type of the audio input data stream.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AudioSampleType SampleType { get; }

        /// <summary>
        /// Gets the size allocated for the audio input buffer.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The AudioCaptureBase has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int GetBufferSize()
        {
            ValidateNotDisposed();

            AudioInput.GetBufferSize(_handle, out var size)
                .ThrowIfFailed("Failed to get buffer size.");

            return size;
        }

        /// <summary>
        /// Prepares the AudioCapture for reading audio data by starting buffering of audio data from the device.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed due to an internal error.<br/>
        ///     -or-<br/>
        ///     The current state is not <see cref="AudioIOState.Idle"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioCaptureBase has already been disposed of.</exception>
        /// <seealso cref="Unprepare"/>
        /// <since_tizen> 3 </since_tizen>
        public void Prepare()
        {
            ValidateState(AudioIOState.Idle);

            AudioInput.Prepare(_handle).ThrowIfFailed("Failed to prepare the AudioCapture");
        }

        /// <summary>
        /// Unprepares the AudioCapture.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed due to an internal error.<br/>
        ///     -or-<br/>
        ///     The current state is <see cref="AudioIOState.Idle"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioCaptureBase has already been disposed of.</exception>
        /// <seealso cref="Prepare"/>
        /// <since_tizen> 3 </since_tizen>
        public void Unprepare()
        {
            ValidateState(AudioIOState.Running, AudioIOState.Paused);

            AudioInput.Unprepare(_handle).ThrowIfFailed("Failed to unprepare the AudioCapture");
        }

        /// <summary>
        /// Pauses buffering of audio data from the device.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The current state is <see cref="AudioIOState.Idle"/>.<br/>
        ///     -or-<br/>
        ///     The method is called in the <see cref="AsyncAudioCapture.DataAvailable"/> event handler.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioCaptureBase has already been disposed of.</exception>
        /// <seealso cref="Resume"/>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            if (_state == AudioIOState.Paused)
            {
                return;
            }
            ValidateState(AudioIOState.Running);

            AudioInput.Pause(_handle).ThrowIfFailed("Failed to pause.");
        }
        /// <summary>
        /// Resumes buffering audio data from the device.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     The current state is <see cref="AudioIOState.Idle"/>.<br/>
        ///     -or-<br/>
        ///     The method is called in the <see cref="AsyncAudioCapture.DataAvailable"/> event handler.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioCaptureBase has already been disposed of.</exception>
        /// <seealso cref="Pause"/>
        /// <since_tizen> 3 </since_tizen>
        public void Resume()
        {
            if (_state == AudioIOState.Running)
            {
                return;
            }
            ValidateState(AudioIOState.Paused);

            AudioInput.Resume(_handle).ThrowIfFailed("Failed to resume.");
        }

        /// <summary>
        /// Flushes and discards buffered audio data from the input stream.
        /// </summary>
        /// <exception cref="InvalidOperationException">The current state is <see cref="AudioIOState.Idle"/>.</exception>
        /// <exception cref="ObjectDisposedException">The AudioCaptureBase has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Flush()
        {
            ValidateState(AudioIOState.Running, AudioIOState.Paused);

            var ret = AudioInput.Flush(_handle);
            MultimediaDebug.AssertNoError((int)ret);
        }

        /// <summary>
        /// Sets the sound stream information to the audio input.
        /// </summary>
        /// <param name="streamPolicy">The <see cref="AudioStreamPolicy"/> to apply for the AudioCapture.</param>
        /// <exception cref="ArgumentNullException"><paramref name="streamPolicy"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="streamPolicy"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     The AudioCaptureBase has already been disposed of.
        /// </exception>
        /// <exception cref="NotSupportedException"><paramref name="streamPolicy"/> is not supported.</exception>
        /// <exception cref="ArgumentException">Not able to retrieve information from <paramref name="streamPolicy"/>.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyStreamPolicy(AudioStreamPolicy streamPolicy)
        {
            if (streamPolicy == null)
            {
                throw new ArgumentNullException(nameof(streamPolicy));
            }

            ValidateNotDisposed();

            AudioInput.SetStreamInfo(_handle, streamPolicy.Handle)
                .ThrowIfFailed("Failed to apply stream policy.");
        }
    }

    /// <summary>
    /// Provides the ability to record audio from system audio input devices in a synchronous way.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/recorder</privilege>
    /// <since_tizen> 3 </since_tizen>
    public class AudioCapture : AudioCaptureBase
    {
        /// <summary>
        /// Initializes a new instance of the AudioCapture class with the specified sample rate, channel, and sampleType.
        /// </summary>
        /// <param name="sampleRate">The audio sample rate (8000 ~ 192000Hz).</param>
        /// <param name="channel">The audio channel type.</param>
        /// <param name="sampleType">The audio sample type.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="sampleRate"/> is less than <see cref="AudioCaptureBase.MinSampleRate"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="sampleRate"/> is greater than <see cref="AudioCaptureBase.MaxSampleRate"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="channel"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="sampleType"/> is invalid.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The required privilege is not specified.</exception>
        /// <exception cref="NotSupportedException">The system does not support microphone.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioCapture(int sampleRate, AudioChannel channel, AudioSampleType sampleType)
            : base(sampleRate, channel, sampleType)
        {
        }

        /// <summary>
        /// Reads audio data from the audio input buffer.
        /// </summary>
        /// <param name="count">The number of bytes to be read.</param>
        /// <returns>The buffer of audio data captured.</returns>
        /// <exception cref="InvalidOperationException">The current state is not <see cref="AudioIOState.Running"/>.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="count"/> is equal to or less than zero.</exception>
        /// <exception cref="ObjectDisposedException">The AudioCapture has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Read(int count)
        {
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count), count,
                    $"{ nameof(count) } can't be equal to or less than zero.");
            }
            ValidateState(AudioIOState.Running);

            byte[] buffer = new byte[count];

            AudioInput.Read(_handle, buffer, count).ThrowIfFailed("Failed to read.");

            return buffer;
        }
    }

    /// <summary>
    /// Provides the ability to record audio from system audio input devices in an asynchronous way.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/recorder</privilege>
    /// <since_tizen> 3 </since_tizen>
    public class AsyncAudioCapture : AudioCaptureBase
    {

        /// <summary>
        /// Occurs when audio data is available.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AudioDataAvailableEventArgs> DataAvailable;

        /// <summary>
        /// Initializes a new instance of the AsyncAudioCapture class with the specified sample rate, channel and sampleType.
        /// </summary>
        /// <param name="sampleRate">The audio sample rate (8000 ~ 192000Hz).</param>
        /// <param name="channel">The audio channel type.</param>
        /// <param name="sampleType">The audio sample type.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="sampleRate"/> is less than <see cref="AudioCaptureBase.MinSampleRate"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="sampleRate"/> is greater than <see cref="AudioCaptureBase.MaxSampleRate"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="channel"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="sampleType"/> is invalid.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The required privilege is not specified.</exception>
        /// <exception cref="NotSupportedException">The system does not support microphone.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AsyncAudioCapture(int sampleRate, AudioChannel channel, AudioSampleType sampleType)
            : base(sampleRate, channel, sampleType)
        {
            _streamCallback = (IntPtr handle, uint length, IntPtr _) => { OnInputDataAvailable(handle, length); };

            AudioInput.SetStreamCallback(_handle, _streamCallback, IntPtr.Zero)
                .ThrowIfFailed("Failed to create instance.");
        }

        private AudioStreamCallback _streamCallback;

        private void OnInputDataAvailable(IntPtr handle, uint length)
        {
            if (length == 0U)
            {
                return;
            }

            try
            {
                AudioInput.Peek(_handle, out IntPtr ptr, ref length).ThrowIfFailed("Failed to peek.");

                byte[] buffer = new byte[length];
                Marshal.Copy(ptr, buffer, 0, (int)length);

                AudioInput.Drop(_handle);

                DataAvailable?.Invoke(this, new AudioDataAvailableEventArgs(buffer));
            }
            catch (Exception e)
            {
                Log.Error(nameof(AsyncAudioCapture), e.Message);
            }
        }
    }
}
