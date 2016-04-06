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
    public class MessagePort : IDisposable
    {
        private static object s_lock = new object();
        private static HashSet<string> s_portMap = new HashSet<string>();

        /// <summary>
        /// Constructor
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

        ~MessagePort()
        {
            if (_listening)
            {
                StopListening();
            }
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
            lock (s_lock)
            {
                if (s_portMap.Contains(_portName))
                {
                    throw new InvalidOperationException(_portName + " is already used");
                }
                _messageCallBack = (int localPortId, string remoteAppId, string remotePortName, bool trusted, IntPtr message, IntPtr userData) =>
                {
                    MessageReceivedEventArgs args = new MessageReceivedEventArgs() {
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
                    RaiseMessageReceivedEvent(MessageReceived, args);
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
        /// Sends a message to the message port of a remote application.
        /// </summary>
        /// <param name="message">The message to be passed to the remote application, the recommended message size is under 4KB</param>
        /// <param name="remoteAppId">The ID of the remote application</param>
        /// <param name="remotePortName">The name of the remote message port</param>
        /// <param name="trusted">If true the trusted message port of remote application otherwise false</param>
        public void Send(Bundle message, string remoteAppId, string remotePortName, bool trusted = false)
        {
            if (!_listening)
            {
                throw new InvalidOperationException("Sould start listen before send");
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

        private void RaiseMessageReceivedEvent(EventHandler<MessageReceivedEventArgs> evt, MessageReceivedEventArgs args)
        {
            if (evt != null)
            {
                evt(this, args);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_listening)
            {
                StopListening();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}