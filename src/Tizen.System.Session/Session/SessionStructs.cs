/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Text;
using Tizen.Internals;

namespace Tizen.System
{
    [NativeStruct("subsession_event_info", Include = "sessiond.h", PkgConfig = "libsessiond")]
    [StructLayout(LayoutKind.Explicit)]
    internal struct SubsessionEventInfoNative
    {
        [FieldOffset(0)]
        public SessionEventType eventType;
        [FieldOffset(4)]
        public int sessionUID;
        [FieldOffset(8)]
        public AddUser addUser;
        [FieldOffset(8)]
        public RemoveUser removeUser;
        [FieldOffset(8)]
        public SwitchUser switchUser;
    }

    /*

	Regarding AddUser, RemoveUser and SwitchUser structs:

	Marshaling complex C/C++ structs containing C/C++ unions as their members is tricky.
	Firstly, to handle C/C++ unions in C# one needs to provide an explicit memory layout.
	It's vital to provide a correct alignment. Since our fields in the native C struct being
	reflected here are already all divisible by 4, there's no need for fillers.
	Secondly, when the C# marshaller encounters an array, it creates a managed counterpart
	on the heap, but what we'll get on the stack is actually the reference to the array on the heap.
	Any other structure containing basic types would be overlapping and thus invalidating that
	reference (remember we're dealing with a union where all the elements (structs in our case)
	start form the same address) and leading to a nasty run-time error:
	"it contains an object field at offset X that is incorrectly aligned
	or overlapped by a non-object field".
	The only solution that works 100% of the times is unrolling the arrays down to
	single bytes and turn off the C# marshaller.
	Unfortunately the code is not pretty, but they say maturity is consent to an unfulfilled life.

	*/

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct AddUser
    {
        public byte userName_00;
        public byte userName_01;
        public byte userName_02;
        public byte userName_03;
        public byte userName_04;
        public byte userName_05;
        public byte userName_06;
        public byte userName_07;
        public byte userName_08;
        public byte userName_09;
        public byte userName_10;
        public byte userName_11;
        public byte userName_12;
        public byte userName_13;
        public byte userName_14;
        public byte userName_15;
        public byte userName_16;
        public byte userName_17;
        public byte userName_18;
        public byte userName_19;

        public string userName
        {
            get
            {
                return UnrolledBytesToStringConverter.Convert20(
                    userName_00, userName_01, userName_02, userName_03,
                    userName_04, userName_05, userName_06, userName_07,
                    userName_08, userName_09, userName_10, userName_11,
                    userName_12, userName_13, userName_14, userName_15,
                    userName_16, userName_17, userName_18, userName_19
                );
            }
        }
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct RemoveUser
    {
        public byte userName_00;
        public byte userName_01;
        public byte userName_02;
        public byte userName_03;
        public byte userName_04;
        public byte userName_05;
        public byte userName_06;
        public byte userName_07;
        public byte userName_08;
        public byte userName_09;
        public byte userName_10;
        public byte userName_11;
        public byte userName_12;
        public byte userName_13;
        public byte userName_14;
        public byte userName_15;
        public byte userName_16;
        public byte userName_17;
        public byte userName_18;
        public byte userName_19;
        public string userName
        {
            get
            {
                return UnrolledBytesToStringConverter.Convert20(
                    userName_00, userName_01, userName_02, userName_03,
                    userName_04, userName_05, userName_06, userName_07,
                    userName_08, userName_09, userName_10, userName_11,
                    userName_12, userName_13, userName_14, userName_15,
                    userName_16, userName_17, userName_18, userName_19
                );
            }
        }
    }
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
    internal struct SwitchUser
    {
        public Int64 switchID;
        public byte userNamePrev_00;
        public byte userNamePrev_01;
        public byte userNamePrev_02;
        public byte userNamePrev_03;
        public byte userNamePrev_04;
        public byte userNamePrev_05;
        public byte userNamePrev_06;
        public byte userNamePrev_07;
        public byte userNamePrev_08;
        public byte userNamePrev_09;
        public byte userNamePrev_10;
        public byte userNamePrev_11;
        public byte userNamePrev_12;
        public byte userNamePrev_13;
        public byte userNamePrev_14;
        public byte userNamePrev_15;
        public byte userNamePrev_16;
        public byte userNamePrev_17;
        public byte userNamePrev_18;
        public byte userNamePrev_19;

        public string userNamePrev
        {
            get
            {
                return UnrolledBytesToStringConverter.Convert20(
                    userNamePrev_00, userNamePrev_01, userNamePrev_02, userNamePrev_03,
                    userNamePrev_04, userNamePrev_05, userNamePrev_06, userNamePrev_07,
                    userNamePrev_08, userNamePrev_09, userNamePrev_10, userNamePrev_11,
                    userNamePrev_12, userNamePrev_13, userNamePrev_14, userNamePrev_15,
                    userNamePrev_16, userNamePrev_17, userNamePrev_18, userNamePrev_19
                );
            }
        }

        public byte userNameNext_00;
        public byte userNameNext_01;
        public byte userNameNext_02;
        public byte userNameNext_03;
        public byte userNameNext_04;
        public byte userNameNext_05;
        public byte userNameNext_06;
        public byte userNameNext_07;
        public byte userNameNext_08;
        public byte userNameNext_09;
        public byte userNameNext_10;
        public byte userNameNext_11;
        public byte userNameNext_12;
        public byte userNameNext_13;
        public byte userNameNext_14;
        public byte userNameNext_15;
        public byte userNameNext_16;
        public byte userNameNext_17;
        public byte userNameNext_18;
        public byte userNameNext_19;

        public string userNameNext
        {
            get
            {
                return UnrolledBytesToStringConverter.Convert20(
                    userNameNext_00, userNameNext_01, userNameNext_02, userNameNext_03,
                    userNameNext_04, userNameNext_05, userNameNext_06, userNameNext_07,
                    userNameNext_08, userNameNext_09, userNameNext_10, userNameNext_11,
                    userNameNext_12, userNameNext_13, userNameNext_14, userNameNext_15,
                    userNameNext_16, userNameNext_17, userNameNext_18, userNameNext_19
                );
            }
        }
    }

    internal static class UnrolledBytesToStringConverter
    {
        public static string Convert20(
            byte val_00, byte val_01, byte val_02, byte val_03,
            byte val_04, byte val_05, byte val_06, byte val_07,
            byte val_08, byte val_09, byte val_10, byte val_11,
            byte val_12, byte val_13, byte val_14, byte val_15,
            byte val_16, byte val_17, byte val_18, byte val_19)
        {
            byte[] toConvert = new byte[]
            {
                    val_00, val_01, val_02, val_03,
                    val_04, val_05, val_06, val_07,
                    val_08, val_09, val_10, val_11,
                    val_12, val_13, val_14, val_15,
                    val_16, val_17, val_18, val_19
            };

            return Encoding.UTF8.GetString(toConvert);
        }
    }
}
