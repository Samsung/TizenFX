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
    /// This class is for a TV product. It will be removed.
    internal static class TvProductHelper
    {
        private static int is_TV_product = -1;

        private static readonly Dictionary<RuntimeInfoKey, int> s_keyTVkeyMapping = new Dictionary<RuntimeInfoKey, int>
        {
            [RuntimeInfoKey.Bluetooth] = 5,
            [RuntimeInfoKey.WifiHotspot] = 6,
            [RuntimeInfoKey.BluetoothTethering] = 7,
            [RuntimeInfoKey.UsbTethering] = 8,
            [RuntimeInfoKey.PacketData] = 13,
            [RuntimeInfoKey.DataRoaming] = 14,
            [RuntimeInfoKey.Vibration] = 16,
            [RuntimeInfoKey.AudioJack] = 20,
            [RuntimeInfoKey.BatteryIsCharging] = 22,
            [RuntimeInfoKey.TvOut] = 18,
            [RuntimeInfoKey.Charger] = 26,
            [RuntimeInfoKey.AutoRotation] = 28,
            [RuntimeInfoKey.Gps] = 21,
            [RuntimeInfoKey.AudioJackConnector] = 20
        };

        private static void CheckTvProduct()
        {
            bool is_key_existed = false;
            string profile;

#pragma warning disable CS0618 // Type or member is obsolete
            is_key_existed = SystemInfo.TryGetValue<string>("http://com.samsung/build_config/product_type", out profile);
#pragma warning restore CS0618 // Type or member is obsolete
            if (is_key_existed && String.Compare(profile, "TV") == 0)
            {
                is_TV_product = 1;
            }
            else
            {
                is_TV_product = 0;
            }
        }

        internal static RuntimeInfoKey ConvertKeyIfTvProduct(RuntimeInfoKey key)
        {
            if (is_TV_product == -1)
            {
                CheckTvProduct();
            }

            if (is_TV_product == 1)
            {
                if (!s_keyTVkeyMapping.TryGetValue(key, out int key_TV))
                {
                    InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
                }
                return (RuntimeInfoKey)key_TV;
            }
            else
            {
                return key;
            }
        }

        internal static RuntimeInfoKey ReconvertKeyIfTvProduct(RuntimeInfoKey key)
        {
            if (is_TV_product == -1)
            {
                CheckTvProduct();
            }

            if (is_TV_product == 1)
            {
                foreach (KeyValuePair<RuntimeInfoKey, int> kvp in s_keyTVkeyMapping)
                {
                    if (kvp.Value == (int)key)
                        return kvp.Key;
                }

                Log.Error(InformationErrorFactory.LogTag, "Key mapping failed");
                return 0;
            }
            else
            {
                return key;
            }
        }
    }
}
