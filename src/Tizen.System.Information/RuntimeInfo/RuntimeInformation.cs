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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.System
{
    /// <summary>
    /// The RuntimeInformation provides functions to obtain the runtime information of various system preferences.
    /// </summary>
    public static class RuntimeInformation
    {
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_bluetoothEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_wifiHotspotEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_bluetoothTetheringEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_usbTetheringEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_packetDataEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_dataRoamingEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_vibrationEnabled;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_audioJackConnected;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_gpsStatusChanged;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_batteryIsCharging;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_tvOutConnected;
        private static event EventHandler<RuntimeKeyStatusChangedEventArgs> s_audioJackConnectorChanged;
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
            [RuntimeInformationKey.PacketData] = typeof(bool),
            [RuntimeInformationKey.DataRoaming] = typeof(bool),
            [RuntimeInformationKey.Vibration] = typeof(bool),
            [RuntimeInformationKey.AudioJack] = typeof(bool),
            [RuntimeInformationKey.BatteryIsCharging] = typeof(bool),
            [RuntimeInformationKey.TvOut] = typeof(bool),
            [RuntimeInformationKey.Charger] = typeof(bool),
            [RuntimeInformationKey.AutoRotation] = typeof(bool),
            [RuntimeInformationKey.Gps] = typeof(int),
            [RuntimeInformationKey.AudioJackConnector] = typeof(int)
        };

        internal static readonly Dictionary<RuntimeInformationKey, int> s_keyTVkeyMapping = new Dictionary<RuntimeInformationKey, int>
        {
            [RuntimeInformationKey.Bluetooth] = 5,
            [RuntimeInformationKey.WifiHotspot] = 6,
            [RuntimeInformationKey.BluetoothTethering] = 7,
            [RuntimeInformationKey.UsbTethering] = 8,
            [RuntimeInformationKey.PacketData] = 13,
            [RuntimeInformationKey.DataRoaming] = 14,
            [RuntimeInformationKey.Vibration] = 16,
            [RuntimeInformationKey.AudioJack] = 20,
            [RuntimeInformationKey.BatteryIsCharging] = 22,
            [RuntimeInformationKey.TvOut] = 18,
            [RuntimeInformationKey.Charger] = 26,
            [RuntimeInformationKey.AutoRotation] = 28,
            [RuntimeInformationKey.Gps] = 21,
            [RuntimeInformationKey.AudioJackConnector] = 20
        };

        internal static int is_TV_product = -1;

        [EditorBrowsable(EditorBrowsableState.Never)]
        /* This function is for a TV product. It will be removed. */
        internal static RuntimeInformationKey ConvertKeyIfTvProduct(RuntimeInformationKey key)
        {
            bool is_key_existed = false;
            string profile;
            int key_TV = -1;

            if (is_TV_product == -1)
            {
                is_key_existed = SystemInfo.TryGetValue<string>("http://com.samsung/build_config/product_type", out profile);
                if (is_key_existed && String.Compare(profile, "TV") == 0)
                {
                    is_TV_product = 1;
                }
                else
                {
                    is_TV_product = 0;
                }
            }

            if (is_TV_product == 0)
            {
                return key;
            }
            else
            {
                if (!s_keyTVkeyMapping.TryGetValue(key, out key_TV))
                {
                    RuntimeInfoErrorFactory.ThrowException((int)RuntimeInfoError.InvalidParameter);
                }
                return (RuntimeInformationKey)key_TV;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static object GetStatus(RuntimeInformationKey key)
        {
            Type value;
            if (!s_keyDataTypeMapping.TryGetValue(key, out value))
            {
                RuntimeInfoErrorFactory.ThrowException((int)RuntimeInfoError.InvalidParameter);
            }

            if (s_keyDataTypeMapping[key] == typeof(int))
            {
                int status;
                int ret = Interop.RuntimeInfo.GetValue(ConvertKeyIfTvProduct(key), out status);
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
                int ret = Interop.RuntimeInfo.GetValue(ConvertKeyIfTvProduct(key), out status);
                if (ret != (int)RuntimeInfoError.None)
                {
                    Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    RuntimeInfoErrorFactory.ThrowException(ret);
                }

                return status;
            }
        }

        /// <summary>
        /// Validates the data type of the status represented by the runtime key.
        /// Note that this is a generic method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <typeparam name="T">The generic type to validate.</typeparam>
        /// <param name="key">The runtime information key for which the status type is validated.</param>
        /// <returns>True if the data type matches.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
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
        /// Gets the status of runtime key.
        /// Note that this is a generic method.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <typeparam name="T">The generic type to return.</typeparam>
        /// <param name="key">The runtime information key for which the current should be read.</param>
        /// <returns>The current status of the given key.</returns>.
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        /// <exception cref="IOException">Thrown when I/O error occurs while reading from the system.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature related <paramref name="key"/> is not supported.</exception>
        public static T GetStatus<T>(RuntimeInformationKey key)
        {
            return (T)GetStatus(key);
        }

        /// <summary>
        /// (event) BluetoothEnabled is raised when the system preference for Bluetooth is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> BluetoothEnabled
        {
            add
            {
                if (s_bluetoothEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Bluetooth), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Bluetooth));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) WifiHotspotEnabled is raised when the system preference for Wi-Fi is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> WifiHotspotEnabled
        {
            add
            {
                if (s_wifiHotspotEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.WifiHotspot), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.WifiHotspot));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) BluetoothTetheringEnabled is raised when the system preference for bluetooth tethering is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> BluetoothTetheringEnabled
        {
            add
            {
                if (s_bluetoothTetheringEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.BluetoothTethering), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.BluetoothTethering));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) UsbTetheringEnabled is raised when the system preference for USB tethering is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> UsbTetheringEnabled
        {
            add
            {
                if (s_usbTetheringEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.UsbTethering), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.UsbTethering));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) PacketDataEnabled is raised when the system preference for package data through 3G network is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> PacketDataEnabled
        {
            add
            {
                if (s_packetDataEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.PacketData), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.PacketData));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) DataRoamingEnabled is raised when the system preference for data roaming is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> DataRoamingEnabled
        {
            add
            {
                if (s_dataRoamingEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.DataRoaming), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.DataRoaming));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) VibrationEnabled is raised when the system preference for vibration is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> VibrationEnabled
        {
            add
            {
                if (s_vibrationEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Vibration), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Vibration));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) AudioJackConnected is raised when the audio jack is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> AudioJackConnected
        {
            add
            {
                if (s_audioJackConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.AudioJack), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.AudioJack));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) GpsStatusChanged is raised when the status of GPS is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> GpsStatusChanged
        {
            add
            {
                if (s_gpsStatusChanged == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Gps), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Gps));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) BatteryIsCharging is raised when the battery is currently charging.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> BatteryIsCharging
        {
            add
            {
                if (s_batteryIsCharging == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.BatteryIsCharging), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.BatteryIsCharging));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) TvOutConnected is raised when TV out is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> TvOutConnected
        {
            add
            {
                if (s_tvOutConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.TvOut), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.TvOut));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) AudioJackConnectorChanged is raised when the audio jack connection changes.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> AudioJackConnectorChanged
        {
            add
            {
                if (s_audioJackConnectorChanged == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.AudioJackConnector), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.AudioJackConnector));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) ChargerConnected is raised when the charger is connected/disconnected.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> ChargerConnected
        {
            add
            {
                if (s_chargerConnected == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Charger), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.Charger));
                    if (ret != (int)RuntimeInfoError.None)
                    {
                        Log.Error(RuntimeInfoErrorFactory.LogTag, "Interop failed to add event handler");
                        RuntimeInfoErrorFactory.ThrowException(ret);
                    }
                }
            }
        }
        /// <summary>
        /// (event) AutoRotationEnabled is raised when the system preference for auto rotation is changed.
        /// </summary>
        public static event EventHandler<RuntimeKeyStatusChangedEventArgs> AutoRotationEnabled
        {
            add
            {
                if (s_autoRotationEnabled == null)
                {
                    int ret = Interop.RuntimeInfo.SetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.AutoRotation), s_runtimeInfoChangedCallback, IntPtr.Zero);
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
                    int ret = Interop.RuntimeInfo.UnsetRuntimeInfoChangedCallback(ConvertKeyIfTvProduct(RuntimeInformationKey.AutoRotation));
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
