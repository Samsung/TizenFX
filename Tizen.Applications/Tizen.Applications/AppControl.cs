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
    /// 
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
            public const string Main = "http://tizen.org/appcontrol/operation/main";
            public const string Default = "http://tizen.org/appcontrol/operation/default";
            public const string Edit = "http://tizen.org/appcontrol/operation/edit";
            public const string View = "http://tizen.org/appcontrol/operation/view";
            public const string Pick = "http://tizen.org/appcontrol/operation/pick";
            public const string CreateContent = "http://tizen.org/appcontrol/operation/create_content";
            public const string Call = "http://tizen.org/appcontrol/operation/call";
            public const string Send = "http://tizen.org/appcontrol/operation/send";
            public const string SendText = "http://tizen.org/appcontrol/operation/send_text";
            public const string Share = "http://tizen.org/appcontrol/operation/share";
            public const string MultiShare = "http://tizen.org/appcontrol/operation/multi_share";
            public const string ShareText = "http://tizen.org/appcontrol/operation/share_text";
            public const string Dial = "http://tizen.org/appcontrol/operation/dial";
            public const string Search = "http://tizen.org/appcontrol/operation/search";
            public const string Download = "http://tizen.org/appcontrol/operation/download";
            public const string Print = "http://tizen.org/appcontrol/operation/print";
            public const string Compose = "http://tizen.org/appcontrol/operation/compose";
            public const string LaunchOnEvent = "http://tizen.org/appcontrol/operation/launch_on_event";
            public const string Add = "http://tizen.org/appcontrol/operation/add";
            public const string ImageCapture = "http://tizen.org/appcontrol/operation/image_capture";
            public const string VideoCapture = "http://tizen.org/appcontrol/operation/video_capture";
            public const string Setting = "http://tizen.org/appcontrol/operation/setting";
            public const string SettingBtEnable = "http://tizen.org/appcontrol/operation/setting/bt_enable";
            public const string SettingBtVisibility = "http://tizen.org/appcontrol/operation/setting/bt_visibility";
            public const string SettingLocation = "http://tizen.org/appcontrol/operation/setting/location";
            public const string SettingNfc = "http://tizen.org/appcontrol/operation/setting/nfc";
            public const string SettingWifi = "http://tizen.org/appcontrol/operation/setting/wifi";
        }

        /// <summary>
        /// 
        /// </summary>
        public string Operation { get { return _operation; } }

        /// <summary>
        /// 
        /// </summary>
        public string Mime { get { return _mime; } }

        /// <summary>
        /// 
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
