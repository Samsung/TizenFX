/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tizen.System
{
    /// <summary>
    /// The RuntimeInformation provides functions to obtain runtime information of various system preferences.
    /// </summary>
    public static class RuntimeInformation
    {
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_bluetoothEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_wifiHotspotEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_bluetoothTetheringEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_usbTetheringEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_locationServiceEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_locationNetworkPositionEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_packetDataEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_dataRoamingEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_vibrationEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_audioJackConnected;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_gpsStatusChanged;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_batteryIsCharging;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_tvOutConnected;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_audioJackConnectorChanged;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_usbConnected;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_chargerConnected;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_autoRotationEnabled;

        private static readonly Interop.RuntimeInfo.RuntimeInformationChangedCallback s_runtimeInfoChangedCallback = (RuntimeInformationKey key, IntPtr userData) =>
        {
            RuntimeKeyStatusChangedEventArgs eventArgs = new RuntimeKeyStatusChangedEventArgs()
            {
                Key = key
            };
            switch (key)
            {
                case RuntimeInformationKey.Bluetooth:
                    {
                        s_bluetoothEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.WifiHotspot:
                    {
                        s_wifiHotspotEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.BluetoothTethering:
                    {
                        s_bluetoothTetheringEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.UsbTethering:
                    {
                        s_usbTetheringEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.LocationService:
                    {
                        s_locationServiceEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.LocationNetworkPosition:
                    {
                        s_locationNetworkPositionEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.PacketData:
                    {
                        s_packetDataEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.DataRoaming:
                    {
                        s_dataRoamingEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.Vibration:
                    {
                        s_vibrationEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.AudioJack:
                    {
                        s_audioJackConnected?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.Gps:
                    {
                        s_gpsStatusChanged?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.BatteryIsCharging:
                    {
                        s_batteryIsCharging?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.TvOut:
                    {
                        s_tvOutConnected?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.AudioJackConnector:
                    {
                        s_audioJackConnectorChanged?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.Usb:
                    {
                        s_usbConnected?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.Charger:
                    {
                        s_chargerConnected?.Invoke(null, eventArgs);
                        break;
                    };
                case RuntimeInformationKey.AutoRotation:
                    {
                        s_autoRotationEnabled?.Invoke(null, eventArgs);
                        break;
                    };
                default:
                    break;
            };
        };

        internal static readonly Dictionary<RuntimeInformationKey, Type> s_keyDataTypeMapping = new Dictionary<RuntimeInformationKey, Type>
        {
            [RuntimeInformationKey.Bluetooth] = typeof(bool),
            [RuntimeInformationKey.WifiHotspot] = typeof(bool),
            [RuntimeInformationKey.BluetoothTethering] = typeof(bool),
            [RuntimeInformationKey.UsbTethering] = typeof(bool),
            [RuntimeInformationKey.LocationService] = typeof(bool),
            [RuntimeInformationKey.LocationNetworkPosition] = typeof(bool),
            [RuntimeInformationKey.PacketData] = typeof(bool),
            [RuntimeInformationKey.DataRoaming] = typeof(bool),
            [RuntimeInformationKey.Vibration] = typeof(bool),
            [RuntimeInformationKey.AudioJack] = typeof(bool),
            [RuntimeInformationKey.BatteryIsCharging] = typeof(bool),
            [RuntimeInformationKey.TvOut] = typeof(bool),
            [RuntimeInformationKey.Usb] = typeof(bool),
            [RuntimeInformationKey.Charger] = typeof(bool),
            [RuntimeInformationKey.AutoRotation] = typeof(bool),
            [RuntimeInformationKey.Gps] = typeof(int),
            [RuntimeInformationKey.AudioJackConnector] = typeof(int)
        };

        /// <summary>
        /// This function gets current state of the given key which represents specific runtime information
        /// </summary>
        /// <param name="key">The runtime information key for which the current should be read </param>
        /// <returns>The current status of the given key</returns>
        internal static object GetStatus(RuntimeInformationKey key)
        {
            if (s_keyDataTypeMapping[key] == typeof(int))
            {
                int status;
                int ret = Interop.RuntimeInfo.GetValue(key, out status);
                if (ret != (int)RuntimeInfoError.None)
                {
                    Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    RuntimeInfoErrorFactory.ThrowException(ret);
                }

                return status;
            }
            else
            {
                bool status;
                int ret = Interop.RuntimeInfo.GetValue(key, out status);
                if (ret != (int)RuntimeInfoError.None)
                {
                    Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    RuntimeInfoErrorFactory.ThrowException(ret);
                }

                return status;
            }
        }

        /// <summary>
        /// Validates the data type of the status represented by Runtime Key.
        /// Note that this is a generic method.
        /// </summary>
        /// <typeparam name="T">The generic type to validate.</typeparam>
        /// <param name="key">The runtime information key for which the status type is validated </param>
        /// <returns>true if the data type matches</returns>.
        public static bool Is<T>(RuntimeInformationKey key)
        {
            if (!s_keyDataTypeMapping.ContainsKey(key))
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Invalid data type");
                throw new ArgumentException("Invalid parameter");
            }

            return s_keyDataTypeMapping[key] == typeof(T);
        }

        /// <summary>
        /// Gets the status of Runtime Key.
        /// Note that this is a generic method.
        /// </summary>
        /// <typeparam name="T">The generic type to return.</typeparam>
        /// <param name="key">The runtime information key for which the current should be read </param>
        /// <returns>The current status of the given key</returns>.
        public static T GetStatus<T>(RuntimeInformationKey key)
        {
            return (T)GetStatus(key);
        }

        /// <summary>
        /// The System memory information
        /// </summary>
        public static SystemMemoryInformation GetSystemMemoryInformation()
        {
            Interop.RuntimeInfo.MemoryInfo info = new Interop.RuntimeInfo.MemoryInfo();
            int ret = Interop.RuntimeInfo.GetSystemMemoryInfo(out info);
            if (ret != (int)RuntimeInfoError.None)
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get System memory information");
                RuntimeInfoErrorFactory.ThrowException(ret);
            }

            return new SystemMemoryInformation(info);
        }

        /// <summary>
        /// Gets memory information per processes
        /// </summary>
        /// <param name="pid">List of unique process ids </param>
        /// <returns>List of memory information per processes</returns>
        public static IDictionary<int, ProcessMemoryInformation> GetProcessMemoryInformation(IEnumerable<int> pid)
        {
            int[] processArray = pid.ToArray<int>();
            Interop.RuntimeInfo.ProcessMemoryInfo[] processMemoryArray = new Interop.RuntimeInfo.ProcessMemoryInfo[pid.Count<int>()];
            Dictionary<int, ProcessMemoryInformation> map = new Dictionary<int, ProcessMemoryInformation>();
            int ret = Interop.RuntimeInfo.GetProcessMemoryInfo(processArray, pid.Count<int>(), out processMemoryArray);
            if (ret != (int)RuntimeInfoError.None)
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get Process memory information");
                RuntimeInfoErrorFactory.ThrowException(ret);
            }

            int idx = 0;
            foreach (Interop.RuntimeInfo.ProcessMemoryInfo cur in processMemoryArray)
            {
                ProcessMemoryInformation processMemory = new ProcessMemoryInformation(cur);
                map.Add(processArray[idx], processMemory);
                idx++;
            }

            return map;
        }

        /// <summary>
        /// The CPU runtime
        /// </summary>
        public static CpuUsage GetCpuUsage()
        {
            Interop.RuntimeInfo.CpuUsage usage = new Interop.RuntimeInfo.CpuUsage();
            int ret = Interop.RuntimeInfo.GetCpuUsage(out usage);
            if (ret != (int)RuntimeInfoError.None)
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get cpu usage");
                RuntimeInfoErrorFactory.ThrowException(ret);
            }
            return new CpuUsage(usage);
        }

        /// <summary>
        /// The CPU run time per process
        /// </summary>
        /// <param name="pid">List of unique process ids </param>
        /// <returns>List of CPU usage information per processes</returns>
        public static IDictionary<int, ProcessCpuUsage> GetProcessCpuUsage(IEnumerable<int> pid)
        {
            int[] processArray = pid.ToArray<int>();
            Interop.RuntimeInfo.ProcessCpuUsage[] processCpuUsageArray = new Interop.RuntimeInfo.ProcessCpuUsage[pid.Count<int>()];
            Dictionary<int, ProcessCpuUsage> map = new Dictionary<int, ProcessCpuUsage>();
            int ret = Interop.RuntimeInfo.GetProcessCpuUsage(processArray, pid.Count<int>(), out processCpuUsageArray);
            if (ret != (int)RuntimeInfoError.None)
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get Process cpu usage");
                RuntimeInfoErrorFactory.ThrowException(ret);
            }

            int idx = 0;
            foreach (Interop.RuntimeInfo.ProcessCpuUsage cur in processCpuUsageArray)
            {
                ProcessCpuUsage processUsage = new ProcessCpuUsage(cur);
                map.Add(processArray[idx], processUsage);
                idx++;
            }

            return map;
        }

        /// <summary>
        /// The number of processors
        /// </summary>
        public static int ProcessorCount
        {
            get
            {
                int count;
                int ret = Interop.RuntimeInfo.GetProcessorCount(out count);
                if (ret != (int)RuntimeInfoError.None)
                {
                    Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get Processor count");
                    RuntimeInfoErrorFactory.ThrowException(ret);
                }

                return count;
            }
        }

        /// <summary>
        /// Gets the current frequency of processor
        /// </summary>
        /// <param name="coreId">The index (from 0) of CPU core that you want to know the frequency</param>
        /// <returns>The current frequency(MHz) of processor</returns>
        public static int GetProcessorCurrentFrequency(int coreId)
        {
            int frequency;
            int ret = Interop.RuntimeInfo.GetProcessorCurrentFrequency(coreId, out frequency);
            if (ret != (int)RuntimeInfoError.None)
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get Processor current frequency");
                RuntimeInfoErrorFactory.ThrowException(ret);
            }
            return frequency;
        }

        /// <summary>
        /// Gets the max frequency of processor
        /// </summary>
        /// <param name="coreId">The index (from 0) of CPU core that you want to know the frequency</param>
        /// <returns>The max frequency(MHz) of processor</returns>
        public static int GetProcessorMaxFrequency(int coreId)
        {
            int frequency;
            int ret = Interop.RuntimeInfo.GetProcessorMaxFrequency(coreId, out frequency);
            if (ret != (int)RuntimeInfoError.None)
            {
                Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get  Processor max frequency");
                RuntimeInfoErrorFactory.ThrowException(ret);
            }
            return frequency;
        }

        /// <summary>
        /// (event) BluetoothEnabled is rasied when system preference for bluetooth is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> BluetoothEnabled
        {
            add
            {
                if (s_bluetoothEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.Bluetooth, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_bluetoothEnabled += value;
            }
            remove
            {
                s_bluetoothEnabled -= value;
                if (s_bluetoothEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.Bluetooth);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) WifiHotspotEnabled is rasied when system preference for Wi-Fi is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> WifiHotspotEnabled
        {
            add
            {
                if (s_wifiHotspotEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.WifiHotspot, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_wifiHotspotEnabled += value;
            }
            remove
            {
                s_wifiHotspotEnabled -= value;
                if (s_wifiHotspotEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.WifiHotspot);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) BluetoothTetheringEnabled is rasied when system preference for bluetooth tethering is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> BluetoothTetheringEnabled
        {
            add
            {
                if (s_bluetoothTetheringEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.BluetoothTethering, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_bluetoothTetheringEnabled += value;
            }
            remove
            {
                s_bluetoothTetheringEnabled -= value;
                if (s_bluetoothTetheringEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.BluetoothTethering);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) UsbTetheringEnabled is rasied when system preference for USB terhering is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> UsbTetheringEnabled
        {
            add
            {
                if (s_usbTetheringEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.UsbTethering, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_usbTetheringEnabled += value;
            }
            remove
            {
                s_usbTetheringEnabled -= value;
                if (s_usbTetheringEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.UsbTethering);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) LocationServiceEnabled is rasied when system preference for location service is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> LocationServiceEnabled
        {
            add
            {
                if (s_locationServiceEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.LocationService, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_locationServiceEnabled += value;
            }
            remove
            {
                s_locationServiceEnabled -= value;
                if (s_locationServiceEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.LocationService);
                    RuntimeInfoErrorFactory.ThrowException(ret);
                }
            }
        }
        /// <summary>
        /// (event) LocationNetworkPositionEnabled is rasied when system preference for allowing location service to use location data from cellular and Wi-Fi is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> LocationNetworkPositionEnabled
        {
            add
            {
                if (s_locationNetworkPositionEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.LocationNetworkPosition, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_locationNetworkPositionEnabled += value;
            }
            remove
            {
                s_locationNetworkPositionEnabled -= value;
                if (s_locationNetworkPositionEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.LocationNetworkPosition);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) PacketDataEnabled is rasied when system preference for package data through 3G network is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> PacketDataEnabled
        {
            add
            {
                if (s_packetDataEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.PacketData, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_packetDataEnabled += value;
            }
            remove
            {
                s_packetDataEnabled -= value;
                if (s_packetDataEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.PacketData);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) DataRoamingEnabled is rasied when system preference for data roaming is changed.

        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> DataRoamingEnabled
        {
            add
            {
                if (s_dataRoamingEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.DataRoaming, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_dataRoamingEnabled += value;
            }
            remove
            {
                s_dataRoamingEnabled -= value;
                if (s_dataRoamingEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.DataRoaming);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) VibrationEnabled is rasied when system preference for vibration is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> VibrationEnabled
        {
            add
            {
                if (s_vibrationEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.Vibration, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_vibrationEnabled += value;
            }
            remove
            {
                s_vibrationEnabled -= value;
                if (s_vibrationEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.Vibration);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) AudioJackConnected is rasied when audio jack is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> AudioJackConnected
        {
            add
            {
                if (s_audioJackConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.AudioJack, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_audioJackConnected += value;
            }
            remove
            {
                s_audioJackConnected -= value;
                if (s_audioJackConnected == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.AudioJack);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) GpsStatusChanged is rasied when status of GPS is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> GpsStatusChanged
        {
            add
            {
                if (s_gpsStatusChanged == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.Gps, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_gpsStatusChanged += value;
            }
            remove
            {
                s_gpsStatusChanged -= value;
                if (s_gpsStatusChanged == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.Gps);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) BatteryIsCharging is rasied battery is currently charging.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> BatteryIsCharging
        {
            add
            {
                if (s_batteryIsCharging == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.BatteryIsCharging, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_batteryIsCharging += value;
            }
            remove
            {
                s_batteryIsCharging -= value;
                if (s_batteryIsCharging == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.BatteryIsCharging);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) TvOutConnected is rasied when TV out is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> TvOutConnected
        {
            add
            {
                if (s_tvOutConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.TvOut, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_tvOutConnected += value;
            }
            remove
            {
                s_tvOutConnected -= value;
                if (s_tvOutConnected == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.TvOut);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) AudioJackConnectorChanged is rasied when audio jack connection changes.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> AudioJackConnectorChanged
        {
            add
            {
                if (s_audioJackConnectorChanged == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.AudioJackConnector, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_audioJackConnectorChanged += value;
            }
            remove
            {
                s_audioJackConnectorChanged -= value;
                if (s_audioJackConnectorChanged == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.AudioJackConnector);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) UsbConnected is rasied when USB is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> UsbConnected
        {
            add
            {
                if (s_usbConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.Usb, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_usbConnected += value;
            }
            remove
            {
                s_usbConnected -= value;
                if (s_usbConnected == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.Usb);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) ChargerConnected is rasied when charger is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> ChargerConnected
        {
            add
            {
                if (s_chargerConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.Charger, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_chargerConnected += value;
            }
            remove
            {
                s_chargerConnected -= value;
                if (s_chargerConnected == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.Charger);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) AutoRotationEnabled is rasied when system preference for auto rotaion is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> AutoRotationEnabled
        {
            add
            {
                if (s_autoRotationEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(RuntimeInformationKey.AutoRotation, s_runtimeInfoChangedCallback, IntPtr.Zero);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
                s_autoRotationEnabled += value;
            }
            remove
            {
                s_autoRotationEnabled -= value;
                if (s_autoRotationEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(RuntimeInformationKey.AutoRotation);
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
    }
}
