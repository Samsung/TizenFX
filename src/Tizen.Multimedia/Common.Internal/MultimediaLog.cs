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
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Tizen.Multimedia
{
    internal static class MultimediaLog
    {
        [Conditional("DEBUG")]
        public static void Debug(string tag, string message, Exception e = null, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Log.Debug(tag, BuildMessage(message, e), file, func, line);
        }

        public static void Error(string tag, string message, Exception e = null, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Log.Error(tag, BuildMessage(message, e), file, func, line);
        }

        public static void Fatal(string tag, string message, Exception e = null, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Log.Fatal(tag, BuildMessage(message, e), file, func, line);
        }

        public static void Info(string tag, string message, Exception e = null, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Log.Info(tag, BuildMessage(message, e), file, func, line);
        }

        public static void Verbose(string tag, string message, Exception e = null, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Log.Verbose(tag, BuildMessage(message, e), file, func, line);
        }

        public static void Warn(string tag, string message, Exception e = null, [CallerFilePath] string file = "", [CallerMemberName] string func = "", [CallerLineNumber] int line = 0)
        {
            Log.Warn(tag, BuildMessage(message, e), file, func, line);
        }

        private static string BuildMessage(string message, Exception exception)
        {
            if (exception == null)
            {
                return message;
            }

            StringBuilder sb = new StringBuilder();

            Exception e = exception;
            while (e != null)
            {
                message += e.Message + Environment.NewLine + e.StackTrace;
                e = e.InnerException;
            }

            return sb.ToString();
        }
    }
}
