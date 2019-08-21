/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control audio ducking.
    /// </summary>
    /// <seealso cref="AudioManager"/>
    /// <since_tizen> 6 </since_tizen>
    public sealed class AudioDucking : IDisposable
    {
        private AudioDuckingHandle _handle;
        private bool _disposed = false;
        private Interop.AudioDucking.DuckingStateChangedCallback _duckingStateChangedCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioDucking"/> class with <see cref="AudioStreamType"/>.
        /// </summary>
        /// <param name="targetType">The type of sound stream to be affected by this new instance.</param>
        /// <exception cref="ArgumentException"><paramref name="targetType"/> is invalid.</exception>
        /// <exception cref="InvalidOperationException">Operation failed; internal error.</exception>
        /// <since_tizen> 6 </since_tizen>
        public AudioDucking(AudioStreamType targetType)
        {
            ValidationUtil.ValidateEnum(typeof(AudioStreamType), targetType, nameof(targetType));

            _duckingStateChangedCallback = (AudioDuckingHandle ducking, bool isDucked, IntPtr _) =>
            {
                DuckingStateChanged?.Invoke(this,
                    new AudioDuckingStateChangedEventArgs(IsDucked));
            };

            Interop.AudioDucking.Create(targetType, _duckingStateChangedCallback,
                IntPtr.Zero, out _handle).ThrowIfError("Unable to create stream ducking");

            Debug.Assert(_handle != null);
        }

        /// <summary>
        /// Occurs when the ducking state is changed.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<AudioDuckingStateChangedEventArgs> DuckingStateChanged;

        /// <summary>
        /// Gets the ducking state of the stream.
        /// </summary>
        /// <value>true if the audio stream is ducked; otherwise, false.</value>
        /// <exception cref="InvalidOperationException">Operation failed; internal error.</exception>
        /// <exception cref="ObjectDisposedException">The ducking has already been disposed of.</exception>
        /// <since_tizen> 6 </since_tizen>
        public bool IsDucked
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(AudioDucking));
                }

                Interop.AudioDucking.IsDucked(Handle, out bool isDucked).
                    ThrowIfError("Failed to get the running state of the device");

                return isDucked;
            }
        }

        /// <summary>
        /// Activate audio ducking
        /// </summary>
        /// <param name="duration">The duration(milisecond) for ducking.</param>
        /// <param name="ratio">The volume ratio after ducked.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="duration"/> is less than 0 or greater than 3000.<br/>
        ///     -or-<br/>
        ///     <paramref name="ratio"/> is less than 0.0 or greater than or equal to 1.0.<br/>
        /// </exception>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.<br/>
        ///     -or-<br/>
        ///     The target stream is already ducked.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege to set volume.</exception>
        /// <exception cref="ObjectDisposedException">The ducking has already been disposed of.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Activate(uint duration, double ratio)
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(AudioDucking));
            }

            if (duration < 0 || duration > 3000)
            {
                throw new ArgumentOutOfRangeException(nameof(duration), duration, "Valid range : 0 <= duration <= 3000");
            }

            if (ratio < 0.0 || ratio >= 1.0)
            {
                throw new ArgumentOutOfRangeException(nameof(ratio), ratio, "Valid range : 0 <= ratio < 1.0");
            }

            Interop.AudioDucking.Activate(Handle, duration, ratio).
                ThrowIfError("Failed to activate ducking");
        }

        /// <summary>
        /// Deactivate audio ducking
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Operation failed; internal error.<br/>
        ///     -or-<br/>
        ///     The target stream is already ducked.
        /// </exception>
        /// <exception cref="UnauthorizedAccessException">The caller does not have required privilege to set volume.</exception>
        /// <exception cref="ObjectDisposedException">The ducking has already been disposed of.</exception>
        /// <since_tizen> 6 </since_tizen>
        public void Deactivate()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(AudioDucking));
            }

            Interop.AudioDucking.Deactivate(Handle).
                ThrowIfError("Failed to deactivate ducking");
        }

        /// <summary>
        /// Releases all resources used by the <see cref="AudioDucking"/>.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            if (_handle != null)
            {
                _handle.Dispose();
            }

            _disposed = true;
            GC.SuppressFinalize(this);
        }

        internal AudioDuckingHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(AudioDucking));
                }
                return _handle;
            }
        }
    }
}