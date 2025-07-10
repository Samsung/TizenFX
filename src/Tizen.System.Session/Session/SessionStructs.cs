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
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SubsessionEventInfoNative
    {
        public SessionEventType EventType;

        public int SessionUID;

        public EventInfoUnion Union;
    }

    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal struct EventInfoUnion
    {
        [FieldOffset(0)]
        public AddUserInfo AddUser;
        [FieldOffset(0)]
        public RemoveUserInfo RemoveUser;
        [FieldOffset(0)]
        public SwitchUserInfo SwitchUser;
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct AddUserInfo
    {
        public fixed byte UserName[Session.MaxUserLength];
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct RemoveUserInfo
    {
        public fixed byte UserName[Session.MaxUserLength];
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct SwitchUserInfo
    {
        public long SwitchID;

        public fixed byte UserNamePrev[Session.MaxUserLength];

        public fixed byte UserNameNext[Session.MaxUserLength];
    }
}
