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
    internal static class AudioManagerLog
    {
        internal const string Tag = "Tizen.Multimedia.AudioManager";
    }

    /// <summary>
    /// The Audio Manager class provides functions to get and set sound parameters like volume and devices.
    /// </summary>
    public static class AudioManager
    {
        private static int _deviceConnectionChangedCallbackId = -1;
        private static int _deviceStateChangedCallbackId = -1;

        private static Interop.SoundDeviceConnectionChangedCallback _audioDeviceConnectionChangedCallback;
        private static Interop.SoundDeviceStateChangedCallback _audioDeviceStateChangedCallback;

        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _audioDeviceConnectionChanged;
        private static EventHandler<AudioDeviceStateChangedEventArgs> _audioDeviceStateChanged;

        /// <summary>
        /// Constructor for AudioManager. Initializes the VolumeController property etc.
        /// </summary>
        static AudioManager()
        {
            VolumeController = new AudioVolume();
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of an Audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> DeviceConnectionChanged
        {
            add
            {
                if (_audioDeviceConnectionChanged == null)
                {
                    RegisterAudioDeviceEvent();
                    Tizen.Log.Info(AudioManagerLog.Tag, "DeviceConnectionChanged event registered");
                }
                _audioDeviceConnectionChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeviceConnectionChanged event added");
            }
            remove
            {
                if (_audioDeviceConnectionChanged?.GetInvocationList()?.GetLength(0) == 1)
                {
                    UnregisterDeviceConnectionChangedEvent();
                }
                _audioDeviceConnectionChanged -= value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the state of an Audio sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDeviceStateChangedEventArgs> DeviceStateChanged
        {
            add
            {
                if (_audioDeviceStateChanged == null)
                {
                    RegisterDeviceStateChangedEvent();
                }
                _audioDeviceStateChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeviceStateChanged event added");
            }
            remove
            {
                if (_audioDeviceStateChanged?.GetInvocationList()?.GetLength(0) == 1)
                {
                    UnregisterDeviceStateChangedEvent();
                }
                _audioDeviceStateChanged -= value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeviceStateChanged event removed");
            }
        }

        /// <summary>
        /// The VolumeController object (singleton) is-a part of SoundManager and its properties and methods are used via AudioManager
        /// </summary>
        public static AudioVolume VolumeController { get; }

        /// <summary>
        /// Gets the list consisting of all devices currently connected.
        /// </summary>
        /// <param name="options">The audio device options</param>
        /// <returns>The list of connected devices: IEnumerable of Device objects</returns>
        public static IEnumerable<AudioDevice> GetCurrentDevices(AudioDeviceOptions options)
        {
            List<AudioDevice> audioDeviceList = new List<AudioDevice>();
            IntPtr deviceListHandle;
            IntPtr handlePosition;
            int ret = Interop.AudioDevice.GetCurrentDeviceList(options, out deviceListHandle);
            if (ret != (int)AudioManagerError.NoData)
            {
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get next device");
            }
            while (ret == (int)AudioManagerError.None)
            {
                ret = Interop.AudioDevice.GetNextDevice(deviceListHandle, out handlePosition);
                if (ret == (int)AudioManagerError.None)
                {
                    audioDeviceList.Add(new AudioDevice(handlePosition));
                }
                else if (ret != (int)AudioManagerError.NoData)
                {
                    AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get next device");
                }
            }
            return audioDeviceList;
        }

        private static void RegisterAudioDeviceEvent()
        {
            _audioDeviceConnectionChangedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionChangedEventArgs eventArgs = new AudioDeviceConnectionChangedEventArgs(new AudioDevice(device), isConnected);
                _audioDeviceConnectionChanged?.Invoke(null, eventArgs);
            };
            int ret = Interop.AudioDevice.AddDeviceConnectionChangedCallback(AudioDeviceOptions.All, _audioDeviceConnectionChangedCallback, IntPtr.Zero, out _deviceConnectionChangedCallbackId);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to add device connection changed callback");
            Tizen.Log.Info(AudioManagerLog.Tag, "AudioDeviceConnectionChanged Event registered");
        }

        private static void RegisterDeviceStateChangedEvent()
        {
            _audioDeviceStateChangedCallback = (IntPtr device, AudioDeviceState changedState, IntPtr userData) =>
            {
                AudioDeviceStateChangedEventArgs eventArgs = new AudioDeviceStateChangedEventArgs(new AudioDevice(device), changedState);
                _audioDeviceStateChanged?.Invoke(null, eventArgs);
            };
            int ret = Interop.AudioDevice.AddDeviceStateChangedCallback(AudioDeviceOptions.All, _audioDeviceStateChangedCallback, IntPtr.Zero, out _deviceStateChangedCallbackId);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to add device state changed callback");
            Tizen.Log.Info(AudioManagerLog.Tag, "AudioDeviceStateChangedEvent callback registered");
        }

        private static void UnregisterDeviceConnectionChangedEvent()
        {
            if (_deviceConnectionChangedCallbackId > 0)
            {
                int ret = Interop.AudioDevice.RemoveDeviceConnectionChangedCallback(_deviceConnectionChangedCallbackId);
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to remove device connection changed callback");
                Tizen.Log.Info(AudioManagerLog.Tag, "AudioDeviceConnectionChangedEvent callback unregistered");
                _deviceConnectionChangedCallbackId = -1;
            }
        }

        private static void UnregisterDeviceStateChangedEvent()
        {
            if (_deviceStateChangedCallbackId > 0)
            {
                int ret = Interop.AudioDevice.RemoveDeviceStateChangedCallback(_deviceStateChangedCallbackId);
                AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to remove device state changed callback");
                Tizen.Log.Info(AudioManagerLog.Tag, "AudioDeviceStateChanged callback unregistered");
                _deviceStateChangedCallbackId = -1;
            }
        }
    }
}
