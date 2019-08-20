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
    public class AudioDucking : IDisposable
    {
        private AudioDuckingHandle _handle;
        private bool _disposed = false;
        private Interop.AudioDucking.DuckingStateChangedCallback _duckingStateChangedCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioDucking"/> class with <see cref="AudioStreamType"/>.
        /// </summary>
        /// <param name="targetType">The type of the sound stream for which the policy needs to be created.</param>
        /// <exception cref="ArgumentException"><paramref name="targetType"/> is invalid.</exception>
        /// <since_tizen> 6 </since_tizen>
        public AudioDucking(AudioStreamType targetType)
        {
            ValidationUtil.ValidateEnum(typeof(AudioStreamType), targetType, nameof(targetType));

            _duckingStateChangedCallback = (AudioDuckingHandle ducking, bool isDucked, IntPtr _) =>
            {
                DuckingStateChanged?.Invoke(this,
                    new AudioDuckingStateChangedEventArgs(Handle, IsDucked));
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
        /// <since_tizen> 6 </since_tizen>
        public bool IsDucked
        {
            get
            {
                Interop.AudioDucking.IsDucked(Handle, out bool isDucked).
                    ThrowIfError("Failed to get the running state of the device");

                return isDucked;
            }
        }

        /// <summary>
        /// Activate audio ducking
        /// </summary>
        /// <param name="duration">The duration for ducking.</param>
        /// <param name="ratio">The volume ratio after ducked.</param>
        /// <since_tizen> 6 </since_tizen>
        public void Activate(uint duration, double ratio)
        {
            Interop.AudioDucking.Activate(Handle, duration, ratio).
                ThrowIfError("Failed to activate ducking");
        }

        /// <summary>
        /// Deactivate audio ducking
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Deactivate()
        {
            Interop.AudioDucking.Deactivate(Handle).
                ThrowIfError("Failed to deactivate ducking");
        }

        /// <summary>
        /// Releases all resources used by the <see cref="AudioDucking"/>.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
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

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="AudioDucking"/>.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                if (_handle != null)
                {
                    _handle.Dispose();
                }
                _disposed = true;
            }
        }
    }
}