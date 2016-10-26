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
using System.Collections.Generic;
using static Interop.MediaVision;

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents an abstract EngineConfiguration class.\n
    /// It provides dictionary functionality. It means that it is possible to set (key, value) pairs to this class \n
    /// and use them to transfer these values to the engine part underlying Media Vision API. \n
    /// Information on which attributes can be set is provided together with concrete engines.
    /// </summary>
    public abstract class EngineConfiguration : IDisposable
    {
        internal IntPtr _engineHandle = IntPtr.Zero;
        private readonly IDictionary<string, object> _config = new Dictionary<string, object>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor of the EngineConfig class.
        /// </summary>
        internal EngineConfiguration()
        {
            int ret = Interop.MediaVision.EngineConfig.Create(out _engineHandle);
            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to create media vision engine.");
        }

        /// <summary>
        /// Destructor of the EngineConfig class.
        /// </summary>
        ~EngineConfiguration()
        {
            Dispose(false);
        }

        internal void Add<T>(string key, T value)
        {
            int ret = 0;
            object val = (object)value;
            if (typeof(T) == typeof(double))
            {
                ret = Interop.MediaVision.EngineConfig.SetDouble(_engineHandle, key, (double)val);
            }
            else if (typeof(T) == typeof(int))
            {
                ret = Interop.MediaVision.EngineConfig.SetInt(_engineHandle, key, (int)val);
            }
            else if (typeof(T) == typeof(bool))
            {
                ret = Interop.MediaVision.EngineConfig.SetBool(_engineHandle, key, (bool)val);
            }
            else if (typeof(T) == typeof(string))
            {
                ret = Interop.MediaVision.EngineConfig.SetString(_engineHandle, key, (string)val);
            }

            MediaVisionErrorFactory.CheckAndThrowException(ret, "Failed to add attribute");
            _config.Add(key, val);
        }

        internal object Get(string key)
        {
            if (_config.ContainsKey(key))
            {
                return _config[key];
            }
            else
            {
                Log.Error(MediaVisionLog.Tag, "Attribute was not set");
                return null;
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // Free managed objects
            }

            Interop.MediaVision.EngineConfig.Destroy(_engineHandle);
            _disposed = true;
        }
    }
}
