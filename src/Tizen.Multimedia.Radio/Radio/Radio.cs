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
using System.Threading.Tasks;
using Tizen.System;
using Native = Interop.Radio;
using static Interop;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides a means for using the radio feature.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Radio : IDisposable
    {
        private RadioHandle _handle;

        private const string FeatureFmRadio = "http://tizen.org/feature/fmradio";

        /// <summary>
        /// Initializes a new instance of the Radio class.
        /// </summary>
        /// <exception cref="NotSupportedException">The radio feature is not supported.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Radio()
        {
            ValidateFeatureSupported(FeatureFmRadio);

            Native.Create(out _handle);

            try
            {
                InitCallbacks();

                Native.SetScanCompletedCb(_handle, _scanCompletedCallback).
                    ThrowIfFailed("Failed to initialize radio");
                Native.SetInterruptedCb(_handle, _interruptedCallback).
                    ThrowIfFailed("Failed to initialize radio");
            }
            catch (Exception)
            {
                _handle.Dispose();
                throw;
            }
        }

        private void InitCallbacks()
        {
            _scanCompletedCallback = _ => ScanCompleted?.Invoke(this, EventArgs.Empty);

            _interruptedCallback =
                (reason, _) => Interrupted?.Invoke(this, new RadioInterruptedEventArgs(reason));

            _scanUpdatedCallback =
                (frequency, _) => ScanUpdated?.Invoke(this, new ScanUpdatedEventArgs(frequency));

            _scanStoppedCallback = _ => ScanStopped?.Invoke(this, EventArgs.Empty);
        }

        private RadioHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(GetType().Name);
                }
                return _handle;
            }
        }

        private Native.ScanUpdatedCallback _scanUpdatedCallback;

        private Native.ScanStoppedCallback _scanStoppedCallback;

        private Native.ScanCompletedCallback _scanCompletedCallback;

        private Native.InterruptedCallback _interruptedCallback;

        /// <summary>
        /// Occurs when the radio scanning information is updated.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ScanUpdatedEventArgs> ScanUpdated;

        /// <summary>
        /// Occurs when the radio scanning stops.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler ScanStopped;

        /// <summary>
        /// Occurs when the radio scanning is completed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler ScanCompleted;

        /// <summary>
        /// Occurs when the radio is interrupted.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<RadioInterruptedEventArgs> Interrupted;

        /// <summary>
        /// Gets the current state of the radio.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public RadioState State
        {
            get
            {
                Native.GetState(Handle, out var state).ThrowIfFailed("Failed to get state");
                return state;
            }
        }

        /// <summary>
        /// Gets or sets the radio frequency in the range of 87500 ~ 108000 kHz.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than <see cref="Range.Min"/> of <see cref="FrequencyRange"/>.<br/>
        ///     -or- <br/>
        ///     <paramref name="value"/> is greater than <see cref="Range.Max"/> of <see cref="FrequencyRange"/>.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int Frequency
        {
            get
            {
                Native.GetFrequency(Handle, out var value).ThrowIfFailed("Failed to get frequency");
                return value;
            }
            set
            {
                if (value < FrequencyRange.Min || value > FrequencyRange.Max)
                {
                    throw new ArgumentOutOfRangeException(nameof(Frequency), value,
                        "Frequency must be within FrequencyRange.");
                }

                Native.SetFrequency(Handle, value).ThrowIfFailed("Failed to set frequency");
            }
        }

        /// <summary>
        /// Gets the current signal strength in the range of -128 ~ 128 dBm.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int SignalStrength
        {
            get
            {
                int value = 0;
                Native.GetSignalStrength(Handle, out value).ThrowIfFailed("Failed to get signal strength");
                return value;
            }
        }

        /// <summary>
        /// Gets or sets the value indicating if the radio is muted.
        /// </summary>
        /// <value>
        /// true if the radio is muted; otherwise, false.
        /// The default is false.
        /// </value>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool IsMuted
        {
            get
            {
                Native.GetMuted(Handle, out var value).ThrowIfFailed("Failed to get the mute state");
                return value;
            }
            set
            {
                Native.SetMute(Handle, value).ThrowIfFailed("Failed to set the mute state");
            }
        }

        /// <summary>
        /// Gets the channel spacing for the current region.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public int ChannelSpacing
        {
            get
            {
                Native.GetChannelSpacing(Handle, out var value).
                    ThrowIfFailed("Failed to get channel spacing");
                return value;
            }
        }

        /// <summary>
        /// Gets or sets the radio volume level.
        /// </summary>
        /// <remarks>Valid volume range is from 0 to 1.0(100%), inclusive.</remarks>
        /// <value>The default is 1.0.</value>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="value"/> is less than zero.<br/>
        ///     -or-<br/>
        ///     <paramref name="value"/> is greater than 1.0.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public float Volume
        {
            get
            {
                Native.GetVolume(Handle, out var value).ThrowIfFailed("Failed to get volume level.");
                return value;
            }
            set
            {
                if (value < 0F || 1.0F < value)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value,
                        $"Valid volume range is 0 <= value <= 1.0, but got { value }.");
                }

                Native.SetVolume(Handle, value).ThrowIfFailed("Failed to set volume level");
            }
        }

        /// <summary>
        /// Gets the frequency for the region in the range of 87500 ~ 108000 kHz.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Range FrequencyRange
        {
            get
            {
                Native.GetFrequencyRange(Handle, out var min, out var max).
                    ThrowIfFailed("Failed to get frequency range");

                return new Range(min, max);
            }
        }

        /// <summary>
        /// Starts the radio.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Ready"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Start()
        {
            ValidateRadioState(RadioState.Ready);

            Native.Start(Handle).ThrowIfFailed("Failed to start radio");
        }

        /// <summary>
        /// Stops the radio.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Stop()
        {
            ValidateRadioState(RadioState.Playing);

            Native.Stop(Handle).ThrowIfFailed("Failed to stop radio");
        }

        /// <summary>
        /// Starts the radio scanning and triggers the <see cref="ScanUpdated"/> event when the scan information is updated.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Ready"/> or <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <seealso cref="ScanUpdated"/>
        /// <seealso cref="ScanCompleted"/>
        /// <since_tizen> 3 </since_tizen>
        public void StartScan()
        {
            ValidateRadioState(RadioState.Ready, RadioState.Playing);

            Native.ScanStart(Handle, _scanUpdatedCallback).ThrowIfFailed("Failed to start scanning");
        }

        /// <summary>
        /// Stops the radio scanning.
        /// </summary>
        /// <remarks>The radio must be in the <see cref="RadioState.Scanning"/> state.</remarks>
        /// <exception cref="InvalidOperationException">The radio is not in the valid state.</exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <seealso cref="ScanStopped"/>
        /// <since_tizen> 3 </since_tizen>
        public void StopScan()
        {
            ValidateRadioState(RadioState.Scanning);

            Native.ScanStop(Handle, _scanStoppedCallback).ThrowIfFailed("Failed to stop scanning");
        }

        /// <summary>
        /// Seeks up the effective frequency of the radio.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous seeking operation.
        /// The result value is the current frequency in the range of 87500 ~ 108000 kHz.
        /// It can be -1 if the seeking operation has failed.
        /// </returns>
        /// <remarks>The radio must be in the <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The radio is not in the valid state.<br/>
        ///     -or-<br/>
        ///     Seeking is in progress.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Task<int> SeekUpAsync()
        {
            return SeekAsync(Native.SeekUp);
        }

        /// <summary>
        /// Seeks down the effective frequency of the radio.
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous seeking operation.
        /// The result value is the current frequency in the range of 87500 ~ 108000 kHz.
        /// It can be -1 if the seeking operation has failed.
        /// </returns>
        /// <remarks>The radio must be in the <see cref="RadioState.Playing"/> state.</remarks>
        /// <exception cref="InvalidOperationException">
        ///     The radio is not in the valid state.<br/>
        ///     -or-<br/>
        ///     Seeking is in progress.
        /// </exception>
        /// <exception cref="ObjectDisposedException">The radio already has been disposed.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Task<int> SeekDownAsync()
        {
            return SeekAsync(Native.SeekDown);
        }

        private async Task<int> SeekAsync(
            Func<RadioHandle, Native.SeekCompletedCallback, IntPtr, RadioError> func)
        {
            ValidateRadioState(RadioState.Playing);

            var tcs = new TaskCompletionSource<int>();
            Native.SeekCompletedCallback callback =
                (currentFrequency, _) => tcs.TrySetResult(currentFrequency);

            using (ObjectKeeper.Get(callback))
            {
                func(Handle, callback, IntPtr.Zero).ThrowIfFailed("Failed to seek");
                return await tcs.Task;
            }
        }

        private void ValidateFeatureSupported(string featurePath)
        {
            if (Information.TryGetValue(featurePath, out bool supported) == false || supported == false)
            {
                throw new NotSupportedException($"The feature({featurePath}) is not supported.");
            }
        }

        private void ValidateRadioState(params RadioState[] required)
        {
            ValidateNotDisposed();

            RadioState curState = State;

            if (required.Contains(curState) == false)
            {
                throw new InvalidOperationException($"{curState} is not valid state.");
            }
        }

        #region IDisposable Support
        private bool _disposed = false;

        /// <summary>
        /// Releases the resources used by the Radio.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources; false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != null)
                {
                    _handle.Dispose();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="Radio"/> object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
        }

        private void ValidateNotDisposed()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(Radio));
            }
        }
        #endregion
    }
}
