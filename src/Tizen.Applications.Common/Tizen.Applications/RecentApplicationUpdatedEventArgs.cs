/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
    /// Arguments for the event raised when the recent application history is updated.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RecentApplicationUpdatedEventArgs : EventArgs
    {
        private readonly IEnumerable<RecentApplicationInfo> _infos;

        public RecentApplicationUpdatedEventArgs(IntPtr table, int nrows, int ncols)
        {
            _infos = BuildApplicationInfoList(table, nrows, ncols);
        }

        /// <summary>
        /// Gets the list of recently used applications and their information.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public IEnumerable<RecentApplicationInfo> Infos => _infos;

        private IEnumerable<RecentApplicationInfo> BuildApplicationInfoList(IntPtr table, int nrows, int ncols)
        {
            var infos = new List<RecentApplicationInfo>(nrows);

            for (int row = 0; row < nrows; row++)
            {
                var record = GetRecordSafe(table, nrows, ncols, row);
                infos.Add(new RecentApplicationInfo(record));
            }

            return infos;
        }

        private Interop.ApplicationManager.RuaRec GetRecordSafe(IntPtr table, int nrows, int ncols, int row)
        {
            Interop.ApplicationManager.ErrorCode err = Interop.ApplicationManager.RuaHistoryGetRecord(
                out Interop.ApplicationManager.RuaRec record, table, nrows, ncols, row);

            if (err != Interop.ApplicationManager.ErrorCode.None)
            {
                throw ApplicationManagerErrorFactory.GetException(err, $"Failed to get record at row {row}.");
            }

            return record;
        }
    }
}
