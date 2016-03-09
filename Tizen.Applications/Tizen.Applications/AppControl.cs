/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System;

namespace Tizen.Applications
{
    /// <summary>
    /// The AppControl to launch other application or an actor or a service.
    /// </summary>
    public class AppControl
    {
        private readonly string _operation;
        private readonly string _mime;
        private readonly string _uri;

        /// <summary>
        /// 
        /// </summary>
        public static class Operations
        {
            /// <summary>
            /// An explicit launch for a homescreen application. 
            /// </summary>
            public const string Main = "http://tizen.org/appcontrol/operation/main";

            /// <summary>
            /// An explicit launch for an application that excludes a homescreen application. 
            /// </summary>
            public const string Default = "http://tizen.org/appcontrol/operation/default";

            /// <summary>
            /// Provides an editable access to the given data. 
            /// </summary>
            public const string Edit = "http://tizen.org/appcontrol/operation/edit";

            /// <summary>
            /// Displays the data. 
            /// </summary>
            public const string View = "http://tizen.org/appcontrol/operation/view";

            /// <summary>
            /// Picks items. 
            /// </summary>
            public const string Pick = "http://tizen.org/appcontrol/operation/pick";

            /// <summary>
            /// Creates contents. 
            /// </summary>
            public const string CreateContent = "http://tizen.org/appcontrol/operation/create_content";

            /// <summary>
            /// Performs a call to someone. 
            /// </summary>
            public const string Call = "http://tizen.org/appcontrol/operation/call";

            /// <summary>
            /// Delivers some data to someone else. 
            /// </summary>
            public const string Send = "http://tizen.org/appcontrol/operation/send";

            /// <summary>
            /// Delivers text data to someone else. 
            /// </summary>
            public const string SendText = "http://tizen.org/appcontrol/operation/send_text";

            /// <summary>
            /// Shares an item with someone else. 
            /// </summary>
            public const string Share = "http://tizen.org/appcontrol/operation/share";

            /// <summary>
            /// Shares multiple items with someone else. 
            /// </summary>
            public const string MultiShare = "http://tizen.org/appcontrol/operation/multi_share";

            /// <summary>
            /// Shares text data with someone else. 
            /// </summary>
            public const string ShareText = "http://tizen.org/appcontrol/operation/share_text";

            /// <summary>
            /// Dials a number. This shows a UI with the number to be dialed, allowing the user to explicitly initiate the call. 
            /// </summary>
            public const string Dial = "http://tizen.org/appcontrol/operation/dial";

            /// <summary>
            /// Performs a search. 
            /// </summary>
            public const string Search = "http://tizen.org/appcontrol/operation/search";

            /// <summary>
            /// Downloads items. 
            /// </summary>
            public const string Download = "http://tizen.org/appcontrol/operation/download";

            /// <summary>
            /// Prints contents. 
            /// </summary>
            public const string Print = "http://tizen.org/appcontrol/operation/print";

            /// <summary>
            /// Composes a message. 
            /// </summary>
            public const string Compose = "http://tizen.org/appcontrol/operation/compose";

            /// <summary>
            /// Can be launched by interested System-Event. 
            /// </summary>
            public const string LaunchOnEvent = "http://tizen.org/appcontrol/operation/launch_on_event";

            /// <summary>
            /// Adds an item. 
            /// </summary>
            public const string Add = "http://tizen.org/appcontrol/operation/add";

            /// <summary>
            /// Captures images by camera applications. 
            /// </summary>
            public const string ImageCapture = "http://tizen.org/appcontrol/operation/image_capture";

            /// <summary>
            /// Captures videos by camera applications. 
            /// </summary>
            public const string VideoCapture = "http://tizen.org/appcontrol/operation/video_capture";

            /// <summary>
            /// Shows system settings. 
            /// </summary>
            public const string Setting = "http://tizen.org/appcontrol/operation/setting";

            /// <summary>
            /// Shows settings to enable Bluetooth. 
            /// </summary>
            public const string SettingBluetoothEnable = "http://tizen.org/appcontrol/operation/setting/bt_enable";

            /// <summary>
            /// Shows settings to configure Bluetooth visibility. 
            /// </summary>
            public const string SettingBluetoothVisibility = "http://tizen.org/appcontrol/operation/setting/bt_visibility";

            /// <summary>
            /// Shows settings to allow configuration of current location sources. 
            /// </summary>
            public const string SettingLocation = "http://tizen.org/appcontrol/operation/setting/location";

            /// <summary>
            /// Shows NFC settings. 
            /// </summary>
            public const string SettingNfc = "http://tizen.org/appcontrol/operation/setting/nfc";

            /// <summary>
            /// Shows settings to allow configuration of Wi-Fi. 
            /// </summary>
            public const string SettingWifi = "http://tizen.org/appcontrol/operation/setting/wifi";
        }

        /// <summary>
        /// Gets the operation to be performed. 
        /// </summary>
        public string Operation { get { return _operation; } }

        /// <summary>
        /// Gets the explicit MIME type of the data. 
        /// </summary>
        public string Mime { get { return _mime; } }

        /// <summary>
        /// Gets the URI of the data. 
        /// </summary>
        public string Uri { get { return _uri; } }

        internal AppControl(IntPtr appControlHandle)
        {
            var handle = new Interop.AppControl.SafeAppControlHandle(appControlHandle);
            Interop.AppControl.GetOperation(handle, out _operation);
            Interop.AppControl.GetMime(handle, out _mime);
            Interop.AppControl.GetUri(handle, out _uri);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="mime"></param>
        /// <param name="uri"></param>
        public AppControl(string operation, string mime, string uri)
        {
            _operation = operation;
            _mime = mime;
            _uri = uri;
        }

        internal bool IsLaunchOperation()
        {
            if (_operation == null) return false;
            return (_operation == Operations.Main) || (_operation == Operations.Default);
        }

        internal bool IsService
        {
            get { return false; }
        }
    }
}
