﻿/*
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
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// A constructor of DevicePolicyManager that creates handle.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when connection refused or a memory error occurred.</exception>
        public DevicePolicyManager()
        {
            _handle = Interop.DevicePolicyManager.CreateHandle();
            var lastError = ErrorFacts.GetLastResult();
            if (lastError != (int)Interop.DevicePolicyManager.ErrorCode.None)
            {
                throw DevicePolicyManagerErrorFactory.CreateException(ErrorFacts.GetLastResult());
            }
        }

        /// <summary>
        /// Method to creates an instance of Device Policy.
        /// </summary>
        /// <typeparam name="T">The generic type to create.</typeparam>
        /// <returns>An instance of policy.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// <exception cref="InvalidOperationException">Thrown when failed to create instance of the policy.</exception>
        public T GetPolicy<T>() where T : DevicePolicy
        {
            try
            {
                T policy = Activator.CreateInstance(typeof(T),
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance,
                    null, new object[] { this }, null) as T;
                return policy;
            }
            catch (Exception e)
            {
                Log.Error(Globals.LogTag, "Failed to create policy. " + e.Message);
                throw new InvalidOperationException("Failed to create policy.");
            }
        }

        internal IntPtr GetHandle()
        {
            return _disposed ? IntPtr.Zero : _handle;
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
            if (!_disposed)
            {
                if (disposing)
                {
                    // to be used if there are any other disposable objects
                }

                if (_handle != IntPtr.Zero)
                {
                    int ret = Interop.DevicePolicyManager.DestroyHandle(_handle);
                    if (ret != (int)Interop.DevicePolicyManager.ErrorCode.None)
                    {
                        Log.Error(Globals.LogTag, "Failed to destroy handle " + ret);
                    }

                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
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

    static internal class Globals
    {
        internal const string LogTag = "Tizen.Security.DPM";
    }

    internal static class DevicePolicyManagerErrorFactory
    {
        static internal Exception CreateException(int error)
        {
            Interop.DevicePolicyManager.ErrorCode errCode = (Interop.DevicePolicyManager.ErrorCode)error;
            switch (errCode)
            {
                case Interop.DevicePolicyManager.ErrorCode.InvalidParameter:
                    return new ArgumentException("Invalid parameter");
                case Interop.DevicePolicyManager.ErrorCode.TimeOut:
                    return new TimeoutException("Timeout");
                case Interop.DevicePolicyManager.ErrorCode.PermissionDenied:
                    return new UnauthorizedAccessException("Permission Denied");
                case Interop.DevicePolicyManager.ErrorCode.OutOfMemory:
                    return new InvalidOperationException("Out of memory");
                case Interop.DevicePolicyManager.ErrorCode.ConnectionRefused:
                    return new InvalidOperationException("Connection refused");
                default:
                    return new InvalidOperationException("Unknown Error Code");
            }
        }
    }
}
