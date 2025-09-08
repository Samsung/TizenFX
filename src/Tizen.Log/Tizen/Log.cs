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
using System.Text;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.ComponentModel;

namespace Tizen
{
    internal static class LogPrinter
    {
        private static char[] sep = { '\\', '/' };
        private static byte[] fmt1 = Encoding.UTF8.GetBytes("%s");
        private static byte[] fmt2 = Encoding.UTF8.GetBytes("%s: %s(%d) > %s");

        private static unsafe void _Print(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            if (tag == null)
                tag = String.Empty;
            if (message == null)
                message = String.Empty;
            if (file == null)
                file = String.Empty;
            if (func == null)
                func = String.Empty;

            int tagByteLength = Encoding.UTF8.GetMaxByteCount(tag.Length);
            Span<byte> tagByte = tagByteLength < 1024 ? stackalloc byte[tagByteLength + 1] : new byte[tagByteLength + 1];

            int messageByteLength = Encoding.UTF8.GetMaxByteCount(message.Length);
            Span<byte> messageByte = messageByteLength < 1024 ? stackalloc byte[messageByteLength + 1] : new byte[messageByteLength + 1];

            fixed (char* pTagChar = tag)
            fixed (char* pMessageChar = message)
            fixed (byte* pTagByte = &MemoryMarshal.GetReference(tagByte))
            fixed (byte* pMessageByte = &MemoryMarshal.GetReference(messageByte))
            fixed (byte* pFmt1Byte = fmt1)
            fixed (byte* pFmt2Byte = fmt2)
            {
                int len = Encoding.UTF8.GetBytes(pTagChar, tag.Length, pTagByte, tagByteLength);
                pTagByte[len] = 0;
                len = Encoding.UTF8.GetBytes(pMessageChar, message.Length, pMessageByte, messageByteLength);
                pMessageByte[len] = 0;

                if (String.IsNullOrEmpty(file))
                {
                    if (log_id == Interop.Dlog.LogID.LOG_ID_INVALID)
                        Interop.Dlog.Print(priority, pTagByte, pFmt1Byte, pMessageByte);
                    else
                        Interop.Dlog.InternalPrint(log_id, priority, pTagByte, pFmt1Byte, pMessageByte);
                    return;
                }

                int index = file.LastIndexOfAny(sep) + 1;
                int filenameLength = file.Length - index;

                int filenameByteLength = Encoding.UTF8.GetMaxByteCount(filenameLength);
                Span<byte> filenameByte = filenameByteLength < 1024 ? stackalloc byte[filenameByteLength + 1] : new byte[filenameByteLength + 1];

                int funcByteLength = Encoding.UTF8.GetMaxByteCount(func.Length);
                Span<byte> funcByte = funcByteLength < 1024 ? stackalloc byte[funcByteLength + 1] : new byte[funcByteLength + 1];

                fixed (char* pFilenameChar = file)
                fixed (char* pFuncChar = func)
                fixed (byte* pFilenameByte = &MemoryMarshal.GetReference(filenameByte))
                fixed (byte* pFuncByte = &MemoryMarshal.GetReference(funcByte))
                {
                    len = Encoding.UTF8.GetBytes(pFilenameChar + index, filenameLength, pFilenameByte, filenameByteLength);
                    pFilenameByte[len] = 0;
                    len = Encoding.UTF8.GetBytes(pFuncChar, func.Length, pFuncByte, funcByteLength);
                    pFuncByte[len] = 0;

                    if (log_id == Interop.Dlog.LogID.LOG_ID_INVALID)
                        Interop.Dlog.Print(priority, pTagByte, pFmt2Byte, pFilenameByte, pFuncByte, line, pMessageByte);
                    else
                        Interop.Dlog.InternalPrint(log_id, priority, pTagByte, pFmt2Byte, pFilenameByte, pFuncByte, line, pMessageByte);
                }
            }
        }

        private static unsafe void _PrintFallback(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            fixed (byte* pTagByte = Encoding.UTF8.GetBytes(tag))
            fixed (byte* pMessageByte = Encoding.UTF8.GetBytes(message))
            fixed (byte* pFmt1Byte = fmt1)
            fixed (byte* pFmt2Byte = fmt2)
            {
                if (String.IsNullOrEmpty(file))
                {
                    if (log_id == Interop.Dlog.LogID.LOG_ID_INVALID)
                        Interop.Dlog.Print(priority, pTagByte, pFmt1Byte, pMessageByte);
                    else
                        Interop.Dlog.InternalPrint(log_id, priority, pTagByte, pFmt1Byte, pMessageByte);
                    return;
                }

                int index = file.LastIndexOfAny(sep);
                string filename = file.Substring(index + 1);

                fixed (byte* pFilenameByte = Encoding.UTF8.GetBytes(filename))
                fixed (byte* pFuncByte = Encoding.UTF8.GetBytes(func))
                {
                    if (log_id == Interop.Dlog.LogID.LOG_ID_INVALID)
                        Interop.Dlog.Print(priority, pTagByte, pFmt2Byte, pFilenameByte, pFuncByte, line, pMessageByte);
                    else
                        Interop.Dlog.InternalPrint(log_id, priority, pTagByte, pFmt2Byte, pFilenameByte, pFuncByte, line, pMessageByte);
                }
            }
        }

        public static unsafe void Print(Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            try
            {
                _Print(Interop.Dlog.LogID.LOG_ID_INVALID, priority, tag, message, file, func, line);
            }
            catch (StackOverflowException)
            {
                _PrintFallback(Interop.Dlog.LogID.LOG_ID_INVALID, priority, tag, message, file, func, line);
            }
        }

        public static unsafe void Print(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            try
            {
                _Print(log_id, priority, tag, message, file, func, line);
            }
            catch (StackOverflowException)
            {
                _PrintFallback(log_id, priority, tag, message, file, func, line);
            }
        }
    }

    /// <summary>
    /// Provides methods to print log messages to the Tizen logging system.
    /// Depending on products, some priorities (e.g., Vervose and Debug) can be disabled by default to prevent too many logs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Log
    {
        private static char[] sep = { '\\', '/' };
        /// <summary>
        /// Prints a regular log message with the VERBOSE priority.
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
        /// Prints a regular log message with the DEBUG priority.
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
        /// Prints a regular log message with the INFO priority.
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
        /// Prints a regular log message with the WARNING priority.
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
        /// Prints a regular log message with the ERROR priority.
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
        /// Prints a regular log message with the FATAL priority.
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

        static unsafe void Print(Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            LogPrinter.Print(priority, tag, message, file, func, line);
        }
    }

    /// <summary>
    /// Provides methods to print log messages to the Tizen logging system.
    /// Sends "internal" logs, which end up in a different Dlog buffer than regular logs.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InternalLog
    {
        private static char[] sep = { '\\', '/' };
        /// <summary>
        /// Prints an internal log message with the VERBOSE priority.
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
        /// Prints an internal log message with the DEBUG priority.
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
        /// Prints an internal log message with the INFO priority.
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
        /// Prints an internal log message with the WARNING priority.
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
        /// Prints an internal log message with the ERROR priority.
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
        /// Prints an internal log message with the FATAL priority.
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

        static unsafe void Print(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
            LogPrinter.Print(log_id, priority, tag, message, file, func, line);
        }
    }

    /// <summary>
    /// Provides methods to print log messages to the Tizen logging system.
    /// Sends "secure" logs, which have extra safety not to appear on release builds.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class SecureLog
    {
        private static char[] sep = { '\\', '/' };
        /// <summary>
        /// Prints a secure log message with the VERBOSE priority.
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
        /// Prints a secure log message with the DEBUG priority.
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
        /// Prints a secure log message with the INFO priority.
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
        /// Prints a secure log message with the WARNING priority.
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
        /// Prints a secure log message with the ERROR priority.
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
        /// Prints a secure log message with the FATAL priority.
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

        static unsafe void Print(Interop.Dlog.LogID log_id, Interop.Dlog.LogPriority priority, string tag, string message, string file, string func, int line)
        {
#if !DISABLE_SECURELOG
            LogPrinter.Print(log_id, priority, tag, message, file, func, line);
#endif
        }
    }
}
