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

            List<string> results = RunSmokeTests();
            foreach (string result in results)
            {
                Tizen.Log.Debug(LogTag, result);
            }

            Window window = NUIApplication.GetDefaultWindow();
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

        static List<string> RunSmokeTests()
        {
            List<string> results = new List<string>();

#if BUILD_TCORE_ENABLE
            RunCreateTest(results, "WindowSystem configured backend (tcore Wayland)", () => new WindowSystemShell());
            RunCreateTest(results, "NUI.WindowSystem configured backend (tcore Wayland)", () => new NuiShell());
#else
            RunCreateTest(results, "WindowSystem configured backend (EFL)", () => new WindowSystemShell());
            RunCreateTest(results, "NUI.WindowSystem configured backend (EFL)", () => new NuiShell());
#endif

            return results;
        }

        static void RunCreateTest(List<string> results, string name, Func<IDisposable> create)
        {
            try
            {
                using (IDisposable shell = create())
                {
                }

                results.Add($"PASS  {name}: created and disposed");
            }
            catch (Exception exception)
            {
                results.Add($"FAIL  {name}: {exception.GetType().Name}: {exception.Message}");
            }
        }

        static void Main(string[] args)
        {
            new TizenShellBackendSmokeTest().Run(args);
        }
    }
}
