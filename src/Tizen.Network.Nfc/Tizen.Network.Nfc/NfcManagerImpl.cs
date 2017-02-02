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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Network.Nfc
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Nfc";
    }

    internal static class NfcConvertUtil
    {
        internal static byte[] IntLengthIntPtrToByteArray(IntPtr nativeValue, int length)
        {
            byte[] value = new byte[length];
            if (nativeValue != IntPtr.Zero)
            {
                Marshal.Copy(nativeValue, value, 0, length);
            }
            return value;
        }

        internal static byte[] UintLengthIntPtrToByteArray(IntPtr nativeValue, uint length)
        {
            byte[] value = new byte[length];

            if (nativeValue != IntPtr.Zero)
            {
                for (int i = 0; i < length; i++)
                {
                    value[i] = Marshal.ReadByte(nativeValue);
                    nativeValue += sizeof(byte);
                }
            }
            return value;
        }
    }

    internal partial class NfcManagerImpl : IDisposable
    {
        private static readonly NfcManagerImpl _instance = new NfcManagerImpl();
        private static readonly NfcTagAdapter _instanceTagAdapter = new NfcTagAdapter();
        private static readonly NfcP2pAdapter _instanceP2pAdapter = new NfcP2pAdapter();
        private static readonly NfcCardEmulationAdapter _instanceCardEmulationAdapter = new NfcCardEmulationAdapter();

        private Dictionary<IntPtr, Interop.Nfc.VoidCallback> _callback_map = new Dictionary<IntPtr, Interop.Nfc.VoidCallback>();
        private int _requestId = 0;
        private bool disposed = false;

        internal static NfcManagerImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        internal NfcTagAdapter TagAdapter
        {
            get
            {
                return _instanceTagAdapter;
            }
        }

        internal NfcP2pAdapter P2pAdapter
        {
            get
            {
                return _instanceP2pAdapter;
            }
        }

        internal NfcCardEmulationAdapter CardEmulationAdapter
        {
            get
            {
                return _instanceCardEmulationAdapter;
            }
        }

        internal bool IsSupported
        {
            get
            {
                bool support = Interop.Nfc.IsSupported();

                return support;
            }
        }

        internal bool IsActivated
        {
            get
            {
                bool active = Interop.Nfc.IsActivated();

                return active;
            }
        }

        internal NfcNdefMessage CachedNdefMessage
        {
            get
            {
                IntPtr ndef = IntPtr.Zero; ;
                int ret = Interop.Nfc.GetCachedMessage(out ndef);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get cached ndef message, Error - " + (NfcError)ret);
                }

                NfcNdefMessage ndefMessage = new NfcNdefMessage(ndef);
                return ndefMessage;
            }
        }

        internal NfcTagFilterType TagFilterType
        {
            get
            {
                int type = Interop.Nfc.GetTagFilter();

                return (NfcTagFilterType)type;
            }
            set
            {
                Interop.Nfc.SetTagFilter((int)value);
            }
        }

        internal NfcSecureElementType SecureElementType
        {
            get
            {
                int type;
                int ret = Interop.Nfc.GetSecureElementType(out type);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to get secure element type, Error - " + (NfcError)ret);
                }
                return (NfcSecureElementType)type;
            }
            set
            {
                int ret = Interop.Nfc.SetSecureElementType((int)value);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to set secure element type, Error - " + (NfcError)ret);
                }
            }
        }

        internal bool SystemHandlerEnabled
        {
            get
            {
                bool systemhandler = Interop.Nfc.IsSystemHandlerEnabled();

                return systemhandler;
            }
            set
            {
                int ret = Interop.Nfc.SetSystemHandlerEnable(value);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to enable system handler, Error - " + (NfcError)ret);
                }
            }
        }

        private NfcManagerImpl()
        {
            initialize();
        }

        ~NfcManagerImpl()
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
            deinitialize();
            disposed = true;
        }

        private void initialize()
        {
            int ret = Interop.Nfc.Initialize();
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize Nfc, Error - " + (NfcError)ret);
                NfcErrorFactory.ThrowNfcException(ret);
            }
        }

        private void deinitialize()
        {
            int ret = Interop.Nfc.Deinitialize();
            if (ret != (int)NfcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize Nfc, Error - " + (NfcError)ret);
            }
        }

        internal Task SetActivationAsync(bool activation)
        {
            TaskCompletionSource<bool> task = new TaskCompletionSource<bool>();
            IntPtr id = IntPtr.Zero;
            lock (_callback_map)
            {
                id = (IntPtr)_requestId++;
                _callback_map[id] = (error, key) =>
                {
                    Log.Debug(Globals.LogTag, "nfc activated");
                    if (error != (int)NfcError.None)
                    {
                        Log.Error(Globals.LogTag, "Error occurs during Nfc activating, " + (NfcError)error);
                        task.SetException(new InvalidOperationException("Error occurs during Nfc activating, " + (NfcError)error));
                    }
                    task.SetResult(true);
                    lock (_callback_map)
                    {
                        _callback_map.Remove(key);
                    }
                };

                int ret = Interop.Nfc.SetActivation(activation, _callback_map[id], id);
                if (ret != (int)NfcError.None)
                {
                    Log.Error(Globals.LogTag, "Failed to activate nfc, Error - " + (NfcError)ret);
                    NfcErrorFactory.ThrowNfcException(ret);
                }
            }
            return task.Task;
        }
    }
}
