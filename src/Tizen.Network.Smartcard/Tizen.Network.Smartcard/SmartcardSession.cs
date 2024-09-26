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
    /// The SmartcardSession class provides information about the Smartcard session established with the Secure Element. 
    /// Applications can use this class to manage the session, perform various operations, and interact with the Secure Element.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    /// <privilege>http://tizen.org/privilege/secureelement</privilege>
    public class SmartcardSession : IDisposable
    {
        private int _sessionHandle = -1;
        private bool disposed = false;
        private List<SmartcardChannel> _basicChannelList = new List<SmartcardChannel>();
        private List<SmartcardChannel> _logicalChannelList = new List<SmartcardChannel>();
        private SmartcardReader _readerObject;
        private int _basicChannel = 0;
        private int _logicalChannel = 0;

        /// <summary>
        /// The Reader property represents the SmartcardReader object associated with the current Smartcard session.
        /// This property allows applications to access information about the reader that is providing the session,
        /// such as its name and state. It can be useful for displaying relevant information to the user or for logging purposes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SmartcardReader Reader
        {
            get
            {
                int reader;
                int ret = Interop.Smartcard.Session.SessionGetReader(_sessionHandle, out reader);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get reader, Error - " + (SmartcardError)ret);
                }

                if (_readerObject.GetHandle() != reader)
                {
                    Log.Error(Globals.LogTag, "Does not correspond with reader, Error - " + _readerObject.GetHandle() + " " + reader);
                }

                return _readerObject;
            }
        }

        /// <summary>
        /// The Atr property represents the Answer to Reset (ATR) of the Secure Element associated with the current Smartcard session.
        /// The ATR is a sequence of bytes sent by the Secure Element during the initial communication phase,
        /// providing information about the card's characteristics and capabilities.
        /// Applications can use this property to retrieve the ATR and analyze the card's properties.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Atr
        {
            get
            {
                byte[] atrList;
                IntPtr strAtr;
                int len;
                int ret = Interop.Smartcard.Session.SessionGetAtr(_sessionHandle, out strAtr, out len);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get atr, Error - " + (SmartcardError)ret);
                }

                atrList = new byte[len];
                for (int i = 0; i < len; i++)
                {
                    atrList[i] = Marshal.ReadByte(strAtr);
                    strAtr += sizeof(byte);
                }
                return atrList;
            }
        }

        /// <summary>
        /// The IsClosed property indicates whether the current Smartcard session is closed.
        /// This property allows applications to check the status of the session and determine if it is still active or has been terminated.
        /// Knowing the session's status is important for managing resources and ensuring proper communication with the Secure Element.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsClosed
        {
            get
            {
                bool isClosed;
                int ret = Interop.Smartcard.Session.SessionIsClosed(_sessionHandle, out isClosed);
                if (ret != (int)SmartcardError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get present, Error - " + (SmartcardError)ret);
                }
                return isClosed;
            }
        }

        internal SmartcardSession(SmartcardReader readerHandle, int sessionHandle)
        {
            _readerObject = readerHandle;
            _sessionHandle = sessionHandle;
        }

        /// <summary>
        /// SmartcardSession destructor.
        /// </summary>
        ~SmartcardSession()
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
                foreach (SmartcardChannel channel in _basicChannelList)
                {
                    channel.Dispose();
                    _basicChannelList.Remove(channel);
                }

                foreach (SmartcardChannel channel in _logicalChannelList)
                {
                    channel.Dispose();
                    _logicalChannelList.Remove(channel);
                }
            }
            //Free unmanaged objects
            disposed = true;
        }

        internal int GetHandle()
        {
            return _sessionHandle;
        }

        /// <summary>
        /// The Close method terminates the connection with the Secure Element associated with the current Smartcard session.
        /// This method ensures that any resources allocated for the session are released and the session is properly closed.
        /// By calling this method, applications can free up resources and ensure that no further operations are performed on the session.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        public void Close()
        {
            int ret = Interop.Smartcard.Session.SessionClose(_sessionHandle);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to close, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }
            Dispose(true);
        }

        /// <summary>
        /// The CloseChannels method closes all channels that have been opened within the current Smartcard session.
        /// This method ensures that any active channels with the Secure Element are properly terminated.
        /// By calling this method, applications can release resources and prevent potential conflicts or errors when interacting with the Smartcard.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public void CloseChannels()
        {
            int ret = Interop.Smartcard.Session.SessionCloseChannels(_sessionHandle);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to close, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }

            foreach (SmartcardChannel channel in _basicChannelList)
            {
                channel.Close();
            }

            foreach (SmartcardChannel channel in _logicalChannelList)
            {
                channel.Close();
            }
        }

        /// <summary>
        /// Gets an access to the basic channel, as defined in the ISO/IEC 7816-4 specification (the one that has number 0).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The SmartcardChannel object for the basic channel.</returns>
        /// <param name="aid">The byte array containing the Application ID(AID) to be selected on the given channel.</param>
        /// <param name="p2">P2 byte of the SELECT command if executed.</param>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to invalid operation.</exception>
        public SmartcardChannel OpenBasicChannel(byte[] aid, byte p2)
        {
            int aidLen = (aid == null ? 0 : aid.Length);
            int ret = Interop.Smartcard.Session.SessionOpenBasicChannel(_sessionHandle, aid, aidLen, p2, out _basicChannel);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to open basic channel, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }
            SmartcardChannel basicChannel = new SmartcardChannel(this, _basicChannel);
            _basicChannelList.Add(basicChannel);

            return basicChannel;
        }

        /// <summary>
        /// Open a logical channel with the secure element, selecting the Applet represented by the given application ID (AID).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The SmartcardChannel object for the logical channel.</returns>
        /// <param name="aid">The byte array containing the Application ID(AID) to be selected on the given channel.</param>
        /// <param name="p2">P2 byte of the SELECT command if executed.</param>
        /// <exception cref="NotSupportedException">Thrown when the Smartcard is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method failed due to an invalid operation.</exception>
        public SmartcardChannel OpenLogicalChannel(byte[] aid, byte p2)
        {
            int aidLen = (aid == null ? 0 : aid.Length);
            int ret = Interop.Smartcard.Session.SessionOpenLogicalChannel(_sessionHandle, aid, aidLen, p2, out _logicalChannel);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to open logical channel, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }
            SmartcardChannel logicalChannel = new SmartcardChannel(this, _logicalChannel);
            _logicalChannelList.Add(logicalChannel);

            return logicalChannel;
        }
    }
}
