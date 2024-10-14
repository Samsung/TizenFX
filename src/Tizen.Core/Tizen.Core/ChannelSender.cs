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
    /// Represents the channel sender used for inter-task communication. It provides methods to send messages between tasks in order to facilitate task coordination.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class ChannelSender : IDisposable
    {
        private bool _disposed = false;

        internal ChannelSender(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Finalizes an instance of the ChannelSender class.
        /// </summary>
        ~ChannelSender()
        {
            Dispose(false);
        }

        /// <summary>
        /// Sends the channel object to the receiver.
        /// </summary>
        /// <param name="channelObject">The channel object instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <remarks>
        /// It's important to call the Dispose() method on the passed channel object to release resources.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var channel = new Channel();
        /// var sender = channel.Sender;
        /// string message = "Test";
        /// using (var channelObject = new ChannelObject(1, message))
        /// {
        ///   sender.Send(channelObject);
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Send(ChannelObject channelObject)
        {
            if (channelObject == null)
            {
                throw new ArgumentNullException(nameof(channelObject));
            }

            if (channelObject.Handle == IntPtr.Zero)
            {
                throw new ArgumentException("Invalid argument");
            }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.SenderSend(Handle, channelObject.Handle);
            if (error != Interop.LibTizenCore.ErrorCode.None)
            {
                throw new InvalidOperationException("Failed to send channel object");
            }
            channelObject.IsUsed = true;
        }

        /// <summary>
        /// Creates and returns a copy of the channel sender object.
        /// </summary>
        /// <returns>A newly created channel sender instance.</returns>
        /// <exception cref="InvalidOperationException">Thrown when failed because of an invalid operation.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var channel = new Channel();
        /// var sender = channel.Sender;
        /// var clonedSender = sender.Clone();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public ChannelSender Clone()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.SenderClone(Handle, out IntPtr clonedHandle);
            if (error == Interop.LibTizenCore.ErrorCode.InvalidParameter)
            {
                error = Interop.LibTizenCore.ErrorCode.InvalidContext;
            }
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to clone channel sender");

            return new ChannelSender(clonedHandle);
        }

        internal IntPtr Handle { get; private set; }

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
                    if (Handle != IntPtr.Zero)
                    {
                        Interop.LibTizenCore.TizenCoreChannel.SenderDestroy(Handle);
                        Handle = IntPtr.Zero;
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
