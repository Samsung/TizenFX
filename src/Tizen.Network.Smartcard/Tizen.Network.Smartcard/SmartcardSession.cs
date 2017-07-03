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
    /// A class for Smartcard session informations. It allows applications to handle session informations.
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
        /// The reader object that provides the given session.
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
        /// The Answer to Reset(ATR) of this Secure Element.
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
        /// Whether the session is closed.
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

        ~SmartcardSession()
        {
            Dispose(false);
        }

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
        /// Closes the connection with the Secure Element.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Closes any channel opened on the given session.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// <returns>The SmartcardChannel object for basic channel.</returns>
        /// <param name="aid">Byte array containing the Application ID(AID) to be selected on the given channel.</param>
        /// <param name="p2">P2 byte of the SELECT command if executed.</param>
        public SmartcardChannel OpenBasicChannel(byte[] aid, byte p2)
        {
            int ret = Interop.Smartcard.Session.SessionOpenBasicChannel(_sessionHandle, aid, aid.Length, p2, out _basicChannel);
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
        /// Open a logical channel with the Secure Element, selecting the Applet represented by the given Application ID(AID).
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The SmartcardChannel object for logical channel.</returns>
        /// <param name="aid">Byte array containing the Application ID(AID) to be selected on the given channel.</param>
        /// <param name="p2">P2 byte of the SELECT command if executed.</param>
        public SmartcardChannel OpenLogicalChannel(byte[] aid, byte p2)
        {
            int ret = Interop.Smartcard.Session.SessionOpenLogicalChannel(_sessionHandle, aid, aid.Length, p2, out _logicalChannel);
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
