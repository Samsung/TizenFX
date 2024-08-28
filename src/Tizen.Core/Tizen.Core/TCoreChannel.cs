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

namespace Tizen.Core
{
    /// <summary>
    /// The class for managing communication channels between tasks of Tizen Core.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class TCoreChannel : IDisposable
    {
        private bool _disposed = false;

        /// <summary>
        /// Constructor for creating a new channel with a sender and a receiver.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// try
        /// {
        ///   var channel = new TCoreChannel();
        /// }
        /// catch (OutOfMemoryException)
        /// {
        ///   Console.WriteLine("Exception occurs");
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public TCoreChannel()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.MakePair(out IntPtr sender, out IntPtr receiver);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to make a channel pair");
            Sender = new TCoreChannelSender(sender);
            Receiver = new TCoreChannelReceiver(receiver);
        }

        /// <summary>
        /// Finalizer of the class TCoreChannel.
        /// </summary>
        ~TCoreChannel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the TCoreChannelSender instance.
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public TCoreChannelSender Sender { get; private set; }

        /// <summary>
        /// Gets the TCoreChannelReceiver instance. 
        /// </summary>
        /// <since_tizen> 12 </since_tizen>
        public TCoreChannelReceiver Receiver { get; private set; }

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
                    Sender.Dispose();
                    Receiver.Dispose();
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
