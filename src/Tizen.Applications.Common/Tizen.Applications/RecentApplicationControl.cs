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
using System.ComponentModel;
using System.Runtime.InteropServices;
using static Interop.ApplicationManager;

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the recent application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecentApplicationControl
    {
        private const string LogTag = "Tizen.Applications.RecentApplicationControl";
        private readonly string _pkgId;
        private static Interop.ApplicationManager.RuaHistoryUpdateCallback s_historyUpdateCallback;
        private static EventHandler<RecentApplicationUpdatedEventArgs> s_historyUpdateHandler;
        private static int s_callbackId = 0;
        private static readonly object s_eventLock = new object();

        internal RecentApplicationControl(String pkgId)
        {
            _pkgId = pkgId;
        }

        /// <summary>
        /// Deletes the application from the recent application list.
        /// </summary>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public void Delete()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            err = Interop.ApplicationManager.RuaDeleteHistoryWithPkgname(_pkgId);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to delete application from recent application list.");
            }
        }

        /// <summary>
        /// Deletes all recent applications from the recent application list.
        /// </summary>
        /// <privlevel>platform</privlevel>
        /// <since_tizen> 3 </since_tizen>
        public static void DeleteAll()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            err = Interop.ApplicationManager.RuaClearHistory();
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to clear the recent application list.");
            }
        }

        /// <summary>
        /// Occurs whenever the recent application history is updated.
        /// </summary>
        /// <privlevel>platform</privlevel>
        /// <exception cref="InvalidOperationException">Thrown when failed because of system error.</exception>
        /// <since_tizen> 13 </since_tizen>
        public static event EventHandler<RecentApplicationUpdatedEventArgs> RecentApplicationHistoryUpdated
        {
            add
            {
                lock (s_eventLock)
                {
                    if (s_historyUpdateCallback == null)
                    {
                        RegisterHistoryUpdateEvent();
                    }
                    s_historyUpdateHandler += value;
                }
            }
            remove
            {
                lock (s_eventLock)
                {
                    s_historyUpdateHandler -= value;
                    if (s_historyUpdateHandler == null && s_historyUpdateCallback != null)
                    {
                        UnRegisterHistoryUpdateEvent();
                        s_historyUpdateCallback = null;
                    }
                }
            }
        }

        private static void RegisterHistoryUpdateEvent()
        {
            s_historyUpdateCallback = (IntPtr table, int nRows, int nCols, IntPtr userData) =>
            {
                lock (s_eventLock)
                {
                    try
                    {
                        RecentApplicationUpdatedEventArgs args = new RecentApplicationUpdatedEventArgs(table, nRows, nCols);
                        s_historyUpdateHandler?.Invoke(null, args);
                    }
                    catch (Exception e)
                    {
                        Log.Error(LogTag, "Failed to get record by using RuaHistoryGetRecord. Err = " + e.Message);
                    }
                }
            };

            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            err = Interop.ApplicationManager.RuaSetUpdateCallback(s_historyUpdateCallback, IntPtr.Zero, out s_callbackId);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to register the callback function.");
            }
        }

        private static void UnRegisterHistoryUpdateEvent()
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.ErrorCode.None;
            err = Interop.ApplicationManager.RuaUnSetUpdateCallback(s_callbackId);
            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, "Failed to unregister the callback function.");
            }
        }
    }
}
