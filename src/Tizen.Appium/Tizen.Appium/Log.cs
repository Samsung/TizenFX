using System;
using System.Runtime.CompilerServices;

namespace Tizen.Appium
{
    internal static class Log
    {
        static String Tag = "TizenAppium";

        internal static void Debug(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Debug(Tag, message, file, func, line);
        }

        internal static void Verbose(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Verbose(Tag, message, file, func, line);
        }

        internal static void Info(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Info(Tag, message, file, func, line);
        }

        internal static void Warn(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Warn(Tag, message, file, func, line);
        }

        internal static void Error(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Error(Tag, message, file, func, line);
        }

        internal static void Fatal(string message,
                [CallerFilePath] string file = "",
                [CallerMemberName] string func = "",
                [CallerLineNumber] int line = 0)
        {
            Tizen.Log.Fatal(Tag, message, file, func, line);
        }
    }
}
