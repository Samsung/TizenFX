
using global::System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;

    public class WindowFrontBufferRenderingSample : IExample
    {
        const string tag = "NUITEST";
        private View view;
        private Window window;
        private TextLabel textlabel;
        private Animation animation;

        public void Activate()
        {
            WindowData newWindowData = new WindowData()
            {
                PositionSize = new Rectangle(0, 0, 600, 300),
                WindowMode = NUIApplication.WindowMode.Opaque,
                WindowType = WindowType.Normal,
                FrontBufferRendering = true,
            };

            bool result = false;
            result = newWindowData.FrontBufferRendering;
            log.Fatal(tag, $"Current Front Buffer Rendering: {result}\n");

            window = new Window("new Window", newWindowData);

            view = new View()
            {
                PositionUsesPivotPoint = true,
                PivotPoint = PivotPoint.Center,
                ParentOrigin = ParentOrigin.Center,
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Black,
            };

            textlabel = new TextLabel()
            {
                Text = $"Current Front Buffer Rendering: {result}\n",
                PointSize = 30.0f,
                TextColor = Color.Blue,
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };

            animation = new Animation(2000);
            animation.AnimateTo(textlabel, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 1000);
            animation.AnimateTo(textlabel, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 1000, 2000);
            animation.Looping = true;
            animation.Play();

            view.Add(textlabel);

            window.Add(view);
            window.Show();
        }

        public void Deactivate()
        {

        }
    }
}
