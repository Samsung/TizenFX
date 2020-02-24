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
    /// <since_tizen> 3 </since_tizen>
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
        /// <since_tizen> 3 </since_tizen>
        public static AudioVolume VolumeController { get; }

        /// <summary>
        /// Gets the all devices currently connected.
        /// </summary>
        /// <returns>An IEnumerable&lt;AudioDevice&gt; that contains connected devices.</returns>
        /// <since_tizen> 4 </since_tizen>
        public static IEnumerable<AudioDevice> GetConnectedDevices()
        {
            IntPtr deviceListHandle = IntPtr.Zero;

            try
            {
                var ret = Interop.AudioDevice.GetDeviceList(AudioDeviceOptions.All, out deviceListHandle);

                if (ret == AudioManagerError.NoData)
                {
                    return new List<AudioDevice>();
                }

                ret.ThrowIfError("Failed to get connected devices");

                return RetrieveDevices();
            }
            finally
            {
                Interop.AudioDevice.FreeDeviceList(deviceListHandle);
            }

            IEnumerable<AudioDevice> RetrieveDevices()
            {
                var result = new List<AudioDevice>();

                while (true)
                {
                    var ret = Interop.AudioDevice.GetNextDevice(deviceListHandle, out var deviceHandle);

                    if (ret == AudioManagerError.NoData)
                    {
                        break;
                    }

                    ret.ThrowIfError("Failed to get connected devices");

                    result.Add(new AudioDevice(deviceHandle));
                }
                return result;
            }
        }

        #region DeviceConnectionChanged event
        private static int _deviceConnectionChangedCallbackId = -1;

        private static Interop.AudioDevice.ConnectionChangedCallback _audioDeviceConnectionChangedCallback;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _audioDeviceConnectionChanged;
        private static readonly object _audioDeviceConnectionLock = new object();

        /// <summary>
        /// Occurs when the state of a connection of an audio device changes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> DeviceConnectionChanged
        {
            add
            {
                if (value == null)
                {
                    return;
                }

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
            _audioDeviceConnectionChangedCallback = (device, isConnected, _) =>
            {
                _audioDeviceConnectionChanged?.Invoke(null,
                    new AudioDeviceConnectionChangedEventArgs(new AudioDevice(device), isConnected));
            };

            Interop.AudioDevice.AddDeviceConnectionChangedCallback(AudioDeviceOptions.All,
                _audioDeviceConnectionChangedCallback, IntPtr.Zero, out _deviceConnectionChangedCallbackId).
                ThrowIfError("Unable to add device connection changed callback");
        }

        private static void UnregisterDeviceConnectionChangedEvent()
        {
            Interop.AudioDevice.RemoveDeviceConnectionChangedCallback(_deviceConnectionChangedCallbackId).
                ThrowIfError("Unable to remove device connection changed callback");
        }
        #endregion

        #region DeviceRunningStateChanged event
        private static int _deviceRunningChangedCallbackId = -1;
        private static Interop.AudioDevice.RunningChangedCallback _audioDeviceRunningChangedCallback;
        private static EventHandler<AudioDeviceRunningChangedEventArgs> _audioDeviceRunningChanged;
        private static readonly object _audioDeviceRunningLock = new object();

        /// <summary>
        /// Occurs when the audio stream started actually to run on the device.
        /// </summary>
        /// <remarks>
        /// If this event is invoked once and the audio stream is still running on the device,<br/>
        /// this event will not be invoked anymore, even if there are more audio streams to run.<br/>
        /// This event is invoked only when all streams are stopped and a new stream starts to run.
        /// </remarks>
        /// <exception cref="InvalidOperationException">
        /// AudioManager failed to communicate internally or allocate memory.
        /// </exception>
        /// <since_tizen> 5 </since_tizen>
        public static event EventHandler<AudioDeviceRunningChangedEventArgs> DeviceRunningChanged
        {
            add
            {
                if (value == null)
                {
                    return;
                }
                lock (_audioDeviceRunningLock)
                {
                    if (_audioDeviceRunningChanged == null)
                    {
                        RegisterDeviceRunningChangedEvent();
                    }
                    _audioDeviceRunningChanged += value;
                }
            }
            remove
            {
                if (value == null)
                {
                    return;
                }
                lock (_audioDeviceRunningLock)
                {
                    _audioDeviceRunningChanged -= value;
                    if (_audioDeviceRunningChanged == null)
                    {
                        UnregisterDeviceRunningChangedEvent();
                    }
                }
            }
        }

        private static void RegisterDeviceRunningChangedEvent()
        {
            _audioDeviceRunningChangedCallback = (device, isRunning, _) =>
            {
                _audioDeviceRunningChanged?.Invoke(null,
                    new AudioDeviceRunningChangedEventArgs(new AudioDevice(device), isRunning));
            };
            Interop.AudioDevice.AddDeviceRunningChangedCallback(AudioDeviceOptions.All,
               _audioDeviceRunningChangedCallback, IntPtr.Zero, out _deviceRunningChangedCallbackId).
               ThrowIfError("Failed to add DeviceRunningChanged event");
        }

        private static void UnregisterDeviceRunningChangedEvent()
        {
            Interop.AudioDevice.RemoveDeviceRunningChangedCallback(_deviceRunningChangedCallbackId).
                ThrowIfError("Failed to remove DeviceRunningChanged event");
        }
        #endregion
    }
}
