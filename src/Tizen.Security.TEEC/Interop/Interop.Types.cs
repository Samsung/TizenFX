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
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct sTEEC_SharedMemoryImp
    {
        public IntPtr context;
        public IntPtr context_imp;
        public UInt32 flags;
        public UInt32 memid;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_SharedMemory
    {
        public IntPtr buffer;
        public UInt32 size;
        public UInt32 flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct TEEC_Parameter
    {
        public UInt32 a;
        public UInt32 b;
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

