
using global::System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using l = Tizen.Log;

    public class VisibilityChangedTest : IExample
    {
        Window win, subWin;
        View dummy1, dummy2;
        View subDummy1, subDummy2;
        Timer t1, t2, t3, t4, t5, t6;
        const string t = "NUITEST";
        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = Color.Green;
            win.VisibilityChanged += Win_VisibilityChanged;

            dummy1 = new View();
            dummy1.Size = new Size(200, 200);
            dummy1.Position = new Position(10, 10);
            dummy1.BackgroundColor = Color.Red;
            dummy1.Name = "dummy1";
            dummy1.VisibilityChanged += View_VisibilityChanged;
            win.Add(dummy1);

            dummy2 = new View();
            dummy2.Size = new Size(100, 100);
            dummy2.Position = new Position(10, 10);
            dummy2.BackgroundColor = Color.Purple;
            dummy2.Name = "dummy2";
            dummy2.VisibilityChanged += View_VisibilityChanged;
            dummy1.Add(dummy2);

            subWin = new Window();
            subWin.BackgroundColor = Color.Yellow;
            subWin.WindowSize = new Size2D(500, 500);
            subWin.WindowPosition = new Position2D(100, 200);
            subWin.VisibilityChanged += SubWin_VisibilityChanged;

            subDummy1 = new View();
            subDummy1.Size = new Size(200, 200);
            subDummy1.Position = new Position(10, 10);
            subDummy1.BackgroundColor = Color.Blue;
            subDummy1.Name = "subDummy1";
            subDummy1.VisibilityChanged += View_VisibilityChanged;
            subWin.Add(subDummy1);

            subDummy2 = new View();
            subDummy2.Size = new Size(100, 100);
            subDummy2.Position = new Position(10, 10);
            subDummy2.BackgroundColor = Color.Crimson;
            subDummy2.Name = "subDummy2";
            subDummy2.VisibilityChanged += View_VisibilityChanged;
            subDummy1.Add(subDummy2);

            cnt1 = cnt2 = cnt3 = cnt4 = cnt5 = cnt6 = 0;

            t1 = new Timer(1300);
            t1.Tick += T1_Tick;
            t1.Start();

            t2 = new Timer(1700);
            t2.Tick += T2_Tick;
            t2.Start();

            t3 = new Timer(2100);
            t3.Tick += T3_Tick;
            t3.Start();

            t4 = new Timer(2500);
            t4.Tick += T4_Tick;
            t4.Start();

            t5 = new Timer(2900);
            t5.Tick += T5_Tick;
            t5.Start();

            t6 = new Timer(3100);
            t6.Tick += T6_Tick;
            t6.Start();
        }

        int cnt1, cnt2, cnt3, cnt4, cnt5, cnt6;
        private bool T1_Tick(object source, Timer.TickEventArgs e)
        {
            l.Debug(t, $"T1_Tick. {dummy1.Name} visibility change started");
            if (++cnt1 %2 == 0)
            {
                dummy1.Show();
            }
            else
            {
                dummy1.Hide();
            }
            l.Debug(t, $"T1_Tick. {dummy1.Name} visibility change finished");
            return true;
        }
        private bool T2_Tick(object source, Timer.TickEventArgs e)
        {
            l.Debug(t, $"T2_Tick. {dummy2.Name} visibility change started");
            if (++cnt2 %2 == 0)
            {
                dummy2.Show();
            }
            else
            {
                dummy2.Hide();
            }
            l.Debug(t, $"T2_Tick. {dummy2.Name} visibility change finished");
            return true;
        }
        private bool T3_Tick(object source, Timer.TickEventArgs e)
        {
            l.Debug(t, $"T3_Tick. {subDummy1.Name} visibility change started");
            if (++cnt3 %2 == 0)
            {
                subDummy1.Show();
            }
            else
            {
                subDummy1.Hide();
            }
            l.Debug(t, $"T3_Tick. {subDummy1.Name} visibility change finished");
            return true;
        }
        private bool T4_Tick(object source, Timer.TickEventArgs e)
        {
            l.Debug(t, $"T4_Tick. {subDummy2.Name} visibility change started");
            if (++cnt4 %2 == 0)
            {
                subDummy2.Show();
            }
            else
            {
                subDummy2.Hide();
            }
            l.Debug(t, $"T4_Tick. {subDummy2.Name} visibility change finished");
            return true;
        }
        private bool T5_Tick(object source, Timer.TickEventArgs e)
        {
            l.Debug(t, $"T5_Tick. win visibility change started");
            if (++cnt5 %2 == 0)
            {
                win.Show();
            }
            else
            {
                win.Hide();
            }
            l.Debug(t, $"T5_Tick. win visibility change finished");
            return true;
        }
        private bool T6_Tick(object source, Timer.TickEventArgs e)
        {
            l.Debug(t, $"T5_Tick. subWin visibility change started");
            if (++cnt6 % 2 == 0)
            {
                subWin.Show();
            }
            else
            {
                subWin.Hide();
            }
            l.Debug(t, $"T5_Tick. subWin visibility change finished");
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

        private void View_VisibilityChanged(object sender, View.VisibilityChangedEventArgs e)
        {
            View self = sender as View;
            l.Debug(t, $"{self.Name} visibility changed! e.View.Name={e.View.Name} e.Visibility={e.Visibility} e.Type={e.Type}");
        }

        public void Deactivate()
        {
            t1?.Stop();
            t2?.Stop();
            t3?.Stop();
            t4?.Stop();
            t5?.Stop();
            t6?.Stop();
            t1?.Dispose();
            t2?.Dispose();
            t3?.Dispose();
            t4?.Dispose();
            t5?.Dispose();
            t6?.Dispose();
            t1 = t2 = t3 = t4 = t5 = t6 = null;

            dummy1.VisibilityChanged -= View_VisibilityChanged;
            dummy2.VisibilityChanged -= View_VisibilityChanged;

            subDummy1.VisibilityChanged -= View_VisibilityChanged;
            subDummy2.VisibilityChanged -= View_VisibilityChanged;

            dummy1.Dispose();
            dummy2.Dispose();
            subDummy1.Dispose();
            subDummy2.Dispose();

            win.VisibilityChanged -= Win_VisibilityChanged;
            subWin.VisibilityChanged -= SubWin_VisibilityChanged;

            subWin.Hide();
            subWin.Dispose();
            win.Show();
        }
    }
}
