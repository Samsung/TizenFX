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
        internal static partial class Pwm
        {
            public enum Polarity
            {
                ActiveHigh = 0,
                ActiveLow
            }

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_pwm_open")]
            internal static extern ErrorCode Open(int chip, int pin, out IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_pwm_close")]
            internal static extern ErrorCode Close(IntPtr handle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_pwm_set_period")]
            internal static extern ErrorCode SetPeriod(IntPtr handle, uint period);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_pwm_set_duty_cycle")]
            internal static extern ErrorCode SetDutyCycle(IntPtr handle, uint dutyCycle);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_pwm_set_polarity")]
            internal static extern ErrorCode SetPolarity(IntPtr handle, Polarity polarity);

            [DllImport(Libraries.Peripherial, EntryPoint = "peripheral_pwm_set_enabled")]
            internal static extern ErrorCode SetEnabled(IntPtr handle, bool enabled);
        }
    }
}