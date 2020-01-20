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

namespace Tizen.Network.Smartcard
{
    static internal class Globals
    {
        internal const string LogTag = "Tizen.Network.Smartcard";
    }

    internal class SmartcardManagerImpl : IDisposable
    {
        private static readonly SmartcardManagerImpl _instance = new SmartcardManagerImpl();
        private bool disposed = false;

        internal static SmartcardManagerImpl Instance
        {
            get
            {
                return _instance;
            }
        }

        private SmartcardManagerImpl()
        {
            initialize();
        }

        ~SmartcardManagerImpl()
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
            int ret = Interop.Smartcard.Initialize();
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize smartcard, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }
        }

        private void deinitialize()
        {
            int ret = Interop.Smartcard.Deinitialize();
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to deinitialize smartcard, Error - " + (SmartcardError)ret);
            }
        }

        internal IEnumerable<SmartcardReader> GetReaders()
        {
            IntPtr readerPtr;
            int len = 0;
            List<SmartcardReader> readerList = new List<SmartcardReader>();

            int ret = Interop.Smartcard.GetReaders(out readerPtr, out len);
            if (ret != (int)SmartcardError.None)
            {
                Log.Error(Globals.LogTag, "Failed to remove with AP, Error - " + (SmartcardError)ret);
                SmartcardErrorFactory.ThrowSmartcardException(ret);
            }

            for (int i = 0; i < len; i++)
            {
                int readerID = Marshal.ReadInt32(readerPtr);

                SmartcardReader readerItem = new SmartcardReader(readerID);
                readerList.Add(readerItem);
                readerPtr += sizeof(int);
            }

            return readerList;
        }
    }
}
