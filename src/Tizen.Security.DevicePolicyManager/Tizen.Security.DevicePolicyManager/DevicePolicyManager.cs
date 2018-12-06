/*
 *  Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using Tizen.Internals.Errors;

namespace Tizen.Security.DevicePolicyManager
{
    /// <summary>
    /// The DevicePolicyManager provides the methods to create handle for device policy.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class DevicePolicyManager : IDisposable
    {
        private IntPtr handle = IntPtr.Zero;
        private bool disposed = false;

        /// <summary>
        /// A constructor of DevicePolicyManager that creates handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public DevicePolicyManager()
        {
            handle = Interop.DevicePolicyManager.CreateHandle();
        }

        /// <summary>
        /// Method to creates an instance of Device Policy.
        /// </summary>
        /// <typeparam name="T">The generic type to create.</typeparam>
        /// <returns>An instance of policy.</returns>
        /// <since_tizen> 6 </since_tizen>
        public T GetPolicy<T>() where T : class
        {
            T policy = Activator.CreateInstance(typeof(T),
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                null, new object[] { this }, null) as T;

            if (policy == null)
            {
                return default(T);
            }
            else
            {
                return policy;
            }
        }

        internal IntPtr GetHandle()
        {
            if (disposed)
            {
                return IntPtr.Zero;
            }

            return handle;
        }

        /// <summary>
        /// A Destructor of DevicePolicyManager.
        /// </summary>
        ~DevicePolicyManager()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }
 
            if (handle != IntPtr.Zero)
            {
                Interop.DevicePolicyManager.DestroyHandle(handle);
                handle = IntPtr.Zero;
            }

            disposed = true;
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    internal static class DevicePolicyManagerErrorFactory
    {
        static internal Exception GetException(int error)
        {
            Interop.DevicePolicyManager.DpmError errCode = (Interop.DevicePolicyManager.DpmError)error;
            switch (errCode)
            {
                case Interop.DevicePolicyManager.DpmError.InvalidParameter:
                    return new ArgumentException("Invalid parameter");
                case Interop.DevicePolicyManager.DpmError.TimeOut:
                    return new TimeoutException("Timeout");
                case Interop.DevicePolicyManager.DpmError.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied");
                case Interop.DevicePolicyManager.DpmError.OutOfMemory:
                    return new OutOfMemoryException("Out of memory");
                case Interop.DevicePolicyManager.DpmError.ConnectionRefused:
                    return new InvalidOperationException("Connection refused");
                default:
                    return new InvalidOperationException("Unknown Error Code");
            }
        }
    }
}
