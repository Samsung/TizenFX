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
using System.IO;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Tizen
{
    /// <summary>
    /// Provides methods to print log messages to the Tizen logging system.
    /// Depending on products, some priorities (e.g., Vervose and Debug) can be disabled by default to prevent too many logs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Log
    {
        /// <summary>
        /// Prints a log message with the VERBOSE priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Verbose(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogPriority.DLOG_VERBOSE, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the DEBUG priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Debug(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogPriority.DLOG_DEBUG, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the INFO priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Info(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogPriority.DLOG_INFO, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the WARNING priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Warn(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogPriority.DLOG_WARN, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the ERROR priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Error(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogPriority.DLOG_ERROR, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the FATAL priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Fatal(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogPriority.DLOG_FATAL, tag, message, file, func, line);
        }

        static void Print(Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(priority, tag, "%s", message);
            }
            else
            {
                Uri f = new Uri("file://" + file);
                Interop.Dlog.Print(priority, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, message);
            }
        }
    }

    /// <summary>
    /// Provides methods to print log messages to the Tizen logging system.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InternalLog
    {
        /// <summary>
        /// Prints a log message with the VERBOSE priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Verbose(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            // For internal dlog APIs, Verbose level log is disabled
            // Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_VERBOSE, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the DEBUG priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Debug(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_DEBUG, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the INFO priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Info(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_INFO, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the WARNING priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Warn(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_WARN, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the ERROR priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Error(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_ERROR, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the FATAL priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Fatal(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_FATAL, tag, message, file, func, line);
        }

        static void Print(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.InternalPrint(log_id, priority, tag, "%s", message);
            }
            else
            {
                Uri f = new Uri("file://" + file);
                Interop.Dlog.InternalPrint(log_id, priority, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, message);
            }
        }
    }

    /// <summary>
    /// Provides methods to print log messages to the Tizen logging system.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SecureLog
    {
        /// <summary>
        /// Prints a log message with the VERBOSE priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Verbose(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            // For internal dlog APIs, Verbose level log is disabled
            // Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_VERBOSE, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the DEBUG priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Debug(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_DEBUG, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the INFO priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Info(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_INFO, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the WARNING priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Warn(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_WARN, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the ERROR priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Error(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_ERROR, tag, message, file, func, line);
        }

        /// <summary>
        /// Prints a log message with the FATAL priority.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="message">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of the calling position. This argument will be set automatically by the compiler.</param>
        public static void Fatal(string tag, string message, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Print(Interop.Dlog.LogID.LOG_ID_MAIN, Interop.Dlog.LogPriority.DLOG_FATAL, tag, message, file, func, line);
        }

        static void Print(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
#if !DISABLE_SECURELOG
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.InternalPrint(log_id, priority, tag, "[SECURE_LOG] %s", message);
            }
            else
            {
                Uri f = new Uri("file://" + file);
                Interop.Dlog.InternalPrint(log_id, priority, tag, "%s: %s(%d) > [SECURE_LOG] %s", Path.GetFileName(f.AbsolutePath), func, line, message);
            }
#endif
        }
    }
}
