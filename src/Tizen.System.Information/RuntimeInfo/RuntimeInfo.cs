/*
* Copyright (c) 2016 - 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.System
{
    internal static class RuntimeInfo
    {
        private static RuntimeInfoEventHandler BluetoothEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.Bluetooth);
        private static RuntimeInfoEventHandler WifiHotspotEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.WifiHotspot);
        private static RuntimeInfoEventHandler BluetoothTetheringEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.BluetoothTethering);
        private static RuntimeInfoEventHandler UsbTetheringEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.UsbTethering);
        private static RuntimeInfoEventHandler PacketDataEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.PacketData);
        private static RuntimeInfoEventHandler DataRoamingEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.DataRoaming);
        private static RuntimeInfoEventHandler VibrationEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.Vibration);
        private static RuntimeInfoEventHandler AudioJackConnected = new RuntimeInfoEventHandler(RuntimeInfoKey.AudioJack);
        private static RuntimeInfoEventHandler GpsStatusChanged = new RuntimeInfoEventHandler(RuntimeInfoKey.Gps);
        private static RuntimeInfoEventHandler BatteryIsCharging = new RuntimeInfoEventHandler(RuntimeInfoKey.BatteryIsCharging);
        private static RuntimeInfoEventHandler TvOutConnected = new RuntimeInfoEventHandler(RuntimeInfoKey.TvOut);
        private static RuntimeInfoEventHandler AudioJackConnectorChanged = new RuntimeInfoEventHandler(RuntimeInfoKey.AudioJackConnector);
        private static RuntimeInfoEventHandler ChargerConnected = new RuntimeInfoEventHandler(RuntimeInfoKey.Charger);
        private static RuntimeInfoEventHandler AutoRotationEnabled = new RuntimeInfoEventHandler(RuntimeInfoKey.AutoRotation);

        internal static readonly Dictionary<RuntimeInfoKey, Type> s_keyDataTypeMapping = new Dictionary<RuntimeInfoKey, Type>
        {
            [RuntimeInfoKey.Bluetooth] = typeof(bool),
            [RuntimeInfoKey.WifiHotspot] = typeof(bool),
            [RuntimeInfoKey.BluetoothTethering] = typeof(bool),
            [RuntimeInfoKey.UsbTethering] = typeof(bool),
            [RuntimeInfoKey.PacketData] = typeof(bool),
            [RuntimeInfoKey.DataRoaming] = typeof(bool),
            [RuntimeInfoKey.Vibration] = typeof(bool),
            [RuntimeInfoKey.AudioJack] = typeof(bool),
            [RuntimeInfoKey.BatteryIsCharging] = typeof(bool),
            [RuntimeInfoKey.TvOut] = typeof(bool),
            [RuntimeInfoKey.Charger] = typeof(bool),
            [RuntimeInfoKey.AutoRotation] = typeof(bool),
            [RuntimeInfoKey.Gps] = typeof(int),
            [RuntimeInfoKey.AudioJackConnector] = typeof(int)
        };

        /// <summary>
        /// Validates the data type of the status represented by the runtime key.
        /// Note that this is a generic method.
        /// </summary>
        /// <typeparam name="T">The generic type to validate.</typeparam>
        /// <param name="key">The runtime information key for which the status type is validated.</param>
        /// <returns>True if the data type matches.</returns>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        internal static bool Is<T>(RuntimeInfoKey key)
        {
            if (!s_keyDataTypeMapping.ContainsKey(key))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid data type");
                throw new ArgumentException("Invalid parameter");
            }

            return s_keyDataTypeMapping[key] == typeof(T);
        }

        /// <summary>
        /// Gets the status of runtime key.
        /// Note that this is a generic method.
        /// </summary>
        /// <typeparam name="T">The generic type to return.</typeparam>
        /// <param name="key">The runtime information key for which the current should be read.</param>
        /// <param name="value">The value of the given feature.</param>
        /// <returns>Returns true on success, otherwise false.</returns>
        internal static bool TryGetValue<T>(RuntimeInfoKey key, out T value)
        {
            Type type;
            value = default(T);

            if (!s_keyDataTypeMapping.TryGetValue(key, out type))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid key");
                return false;
            }

            if (type == typeof(bool))
            {
                InformationError ret = Interop.RuntimeInfo.GetValue(key, out bool val);

                if (ret != InformationError.None)
                {
                    Log.Error(InformationErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    return false;
                }

                value = (T)(object)val;
            }
            else if(type == typeof(int))
            {
                InformationError ret = Interop.RuntimeInfo.GetValue(key, out int val);

                if (ret != InformationError.None)
                {
                    Log.Error(InformationErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    return false;
                }

                value = (T)(object)val;
            }

            return true;
        }

        private static void FindEventHandler(RuntimeInfoKey key, ref RuntimeInfoEventHandler handler)
        {
            switch (key)
            {
                case RuntimeInfoKey.Bluetooth:
                    handler = BluetoothEnabled;
                    break;
                case RuntimeInfoKey.WifiHotspot:
                    handler = WifiHotspotEnabled;
                    break;
                case RuntimeInfoKey.BluetoothTethering:
                    handler = BluetoothTetheringEnabled;
                    break;
                case RuntimeInfoKey.UsbTethering:
                    handler = UsbTetheringEnabled;
                    break;
                case RuntimeInfoKey.PacketData:
                    handler = PacketDataEnabled;
                    break;
                case RuntimeInfoKey.DataRoaming:
                    handler = DataRoamingEnabled;
                    break;
                case RuntimeInfoKey.Vibration:
                    handler = VibrationEnabled;
                    break;
                case RuntimeInfoKey.AudioJack:
                    handler = AudioJackConnected;
                    break;
                case RuntimeInfoKey.Gps:
                    handler = GpsStatusChanged;
                    break;
                case RuntimeInfoKey.BatteryIsCharging:
                    handler = BatteryIsCharging;
                    break;
                case RuntimeInfoKey.TvOut:
                    handler = TvOutConnected;
                    break;
                case RuntimeInfoKey.AudioJackConnector:
                    handler = AudioJackConnectorChanged;
                    break;
                case RuntimeInfoKey.Charger:
                    handler = ChargerConnected;
                    break;
                case RuntimeInfoKey.AutoRotation:
                    handler = AutoRotationEnabled;
                    break;
                default:
                    handler = null;
                    break;
            }
        }

        /// <summary>
        /// Registers a change event callback for given key.
        /// </summary>
        /// <param name="key">The runtime information key which wants to register callback.</param>
        /// <param name="callback">The callback function to subscribe.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature related <paramref name="key"/> is not supported.</exception>
        internal static void SetCallback(RuntimeInfoKey key, EventHandler<RuntimeFeatureStatusChangedEventArgs> callback)
        {
            RuntimeInfoEventHandler handler = null;

            FindEventHandler(key, ref handler);
            if (handler == null)
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid key");
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            handler.EventHandler += callback;
        }

        /// <summary>
        /// Unregisters a change event callback for given key.
        /// </summary>
        /// <param name="key">The runtime information key which wants to unregister callback.</param>
        /// <param name="callback">The callback function to unsubscribe.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        internal static void UnsetCallback(RuntimeInfoKey key, EventHandler<RuntimeFeatureStatusChangedEventArgs> callback)
        {
            RuntimeInfoEventHandler handler = null;

            FindEventHandler(key, ref handler);
            if (handler == null)
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid key");
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            handler.EventHandler -= callback;
        }
    }
}
