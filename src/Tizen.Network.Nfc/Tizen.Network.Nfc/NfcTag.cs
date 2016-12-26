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
    /// A class for managing the Tag information.
    /// </summary>
    public class NfcTag : IDisposable
    {
        private bool disposed = false;
        private IntPtr _tagHandle = IntPtr.Zero;

        /// <summary>
        /// The type of NFC tag.
        /// </summary>
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
        /// Whether the given NFC tag supports NDEF messages.
        /// </summary>
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
        /// The maximum NDEF message size that can be stored in NFC tag.
        /// </summary>
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
        /// The size of NDEF message that stored in the tag.
        /// </summary>
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
        }

        ~NfcTag()
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
            }
            //Free unmanaged objects
            disposed = true;
        }

        /// <summary>
        /// Retrieves all tag information.
        /// </summary>
        /// <returns>List of NfcTagInformation objects.</returns>
        public IEnumerable<NfcTagInformation> ForeachInformation()
        {
            List<NfcTagInformation> infoList = new List<NfcTagInformation>();
            Interop.Nfc.TagInformationCallback callback = (IntPtr key, IntPtr infoValue, int valueSize, IntPtr userData) =>
            {
                if (key != IntPtr.Zero && infoValue != IntPtr.Zero)
                {
                    NfcTagInformation tagInfo = new NfcTagInformation();

                    tagInfo.Key = Marshal.PtrToStringAnsi(key);
                    tagInfo.InformationValue = new byte[valueSize];
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
        /// <param name="buffer">The binary data for parameter or additional commands.</param>
        public Task<byte[]> TransceiveAsync(byte[] buffer)
        {
            var task = new TaskCompletionSource<byte[]>();
            
            byte[] resultBuffer = null;
            Interop.Nfc.TagTransceiveCompletedCallback callback = (int result, IntPtr resultData, int dataSize, IntPtr userData) =>
            {
                if (result == (int)NfcError.None)
                {
                    resultBuffer = new byte[dataSize];
                    Marshal.Copy(resultData, resultBuffer, 0, dataSize);
                    task.SetResult(resultBuffer);
                }
                return;
            };

            int ret = Interop.Nfc.Tag.Transceive(_tagHandle, buffer, buffer.Length, callback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to transceive data, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }

        /// <summary>
        /// Reads NDEF formatted data from NFC tag.
        /// </summary>
        public Task<NfcNdefMessage> ReadNdefMessageAsync()
        {
            var task = new TaskCompletionSource<NfcNdefMessage>();

            NfcNdefMessage ndefMsg = null;
            Interop.Nfc.TagReadCompletedCallback callback = (int result, IntPtr ndefMessage, IntPtr userData) =>
            {
                if (result == (int)NfcError.None)
                {
                    ndefMsg = new NfcNdefMessage(ndefMessage);
                    task.SetResult(ndefMsg);

                    return true;
                }
                return false;
            };

            int ret = Interop.Nfc.Tag.ReadNdef(_tagHandle, callback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to read ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }

        /// <summary>
        /// Writes NDEF formatted data.
        /// </summary>
        /// <param name="ndefMessage">The NfcNdefMessage object.</param>
        public Task<NfcError> WriteNdefMessageAsync(NfcNdefMessage ndefMessage)
        {
            var task = new TaskCompletionSource<NfcError>();

            Interop.Nfc.VoidCallback callback = (int result, IntPtr userData) =>
            {
                task.SetResult((NfcError)result);
                return;
            };

            int ret = Interop.Nfc.Tag.WriteNdef(_tagHandle, ndefMessage.GetHandle(), callback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to write ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }

        /// <summary>
        /// Formats the detected tag that can store NDEF message.
        /// </summary>
        /// <param name="keyValue">The key value that may need to format the tag.</param>
        public Task<NfcError> FormatNdefMessageAsync(byte[] keyValue)
        {
            var task = new TaskCompletionSource<NfcError>();

            Interop.Nfc.VoidCallback callback = (int result, IntPtr userData) =>
            {
                task.SetResult((NfcError)result);
                return;
            };

            int ret = Interop.Nfc.Tag.FormatNdef(_tagHandle, keyValue, keyValue.Length, callback, IntPtr.Zero);
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to format ndef message, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }

            return task.Task;
        }
    }
}
