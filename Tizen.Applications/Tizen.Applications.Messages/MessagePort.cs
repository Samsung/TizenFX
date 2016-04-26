using System;
using System.Collections.Generic;

namespace Tizen.Applications.Messages
{
    /// <summary>
    /// The Message Port API provides functions to send and receive messages between applications.
    /// </summary>
    /// <remarks>
    /// The Message Port API provides functions for passing messages between applications. An application should register its own local port to receive messages from remote applications.
    /// If a remote application sends a message, the registered callback function of the local port is called.
    /// The trusted message-port API allows communications between applications that are signed by the same developer(author) certificate.
    /// </remarks>
    public class MessagePort : IDisposable
    {
        private static readonly object s_lock = new object();
        private static readonly HashSet<string> s_portMap = new HashSet<string>();

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
        /// <param name="portName">The name of the local message port</param>
        /// <param name="trusted">If true is the trusted message port of application, otherwise false</param>
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
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        /// <summary>
        /// The name of the local message port
        /// </summary>
        public string PortName
        {
            get
            {
                return _portName;
            }
        }
        /// <summary>
        /// If true the message port is a trusted port, otherwise false it is not
        /// </summary>
        public bool Trusted
        {
            get
            {
                return _trusted;
            }
        }

        /// <summary>
        /// If true the message port is listening, otherwise false it is not
        /// </summary>
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
        public void Listen()
        {
            lock (s_lock)
            {
                if (s_portMap.Contains(_portName))
                {
                    throw new InvalidOperationException(_portName + " is already used");
                }
                _messageCallBack = (int localPortId, string remoteAppId, string remotePortName, bool trusted, IntPtr message, IntPtr userData) =>
                {
                    MessageReceivedEventArgs args = new MessageReceivedEventArgs()
                    {
                        Message = Bundle.MakeRetainedBundle(message)
                    };

                    if (!String.IsNullOrEmpty(remotePortName) && !String.IsNullOrEmpty(remoteAppId))
                    {
                        args.Remote = new RemoteValues()
                        {
                            AppId = remoteAppId,
                            PortName = remotePortName,
                            Trusted = trusted
                        };
                    }
                    MessageReceived?.Invoke(this, args);
                };

                _portId = _trusted ?
                            Interop.MessagePort.RegisterTrustedPort(_portName, _messageCallBack, IntPtr.Zero) :
                            Interop.MessagePort.RegisterPort(_portName, _messageCallBack, IntPtr.Zero);

                if (_portId <= 0)
                    throw new InvalidOperationException("Can't Listening with " + _portName);

                s_portMap.Add(_portName);
                _listening = true;
            }
        }

        /// <summary>
        /// Unregisters the local message port.
        /// </summary>
        public void StopListening()
        {
            if (!_listening)
            {
                throw new InvalidOperationException("Already stopped");
            }

            int ret = _trusted ?
                        Interop.MessagePort.UnregisterTrustedPort(_portId) :
                        Interop.MessagePort.UnregisterPort(_portId);

            if (ret != (int)MessagePortError.None)
            {
                MessagePortErrorFactory.ThrowException(ret);
            }

            lock (s_lock)
            {
                s_portMap.Remove(_portName);
            }
            _portId = 0;
            _listening = false;
        }

        /// <summary>
        /// Sends a untrusted message to the message port of a remote application.
        /// </summary>
        /// <param name="message">The message to be passed to the remote application, the recommended message size is under 4KB</param>
        /// <param name="remoteAppId">The ID of the remote application</param>
        /// <param name="remotePortName">The name of the remote message port</param>
        public void Send(Bundle message, string remoteAppId, string remotePortName)
        {
            Send(message, remoteAppId, remotePortName, false);
        }

        /// <summary>
        /// Sends a message to the message port of a remote application.
        /// </summary>
        /// <param name="message">The message to be passed to the remote application, the recommended message size is under 4KB</param>
        /// <param name="remoteAppId">The ID of the remote application</param>
        /// <param name="remotePortName">The name of the remote message port</param>
        /// <param name="trusted">If true the trusted message port of remote application otherwise false</param>
        public void Send(Bundle message, string remoteAppId, string remotePortName, bool trusted)
        {
            if (!_listening)
            {
                throw new InvalidOperationException("Should start listen before send");
            }
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }
            int ret = trusted ?
                        Interop.MessagePort.SendTrustedMessageWithLocalPort(remoteAppId, remotePortName, message.Handle, _portId) :
                        Interop.MessagePort.SendMessageWithLocalPort(remoteAppId, remotePortName, message.Handle, _portId);

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
        /// Releases the unmanaged resourced used by the MessagePort class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
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
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
