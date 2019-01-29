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
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Network.Stc
{
    internal static class Globals
    {
        internal const string LogTag = "Tizen.Network.Stc";
    }

    internal class StcHandleHolder
    {
        private SafeStcHandle _handle;

        internal StcHandleHolder()
        {
            _handle = StcManagerImpl.Instance.Initialize();
            Log.Debug(Globals.LogTag, "Handle: " + _handle);
        }

        internal SafeStcHandle GetSafeHandle()
        {
            Log.Debug(Globals.LogTag, "StcHandleholder safehandle = " + _handle);
            return _handle;
        }
    }

    /// <summary>
    /// The implementation of Stc APIs.
    /// </summary>
    internal class StcManagerImpl
    {
        private static StcManagerImpl _instance = null;

        private StcManagerImpl()
        {
        }

        internal static StcManagerImpl Instance
        {
            get
            {
                if (_instance == null)
                {
                    Log.Debug(Globals.LogTag, "Instance is null");
                    _instance = new StcManagerImpl();
                }

                return _instance;
            }
        }

        private static ThreadLocal<StcHandleHolder> s_threadName = new ThreadLocal<StcHandleHolder>(() =>
        {
            Log.Info(Globals.LogTag, "In threadlocal delegate");
            return new StcHandleHolder();
        });

        internal SafeStcHandle GetSafeHandle()
        {
            return s_threadName.Value.GetSafeHandle();
        }

        internal SafeStcHandle Initialize()
        {
            SafeStcHandle handle;
            int ret = Interop.Stc.Initialize(out handle);
            if (ret != (int)StcError.None)
            {
                Log.Error(Globals.LogTag, "Failed to initialize Stc, Error - " + (StcError)ret);
                StcErrorFactory.ThrowStcException(ret);
            }
            return handle;
        }
    }
}
