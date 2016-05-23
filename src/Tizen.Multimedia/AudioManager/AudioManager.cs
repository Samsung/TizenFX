using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.Multimedia
{
    /// <summary>
    /// The Audio Manager API provides functions to get and set sound parameters like volume, stream policy, session policy and devices.
    /// </summary>
    public static class AudioManager
    {
        private static int _deviceConnectedCounter = 0;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _audioDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _audioDeviceConnectedCallback;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _stateActivatedDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _stateActivatedDeviceConnectedCallback;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _stateDeactivatedDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _stateDeactivatedDeviceConnectedCallback;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _typeExternalDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _typeExternalDeviceConnectedCallback;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _typeInternalDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _typeInternalDeviceConnectedCallback;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _ioDirectionInDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _ioDirectionInDeviceConnectedCallback;
        private static EventHandler<AudioDeviceConnectionStateChangedEventArgs> _ioDirectionOutDeviceConnected;
        private static Interop.SoundDeviceConnectedCallback _ioDirectionOutDeviceConnectedCallback;


        private static int _deviceInformationChanged = 0;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _audioDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _audioDeviceInformationChangedCallback;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _stateActivatedDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _stateActivatedDeviceInformationChangedCallback;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _stateDeactivatedDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _stateDeactivatedDeviceInformationChangedCallback;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _typeExternalDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _typeExternalDeviceInformationChangedCallback;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _typeInternalDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _typeInternalDeviceInformationChangedCallback;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _ioDirectionInDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _ioDirectionInDeviceInformationChangedCallback;
        private static EventHandler<AudioDevicePropertyChangedEventArgs> _ioDirectionOutDeviceInformationChanged;
        private static Interop.SoundDeviceInformationChangedCallback _ioDirectionOutDeviceInformationChangedCallback;


        /// <summary>
        /// The VolumeController object (singleton) is-a part of SoundManager and its properties and methods are used via AudioManager
        /// </summary>
        public static Volume VolumeController
        {
            get;
            internal set;
        }

        /// <summary>
        /// Constructor for AudioManager. Initializes the VolumeController property etc.
        /// </summary>
        static AudioManager()
        {
            VolumeController = new Volume();
        }

        /*/// <summary>
        /// Destructor for SoundManager. Frees the DeviceList and all devices in it etc.
        /// </summary>
        ~AudioManager()
        {

        }*/

        /// <summary>
        /// Gets the list consisting of all devices currently connected. 
        /// </summary>
        /// <param name="deviceListFilter">The mask value</param>
        /// <returns>The list of connected devices: IEnumerable of Device objects</returns>
        public static IEnumerable<AudioDevice> GetCurrentDevices(AudioDeviceOptions options)
        {
            List<AudioDevice> audioDeviceList = new List<AudioDevice>();
            IntPtr deviceListHandle;
            IntPtr handlePosition;
            int ret = Interop.Device.GetCurrentDeviceList(options, out deviceListHandle);
			if (ret != (int)AudioManagerError.NoData)
			{
				AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get next device");
			}

            while (ret == (int)AudioManagerError.None)
            {
                ret = Interop.Device.GetNextDevice(deviceListHandle, out handlePosition);
                if (ret == (int)AudioManagerError.None)
                {
                    audioDeviceList.Add(new AudioDevice(handlePosition));
                }
				else if (ret != (int)AudioManagerError.NoData)
				{
					AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to get next device");
				}
            }

            //ret = Interop.Device.FreeDeviceList(deviceListHandle);
            //if (ret != 0)
            //{
            //    //throws exception
            //}

            return audioDeviceList;
            // return new AudioDeviceCollection(options);
        }


        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of an Audio device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> DeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("Audio Device Connected Event added....");
                if (_audioDeviceConnected == null)
                {
                    RegisterAudioDeviceConnectedEvent();
                    Console.WriteLine("Audio Device Connected Event Registered....");
                }
                _deviceConnectedCounter++;
                _audioDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("Audio Device Connected Event removed");
                _deviceConnectedCounter--;
                _audioDeviceConnected -= value;
                if (_audioDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterAudioDeviceConnectedEvent()
        {
            _audioDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _audioDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.All, _audioDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }


        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of a StateActivated sound device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> ActivatedDeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_stateActivatedDeviceConnected == null)
                {
                    RegisterStateActivatedDeviceConnectedEvent();
                }
                _deviceConnectedCounter++;
                _stateActivatedDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceConnectedCounter--;
                _stateActivatedDeviceConnected -= value;
                if (_stateActivatedDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterStateActivatedDeviceConnectedEvent()
        {
            _stateActivatedDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _stateActivatedDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.Activated, _stateActivatedDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set activated device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }


        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of a StateDeactivated sound device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> DeactivatedDeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_stateDeactivatedDeviceConnected == null)
                {
                    RegisterStateDeactivatedDeviceConnectedEvent();
                }
                _deviceConnectedCounter++;
                _stateDeactivatedDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceConnectedCounter--;
                _stateDeactivatedDeviceConnected -= value;
                if (_stateDeactivatedDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterStateDeactivatedDeviceConnectedEvent()
        {
            _stateDeactivatedDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _stateDeactivatedDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.Deactivated, _stateDeactivatedDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set deactivated device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }


        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of a TypeExternal sound device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> ExternalDeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_typeExternalDeviceConnected == null)
                {
                    RegisterTypeExternalDeviceConnectedEvent();
                }
                _deviceConnectedCounter++;
                _typeExternalDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceConnectedCounter--;
                _typeExternalDeviceConnected -= value;
                if (_typeExternalDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterTypeExternalDeviceConnectedEvent()
        {
            _typeExternalDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _typeExternalDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.External, _typeExternalDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set external device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of a TypeInternal sound device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> InternalDeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_typeInternalDeviceConnected == null)
                {
                    RegisterTypeInternalDeviceConnectedEvent();
                }
                _deviceConnectedCounter++;
                _typeInternalDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceConnectedCounter--;
                _typeInternalDeviceConnected -= value;
                if (_typeInternalDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterTypeInternalDeviceConnectedEvent()
        {
            _typeInternalDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _typeInternalDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.Internal, _typeInternalDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set internal device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of a IoDirectionIn sound device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> InputDeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_ioDirectionInDeviceConnected == null)
                {
                    RegisterIoDirectionInDeviceConnectedEvent();
                }
                _deviceConnectedCounter++;
                _ioDirectionInDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceConnectedCounter--;
                _ioDirectionInDeviceConnected -= value;
                if (_ioDirectionInDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterIoDirectionInDeviceConnectedEvent()
        {
            _ioDirectionInDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _ioDirectionInDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.Input, _ioDirectionInDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set input device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a function to be invoked when the state of connection of a IoDirectionOut sound device was changed. 
        /// </summary>
        public static event EventHandler<AudioDeviceConnectionStateChangedEventArgs> OutputDeviceConnectionStateChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_ioDirectionOutDeviceConnected == null)
                {
                    RegisterIoDirectionOutDeviceConnectedEvent();
                }
                _deviceConnectedCounter++;
                _ioDirectionOutDeviceConnected += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceConnectedCounter--;
                _ioDirectionOutDeviceConnected -= value;
                if (_ioDirectionOutDeviceConnected == null && _deviceConnectedCounter == 0)
                {
                    UnregisterDeviceConnectedEvent();
                }

            }
        }

        public static void RegisterIoDirectionOutDeviceConnectedEvent()
        {
            _ioDirectionOutDeviceConnectedCallback = (IntPtr device, bool isConnected, IntPtr userData) =>
            {
                AudioDeviceConnectionStateChangedEventArgs eventArgs = new AudioDeviceConnectionStateChangedEventArgs(new AudioDevice(device), isConnected);
                _ioDirectionOutDeviceConnected.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceConnectedCallback(AudioDeviceOptions.Output, _ioDirectionOutDeviceConnectedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set output device connected callback");
            Console.WriteLine("Device connected Event return:" + ret);
        }

        /// <summary>
        /// Unregister for Deivce Connected event
        /// </summary>
        public static void UnregisterDeviceConnectedEvent()
        {
            int ret = Interop.Device.UnsetDeviceConnectedCallback();
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to unset device connected callback");
            Console.WriteLine("Device connected unregister event return:" + ret);

        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of an Audio sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> DevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_audioDeviceInformationChanged == null)
                {
                    RegisterAudioDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _audioDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _audioDeviceInformationChanged -= value;
                if (_audioDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterAudioDeviceInformationChangedEvent()
        {
            _audioDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _audioDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.All, _audioDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of a StateActivated sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> ActivatedDevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_stateActivatedDeviceInformationChanged == null)
                {
                    RegisterStateActivatedDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _stateActivatedDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _stateActivatedDeviceInformationChanged -= value;
                if (_stateActivatedDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterStateActivatedDeviceInformationChangedEvent()
        {
            _stateActivatedDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _stateActivatedDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.Activated, _stateActivatedDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set activated device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of a StateDeactivated sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> DeactivatedDevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_stateDeactivatedDeviceInformationChanged == null)
                {
                    RegisterStateDeactivatedDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _stateDeactivatedDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _stateDeactivatedDeviceInformationChanged -= value;
                if (_stateDeactivatedDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterStateDeactivatedDeviceInformationChangedEvent()
        {
            _stateDeactivatedDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _stateDeactivatedDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.Deactivated, _stateDeactivatedDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set deactivated device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of a TypeExternal sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> ExternalDevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_typeExternalDeviceInformationChanged == null)
                {
                    RegisterTypeExternalDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _typeExternalDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _typeExternalDeviceInformationChanged -= value;
                if (_typeExternalDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterTypeExternalDeviceInformationChangedEvent()
        {
            _typeExternalDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _typeExternalDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.External, _typeExternalDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set external device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of a TypeInternal sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> InternalDevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_typeInternalDeviceInformationChanged == null)
                {
                    RegisterTypeInternalDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _typeInternalDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _typeInternalDeviceInformationChanged -= value;
                if (_typeInternalDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterTypeInternalDeviceInformationChangedEvent()
        {
            _typeInternalDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _typeInternalDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.Internal, _typeInternalDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set internal device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of a IoDirectionIn sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> InputDevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_ioDirectionInDeviceInformationChanged == null)
                {
                    RegisterIoDirectionInDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _ioDirectionInDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _ioDirectionInDeviceInformationChanged -= value;
                if (_ioDirectionInDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterIoDirectionInDeviceInformationChangedEvent()
        {
            _ioDirectionInDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _ioDirectionInDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.Input, _ioDirectionInDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set input device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Registers/Unregisters a callback function to be invoked when the information of a IoDirectionOut sound device was changed.
        /// </summary>
        public static event EventHandler<AudioDevicePropertyChangedEventArgs> OutputDevicePropertyChanged
        {
            add
            {
                Console.WriteLine("VolumeController Changed Event added....");
                if (_ioDirectionOutDeviceInformationChanged == null)
                {
                    RegisterIoDirectionOutDeviceInformationChangedEvent();
                }
                _deviceInformationChanged++;
                _ioDirectionOutDeviceInformationChanged += value;
            }
            remove
            {
                Console.WriteLine("VolumeController Changed Event removed");
                _deviceInformationChanged--;
                _ioDirectionOutDeviceInformationChanged -= value;
                if (_ioDirectionOutDeviceInformationChanged == null && _deviceInformationChanged == 0)
                {
                    UnregisterDeviceInformationChangedEvent();
                }

            }
        }

        public static void RegisterIoDirectionOutDeviceInformationChangedEvent()
        {
            _ioDirectionOutDeviceInformationChangedCallback = (IntPtr device, AudioDeviceProperty property, IntPtr userData) =>
            {
                AudioDevicePropertyChangedEventArgs eventArgs = new AudioDevicePropertyChangedEventArgs(new AudioDevice(device), property);
                _ioDirectionOutDeviceInformationChanged.Invoke(null, eventArgs);
            };
            int ret = Interop.Device.SetDeviceInformationChangedCallback(AudioDeviceOptions.Output, _ioDirectionOutDeviceInformationChangedCallback, IntPtr.Zero);
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to set output device information changed callback");
            Console.WriteLine("Device Inforamtion Changed Event return:" + ret);
        }

        /// <summary>
        /// Unregister for Device Information Changed Event
        /// </summary>
        public static void UnregisterDeviceInformationChangedEvent()
        {
            int ret = Interop.Device.UnsetDeviceInformationChangedCallback();
			AudioManagerErrorFactory.CheckAndThrowException(ret, "Unable to unset device information changed callback");
            Console.WriteLine("Device information Changed unregister event return:" + ret);

        }
    }


}
