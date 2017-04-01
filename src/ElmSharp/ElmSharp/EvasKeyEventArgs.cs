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
    /// <summary>
    /// The EvasKeyEventArgs is an EvasKey EventArgs
    /// </summary>
    public class EvasKeyEventArgs : EventArgs
    {
        /// <summary>
        /// BackButton name in Platform
        /// </summary>
        public const string PlatformBackButtonName = "XF86Back";
        /// <summary>
        /// MenuButton name in Platform
        /// </summary>
        public const string PlatformMenuButtonName = "XF86Menu";
        /// <summary>
        /// HomeButton name in Platform
        /// </summary>
        public const string PlatformHomeButtonName = "XF86Home";

        /// <summary>
        /// Gets the name of Key
        /// </summary>
        public string KeyName { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the EvasKeyEventArgs class.
        /// </summary>
        /// <param name="data">data info</param>
        /// <param name="obj"> object </param>
        /// <param name="info">information </param>
        /// <returns>EvasKey eventArgs</returns>
        static public EvasKeyEventArgs Create(IntPtr data, IntPtr obj, IntPtr info)
        {
            var evt = Marshal.PtrToStructure<EvasEventKeyDown>(info);
            return new EvasKeyEventArgs() { KeyName = evt.keyname };
        }

        /// <summary>
        /// Event structure for Key Down event callbacks.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct EvasEventKeyDown
        {
            /// <summary>
            /// Name string of the key pressed
            /// </summary>
            public string keyname;
            /// <summary>
            /// Data to be passed to the event
            /// </summary>
            public IntPtr data;
            /// <summary>
            /// Modifier keys pressed during the event
            /// </summary>
            public IntPtr modifiers;
            /// <summary>
            /// Locks info
            /// </summary>
            public IntPtr locks;
            /// <summary>
            /// Logical key: (example, shift+1 == exclamation)
            /// </summary>
            public string key;
            /// <summary>
            /// UTF8 string if this keystroke has produced a visible string to be ADDED
            /// </summary>
            public string str;
            /// <summary>
            /// UTF8 string if this keystroke has modified a string in the middle of being composed - this string replaces the previous one
            /// </summary>
            public string compose;
            /// <summary>
            /// Event_flags
            /// </summary>
            public IntPtr event_flags;
            /// <summary>
            ///
            /// </summary>
            public IntPtr dev;
            /// <summary>
            /// Keycode
            /// </summary>
            public uint keycode;
        };

    }
}
