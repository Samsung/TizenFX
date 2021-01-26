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
using Tizen.Applications;

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// The message port API provides functions to send and receive messages between applications.
    /// </summary>
    /// <remarks>
    /// The message port API provides functions for passing messages between applications. An application should register its own local port to receive messages from remote applications.
    /// If a remote application sends a message, the registered callback function of the local port is called.
    /// The trusted message-port API allows communications between applications that are signed by the same developer(author) certificate.
    /// </remarks>
    /// <since_tizen> 3 </since_tizen>
    public class MessagePort : IDisposable
    {
        private static readonly object s_lock = new object();
        private static readonly HashSet<string> s_portMap = new HashSet<string>();
        private static string LogTag = "MessagePort";

        // The name of the local message port
        private readonly string _portName = null;

        // If true the message port is a trusted port, otherwise false it is not
        private readonly bool _trusted = false;

        // The local message port ID
        private int _portId = 0;

        // If true the message port is listening, otherwise false it is not
        private bool _listening = false;

        private Interop.MessagePort.message_port_message_cb _messageCallBack;

        /// <summary>
        /// Initializes the instance of the MessagePort class.
        /// </summary>
        /// <param name="portName">The name of the local message port.</param>
        /// <param name="trusted">If true, it is the trusted message port of application, otherwise false.</param>
        /// <exception cref="System.ArgumentException">Thrown when portName is null or empty.</exception>
        /// <example>
        /// <code>
        /// MessagePort messagePort = new MessagePort("SenderPort", true);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public MessagePort(string portName, bool trusted)
        {
            if (String.IsNullOrEmpty(portName))
            {
                MessagePortErrorFactory.ThrowException((int)MessagePortError.InvalidParameter, "Invalid PortName", "PortName");
            }
            _portName = portName;
            _trusted = trusted;
        }

        /// <summary>
        /// Destructor of the MessagePort class.
        /// </summary>
        ~MessagePort()
        {
            Dispose(false);
        }

        /// <summary>
        /// Called when a message is received.
        /// </summary>
        /// <example>
        /// <code>
        /// MessagePort messagePort = new MessagePort("SenderPort", true);
        /// messagePort.MessageReceived += MessageReceivedCallback;
        /// static void MessageReceivedCallback(object sender, MessageReceivedEventArgs e)
        /// {
        ///     Console.WriteLine("Message Received ");
        ///     if (e.Remote.AppId != null) {
        ///         Console.WriteLine("from :"+e.Remote.AppId);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The name of the local message port.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PortName
        {
            get
            {
                return _portName;
            }
        }
        /// <summary>
        /// If true, the message port is a trusted port, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Trusted
        {
            get
            {
                return _trusted;
            }
        }

        /// <summary>
        /// If true, the message port is listening, otherwise false.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Listening
        {
            get
            {
                return _listening;
            }
        }

        /// <summary>
        /// Register the local message port.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when portName is already used, when there is an I/O error.</exception>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// MessagePort messagePort = new MessagePort("SenderPort", true);
        /// messagePort.MessageReceived += MessageReceivedCallback;
        /// messagePort.Listen();
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void Listen()
        {
            lock (s_lock)
            {
                if (s_portMap.Contains(_portName))
                {
                    MessagePortErrorFactory.ThrowException((int)MessagePortError.InvalidOperation, _portName + "is already used");
                }
                _messageCallBack = (int localPortId, string remoteAppId, string remotePortName, bool trusted, IntPtr message, IntPtr userData) =>
                {
                    MessageReceivedEventArgs args = new MessageReceivedEventArgs();
                    try
                    {
                        args.Message = new Bundle(new SafeBundleHandle(message, false));
                    }
                    catch (Exception ex)
                    {
                        Log.Error(LogTag, "Exception(" + ex.ToString() + ")");
                        args.Message = null;
                    }

                    if (args.Message == null)
                    {
                        Log.Error(LogTag, "Failed to create Bundle. message({0})", (message == IntPtr.Zero) ? "null" : message.ToString());
                        return;
                    }

                    args.Remote = new RemoteValues()
                    {
                        AppId = remoteAppId != null ? remoteAppId : String.Empty,
                        PortName = remotePortName != null ? remotePortName : String.Empty,
                        Trusted = trusted
                    };
                    MessageReceived?.Invoke(this, args);
                };

                _portId = _trusted ?
                            Interop.MessagePort.RegisterTrustedPort(_portName, _messageCallBack, IntPtr.Zero) :
                            Interop.MessagePort.RegisterPort(_portName, _messageCallBack, IntPtr.Zero);

                if (_portId <= 0)
                    MessagePortErrorFactory.ThrowException(_portId, "RegisterPort", _portName);

                s_portMap.Add(_portName);
                _listening = true;
            }
        }

        /// <summary>
        /// Unregisters the local message port.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when messageport is already stopped, when there is an I/O error, when the port is not found.</exception>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// MessagePort messagePort = new MessagePort("SenderPort", true);
        /// messagePort.MessageReceived += MessageReceivedCallback;
        /// messagePort.Listen();
        /// using (var message = new Tizen.Application.Bundle())
        /// {
        ///     message.AddItem("message", "a_string");
        ///     messagePort.Send(message, "ReceiverAppID", "ReceiverPort");
        /// }
        /// messagePort.StopListening();
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void StopListening()
        {
            if (!_listening)
            {
                MessagePortErrorFactory.ThrowException((int)MessagePortError.InvalidOperation, "Already stopped");
            }

            int ret = _trusted ?
                        Interop.MessagePort.UnregisterTrustedPort(_portId) :
                        Interop.MessagePort.UnregisterPort(_portId);

            if (ret != (int)MessagePortError.None)
            {
                MessagePortErrorFactory.ThrowException(ret, "Error Unregister port");
            }

            lock (s_lock)
            {
                s_portMap.Remove(_portName);
            }
            _portId = 0;
            _listening = false;
        }

        /// <summary>
        /// Sends an untrusted message to the message port of a remote application.
        /// </summary>
        /// <param name="message">The message to be passed to the remote application, the recommended message size is under 4KB.</param>
        /// <param name="remoteAppId">The ID of the remote application.</param>
        /// <param name="remotePortName">The name of the remote message port.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when there is an I/O error, when the port is not found.</exception>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when message has exceeded the maximum limit(4KB).</exception>
        /// <example>
        /// <code>
        /// MessagePort messagePort = new MessagePort("SenderPort", true);
        /// messagePort.MessageReceived += MessageReceivedCallback;
        /// messagePort.Listen();
        /// using (var message = new Tizen.Application.Bundle())
        /// {
        ///     message.AddItem("message", "a_string");
        ///     messagePort.Send(message, "ReceiverAppID", "ReceiverPort");
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void Send(Bundle message, string remoteAppId, string remotePortName)
        {
            Send(message, remoteAppId, remotePortName, false);
        }

        /// <summary>
        /// Sends a message to the message port of a remote application.
        /// </summary>
        /// <param name="message">The message to be passed to the remote application, the recommended message size is under 4KB.</param>
        /// <param name="remoteAppId">The ID of the remote application.</param>
        /// <param name="remotePortName">The name of the remote message port.</param>
        /// <param name="trusted">If true, it is the trusted message port of remote application, otherwise false.</param>
        /// <exception cref="System.InvalidOperationException">Thrown when there is an I/O error, when the port is not found.</exception>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when message has exceeded the maximum limit(4KB).</exception>
        /// <exception cref="System.UnauthorizedAccessException">Thrown when the remote application is not signed with the same certificate.</exception>
        /// <example>
        /// <code>
        /// MessagePort messagePort = new MessagePort("SenderPort", true);
        /// messagePort.MessageReceived += MessageReceivedCallback;
        /// messagePort.Listen();
        /// using (var message = new Tizen.Application.Bundle())
        /// {
        ///     message.AddItem("message", "a_string");
        ///     messagePort.Send(message, "ReceiverAppID", "ReceiverPort", true);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void Send(Bundle message, string remoteAppId, string remotePortName, bool trusted)
        {
            if (!_listening)
            {
                MessagePortErrorFactory.ThrowException((int)MessagePortError.InvalidOperation, "Should start listen before send");
            }
            if (message == null || message.SafeBundleHandle == null || message.SafeBundleHandle.IsInvalid)
            {
                MessagePortErrorFactory.ThrowException((int)MessagePortError.InvalidParameter, "message is null", "Message");
            }
            int ret = trusted ?
                        Interop.MessagePort.SendTrustedMessageWithLocalPort(remoteAppId, remotePortName, message.SafeBundleHandle, _portId) :
                        Interop.MessagePort.SendMessageWithLocalPort(remoteAppId, remotePortName, message.SafeBundleHandle, _portId);

            if (ret != (int)MessagePortError.None)
            {
                if (ret == (int)MessagePortError.MaxExceeded)
                {
                    MessagePortErrorFactory.ThrowException(ret, "Message has exceeded the maximum limit(4KB)", "Message");
                }
                MessagePortErrorFactory.ThrowException(ret, "Can't send message");
            }
        }

        /// <summary>
        /// Releases the unmanaged resources used by the MessagePort class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_listening)
            {
                try
                {
                    StopListening();
                }
                catch (Exception e)
                {
                    Log.Warn(GetType().Namespace, "Exception in Dispose :" + e.Message);
                }
            }
        }

        /// <summary>
        /// Releases all resources used by the MessagePort class.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
