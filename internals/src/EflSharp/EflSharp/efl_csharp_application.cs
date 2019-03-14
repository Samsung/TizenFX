using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Efl.UnsafeNativeMethods;

static class UnsafeNativeMethods {
    [DllImport(efl.Libs.Ecore)] public static extern void ecore_init();
    [DllImport(efl.Libs.Ecore)] public static extern void ecore_shutdown();
    [DllImport(efl.Libs.Elementary)] public static extern int elm_init(int argc, IntPtr argv);
    [DllImport(efl.Libs.Elementary)] public static extern void elm_policy_set(int policy, int policy_detail);
    [DllImport(efl.Libs.Elementary)] public static extern void elm_shutdown();
    [DllImport(efl.Libs.Elementary)] public static extern void elm_exit();
}

namespace Efl {
  namespace Csharp {
    public enum Components {
        Basic,
        Ui,
    }
    /// <summary>
    /// This represents the entry point for the EFL framework
    /// You can use this class to implement the 4 abstract methods which will then be called accordingly
    /// All subsystems of efl are booted up correctly when the abstract methods of this class are called.
    /// </summary>
    /// <remarks>
    /// Calls to efl outside those efl-callbacks or outside the mainloop are not allowed and will lead to issues
    /// </remarks>
    /// <example>
    /// UserApp is the class that implements the Application abstract
    /// <code>
    /// public static void Main() {
    ///   UserApp editor = new UserApp();
    ///   editor.Launch(editor);
    /// }
    /// </code>
    /// </example>
    public abstract class Application {
      //the initializied components
      private static Components initComponent;
      //what follows are 3 private functions to boot up the internals of efl
      private static void Init(Efl.Csharp.Components component) {
        Eina.Config.Init();
        Efl.Eo.Config.Init();
        ecore_init();
        evas_init();
        eldbus.Config.Init();

        if (component == Components.Ui) {
          // TODO Support elm command line arguments
#if WIN32 // Not a native define, we define it in our build system
          // Ecore_Win32 uses OleInitialize, which requires single thread apartments
          if (System.Threading.Thread.CurrentThread.GetApartmentState() != ApartmentState.STA)
              throw new InvalidOperationException("UI Applications require STAThreadAttribute in Main()");
#endif
          elm_init(0, IntPtr.Zero);

          elm_policy_set((int)Elm.Policy.Quit, (int)Elm.PolicyQuit.LastWindowHidden);
        }
        initComponent = component;
      }
      private static void Shutdown() {
        // Try to cleanup everything before actually shutting down.
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();

        if (initComponent == Components.Ui) {
          elm_shutdown();
        }
        eldbus.Config.Shutdown();
        evas_shutdown();
        ecore_shutdown();
        Efl.Eo.Config.Shutdown();
        Eina.Config.Shutdown();
      }
      /// <summary>
      /// Called when the application is started. Arguments from the command line are passed here.
      /// </summary>
      protected abstract void OnInitialize(Eina.Array<System.String> args);
      /// <summary>
      /// Arguments are passed here, Additional calls to this function may occure,
      /// but then the initialization flag is set to false.
      /// </summary>
      /// <remarks>
      /// When Initialize is true then OnInitialize is also called
      /// </remarks>
      protected virtual void OnArguments(Efl.LoopArguments args) { }
      /// <summary>
      /// Called when the application is not going to be displayed, or is not used by a user for some time.
      /// </summary>
      protected virtual void OnPause() { }
      /// <summary>
      /// Called before an application is used again after a call to OnPause().
      /// </summary>
      protected virtual void OnResume() { }
      /// <summary>
      /// Called before starting the shutdown of the application.
      /// </summary>
      protected virtual void OnTerminate() { }
      /// <summary>
      /// This function initializices everything in EFL and runs your application.
      /// This call will result in a call to OnInitialize(), which you application should override.
      /// </summary>
      public void Launch(Efl.Csharp.Components components=Components.Ui) {
        Init(components);
        Efl.App app = Efl.App.AppMain;
        Eina.Array<String> command_line = new Eina.Array<String>();
        command_line.Append(Environment.GetCommandLineArgs());
        app.SetCommandArray(command_line);
        app.ArgumentsEvt += (object sender, LoopArgumentsEvt_Args evt) => {
          if (evt.arg.Initialization) {
            OnInitialize(evt.arg.Argv);
          }
          OnArguments(evt.arg);
        };
        app.PauseEvt += (object sender, EventArgs e) => {
          OnPause();
        };
        app.ResumeEvt += (object sender, EventArgs e) => {
          OnResume();
        };
        app.TerminateEvt += (object sender, EventArgs e) => {
          OnTerminate();
        };
        app.Begin();
        Shutdown();
      }
    }
  }
}


