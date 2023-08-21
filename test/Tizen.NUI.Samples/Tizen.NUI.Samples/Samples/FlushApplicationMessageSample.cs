using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Threading;

namespace Tizen.NUI.Samples
{
    public class FlushApplicationMessageSample : IExample
    {
        private View root;
        private TextLabel textLabel;
        private NUIApplication application;

        public void SetCurrentApplication(Tizen.NUI.NUIApplication application)
        {
            Tizen.Log.Error("NUITEST", $"SetCurrentApplication {application}\n");
            this.application = application;
        }

        public Tizen.NUI.NUIApplication GetCurrentApplication()
        {
            Tizen.Log.Error("NUITEST", $"GetCurrentApplication {application}\n");
            return application;
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = window.Size,
                BackgroundColor = new Color(0.8f, 0.8f, 0.8f, 0.6f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };
            window.Add(root);

            textLabel = new TextLabel()
            {
                Text = "SceneOn",
            };

            root.Add(textLabel);
            Tizen.Log.Error("NUITEST", "SceneOn\n");

            textLabel.Text = "Sleep 5 seconds";

            GetCurrentApplication()?.FlushUpdateMessages();
            Tizen.Log.Error("NUITEST", "FlushUpdateMessages\n");

            Tizen.Log.Error("NUITEST", "Sleep 5 seconds\n");
            Thread.Sleep(5000); /// sleep 5 seconds
            Tizen.Log.Error("NUITEST", "Sleep done\n");

            textLabel.Text = "Sleep done!\n";
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
