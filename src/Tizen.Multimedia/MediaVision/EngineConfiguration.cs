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
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// A base class for configuration classes.
    /// </summary>
    public abstract class EngineConfiguration : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        internal EngineConfiguration()
        {
            EngineConfig.Create(out _handle).Validate("Failed to create media vision engine.");
        }

        ~EngineConfiguration()
        {
            Dispose(false);
        }

        internal static IntPtr GetHandle(EngineConfiguration config)
        {
            if (config == null)
            {
                return IntPtr.Zero;
            }

            if (config._disposed)
            {
                throw new ObjectDisposedException(config.GetType().Name);
            }

            return config._handle;
        }

        internal void Set(string key, double value)
        {
            EngineConfig.SetDouble(Handle, key, value).Validate("Failed to set attribute");
        }

        internal void Set(string key, int value)
        {
            EngineConfig.SetInt(Handle, key, value).Validate("Failed to set attribute");
        }


        internal void Set(string key, bool value)
        {
            EngineConfig.SetBool(Handle, key, value).Validate("Failed to set attribute");
        }

        internal void Set(string key, string value)
        {
            EngineConfig.SetString(Handle, key, value).Validate("Failed to set attribute");
        }

        internal int GetInt(string key)
        {
            int value = 0;
            EngineConfig.GetInt(Handle, key, out value).Validate("Failed to get the value");
            return value;
        }

        internal double GetDouble(string key)
        {
            double value = 0;
            EngineConfig.GetDouble(Handle, key, out value).Validate("Failed to get the value");
            return value;
        }

        internal bool GetBool(string key)
        {
            bool value = false;
            EngineConfig.GetBool(Handle, key, out value).Validate("Failed to get the value");
            return value;
        }

        internal string GetString(string key)
        {
            IntPtr ptr = IntPtr.Zero;

            try
            {
                EngineConfig.GetString(Handle, key, out ptr).Validate("Failed to get the value");
                return Marshal.PtrToStringAnsi(ptr);
            }
            finally
            {
                Interop.Libc.Free(ptr);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            EngineConfig.Destroy(_handle);
            _disposed = true;
        }

        internal IntPtr Handle
        {
            get
            {
                if (_disposed)
                {
                    throw new ObjectDisposedException(nameof(EngineConfiguration));
                }
                return _handle;
            }
        }
    }
}
