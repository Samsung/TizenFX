/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
        readonly SafeStcHandle _handle;

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
        private static StcManagerImpl _instance;
        private Dictionary<IntPtr, Interop.Stc.GetAllStatsFinishedCallback> _getAllStatsCb_map = new Dictionary<IntPtr, Interop.Stc.GetAllStatsFinishedCallback>();
        private int _requestAllId = 0;

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
                throw StcErrorFactory.GetStcException(ret);
            }
            return handle;
        }

        internal Task<IEnumerable<NetworkStatistics>> GetStatisticsAsync(StatisticsFilter filter)
        {
            TaskCompletionSource<IEnumerable<NetworkStatistics>> task = new TaskCompletionSource<IEnumerable<NetworkStatistics>>();
            IntPtr id;

            lock (_getAllStatsCb_map)
            {
                id = (IntPtr)_requestAllId++;
                _getAllStatsCb_map[id] = (int result, IntPtr infoList, IntPtr key) =>
                {
                    if (result != (int)StcError.None)
                    {
                        Log.Error(Globals.LogTag, "GetAllStats failed, Error - " + (StcError)result);
                        task.SetException(StcErrorFactory.GetStcException(result));
                        lock (_getAllStatsCb_map)
                        {
                            _getAllStatsCb_map.Remove(key);
                        }
                        return;
                    }

                    List<NetworkStatistics> statsList = new List<NetworkStatistics>();

                    Interop.Stc.StatsInfoCallback foreachAllStatsCb = (int resultTemp, IntPtr info, IntPtr userDataTemp) =>
                    {
                        if (resultTemp != (int)StcError.None)
                        {
                            Log.Error(Globals.LogTag, "ForeachAllStats failed, Error - " + (StcError)resultTemp);
                            task.SetException(StcErrorFactory.GetStcException(resultTemp));
                        }

                        Interop.Stc.SafeStatsHandle cloned;
                        int retValue = Interop.Stc.Info.StatsClone(info, out cloned);
                        if (retValue != (int)StcError.None)
                        {
                            Log.Error(Globals.LogTag, "StatsClone() failed , Error - " + (StcError)retValue);
                            task.SetException(StcErrorFactory.GetStcException(retValue));
                        }

                        statsList.Add(new NetworkStatistics(cloned));
                        return CallbackRet.Continue;
                    };

                    int retTemp = Interop.Stc.ForeachAllStats(infoList, foreachAllStatsCb, IntPtr.Zero);
                    if(retTemp != (int)StcError.None)
                    {
                        Log.Error(Globals.LogTag, "foreachAllStatus() failed , Error - " + (StcError)retTemp);
                        task.SetException(StcErrorFactory.GetStcException(retTemp));
                    }
                    else
                    {
                        task.SetResult(statsList);
                    }

                    lock (_getAllStatsCb_map)
                    {
                        _getAllStatsCb_map.Remove(key);
                    }
                };

                using (var filterHandle = filter.ConvertToNativeFilter())
                {
                        int ret = Interop.Stc.GetAllStats(GetSafeHandle(), filterHandle, _getAllStatsCb_map[id], id);
                        if (ret != (int)StcError.None)
                        {
                               Log.Error(Globals.LogTag, "GetAllStatus() failed , Error - " + (StcError)ret);
                               throw StcErrorFactory.GetStcException(ret);
                        }
                }
            }
            return task.Task;
        }
    }
}
