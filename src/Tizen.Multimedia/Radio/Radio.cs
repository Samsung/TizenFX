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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Radio class, provides support for using the Radio feature
    /// </summary>
    public class Radio : IDisposable
    {
        internal Interop.RadioHandle _handle;

        /// <summary>
        /// Radio constructor
        /// </summary>
        /// <exception cref="OutOfMemoryException"></exception>
        /// <exception cref="NotSupportedException">This is thrown if Radio feature is not supported</exception>
        /// <exception cref="InvalidOperationException"></exception>
        public Radio()
        {
            _handle = new Interop.RadioHandle();
            _handle.ScanCompleteCb = ScanCompleteCallback;
            _handle.InteruptedCb = PlaybackIntruptedCallback;
        }

        /// <summary>
        /// Scan update event, to be triggered when radio scan information is updated
        /// </summary>
        public event EventHandler<ScanUpdatedEventArgs> ScanInformationUpdated;

        /// <summary>
        /// Scan stopped event, to be triggered when radio scanning stops
        /// </summary>
        public event EventHandler ScanStopped;

        /// <summary>
        /// Scan complete event, to be triggered when radio scan is completed
        /// </summary>
        public event EventHandler ScanCompleted;

        /// <summary>
        /// Playback interrupted event, to be triggered when radio playback is interrupted
        /// </summary>
        public event EventHandler<RadioInterruptedEventArgs> PlaybackInterrupted;

        /// <summary>
        /// Current state for the radio
        /// </summary>
        public RadioState State
        {
            get
            {
                ValidateObjectNotDisposed();
                return (RadioState)_handle.State;
            }
        }

        /// <summary>
        /// Current radio frequency, in [87500 ~ 108000] (kHz) range
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">This is thrown if value passed to setter in not in valid range</exception>
        public int Frequency
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.Frequency;
            }
            set
            {
                ValidateObjectNotDisposed();
                ValidateInputRangeForPropertySetter(value, 87500, 108000);
                _handle.Frequency = value;
            }
        }

        /// <summary>
        /// Current signal strength, in  [-128 ~ 128] (dBm) range
        /// </summary>
        public int SignalStrength
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.SignalStrength;
            }
        }

        /// <summary>
        /// Indicates if radio is muted
        /// </summary>
        public bool IsMuted
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.IsMuted;
            }
            set
            {
                ValidateObjectNotDisposed();
                _handle.IsMuted = value;
            }
        }

        /// <summary>
        /// Channel spacing for current region
        /// </summary>
        public int ChannelSpacing
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.ChannelSpacing;
            }
        }

        /// <summary>
        /// Current radio volume level, in [0.0 ~ 1.0](1.0 = 100%) range
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">This is thrown if value passed to setter in not in valid range</exception>
        public float Volume
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.Volume;
            }
            set
            {
                ValidateObjectNotDisposed();
                ValidateInputRangeForPropertySetter(value, 0.0, 1.0);
                _handle.Volume = value;
            }
        }

        /// <summary>
        /// Minimum frequency for the region, in [87500 ~ 108000] (kHz) range
        /// </summary>
        public int MinimumFrequency
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.MinimumFrequency;
            }
        }

        /// <summary>
        /// Maximum frequency for the region, in [87500 ~ 108000] (kHz) range
        /// </summary>
        public int MaximumFrequency
        {
            get
            {
                ValidateObjectNotDisposed();
                return _handle.MaximumFrequency;
            }
        }

        /// <summary>
        /// Starts radio playback
        /// </summary>
        /// <remarks>This method can be called if Radio is in Ready state. This method will move Radio to Playing state</remarks>
        /// <exception cref="InvalidOperationException">This is thrown if Radio is not in Ready state</exception>
        public void StartPlayback()
        {
            ValidateObjectNotDisposed();
            ValidateRadioState(() => State == RadioState.Ready);
            _handle.StartPlayback();
        }

        /// <summary>
        /// Stops radio playback
        /// </summary>
        /// <remarks>This method can be called if Radio is in Playing state. This method will move Radio to Ready state</remarks>
        /// <exception cref="InvalidOperationException">This is thrown if Radio is not in Playing state</exception>
        public void StopPlayback()
        {
            ValidateObjectNotDisposed();
            ValidateRadioState(() => State == RadioState.Playing);
            _handle.StopPlayback();
        }

        /// <summary>
        /// Starts radio scan, will trigger ScanInformationUpdated event, when scan information is updated
        /// </summary>
        /// <remarks>This method should not be called if Radio is in Scanning state. This method will move Radio to Scanning state</remarks>
        /// <exception cref="InvalidOperationException">This is thrown if Radio is already in Scanning state</exception>
        public void StartScan()
        {
            ValidateObjectNotDisposed();
            ValidateRadioState(() => State != RadioState.Scanning);
            _handle.StartScan(ScanUpdateCallback);
        }

        /// <summary>
        /// Stops radio scan, will trigger ScanStopped event, once complete
        /// </summary>
        /// <remarks>This method should be called only if Radio is in Scanning state</remarks>
        /// <exception cref="InvalidOperationException">This is thrown if Radio is not in Scanning state</exception>
        public void StopScan()
        {
            ValidateObjectNotDisposed();
            ValidateRadioState(() => State == RadioState.Scanning);
            _handle.StopScan(ScanStoppedCallback);
        }

        /// <summary>
        /// Seeks up the effective frequency of the radio
        /// </summary>
        /// <returns>Current frequency, in range [87500 ~ 108000] (kHz)</returns>
        /// <remarks>Radio must be in Playing state to use this API</remarks>
        /// <exception cref="InvalidOperationException">This is thrown if Radio is not in Playing state</exception>
        public Task<int> SeekUpAsync()
        {
            ValidateObjectNotDisposed();
            ValidateRadioState(() => State == RadioState.Playing);

            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            Interop.RadioHandle.SeekCompletedCallback callback = (currentFrequency, userData) =>
            {
                tcs.TrySetResult(currentFrequency);
            };

            _handle.SeekUp(callback);
            return Interop.PinnedTask(tcs);
        }

        /// <summary>
        /// Seeks down the effective frequency of the radio
        /// </summary>
        /// <returns>Current frequency, in range [87500 ~ 108000] (kHz)</returns>
        /// <remarks>Radio must be in Playing state to use this API</remarks>
        /// <exception cref="InvalidOperationException">This is thrown if Radio is not in Playing state</exception>
        public Task<int> SeekDownAsync()
        {
            ValidateObjectNotDisposed();
            ValidateRadioState(() => State == RadioState.Playing);

            TaskCompletionSource<int> tcs = new TaskCompletionSource<int>();
            Interop.RadioHandle.SeekCompletedCallback callback = (currentFrequency, userData) =>
            {
                tcs.TrySetResult(currentFrequency);
            };

            _handle.SeekDown(callback);
            return Interop.PinnedTask(tcs);
        }

        private void ScanUpdateCallback(int frequency, IntPtr data)
        {
            ScanInformationUpdated?.Invoke(this, new ScanUpdatedEventArgs(frequency));
        }

        private void ScanStoppedCallback(IntPtr data)
        {
            ScanStopped?.Invoke(this, EventArgs.Empty);
        }

        private void ScanCompleteCallback(IntPtr data)
        {
            ScanCompleted?.Invoke(this, EventArgs.Empty);
        }

        private void PlaybackIntruptedCallback(Interop.RadioInterruptedReason reason, IntPtr data)
        {
            PlaybackInterrupted?.Invoke(this, new RadioInterruptedEventArgs((RadioInterruptedReason)reason));
        }

        private void ValidateInputRangeForPropertySetter<T>(T input, T min, T max, [CallerMemberName] string member = "") where T : IComparable<T>
        {
            if (min.CompareTo(input) == 1 || max.CompareTo(input) == -1)
            {
                throw new ArgumentOutOfRangeException(member, input, $"Valid Range [{min} - {max}]");
            }
        }

        private void ValidateRadioState(Func<bool> stateVerifier, [CallerMemberName] string member = "")
        {
            if (stateVerifier() == false)
            {
                throw new InvalidOperationException($"{State} is not valid state to call {member}. Please check API documentation");
            }
        }

        private void ValidateObjectNotDisposed()
        {
            if (_disposedValue)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                _handle.Dispose();
                _disposedValue = true;
            }
        }

        ~Radio()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}