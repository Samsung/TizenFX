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
            var evt = Marshal.PtrToStructure<EvasEventKeyDown>(info);
            return new EvasKeyEventArgs() { KeyName = evt.keyname };
        }

        [StructLayout(LayoutKind.Sequential)]
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
