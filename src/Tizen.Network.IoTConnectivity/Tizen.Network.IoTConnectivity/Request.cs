/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Class respresenting request to a resource.
    /// It provides APIs to manage client's request.
    /// </summary>
    public class Request : IDisposable
    {
        private bool _disposed = false;

        internal Request()
        {
        }

        /// <summary>
        /// Destructor of the Request class.
        /// </summary>
        ~Request()
        {
            Dispose(false);
        }

        /// <summary>
        /// The host address of the request
        /// </summary>
        public string HostAddress { get; internal set; }

        /// <summary>
        /// The representation of the request
        /// </summary>
        public Representation Representation { get; internal set; }

        /// <summary>
        /// The query of the request
        /// </summary>
        public ResourceQuery Query { get; internal set; }

        /// <summary>
        /// The options related to the request
        /// </summary>
        public ResourceOptions Options { get; internal set; }

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
                return;

            if (disposing)
            {
                Representation?.Dispose();
                Query?.Dispose();
                Options?.Dispose();
            }

            _disposed = true;
        }
    }
}
