/*
 * Copyright (c) 2024 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Concurrent;

namespace Tizen.Core
{
    /// <summary>
    /// Represents an event object used for broadcasting the event.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class EventObject : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private static readonly ConcurrentDictionary<int, object> _dataMap = new ConcurrentDictionary<int, object>();
        private static readonly object _dataLock = new object();
        private static int _dataId = 0;
        private static Interop.LibTizenCore.TizenCoreEvent.EventObjectDestroyCallback _destroyCallback = new Interop.LibTizenCore.TizenCoreEvent.EventObjectDestroyCallback(NativeObjectDestroyCallback);

        /// <summary>
        /// Constructor for creating a new event object with specified ID and data.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="data">The data object.</param>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// <code>
        /// 
        /// int id = 0;
        /// string message = "Test event";
        /// var eventObject = new EventObject(id++, message);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public EventObject(int id, object data)
        {
            int dataId;
            lock (_dataLock)
            {
                dataId = _dataId++;
            }

            _dataMap[dataId] = data;
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreEvent.ObjectCreate(out _handle, id, (IntPtr)dataId);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to create channel object");

            Interop.LibTizenCore.TizenCoreEvent.ObjectSetDestroyCallback(_handle, _destroyCallback, (IntPtr)dataId);
        }

        internal EventObject(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Finalizes an instance of the EventObject class.
        /// </summary>
        ~EventObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the ID of the event object.
        /// </summary>
        public int Id
        {
            get
            {
                Interop.LibTizenCore.TizenCoreEvent.ObjectGetId(_handle, out int id);
                return id;
            }
        }

        /// <summary>
        /// Gets the Data of the event object.
        /// </summary>
        public object Data
        {
            get
            {
                Interop.LibTizenCore.TizenCoreEvent.ObjectGetData(_handle, out IntPtr handle);
                int id = (int)handle;
                if (_dataMap.TryGetValue(id, out var data))
                {
                    return data;
                }
                return null;
            }
        }

        internal IntPtr Handle { get { return _handle; } set { _handle = value; } }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 12 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_handle != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCoreEvent.ObjectDestroy(_handle);
                        _handle = IntPtr.Zero;
                    }
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Release any unmanaged resources used by this object.
        /// </summary>
        /// <since_tize> 12 </since_tize>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private static void NativeObjectDestroyCallback(IntPtr eventData, IntPtr userData)
        {
            int dataId = (int)eventData;
            _dataMap.TryRemove(dataId, out var _);
        }
    }
}
