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
using Tizen.System;
using System.Runtime.InteropServices;
using static Interop.MediaVision;

namespace Tizen.Multimedia.Vision
{
    /// <summary>
    /// A base class for configuration classes.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public abstract class EngineConfiguration : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        private const string _featurePath = "http://tizen.org/feature/vision.";

        private bool IsSupportedEngineType(string type)
        {
            bool isSupported = false;

            string featureType = _featurePath + type;

            bool ret = Information.TryGetValue(featureType, out isSupported);

            return (isSupported && ret) ? true : false;
        }

        private bool IsSupportedEngineType(string type1, string type2)
        {
            return (IsSupportedEngineType(type1) && IsSupportedEngineType(type2)) ? true : false;
        }

        internal EngineConfiguration(string engineType)
        {
            if (IsSupportedEngineType(engineType) == false)
            {
                throw new NotSupportedException($"{engineType} : Not Supported");
            }

            EngineConfig.Create(out _handle).Validate("Failed to create media vision engine.");
        }

        internal EngineConfiguration(string engineType1, string engineType2)
        {
            if (IsSupportedEngineType(engineType1, engineType2) == false)
            {
                throw new NotSupportedException($"{engineType1} or {engineType2} : Not Supported");
            }

            EngineConfig.Create(out _handle).Validate("Failed to create media vision engine.");
        }

        /// <summary>
        /// Finalizes an instance of the EngineConfiguration class.
        /// </summary>
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

        internal void Set(string key, string [] value)
        {
            EngineConfig.SetStringArray(Handle, key, value, value.Length).Validate("Failed to set attribute");
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
                LibcSupport.Free(ptr);
            }
        }

        internal string[] GetStringArray(string key)
        {
            IntPtr values = IntPtr.Zero;
            int size = 0;

            try
            {
                EngineConfig.GetStringArray(Handle, key, out values, out size).
                    Validate("Failed to get the value");

                var current = values;
                var result = new string[size];

                for (int i = 0; i < size; i++)
                {
                    result[i] = Marshal.PtrToStringAnsi(Marshal.ReadIntPtr(current));
                    current = (IntPtr)((long)current + Marshal.SizeOf(typeof(IntPtr)));
                }

                return result;
            }
            finally
            {
                var current = values;
                for (int i = 0; i < size; i++)
                {
                    LibcSupport.Free(Marshal.ReadIntPtr(current));
                    current = (IntPtr)((long)current + Marshal.SizeOf(typeof(IntPtr)));
                }
            }
        }

        /// <summary>
        /// Releases all resources used by the <see cref="EngineConfiguration"/> object.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the resources used by the <see cref="EngineConfiguration"/> object.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources, otherwise false to release only unmanaged resources.
        /// </param>
        /// <since_tizen> 4 </since_tizen>
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
