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
        private static int _deviceConnectedCounter = 0;
        private static int _deviceInformationChanged = 0;

        private static Interop.SoundDeviceConnectedCallback _audioDeviceConnectedCallback;
        private static Interop.SoundDeviceInformationChangedCallback _audioDeviceInformationChangedCallback;

        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _audioDeviceConnected;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _stateActivatedDeviceConnected;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _stateDeactivatedDeviceConnected;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _typeExternalDeviceConnected;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _typeInternalDeviceConnected;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _ioDirectionInDeviceConnected;
        private static EventHandler<AudioDeviceConnectionChangedEventArgs> _ioDirectionOutDeviceConnected;

        private static EventHandler<AudioDevicePropertyChangedEventArgs> _audioDeviceInformationChanged;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _stateActivatedDeviceInformationChanged;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _stateDeactivatedDeviceInformationChanged;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _typeExternalDeviceInformationChanged;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _typeInternalDeviceInformationChanged;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _ioDirectionInDeviceInformationChanged;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _ioDirectionOutDeviceInformationChanged;

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
                if (_audioDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.All);
                    Tizen.Log.Info(AudioManagerLog.Tag, "DeviceConnectionChanged event registered");
                }
                _deviceConnectedCounter++;
                _audioDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _audioDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "DeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the connection of an activated audio device is changed.
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> ActivatedDeviceConnectionChanged
        {
            add
            {
                if (_stateActivatedDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.Activated);
                }
                _deviceConnectedCounter++;
                _stateActivatedDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "ActivatedDeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _stateActivatedDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "ActivatedDeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the connection of an deactivated audio device is changed
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> DeactivatedDeviceConnectionChanged
        {
            add
            {
                if (_stateDeactivatedDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.Deactivated);
                }
                _deviceConnectedCounter++;
                _stateDeactivatedDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeactivatedDeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _stateDeactivatedDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "DeactivatedDeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the connection of an external audio device is changed
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> ExternalDeviceConnectionChanged
        {
            add
            {
                if (_typeExternalDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.External);
                }
                _deviceConnectedCounter++;
                _typeExternalDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "ExternalDeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _typeExternalDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "ExternalDeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the connection of an internal audio device is changed
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> InternalDeviceConnectionChanged
        {
            add
            {
                if (_typeInternalDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.Internal);
                }
                _deviceConnectedCounter++;
                _typeInternalDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "InternalDeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _typeInternalDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "InternalDeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the connection of an input audio device is changed.
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> InputDeviceConnectionChanged
        {
            add
            {
                if (_ioDirectionInDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.Input);
                }
                _deviceConnectedCounter++;
                _ioDirectionInDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "InputDeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _ioDirectionInDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "InputDeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the connection of an output audio device is changed
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionChangedEventArgs> OutputDeviceConnectionChanged
        {
            add
            {
                if (_ioDirectionOutDeviceConnected == null)
                {
                    RegisterAudioDeviceEvent(AudioDeviceOptions.Output);
                }
                _deviceConnectedCounter++;
                _ioDirectionOutDeviceConnected += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "OutputDeviceConnectionChanged event added");
            }
            remove
            {
                _deviceConnectedCounter--;
                _ioDirectionOutDeviceConnected -= value;
                if (_deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "OutputDeviceConnectionChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of an Audio sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> DevicePropertyChanged
        {
            add
            {
                if (_audioDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.All);
                }
                _deviceInformationChanged++;
                _audioDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _audioDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "DevicePropertyChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of a activated audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> ActivatedDevicePropertyChanged
        {
            add
            {
                if (_stateActivatedDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.Activated);
                }
                _deviceInformationChanged++;
                _stateActivatedDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "ActivatedDevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _stateActivatedDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "ActivatedDevicePropertyChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of a deactivated audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> DeactivatedDevicePropertyChanged
        {
            add
            {
                if (_stateDeactivatedDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.Deactivated);
                }
                _deviceInformationChanged++;
                _stateDeactivatedDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "DeactivatedDevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _stateDeactivatedDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "DeactivatedDeviceProperty Changed event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of a external audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> ExternalDevicePropertyChanged
        {
            add
            {
                if (_typeExternalDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.External);
                }
                _deviceInformationChanged++;
                _typeExternalDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "ExternalDevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _typeExternalDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "ExternalDevicePropertyChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of a internal audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> InternalDevicePropertyChanged
        {
            add
            {
                if (_typeInternalDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.Internal);
                }
                _deviceInformationChanged++;
                _typeInternalDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "InternalDevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _typeInternalDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "InternalDevicePropertyChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of a input audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> InputDevicePropertyChanged
        {
            add
            {
                if (_ioDirectionInDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.Input);
                }
                _deviceInformationChanged++;
                _ioDirectionInDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "InputDevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _ioDirectionInDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "InputDevicePropertyChanged event removed");
            }
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the property of a output audio device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> OutputDevicePropertyChanged
        {
            add
            {
                if (_ioDirectionOutDeviceInformationChanged == null)
                {
                    RegisterDeviceInformationChangedEvent(AudioDeviceOptions.Output);
                }
                _deviceInformationChanged++;
                _ioDirectionOutDeviceInformationChanged += value;
                Tizen.Log.Info(AudioManagerLog.Tag, "OutputDevicePropertyChanged event added");
            }
            remove
            {
                _deviceInformationChanged--;
                _ioDirectionOutDeviceInformationChanged -= value;
                if (_deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }
                Tizen.Log.Info(AudioManagerLog.Tag, "OutputDevicePropertyChanged event removed");
            }
        }

        /// <summary>
        /// The VolumeController object (singleton) is-a part of SoundManager and its properties and methods are used via AudioManager
        /// </summary>
        public static AudioVolume VolumeController
        {
            get;
            private set;
        }

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

        private static void RegisterAudioDeviceEvent(AudioDeviceOptions option)
        {
            _audioDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                int audioOption = (int) userData;

                AudioDeviceConnectionChangedEventArgs eventArgs = new AudioDeviceConnectionChangedEventArgs(new AudioDevice(device), isConnected);

                switch ((AudioDeviceOptions)audioOption)
                {
                    case AudioDeviceOptions.All:
                        _audioDeviceConnected?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Activated:
                        _stateActivatedDeviceConnected?.Invoke(null, eventArgs); ;
                        break;
                    case AudioDeviceOptions.Deactivated:
                        _stateDeactivatedDeviceConnected?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.External:
                        _typeExternalDeviceConnected?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Internal:
                        _typeInternalDeviceConnected?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Input:
                        _ioDirectionInDeviceConnected?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Output:
                        _ioDirectionOutDeviceConnected?.Invoke(null, eventArgs);
                        break;
                    default:
                        return;
                }
            };
            int ret = Interop.AudioDevice.SetDeviceConnectedCallback(option, _audioDeviceConnectedCallback, (IntPtr) option);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set device connected callback");
            Tizen.Log.Info(AudioManagerLog.Tag, "AudioDeviceConnected Event registered");
        }

        private static void RegisterDeviceInformationChangedEvent(AudioDeviceOptions option)
        {
            _audioDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                int audioOption = (int)userData;

                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);

                switch ((AudioDeviceOptions)audioOption)
                {
                    case AudioDeviceOptions.All:
                        _audioDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Activated:
                        _stateActivatedDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Deactivated:
                        _stateDeactivatedDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.External:
                        _typeExternalDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Internal:
                        _typeInternalDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Input:
                        _ioDirectionInDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    case AudioDeviceOptions.Output:
                        _ioDirectionOutDeviceInformationChanged?.Invoke(null, eventArgs);
                        break;
                    default:
                        return;
                }
            };
            int ret = Interop.AudioDevice.SetDeviceInformationChangedCallback(option, _audioDeviceInformationChangedCallback, (IntPtr) option);
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set device property changed callback");
            Tizen.Log.Info(AudioManagerLog.Tag, "AudioDevicePropertyChangedEvent callback registered");
        }

        private static void UnregisterDeviceConnectedEvent()
        {
            int ret = Interop.AudioDevice.UnsetDeviceConnectedCallback();
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to unset device connected callback");
            Tizen.Log.Info(AudioManagerLog.Tag, "AudioDeviceConnectedEvent callback unregistered");
        }

        private static void UnregisterDeviceInformationChangedEvent()
        {
            int ret = Interop.AudioDevice.UnsetDeviceInformationChangedCallback();
            AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to unset device property changed callback");
            Tizen.Log.Info(AudioManagerLog.Tag, "AudioDevicePropertyChanged callback unregistered");
        }
    }
}
