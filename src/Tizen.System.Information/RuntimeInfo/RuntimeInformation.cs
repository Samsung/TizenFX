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
        private static RuntimeInfoEventHandler BluetoothEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.Bluetooth);
        private static RuntimeInfoEventHandler WifiHotspotEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.WifiHotspot);
        private static RuntimeInfoEventHandler BluetoothTetheringEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.BluetoothTethering);
        private static RuntimeInfoEventHandler UsbTetheringEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.UsbTethering);
        private static RuntimeInfoEventHandler PacketDataEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.PacketData);
        private static RuntimeInfoEventHandler DataRoamingEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.DataRoaming);
        private static RuntimeInfoEventHandler VibrationEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.Vibration);
        private static RuntimeInfoEventHandler AudioJackConnected = new RuntimeInfoEventHandler(RuntimeInformationKey.AudioJack);
        private static RuntimeInfoEventHandler GpsStatusChanged = new RuntimeInfoEventHandler(RuntimeInformationKey.Gps);
        private static RuntimeInfoEventHandler BatteryIsCharging = new RuntimeInfoEventHandler(RuntimeInformationKey.BatteryIsCharging);
        private static RuntimeInfoEventHandler TvOutConnected = new RuntimeInfoEventHandler(RuntimeInformationKey.TvOut);
        private static RuntimeInfoEventHandler AudioJackConnectorChanged = new RuntimeInfoEventHandler(RuntimeInformationKey.AudioJackConnector);
        private static RuntimeInfoEventHandler ChargerConnected = new RuntimeInfoEventHandler(RuntimeInformationKey.Charger);
        private static RuntimeInfoEventHandler AutoRotationEnabled = new RuntimeInfoEventHandler(RuntimeInformationKey.AutoRotation);

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

        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static object GetStatus(RuntimeInformationKey key)
        {
            Type value;
            if (!s_keyDataTypeMapping.TryGetValue(key, out value))
            {
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            if (s_keyDataTypeMapping[key] == typeof(int))
            {
                int status;
                InformationError ret = Interop.RuntimeInfo.GetValue(TvProductHelper.ConvertKeyIfTvProduct(key), out status);
                if (ret != InformationError.None)
                {
                    Log.Error(InformationErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    InformationErrorFactory.ThrowException(ret);
                }

                return status;
            }
            else
            {
                bool status;
                InformationError ret = Interop.RuntimeInfo.GetValue(TvProductHelper.ConvertKeyIfTvProduct(key), out status);
                if (ret != InformationError.None)
                {
                    Log.Error(InformationErrorFactory.LogTag, "Interop failed to get value for key {0}", key.ToString());
                    InformationErrorFactory.ThrowException(ret);
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
                Log.Error(InformationErrorFactory.LogTag, "Invalid data type");
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

        [EditorBrowsable(EditorBrowsableState.Never)]
        private static void FindEventHandler(RuntimeInformationKey key, ref RuntimeInfoEventHandler handler)
        {
            switch (key)
            {
                case RuntimeInformationKey.Bluetooth:
                    handler = BluetoothEnabled;
                    break;
                case RuntimeInformationKey.WifiHotspot:
                    handler = WifiHotspotEnabled;
                    break;
                case RuntimeInformationKey.BluetoothTethering:
                    handler = BluetoothTetheringEnabled;
                    break;
                case RuntimeInformationKey.UsbTethering:
                    handler = UsbTetheringEnabled;
                    break;
                case RuntimeInformationKey.PacketData:
                    handler = PacketDataEnabled;
                    break;
                case RuntimeInformationKey.DataRoaming:
                    handler = DataRoamingEnabled;
                    break;
                case RuntimeInformationKey.Vibration:
                    handler = VibrationEnabled;
                    break;
                case RuntimeInformationKey.AudioJack:
                    handler = AudioJackConnected;
                    break;
                case RuntimeInformationKey.Gps:
                    handler = GpsStatusChanged;
                    break;
                case RuntimeInformationKey.BatteryIsCharging:
                    handler = BatteryIsCharging;
                    break;
                case RuntimeInformationKey.TvOut:
                    handler = TvOutConnected;
                    break;
                case RuntimeInformationKey.AudioJackConnector:
                    handler = AudioJackConnectorChanged;
                    break;
                case RuntimeInformationKey.Charger:
                    handler = ChargerConnected;
                    break;
                case RuntimeInformationKey.AutoRotation:
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
        /// <since_tizen> 4 </since_tizen>
        /// <param name="key">The runtime information key which wants to register callback.</param>
        /// <param name="callback">The callback function to subscribe.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature related <paramref name="key"/> is not supported.</exception>
        public static void SetCallback(RuntimeInformationKey key, EventHandler<RuntimeKeyStatusChangedEventArgs> callback)
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
        /// Unegisters a change event callback for given key.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="key">The runtime information key which wants to unregister callback.</param>
        /// <param name="callback">The callback function to unsubscribe.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        public static void UnsetCallback(RuntimeInformationKey key, EventHandler<RuntimeKeyStatusChangedEventArgs> callback)
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
