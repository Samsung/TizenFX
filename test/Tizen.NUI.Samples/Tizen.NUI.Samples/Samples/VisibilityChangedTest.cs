
using global::System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using l = Tizen.Log;

    public class VisibilityChangedTest : IExample
    {
        Window win, subWin;
        Timer t1, t2;
        const string t = "NUITEST";
        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = Color.Green;
            win.VisibilityChanged += Win_VisibilityChanged;

            var dummy = new View();
            dummy.Size = new Size(200, 200);
            dummy.Position = new Position(10, 10);
            dummy.BackgroundColor = Color.Red;
            win.Add(dummy);

            subWin = new Window();
            subWin.BackgroundColor = Color.Yellow;
            subWin.WindowSize = new Size2D(500, 500);
            subWin.WindowPosition = new Position2D(100, 200);
            subWin.VisibilityChanged += SubWin_VisibilityChanged;

            var dum2 = new View();
            dum2.Size = new Size(200, 200);
            dum2.Position = new Position(10, 10);
            dum2.BackgroundColor = Color.Blue;
            subWin.Add(dum2);

            t1 = new Timer(1300);
            t1.Tick += T1_Tick;
            t1.Start();

            t2 = new Timer(1700);
            t2.Tick += T2_Tick;
            t2.Start();
        }

        int cnt;
        private bool T2_Tick(object source, Timer.TickEventArgs e)
        {
            if(cnt++ %2 == 0)
            {
                win.Show();
            }else
            {
                win.Hide();
            }
            return true;
        }

        int cnt2;
        private bool T1_Tick(object source, Timer.TickEventArgs e)
        {
            if (cnt2++ % 2 == 0)
            {
                subWin.Show();
            }
            else
            {
                subWin.Hide();
            }
            return true;

        }

        private void SubWin_VisibilityChanged(object sender, Window.VisibilityChangedEventArgs e)
        {
            l.Debug(t, $"sub window visibility changed! e.Visibility={e.Visibility}");
        }

        private void Win_VisibilityChanged(object sender, Window.VisibilityChangedEventArgs e)
        {
            l.Debug(t, $"main window visibility changed! e.Visibility={e.Visibility}");
        }

        public void Deactivate()
        {
            t1.Stop();
            t2.Stop();
            t1.Dispose();
            t2.Dispose();
            t1 = t2 = null;
            
            win.VisibilityChanged -= Win_VisibilityChanged;
            subWin.VisibilityChanged -= SubWin_VisibilityChanged;

            subWin.Hide();
            win.Show();
        }
    }
}
