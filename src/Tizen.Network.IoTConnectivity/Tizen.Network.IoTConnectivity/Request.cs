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
    /// Class respresenting Request to a resource
    /// </summary>
    public class Request: IDisposable
    {
        private bool _disposed = false;

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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Representation.Dispose();
                Query.Dispose();
                Options.Dispose();
            }

            _disposed = true;
        }
    }
}
