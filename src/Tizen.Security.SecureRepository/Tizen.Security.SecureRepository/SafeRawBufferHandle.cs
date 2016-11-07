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
    internal class SafeRawBufferHandle : SafeHandle
    {
        public SafeRawBufferHandle(IntPtr ptr, bool ownsHandle = true) :
            base(ptr, true)
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
                int ret = Interop.CkmcTypes.BufferNew(
                    this.Data, (UIntPtr)this.Data.Length, out ptr);
                CheckNThrowException(ret, "Failed to create buf");

                if (!this.IsInvalid && !this.ReleaseHandle())
                    throw new InvalidOperationException("Failed to release buf handle");

                this.SetHandle(ptr);
                return this.handle;
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

        /// <summary>
        /// Gets a value that indicates whether the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free
        /// the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            Interop.CkmcTypes.BufferFree(this.handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
