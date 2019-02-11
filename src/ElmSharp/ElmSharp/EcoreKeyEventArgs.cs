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
    /// It inherits System.EventArgs.
    /// The EcoreKeyEventArgs is an EventArgs to record the Ecore event's key name and key code.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public class EcoreKeyEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the KeyName property. The return type is string.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public string KeyName { get; private set; }
        /// <summary>
        /// Gets the KeyCode property. The return type is int.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int KeyCode { get; private set; }

        /// <summary>
        /// Creates and initializes a new instance of the EcoreKeyEventArgs class.
        /// </summary>
        /// <param name="data">data</param>
        /// <param name="type">type</param>
        /// <param name="info">information</param>
        /// <returns>New instance of the EcoreKeyEventArgs class.</returns>
        /// <since_tizen> preview </since_tizen>
        public static EcoreKeyEventArgs Create(IntPtr data, EcoreEventType type, IntPtr info)
        {
            var evt = Marshal.PtrToStructure<EcoreEventKey>(info);
            return new EcoreKeyEventArgs { KeyName = evt.keyname, KeyCode = (int)evt.keycode };
        }

        [StructLayout(LayoutKind.Sequential)]
        struct EcoreEventKey
        {
            public string keyname;
            public string key;
            public string str;
            public string compose;
            public IntPtr window;
            public IntPtr root_window;
            public IntPtr event_window;
            public uint timestamp;
            public uint modifiers;
            public int same_screen;
            public uint keycode;
            public IntPtr data;
            public IntPtr dev;
        }
    }
}
