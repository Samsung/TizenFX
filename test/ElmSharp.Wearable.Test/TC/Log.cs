using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace ElmSharp.Test
{
    internal static class Log
    {
        #if NOTIZEN
            public const string Library = "dlog";
        #else
            public const string Library = "libdlog.so.0";
        #endif
        const string TAG = "ElmSharp.Test";

        public static void Debug(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Print(LogPriority.DLOG_DEBUG, TAG, message, file, func, line);
        }

        public static void Info(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Print(LogPriority.DLOG_DEBUG, TAG, message, file, func, line);
        }

        public static void Error(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Print(LogPriority.DLOG_DEBUG, TAG, message, file, func, line);
        }

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

        private static void Print(LogPriority priority, string tag, string message, string file, string func, int line)
        {
            FileInfo finfo = new FileInfo(file);
            Print(priority, tag, "%s: %s(%d) > %s", finfo.Name, func, line, message);
        }

        [DllImportAttribute(Library, EntryPoint = "dlog_print")]
        internal static extern int Print(LogPriority prio, string tag, string fmt, string file, string func, int line, string msg);
    }
}
