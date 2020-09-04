/*
* Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
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
using NativeApi = Interop.Inspections;

namespace Tizen.Inspections
{
    /// <summary>
    /// The Inspector class is used for requesting client data and receiving inspection events.
    /// </summary>
    public static class Inspector
    {
        private static NativeApi.NotificationCallback _notificationCallback;
        private static event EventHandler<EventReceivedEventArgs> _eventReceived;

        /// <summary>
        /// Event to be invoked when new inspection context arrives.
        /// </summary>
        public static event EventHandler<EventReceivedEventArgs> EventReceived
        {
            add
            {
                if (_eventReceived == null)
                    SetNotificationCallback();
                _eventReceived += value;
            }
            remove
            {
                _eventReceived -= value;
                if (_eventReceived == null)
                    UnsetNotificationCallback();
            }
        }

        /// <summary>
        /// Requests other module (app or service) to provide inspection data.
        /// </summary>
        /// <param name="moduleID">An ID of module to request.</param>
        /// <param name="parameters">Array of request parameters passed to the module.</param>
        /// <returns>
        /// The instance of InspectionData.
        /// </returns>
        /// <remarks>
        /// This function is permitted only to an app signed by platform level certificates.
        /// </remarks>
        public static InspectionData RequestInspectableData(string moduleID, string[] parameters)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            var ret = NativeApi.RequestClientData(moduleID, parameters, parameters.Length, out IntPtr data);
            if (ret != NativeApi.InspectionError.None)
                throw ExceptionFactory.CreateException(ret);

            return new InspectionData(data);
        }

        private static void SetNotificationCallback()
        {
            _notificationCallback = (IntPtr ctx, IntPtr data) =>
            {
                _eventReceived?.Invoke(null, new EventReceivedEventArgs(new InspectionContext(ctx)));
            };

            var ret = NativeApi.SetNotificationCb(_notificationCallback, IntPtr.Zero);
            if (ret != NativeApi.InspectionError.None)
                throw ExceptionFactory.CreateException(ret);
        }

        private static void UnsetNotificationCallback()
        {
            NativeApi.UnsetNotificationCb();
        }
    }

    /// <summary>
    /// The InspectionContext class is used for getting data from the context.
    /// </summary>
    public class InspectionContext : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// The InspectionContext class constructor.
        /// </summary>
        /// <param name="handle">Inspection context received in the EventReceived event.</param>
        internal InspectionContext(IntPtr handle)
        {
            _handle = handle;

            var ret = NativeApi.GetClientID(handle, out string clientID);
            if (ret != NativeApi.InspectionError.None)
                throw ExceptionFactory.CreateException(ret);

            ModuleID = clientID;
        }

        /// <summary>
        /// Finalizes an instance of the InspectionContext class.
        /// </summary>
        ~InspectionContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets data from the context based on given parameters.
        /// </summary>
        /// <param name="parameters">Array of parameters.</param>
        /// <returns>
        /// The instance of InspectionData.
        /// </returns>
        /// <remarks>
        /// This function is permitted only to an app signed by platform level certificates.
        /// </remarks>
        public InspectionData GetInspectableData(string[] parameters)
        {
            if (parameters is null)
                throw new ArgumentNullException(nameof(parameters));

            var ret = NativeApi.GetData(_handle, parameters, parameters.Length, out IntPtr data);
            if (ret != NativeApi.InspectionError.None)
                throw ExceptionFactory.CreateException(ret);

            return new InspectionData(data);
        }

        /// <summary>
        /// Stores module ID.
        /// </summary>
        public string ModuleID { get; internal set; }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    NativeApi.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }
    }

    /// <summary>
    /// The InspectionData class is used for reading inspection data.
    /// </summary>
    public class InspectionData : IDisposable
    {
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// The InspectionData class constructor.
        /// </summary>
        /// <param name="handle">Inspection data handle.</param>
        internal InspectionData(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Finalizes an instance of the InspectionData class.
        /// </summary>
        ~InspectionData()
        {
            Dispose(false);
        }

        /// <summary>
        /// Reads given number of bytes from inspection data.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read.</param>
        /// <returns>
        /// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        public int Read(byte[] buffer, int offset, int count)
        {
            return ReadUnsafe(buffer, offset, count, 0);
        }

        /// <summary>
        /// Reads given number of bytes from inspection data.
        /// </summary>
        /// <param name="buffer">An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset + count - 1) replaced by the bytes read from the current source.</param>
        /// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
        /// <param name="count">The maximum number of bytes to be read.</param>
        /// <param name="timeout">Timeout [ms] for reading requested number of bytes.</param>
        /// <returns>
        /// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available, or zero (0) if the end of the stream has been reached.
        /// </returns>
        public int Read(byte[] buffer, int offset, int count, int timeout)
        {
            return ReadUnsafe(buffer, offset, count, timeout);
        }

        private unsafe int ReadUnsafe(byte[] buffer, int offset, int count, int timeout)
        {
            var length = Convert.ToUInt32(count);
            uint bytes_read = 0;

            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));

            if (offset + count > buffer.Length)
                throw new ArgumentException("The sum of offset and count is larger than the buffer length");

            if (offset < 0)
                throw new ArgumentOutOfRangeException(nameof(offset));

            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));

            fixed (byte* p = &buffer[offset])
            {
                IntPtr ptr = (IntPtr)p;
                var ret = NativeApi.DataRead(_handle, ptr, length, timeout, out bytes_read);
                if (ret < NativeApi.InspectionError.None)
                    throw ExceptionFactory.CreateException(ret);
            }

            return (int)bytes_read;
        }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose API for closing the internal resources.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (_handle != IntPtr.Zero)
                {
                    NativeApi.DataDestroy(_handle);
                    _handle = IntPtr.Zero;
                }
                _disposed = true;
            }
        }
    }
}
