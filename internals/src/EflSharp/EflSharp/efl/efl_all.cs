#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Threading;

using static Efl.UnsafeNativeMethods;

namespace Efl
{

static class UnsafeNativeMethods
{
    private delegate void init_func_delegate();
    [DllImport(efl.Libs.Ecore)] public static extern void ecore_init();
    [DllImport(efl.Libs.Ecore)] public static extern void ecore_shutdown();
    // dotnet loads libraries from DllImport with RTLD_LOCAL. Due to the
    // way evas modules are built with meson, currently they do not link directly
    // with libevas, leading to symbol not found errors when trying to open them.
    // The call to FunctionWrapper makes sure evas is loaded with RTLD_GLOBAL,
    // allowing the symbols to remain visible for the modules until the build
    // is sorted out.
    private static Efl.Eo.FunctionWrapper<init_func_delegate> _evas_init;
    [DllImport(efl.Libs.Evas)] public static extern void evas_shutdown();
    [DllImport(efl.Libs.Elementary)] public static extern int elm_init(int argc, IntPtr argv);
    [DllImport(efl.Libs.Elementary)] public static extern void elm_policy_set(int policy, int policy_detail);
    [DllImport(efl.Libs.Elementary)] public static extern void elm_shutdown();
    [DllImport(efl.Libs.Elementary)] public static extern void elm_run();
    [DllImport(efl.Libs.Elementary)] public static extern void elm_exit();

    static UnsafeNativeMethods()
    {
        _evas_init = new Efl.Eo.FunctionWrapper<init_func_delegate>("evas", "evas_init");
    }

    public static void evas_init()
    {
        _evas_init.Value.Delegate();
    }
}

public static class All
{
    private static bool InitializedUi = false;

    public static bool MainLoopInitialized {
        get;
        private set;
    }

    public static readonly object InitLock = new object();

    public static void Init(Efl.Csharp.Components components = Efl.Csharp.Components.Basic)
    {
        Eina.Config.Init();
        Efl.Eo.Config.Init();
        ecore_init();
        evas_init();
        eldbus.Config.Init();

        if (components == Efl.Csharp.Components.Ui)
        {
            Efl.Ui.Config.Init();
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
        Eina.Log.Debug("Calling GC before shutdown");
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();

        Monitor.Enter(InitLock);
        MainLoopInitialized = false;
        Monitor.Exit(InitLock);

        if (InitializedUi)
        {
            Eina.Log.Debug("Shutting down Elementary");
            Efl.Ui.Config.Shutdown();
        }

        Eina.Log.Debug("Shutting down Eldbus");
        eldbus.Config.Shutdown();
        Eina.Log.Debug("Shutting down Evas");
        evas_shutdown();
        Eina.Log.Debug("Shutting down Ecore");
        ecore_shutdown();
        Eina.Log.Debug("Shutting down Eo");
        Efl.Eo.Config.Shutdown();
        Eina.Log.Debug("Shutting down Eina");
        Eina.Config.Shutdown();
    }
}

// Placeholder. Will move to elm_config.cs later
namespace Ui
{

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

        elm_policy_set((int)Elm.Policy.Quit, (int)Elm.PolicyQuit.LastWindowHidden);

        // TIZEN_ONLY(20190425) Use efl-sharp-theme.edj on EflSharp
        Efl.Ui.Theme.GetDefault().AddOverlay("/usr/share/efl-sharp/efl-sharp-theme.edj");
        //
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
