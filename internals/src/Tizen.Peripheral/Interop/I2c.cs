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
        internal static partial class I2c
        {
            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_open")]
            internal static extern ErrorCode Open(int bus, int address, out IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_close")]
            internal static extern ErrorCode Close(IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_read")]
            internal static extern ErrorCode Read(IntPtr handle, byte[] value, uint size);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_write")]
            internal static extern ErrorCode Write(IntPtr handle, byte[] value, uint size);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_read_register_byte")]
            internal static extern ErrorCode ReadRegisterByte(IntPtr handle, byte register, out byte data);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_write_register_byte")]
            internal static extern ErrorCode WriteRegisterByte(IntPtr handle, byte register, byte data);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_read_register_word")]
            internal static extern ErrorCode ReadRegisterWord(IntPtr handle, byte register, out ushort data);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_i2c_write_register_word")]
            internal static extern ErrorCode WriteRegisterWord(IntPtr handle, byte register, ushort data);
        }
    }
}