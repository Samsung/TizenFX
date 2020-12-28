/*
* Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.System
{
    /// <summary>
    /// The Information class provides functions to obtain various system information.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class Information
    {
        internal const string HttpPrefix = "http://";
        internal const string RuntimeInfoStringKeyPrefix = "tizen.org/runtimefeature/";

        internal const string RuntimeInfoStringKeyBluetooth = "bluetooth";
        internal const string RuntimeInfoStringKeyTetheringWiFi = "tethering.wifi";
        internal const string RuntimeInfoStringKeyTetheringBluetooth = "tethering.bluetooth";
        internal const string RuntimeInfoStringKeyTetheringUsb = "tethering.usb";
        internal const string RuntimeInfoStringKeyPacketData = "packetdata";
        internal const string RuntimeInfoStringKeyDataRoaming = "dataroaming";
        internal const string RuntimeInfoStringKeyVibration = "vibration";
        internal const string RuntimeInfoStringKeyAudioJackConnected = "audiojack.connected";
        internal const string RuntimeInfoStringKeyBatteryCharging = "battery.charging";
        internal const string RuntimeInfoStringKeyTvOut = "tvout";
        internal const string RuntimeInfoStringKeyCharger = "charger";
        internal const string RuntimeInfoStringKeyAutoRotation = "autorotation";
        internal const string RuntimeInfoStringKeyGps = "gps";
        internal const string RuntimeInfoStringKeyAudioJackType = "audiojack.type";


        private static readonly Dictionary<string, RuntimeInfoKey> StringEnumMapping = new Dictionary<string, RuntimeInfoKey>
        {
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyBluetooth] = RuntimeInfoKey.Bluetooth,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyTetheringWiFi] = RuntimeInfoKey.WifiHotspot,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyTetheringBluetooth] = RuntimeInfoKey.BluetoothTethering,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyTetheringUsb] = RuntimeInfoKey.UsbTethering,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyPacketData] = RuntimeInfoKey.PacketData,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyDataRoaming] = RuntimeInfoKey.DataRoaming,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyVibration] = RuntimeInfoKey.Vibration,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyAudioJackConnected] = RuntimeInfoKey.AudioJack,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyBatteryCharging] = RuntimeInfoKey.BatteryIsCharging,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyTvOut] = RuntimeInfoKey.TvOut,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyCharger] = RuntimeInfoKey.Charger,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyAutoRotation] = RuntimeInfoKey.AutoRotation,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyGps] = RuntimeInfoKey.Gps,
            [RuntimeInfoStringKeyPrefix + RuntimeInfoStringKeyAudioJackType] = RuntimeInfoKey.AudioJackConnector
        };

        internal static readonly Dictionary<RuntimeInfoKey, string> EnumStringMapping = new Dictionary<RuntimeInfoKey, string>
        {
            [RuntimeInfoKey.Bluetooth] = RuntimeInfoStringKeyBluetooth,
            [RuntimeInfoKey.WifiHotspot] = RuntimeInfoStringKeyTetheringWiFi,
            [RuntimeInfoKey.BluetoothTethering] = RuntimeInfoStringKeyTetheringBluetooth,
            [RuntimeInfoKey.UsbTethering] = RuntimeInfoStringKeyTetheringUsb,
            [RuntimeInfoKey.PacketData] = RuntimeInfoStringKeyPacketData,
            [RuntimeInfoKey.DataRoaming] = RuntimeInfoStringKeyDataRoaming,
            [RuntimeInfoKey.Vibration] = RuntimeInfoStringKeyVibration,
            [RuntimeInfoKey.AudioJack] = RuntimeInfoStringKeyAudioJackConnected,
            [RuntimeInfoKey.BatteryIsCharging] = RuntimeInfoStringKeyBatteryCharging,
            [RuntimeInfoKey.TvOut] = RuntimeInfoStringKeyTvOut,
            [RuntimeInfoKey.Charger] = RuntimeInfoStringKeyCharger,
            [RuntimeInfoKey.AutoRotation] = RuntimeInfoStringKeyAutoRotation,
            [RuntimeInfoKey.Gps] = RuntimeInfoStringKeyGps,
            [RuntimeInfoKey.AudioJackConnector] = RuntimeInfoStringKeyAudioJackType
        };

        private static bool ConvertStringToRuntimeInfoKey(string key, out RuntimeInfoKey feature)
        {
            string filteredKey = key.StartsWith(HttpPrefix) ? key.Substring(HttpPrefix.Length) : key;
            feature = default(RuntimeInfoKey);

            return StringEnumMapping.TryGetValue(filteredKey, out feature);
        }

        private static bool TryGetRuntimeInfoValue<T>(RuntimeInfoKey key, out T value)
        {
            value = default(T);

            if (!RuntimeInfo.Is<T>(key))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid return type");
                return false;
            }

            return RuntimeInfo.TryGetValue<T>(key, out value);
        }

#pragma warning disable CS0618 // Type or member is obsolete
        private static bool TryGetSystemInfoValue<T>(string key, out T value)
        {
            value = default(T);

            if (!SystemInfo.IsValidKey(key))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid key");
                return false;
            }

            if (!SystemInfo.Is<T>(key))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid return type");
                return false;
            }

            return SystemInfo.TryGetValue<T>(key, out value);
        }
#pragma warning restore CS0618 // Type or member is obsolete

        /// <summary>
        /// Gets the value of the feature.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <typeparam name="T">The type of <paramref name="value"/>.</typeparam>
        /// <param name="key">The name of the feature.</param>
        /// <param name="value">The value of the given feature.</param>
        /// <returns>Returns true on success, otherwise false.</returns>
        public static bool TryGetValue<T>(string key, out T value)
        {
            RuntimeInfoKey runtimeFeature;

            if (ConvertStringToRuntimeInfoKey(key, out runtimeFeature))
            {
                return TryGetRuntimeInfoValue<T>(runtimeFeature, out value);
            }
            else
            {
                return TryGetSystemInfoValue<T>(key, out value);
            }
        }

        /// <summary>
        /// Registers a change event callback for given runtime feature key.
        /// </summary>
        /// <remarks>
        /// This function is only for runtime feature.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="key">The name of runtime feature which wants to register callback.</param>
        /// <param name="callback">The callback function to subscribe.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature related <paramref name="key"/> is not supported.</exception>
        public static void SetCallback(string key, EventHandler<RuntimeFeatureStatusChangedEventArgs> callback)
        {
            RuntimeInfoKey runtimeFeature;

            if (!ConvertStringToRuntimeInfoKey(key, out runtimeFeature))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid key");
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            RuntimeInfo.SetCallback(runtimeFeature, callback);
        }

        /// <summary>
        /// Unregisters a change event callback for given runtime feature key.
        /// </summary>
        /// <remarks>
        /// This function is only for runtime feature.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="key">The name of runtime feature which wants to unregister callback.</param>
        /// <param name="callback">The callback function to unsubscribe.</param>
        /// <exception cref="ArgumentException">Thrown when the <paramref name="key"/> is invalid.</exception>
        /// <exception cref="NotSupportedException">Thrown when the feature related <paramref name="key"/> is not supported.</exception>
        public static void UnsetCallback(string key, EventHandler<RuntimeFeatureStatusChangedEventArgs> callback)
        {
            RuntimeInfoKey runtimeFeature;

            if (!ConvertStringToRuntimeInfoKey(key, out runtimeFeature))
            {
                Log.Error(InformationErrorFactory.LogTag, "Invalid key");
                InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
            }

            RuntimeInfo.UnsetCallback(runtimeFeature, callback);
        }

        // for internal use only
        [EditorBrowsable(EditorBrowsableState.Never)]
        static void Preload()
        {
            TryGetValue("http://tizen.org/feature/screen.width", out int width);
            TryGetValue("http://tizen.org/feature/screen.height", out int height);
        }
    }
}
