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

using Tizen.Internals;

internal static partial class Interop
{
    internal static partial class Eext
    {
        const short EEXT_CALLBACK_PRIORITY_AFTER = 100;
        const short EEXT_CALLBACK_PRIORITY_BEFORE = -100;
        const short EEXT_CALLBACK_PRIORITY_DEFAULT = 0;

        internal delegate bool Eext_Rotary_Event_Cb(IntPtr data, IntPtr obj, IntPtr info);
        internal delegate bool Eext_Rotary_Handler_Cb(IntPtr data, IntPtr info);

        internal enum Eext_Rotary_Event_Direction
        {
            Clockwise,
            CounterClockwise
        }

        [NativeStruct("Eext_Rotary_Event_Info", Include="circle/efl_extension_rotary.h", PkgConfig="efl-extension")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct Eext_Rotary_Event_Info
        {
            public Eext_Rotary_Event_Direction Direction;
            public uint TimeStamp;
        }

        internal static Eext_Rotary_Event_Info FromIntPtr(IntPtr infoPtr)
        {
            var info = Marshal.PtrToStructure<Eext_Rotary_Event_Info>(infoPtr);
            return info;
        }

        [DllImport(Libraries.Eext)]
        internal static extern IntPtr eext_rotary_object_event_activated_set(IntPtr circleObject, bool activated);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_rotary_object_event_callback_add(IntPtr obj, Eext_Rotary_Event_Cb func, IntPtr data);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_rotary_object_event_callback_priority_add(IntPtr obj, short priority, Eext_Rotary_Event_Cb func, IntPtr data);

        [DllImport(Libraries.Eext)]
        internal static extern IntPtr eext_rotary_object_event_callback_del(IntPtr obj, Eext_Rotary_Event_Cb func);

        [DllImport(Libraries.Eext)]
        internal static extern bool eext_rotary_event_handler_add(Eext_Rotary_Handler_Cb func, IntPtr data);

        [DllImport(Libraries.Eext)]
        internal static extern IntPtr eext_rotary_event_handler_del(Eext_Rotary_Handler_Cb func);
    }
}