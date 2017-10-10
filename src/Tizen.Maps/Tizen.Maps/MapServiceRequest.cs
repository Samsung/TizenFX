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
using System.Threading.Tasks;

namespace Tizen.Maps
{
    /// <summary>
    /// Base class for a map service request.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <typeparam name="T"></typeparam>
    public abstract class MapServiceRequest<T> : IDisposable
    {
        internal TaskCompletionSource<IEnumerable<T>> _requestTask;
        internal string errMessage;
        internal int? _requestID;
        internal ServiceRequestType _type;

        internal Action startExecutionAction;
        internal Interop.ErrorCode errorCode;

        internal MapService _service;

        /// <summary>
        /// Creates a map service request.
        /// </summary>
        /// <param name="service">Map service object.</param>
        /// <param name="type">Request type.</param>
        internal MapServiceRequest(MapService service, ServiceRequestType type)
        {
            _service = service;
            _type = type;
        }

        /// <summary>
        /// Sends a request to the map service provider.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Response from the map service provider.</returns>
        /// <privilege>http://tizen.org/privilege/mapservice</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/network.get</privilege>
        /// <exception cref="System.NotSupportedException">Thrown when the required feature is not supported.</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when application does not have some privilege to access this method.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the result is invalid.</exception>
        /// <exception cref="System.ArgumentException">Thrown when arguments are invalid.</exception>
        public async Task<IEnumerable<T>> GetResponseAsync()
        {
            IEnumerable<T> task = null;
            if (_requestTask == null || _requestTask.Task.IsCanceled)
            {
                _requestTask = new TaskCompletionSource<IEnumerable<T>>();
                startExecutionAction();
                task = await _requestTask.Task.ConfigureAwait(false);
            }
            errorCode.WarnIfFailed(errMessage);
            return task;
        }

        internal void Cancel()
        {
            if (_requestTask?.Task.IsCompleted == false)
            {
                _requestTask?.SetCanceled();
                if (_requestID != null)
                {
                    var err = Interop.CancelRequest(_service.handle, (int)_requestID);
                    err.ThrowIfFailed($"Unable to cancel service request, Type: {_type}, ID: {_requestID}");
                }

                errorCode = Interop.ErrorCode.Canceled;
            }
        }

        #region IDisposable Support
        private bool _disposedValue = false;

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">If true, managed and unmanaged resources can be disposed, otherwise only unmanaged resources can be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    Cancel();
                    _service.Dispose();
                }
                _disposedValue = true;
            }
        }

        /// <summary>
        /// Releases all the resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
