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
using System.Collections;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// A class for the NDEF Message information. It allows applications to use the NDEF Message information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NfcNdefMessage : IDisposable
    {
        private bool disposed = false;
        private IntPtr _messageHandle = IntPtr.Zero;
        private ArrayList _recordList = new ArrayList();

        /// <summary>
        /// The number of records in the NDEF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
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
        /// Creates an object for the access point.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public NfcNdefMessage()
        {
            int ret = Interop.Nfc.NdefMessage.Create(out _messageHandle);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create Ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        internal NfcNdefMessage(IntPtr messageHandle)
        {
            if (messageHandle == IntPtr.Zero)
            {
                return;
            }

            _messageHandle = messageHandle;

            int recordCount;
            int ret = Interop.Nfc.NdefMessage.GetRecordCount(_messageHandle, out recordCount);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to GetRecordCount, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            for (int i = 0; i < recordCount; i++) {
                IntPtr recordHandle;
                ret = Interop.Nfc.NdefMessage.GetRecord(_messageHandle, i, out recordHandle);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get record, Error - " + (NfcError)ret);
                    NfcErrorFactory.ThrowNfcException(ret);
                }

                NfcNdefRecord record = new NfcNdefRecord(recordHandle);
                
                _recordList.Add(record);
                Log.Debug(Globals.LogTag, "Record Added");
            }
        }

        /// <summary>
        /// NfcNdefMessage destructor.
        /// </summary>
        ~NfcNdefMessage()
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
                int ret = Interop.Nfc.NdefMessage.Destroy(_messageHandle);

                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to destroy ndef message, Error - " + (NfcError)ret);
                }
            }
            //Free unmanaged objects
            disposed = true;
        }

        /// <summary>
        /// Appends a record into the NDEF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Whether the record is appended successfully.</returns>
        /// <param name="record">The NfcNdefRecord object that will be appended into the NDEF message.</param>
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
        /// Inserts a record at the index into the NDEF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Whether inserting the record succeeded.</returns>
        /// <param name="index">The index of a record ( starts from 0 ).</param>
        /// <param name="record">The NfcNdefRecord object that will be appended into the NDEF message.</param>
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
                _recordList.Insert(index, record);
            }

            return isSuccess;
        }

        /// <summary>
        /// Removes a record at the index into the NDEF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Whether removing the record succeeded.</returns>
        /// <param name="index">The index of a record ( starts from 0 ).</param>
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
        /// Gets a record by the index.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The NfcNdefRecord object.</returns>
        /// <param name="index">The index of a record ( starts from 0 ).</param>
        public NfcNdefRecord GetRecord(int index)
        {
            return (NfcNdefRecord)_recordList[index];
        }

        internal IntPtr GetHandle()
        {
            return _messageHandle;
        }
    }
}
