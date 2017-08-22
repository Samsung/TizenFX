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
using System.ComponentModel;

namespace Tizen.System
{
    [EditorBrowsable(EditorBrowsableState.Never)]
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

        /// This function is for a TV product. It will be removed.
        internal static RuntimeInfoKey ConvertKeyIfTvProduct(RuntimeInfoKey key)
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
                    InformationErrorFactory.ThrowException(InformationError.InvalidParameter);
                }
                return (RuntimeInfoKey)key_TV;
            }
        }
    }
}
