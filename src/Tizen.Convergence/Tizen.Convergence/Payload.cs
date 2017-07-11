/*
* Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.Convergence
{
    /// <summary>
    /// Represents a payload used in Tizen D2D convergence
    /// </summary>
    public class Payload : IDisposable
    {
        internal Interop.ConvPayloadHandle _payloadHandle;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        public Payload()
        {
            int ret = Interop.ConvPayload.Create(out _payloadHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create payload");
                throw ErrorFactory.GetException(ret);
            }
        }

        internal Payload(IntPtr payloadHandle)
        {
            _payloadHandle = new Interop.ConvPayloadHandle(payloadHandle, false);
        }

        /// <summary>
        /// Adds a key-value pair to payload
        /// </summary>
        /// <param name="key">The key of the attribute</param>
        /// <param name="value">The value of the attribute</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the arguments passed are null </exception>
        public void Set(string key, string value)
        {
            if(key == null || value == null)
            {
                throw new ArgumentNullException();
            }

            int ret = 0;
            if (value is string)
            {
                ret = Interop.ConvPayload.SetString(_payloadHandle, key, value);
                if (ret != (int)ConvErrorCode.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Failed to add string to payload");
                    throw ErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Adds a key-value pair to payload
        /// </summary>
        /// <param name="key">The key of the attribute</param>
        /// <param name="value">The value of the attribute</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the arguments passed are null </exception>
        public void Set(string key, byte[] value)
        {
            if (key == null || value == null)
            {
                throw new ArgumentNullException();
            }

            int ret = 0;
            ret = Interop.ConvPayload.SetByte(_payloadHandle, key, value.Length, value);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to add string to payload");
                throw ErrorFactory.GetException(ret);
            }
        }


        /// <summary>
        /// Sets binary to payload.
        /// </summary>
        /// <param name="value">The binary to set</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the arguments passed are null </exception>
        public void Set(byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException();
            }

            int ret = 0;
            ret = Interop.ConvPayload.SetBinary(_payloadHandle, value.Length, value);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to add binary to payload");
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Gets the value of the key from payload
        /// </summary>
        /// <param name="key">The key of the attribute</param>
        /// <param name="value">The value of the attribute</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the arguments passed are null </exception>
        /// <exception cref="ArgumentException">Thrown if the key is not found </exception>
        public void Get(string key, out string value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            IntPtr stringPtr = IntPtr.Zero;
            int ret = 0;
            ret = Interop.ConvPayload.GetString(_payloadHandle, key, out stringPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to add string to payload");
                throw ErrorFactory.GetException(ret);
            }

            value = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);
        }

        /// <summary>
        /// Gets the value of the key from payload
        /// </summary>
        /// <param name="key">The key of the attribute</param>
        /// <param name="value">The value of the attribute</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="ArgumentNullException">Thrown if the arguments passed are null </exception>
        /// <exception cref="ArgumentException">Thrown if the key is not found </exception>
        public void Get(string key, out byte[] value)
        {
            if (key == null)
            {
                throw new ArgumentNullException();
            }

            int ret = 0;
            IntPtr byteArrayPtr;
            int byteArraySize;
            ret = Interop.ConvPayload.GetByte(_payloadHandle, key, out byteArraySize, out byteArrayPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to add string to payload");
                throw ErrorFactory.GetException(ret);
            }

            byte[] byteArray = new byte[byteArraySize];
            Marshal.Copy(byteArrayPtr, byteArray, 0, byteArraySize);
            value = byteArray;
            Interop.Libc.Free(byteArrayPtr);
        }

        /// <summary>
        /// Gets binary from payload
        /// </summary>
        /// <param name="value">The result value</param>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        public void Get(out byte[] value)
        {
            int ret = 0;
            IntPtr byteArrayPtr;
            int byteArraySize;
            ret = Interop.ConvPayload.GetBinary(_payloadHandle, out byteArraySize, out byteArrayPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to get binary from payload");
                throw ErrorFactory.GetException(ret);
            }

            byte[] byteArray = new byte[byteArraySize];
            Marshal.Copy(byteArrayPtr, byteArray, 0, byteArraySize);
            value = byteArray;
            Interop.Libc.Free(byteArrayPtr);
        }

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            _payloadHandle.Dispose();
        }
    }
}
