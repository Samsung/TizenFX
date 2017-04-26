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
using System.Runtime.InteropServices;

namespace Tizen.Convergence
{
    /// <summary>
    /// The class abstracts the features provided by Tizen D2D Convergence.
    /// </summary>
    /// <seealso cref="AppCommunicationService"/>
    public abstract class Service : IDisposable
    {
        internal Interop.ConvServiceHandle _serviceHandle;
        internal const string ServiceIdKey = "service_id";
        internal const string ServiceVersionKey = "service_version";

        private event EventHandler<ServiceEventOccuredEventArgs> _serviceEventOccured;

        internal Service(Interop.ServiceType type)
        {
            int ret = Interop.ConvService.Create(out _serviceHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create service handle");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.ConvService.SetType(_serviceHandle, (int)type);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to create service handle");
                throw ErrorFactory.GetException(ret);
            }
        }

        internal Service(IntPtr existingServiceHandle)
        {
            int ret = Interop.ConvService.Clone(existingServiceHandle, out _serviceHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to clone device");
                throw ErrorFactory.GetException(ret);
            }

            IntPtr stringPtr = IntPtr.Zero;
            ret = Interop.ConvService.GetPropertyString(_serviceHandle, ServiceIdKey, out stringPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to get service Id");
                throw ErrorFactory.GetException(ret);
            }

            Id = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            ret = Interop.ConvService.GetPropertyString(_serviceHandle, ServiceVersionKey, out stringPtr);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to get service version");
                throw ErrorFactory.GetException(ret);
            }

            Version = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);
        }

        /// <summary>
        /// The ID of the service
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// The Version of the service
        /// </summary>
        public string Version { get; }

        /// <summary>
        /// The event handler for Service Events(Start/Publish/Read/Stop)
        /// </summary>
        public event EventHandler<ServiceEventOccuredEventArgs> ServiceEventOccurred
        {
            add
            {
                if (_serviceEventOccured == null)
                {
                    RegisterServiceEventListener();
                }
                _serviceEventOccured += value;
            }
            remove
            {
                _serviceEventOccured -= value;
                if (_serviceEventOccured == null)
                {
                    UnregisterServiceEventListener();
                }
            }
        }

        /// <summary>
        /// The event handler for service error events
        /// </summary>
        public event EventHandler<ServiceErrorOccuredEventArgs> ServiceErrorOccured;

        /// <summary>
        /// The dispose method
        /// </summary>
        public void Dispose()
        {
            _serviceHandle.Dispose();
        }

        internal static Service GetService(IntPtr serviceHandle)
        {
            Service service = null;
            int serviceType;
            int ret = Interop.ConvService.GetType(serviceHandle, out serviceType);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to get service version");
                throw ErrorFactory.GetException(ret);
            }
            if (serviceType == (int)Interop.ServiceType.AppCommunication)
            {
                service = new AppCommunicationService(serviceHandle);
            }

            return service;
        }

        private void RegisterServiceEventListener()
        {
            int ret = Interop.ConvService.SetListenerCb(_serviceHandle, serviceEventsCb, IntPtr.Zero);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to set listener for service events");
                throw ErrorFactory.GetException(ret);
            }
        }

        private void UnregisterServiceEventListener()
        {
            int ret = Interop.ConvService.UnsetListenerCb(_serviceHandle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Failed to unset listener for service events");
                throw ErrorFactory.GetException(ret);
            }
        }

        private void serviceEventsCb(IntPtr serviceHandle, IntPtr channelHandle, int error, IntPtr resultPayloadHandle, IntPtr userData)
        {
            Log.Debug(ErrorFactory.LogTag, "service event occured. error code :[" + error + "]");

            if (error == (int)ConvErrorCode.None)
            {
                var channel = (channelHandle == IntPtr.Zero) ? null : new Channel(channelHandle);
                var payload = (resultPayloadHandle == IntPtr.Zero) ? null : new Payload(resultPayloadHandle);
                _serviceEventOccured?.Invoke(this, new ServiceEventOccuredEventArgs()
                {
                    Payload = payload,
                    Channel = channel
                });
            }
            else
            {
                var eventArgs = new ServiceErrorOccuredEventArgs()
                {
                    Exception = ErrorFactory.GetException(error)
                };
                ServiceErrorOccured?.Invoke(this, eventArgs);
            }
        }
    }
}
