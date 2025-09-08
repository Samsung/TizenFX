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
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Tizen.Core
{
    /// <summary>
    /// Represents a channel object used for inter-task communication.
    /// </summary>
    /// <remarks>
    /// A channel object provides a mechanism for tasks to communicate with each other in a process. It allows sending messages between tasks without any race conditions.
    /// To create a channel object, call the static method 'Create'. Once created, you can send and receive messages through the channel by calling the respective methods on the channel object.
    /// When you are done using the channel object, remember to dispose it properly to avoid resource leaks.
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class ChannelObject : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;
        private static readonly ConcurrentDictionary<int, object> _dataMap = new ConcurrentDictionary<int, object>();
        private static readonly object _dataLock = new object();
        private static int _dataId = 1;

        /// <summary>
        /// Constructor for creating a new channel object with specified ID and data.
        /// </summary>
        /// <param name="id">The ID.</param>
        /// <param name="data">The data object.</param>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <remarks>
        /// This constructor creates a new channel object with the specified ID and data. It throws an OutOfMemoryException if there isn't enough memory available to allocate the object.
        /// Additionally, it may throw an InvalidOperationException if the operation fails due to an invalid condition.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// int id = 0;
        /// string message = "Test message";
        /// var channelObject = new ChannelObject(id++, message);
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public ChannelObject(int id, object data)
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.ObjectCreate(out _handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to create channel object");
            Id = id;
            Data = data;
            IsUsed = false;
            IsDestroyable = true;
        }

        internal ChannelObject(IntPtr handle)
        {
            _handle = handle;
            IsUsed = false;
            IsDestroyable = true;
        }

        /// <summary>
        /// Finalizes an instance of the ChannelObject class.
        /// </summary>
        ~ChannelObject()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets and sets the ID.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public int Id
        {
            get
            {
                Interop.LibTizenCore.TizenCoreChannel.ObjectGetId(_handle, out int id);
                return id;
            }
            set
            {
                Interop.LibTizenCore.TizenCoreChannel.ObjectSetId(_handle, value); 
            }            
        }

        /// <summary>
        /// Gets and sets the data object.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public object Data
        {
            get
            {
                Interop.LibTizenCore.TizenCoreChannel.ObjectGetData(_handle, out IntPtr handle);
                int id = (int)handle;
                if (_dataMap.TryGetValue(id, out var data))
                {
                    return data;
                }
                return null;
            }
            set
            {
                int id;
                Interop.LibTizenCore.TizenCoreChannel.ObjectGetData(_handle, out IntPtr handle);
                if (handle != IntPtr.Zero)
                {
                    id = (int)handle;
                    _dataMap.TryRemove(id, out var _);
                }

                lock (_dataLock)
                {
                    if (_dataId + 1 < 0)
                    {
                        _dataId = 1;
                    }
                    id = _dataId++;
                }
                _dataMap[id] = value;
                Interop.LibTizenCore.TizenCoreChannel.ObjectSetData(_handle, (IntPtr)id);
            }
        }

        /// <summary>
        /// Gets the name of the sender task.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public string Sender
        {
            get
            {
                Interop.LibTizenCore.TizenCoreChannel.ObjectGetSenderTaskName(_handle, out IntPtr taskName);
                return Marshal.PtrToStringAnsi(taskName);
            }
        }

        internal bool IsDestroyable { set; get; }

        internal bool IsUsed { set; get; }

        internal IntPtr Handle { get { return _handle; } }

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
                        if (!IsUsed)
                        {
                            Interop.LibTizenCore.TizenCoreChannel.ObjectGetData(_handle, out IntPtr handle);
                            int id = (int)handle;
                            _dataMap.TryRemove(id, out var data);
                        }

                        if (IsDestroyable)
                        {
                            Interop.LibTizenCore.TizenCoreChannel.ObjectDestroy(_handle);
                        }
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
    }
}
