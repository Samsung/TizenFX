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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control the sound stream.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioStreamPolicy : IDisposable
    {
        private AudioStreamPolicyHandle _handle;
        private bool _disposed = false;
        private Interop.AudioStreamPolicy.FocusStateChangedCallback _focusStateChangedCallback;

        /// <summary>
        /// Initializes a new instance of the <see cref="AudioStreamPolicy"/> class with <see cref="AudioStreamType"/>.
        /// </summary>
        /// <remarks>
        /// To apply the stream policy according to this stream information, the AudioStreamPolicy should
        /// be passed to other APIs related to playback or recording. (For example., <see cref="T:Tizen.Multimedia.Player"/>,
        /// <see cref="T:Tizen.Multimedia.WavPlayer"/> , etc.)
        /// </remarks>
        /// <param name="streamType">The type of the sound stream for which the policy needs to be created.</param>
        /// <exception cref="ArgumentException"><paramref name="streamType"/> is invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioStreamPolicy(AudioStreamType streamType)
        {
            ValidationUtil.ValidateEnum(typeof(AudioStreamType), streamType, nameof(streamType));

            _focusStateChangedCallback = (IntPtr streamInfo, AudioStreamFocusOptions focusMask,
                AudioStreamFocusState state, AudioStreamFocusChangedReason reason, AudioStreamBehaviors behaviors,
                string extraInfo, IntPtr _) =>
            {
                FocusStateChanged?.Invoke(this,
                    new AudioStreamPolicyFocusStateChangedEventArgs(focusMask, state, reason, behaviors, extraInfo));
            };

            Interop.AudioStreamPolicy.Create(streamType, _focusStateChangedCallback,
                IntPtr.Zero, out _handle).ThrowIfError("Unable to create stream information");

            Debug.Assert(_handle != null);
        }

        /// <summary>
        /// Occurs when the state of focus that belongs to the current AudioStreamPolicy is changed.
        /// </summary>
        /// <remarks>
        /// The event is raised in the internal thread.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<AudioStreamPolicyFocusStateChangedEventArgs> FocusStateChanged;

        /// <summary>
        /// Gets the <see cref="AudioVolumeType"/>.
        /// </summary>
        /// <remarks>
        /// If the <see cref="AudioStreamType"/> of the current AudioStreamPolicy is <see cref="AudioStreamType.Emergency"/>,
        /// it returns <see cref="AudioVolumeType.None"/>.
        /// </remarks>
        /// <value>The <see cref="AudioVolumeType"/> of the policy instance.</value>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioVolumeType VolumeType
        {
            get
            {
                var ret = Interop.AudioStreamPolicy.GetSoundType(Handle, out var type);
                if (ret == AudioManagerError.NoData)
                {
                    return AudioVolumeType.None;
                }

                ret.ThrowIfError("Failed to get volume type");

                return type;
            }
        }

        private AudioStreamFocusState GetFocusState(bool playback)
        {
            int ret = Interop.AudioStreamPolicy.GetFocusState(Handle, out var stateForPlayback, out var stateForRecording);
            MultimediaDebug.AssertNoError(ret);

            return playback ? stateForPlayback : stateForRecording;
        }

        /// <summary>
        /// Gets the state of focus for the playback.
        /// </summary>
        /// <value>The state of focus for playback.</value>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioStreamFocusState PlaybackFocusState => GetFocusState(true);

        /// <summary>
        /// Gets the state of focus for the recording.
        /// </summary>
        /// <value>The state of focus for recording.</value>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public AudioStreamFocusState RecordingFocusState => GetFocusState(false);

        /// <summary>
        /// Gets or sets the auto focus reacquisition.
        /// </summary>
        /// <value>
        /// true if the auto focus reacquisition is enabled; otherwise, false.<br/>
        /// The default is true.
        /// </value>
        /// <remarks>
        /// If you don't want to reacquire the focus you've lost automatically,
        /// disable the focus reacquisition.
        /// </remarks>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public bool FocusReacquisitionEnabled
        {
            get
            {
                Interop.AudioStreamPolicy.GetFocusReacquisition(Handle, out var enabled).
                    ThrowIfError("Failed to get focus reacquisition state");

                return enabled;
            }
            set
            {
                Interop.AudioStreamPolicy.SetFocusReacquisition(Handle, value).
                    ThrowIfError("Failed to set focus reacquisition");
            }
        }

        internal AudioStreamPolicyHandle Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(AudioStreamPolicy));
                }
                return _handle;
            }
        }

        /// <summary>
        /// Acquires the stream focus.
        /// </summary>
        /// <param name="options">The focuses that you want to acquire.</param>
        /// <param name="behaviors">The requesting behaviors.</param>
        /// <param name="extraInfo">The extra information for this request. This value can be null.</param>
        /// <exception cref="ArgumentException"><paramref name="options"/> is zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="options"/> contain a invalid bit.<br/>
        ///     -or-<br/>
        ///     <paramref name="behaviors"/> contain a invalid bit.
        /// </exception>
        /// <exception cref="InvalidOperationException">The focus has already been acquired.</exception>
        /// <exception cref="AudioPolicyException">Called in <see cref="FocusStateChanged"/> raised by releasing focus.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void AcquireFocus(AudioStreamFocusOptions options, AudioStreamBehaviors behaviors, string extraInfo)
        {
            if (options == 0)
            {
                throw new ArgumentException("options can't be zero.", nameof(options));
            }

            if (options.IsValid() == false)
            {
                throw new ArgumentOutOfRangeException(nameof(options), options, "options contains a invalid bit.");
            }

            if (behaviors.IsValid() == false)
            {
                throw new ArgumentOutOfRangeException(nameof(behaviors), behaviors, "behaviors contains a invalid bit.");
            }

            Interop.AudioStreamPolicy.AcquireFocus(Handle, options, behaviors, extraInfo).
                ThrowIfError("Failed to acquire focus");
        }

        /// <summary>
        /// Releases the acquired focus.
        /// </summary>
        /// <param name="options">The focus mask that you want to release.</param>
        /// <param name="behaviors">The requesting behaviors.</param>
        /// <param name="extraInfo">The extra information for this request. This value can be null.</param>
        /// <exception cref="ArgumentException"><paramref name="options"/> is zero.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        ///     <paramref name="options"/> contain a invalid bit.<br/>
        ///     -or-<br/>
        ///     <paramref name="behaviors"/> contain a invalid bit.
        /// </exception>
        /// <exception cref="InvalidOperationException">The focus has not been acquired.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void ReleaseFocus(AudioStreamFocusOptions options, AudioStreamBehaviors behaviors, string extraInfo)
        {
            if (options == 0)
            {
                throw new ArgumentException("options can't be zero.", nameof(options));
            }

            if (options.IsValid() == false)
            {
                throw new ArgumentOutOfRangeException(nameof(options), options, "options contains a invalid bit.");
            }

            if (behaviors.IsValid() == false)
            {
                throw new ArgumentOutOfRangeException(nameof(behaviors), behaviors, "behaviors contains a invalid bit.");
            }

            Interop.AudioStreamPolicy.ReleaseFocus(Handle, options, behaviors, extraInfo).
                ThrowIfError("Failed to release focus");
        }

        /// <summary>
        /// Applies the stream routing.
        /// </summary>
        /// <remarks>
        /// If the stream has not been made yet, this will be applied when the stream starts to play.
        /// </remarks>
        /// <seealso cref="AddDeviceForStreamRouting(AudioDevice)"/>
        /// <seealso cref="RemoveDeviceForStreamRouting(AudioDevice)"/>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void ApplyStreamRouting()
        {
            Interop.AudioStreamPolicy.ApplyStreamRouting(Handle).ThrowIfError("Failed to apply stream routing");
        }

        /// <summary>
        /// Adds a device for the stream routing.
        /// </summary>
        /// <param name="device">The device to add.</param>
        /// <remarks>
        /// The available <see cref="AudioStreamType"/> is <see cref="AudioStreamType.Voip"/> and <see cref="AudioStreamType.MediaExternalOnly"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        ///     The device is not connected.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
        /// <exception cref="ArgumentNullException"><paramref name="device"/> is null.</exception>
        /// <exception cref="AudioPolicyException"><see cref="AudioStreamType"/> of <paramref name="device"/> is unavailable for this.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <seealso cref="AudioManager.GetConnectedDevices()"/>
        /// <seealso cref="ApplyStreamRouting"/>
        /// <since_tizen> 3 </since_tizen>
        public void AddDeviceForStreamRouting(AudioDevice device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            var ret = Interop.AudioStreamPolicy.AddDeviceForStreamRouting(Handle, device.Id);

            if (ret == AudioManagerError.NoData)
            {
                throw new InvalidOperationException("The device seems not connected.");
            }

            ret.ThrowIfError("Failed to add device for stream routing");
        }

        /// <summary>
        /// Removes the device for the stream routing.
        /// </summary>
        /// <param name="device">The device to remove.</param>
        /// <remarks>
        /// The available <see cref="AudioStreamType"/> is <see cref="AudioStreamType.Voip"/> and <see cref="AudioStreamType.MediaExternalOnly"/>.
        /// </remarks>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="device"/> is null.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <seealso cref="AudioManager.GetConnectedDevices()"/>
        /// <since_tizen> 3 </since_tizen>
        public void RemoveDeviceForStreamRouting(AudioDevice device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            Interop.AudioStreamPolicy.RemoveDeviceForStreamRouting(Handle, device.Id).
                ThrowIfError("Failed to remove device for stream routing");
        }

        /// <summary>
        /// Checks if any stream from the current AudioStreamPolicy is using the device.
        /// </summary>
        /// <returns>true if any audio stream from the current AudioStreamPolicy is using the device; otherwise, false.</returns>
        /// <param name="device">The device to be checked.</param>
        /// <exception cref="ArgumentNullException"><paramref name="device"/> is null.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <seealso cref="AudioManager.GetConnectedDevices()"/>
        /// <since_tizen> 6 </since_tizen>
        public bool IsStreamOnDevice(AudioDevice device)
        {
            if (device == null)
            {
                throw new ArgumentNullException(nameof(device));
            }

            var ret = Interop.AudioStreamPolicy.IsStreamOnDevice(Handle, device.Id, out var isOn);
            ret.ThrowIfError("Failed to check stream on device");

            return isOn;
        }

        /// <summary>
        /// Releases all resources used by the <see cref="AudioStreamPolicy"/>.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="AudioStreamPolicy"/>.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        /// <since_tizen> 3 </since_tizen>
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

        #region Static events

        private static bool _isWatchCallbackRegistered;
        private static EventHandler<StreamFocusStateChangedEventArgs> _streamFocusStateChanged;
        private static Interop.AudioStreamPolicy.FocusStateWatchCallback _focusStateWatchCallback;
        private static readonly object _streamFocusEventLock = new object();

        /// <summary>
        /// Occurs when the focus state for stream types is changed regardless of the process.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<StreamFocusStateChangedEventArgs> StreamFocusStateChanged
        {
            add
            {
                lock (_streamFocusEventLock)
                {
                    if (_isWatchCallbackRegistered == false)
                    {
                        RegisterFocusStateWatch();
                        _isWatchCallbackRegistered = true;
                    }
                    _streamFocusStateChanged += value;
                }
            }
            remove
            {
                lock (_streamFocusEventLock)
                {
                    _streamFocusStateChanged -= value;
                }
            }
        }

        private static void RegisterFocusStateWatch()
        {
            _focusStateWatchCallback = (id, options, focusState, reason, extraInfo, _) =>
            {
                _streamFocusStateChanged?.Invoke(null,
                    new StreamFocusStateChangedEventArgs(options, focusState, reason, extraInfo));
            };

            Interop.AudioStreamPolicy.AddFocusStateWatchCallback(
                AudioStreamFocusOptions.Playback | AudioStreamFocusOptions.Recording,
                _focusStateWatchCallback, IntPtr.Zero, out var cbId).
                ThrowIfError("Failed to initialize focus state event");
        }
        #endregion
    }
}
