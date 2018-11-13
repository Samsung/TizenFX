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

namespace Tizen.Applications
{
    /// <summary>
    /// Operations of the AppControl.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class AppControlOperations
    {
        /// <summary>
        /// An explicit launch for a homescreen application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Main = "http://tizen.org/appcontrol/operation/main";

        /// <summary>
        /// An explicit launch for an application that excludes a homescreen application.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Default = "http://tizen.org/appcontrol/operation/default";

        /// <summary>
        /// Provides an editable access to the given data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Edit = "http://tizen.org/appcontrol/operation/edit";

        /// <summary>
        /// Displays the data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string View = "http://tizen.org/appcontrol/operation/view";

        /// <summary>
        /// Picks items.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Pick = "http://tizen.org/appcontrol/operation/pick";

        /// <summary>
        /// Creates contents.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string CreateContent = "http://tizen.org/appcontrol/operation/create_content";

        /// <summary>
        /// Performs a call to someone.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Call = "http://tizen.org/appcontrol/operation/call";

        /// <summary>
        /// Delivers some data to someone else.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Send = "http://tizen.org/appcontrol/operation/send";

        /// <summary>
        /// Delivers text data to someone else.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SendText = "http://tizen.org/appcontrol/operation/send_text";

        /// <summary>
        /// Shares an item with someone else.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Share = "http://tizen.org/appcontrol/operation/share";

        /// <summary>
        /// Shares multiple items with someone else.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string MultiShare = "http://tizen.org/appcontrol/operation/multi_share";

        /// <summary>
        /// Shares text data with someone else.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string ShareText = "http://tizen.org/appcontrol/operation/share_text";

        /// <summary>
        /// Dials a number. This shows an UI with the number to be dialed, allowing the user to explicitly initiate the call.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Dial = "http://tizen.org/appcontrol/operation/dial";

        /// <summary>
        /// Performs a search.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Search = "http://tizen.org/appcontrol/operation/search";

        /// <summary>
        /// Downloads items.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Download = "http://tizen.org/appcontrol/operation/download";

        /// <summary>
        /// Prints contents.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Print = "http://tizen.org/appcontrol/operation/print";

        /// <summary>
        /// Composes a message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Compose = "http://tizen.org/appcontrol/operation/compose";

        /// <summary>
        /// Can be launched by interested System-Event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string LaunchOnEvent = "http://tizen.org/appcontrol/operation/launch_on_
            ";

        /// <summary>
        /// Adds an item.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Add = "http://tizen.org/appcontrol/operation/add";

        /// <summary>
        /// Captures images by camera applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string ImageCapture = "http://tizen.org/appcontrol/operation/image_capture";

        /// <summary>
        /// Captures videos by camera applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string VideoCapture = "http://tizen.org/appcontrol/operation/video_capture";

        /// <summary>
        /// Shows system settings.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string Setting = "http://tizen.org/appcontrol/operation/setting";

        /// <summary>
        /// Shows settings to enable Bluetooth.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SettingBluetoothEnable = "http://tizen.org/appcontrol/operation/setting/bt_enable";

        /// <summary>
        /// Shows settings to configure the Bluetooth visibility.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SettingBluetoothVisibility = "http://tizen.org/appcontrol/operation/setting/bt_visibility";

        /// <summary>
        /// Shows settings to allow configuration of current location sources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SettingLocation = "http://tizen.org/appcontrol/operation/setting/location";

        /// <summary>
        /// Shows NFC settings.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SettingNfc = "http://tizen.org/appcontrol/operation/setting/nfc";

        /// <summary>
        /// Shows settings to allow configuration of Wi-Fi.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string SettingWifi = "http://tizen.org/appcontrol/operation/setting/wifi";
    }
}
