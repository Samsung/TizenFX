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
    /// Base class for map service request
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class MapServiceRequest<T> : IDisposable
    {
        protected TaskCompletionSource<IEnumerable<T>> _requestTask;
        protected string errMessage;
        protected int? _requestID;
        protected ServiceRequestType _type;

        internal Action startExecutionAction;
        internal Interop.ErrorCode errorCode;

        internal MapService _service;

        /// <summary>
        /// Creates map service request
        /// </summary>
        /// <param name="service">map service object</param>
        /// <param name="type">Request type</param>
        internal MapServiceRequest(MapService service, ServiceRequestType type)
        {
            _service = service;
            _type = type;
        }

        /// <summary>
        /// Sends request to map service provider
        /// </summary>
        /// <returns>Response from map service provider</returns>
        /// <exception cref="TaskCanceledException">Throws if request is canceled</exception>
        /// <exception cref="InvalidOperationException">Throws if native operation failed</exception>
        public async Task<IEnumerable<T>> GetResponseAsync()
        {
            if (_requestTask == null || _requestTask.Task.IsCanceled)
            {
                _requestTask = new TaskCompletionSource<IEnumerable<T>>();
                startExecutionAction();
                await _requestTask.Task;
            }
            errorCode.WarnIfFailed(errMessage);
            return await _requestTask.Task;
        }

        /// <summary>
        /// Cancel this map service request
        /// </summary>
        public void Cancel()
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

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
