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
        public SafeRawBufferHandle(IntPtr ptrRawBuffer, bool ownsHandle = true) : base(IntPtr.Zero, true)
        {
            this.SetHandle(ptrRawBuffer);

            if (ptrRawBuffer == IntPtr.Zero)
                return;

            CkmcRawBuffer buff = (CkmcRawBuffer)Marshal.PtrToStructure(ptrRawBuffer, typeof(CkmcRawBuffer));
            byte[] data = new byte[buff.size];
            Marshal.Copy(buff.data, data, 0, data.Length);

            this.Data = data;
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
            get { return handle == IntPtr.Zero; }
        }

        /// <summary>
        /// When overridden in a derived class, executes the code required to free the handle.
        /// </summary>
        /// <returns>true if the handle is released successfully</returns>
        protected override bool ReleaseHandle()
        {
            if (IsInvalid) // do not release
                return true;

            Interop.CkmcTypes.BufferFree(handle);
            this.SetHandle(IntPtr.Zero);
            return true;
        }
    }
}
