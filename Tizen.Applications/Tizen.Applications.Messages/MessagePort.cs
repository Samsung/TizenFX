using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Tizen.Internals;

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
    public class MessagePort
    {
        private static Dictionary<MessagePort, int> s_portMap = new Dictionary<MessagePort, int>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName">The name of the local message port</param>
        /// <param name="trusted">If true is the trusted message port of application, otherwise false</param>
        public MessagePort(string portName, bool trusted)
        {
            _portName = portName;
            _trusted = trusted;
        }

        ~MessagePort()
        {
            if (_listening)
            {
                StopListening();
            }
        }

        /// <summary>
        /// Called when a message is received.
        /// </summary>
        public event EventHandler<MessageReceivedEventArgs> MessageReceived;

        private enum MessagePortError
        {
            None = Internals.Errors.ErrorCode.None,
            IOError = Internals.Errors.ErrorCode.IoError,
            OutOfMemory = Internals.Errors.ErrorCode.OutOfMemory,
            InvalidParameter = Internals.Errors.ErrorCode.InvalidParameter,
            PortNotFound = -0x01130000 | 0x01,
            CertificateNotMatch = -0x01130000 | 0x02,
            MaxExceeded = -0x01130000 | 0x03,
            ResourceUnavailable = -0x01130000 | 0x04
        }

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
        /// The local message port ID
        /// </summary>
        private int _portId = 0;

        /// <summary>
        /// The name of the local message port
        /// </summary>
        private string _portName = null;

        /// <summary>
        /// If true the message port is a trusted port, otherwise false it is not
        /// </summary>
        private bool _trusted = false;

        /// <summary>
        /// If true the message port is listening, otherwise false it is not
        /// </summary>
        private bool _listening = false;

        private Interop.MessagePort.message_port_message_cb _messageCallBack;

        /// <summary>
        /// Register the local message port.
        /// </summary>
        public void Listen()
        {
            if (!s_portMap.ContainsKey(this))
            {
                _messageCallBack = (int localPortId, string remoteAppId, string remotePortName, bool trusted, IntPtr message, IntPtr userData) =>
                {
                    Bundle bundle = new Bundle(message);
                    MessageReceivedEventArgs args;

                    if (remotePortName != null)
                    {
                        args = new MessageReceivedEventArgs(bundle, remoteAppId, remotePortName, trusted);
                    }
                    else
                    {
                        args = new MessageReceivedEventArgs(bundle);
                    }

                    RaiseMessageReceivedEvent(MessageReceived, args);
                };

                if (_trusted)
                {
                    _portId = Interop.MessagePort.RegisterTrustedPort(_portName, _messageCallBack, IntPtr.Zero);
                }
                else
                {
                    _portId = Interop.MessagePort.RegisterPort(_portName, _messageCallBack, IntPtr.Zero);
                }

                if(_portId > 0)
                {
                    s_portMap.Add(this, 1);
                    _listening = true;
                }
                else
                {
                    switch ((MessagePortError)_portId)
                    {
                        case MessagePortError.IOError: throw new IOException("I/O Error");
                        case MessagePortError.OutOfMemory: throw new InvalidOperationException("Out of memory");
                        case MessagePortError.InvalidParameter: throw new ArgumentException("Invalid parameter");
                    }
                }
            }
            else
            {
                throw new ArgumentException("Already listening");
            }
        }

        /// <summary>
        /// Unregisters the local message port.
        /// </summary>
        public void StopListening()
        {
            if (_listening)
            {
                int ret;
                if (_trusted)
                {
                    ret = Interop.MessagePort.UnregisterTrustedPort(_portId);
                }
                else
                {
                    ret = Interop.MessagePort.UnregisterPort(_portId);
                }

                if (ret == 0)
                {
                    s_portMap.Remove(this);
                    _portId = 0;
                    _listening = false;
                }
                else
                {
                    switch ((MessagePortError)ret)
                    {
                        case MessagePortError.IOError: throw new IOException("I/O Error");
                        case MessagePortError.OutOfMemory: throw new InvalidOperationException("Out of memory");
                        case MessagePortError.InvalidParameter: throw new ArgumentException("Invalid parameter");
                        case MessagePortError.PortNotFound: throw new ArgumentNullException("Port not found");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Already stopped");
            }
        }

        /// <summary>
        /// Sends a message to the message port of a remote application.
        /// </summary>
        /// <param name="message">The message to be passed to the remote application, the recommended message size is under 4KB</param>
        /// <param name="remoteAppId">The ID of the remote application</param>
        /// <param name="remotePortName">The name of the remote message port</param>
        /// <param name="trusted">If true the trusted message port of remote application otherwise false</param>
        public void Send(Bundle message, string remoteAppId, string remotePortName, bool trusted=false)
        {
            if (_listening)
            {
                int ret;
                if (trusted)
                {
                    ret = Interop.MessagePort.SendTrustedMessageWithLocalPort(remoteAppId, remotePortName, message.Handle, _portId);
                }
                else
                {
                    ret = Interop.MessagePort.SendMessageWithLocalPort(remoteAppId, remotePortName, message.Handle, _portId);
                }
                if (ret != 0)
                {
                    switch ((MessagePortError)ret)
                    {
                        case MessagePortError.IOError: throw new IOException("I/O Error");
                        case MessagePortError.InvalidParameter: throw new ArgumentException("Invalid parameter");
                        case MessagePortError.OutOfMemory: throw new InvalidOperationException("Out of memory");
                        case MessagePortError.PortNotFound: throw new ArgumentNullException("Port not found");
                        case MessagePortError.CertificateNotMatch: throw new ArgumentException("Certification not match");
                        case MessagePortError.MaxExceeded: throw new ArgumentOutOfRangeException("Max(4KB) exceeded");
                        case MessagePortError.ResourceUnavailable: throw new ArgumentNullException("Resource unavailable");
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Need listening");
            }
        }

        /// <summary>
        /// Override GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash = 0;
            if (_portName != null)
            {
                hash ^= _portName.GetHashCode();
            }
            hash ^= _trusted.GetHashCode();
            return hash;
        }

        /// <summary>
        /// Override Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            MessagePort p = obj as MessagePort;
            if (p == null)
            {
                return false;
            }
            return (_portName == p._portName) & (_trusted == p._trusted);
        }

        private void RaiseMessageReceivedEvent(EventHandler<MessageReceivedEventArgs> evt, MessageReceivedEventArgs args)
        {
            if (evt != null)
            {
                evt(this, args);
            }
        }
    }
}
