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
using System.Threading.Tasks;

namespace Tizen.Network.Nfc
{
    /// <summary>
    /// The class for managing the Tag information.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class NfcTag : IDisposable
    {
        private bool disposed = false;
        private IntPtr _tagHandle = IntPtr.Zero;
        int _requestId = 0;

        Dictionary<int, TaskCompletionSource<byte[]>> _transceiveTaskSource = new Dictionary<int, TaskCompletionSource<byte[]>>();
        Interop.Nfc.TagTransceiveCompletedCallback _nativeTransceiveCallback;

        Dictionary<int, TaskCompletionSource<NfcError>> _voidTaskSource = new Dictionary<int, TaskCompletionSource<NfcError>>();
        Interop.Nfc.VoidCallback _nativeVoidCallback;

        Dictionary<int, TaskCompletionSource<NfcNdefMessage>> _readNdefTaskSource = new Dictionary<int, TaskCompletionSource<NfcNdefMessage>>();
        Interop.Nfc.TagReadCompletedCallback _nativeTagReadCallback;

        /// <summary>
        /// Constructor of NfcTag
        /// </summary>
        public NfcTag()
        {
            // A method is need to convert delegate to pass unmanaged layer through Interop call
            // If we do not convert explicitly it, implicitly convert was occurred
            // and temporal delegate was created. and it could be released by GC
            _nativeTransceiveCallback = TransceiveCompletedCallback;
            _nativeVoidCallback = VoidCallback;
            _nativeTagReadCallback = ReadNdefCallback;
        }

        /// <summary>
        /// The type of the NFC tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public NfcTagType Type
        {
            get
            {
                int type;
                int ret = Interop.Nfc.Tag.GetType(_tagHandle, out type);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get tag type, Error - " + (NfcError)ret);
                }
                return (NfcTagType)type;
            }
        }

        /// <summary>
        /// Whether the given NFC tag supports the NDEF messages.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool IsSupportNdef
        {
            get
            {
                bool isSupport;
                int ret = Interop.Nfc.Tag.IsSupportNdef(_tagHandle, out isSupport);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get support state, Error - " + (NfcError)ret);
                }
                return isSupport;

            }
        }

        /// <summary>
        /// The maximum NDEF message size that can be stored in the NFC tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint MaximumNdefSize
        {
            get
            {
                uint maxSize;
                int ret = Interop.Nfc.Tag.GetMaximumNdefSize(_tagHandle, out maxSize);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get max ndef size, Error - " + (NfcError)ret);
                }
                return maxSize;
            }
        }

        /// <summary>
        /// The size of the NDEF message stored in the tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public uint NdefSize
        {
            get
            {
                uint ndefSize;
                int ret = Interop.Nfc.Tag.GetNdefSize(_tagHandle, out ndefSize);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get ndef size, Error - " + (NfcError)ret);
                }
                return ndefSize;
            }
        }

        internal NfcTag(IntPtr handle)
        {
            _tagHandle = handle;
            _nativeTransceiveCallback = TransceiveCompletedCallback;
            _nativeVoidCallback = VoidCallback;
            _nativeTagReadCallback = ReadNdefCallback;
        }

        /// <summary>
        /// NfcTag destructor.
        /// </summary>
        ~NfcTag()
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
        /// Retrieves all the tag information.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The list of the NfcTagInformation objects.</returns>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public IEnumerable<NfcTagInformation> ForeachInformation()
        {
            List<NfcTagInformation> infoList = new List<NfcTagInformation>();
            Interop.Nfc.TagInformationCallback callback = (IntPtr key, IntPtr infoValue, int valueSize, IntPtr userData) =>
            {
                if (key != IntPtr.Zero && infoValue != IntPtr.Zero)
                {
                    NfcTagInformation tagInfo = new NfcTagInformation(Marshal.PtrToStringAnsi(key), new byte[valueSize]);

                    Marshal.Copy(infoValue, tagInfo.InformationValue, 0, valueSize);

                    infoList.Add(tagInfo);

                    return true;
                }
                return false;
            };

            int ret = Interop.Nfc.Tag.ForeachInformation(_tagHandle, callback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to get all Tag information, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return infoList;
        }

        /// <summary>
        /// Transceives the data of the raw format card.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="buffer">The binary data for a parameter or additional commands.</param>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the the method fails due to an invalid operation.</exception>
        public Task<byte[]> TransceiveAsync(byte[] buffer)
        {
            int requestId = 0;
            var task = new TaskCompletionSource<byte[]>();
            lock (this)
            {
                requestId = _requestId++;
                _transceiveTaskSource[requestId] = task;
            }

            int ret = Interop.Nfc.Tag.Transceive(_tagHandle, buffer, buffer.Length, _nativeTransceiveCallback, (IntPtr)requestId);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to transceive data, Error - " + (NfcError)ret);
                _transceiveTaskSource.Remove(requestId);
                NfcErrorFactory.ThrowNfcException(ret);
            }
            return task.Task;
        }

        /// <summary>
        /// Reads the NDEF formatted data from the NFC tag.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public Task<NfcNdefMessage> ReadNdefMessageAsync()
        {
            int requestId = 0;
            var task = new TaskCompletionSource<NfcNdefMessage>();

            lock (this)
            {
                requestId = _requestId++;
                _readNdefTaskSource[requestId] = task;
            }

            int ret = Interop.Nfc.Tag.ReadNdef(_tagHandle, _nativeTagReadCallback, (IntPtr)requestId);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to read ndef message, Error - " + (NfcError)ret);
                _readNdefTaskSource.Remove(requestId);
                NfcErrorFactory.ThrowNfcException(ret);
            }
            return task.Task;
        }

        /// <summary>
        /// Writes the NDEF formatted data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="ndefMessage">The NfcNdefMessage object.</param>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when the method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public Task<NfcError> WriteNdefMessageAsync(NfcNdefMessage ndefMessage)
        {
            int requestId = 0;
            var task = new TaskCompletionSource<NfcError>();

            lock (this)
            {
                requestId = _requestId++;
                _voidTaskSource[requestId] = task;
            }

            int ret = Interop.Nfc.Tag.WriteNdef(_tagHandle, ndefMessage.GetHandle(), _nativeVoidCallback, (IntPtr)requestId);

            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to write ndef message, Error - " + (NfcError)ret);
                _voidTaskSource.Remove(requestId);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }

        /// <summary>
        /// Formats the detected tag that can store the NDEF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="keyValue">The key value that may need to format the tag.</param>
        /// <privilege>http://tizen.org/privilege/nfc</privilege>
        /// <exception cref="NotSupportedException">Thrown when the NFC is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when method fails due to an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method fails due to an invalid operation.</exception>
        public Task<NfcError> FormatNdefMessageAsync(byte[] keyValue)
        {
            int requestId = 0;
            var task = new TaskCompletionSource<NfcError>();

            lock (this)
            {
                requestId = _requestId++;
                _voidTaskSource[requestId] = task;
            }

            int ret = Interop.Nfc.Tag.FormatNdef(_tagHandle, keyValue, keyValue.Length, _nativeVoidCallback, (IntPtr)requestId);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to format ndef message, Error - " + (NfcError)ret);
                _voidTaskSource.Remove(requestId);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }

        void TransceiveCompletedCallback(int result, IntPtr resultData, int dataSize, IntPtr userData)
        {
            int requestId = (int)userData;
            if (_transceiveTaskSource.ContainsKey(requestId))
            {
                if (result == (int)NfcError.None)
                {
                    byte[] resultBuffer = new byte[dataSize];
                    Marshal.Copy(resultData, resultBuffer, 0, dataSize);
                    _transceiveTaskSource[requestId].TrySetResult(resultBuffer);
                }
                _transceiveTaskSource.Remove(requestId);
            }
            return;
        }

        void VoidCallback(int result, IntPtr userData)
        {
            int requestId = (int)userData;
            if (_voidTaskSource.ContainsKey(requestId))
            {
                _voidTaskSource[requestId].TrySetResult((NfcError)result);
                _voidTaskSource.Remove(requestId);
            }
        }

        bool ReadNdefCallback(int result, IntPtr ndefMessage, IntPtr userData)
        {
            bool ret = false;
            int requestId = (int)userData;
            if (_readNdefTaskSource.ContainsKey(requestId))
            {
                if (result == (int)NfcError.None)
                {
                    var ndefMsg = new NfcNdefMessage(ndefMessage);
                    _readNdefTaskSource[requestId].TrySetResult(ndefMsg);
                    ret = true;
                }
                _readNdefTaskSource.Remove(requestId);
            }
            return ret;
        }
    }
}
