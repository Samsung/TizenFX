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

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// A class for the NDEF Record information. It allows applications to use the NDEF Record information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NfcNdefRecord : IDisposable
    {
        private bool disposed = false;
        private IntPtr _recordHandle = IntPtr.Zero;

        /// <summary>
        /// The record ID.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Id
        {
            get
            {
                IntPtr id;
                int idLength;
                int ret = Interop.Nfc.NdefRecord.GetId(_recordHandle, out id, out idLength);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get id, Error - " + (NfcError)ret);
                    return null;
                }

                return NfcConvertUtil.IntLengthIntPtrToByteArray(id, idLength);
            }
        }

        /// <summary>
        /// The record payload.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Payload
        {
            get
            {
                IntPtr payload;
                uint payloadLength;
                int ret = Interop.Nfc.NdefRecord.GetPayload(_recordHandle, out payload, out payloadLength);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get payload, Error - " + (NfcError)ret);
                    return null;
                }

                return NfcConvertUtil.UintLengthIntPtrToByteArray(payload, payloadLength);
            }
        }

        /// <summary>
        /// The record type.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public byte[] Type
        {
            get
            {
                IntPtr type;
                int typeSize;
                int ret = Interop.Nfc.NdefRecord.GetType(_recordHandle, out type, out typeSize);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get payload, Error - " + (NfcError)ret);
                    return null;
                }

                return NfcConvertUtil.IntLengthIntPtrToByteArray(type, typeSize);
            }
        }

        /// <summary>
        /// The record TNF (Type Name Format) value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NfcRecordTypeNameFormat Tnf
        {
            get
            {
                int tnf;
                int ret = Interop.Nfc.NdefRecord.GetTnf(_recordHandle, out tnf);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get tnf, Error - " + (NfcError)ret);
                }
                return (NfcRecordTypeNameFormat)tnf;
            }
        }

        /// <summary>
        /// The text of the text type NDEF record.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Text
        {
            get
            {
                string text;
                int ret = Interop.Nfc.NdefRecord.GetText(_recordHandle, out text);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get text, Error - " + (NfcError)ret);
                }
                return text;
            }
        }

        /// <summary>
        /// The language code of the text type NDEF record.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string LanguageCode
        {
            get
            {
                string languageCode;
                int ret = Interop.Nfc.NdefRecord.GetLanguageCode(_recordHandle, out languageCode);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get language code, Error - " + (NfcError)ret);
                }
                return languageCode;
            }
        }

        /// <summary>
        /// The encoding type of the text type NDEF record.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NfcEncodeType EncodeType
        {
            get
            {
                int encodeType;
                int ret = Interop.Nfc.NdefRecord.GetEncodeType(_recordHandle, out encodeType);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get encode type, Error - " + (NfcError)ret);
                }
                return (NfcEncodeType)encodeType;
            }
        }

        /// <summary>
        /// The URI of the URI type NDEF record.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Uri
        {
            get
            {
                string uri;
                int ret = Interop.Nfc.NdefRecord.GetUri(_recordHandle, out uri);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get uri, Error - " + (NfcError)ret);
                }
                return uri;
            }
        }

        /// <summary>
        /// The mime type of the mime type NDEF record.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string MimeType
        {
            get
            {
                string mimeType;
                int ret = Interop.Nfc.NdefRecord.GetMimeType(_recordHandle, out mimeType);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get mime type, Error - " + (NfcError)ret);
                }
                return mimeType;
            }
        }

        /// <summary>
        /// Creates a record with a given parameter value.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="format">The type name format.</param>
        /// <param name="type">The specified type name.</param>
        /// <param name="id">The record ID.</param>
        /// <param name="payload">The payload of this record.</param>
        /// <param name="paloadLength">The byte size of the payload.</param>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public NfcNdefRecord(NfcRecordTypeNameFormat format, byte[] type, byte[] id, byte[] payload, uint paloadLength)
        {
            int ret = Interop.Nfc.NdefRecord.Create(out _recordHandle, (int)format, type, type.Length, id, id.Length, payload, paloadLength);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create Ndef record, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        /// <summary>
        /// Creates a record with the text type payload.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="text">The encoded text.</param>
        /// <param name="languageCode">The language code string value followed by the IANA [RFC 3066] \(ex: en-US, ko-KR).</param>
        /// <param name="encode">The encoding type.</param>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public NfcNdefRecord(string text, string languageCode, NfcEncodeType encode)
        {
            int ret = Interop.Nfc.NdefRecord.CreateText(out _recordHandle, text, languageCode, (int)encode);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create ndef Text record, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        /// <summary>
        /// Creates a record with the URI type payload.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="uri">The URI string that will be stored in the payload.</param>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public NfcNdefRecord(string uri)
        {
            int ret = Interop.Nfc.NdefRecord.CreateUri(out _recordHandle, uri);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create ndef Uri record, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        /// <summary>
        /// Creates a record with the mime type payload.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="mimeType">The mime type [RFC 2046] \(ex. text/plain, image/jpeg ). This value is stored in the type field.</param>
        /// <param name="data">The data in the form of the bytes array.</param>
        /// <param name="dataSize">The size of the data.</param>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public NfcNdefRecord(string mimeType, byte[] data, uint dataSize)
        {
            int ret = Interop.Nfc.NdefRecord.CreateMime(out _recordHandle, mimeType, data, dataSize);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to create ndef Mime record, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        internal NfcNdefRecord(IntPtr recordHandle)
        {
            _recordHandle = recordHandle;
        }

        /// <summary>
        /// NfcNdefRecord destructor.
        /// </summary>
        ~NfcNdefRecord()
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
                int ret = Interop.Nfc.NdefRecord.Destroy(_recordHandle);

                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to destroy ndef record, Error - " + (NfcError)ret);
                }
            }
            //Free unmanaged objects
            disposed = true;
        }

        internal IntPtr GetHandle()
        {
            return _recordHandle;
        }
    }
}
