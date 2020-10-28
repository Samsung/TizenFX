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
using static Interop.AudioIO;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to directly manage the system audio output devices and play the PCM (pulse-code modulation) data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioPlayback : IDisposable
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

        private IntPtr _handle = IntPtr.Zero;

        private AudioIOState _state = AudioIOState.Idle;

        #region Event
        /// <summary>
        /// Occurs when the audio playback data can be written.
        /// </summary>
        /// <seealso cref="Write(byte[])"/>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AudioPlaybackBufferAvailableEventArgs> BufferAvailable;

        private AudioStreamCallback _streamCallback;

        private void RegisterStreamCallback()
        {
            _streamCallback = (IntPtr handle, uint bytes, IntPtr _) =>
            {
                BufferAvailable?.Invoke(this, new AudioPlaybackBufferAvailableEventArgs((int)bytes));
            };

            AudioIOUtil.ThrowIfError(
                AudioOutput.SetStreamChangedCallback(_handle, _streamCallback, IntPtr.Zero),
                $"Failed to create {nameof(AudioPlayback)}");
        }

        /// <summary>
        /// Occurs when the state of the AudioPlayback is changed.
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

            AudioIOUtil.ThrowIfError(
                AudioOutput.SetStateChangedCallback(_handle, _stateChangedCallback, IntPtr.Zero),
                $"Failed to create {nameof(AudioPlayback)}");
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the AudioPlayback class with the specified sample rate, channel, and sample type.
        /// </summary>
        /// <param name="sampleRate">The audio sample rate (8000 ~ 192000Hz).</param>
        /// <param name="channel">The audio channel type.</param>
        /// <param name="sampleType">The audio sample type.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="sampleRate"/> is less than <see cref="MinSampleRate"/>.<br/>
        ///     -or-<br/>
        ///     <paramref name="sampleRate"/> is greater than <see cref="MaxSampleRate"/>.
        /// </exception>
        /// <exception cref="ArgumentException">
        ///     <paramref name="channel"/> is invalid.<br/>
        ///     -or-<br/>
        ///     <paramref name="sampleType"/> is invalid.
        /// </exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioPlayback(int sampleRate, AudioChannel channel, AudioSampleType sampleType)
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

            AudioIOUtil.ThrowIfError(
                AudioOutput.Create(SampleRate, (int)Channel, (int)SampleType, out _handle),
                $"Failed to create {nameof(AudioPlayback)}");

            RegisterStreamCallback();
            RegisterStateChangedCallback();
        }

        /// <summary>
        /// Finalizes an instance of the AudioPlayback class.
        /// </summary>
        ~AudioPlayback()
        {
            Dispose(false);
        }

        #region Dispose support
        private bool _isDisposed = false;

        /// <summary>
        /// Releases all resources used by the <see cref="AudioPlayback"/> object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="AudioPlayback"/> object.
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

                AudioOutput.Destroy(_handle);
                _handle = IntPtr.Zero;
                _isDisposed = true;
            }
        }

        private void ValidateNotDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
        #endregion

        private void ValidateState(params AudioIOState[] desiredStates)
        {
            ValidateNotDisposed();

            AudioIOUtil.ValidateState(_state, desiredStates);
        }

        /// <summary>
        /// Gets the sample rate of the audio output data stream, in Hertz (Hz).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int SampleRate { get; }

        /// <summary>
        /// Gets the channel type of the audio output data stream.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AudioChannel Channel { get; }

        /// <summary>
        /// Gets the sample type of the audio output data stream.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AudioSampleType SampleType { get; }

        /// <summary>
        /// Gets the sound type supported by the audio output device.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioStreamType StreamType
        {
            get
            {
                ValidateNotDisposed();

                int audioType = 0;
                int ret = AudioOutput.GetSoundType(_handle, out audioType);
                MultimediaDebug.AssertNoError(ret);

                return (AudioStreamType)audioType;
            }
        }

        /// <summary>
        /// Gets the size allocated for the audio output buffer.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int GetBufferSize()
        {
            AudioIOUtil.ThrowIfError(AudioOutput.GetBufferSize(_handle, out var size));
            return size;
        }

        /// <summary>
        /// Drains the buffered audio data from the output stream.
        /// It blocks the calling thread until the drain of the stream buffer is complete, for example, at the end of playback.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <exception cref="InvalidOperationException">The current state is <see cref="AudioIOState.Idle"/>.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Drain()
        {
            ValidateState(AudioIOState.Running, AudioIOState.Paused);

            int ret = AudioOutput.Drain(_handle);

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Starts writing the audio data to the device.
        /// </summary>
        /// <param name="buffer">The buffer to write.</param>
        /// <returns>The written size.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="buffer"/> is null.</exception>
        /// <exception cref="ArgumentException">The length of <paramref name="buffer"/> is zero.</exception>
        /// <exception cref="InvalidOperationException">The current state is not <see cref="AudioIOState.Running"/>.</exception>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int Write(byte[] buffer)
        {
            ValidateState(AudioIOState.Running);

            if (buffer == null)
            {
                throw new ArgumentNullException(nameof(buffer));
            }

            if (buffer.Length == 0)
            {
                throw new ArgumentException("buffer has no data.(the Length is zero.)", nameof(buffer));
            }

            int ret = AudioOutput.Write(_handle, buffer, (uint)buffer.Length);

            AudioIOUtil.ThrowIfError(ret, "Failed to write buffer");

            return ret;
        }

        /// <summary>
        /// Prepares the AudioPlayback.
        /// </summary>
        /// <remarks>
        /// This must be called before <see cref="Write(byte[])"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed due to an internal error.<br/>
        ///     -or-<br/>
        ///     The current state is not <see cref="AudioIOState.Idle"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <seealso cref="Unprepare"/>
        /// <since_tizen> 3 </since_tizen>
        public void Prepare()
        {
            ValidateState(AudioIOState.Idle);

            AudioIOUtil.ThrowIfError(AudioOutput.Prepare(_handle),
                $"Failed to prepare the {nameof(AudioPlayback)}");
        }

        /// <summary>
        /// Unprepares the AudioPlayback.
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed due to an internal error.<br/>
        ///     -or-<br/>
        ///     The current state is <see cref="AudioIOState.Idle"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <seealso cref="Prepare"/>
        /// <since_tizen> 3 </since_tizen>
        public void Unprepare()
        {
            ValidateState(AudioIOState.Running, AudioIOState.Paused);

            AudioIOUtil.ThrowIfError(AudioOutput.Unprepare(_handle),
                $"Failed to unprepare the {nameof(AudioPlayback)}");
        }

        /// <summary>
        /// Pauses feeding of the audio data to the device.
        /// </summary>
        /// <remarks>It has no effect if the current state is <see cref="AudioIOState.Paused"/>.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The current state is <see cref="AudioIOState.Idle"/>.<br/>
        ///     -or-<br/>
        ///     The method is called in the <see cref="BufferAvailable"/> event handler.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <seealso cref="Resume"/>
        /// <since_tizen> 3 </since_tizen>
        public void Pause()
        {
            if (_state == AudioIOState.Paused)
            {
                return;
            }
            ValidateState(AudioIOState.Running);

            AudioIOUtil.ThrowIfError(AudioOutput.Pause(_handle));
        }

        /// <summary>
        /// Resumes feeding of the audio data to the device.
        /// </summary>
        /// <remarks>It has no effect if the current state is <see cref="AudioIOState.Running"/>.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The current state is <see cref="AudioIOState.Idle"/>.<br/>
        ///     -or-<br/>
        ///     The method is called in an event handler.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <seealso cref="Pause"/>
        /// <since_tizen> 3 </since_tizen>
        public void Resume()
        {
            if (_state == AudioIOState.Running)
            {
                return;
            }
            ValidateState(AudioIOState.Paused);

            AudioIOUtil.ThrowIfError(AudioOutput.Resume(_handle));
        }

        /// <summary>
        /// Flushes and discards the buffered audio data from the output stream.
        /// </summary>
        /// <exception cref="InvalidOperationException">The current state is <see cref="AudioIOState.Idle"/>.</exception>
        /// <exception cref="ObjectDisposedException">The AudioPlayback has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Flush()
        {
            ValidateState(AudioIOState.Running, AudioIOState.Paused);

            int ret = AudioOutput.Flush(_handle);

            MultimediaDebug.AssertNoError(ret);
        }

        /// <summary>
        /// Applies the sound stream information to the AudioPlayback.
        /// </summary>
        /// <param name="streamPolicy">The <see cref="AudioStreamPolicy"/> to apply for the AudioPlayback.</param>
        /// <exception cref="ArgumentNullException"><paramref name="streamPolicy"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">
        ///     <paramref name="streamPolicy"/> has already been disposed of.<br/>
        ///     -or-<br/>
        ///     The AudioPlayback has already been disposed of.
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

            AudioIOUtil.ThrowIfError(AudioOutput.SetStreamInfo(_handle, streamPolicy.Handle));
        }
    }
}
