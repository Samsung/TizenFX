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
    /// Represents the TCoreChannelSender class.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class TCoreChannelSender : IDisposable
    {
        private bool _disposed = false;

        internal TCoreChannelSender(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Finalizer of the class TCoreChannelSender.
        /// </summary>
        ~TCoreChannelSender()
        {
            Dispose(false);
        }

        /// <summary>
        /// Sends the channel object to the receiver.
        /// </summary>
        /// <param name="channelObject">The channel object instance.</param>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var sender = channel.Sender;
        /// string message = "Test";
        /// using (var channelObject = new TCoreChannelObject(1, message))
        /// {
        ///   sender.Send(channelObject);
        /// }
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public void Send(TCoreChannelObject channelObject)
        {
            if (channelObject == null)
            {
                throw new ArgumentNullException(nameof(channelObject));
            }

            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.SenderSend(Handle, channelObject.Handle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to send channel object");
            channelObject.IsUsed = true;
        }

        /// <summary>
        /// Creates and returns a copy of the TCoreChannelSender object.
        /// </summary>
        /// <returns>A newly created TCoreChannelSender instance.</returns>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var sender = channel.Sender;
        /// var clonedSender = sender.Clone();
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public TCoreChannelSender Clone()
        {
            Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.SenderClone(Handle, out IntPtr clonedHandle);
            TCoreErrorFactory.CheckAndThrownException(error, "Failed to clone channel sender");

            return new TCoreChannelSender(clonedHandle);
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
