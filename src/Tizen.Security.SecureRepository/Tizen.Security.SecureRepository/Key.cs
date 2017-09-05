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
    /// <summary>
    /// The class that represents a key.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Key
    {
        /// <summary>
        /// A constructor of Key that takes the binary, its type, and optional password
        /// of binary.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="binary">
        /// The binary value of a key. This binary may be encrypted with binaryPassword.
        /// </param>
        /// <param name="type">The key's type.</param>
        /// <param name="binaryPassword">
        /// The password used to decrypt binary when binary is encrypted.
        /// </param>
        public Key(byte[] binary, KeyType type, string binaryPassword)
        {
            this.Binary = binary;
            this.Type = type;
            this.BinaryPassword = binaryPassword;
        }

        internal Key(IntPtr ptr)
        {
            if (ptr == IntPtr.Zero)
                throw new ArgumentNullException("Returned ptr from CAPI cannot be null");

            var ckmcKey = Marshal.PtrToStructure<CkmcKey>(ptr);
            this.Binary = new byte[(int)ckmcKey.size];
            Marshal.Copy(ckmcKey.rawKey, this.Binary, 0, this.Binary.Length);
            this.Type = (KeyType)ckmcKey.keyType;
            this.BinaryPassword = ckmcKey.password;
        }

        // Refresh handle(IntPtr) always. Because C# layer
        // properties(Binary, Type, BinaryPassword) could be changed.
        internal IntPtr GetHandle()
        {
            IntPtr ptr = IntPtr.Zero;
            try
            {
                CheckNThrowException(
                    Interop.CkmcTypes.KeyNew(
                        this.Binary, (UIntPtr)this.Binary.Length, (int)this.Type,
                        this.BinaryPassword, out ptr),
                    "Failed to create key");

                return ptr;
            }
            catch
            {
                if (ptr != IntPtr.Zero)
                    Interop.CkmcTypes.KeyFree(ptr);

                throw;
            }
        }

        /// <summary>
        /// The binary value of a key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Binary
        {
            get; set;
        }

        /// <summary>
        /// The key's type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public KeyType Type
        {
            get; set;
        }

        /// <summary>
        /// The password used to decrypt binary when binary is encrypted. It's optional.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string BinaryPassword
        {
            get; set;
        }

        internal CkmcKey ToCkmcKey()
        {
            return new Interop.CkmcKey(
                (Binary == null) ? IntPtr.Zero : new PinnedObject(this.Binary),
                (Binary == null) ? 0 : this.Binary.Length,
                (int)this.Type,
                this.BinaryPassword);
        }
    }
}
