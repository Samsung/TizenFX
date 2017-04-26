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
using Tizen.Internals.Errors;

namespace Tizen.Convergence
{
    /// <summary>
    /// The class provides APIs to support App to App communication service which relies on a remote server.
    /// The initialization and execution of a server app (the app on the side with the Remote Server, e.g. TV) and a client app (e.g. the app on the mobile or wearable device) are slightly different.
    /// On the server side an instance of the App Communication Service should be created and started by the app. Note, on the client side the service handle shouldn’t be created, but obtained during discovery.
    /// For more information, refer Tizen D2D convergence specification
    /// </summary>
    public class AppCommunicationService : Service
    {
        /// <summary>
        /// The constructor
        /// </summary>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        public AppCommunicationService() :
                base(Interop.ServiceType.AppCommunication)
        {

        }

        internal AppCommunicationService(IntPtr serviceHandle) :
                    base(serviceHandle)
        {

        }

        /// <summary>
        /// Starts and initiates the service
        /// </summary>
        /// <param name="channel">Channel to specify a logical session for the service</param>
        /// <param name="payload">Contains additional data for start request. Refer D2D Convergence specification for more information</param>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <privilege>http://tizen.org/privilege/d2d.datasharing</privilege>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the request is not supported as per Tizen D2D convergence specification </exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the arugments are null</exception>
        /// <seealso cref="Service.ServiceEventOccurred"> The result of the request is delivered through this event</seealso>
        public void Start(Channel channel, Payload payload)
        {
            if (channel == null)
            {
                throw new ArgumentNullException();
            }

            Interop.ConvPayloadHandle handle = (payload == null) ? new Interop.ConvPayloadHandle() : payload._payloadHandle;
            int ret = Interop.ConvService.Start(_serviceHandle, channel._channelHandle, handle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop: Failed to start app communication service:" + ErrorFacts.GetErrorMessage(ret));
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Reads data from the channel opened on the service
        /// </summary>
        /// <param name="channel">Channel representing a logical session on the service</param>
        /// <param name="payload">Contains additional data for start request. Refer D2D Convergence specification for more information</param>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the request is not supported as per Tizen D2D convergence specification </exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the arugments are null</exception>
        /// <seealso cref="Service.ServiceEventOccurred"> The result of the request is delivered through this event</seealso>
        public void Read(Channel channel, Payload payload)
        {
            if (channel == null)
            {
                throw new ArgumentNullException();
            }

            Interop.ConvPayloadHandle handle = (payload == null) ? new Interop.ConvPayloadHandle() : payload._payloadHandle;
            int ret = Interop.ConvService.Read(_serviceHandle, channel._channelHandle, handle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop: Failed to read app communication service:" + ErrorFacts.GetErrorMessage(ret));
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Publishes a message to the remote server application
        /// </summary>
        /// <param name="channel">Channel representing a logical session on the service</param>
        /// <param name="payload">Contains additional data for start request. Refer D2D Convergence specification for more information</param>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <privilege>http://tizen.org/privilege/d2d.datasharing</privilege>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the request is not supported as per Tizen D2D convergence specification </exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the arugments are null</exception>
        /// <seealso cref="Service.ServiceEventOccurred"> The result of the request is delivered through this event</seealso>
        public void Publish(Channel channel, Payload payload)
        {
            if (channel == null)
            {
                throw new ArgumentNullException();
            }

            Interop.ConvPayloadHandle handle = (payload == null) ? new Interop.ConvPayloadHandle() : payload._payloadHandle;
            int ret = Interop.ConvService.Publish(_serviceHandle, channel._channelHandle, handle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop: Failed to publish app communication service:" + ErrorFacts.GetErrorMessage(ret));
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Stops the channel opened on the remote server application
        /// </summary>
        /// <param name="channel">Channel representing a logical session on the service</param>
        /// <param name="payload">Contains additional data for start request. Refer D2D Convergence specification for more information</param>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privilege>http://tizen.org/privilege/bluetooth</privilege>
        /// <feature>http://tizen.org/feature/convergence.d2d</feature>
        /// <exception cref="NotSupportedException">Thrown if the required feature is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the request is not supported as per Tizen D2D convergence specification </exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the arugments are null</exception>
        /// <seealso cref="Service.ServiceEventOccurred"> The result of the request is delivered through this event</seealso>
        public void Stop(Channel channel, Payload payload)
        {
            if (channel == null)
            {
                throw new ArgumentNullException();
            }

            Interop.ConvPayloadHandle handle = (payload == null) ? new Interop.ConvPayloadHandle() : payload._payloadHandle;
            int ret = Interop.ConvService.Stop(_serviceHandle, channel._channelHandle, handle);
            if (ret != (int)ConvErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop: Failed to start stop communication service:" + ErrorFacts.GetErrorMessage(ret));
                throw ErrorFactory.GetException(ret);
            }
        }
    }
}
