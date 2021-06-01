using System.Collections.ObjectModel;
/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using System.Collections.Generic;
using static Interop.CameraDeviceManager;

namespace Tizen.Multimedia
{
    /// <summary>
    /// Provides data for the <see cref="CameraDeviceManager.CameraDeviceListChanged"/> event.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class CameraDeviceListChangedEventArgs : EventArgs
    {
        internal CameraDeviceListChangedEventArgs(ref CameraDeviceListStruct ptr)
        {
            CameraDeviceInfo = GetDeviceInfo(ptr);
        }

        /// <summary>
        /// Gets the camera device info.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ReadOnlyCollection<CameraDeviceInfo> CameraDeviceInfo { get; }

        private ReadOnlyCollection<CameraDeviceInfo> GetDeviceInfo(CameraDeviceListStruct ptr)
        {
            var cameraDevice = ptr.device;

            var cameraDeviceList = new List<CameraDeviceInfo>();

            for (int i = 0 ; i < ptr.count ; i++)
            {
                var deviceInfo = new CameraDeviceInfo(cameraDevice[i].Type, cameraDevice[i].device,
                    GetString(cameraDevice[i].name), GetString(cameraDevice[i].id));

                cameraDeviceList.Add(deviceInfo);

                Log.Info(CameraLog.Tag, deviceInfo.ToString());
            }

            return new ReadOnlyCollection<CameraDeviceInfo>(cameraDeviceList);
        }

        private string GetString(char[] word)
        {
            int length = 0;
            while(word[length] != '\0')
            {
                length++;
            }

            return new String(word, 0, length);
        }
    }
}
