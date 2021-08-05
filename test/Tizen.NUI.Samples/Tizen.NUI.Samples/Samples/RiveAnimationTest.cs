using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveAnimationTest : IExample
    {
        private Window window;
        private Layer defaultLayer;

        RiveAnimationView rav;
        Button playButton, stopButton;
        Button bounceButton, brokeButton;
        Button fillButton, strokeButton, opacityButton;
        Button scaleButton, rotationButton, positionButton;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();

            rav = new RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/buggy.riv")
            {
                Size = new Size(500, 500),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            rav.EnableAnimation("idle", true);

            playButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 0),
                Text = "Play"
            };
            playButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.Play();
            };

            stopButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 0),
                Text = "Stop"
            };
            stopButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.Stop();
            };

            bounceButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 100),
                Text = "Bounce"
            };
            bounceButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.EnableAnimation("bouncing", true);
            };

            brokeButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 100),
                Text = "Broken"
            };
            brokeButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.EnableAnimation("broken", true);
            };

            fillButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 200),
                Text = "Fill"
            };
            fillButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetShapeFillColor("grillFillColor", new Color(1.0f, 0.0f, 0.0f, 1.0f));
            };

            strokeButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 200),
                Text = "Stroke"
            };
            strokeButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetShapeStrokeColor("grillStrokeColor", new Color(0.0f, 255.0f, 0.0f, 255.0f));
            };

            opacityButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(400, 200),
                Text = "Opacity"
            };
            opacityButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetNodeOpacity("front_light", 0.3f);
            };

            scaleButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 300),
                Text = "Scale"
            };
            scaleButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetNodeScale("front_light", new Vector2(2.0f, 2.0f));
            };

            rotationButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 300),
                Text = "Rotation"
            };
            rotationButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetNodeRotation("front_light", new Degree(45.0f));
            };

            positionButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(400, 300),
                Text = "Position"
            };
            positionButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.SetNodePosition("front_light", new Position(100.0f, -50.0f));
            };

            defaultLayer.Add(rav);
            defaultLayer.Add(playButton);
            defaultLayer.Add(stopButton);
            defaultLayer.Add(bounceButton);
            defaultLayer.Add(brokeButton);
            defaultLayer.Add(fillButton);
            defaultLayer.Add(strokeButton);
            defaultLayer.Add(opacityButton);
            defaultLayer.Add(scaleButton);
            defaultLayer.Add(rotationButton);
            defaultLayer.Add(positionButton);
        }
        public void Deactivate()
        {
            defaultLayer.Remove(rav);
            defaultLayer.Remove(playButton);
            defaultLayer.Remove(stopButton);
            defaultLayer.Remove(bounceButton);
            defaultLayer.Remove(brokeButton);
            defaultLayer.Remove(fillButton);
            defaultLayer.Remove(strokeButton);
            defaultLayer.Remove(opacityButton);
            defaultLayer.Remove(scaleButton);
            defaultLayer.Remove(rotationButton);
            defaultLayer.Remove(positionButton);
        }
    }
}
