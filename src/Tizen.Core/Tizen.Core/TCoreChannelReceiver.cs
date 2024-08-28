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
using System.Threading.Tasks;

namespace Tizen.Core
{
    /// <summary>
    /// Represents the TCoreChannelReceiver class.
    /// </summary>
    /// <since_tizen> 12 </since_tizen>
    public class TCoreChannelReceiver : IDisposable
    {
        private bool _disposed = false;

        internal TCoreChannelReceiver(IntPtr handle)
        {
            Handle = handle;
        }

        /// <summary>
        /// Finalizer of the class TCoreChannelReceiver.
        /// </summary>
        ~TCoreChannelReceiver()
        {
            Dispose(false);
        }

        /// <summary>
        /// Occurrs whenever the channel object is received in the main loop of the task.
        /// </summary>
        /// <remarks>
        /// The registered event handler will be invoked when the TCoreChannelReceiver is added to the specific task.
        /// </remarks>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var sender = channel.Sender;
        /// sender.Received += (s, e) => {
        ///   Console.WriteLine("OnChannelObjectReceived. Message = {}", (string)e.Data);
        /// };
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public event EventHandler<TCoreChannelReceivedEventArgs> Received;

        /// <summary>
        /// Receives the channel object from the sender asynchronously.
        /// </summary>
        /// <returns>The received TCoreChannelObject.</returns>
        /// <example>
        /// <code>
        /// 
        /// var channel = new TCoreChannel();
        /// var coreTask = TCoreTask.Find("Test");
        /// coreTask.Send(async () => {
        ///   var channelObject = await channel.Receiver.Receive();
        ///   Console.WriteLine("Message = {}", (string)channelObject.Data);
        /// });
        /// 
        /// </code>
        /// </example>
        /// <since_tizen> 12 </since_tizen>
        public async Task<TCoreChannelObject> Receive()
        {
            return await Task.Run(() =>
            {
                Interop.LibTizenCore.ErrorCode error = Interop.LibTizenCore.TizenCoreChannel.ReceiverReceive(Handle, out IntPtr channelObject);
                TCoreErrorFactory.CheckAndThrownException(error, "Failed to receive channel object");
                return new TCoreChannelObject(channelObject);
            }).ConfigureAwait(false);
        }

        internal IntPtr Handle { get; set; }

        internal void InvokeEventHandler(object sender, TCoreChannelReceivedEventArgs e)
        {
            Received?.Invoke(sender, e);
        }

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
                        Interop.LibTizenCore.TizenCoreChannel.ReceiverDestroy(Handle);
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
