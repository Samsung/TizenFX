#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Threading;

using static UIKit.UnsafeNativeMethods;

namespace UIKit
{

static class UnsafeNativeMethods
{
    private delegate void init_func_delegate();
    [DllImport(UIKit.Libs.Ecore)] public static extern void ecore_init();
    [DllImport(UIKit.Libs.Ecore)] public static extern void ecore_init_ex(int argc, IntPtr argv);
    [DllImport(UIKit.Libs.Ecore)] public static extern void ecore_shutdown();
    // dotnet loads libraries from DllImport with RTLD_LOCAL. Due to the
    // way evas modules are built with meson, currently they do not link directly
    // with libevas, leading to symbol not found errors when trying to open them.
    // The call to FunctionWrapper makes sure evas is loaded with RTLD_GLOBAL,
    // allowing the symbols to remain visible for the modules until the build
    // is sorted out.
    private static UIKit.Wrapper.FunctionWrapper<init_func_delegate> _evas_init;
    [DllImport(UIKit.Libs.Evas)] public static extern void evas_shutdown();
    [DllImport(UIKit.Libs.Elementary)] public static extern int elm_init(int argc, IntPtr argv);
    [DllImport(UIKit.Libs.Elementary)] public static extern void elm_shutdown();
    [DllImport(UIKit.Libs.Elementary)] public static extern void elm_run();
    [DllImport(UIKit.Libs.Elementary)] public static extern void elm_exit();

    static UnsafeNativeMethods()
    {
        _evas_init = new UIKit.Wrapper.FunctionWrapper<init_func_delegate>(UIKit.Libs.Evas, "evas_init");
    }

    public static void evas_init()
    {
        _evas_init.Value.Delegate();
    }
}

/// <summary>Wrapper around the initialization functions of all modules.
///
/// Since EFL 1.23.
/// </summary>
public static class All
{
    private static bool InitializedUi = false;

    public static bool MainLoopInitialized {
        get;
        private set;
    }

    public static readonly object InitLock = new object();

    public static void Init(UIKit.Csharp.Components components = UIKit.Csharp.Components.Basic)
    {
        UIKit.DataTypes.Config.Init();
        UIKit.Wrapper.Config.Init();
        ecore_init();
        ecore_init_ex(0, IntPtr.Zero);
        evas_init();
        //eldbus.Config.Init();

        if (components == UIKit.Csharp.Components.Ui)
        {
            UIKit.Ui.Config.Init();
            InitializedUi = true;
        }
        Monitor.Enter(InitLock);
        MainLoopInitialized = true;
        Monitor.Exit(InitLock);
    }

    /// <summary>Shutdowns all EFL subsystems.</summary>
    public static void Shutdown()
    {
        // Try to cleanup everything before actually shutting down.
        UIKit.DataTypes.Log.Debug("Calling GC before shutdown");
        for (int i = 0; i < 3; i++)
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            UIKit.App.AppMain.Iterate();
        }

        Monitor.Enter(InitLock);
        MainLoopInitialized = false;
        Monitor.Exit(InitLock);

        if (InitializedUi)
        {
            UIKit.DataTypes.Log.Debug("Shutting down Elementary");
            UIKit.Ui.Config.Shutdown();
        }

        //UIKit.DataTypes.Log.Debug("Shutting down Eldbus");
        //eldbus.Config.Shutdown();
        UIKit.DataTypes.Log.Debug("Shutting down Evas");
        evas_shutdown();
        UIKit.DataTypes.Log.Debug("Shutting down Ecore");
        ecore_shutdown();
        UIKit.DataTypes.Log.Debug("Shutting down Eo");
        UIKit.Wrapper.Config.Shutdown();
        UIKit.DataTypes.Log.Debug("Shutting down Eina");
        UIKit.DataTypes.Config.Shutdown();
    }
}

// Placeholder. Will move to elm_config.cs later
namespace Ui
{

/// <summary>Initialization and shutdown of the UI libraries.
///
/// Since EFL 1.23.
/// </summary>
public static class Config
{
    public static void Init()
    {
        // TODO Support elm command line arguments
#if WIN32 // Not a native define, we define it in our build system
        // Ecore_Win32 uses OleInitialize, which requires single thread apartments
        if (System.Threading.Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
        {
            throw new InvalidOperationException("UI Applications require STAThreadAttribute in Main()");
        }
#endif
        elm_init(0, IntPtr.Zero);


        // TIZEN_ONLY(20190425) Use efl-sharp-theme.edj on UIKitSharp
//        UIKit.Ui.Theme.GetDefault().AddOverlay("/usr/share/efl-sharp/efl-sharp-theme.edj");
        //

//        UIKit.Ui.Win.ExitOnAllWindowsClosed = new UIKit.DataTypes.Value(0);
    }

    public static void Shutdown()
    {
        elm_shutdown();
    }

    public static void Run()
    {
        elm_run();
    }

    public static void Exit()
    {
        elm_exit();
    }
}

}

}
