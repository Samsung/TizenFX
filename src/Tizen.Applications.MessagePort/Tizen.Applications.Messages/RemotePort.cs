/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.\
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

namespace Tizen.Applications.Messages
{
    using System;

    /// <summary>
    /// The RemotePort Class provides functions to get if the remote port is running and to get whether the remote port is registered or unregistered.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class RemotePort : IDisposable
    {
        private int _watcherIdForRegistered = -1;
        private int _watcherIdForUnRegistered = -1;
        private bool _disposed = false;

        private Interop.MessagePort.message_port_registration_event_cb _registeredCallBack;
        private Interop.MessagePort.message_port_registration_event_cb _unregisteredCallBack;

        private EventHandler<RemotePortStateChangedEventArgs> _remotePortRegistered;
        private EventHandler<RemotePortStateChangedEventArgs> _remotePortUnregistered;

        private readonly string _portName = null;
        private readonly string _appId = null;
        private readonly bool _trusted = false;

        private bool _isRunning = false;

        /// <summary>
        /// Constructor of the RemotePort class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <param name="appId">The Id of the remote application</param>
        /// <param name="portName">The name of the remote message port</param>
        /// <param name="trusted">If true is the trusted message port of application, otherwise false</param>
        /// <exception cref="System.ArgumentException">Thrown when appId is null or empty, when portName is null or empty</exception>
        /// <example>
        /// <code>
        /// RemotePort remotePort = new RemotePort("org.tizen.example.messageport", "SenderPort", false);
        /// </code>
        /// </example>
        public RemotePort(String appId, string portName, bool trusted)
        {
            if (String.IsNullOrEmpty(appId) || String.IsNullOrEmpty(portName))
            {
                MessagePortErrorFactory.ThrowException((int)MessagePortError.InvalidParameter, "Remote Port", "AppId or PortName");
            }

            _appId = appId;
            _portName = portName;
            _trusted = trusted;

            _registeredCallBack = (string remoteAppId, string remotePortName, bool remoteTrusted, IntPtr userData) =>
            {
                RemotePortStateChangedEventArgs args = new RemotePortStateChangedEventArgs()
                {
                    Status = State.Registered
                };

                _remotePortRegistered?.Invoke(this, args);
            };

            _unregisteredCallBack = (string remoteAppId, string remotePortName, bool remoteTrusted, IntPtr userData) =>
            {
                RemotePortStateChangedEventArgs args = new RemotePortStateChangedEventArgs()
                {
                    Status = State.Unregistered
                };

                _remotePortUnregistered?.Invoke(this, args);
            };
        }

        /// <summary>
        /// Destructor of the RemotePort class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ~RemotePort()
        {
            Dispose(false);
        }

        /// <summary>
        /// The AppId of the remote port
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns> Return appid of RemotePort </returns>
        public string AppId
        {
            get
            {
                return _appId;
            }
        }

        /// <summary>
        /// The name of the remote message port
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <returns> Return name of RemotePort </returns>
        public string PortName
        {
            get
            {
                return _portName;
            }
        }

        /// <summary>
        /// If true the remote port is a trusted port, otherwise if false it is not
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        ///  <returns> Return true if RemotePort is trusted </returns>
        public bool Trusted
        {
            get
            {
                return _trusted;
            }
        }

        /// <summary>
        /// Check if the remote message port is running.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="System.InvalidOperationException">Thrown when there is an I/O error</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// Remote remotePort = new RemotePort("org.tizen.example", "SenderPort", true);
        /// bool isRunning = remotePort.isRunning();
        /// </code>
        /// </example>
        /// <returns> Return true if Remote Port is running </returns>
        public bool IsRunning()
        {
            int ret;

            ret = _trusted ?
                Interop.MessagePort.CheckTrustedRemotePort(_appId, _portName, out _isRunning) :
                Interop.MessagePort.CheckRemotePort(_appId, _portName, out _isRunning);

            if (ret == (int)MessagePortError.CertificateNotMatch)
            {
                /* Although Remote port is NotMatch, it is running */
                _isRunning = true;
            }
            else if (ret != (int)MessagePortError.None)
            {
                MessagePortErrorFactory.ThrowException(ret);
            }

            return _isRunning;
        }

        /// <summary>
        /// Called when the remote port is registered or unregistered.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        /// <exception cref="System.InvalidOperationException">Thrown when there is an I/O error</exception>
        /// <exception cref="System.OutOfMemoryException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// Remote remotePort = new RemotePort("org.tizen.example", "SenderPort", true);
        /// remotePort.RemotePortStateChanged += RemotePortStateChangedCallback;
        /// static void RemotePortStateChangedCallback(object sender, RemotePortStateChangedEventArgs e)
        /// {
        ///     switch (e.Status)
        ///     {
        ///     case State.Registered :
        ///         Console.WriteLine("Remote Port Registered ");
        ///         break;
        ///     case State.Unregistered :
        ///         Console.WriteLine("Remote Port Unregistered ");
        ///         break;
        ///     default :
        ///         break;
        ///     }
        /// }
        /// </code>
        /// </example>
        public event EventHandler<RemotePortStateChangedEventArgs> RemotePortStateChanged
        {
            add
            {
                if (_remotePortRegistered == null)
                {
                    int ret = AddRegistrationCallback();

                    if (ret != (int)MessagePortError.None)
                    {
                        MessagePortErrorFactory.ThrowException(ret);
                    }
                }

                _remotePortRegistered += value;
                _remotePortUnregistered += value;
            }

            remove
            {
                if (_remotePortRegistered?.GetInvocationList()?.Length > 0)
                {
                    _remotePortRegistered -= value;
                    _remotePortUnregistered -= value;

                    if (_remotePortRegistered == null)
                    {
                        int ret = RemoveRegistrationCallback();
                        if (ret != (int)MessagePortError.None)
                        {
                            MessagePortErrorFactory.ThrowException(ret);
                        }
                    }
                }
            }
        }

        private int AddRegistrationCallback()
        {
            if (_watcherIdForRegistered != -1)
            {
                Interop.MessagePort.RemoveRegistrationCallback(_watcherIdForRegistered);
                _watcherIdForRegistered = -1;
            }

            int ret = Interop.MessagePort.AddRegisteredCallback(_appId, _portName, _trusted, _registeredCallBack, IntPtr.Zero, out _watcherIdForRegistered);

            if (ret != (int)MessagePortError.None)
            {
                return ret;
            }

            if (_watcherIdForUnRegistered != -1)
            {
                Interop.MessagePort.RemoveRegistrationCallback(_watcherIdForUnRegistered);
                _watcherIdForUnRegistered = -1;
            }

            ret = Interop.MessagePort.AddUnregisteredCallback(_appId, _portName, _trusted, _unregisteredCallBack, IntPtr.Zero, out _watcherIdForUnRegistered);

            if (ret != (int)MessagePortError.None)
            {
                return ret;
            }

            return ret;
        }

        private int RemoveRegistrationCallback()
        {
            int _retRegistered = (int)MessagePortError.None;
            int _retUnRegistered = (int)MessagePortError.None;
            if (_watcherIdForRegistered != -1)
            {
                _retRegistered = Interop.MessagePort.RemoveRegistrationCallback(_watcherIdForRegistered);

                if (_retRegistered == (int)MessagePortError.None)
                {
                    _watcherIdForRegistered = -1;
                }
            }

            if (_watcherIdForUnRegistered != -1)
            {
                _retUnRegistered = Interop.MessagePort.RemoveRegistrationCallback(_watcherIdForUnRegistered);

                if (_retUnRegistered == (int)MessagePortError.None)
                {
                    _watcherIdForUnRegistered = -1;
                }
            }

            if (_retRegistered != (int)MessagePortError.None ||
                _retUnRegistered != (int)MessagePortError.None)
                return (int)MessagePortError.InvalidOperation;

            return (int)MessagePortError.None;
        }

        /// <summary>
        /// Releases the unmanaged resources used by the RemotePort class specifying whether to perform a normal dispose operation.
        /// </summary>
        /// <param name="disposing">true for a normal dispose operation; false to finalize the handle.</param>
        /// <since_tizen> 4 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            RemoveRegistrationCallback();

            _disposed = true;
        }

        /// <summary>
        /// Releases all resources used by the RemotePort class.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    /// <summary>
    /// Enumeration for Remote Message Port state type
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum State : Byte
    {
        /// <summary>
        /// Value representing Remote Port state is unregistered
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Unregistered = 0,
        /// <summary>
        /// Value representing Remote Port state is registered
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        Registered = 1
    }
}
