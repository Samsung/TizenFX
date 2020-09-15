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
        internal static partial class Uart
        {
            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_open")]
            internal static extern ErrorCode Open(int port, out IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_close")]
            internal static extern ErrorCode Close(IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_set_baud_rate")]
            internal static extern ErrorCode SetBaudRate(IntPtr handle, BaudRate rate);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_set_byte_size")]
            internal static extern ErrorCode SetByteSize(IntPtr handle, ByteSize size);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_set_parity")]
            internal static extern ErrorCode SetParity(IntPtr handle, Parity parity);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_set_stop_bits")]
            internal static extern ErrorCode SetStopBits(IntPtr handle, StopBits bits);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_set_flow_control")]
            internal static extern ErrorCode SetFlowControl(
                IntPtr handle,
                SoftwareFlowControl softwareFlowControl,
                HardwareFlowControl hardwareFlowControl);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_read")]
            internal static extern ErrorCode Read(IntPtr handle, byte[] data, uint size);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_uart_write")]
            internal static extern ErrorCode Write(IntPtr handle, byte[] data, uint size);
        }
    }
}