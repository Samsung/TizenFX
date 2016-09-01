// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    public class EvasKeyEventArgs : EventArgs
    {
        public const string PlatformBackButtonName = "XF86Back";
        public const string PlatformMenuButtonName = "XF86Menu";
        public const string PlatformHomeButtonName = "XF86Home";

        public string KeyName { get; private set; }

        static public EvasKeyEventArgs Create(IntPtr data, IntPtr obj, IntPtr info)
        {
            EvasEventKeyDown evt = (EvasEventKeyDown)Marshal.PtrToStructure(info, typeof(EvasEventKeyDown));
            return new EvasKeyEventArgs() { KeyName = evt.keyname };
        }

        [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential)]
        struct EvasEventKeyDown
        {
            public string keyname;
            public IntPtr data;
            public IntPtr modifiers;
            public IntPtr locks;
            public string key;
            public string str;
            public string compose;
            public IntPtr event_flags;
            public IntPtr dev;
            public uint keycode;
        };

    }
}
