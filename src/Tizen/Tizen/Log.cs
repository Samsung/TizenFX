// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.IO;
using System.Runtime.CompilerServices;

namespace Tizen
{
    /// <summary>
    /// Provides methods to print log messages to Tizen logging system.
    /// </summary>
    public class Log
    {
        /// <summary>
        /// Prints a log message with the DEBUG priority.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="msg">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of calling position. This argument will be set automatically by the compiler.</param>
        public static void Debug(string tag, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_DEBUG, tag, "%s", msg);
            }
            else
            {
                Uri f = new Uri(file);
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_DEBUG, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, msg);
            }
        }

        /// <summary>
        /// Prints a log message with the VERBOSE priority.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="msg">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of calling position. This argument will be set automatically by the compiler.</param>
        public static void Verbose(string tag, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_VERBOSE, tag, "%s", msg);
            }
            else
            {
                Uri f = new Uri(file);
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_VERBOSE, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, msg);
            }
        }

        /// <summary>
        /// Prints a log message with the INFO priority.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="msg">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of calling position. This argument will be set automatically by the compiler.</param>
        public static void Info(string tag, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_INFO, tag, "%s", msg);
            }
            else
            {
                Uri f = new Uri(file);
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_INFO, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, msg);
            }
        }

        /// <summary>
        /// Prints a log message with the WARNING priority.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="msg">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of calling position. This argument will be set automatically by the compiler.</param>
        public static void Warn(string tag, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_WARN, tag, "%s", msg);
            }
            else
            {
                Uri f = new Uri(file);
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_WARN, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, msg);
            }
        }

        /// <summary>
        /// Prints a log message with the ERROR priority.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="msg">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of calling position. This argument will be set automatically by the compiler.</param>
        public static void Error(string tag, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_ERROR, tag, "%s", msg);
            }
            else
            {
                Uri f = new Uri(file);
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_ERROR, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, msg);
            }
        }

        /// <summary>
        /// Prints a log message with the FATAL priority.
        /// </summary>
        /// <param name="tag">The tag name of the log message.</param>
        /// <param name="msg">The log message to print.</param>
        /// <param name="file">The source file path of the caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="func">The function name of caller function. This argument will be set automatically by the compiler.</param>
        /// <param name="line">The line number of calling position. This argument will be set automatically by the compiler.</param>
        public static void Fatal(string tag, string msg, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            if (String.IsNullOrEmpty(file))
            {
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_FATAL, tag, "%s", msg);
            }
            else
            {
                Uri f = new Uri(file);
                Interop.Dlog.Print(Interop.Dlog.LogPriority.DLOG_FATAL, tag, "%s: %s(%d) > %s", Path.GetFileName(f.AbsolutePath), func, line, msg);
            }
        }
    }
}
