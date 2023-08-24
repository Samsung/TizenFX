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
        internal static partial class Adc
        {
            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_adc_open")]
            internal static extern ErrorCode Open(int device, int channel, out IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_adc_close")]
            internal static extern ErrorCode Close(IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_adc_read")]
            internal static extern ErrorCode Read(IntPtr handle, out uint value);
        }
    }
}