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

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides the ability to control volume levels and monitor audio devices.
    /// </summary>
    public static class AudioManager
    {
        static AudioManager()
        {
            VolumeController = new AudioVolume();
        }

        /// <summary>
        /// Gets the volume controller.
        /// </summary>
        /// <value>The <see cref="AudioVolume"/>.</value>
        public static AudioVolume VolumeController { get; }

        /// <summary>
        /// Gets the all devices currently connected.
        /// </summary>
        /// <returns>An IEnumerable&lt;AudioDevice&gt; that contains connected devices.</returns>
        public static IEnumerable<AudioDevice> GetConnectedDevices()
        {
            IntPtr deviceListHandle = IntPtr.Zero;

            try
            {
                var ret = Interop.AudioDevice.GetDeviceList(AudioDeviceOptions.All, out deviceListHandle);

                List<AudioDevice> result = new List<AudioDevice>();

                if (ret == AudioManagerError.NoData)
                {
                    return result;
                }

                ret.Validate("Failed to get connected devices");

                while (ret == AudioManagerError.None)
                {
                    ret = Interop.AudioDevice.GetNextDevice(deviceListHandle, out var deviceHandle);

                    if (ret == AudioManagerError.NoData)
                    {
                        break;
                    }

                    ret.Validate("Failed to get connected devices");

                    result.Add(new AudioDevice(deviceHandle));
                }
                return result;
            }
            finally
            {
                Interop.AudioDevice.FreeDeviceList(deviceListHandle);
            }
        }

        #region DeviceConnectionChanged event
        private static int _deviceConnectionChangedCallbackId = -1;

        private static Interop.AudioDevice.ConnectionChangedCallback _audioDeviceConnectionChangedCallback;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _audioDeviceConnectionChanged;
        private static object _audioDeviceConnectionLock = new object();

        /// <summary>
        /// Occurs when the state of connection of an audio device changes.
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> DeviceConnectionChanged
        {
            add
            {
                lock (_audioDeviceConnectionLock)
                {
                    if (_audioDeviceConnectionChanged == null)
                    {
                        RegisterAudioDeviceEvent();
                    }
                    _audioDeviceConnectionChanged += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }

                lock (_audioDeviceConnectionLock)
                {
                    if (_audioDeviceConnectionChanged == value)
                    {
                        UnregisterDeviceConnectionChangedEvent();
                    }
                    _audioDeviceConnectionChanged -= value;
                }
            }
        }

        private static void RegisterAudioDeviceEvent()
        {
            _audioDeviceConnectionChangedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                _audioDeviceConnectionChanged?.Invoke(null,
                    new AudioDeviceConnectionChangedEventArgs(new AudioDevice(device), isConnected));
            };

            Interop.AudioDevice.AddDeviceConnectionChangedCallback(AudioDeviceOptions.All,
                _audioDeviceConnectionChangedCallback, IntPtr.Zero, out _deviceConnectionChangedCallbackId).
                Validate("Unable to add device connection changed callback");
        }

        private static void UnregisterDeviceConnectionChangedEvent()
        {
            Interop.AudioDevice.RemoveDeviceConnectionChangedCallback(_deviceConnectionChangedCallbackId).
                Validate("Unable to remove device connection changed callback");
        }
        #endregion

        #region DeviceStateChanged event
        private static int _deviceStateChangedCallbackId = -1;

        private static Interop.AudioDevice.StateChangedCallback _audioDeviceStateChangedCallback;
        private static EventHandler<AudioDeviceStateChangedEventArgs> _audioDeviceStateChanged;
        private static object _audioDeviceStateLock = new object();

        /// <summary>
        /// Occurs when the state of an audio device changes.
        /// </summary>
        public static event EventHandler<AudioDeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                lock (_audioDeviceStateLock)
                {
                    if (_audioDeviceStateChanged == null)
                    {
                        RegisterDeviceStateChangedEvent();
                    }
                    _audioDeviceStateChanged += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }

                lock (_audioDeviceStateLock)
                {
                    if (_audioDeviceStateChanged == value)
                    {
                        UnregisterDeviceStateChangedEvent();
                    }
                    _audioDeviceStateChanged -= value;
                }
            }
        }

        private static void RegisterDeviceStateChangedEvent()
        {
            _audioDeviceStateChangedCallback = (IntPtr device, AudioDeviceState changedState, IntPtr userData) =>
            {
                _audioDeviceStateChanged?.Invoke(null,
                    new AudioDeviceStateChangedEventArgs(new AudioDevice(device), changedState));
            };

            Interop.AudioDevice.AddDeviceStateChangedCallback(AudioDeviceOptions.All,
                _audioDeviceStateChangedCallback, IntPtr.Zero, out _deviceStateChangedCallbackId).
                Validate("Failed to add device state changed event");
        }

        private static void UnregisterDeviceStateChangedEvent()
        {
            Interop.AudioDevice.RemoveDeviceStateChangedCallback(_deviceStateChangedCallbackId).
                Validate("Failed to remove device state changed event");
        }
        #endregion
    }
}
