using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen
{
    internal static class NativeMethods
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
        [DllImportAttribute("libdlog.so.0", EntryPoint = "dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DlogPrint(LogPriority prio, string tag, string fmt, string msg);

        [DllImportAttribute("libdlog.so.0", EntryPoint = "dlog_print", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DlogPrint(LogPriority prio, string tag, string fmt, string file, string func, int line, string msg);
    }
}
