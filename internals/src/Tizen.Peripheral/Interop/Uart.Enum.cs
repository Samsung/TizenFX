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

internal static partial class Interop
{
    internal static partial class Peripheral
    {
        internal static partial class Uart
        {
            public enum BaudRate
            {
                Rate0 = 0,
                Rate50,
                Rate75,
                Rate110,
                Rate134,
                Rate150,
                Rate200,
                Rate300,
                Rate600,
                Rate1200,
                Rate1800,
                Rate2400,
                Rate4800,
                Rate9600,
                Rate19200,
                Rate38400,
                Rate57600,
                Rate115200,
                Rate230400
            }

            public enum ByteSize
            {
                Size5Bit = 0,
                Size6Bit,
                Size7Bit,
                Size8Bit
            }

            public enum Parity
            {
                None = 0,
                Even,
                Odd
            }

            public enum StopBits
            {
                Bits1Bit = 0,
                Bits2Bit
            }

            public enum HardwareFlowControl
            {
                None = 0,
                AutoRtscts
            }

            public enum SoftwareFlowControl
            {
                None = 0,
                XonXoff,
            }
        }
    }
}