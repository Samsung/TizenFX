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

using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        #if NOTIZEN
            public const string Dlog = "dlog";
        #else
            public const string Dlog = "libdlog.so.0";
        #endif
    }

    internal static partial class Dlog
    {
        internal enum LogID : int
        {
            LOG_ID_INVALID = -1,
            LOG_ID_MAIN,
            LOG_ID_RADIO,
            LOG_ID_SYSTEM,
            LOG_ID_APPS,
            LOG_ID_KMSG,
            LOG_ID_MAX
        }

        internal enum LogPriority : int
        {
            DLOG_UNKNOWN = 0,
            DLOG_DEFAULT,
            DLOG_VERBOSE,
            DLOG_DEBUG,
            DLOG_INFO,
            DLOG_WARN,
            DLOG_ERROR,
            DLOG_FATAL,
            DLOG_SILENT,
            DLOG_PRIO_MAX,
        }

        [DllImport(Libraries.Dlog, EntryPoint = "dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Print(LogPriority prio, string tag, string fmt, string msg);

        [DllImport(Libraries.Dlog, EntryPoint = "dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Print(LogPriority prio, string tag, string fmt, string file, string func, int line, string msg);

        [DllImport(Libraries.Dlog, EntryPoint = "__dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int InternalPrint(LogID log_id, LogPriority prio, string tag, string fmt, string msg);

        [DllImport(Libraries.Dlog, EntryPoint = "__dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int InternalPrint(LogID log_id, LogPriority prio, string tag, string fmt, string file, string func, int line, string msg);

    }
}

