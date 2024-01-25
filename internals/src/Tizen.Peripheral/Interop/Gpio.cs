/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

internal static partial class Interop
{
    internal static partial class Peripheral
    {
        internal static partial class Gpio
        {
            public enum Direction
            {
                In = 0,
                OutHigh,
                OutLow
            }

            public enum EdgeType
            {
                None = 0,
                Rising,
                Falling,
                Both
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct callbackInfo
            {
                public int vermagic;
                public int gpioPinValue;
                // skip the rest fields in structure as we do not need it
            }
            [StructLayout(LayoutKind.Sequential)]
            public struct PeripherialGpio
            {
                public int vermagic;
                public callbackInfo cbInfo;
                // skip the rest fields in structure as we do not need it
            }

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate void InterruptedEventCallback(IntPtr handle, ErrorCode error, IntPtr data);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_open")]
            internal static extern ErrorCode Open(int pin, out IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_close")]
            internal static extern ErrorCode Close(IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_set_direction")]
            internal static extern ErrorCode SetDirection(IntPtr handle, Direction direction);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_write")]
            internal static extern ErrorCode Write(IntPtr handle, uint value);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_read")]
            internal static extern ErrorCode Read(IntPtr handle, out uint value);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_set_edge_mode")]
            internal static extern ErrorCode SetEdgeMode(IntPtr handle, EdgeType type);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_set_interrupted_cb")]
            internal static extern ErrorCode SetInterruptedCb(IntPtr handle, InterruptedEventCallback callback, IntPtr data);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_gpio_unset_interrupted_cb")]
            internal static extern ErrorCode UnsetInterruptedCb(IntPtr handle);
        }
    }
}
