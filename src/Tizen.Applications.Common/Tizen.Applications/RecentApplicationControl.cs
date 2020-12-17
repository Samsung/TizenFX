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

namespace Tizen.Applications
{
    /// <summary>
    /// This class provides methods and properties to get information of the recent application.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecentApplicationControl
    {
        private const string LogTag = "Tizen.Applications";

        private readonly string _pkgId;

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
    }
}
