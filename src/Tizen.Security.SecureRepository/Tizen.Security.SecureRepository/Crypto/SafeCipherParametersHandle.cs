/*
 *  Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Security.SecureRepository.Crypto
{
    internal class SafeCipherParametersHandle : SafeHandle
    {
        internal SafeCipherParametersHandle(CipherAlgorithmType algorithm) :
            base(IntPtr.Zero, true)
        {
            IntPtr ptr = IntPtr.Zero;
            Interop.CkmcTypes.GenerateNewParam((int)algorithm, out ptr);
            this.SetHandle(ptr);
        }

        internal void SetInteger(CipherParameterName name, long value)
        {
            Interop.CheckNThrowException(
                Interop.CkmcTypes.ParamListSetInteger(
                    Ptr, (int)name, value),
                "Failed to add parameter.");
        }

        internal void SetBuffer(CipherParameterName name, byte[] value)
        {
            var rawBuff = new Interop.CkmcRawBuffer(new PinnedObject(value), value.Length);
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(rawBuff));
            try
            {
                Marshal.StructureToPtr<Interop.CkmcRawBuffer>(rawBuff, ptr, false);
                Interop.CheckNThrowException(
                    Interop.CkmcTypes.ParamListSetBuffer(
                        Ptr, (int)name, ptr),
                    "Failed to add parameter.");
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        internal long GetInteger(CipherParameterName name)
        {
            long value = 0;
            Interop.CheckNThrowException(
                Interop.CkmcTypes.ParamListGetInteger(
                    Ptr, (int)name, out value),
                "Failed to get parameter.");
            return value;
        }

        internal byte[] GetBuffer(CipherParameterName name)
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcTypes.ParamListGetBuffer(
                        Ptr, (int)name, out ptr),
                    "Failed to get parameter.");
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);
            }
        }

        internal CipherAlgorithmType Algorithm
        {
            get
            {
                return (CipherAlgorithmType)GetInteger(
                    CipherParameterName.AlgorithmType);
            }
        }

        internal IntPtr Ptr
        {
            get { return this.handle; }
        }

        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.ParamListFree(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
