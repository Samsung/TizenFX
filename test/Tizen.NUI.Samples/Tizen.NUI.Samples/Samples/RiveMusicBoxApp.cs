using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveMusicBoxApp : IExample
    {
        private Window window;
        private Layer defaultLayer;

        Tizen.NUI.Extension.RiveAnimationView rav;
        Button playButton, stopButton;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();

            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/musicbox.riv")
            {
                Size = new Size(720, 720),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
            };

            rav.EnableAnimation("Loop", true);
            rav.Play();

            playButton = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(0, 0),
                Text = "Start"
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
