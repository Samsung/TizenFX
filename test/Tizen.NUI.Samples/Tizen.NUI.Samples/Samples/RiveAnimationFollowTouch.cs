using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveAnimationFollowTouch : IExample
    {
        private Window window;
        private Layer defaultLayer;

        Tizen.NUI.Extension.RiveAnimationView rav;
        Button playButton, stopButton;
        Button bounceButton, brokeButton;
        Button fillButton, strokeButton, opacityButton;
        Button scaleButton, rotationButton, positionButton;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();
            window.TouchEvent += OnRiveWindowTouchEvent;

            // Load RiveAnimation File
            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/flame-and-spark.riv")
            {
                Size = new Size(720, 720),
            };

            // Enable RiveAnimation and Play
            rav.EnableAnimation("idle", true);
            rav.Play();

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

            defaultLayer.Add(rav);
            defaultLayer.Add(playButton);
        }

         private void OnRiveWindowTouchEvent(object source, Window.TouchEventArgs e)
        {
            Vector2 lp = e.Touch.GetLocalPosition(0);
            Vector2 sp = e.Touch.GetScreenPosition(0);
            float scale = (1000.0f /720.0f);

            // Set root and spark node position
            rav.SetNodePosition("root", new Position(lp.X * scale, lp.Y * scale));
            rav.SetNodePosition("spark", new Position((lp.X - 288) * scale, lp.Y) * scale);
        }
        public void Deactivate()
        {
            defaultLayer.Remove(rav);
            defaultLayer.Remove(playButton);
        }
    }
}
