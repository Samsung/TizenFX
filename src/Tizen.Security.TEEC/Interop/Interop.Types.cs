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
using System.IO;
using System.Text;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Context
    {
        public readonly IntPtr imp;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Session
    {
        public readonly IntPtr imp;
    }

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

    [StructLayout(LayoutKind.Sequential)]
    internal class TEEC_SharedMemory
    {
        public IntPtr buffer;
        public UInt32 size;
        public UInt32 flags;
        public IntPtr imp;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Value
    {
        public UInt32 a;
        public UInt32 b;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_TempMemoryReference
    {
        public IntPtr buffer;
        public UInt32 size;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_RegisteredMemoryReference
    {
        public TEEC_SharedMemory parent;
        public UInt32 size;
        public UInt32 offset;
    }

    [StructLayout(LayoutKind.Explicit)]
    internal struct TEEC_Parameter
    {
        [FieldOffset(0)]
        public TEEC_TempMemoryReference tmpref;
        [FieldOffset(0)]
        public TEEC_RegisteredMemoryReference memref;
        [FieldOffset(0)]
        public TEEC_Value value;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Operation
    {
        public UInt32 started;
        public UInt32 paramTypes;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public TEEC_Parameter[] paramlist;
        public IntPtr imp;
    }
}

