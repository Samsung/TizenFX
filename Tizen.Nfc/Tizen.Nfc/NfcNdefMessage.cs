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
using Tizen.Network;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// A class for Ndef Message information. It allows applications to use Ndef Message information.
    /// </summary>
    public class NfcNdefMessage : IDisposable
    {
        private bool disposed = false;
        private IntPtr _messageHandle = IntPtr.Zero;
        private List<NfcNdefRecord> _recordList = new List<NfcNdefRecord>();

        /// <summary>
        /// The number of record in NDEF message.
        /// </summary>
        public int RecordCount
        {
            get
            {
                int recordCount;
                int ret = Interop.Nfc.NdefMessage.GetRecordCount(_messageHandle, out recordCount);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get record count, Error - " + (NfcError)ret);
                }
                return recordCount;
            }
        }

        /// <summary>
        /// The serial bytes array of NDEF message.
        /// </summary>
        public byte[] Rawdata
        {
            get
            {
                IntPtr rawData;
                uint rawDataSize;
                int ret = Interop.Nfc.NdefMessage.GetRawData(_messageHandle, out rawData, out rawDataSize);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get rawdata, Error - " + (NfcError)ret);
                    return null;
                }

                return NfcConvertUtil.UintLengthIntPtrToByteArray(rawData, rawDataSize);
            }
        }

        /// <summary>
        /// Creates a object for the access point.
        /// </summary>
        public NfcNdefMessage()
        {
            int ret = Interop.Nfc.NdefMessage.Create(out _messageHandle);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create Ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        /// <summary>
        /// Creates NDEF message handle from raw serial bytes.
        /// </summary>
        /// <param name="rawData">The NDEF message in form of bytes array.</param>
        /// <param name="rawData">The size of bytes array.</param>
        public NfcNdefMessage(byte[] rawData, uint rawDataSize)
        {
            int ret = Interop.Nfc.NdefMessage.CreateRawData(out _messageHandle, rawData, rawDataSize);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create Ndef Rawdata message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        internal NfcNdefMessage(IntPtr messageHandle)
        {
            _messageHandle = messageHandle;
        }

        ~NfcNdefMessage()
        {
            int ret = Interop.Nfc.NdefMessage.Destroy(_messageHandle);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to destroy ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

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
            }
            //Free unmanaged objects
            disposed = true;
        }

        /// <summary>
        /// Appends a record into NDEF message.
        /// </summary>
        /// <returns>Whether appending the record succeeded.</returns>
        /// <param name="record">The NfcNdefRecord object that will be appended into NDEF message.</param>
        public bool AppendRecord(NfcNdefRecord record)
        {
            bool isSuccess = true;

            int ret = Interop.Nfc.NdefMessage.AppendRecord(_messageHandle, record.GetHandle());
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to append record, Error - " + (NfcError)ret);
                isSuccess = false;
            }
            else
            {
                _recordList.Add(record);
            }

            return isSuccess;
        }

        /// <summary>
        /// Inserts a record at index into NDEF message.
        /// </summary>
        /// <returns>Whether insterting the record succeeded.</returns>
        /// <param name="index">The index of record ( starts from 0 ).</param>
        /// <param name="record">The NfcNdefRecord object that will be appended into NDEF message.</param>
        public bool InsertRecord(int index, NfcNdefRecord record)
        {
            bool isSuccess = true;

            int ret = Interop.Nfc.NdefMessage.InsertRecord(_messageHandle, index, record.GetHandle());
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to insert record, Error - " + (NfcError)ret);
                isSuccess = false;
            }
            else
            {
                _recordList.Add(record);
            }

            return isSuccess;
        }

        /// <summary>
        /// Inserts a record at index into NDEF message.
        /// </summary>
        /// <returns>Whether removing the record succeeded.</returns>
        /// <param name="index">The index of record ( starts from 0 ).</param>
        public bool RemoveRecord(int index)
        {
            bool isSuccess = true;

            int ret = Interop.Nfc.NdefMessage.RemoveRecord(_messageHandle, index);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove record, Error - " + (NfcError)ret);
                isSuccess = false;
            }

            return isSuccess;
        }

        /// <summary>
        /// Gets record by index.
        /// </summary>
        /// <returns>The NfcNdefRecord object.</returns>
        /// <param name="index">The index of record ( starts from 0 ).</param>
        public NfcNdefRecord GetRecord(int index)
        {
            IntPtr recordHandle;
            NfcNdefRecord recordObject = null;

            int ret = Interop.Nfc.NdefMessage.GetRecord(_messageHandle, index, out recordHandle);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove record, Error - " + (NfcError)ret);
            }

            foreach (NfcNdefRecord recordElement in _recordList)
            {
                if(recordElement.GetHandle() == recordHandle)
                {
                    Log.Debug(Globals.LogTag, "Find record handle");
                    recordObject = recordElement;
                    break;
                }
            }

            return recordObject;
        }

        internal IntPtr GetHandle()
        {
            return _messageHandle;
        }
    }
}
