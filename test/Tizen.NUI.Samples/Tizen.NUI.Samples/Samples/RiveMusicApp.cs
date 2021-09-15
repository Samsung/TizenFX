using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveMusicApp : IExample
    {
        private Window window;
        private Layer defaultLayer;

        Tizen.NUI.Extension.RiveAnimationView rav;
        Button playButton, stopButton;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();

            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/music.riv")
            {
                Size = new Size(500, 500),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            rav.Play();

            playButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 0),
                Text = "Start Music"
            };
            playButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.EnableAnimation("Loop", true);
                rav.EnableAnimation("Start", true);
                rav.EnableAnimation("Stop", false);
            };

            stopButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 0),
                Text = "Stop Music"
            };
            stopButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                rav.EnableAnimation("Loop", false);
                rav.EnableAnimation("Start", false);
                rav.EnableAnimation("Stop", true);
            };

            defaultLayer.Add(rav);
            defaultLayer.Add(playButton);
            defaultLayer.Add(stopButton);
        }
        public void Deactivate()
        {
            defaultLayer.Remove(rav);
            defaultLayer.Remove(playButton);
            defaultLayer.Remove(stopButton);
        }
    }
}
