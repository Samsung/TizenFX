/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.DataControl
{
    /// <summary>
    /// Represents the BulkData class for the DataControl bulk request.
    /// </summary>
    public class BulkData : IDisposable
    {
        private bool _disposed = false;
        private Interop.DataControl.SafeBulkDataHandle _handle;

        /// <summary>
        /// Initializes the BulkData class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public BulkData()
        {
            ResultType ret;

            ret = Interop.DataControl.BulkCreate(out _handle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkCreate");
            }

        }

        internal BulkData(Interop.DataControl.SafeBulkDataHandle handle)
        {
            ResultType ret;
            int count, i;

            ret = Interop.DataControl.BulkCreate(out _handle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkCreate");
            }

            ret = Interop.DataControl.BulkGetCount(handle, out count);
            for ( i = 0; i < count; i++)
            {
                IntPtr bundleHandle;
                Bundle bundle;

                ret = Interop.DataControl.BulkGetData(handle, i, out bundleHandle);
                if (ret != ResultType.Success)
                {
                    ErrorFactory.ThrowException(ret, true, "BulkGetData");
                }

                bundle = new Bundle(new SafeBundleHandle(bundleHandle, false));
                ret = Interop.DataControl.BulkAdd(_handle, bundle.SafeBundleHandle);
                if (ret != ResultType.Success)
                {
                    ErrorFactory.ThrowException(ret, true, "BulkAdd");
                }
            }
        }

        internal Interop.DataControl.SafeBulkDataHandle SafeBulkDataHandle
        {
            get { return _handle; }
        }

        /// <summary>
        /// Adds the bulk data.
        /// </summary>
        /// <param name="data">Bulk data</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        public void Add(Bundle data)
        {
            ResultType ret;

            if (data == null || data.SafeBundleHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "data");
            }

            ret = Interop.DataControl.BulkAdd(_handle, data.SafeBundleHandle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkAdd");
            }
        }

        /// <summary>
        /// Gets the current data count.
        /// </summary>
        public int GetCount()
        {
            int count;
            ResultType ret;

            ret = Interop.DataControl.BulkGetCount(_handle, out count);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkGetCount");
            }

            return count;
        }

        /// <summary>
        /// Returns the data at the given zero-based data index.
        /// </summary>
        /// <param name="index">The target data index.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        public Bundle GetData(int index)
        {
            IntPtr bundlePtr;
            Bundle bundle;
            ResultType ret;

            if (index < 0)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "index");
            }

            ret = Interop.DataControl.BulkGetData(_handle, index, out bundlePtr);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkGetData");
            }

            bundle = new Bundle(new SafeBundleHandle(bundlePtr, false));
            return bundle;
        }

        /// <summary>
        /// Releases all the resources used by the BulkData class.
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
            if (!_disposed)
            {
                if (_handle != null && !_handle.IsInvalid)
                {
                    _handle.Dispose();
                }

                _disposed = true;
            }
        }

        ~BulkData()
        {
            Dispose(false);
        }
    }

    /// <summary>
    /// Represents the BulkResultData class for the DataControl bulk request.
    /// </summary>
    public class BulkResultData : IDisposable
    {
        private const string LogTag = "Tizen.Applications.DataControl";
        private bool _disposed = false;
        private Interop.DataControl.SafeBulkResultDataHandle _handle;
        /// <summary>
        /// Initializes the BulkResultData class.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown in case of any internal error.</exception>
        public BulkResultData()
        {
            ResultType ret;

            ret = Interop.DataControl.BulkResultCreate(out _handle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true,"BulkResultCreate");
            }
        }

        internal BulkResultData(Interop.DataControl.SafeBulkResultDataHandle handle)
        {
            ResultType ret;

            ret = Interop.DataControl.BulkResultCreate(out _handle);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true,"BulkResultCreate");
            }

            int count;
            ret = Interop.DataControl.BulkResultGetCount(handle, out count);
            for (int i = 0; i < count; i++)
            {
                IntPtr bundleHandle;
                Bundle bundle;
                int result;

                ret = Interop.DataControl.BulkResultGetData(handle, i, out bundleHandle, out result);
                if (ret != ResultType.Success)
                {
                    ErrorFactory.ThrowException(ret, true, "BulkResultGetData");
                }

                bundle = new Bundle(new SafeBundleHandle(bundleHandle, false));
                ret = Interop.DataControl.BulkResultAdd(_handle, bundle.SafeBundleHandle, result);
                if (ret != ResultType.Success)
                {
                    ErrorFactory.ThrowException(ret, true, "BulkResultAdd");
                }
            }
        }

        /// <summary>
        /// Adds the bulk operation result data.
        /// </summary>
        /// <param name="data">The result data.</param>
        /// <param name="result">Result.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        public void Add(Bundle data, int result)
        {
            ResultType ret;

            if (data == null || data.SafeBundleHandle.IsInvalid)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "data");
            }

            ret = Interop.DataControl.BulkResultAdd(_handle, data.SafeBundleHandle, result);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkResultAdd");
            }
        }

        internal Interop.DataControl.SafeBulkResultDataHandle SafeBulkDataHandle
        {
            get { return _handle; }
        }

        /// <summary>
        /// Gets the current result data count.
        /// </summary>
        public int GetCount()
        {
            int count;
            ResultType ret;

            ret = Interop.DataControl.BulkResultGetCount(_handle, out count);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true,"BulkResultGetCount");
            }

            return count;
        }

        /// <summary>
        /// Returns the result data at the given zero-based data index.
        /// </summary>
        /// <param name="index">The target result data index.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        public Bundle GetData(int index)
        {
            IntPtr bundlePtr;
            Bundle bundle;
            ResultType ret;
            int result;

            if (index < 0)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "index");
            }

            ret = Interop.DataControl.BulkResultGetData(_handle, index, out bundlePtr, out result);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkResultGetData");
            }

            bundle = new Bundle(new SafeBundleHandle(bundlePtr, false));
            return bundle;
        }

        /// <summary>
        /// Returns the result at the given zero-based data index.
        /// </summary>
        /// <param name="index">The target result index.</param>
        /// <exception cref="ArgumentException">Thrown in case of an invalid parameter.</exception>
        public int GetResult(int index)
        {
            IntPtr bundlePtr;
            ResultType ret;
            int result;

            if (index < 0)
            {
                ErrorFactory.ThrowException(ResultType.InvalidParameter, false, "index");
            }

            ret = Interop.DataControl.BulkResultGetData(_handle, index, out bundlePtr, out result);
            if (ret != ResultType.Success)
            {
                ErrorFactory.ThrowException(ret, true, "BulkResultGetData");
            }

            return result;
        }

        /// <summary>
        /// Releases all the resources used by the BulkResultData class.
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
            if (!_disposed)
            {
                if (_handle != null && !_handle.IsInvalid)
                {
                    _handle.Dispose();
                }

                _disposed = true;
            }
        }

        ~BulkResultData()
        {
            Dispose(false);
        }
    }
}
