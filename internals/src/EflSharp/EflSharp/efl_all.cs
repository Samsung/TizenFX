#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Threading;

using static Efl.UnsafeNativeMethods;

namespace Efl {

static class UnsafeNativeMethods {
    [DllImport(efl.Libs.Ecore)] public static extern void ecore_init();
    [DllImport(efl.Libs.Ecore)] public static extern void ecore_shutdown();
    [DllImport(efl.Libs.Evas)] public static extern void evas_init();
    [DllImport(efl.Libs.Evas)] public static extern void evas_shutdown();
    [DllImport(efl.Libs.Elementary)] public static extern int elm_init(int argc, IntPtr argv);
    [DllImport(efl.Libs.Elementary)] public static extern void elm_policy_set(int policy, int policy_detail);
    [DllImport(efl.Libs.Elementary)] public static extern void elm_shutdown();
    [DllImport(efl.Libs.Elementary)] public static extern void elm_run();
    [DllImport(efl.Libs.Elementary)] public static extern void elm_exit();
}

public enum Components {
    Basic,
    Ui
}

public static class All {
    private static bool InitializedUi = false;

    public static void Init(Efl.Components components=Components.Basic) {
        Eina.Config.Init();
        Efl.Eo.Config.Init();
        ecore_init();
        evas_init();
        eldbus.Config.Init();

        if (components == Components.Ui) {
            Efl.Ui.Config.Init();
            InitializedUi = true;
        }
    }

    /// <summary>Shutdowns all EFL subsystems.</summary>
    public static void Shutdown() {
        // Try to cleanup everything before actually shutting down.
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();

        if (InitializedUi)
            Efl.Ui.Config.Shutdown();
        eldbus.Config.Shutdown();
        evas_shutdown();
        ecore_shutdown();
        Efl.Eo.Config.Shutdown();
        Eina.Config.Shutdown();
    }
}

// Placeholder. Will move to elm_config.cs later
namespace Ui {

public static class Config {
    public static void Init() {
        // TODO Support elm command line arguments
#if WIN32 // Not a native define, we define it in our build system
        // Ecore_Win32 uses OleInitialize, which requires single thread apartments
        if (System.Threading.Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
            throw new InvalidOperationException("UI Applications require STAThreadAttribute in Main()");
#endif
        elm_init(0, IntPtr.Zero);

        elm_policy_set((int)Elm.Policy.Quit, (int)Elm.PolicyQuit.LastWindowHidden);
    }
    public static void Shutdown() {
        elm_shutdown();
    }

    public static void Run() {
        elm_run();
    }

    public static void Exit() {
        elm_exit();
    }
}

}

}
