/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.


using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Libraries
    {
        public const string Dlog = "libdlog.so.0";
    }

    internal static partial class Dlog
    {
        internal enum LogPriority
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
        [DllImportAttribute(Libraries.Dlog, EntryPoint = "dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Print(LogPriority prio, string tag, string fmt, string msg);

        [DllImportAttribute(Libraries.Dlog, EntryPoint = "dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int Print(LogPriority prio, string tag, string fmt, string file, string func, int line, string msg);
    }
}

