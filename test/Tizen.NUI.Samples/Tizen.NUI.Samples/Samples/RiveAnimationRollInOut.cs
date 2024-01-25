using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveAnimationRollInOut : IExample
    {
        private Window window;
        private Layer defaultLayer;
        Tizen.NUI.Extension.RiveAnimationView rav;
        Button playButton;
        bool preIn, isIn;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();
            window.TouchEvent += OnRiveWindowTouchEvent;

            // Load RiveAnimation File
            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/teeny_tiny_file.riv")
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

            if (lp.X > 100 && lp.Y > 100 && lp.X < 620 && lp.Y < 620)
            {
                isIn = true;
            }
            else
            {
                isIn = false;
            }

            if (preIn != isIn)
            {
               preIn = isIn;
               if (preIn)
               {
                 // Change Animation State When the cursor is in the bounds
                 rav.EnableAnimation("rollover_in", true);
                 rav.EnableAnimation("rollover_out", false);
               }
               else
               {
                 // Change Animation State When the cursor is out of the bounds
                 rav.EnableAnimation("rollover_in", false);
                 rav.EnableAnimation("rollover_out", true);
               }
            }
        }
        public void Deactivate()
        {
            window.TouchEvent -= OnRiveWindowTouchEvent;
            if (rav) { defaultLayer.Remove(rav); }
            if (playButton) { defaultLayer.Remove(playButton); }
        }
    }
}
