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
        internal static partial class Spi
        {
            public enum Mode
            {
                Mode0 = 0,
                Mode1,
                Mode2,
                Mode3
            }

            public enum BitOrder
            {
                Msb = 0,
                Lsb
            }

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_open")]
            internal static extern ErrorCode Open(int bus, int chipSelectNumber, out IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_close")]
            internal static extern ErrorCode Close(IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_set_mode")]
            internal static extern ErrorCode SetMode(IntPtr handle, Mode mode);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_set_bit_order")]
            internal static extern ErrorCode SetBitOrder(IntPtr handle, BitOrder order);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_set_bits_per_word")]
            internal static extern ErrorCode SetBitsPerWord(IntPtr handle, byte bits);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_set_frequency")]
            internal static extern ErrorCode SetFrequency(IntPtr handle, uint frequency);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_read")]
            internal static extern ErrorCode Read(IntPtr handle, byte[] data, uint size);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_write")]
            internal static extern ErrorCode Write(IntPtr handle, byte[] data, uint size);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_spi_transfer", CallingConvention = CallingConvention.Cdecl)]
            internal static extern ErrorCode Transfer(IntPtr handle, byte[] txdata, byte[] rxdata, uint size);
        }
    }
}