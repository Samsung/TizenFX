#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;

namespace UIKit
{

namespace DataTypes
{
// Manual wrappers around eina functions

/// <summary>EFL Logging facilities.
///
/// Since EFL 1.23.
/// </summary>
public class Log
{
    [DllImport(UIKit.Libs.Eina)] private static extern void eina_log_print(
            int domain,
            Level level,
            [MarshalAs(UnmanagedType.LPStr)] String file,
            [MarshalAs(UnmanagedType.LPStr)] String function,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] String message);

    [DllImport(UIKit.Libs.Eina)] private static extern int eina_log_domain_register(
            [MarshalAs(UnmanagedType.LPStr)] String name,
            [MarshalAs(UnmanagedType.LPStr)] String color);

    [DllImport(UIKit.Libs.Eina)] private static extern void eina_log_level_set(Level level);

    [DllImport(UIKit.Libs.Eina)] private static extern Level eina_log_level_get();

    /// <summary>The levels of logging.</summary>
    public enum Level
    {
        /// <summary>Critical events.</summary>
        Critical,
        /// <summary>Error events.</summary>
        Error,
        /// <summary>Warning events.</summary>
        Warning,
        /// <summary>Informative events.</summary>
        Info,
        /// <summary>Debugging messages.</summary>
        Debug,
        /// <summary>Unknown events.</summary>
        Unkown = (-2147483647 - 1)
    }

    /// <summary>The colors to be used by the logging system.</summary>
    public class Color
    {
        /// <summary>Light red</summary>
        public static string LIGHTRED  = "\033[31;1m";
        /// <summary>Red</summary>
        public static string RED       = "\033[31m";
        /// <summary>Light blue</summary>
        public static string LIGHTBLUE = "\033[34;1m";
        /// <summary>Blue</summary>
        public static string BLUE      = "\033[34m";
        /// <summary>Green</summary>
        public static string GREEN     = "\033[32;1m";
        /// <summary>Yellow</summary>
        public static string YELLOW    = "\033[33;1m";
        /// <summary>Orange</summary>
        public static string ORANGE    = "\033[0;33m";
        /// <summary>White</summary>
        public static string WHITE     = "\033[37;1m";
        /// <summary>Light cyan</summary>
        public static string LIGHTCYAN = "\033[36;1m";
        /// <summary>Cyan</summary>
        public static string CYAN      = "\033[36m";
        /// <summary>Reset</summary>
        public static string RESET     = "\033[0m";
        /// <summary>Bold</summary>
        public static string HIGH      = "\033[1m";
    }

    private static int domain = -1;

    /// <summary>Static class initializer.</summary>
    static Log()
    {
        const String name = "mono";
        const String color = "\033[32;1m";

        // Maybe move this check outside when other eina stuff get support?
        domain = eina_log_domain_register(name, color);
        if (domain < 0)
        {
            Console.WriteLine("Error: Couldn't register Eina log domain for name {0}.", name);
        }
        else
        {
            Info($"Registered mono domain with number {domain}");
        }
    }

    private static void EnsureDomainRegistered()
    {
        if (domain < 0)
        {
            throw new InvalidOperationException("Log domain is not registered.");
        }
    }

    /// <summary>Prints a critical message with context info. This context is filled automatically by the C# compiler.</summary>
    /// <param name="message">The message to be printed.</param>
    /// <param name="line">The line number this method was called from.</param>
    /// <param name="file">The file this method was called from.</param>
    /// <param name="member">The enlosing method this method was called from.</param>
    public static void Critical(String message, [CallerLineNumber] int line = 0, [CallerFilePath] string file = null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Critical, file, member, line, message);
    }

    /// <summary>Prints an error message with context info. This context is filled automatically by the C# compiler.</summary>
    /// <param name="message">The message to be printed.</param>
    /// <param name="line">The line number this method was called from.</param>
    /// <param name="file">The file this method was called from.</param>
    /// <param name="member">The enlosing method this method was called from.</param>
    public static void Error(String message, [CallerLineNumber] int line = 0, [CallerFilePath] string file = null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Error, file, member, line, message);
    }

    /// <summary>Prints a warning message with context info. This context is filled automatically by the C# compiler.</summary>
    /// <param name="message">The message to be printed.</param>
    /// <param name="line">The line number this method was called from.</param>
    /// <param name="file">The file this method was called from.</param>
    /// <param name="member">The enlosing method this method was called from.</param>
    public static void Warning(String message, [CallerLineNumber] int line = 0, [CallerFilePath] string file = null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Warning, file, member, line, message);
    }

    /// <summary>Prints an informative message with context info. This context is filled automatically by the C# compiler.</summary>
    /// <param name="message">The message to be printed.</param>
    /// <param name="line">The line number this method was called from.</param>
    /// <param name="file">The file this method was called from.</param>
    /// <param name="member">The enlosing method this method was called from.</param>
    public static void Info(String message, [CallerLineNumber] int line = 0, [CallerFilePath] string file = null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Info, file, member, line, message);
    }

    /// <summary>Prints a debug message with context info. This context is filled automatically by the C# compiler.</summary>
    /// <param name="message">The message to be printed.</param>
    /// <param name="line">The line number this method was called from.</param>
    /// <param name="file">The file this method was called from.</param>
    /// <param name="member">The enlosing method this method was called from.</param>
    public static void Debug(String message, [CallerLineNumber] int line = 0, [CallerFilePath] string file = null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Debug, file, member, line, message);
    }

    /// <summary>Sets the highest level log messages should be printed. Values larger than this one are ignored.</summary>
    /// <param name="level">The global message level.</param>
    public static void GlobalLevelSet(Level level)
    {
        eina_log_level_set(level);
    }

    /// <summary>Gets the lowest level of messages that are not ignored.</summary>
    /// <returns>The current message level.</returns>
    public static Level GlobalLevelGet()
    {
        return eina_log_level_get();
    }
}

}

}
