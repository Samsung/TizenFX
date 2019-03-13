#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Diagnostics.Contracts;

namespace Eina { // Manual wrappers around eina functions

public class Log
{
    [DllImport(efl.Libs.Eina)] private static extern void eina_log_print(
            int domain,
            Level level,
            [MarshalAs(UnmanagedType.LPStr)] String file,
            [MarshalAs(UnmanagedType.LPStr)] String function,
            int line,
            [MarshalAs(UnmanagedType.LPStr)] String message);

    [DllImport(efl.Libs.Eina)] private static extern int eina_log_domain_register(
            [MarshalAs(UnmanagedType.LPStr)] String name,
            [MarshalAs(UnmanagedType.LPStr)] String color);

    [DllImport(efl.Libs.Eina)] private static extern void eina_log_level_set(Level level);

    [DllImport(efl.Libs.Eina)] private static extern Level eina_log_level_get();

    public enum Level
    {
        Critical,
        Error,
        Warning,
        Info,
        Debug,
        Unkown = (-2147483647 - 1)
    }

    public class Color
    {
        public static string LIGHTRED  = "\033[31;1m";
        public static string RED       = "\033[31m";
        public static string LIGHTBLUE = "\033[34;1m";
        public static string BLUE      = "\033[34m";
        public static string GREEN     = "\033[32;1m";
        public static string YELLOW    = "\033[33;1m";
        public static string ORANGE    = "\033[0;33m";
        public static string WHITE     = "\033[37;1m";
        public static string LIGHTCYAN = "\033[36;1m";
        public static string CYAN      = "\033[36m";
        public static string RESET     = "\033[0m";
        public static string HIGH      = "\033[1m";
    }

    private static int domain = -1;

    static Log()
    {
        const String name="mono";
        const String color="\033[32;1m";

        // Maybe move this check outside when other eina stuff get support?
        domain = eina_log_domain_register(name, color);
        if (domain < 0)
          Console.WriteLine("Error: Couldn't register Eina log domain for name {0}.", name);
        else
          Info($"Registered mono domain with number {domain}");
    }

    private static void EnsureDomainRegistered()
    {
        if (domain < 0)
          throw new InvalidOperationException("Log domain is not registered.");
    }

    public static void Critical(String message, [CallerLineNumber] int line=0, [CallerFilePath] string file=null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Critical, file, member, line, message);
    }
    public static void Error(String message, [CallerLineNumber] int line=0, [CallerFilePath] string file=null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Error, file, member, line, message);
    }
    public static void Warning(String message, [CallerLineNumber] int line=0, [CallerFilePath] string file=null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Warning, file, member, line, message);
    }
    public static void Info(String message, [CallerLineNumber] int line=0, [CallerFilePath] string file=null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Info, file, member, line, message);
    }
    public static void Debug(String message, [CallerLineNumber] int line=0, [CallerFilePath] string file=null, [CallerMemberName] string member = null)
    {
        EnsureDomainRegistered();
        eina_log_print(domain, Level.Debug, file, member, line, message);
    }

    public static void GlobalLevelSet(Level level)
    {
        eina_log_level_set(level);
    }

    public static Level GlobalLevelGet()
    {
        return eina_log_level_get();
    }
}
}
