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
    /// <remarks>
    /// Channels are essential in inter-task communications because they provide a reliable way to exchange messages and data.
    /// By creating a channel, you can establish a connection between two tasks that need to communicate with each other.
    /// Once created, both tasks can send and receive messages through the channel.
    /// It's important to note that channels have a limited capacity, so make sure to handle message overflows appropriately.
    /// Additionally, remember to close the channel once it's no longer needed to avoid resource leaks.
    /// </remarks>
    /// <since_tizen> 12 </since_tizen>
    public class Channel : IDisposable
    {
        private bool _disposed = false;

        /// <summary>
        /// Creates a new channel with a sender and a receiver.
        /// </summary>
        /// <remarks>
        /// This constructor initializes a new channel that enables communication between a sender and a receiver.
        /// It throws exceptions if any errors occur during initialization due to insufficient memory or invalid operations.
        /// </remarks>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <example>
        /// In the following code snippet, we attempt to initialize a new channel by calling the constructor.
        /// However, if there is not enough memory available, an OutOfMemoryException is thrown. We handle this exception by displaying a message in the console.
        /// <code>
        /// try
        /// {
        ///    var channel = new Channel();
        /// }
        /// catch (OutOfMemoryException)
        /// {
        ///    Console.WriteLine("Exception occurs");
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public Channel()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.MakePair(out IntPtr sender, out IntPtr receiver);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to make a channel pair");
            Sender = new ChannelSender(sender);
            Receiver = new ChannelReceiver(receiver);
        }

        /// <summary>
        /// Finalizes an instance of the Channel class.
        /// </summary>
        ~Channel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the channel sender instance.
        /// </summary>
        /// <remarks>
        /// This property provides access to the channel sender instance that can be used to send messages through the specified channel.
        /// It ensures that only one sender instance per channel exists in order to avoid any conflicts during message transmission.
        /// </remarks>
        /// <since_tizen> 12 </since_tizen>
        public ChannelSender Sender { get; private set; }

        /// <summary>
        /// Gets the channel receiver instance.
        /// </summary>
        /// <remarks>
        /// This property provides access to the channel receiver instance that handles incoming messages from other applications.
        /// By utilizing this instance, you can subscribe to specific channels and receive notifications accordingly.
        /// It is crucial to understand the concept of channels in order to effectively utilize this feature. For more details on channels, refer to the official documentation.
        /// </remarks>
        /// <since_tizen> 12 </since_tizen>
        public ChannelReceiver Receiver { get; private set; }

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
