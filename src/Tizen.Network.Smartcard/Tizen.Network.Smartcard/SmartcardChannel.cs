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
    /// The class for Smartcard channel information. It allows applications to handle the channel information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/secureelement</privilege>
    [Obsolete("Deprecated since API13, will be removed in API15.")]
    public class SmartcardChannel : IDisposable
    {
        private int _channelHandle = -1;
        private bool disposed = false;
        private SmartcardSession _sessionObject;

        /// <summary>
        /// Whether the kind of channel is basic.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Whether the kind of channel is logical.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Whether the channel is closed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// The session that has opened the given channel.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Closes the given channel to the Secure Element.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Gets the response to the select command.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Byte array to retrieve the select response.</returns>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Transmits the APDU command (as per ISO/IEC 7816-4) to the secure element.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Byte array for the response APDU plus status words.</returns>
        /// <param name="cmd">Command APDU to be sent to the secure element.</param>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Helper function to retrieve the response APDU of the previous transmit() call.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Byte array for the response APDU plus status words.</returns>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
        /// Performs a selection of the next applet on the given channel that matches to the partial application ID (AID).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>True or false depending whether another applet with the partial application ID (AID).</returns>
        [Obsolete("Deprecated since API13, will be removed in API15.")]
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
