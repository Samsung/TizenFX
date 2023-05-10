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
    [NativeStruct("subsession_event_info", Include="sessiond.h", PkgConfig="libsessiond")]
    [StructLayout(LayoutKind.Explicit)]
    internal struct SubsessionEventInfoNative
    {
        [FieldOffset(0)]
        public SessionEventType eventType;
        [FieldOffset(4)]
        public int sessionUID;

        [FieldOffset(8)]
        public Int64 switchID;

        /// The following 4 fields are here just for the record and for the NativeStruct validation
        /// which is performed as one of the steps during build with GBS.
        /// However, we've verified that representing the whole structure as IntPtr and accessing
        /// individual string fields with PtrToStructure with and PtrToStringAnsi + IntPtr.Add is
        /// the only way to make it work. That's why we do not use these fields and they shouldn't
        /// be accessed directly.
        [FieldOffset(8)]
        private IntPtr AddUserPtr;
        [FieldOffset(8)]
        private IntPtr RemoveUserPtr;
        [FieldOffset(16)]
        private IntPtr PrevUserPtr;
        [FieldOffset(36)]
        private IntPtr NextUserPtr;
    }
}
