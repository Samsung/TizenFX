/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */
#pragma warning disable 1591

using System;
using System.Runtime.InteropServices;
using System.Threading;

using static CoreUI.UnsafeNativeMethods;

namespace CoreUI
{

static class UnsafeNativeMethods
{
    private delegate void init_func_delegate();
    [DllImport(CoreUI.Libs.Ecore)] internal static extern void ecore_init();
    [DllImport(CoreUI.Libs.Ecore)] internal static extern void ecore_init_ex(int argc, IntPtr argv);
    [DllImport(CoreUI.Libs.Ecore)] internal static extern void ecore_shutdown();
    // dotnet loads libraries from DllImport with RTLD_LOCAL. Due to the
    // way evas modules are built with meson, currently they do not link directly
    // with libevas, leading to symbol not found errors when trying to open them.
    // The call to FunctionWrapper makes sure evas is loaded with RTLD_GLOBAL,
    // allowing the symbols to remain visible for the modules until the build
    // is sorted out.
    private static CoreUI.Wrapper.FunctionWrapper<init_func_delegate> _evas_init;
    [DllImport(CoreUI.Libs.Evas)] internal static extern void evas_shutdown();
    [DllImport(CoreUI.Libs.Elementary)] internal static extern int elm_init(int argc, IntPtr argv);
    [DllImport(CoreUI.Libs.Elementary)] internal static extern void elm_shutdown();
    [DllImport(CoreUI.Libs.Elementary)] internal static extern void elm_run();
    [DllImport(CoreUI.Libs.Elementary)] internal static extern void elm_exit();

    static UnsafeNativeMethods()
    {
        _evas_init = new CoreUI.Wrapper.FunctionWrapper<init_func_delegate>(CoreUI.Libs.Evas, "evas_init");
    }

    internal static void evas_init()
    {
        _evas_init.Value.Delegate();
    }
}

/// <summary>Wrapper around the initialization functions of all modules.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public static class All
{
    private static CoreUI.Csharp.Components initComponents = CoreUI.Csharp.Components.Basic;

    /// <summary>
    ///   If the main loop was initialized.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static bool MainLoopInitialized {
        get;
        private set;
    }

    internal static readonly object InitLock = new object();

    /// <summary>
    ///   Initialize the CoreUI.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="components">The <see cref="CoreUI.Csharp.Components" /> that initialize the CoreUI.</param>
    public static void Init(CoreUI.Csharp.Components components = CoreUI.Csharp.Components.Basic)
    {
        if (components == CoreUI.Csharp.Components.None)
        {
            return;
        }

        initComponents = components;

        if ((initComponents & CoreUI.Csharp.Components.Basic)
            == CoreUI.Csharp.Components.Basic)
        {
            CoreUI.DataTypes.Config.Init();
            CoreUI.Wrapper.Config.Init();
            ecore_init();
            ecore_init_ex(0, IntPtr.Zero);
            evas_init();
            //eldbus.Config.Init();
        }

        if ((initComponents & CoreUI.Csharp.Components.UI)
            == CoreUI.Csharp.Components.UI)
        {
            CoreUI.UI.Config.Init();
        }
        Monitor.Enter(InitLock);
        MainLoopInitialized = true;
        Monitor.Exit(InitLock);
    }

    /// <summary>Shutdowns all EFL subsystems.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Shutdown()
    {
        // Try to cleanup everything before actually shutting down.
        CoreUI.DataTypes.Log.Debug("Calling GC before shutdown");
        for (int i = 0; i < 3; i++)
        {
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
            CoreUI.App.AppMain.Iterate();
        }

        Monitor.Enter(InitLock);
        MainLoopInitialized = false;
        Monitor.Exit(InitLock);

        if (initComponents == CoreUI.Csharp.Components.None)
        {
            return;
        }

        if ((initComponents & CoreUI.Csharp.Components.UI)
            == CoreUI.Csharp.Components.UI)
        {
            CoreUI.DataTypes.Log.Debug("Shutting down Elementary");
            CoreUI.UI.Config.Shutdown();
        }

        if ((initComponents & CoreUI.Csharp.Components.Basic)
            == CoreUI.Csharp.Components.Basic)
        {
            //CoreUI.DataTypes.Log.Debug("Shutting down Eldbus");
            //eldbus.Config.Shutdown();
            CoreUI.DataTypes.Log.Debug("Shutting down Evas");
            evas_shutdown();
            CoreUI.DataTypes.Log.Debug("Shutting down Ecore");
            ecore_shutdown();
            CoreUI.DataTypes.Log.Debug("Shutting down Eo");
            CoreUI.Wrapper.Config.Shutdown();
            CoreUI.DataTypes.Log.Debug("Shutting down Eina");
            CoreUI.DataTypes.Config.Shutdown();
        }
    }
}

// Placeholder. Will move to elm_config.cs later
namespace UI
{

/// <summary>Initialization and shutdown of the UI libraries.
/// </summary>
/// <since_tizen> 6 </since_tizen>
public static class Config
{
    /// <summary>
    /// Initialize the configuration of Elm.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
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


        // TIZEN_ONLY(20190425) Use efl-sharp-theme.edj on CoreUISharp
        CoreUI.UI.Theme.GetDefault().AddOverlay("/usr/share/efl-sharp/efl-sharp-theme.edj");
        //

        CoreUI.UI.Win.ExitOnAllWindowsClosed = new CoreUI.DataTypes.Value(0);
    }

    /// <summary>
    ///   Shutdown Elm systems.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Shutdown()
    {
        elm_shutdown();
    }

    /// <summary>
    ///   Run Elm system.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Run()
    {
        elm_run();
    }

    /// <summary>
    ///   Exit Elm.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public static void Exit()
    {
        elm_exit();
    }
}

}

}
