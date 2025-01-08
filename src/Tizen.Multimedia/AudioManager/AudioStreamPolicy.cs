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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides functionalities to control and manage sound streams within an application.
    /// The <see cref="AudioStreamPolicy"/> class enables developers to set policies for
    /// playback and recording audio streams, adjusting settings for focus and routing,
    /// as well as configuring audio devices and sound effects.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class AudioStreamPolicy : IDisposable
    {
        private AudioStreamPolicyHandle _handle;
        private bool _disposed = false;
        private Interop.AudioStreamPolicy.FocusStateChangedCallback _focusStateChangedCallback;
        private static AudioDevice _inputDevice = null;
        private static AudioDevice _outputDevice = null;
        private const string Tag = "Tizen.Multimedia.AudioStreamPolicy";

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
        /// Occurs when the state of focus for the current <see cref="AudioStreamPolicy"/> changes.
        /// This event allows subscribers to react to changes in audio focus state,
        /// helping to manage audio playback or recording effectively.
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
        /// <exception cref="InvalidOperationException">
        ///     A device has not been set.<br/>
        ///     -or-<br/>
        ///     An internal error occurs.
        /// </exception>
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
        /// Gets or sets the preferred input device.
        /// </summary>
        /// <value>
        /// The <see cref="AudioDevice"/> instance.<br/>
        /// The default is null which means any device is not set on this property.
        /// </value>
        /// <remarks>
        /// This property is to set a specific built-in device when the system has multiple devices of the same built-in device type.
        /// When there's only one device for a built-in device type in the system, nothing will happen even if this property is set successfully.
        /// </remarks>
        /// <exception cref="ArgumentException">A device is not for input.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="AudioPolicyException">A device is not supported by this <see cref="AudioStreamPolicy"/> instance.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <seealso cref="AudioManager.GetConnectedDevices()"/>
        /// <since_tizen> 6 </since_tizen>
        public AudioDevice PreferredInputDevice
        {
            get
            {
                /* This P/Invoke intends to validate if the core audio system
                 * is normal. Otherwise, it'll throw an error here. */
                Interop.AudioStreamPolicy.GetPreferredDevice(Handle, out var inDeviceId, out _).
                    ThrowIfError("Failed to get preferred input device");

                Log.Debug(Tag, $"preferred input device id:{inDeviceId}");

                return _inputDevice;
            }
            set
            {
                Interop.AudioStreamPolicy.SetPreferredDevice(Handle, AudioDeviceIoDirection.Input, value?.Id ?? 0).
                    ThrowIfError("Failed to set preferred input device");

                _inputDevice = value;
            }
        }

        /// <summary>
        /// Gets or sets the preferred output device.
        /// </summary>
        /// <value>
        /// The <see cref="AudioDevice"/> instance.<br/>
        /// The default is null which means any device is not set on this property.
        /// </value>
        /// <remarks>
        /// This property is to set a specific built-in device when the system has multiple devices of the same built-in device type.
        /// When there's only one device for a built-in device type in the system, nothing will happen even if this property is set successfully.
        /// </remarks>
        /// <exception cref="ArgumentException">A device is not for output.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="AudioPolicyException">A device is not supported by this <see cref="AudioStreamPolicy"/> instance.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <seealso cref="AudioManager.GetConnectedDevices()"/>
        /// <since_tizen> 6 </since_tizen>
        public AudioDevice PreferredOutputDevice
        {
            get
            {
                /* This P/Invoke intends to validate if the core audio system
                 * is normal. Otherwise, it'll throw an error here. */
                Interop.AudioStreamPolicy.GetPreferredDevice(Handle, out _, out var outDeviceId).
                    ThrowIfError("Failed to get preferred output device");

                Log.Debug(Tag, $"preferred output device id:{outDeviceId}");

                return _outputDevice;
            }
            set
            {
                Interop.AudioStreamPolicy.SetPreferredDevice(Handle, AudioDeviceIoDirection.Output, value?.Id ?? 0).
                    ThrowIfError("Failed to set preferred output device");

                _outputDevice = value;
            }
        }

        /// <summary>
        /// Checks if any stream from the current AudioStreamPolicy is using the device.
        /// </summary>
        /// <returns>true if any audio stream from the current AudioStreamPolicy is using the device; otherwise, false.</returns>
        /// <param name="device">The device to be checked.</param>
        /// <remarks>
        /// The AudioStreamPolicy can be applied to each playback or recording stream via other API set.
        /// (For example., <see cref="T:Tizen.Multimedia.Player"/>, <see cref="T:Tizen.Multimedia.WavPlayer"/>,
        /// <see cref="T:Tizen.Multimedia.AudioPlayback"/>, <see cref="T:Tizen.Multimedia.AudioCapture"/>, etc.)
        /// This method returns true only when the device is used for the stream which meets to the two conditions.
        /// One is that the current AudioStreamPolicy sets a audio route path to the device and the other is that the playback
        /// or recording stream from other API set should have already started to prepare or to play.(It depends on the API set.)
        /// </remarks>
        /// <exception cref="ArgumentNullException"><paramref name="device"/> is null.</exception>
        /// <exception cref="InvalidOperationException">An internal error occurs.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed of.</exception>
        /// <seealso cref="AudioManager.GetConnectedDevices()"/>
        /// <since_tizen> 6 </since_tizen>
        public bool HasStreamOnDevice(AudioDevice device)
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
        /// Sets the sound effect.
        /// </summary>
        /// <remarks>
        /// If <paramref name="withReference"/> is true, <paramref name="info.Type"/> must be <see cref="SoundEffectType.ReferenceCopy"/> or
        /// <see cref="SoundEffectType.AecSpeex"/> or <see cref="SoundEffectType.AecWebrtc"/>.
        /// And <paramref name="info.ReferenceDevice"/> must not be null.<br/>
        /// If <paramref name="withReference"/> is false, <paramref name="info.Type"/> must be <see cref="SoundEffectType.NoiseSuppression"/> or
        /// <see cref="SoundEffectType.AutoGainControl"/> or <see cref="SoundEffectType.NsWithAgc"/>.
        /// </remarks>
        /// <param name="info">See <see cref="SoundEffectInfo"/>.</param>
        /// <param name="withReference">A reference device for sound effect.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="withReference"/> is true, A reference device is null.</exception>
        /// <exception cref="AudioPolicyException">The current <see cref="AudioStreamType"/> is not supported for sound effect with reference.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed.</exception>
        /// <since_tizen> 12 </since_tizen>
        public void SetSoundEffect(SoundEffectInfo info, bool withReference)
        {
            if (withReference)
            {
                var set = new SoundEffectType[] { SoundEffectType.ReferenceCopy, SoundEffectType.AecSpeex, SoundEffectType.AecWebrtc };
                if (!set.Contains(info.Type))
                {
                    Log.Error(Tag, $"Type={info.Type} is not supported for setting with reference.");
                    throw new ArgumentException($"{info.Type} is not supported for setting with reference.");
                }
                if (info.ReferenceDevice == null)
                {
                    throw new ArgumentNullException(nameof(info.ReferenceDevice));
                }

                Log.Info(Tag, $"{info.ReferenceDevice}");

                Interop.AudioStreamPolicy.SetSoundEffectWithReference(Handle, (SoundEffectWithReferenceNative)info.Type.ToNative(),
                    info.ReferenceDevice.Id).ThrowIfError("Failed to set audio effect with reference");
            }
            else
            {
                var set = new SoundEffectType[] { SoundEffectType.NoiseSuppression, SoundEffectType.AutoGainControl, SoundEffectType.NsWithAgc };
                if (!set.Contains(info.Type))
                {
                    throw new ArgumentException($"{info.Type} is not supported for setting without reference.");
                }

                Interop.AudioStreamPolicy.SetSoundEffect(Handle, info.Type.ToNative()).
                    ThrowIfError("Failed to set sound effect with reference");
            }
        }

        /// <summary>
        /// Gets the sound effect.
        /// </summary>
        /// <remarks>
        /// If <paramref name="withReference"/> is false, <see cref="SoundEffectInfo.ReferenceDevice"/> of returned value will be null.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// The sound effect is not set yet.<br/>
        /// - or -<br/>
        /// There's no matched AudioDevice.
        /// </exception>
        /// <exception cref="InvalidOperationException">Sound effect is not set yet.</exception>
        /// <exception cref="ObjectDisposedException">The <see cref="AudioStreamPolicy"/> has already been disposed.</exception>
        /// <since_tizen> 12 </since_tizen>
        public SoundEffectInfo GetSoundEffect(bool withReference)
        {
            AudioManagerError ret = AudioManagerError.None;
            SoundEffectInfo soundEffectInfo;
            int deviceId = 0;

            if (withReference)
            {
                ret = Interop.AudioStreamPolicy.GetSoundEffectWithReference(Handle, out SoundEffectWithReferenceNative nativeEffect, out deviceId);
                if (ret == AudioManagerError.InvalidParameter)
                {
                    throw new InvalidOperationException("There's no sound effect with reference");
                }
                ret.ThrowIfError("Failed to get sound effect with reference");

                Log.Info(Tag, $"Device ID : {deviceId}");

                soundEffectInfo = new SoundEffectInfo(nativeEffect.ToPublic(),
                    AudioManager.GetConnectedDevices().Where(d => d.Id == deviceId).Single());
            }
            else
            {
                ret = Interop.AudioStreamPolicy.GetSoundEffect(Handle, out int nativeEffect);
                if (ret == AudioManagerError.InvalidParameter)
                {
                    throw new InvalidOperationException("There's no sound effect");
                }
                ret.ThrowIfError("Failed to get sound effect");

                soundEffectInfo = new SoundEffectInfo(((SoundEffectNative)nativeEffect).ToPublic());
            }

            return soundEffectInfo;
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
