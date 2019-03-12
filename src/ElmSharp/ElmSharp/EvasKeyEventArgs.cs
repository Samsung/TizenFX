/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// The EvasKeyEventArgs is a EvasKey EventArgs.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EvasKeyEventArgs : EventArgs
    {
        IntPtr _nativeEventInfo;

        /// <summary>
        /// BackButton name in platform.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public const string PlatformBackButtonName = "XF86Back";

        /// <summary>
        /// MenuButton name in platform.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public const string PlatformMenuButtonName = "XF86Menu";

        /// <summary>
        /// HomeButton name in platform.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public const string PlatformHomeButtonName = "XF86Home";

        /// <summary>
        /// Gets the name of the key.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string KeyName { get; private set; }

        /// <summary>
        /// Sets or gets the flags.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public EvasEventFlag Flags
        {
            get
            {
                IntPtr offset = Marshal.OffsetOf<EvasEventKeyDown>("event_flags");
                return (EvasEventFlag)Marshal.ReadIntPtr(_nativeEventInfo, (int)offset);
            }
            set
            {
                IntPtr offset = Marshal.OffsetOf<EvasEventKeyDown>("event_flags");
                Marshal.WriteIntPtr(_nativeEventInfo, (int)offset, (IntPtr)value);
            }
        }

        EvasKeyEventArgs(IntPtr info)
        {
            _nativeEventInfo = info;
            var evt = Marshal.PtrToStructure<EvasEventKeyDown>(info);
            KeyName = evt.keyname;
        }

        /// <summary>
        /// Creates and initializes a new instance of the EvasKeyEventArgs class.
        /// </summary>
        /// <param name="data">The data information.</param>
        /// <param name="obj">The object.</param>
        /// <param name="info">The information.</param>
        /// <returns>EvasKey eventArgs.</returns>
        /// <since_tizen> preview </since_tizen>
        static public EvasKeyEventArgs Create(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new EvasKeyEventArgs(info);
        }

        /// <summary>
        /// Event structure for Key Down event callbacks.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        struct EvasEventKeyDown
        {
            /// <summary>
            /// Name string of the key pressed.
            /// </summary>
            public string keyname;

            /// <summary>
            /// Data to be passed to the event.
            /// </summary>
            public IntPtr data;

            /// <summary>
            /// Modifier keys pressed during the event.
            /// </summary>
            public IntPtr modifiers;

            /// <summary>
            /// Locks information.
            /// </summary>
            public IntPtr locks;

            /// <summary>
            /// Logical key: (example, shift+1 == exclamation).
            /// </summary>
            public string key;

            /// <summary>
            /// UTF-8 string, if this keystroke has produced a visible string to be added.
            /// </summary>
            public string str;

            /// <summary>
            /// UTF-8 string, if this keystroke has modified a string in the middle of being composed - this string replaces the previous one.
            /// </summary>
            public string compose;

            public uint timestamp;

            /// <summary>
            /// Event_flags.
            /// </summary>
            public EvasEventFlag event_flags;

            /// <summary>
            ///
            /// </summary>
            public IntPtr dev;

            /// <summary>
            /// Keycode.
            /// </summary>
            public uint keycode;
        };
    }

    /// <summary>
    /// Flags for the events.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [Flags]
    public enum EvasEventFlag
    {
        /// <summary>
        /// No fancy flags set.
        /// </summary>
        None = 0,

        /// <summary>
        /// This event is being delivered but should be put "on hold" until the on hold flag is unset. The event should be used for informational purposes and maybe some indications visually, but not actually perform anything.
        /// </summary>
        OnHold = 1,
    }
}