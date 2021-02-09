/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.Applications.ComponentBased
{
    internal class Parcel : IDisposable
    {
        private readonly SafeParcelHandle _handle;

        public Parcel()
        {
            var ret = Interop.Parcel.Create(out _handle);
            if (ret != Interop.Parcel.ErrorCode.None)
            {
                throw ParcelErrorFactory.GetException(ret, "Parcel() is failed.");
            }
        }

        public Parcel(SafeParcelHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentException("handle is null");
            }

            _handle = handle;
        }

        public SafeParcelHandle SafeParcelHandle
        {
            get
            {
                return _handle;
            }
        }

        public byte[] Marshall()
        {
            Interop.Parcel.GetRaw(_handle, out IntPtr raw, out UInt32 size);
            byte[] ret = new byte[size];
            Marshal.Copy((IntPtr)raw, (byte[])ret, 0, (int)size);
            return ret;
        }

        public void UnMarshall(byte[] bytes)
        {
            Interop.Parcel.Reset(_handle, bytes, (UInt32)bytes.Length);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable object.</param>
        /// <since_tizen> 9 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_handle != null && !_handle.IsInvalid)
                        _handle.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the class Parcel.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        ~Parcel()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Releases all the resources used by the class parcel.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        internal static class ParcelErrorFactory
        {
            internal static Exception GetException(Interop.Parcel.ErrorCode err, string message)
            {
                string errMessage = string.Format("{0} err = {1}", message, err);
                switch (err)
                {
                    case Interop.Parcel.ErrorCode.NoData:
                    case Interop.Parcel.ErrorCode.IllegalByteSeq:
                        return new InvalidOperationException(errMessage);
                    case Interop.Parcel.ErrorCode.InvalidParameter:
                        return new ArgumentException(errMessage);
                    default:
                        return new OutOfMemoryException(errMessage);
                }
            }
        }
    }
}