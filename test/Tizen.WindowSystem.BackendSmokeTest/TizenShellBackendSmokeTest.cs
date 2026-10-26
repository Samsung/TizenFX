using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using WindowSystemShell = Tizen.WindowSystem.Shell.TizenShell;
using NuiShell = Tizen.NUI.WindowSystem.Shell.TizenShell;

namespace Tizen.WindowSystem.BackendSmokeTest
{
    class TizenShellBackendSmokeTest : NUIApplication
    {
        const string LogTag = "TzShellBackendTest";

        protected override void OnCreate()
        {
            base.OnCreate();

            Window window = NUIApplication.GetDefaultWindow();
            List<string> results = RunSmokeTests(window);

            window.BackgroundColor = Color.White;

            TextLabel summary = new TextLabel(string.Join("\n", results))
            {
                MultiLine = true,
                PointSize = 16.0f,
                TextColor = Color.Black,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            window.Add(summary);
        }

        static List<string> RunSmokeTests(Window window)
        {
            List<string> results = new List<string>();

#if BUILD_TCORE_ENABLE
            RunCreateTest(results, "WindowSystem configured backend (tcore Wayland)", () => new WindowSystemShell());
            RunCreateTest(results, "NUI.WindowSystem configured backend (tcore Wayland)", () => new NuiShell());
#else
            RunCreateTest(results, "WindowSystem configured backend (EFL)", () => new WindowSystemShell());
            RunCreateTest(results, "NUI.WindowSystem configured backend (EFL)", () => new NuiShell());
#endif

            RunActionTest(results, "WindowSystem QuickPanelClient window interop", () =>
            {
                using (WindowSystemShell shell = new WindowSystemShell())
                using (Tizen.WindowSystem.Shell.QuickPanelClient client = new Tizen.WindowSystem.Shell.QuickPanelClient(
                    shell, (Tizen.Common.IWindowProvider)window, Tizen.WindowSystem.Shell.QuickPanelCategory.SystemDefault))
                {
                }
            });

            RunActionTest(results, "NUI.WindowSystem QuickPanelClient window interop", () =>
            {
                using (NuiShell shell = new NuiShell())
                using (Tizen.NUI.WindowSystem.Shell.QuickPanelClient client = new Tizen.NUI.WindowSystem.Shell.QuickPanelClient(
                    shell, (Tizen.Common.IWindowProvider)window, Tizen.NUI.WindowSystem.Shell.QuickPanelClient.Types.SystemDefault))
                {
                }
            });

            RunActionTest(results, "NUI.WindowSystem QuickPanelClient Window overload", () =>
            {
                using (NuiShell shell = new NuiShell())
                using (Tizen.NUI.WindowSystem.Shell.QuickPanelClient client = new Tizen.NUI.WindowSystem.Shell.QuickPanelClient(
                    shell, window, Tizen.NUI.WindowSystem.Shell.QuickPanelClient.Types.SystemDefault))
                {
                }
            });

            return results;
        }

        static void RunActionTest(List<string> results, string name, Action action)
        {
            try
            {
                action();
                AddResult(results, $"PASS  {name}: created and disposed");
            }
            catch (Exception exception)
            {
                AddResult(results, $"FAIL  {name}: {exception.GetType().Name}: {exception.Message}");
            }
        }

        static void RunCreateTest(List<string> results, string name, Func<IDisposable> create)
        {
            try
            {
                using (IDisposable shell = create())
                {
                }

                AddResult(results, $"PASS  {name}: created and disposed");
            }
            catch (Exception exception)
            {
                AddResult(results, $"FAIL  {name}: {exception.GetType().Name}: {exception.Message}");
            }
        }

        static void AddResult(List<string> results, string result)
        {
            results.Add(result);
            Tizen.Log.Debug(LogTag, result);
        }

        static void Main(string[] args)
        {
            new TizenShellBackendSmokeTest().Run(args);
        }
    }
}
