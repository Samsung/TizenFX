
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class CulledTest : IExample
    {
        const string tag = "NUITEST";
        private Window win;
        private TextLabel text, textStatus;
        private Timer timer;

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.KeyEvent += OnKeyEvent;
            win.BackgroundColor = Color.Green;

            text = new TextLabel("Culled Test");
            text.TextColor = Color.Blue;
            text.PointSize = 12.0f;
            text.BackgroundColor = Color.Yellow;
            text.Size = new Size(200, 100, 0);
            text.Position = new Position(100, 100, 0);
            win.Add(text);

            Animation animation = new Animation(6000);
            animation.AnimateTo(text, "Position", new Position(2000, 1500, 0), 0, 3000);
            animation.AnimateTo(text, "Position", new Position(100, 100, 0), 3000, 6000);
            animation.Looping = true;
            animation.Play();

            textStatus = new TextLabel();
            textStatus.PointSize = 12.0f;
            textStatus.BackgroundColor = Color.Cyan;
            textStatus.Size = new Size(200, 100, 0);
            textStatus.Position = new Position(0, 0, 0);
            win.Add(textStatus);

            timer = new Timer(300);
            timer.Tick += onTick;
            timer.Start();
            tlog.Debug(tag, $"timer start!");
        }

        private bool onTick(object o, Timer.TickEventArgs e)
        {
            textStatus.Text = $"Culled={text.Culled}";
            tlog.Debug(tag, $"text.Culled={text.Culled}");
            return true;
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if(e.Key.State == Key.StateType.Down)
            {
                if(e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "BackSpace")
                {
                    // Do Something later
                }

            }
        }

        public void Deactivate()
        {
            timer.Stop();
            timer.Dispose();

            text.Unparent();
            textStatus.Unparent();
            text.Dispose();
            textStatus.Dispose();
        }
    }
}
