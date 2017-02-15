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

namespace Tizen.Uix.InputMethod
{
    /// <summary>
    /// This Class contains data related to ProcessKey Event
    /// </summary>
    public class ProcessKeyEventArgs
    {
        internal ProcessKeyEventArgs(KeyCode keycode, KeyMask keymask, IntPtr devInfo)
        {
            Keycode = keycode;
            Keymask = keymask;
            DeviceInfo = new VoiceControlDeviceInformation(devInfo);
        }

        /// <summary>
        /// The device information handle
        /// </summary>
        public VoiceControlDeviceInformation DeviceInfo
        {
            get;
            internal set;
        }

        /// <summary>
        /// The key code to be sent
        /// </summary>
        public KeyCode Keycode
        {
            get;
            internal set;
        }

        /// <summary>
        /// The modifier key mask
        /// </summary>
        public KeyMask Keymask
        {
            get;
            internal set;
        }
    }
}