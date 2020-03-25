using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ControlSample : IExample
    {
        private View root;
        private Control control;

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

            control = new Control()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Blue,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                BoxShadow = new Shadow()
                {
                    Color = new Color(0.2f, 0.2f, 0.2f, 0.3f),
                    Offset = new Vector2(5, 5),
                },
                CornerRadius = 26f,
            };

            root.Add(control);
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
