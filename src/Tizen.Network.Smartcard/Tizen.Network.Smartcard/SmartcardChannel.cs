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
using System.Collections.Generic;

namespace Tizen.Network.Smartcard
{
    /// <summary>
    /// The SmartcardChannel class represents a communication channel between the application and a Smartcard.
    /// It provides properties and methods to handle channel-specific operations,
    /// such as transmitting APDUs, retrieving responses, and checking channel states. 
    /// This class also implements the IDisposable interface, allowing for proper resource management.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/secureelement</privilege>
    public class SmartcardChannel : IDisposable
    {
        private int _channelHandle = -1;
        private bool disposed = false;
        private SmartcardSession _sessionObject;

        /// <summary>
        /// The IsBasicChannel property indicates whether the channel is a basic channel.
        /// Basic channels are used to communicate with the card's logical channel zero,
        /// which is typically used for general-purpose applications.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsBasicChannel
        {
            get
            {
                bool isBasicChannel;
                int ret = Interop.Smartcard.Channel.ChannelIsBasicChannel(_channelHandle, out isBasicChannel);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get basic channel, Error - " + (SmartcardError)ret);
                }
                return isBasicChannel;
            }
        }

        /// <summary>
        /// The IsLogicalChannel property indicates whether the channel is a logical channel.
        /// Logical channels are used to communicate with specific applications on the card,
        /// other than the default basic channel.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsLogicalChannel
        {
            get
            {
                bool isBasicChannel;
                int ret = Interop.Smartcard.Channel.ChannelIsBasicChannel(_channelHandle, out isBasicChannel);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get logical channel, Error - " + (SmartcardError)ret);
                }
                return !isBasicChannel;
            }
        }

        /// <summary>
        /// The IsClosed property indicates whether the channel is currently closed.
        /// If true, the channel is not open and cannot be used for communication with the Smartcard.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsClosed
        {
            get
            {
                bool isClosed;
                int ret = Interop.Smartcard.Channel.ChannelIsClosed(_channelHandle, out isClosed);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get closed, Error - " + (SmartcardError)ret);
                }
                return isClosed;
            }
        }

        /// <summary>
        /// The Session property returns the SmartcardSession object that opened the current channel.
        /// This allows applications to access session-specific information and methods.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SmartcardSession Session
        {
            get
            {
                int session;
                int ret = Interop.Smartcard.Channel.ChannelGetSession(_channelHandle, out session);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get session, Error - " + (SmartcardError)ret);
                }

                if (_sessionObject.GetHandle() != session)
                {
                    Log.Error(Globals.LogTag, "Does not correspond with session, Error - " + _sessionObject.GetHandle() + " " + session);
                }

                return _sessionObject;
            }
        }

        internal SmartcardChannel(SmartcardSession sessionHandle, int channelHandle)
        {
            _sessionObject = sessionHandle;
            _channelHandle = channelHandle;
        }

        /// <summary>
        /// SmartcardChannel destructor.
        /// </summary>
        ~SmartcardChannel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free managed objects.
            }
            //Free unmanaged objects
            disposed = true;
        }

        /// <summary>
        /// The Close method closes the current channel to the Secure Element.
        /// This method ensures that all resources allocated for the channel are released and that the channel is no longer available for communication.
        /// Any subsequent attempts to use the channel after calling this method will result in an error.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void Close()
        {
            int ret = Interop.Smartcard.Channel.ChannelClose(_channelHandle);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to channel close, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }
            Dispose(true);
        }

        /// <summary>
        /// The GetSelectedResponse method retrieves the response to the SELECT command sent during the opening of the channel.
        /// This response contains information about the selected application on the Smartcard, such as its AID (Application Identifier).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Byte array to retrieve the select response.</returns>
        public byte[] GetSelectedResponse()
        {
            byte[] respList;
            IntPtr strAtr;
            int len;
            int ret = Interop.Smartcard.Channel.ChannelGetSelectResponse(_channelHandle, out strAtr, out len);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get select response, Error - " + (SmartcardError)ret);
            }

            respList = new byte[len];
            for (int i = 0; i < len; i++)
            {
                respList[i] = Marshal.ReadByte(strAtr);
                strAtr += sizeof(byte);
            }
            return respList;
        }

        /// <summary>
        /// The Transmit method sends an APDU (Application Protocol Data Unit) command to the Secure Element and receives the corresponding response.
        /// This method allows applications to communicate with the Smartcard by sending commands and processing the responses.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Byte array for the response APDU plus status words.</returns>
        /// <param name="cmd">Command APDU to be sent to the secure element.</param>
        public byte[] Transmit(byte[] cmd)
        {
            byte[] atrList;
            IntPtr strAtr;
            int len;
            int ret = Interop.Smartcard.Channel.ChannelTransmit(_channelHandle, cmd, cmd.Length, out strAtr, out len);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to transmit, Error - " + (SmartcardError)ret);
            }

            atrList = new byte[len];
            for (int i = 0; i < len; i++)
            {
                atrList[i] = Marshal.ReadByte(strAtr);
                strAtr += sizeof(byte);
            }

            return atrList;
        }

        /// <summary>
        /// The GetTransmittedResponse method retrieves the response APDU from the previous Transmit method call.
        /// This method allows applications to access the response data without having to store it separately.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Byte array for the response APDU plus status words.</returns>
        public byte[] GetTransmittedResponse()
        {
            byte[] respList;
            IntPtr strAtr;
            int len;
            int ret = Interop.Smartcard.Channel.ChannelTransmitRetrieveResponse(_channelHandle, out strAtr, out len);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get trasmit retrieve response, Error - " + (SmartcardError)ret);
            }

            respList = new byte[len];
            for (int i = 0; i < len; i++)
            {
                respList[i] = Marshal.ReadByte(strAtr);
                strAtr += sizeof(byte);
            }
            return respList;
        }

        /// <summary>
        /// The SelectNext method selects the next applet on the current channel that matches the partial Application Identifier (AID).
        /// This method allows applications to switch between different applets on the Smartcard,
        /// enabling interaction with multiple applications within a single session.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>True or false depending whether another applet with the partial application ID (AID).</returns>
        public bool SelectNext()
        {
            bool selectNext;
            int ret = Interop.Smartcard.Channel.ChannelSelectNext(_channelHandle, out selectNext);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to select next, Error - " + (SmartcardError)ret);
            }
            return selectNext;
        }
    }
}
