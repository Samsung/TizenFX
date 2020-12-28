/*
 *  Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */


using System;
using System.Runtime.InteropServices;
using Tizen.Internals;

internal static partial class Interop
{
#if PROFILE_TV
    private const string PkgConfig = "trustzone-nwd";
#else
    private const string PkgConfig = "tef-libteec";
#endif


    [NativeStruct("TEEC_Context", Include="tee_client_api.h", PkgConfig=PkgConfig)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Context
    {
        public readonly IntPtr imp;
    }

    [NativeStruct("TEEC_Session", Include="tee_client_api.h", PkgConfig=PkgConfig)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Session
    {
        public readonly IntPtr imp;
    }

    [NativeStruct("TEEC_UUID", Include="tee_client_api.h", PkgConfig=PkgConfig)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_UUID
    {
        public UInt32 timeLow;
        public UInt16 timeMid;
        public UInt16 timeHiAndVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] clockSeqAndNode;

        internal static TEEC_UUID ToTeecUuid(Guid guid)
        {
            TEEC_UUID uuid = new TEEC_UUID();
            byte[] bin = guid.ToByteArray();
            uuid.timeLow = BitConverter.ToUInt32(bin, 0);
            uuid.timeMid = BitConverter.ToUInt16(bin, 4);
            uuid.timeHiAndVersion = BitConverter.ToUInt16(bin, 6);
            uuid.clockSeqAndNode = new byte[8];
            Array.Copy(bin, 8, uuid.clockSeqAndNode, 0, 8);
            return uuid;
        }
    }

    [NativeStruct("TEEC_SharedMemory", Include="tee_client_api.h", PkgConfig=PkgConfig)]
    [StructLayout(LayoutKind.Sequential,Pack=8)]
    internal struct TEEC_SharedMemory
    {
        public IntPtr buffer;
        public UIntPtr size;
        public UInt32 flags;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
		public byte[] padding;
    }

    [NativeStruct("TEEC_Value", Include="tee_client_api.h", PkgConfig=PkgConfig)]
    [StructLayout(LayoutKind.Sequential,Pack=8)]
    internal struct TEEC_Value
    {
        public UInt32 a;
        public UInt32 b;
    }

    [NativeStruct("TEEC_TempMemoryReference", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only32Bits)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_TempMemoryReference32
    {
        public Int32 buffer;
        public UInt32 size;
    }

    [NativeStruct("TEEC_RegisteredMemoryReference", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only32Bits)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_RegisteredMemoryReference32
    {
        public Int32 parent;
        public UInt32 size;
        public UInt32 offset;
    }

    [NativeStruct("TEEC_Parameter", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only32Bits)]
    [StructLayout(LayoutKind.Explicit)]
    internal struct TEEC_Parameter32
    {
        [FieldOffset(0)]
        public TEEC_TempMemoryReference32 tmpref;
        [FieldOffset(0)]
        public TEEC_RegisteredMemoryReference32 memref;
        [FieldOffset(0)]
        public TEEC_Value value;
    }

    [NativeStruct("TEEC_Operation", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only32Bits)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Operation32
    {
        public UInt32 started;
        public UInt32 paramTypes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public TEEC_Parameter32[] paramlist;
        public IntPtr imp;
    }

    [NativeStruct("TEEC_TempMemoryReference", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only64Bits)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_TempMemoryReference64
    {
        public Int64 buffer;
        public UInt64 size;
    }

    [NativeStruct("TEEC_RegisteredMemoryReference", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only64Bits)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_RegisteredMemoryReference64
    {
        public Int64 parent;
        public UInt64 size;
        public UInt64 offset;
    }

    [NativeStruct("TEEC_Parameter", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only64Bits)]
    [StructLayout(LayoutKind.Explicit)]
    internal struct TEEC_Parameter64
    {
        [FieldOffset(0)]
        public TEEC_TempMemoryReference64 tmpref;
        [FieldOffset(0)]
        public TEEC_RegisteredMemoryReference64 memref;
        [FieldOffset(0)]
        public TEEC_Value value;
    }

    [NativeStruct("TEEC_Operation", Include="tee_client_api.h", PkgConfig=PkgConfig, Arch=NativeStructArch.Only64Bits)]
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Operation64
    {
        public UInt32 started;
        public UInt32 paramTypes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public TEEC_Parameter64[] paramlist;
        public IntPtr imp;
    }
}

