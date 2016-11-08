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
    /// <summary>
    /// A abstract class holding parameters for encryption and decryption.
    /// </summary>
    abstract public class CipherParameters : SafeHandle
    {
        /// <summary>
        /// A constructor with algorithm
        /// </summary>
        /// <param name="algorithm">An algorithm that this parameters are prepared for.</param>
        protected CipherParameters(CipherAlgorithmType algorithm) : base(IntPtr.Zero, true)
        {
            IntPtr ptrParams;
            Interop.CkmcTypes.GenerateNewParam((int)algorithm, out ptrParams);
            this.SetHandle(ptrParams);
        }

        /// <summary>
        /// Adds integer parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <exception cref="ArgumentException">CipherParameterName is invalid.</exception>
        protected void Add(CipherParameterName name, long value)
        {
            int ret = Interop.CkmcTypes.ParamListSetInteger(PtrCkmcParamList, (int)name, value);
            Interop.CheckNThrowException(ret, "Failed to add parameter.");
        }

        /// <summary>
        /// Adds byte array parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <param name="value">Parameter value.</param>
        /// <exception cref="ArgumentException">CipherParameterName is invalid.</exception>
        protected void Add(CipherParameterName name, byte[] value)
        {
            Interop.CkmcRawBuffer rawBuff = new Interop.CkmcRawBuffer(new PinnedObject(value), value.Length);
            IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(rawBuff));
            try
            {
                Marshal.StructureToPtr<Interop.CkmcRawBuffer>(rawBuff, ptr, false);
                int ret = Interop.CkmcTypes.ParamListSetBuffer(PtrCkmcParamList, (int)name, ptr);
                Interop.CheckNThrowException(ret, "Failed to add parameter.");
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        /// <summary>
        /// Gets integer parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <exception cref="ArgumentException">
        /// CipherParameterName is invalid.
        /// No parameter set with the name.
        /// </exception>
        public long GetInteger(CipherParameterName name)
        {
            long value = 0;
            int ret = Interop.CkmcTypes.ParamListGetInteger(PtrCkmcParamList, (int)name, out value);
            Interop.CheckNThrowException(ret, "Failed to get parameter.");
            return value;
        }

        /// <summary>
        /// Gets byte array parameter.
        /// </summary>
        /// <param name="name">Parameter name.</param>
        /// <exception cref="ArgumentException">
        /// CipherParameterName is invalid.
        /// No parameter set with the name.
        /// </exception>
        public byte[] GetBuffer(CipherParameterName name)
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                Interop.CheckNThrowException(
                    Interop.CkmcTypes.ParamListGetBuffer(
                        PtrCkmcParamList, (int)name, out ptr),
                    "Failed to get parameter.");
                return new SafeRawBufferHandle(ptr).Data;
            }
            finally
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);
            }
        }

        /// <summary>
        /// Cipher algorithm type.
        /// </summary>
        public CipherAlgorithmType Algorithm
        {
            get { return (CipherAlgorithmType)GetInteger(CipherParameterName.AlgorithmType); }
        }

        internal IntPtr PtrCkmcParamList
        {
            get { return this.handle; }
        }

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.ParamListFree(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
