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
using static Interop;

namespace Tizen.Security.SecureRepository
{
    internal class SafeRawBufferHandle
    {
        public SafeRawBufferHandle(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentNullException("Returned ptr from CAPI cannot be null");

            var ckmcBuf = Marshal.PtrToStructure<CkmcRawBuffer>(ptr);
            byte[] data = new byte[(int)ckmcBuf.size];
            Marshal.Copy(ckmcBuf.data, data, 0, data.Length);
            this.Data = data;
        }

        internal IntPtr GetHandle()
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                CheckNThrowException(
                    Interop.CkmcTypes.BufferNew(
                        this.Data, (UIntPtr)this.Data.Length, out ptr),
                    "Failed to create buf");

                return ptr;
            }
            catch
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.BufferFree(ptr);

                throw;
            }
        }

        public byte[] Data
        {
            get; set;
        }
    }
}
