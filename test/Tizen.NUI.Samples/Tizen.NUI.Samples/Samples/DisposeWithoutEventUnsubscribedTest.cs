
using global::System;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class DisposeWithoutEventUnsubscribedTestAndAnimationDisposeTest : IExample
    {
        private const string tag = "NUITEST";
        private const int NUMBER_OF_VIEW = 1000;
        private const int INTERVAL_MS = 1000;
        private const int MIN_POSITION = 100;
        private const int MAX_POSITION = 900;
        private const bool TURN_ON_GC = true;

        private Window win;
        private View rootView;
        private int cnt;
        private List<View> list = new List<View>();
        private Random rand = new Random();
        private bool toggle, toggleRemoveMany;
        private string res;
        private Timer timer;

        public void Activate()
        {
            DisposeWithoutUnsubscribedEventTest();
            AnimationDisposeTest();
        }
        public void Deactivate()
        {
            DisposeManyObject();
            timer.Stop();
            timer.Dispose();
            rootView.Unparent();
            rootView.Dispose();
        }

        private void AnimationDisposeTest()
        {
            var ani = new Animation(1000);
            ani.AnimateTo(rootView, "size", new Size(500, 500, 0));
            ani.Dispose();
            try
            {
                ani.Play();
                tlog.Fatal(tag, "this should not be shown! test NG!");
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException)
                {
                    tlog.Fatal(tag, "Animation is used after disposed! test OK!");
                }
                else
                {
                    tlog.Fatal(tag, $"unwanted exception came! test NG! exception:{e} msg:{e.Message}");
                }
            }

            try
            {
                ani.Clear();
                tlog.Fatal(tag, "this should not be shown! test NG!");
            }
            catch (Exception e)
            {
                if (e is ObjectDisposedException)
                {
                    tlog.Fatal(tag, "Animation is used after disposed! test OK!");
                }
                else
                {
                    tlog.Fatal(tag, $"unwanted exception came! test NG! exception:{e} msg:{e.Message}");
                }
            }
        }

        private void DisposeWithoutUnsubscribedEventTest()
        {
            win = NUIApplication.GetDefaultWindow();

            res = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            rootView = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Blue,
            };
            rootView.Relayout += View_Relayout;
            win.Add(rootView);

            timer = new Timer(INTERVAL_MS);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void AddManyObject()
        {
            tlog.Fatal(tag, $"AddManyObject()");

            for (int i = 0; i < NUMBER_OF_VIEW; i++)
            {
                var child = new ImageView()
                {
                    ResourceUrl = res + "images/Dali/DaliDemo/application-icon-1.png",
                    Size = new Size(60, 60),
                    Position = new Position(rand.Next(MIN_POSITION, MAX_POSITION), rand.Next(MIN_POSITION, MAX_POSITION)),
                    BackgroundColor = new Color((float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), 1),
                };

                rootView.Add(child);
                child.Relayout += Child_Relayout;
                child.RemovedFromWindow += Child_RemovedFromWindow;
                child.AddedToWindow += Child_AddedToWindow;
                child.WheelEvent += Child_WheelEvent;
                child.HoverEvent += Child_HoverEvent;
                child.InterceptTouchEvent += Child_InterceptTouchEvent;
                child.TouchEvent += Child_TouchEvent;
                child.ResourcesLoaded += Child_ResourcesLoaded;
                child.KeyEvent += Child_KeyEvent;
                child.FocusLost += Child_FocusLost;
                child.FocusGained += Child_FocusGained;
            }
        }

        private void Child_FocusGained(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_FocusGained() called!");
            }
        }

        private void Child_FocusLost(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_FocusLost() called!");
            }
        }

        private bool Child_KeyEvent(object source, View.KeyEventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_KeyEvent() called!");
            }
            return true;
        }

        private void Child_ResourcesLoaded(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_ResourcesLoaded() called!");
            }
        }

        private bool Child_TouchEvent(object source, View.TouchEventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_TouchEvent() called!");
            }
            return true;
        }

        private bool Child_InterceptTouchEvent(object source, View.TouchEventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_InterceptTouchEvent() called!");
            }
            return true;
        }

        private bool Child_HoverEvent(object source, View.HoverEventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_HoverEvent() called!");
            }
            return true;
        }

        private bool Child_WheelEvent(object source, View.WheelEventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_WheelEvent() called!");
            }
            return true;
        }

        private void Child_AddedToWindow(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_AddedToWindow() called!");
            }
        }

        private void Child_RemovedFromWindow(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_RemovedFromWindow() called!");
            }
        }

        private void Child_Relayout(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"Child_Relayout() called!");
            }
        }

        private void View_Relayout(object sender, EventArgs e)
        {
            if (++cnt % (NUMBER_OF_VIEW * 3) == 1)
            {
                tlog.Fatal(tag, $"View_Relayout() called! cnt:{cnt}");
            }
        }

        private void RemoveManyObject()
        {
            int childCnt = (int)rootView.ChildCount;
            tlog.Fatal(tag, $"RemoveManyObject() child count:{childCnt}");

            for (int i = childCnt - 1; i >= 0; i--)
            {
                var child = rootView.GetChildAt((uint)i);
                rootView.Remove(child);
            }
        }
        private void DisposeManyObject()
        {
            int childCnt = (int)rootView.ChildCount;
            tlog.Fatal(tag, $"DisposeManyObject() child count:{childCnt}");

            for (int i = childCnt - 1; i >= 0; i--)
            {
                var child = rootView.GetChildAt((uint)i);
                rootView.Remove(child);
                child.Size += new Size(100, 100);
                child.Size -= new Size(100, 100);
                child.Size += new Size(100, 100);
                child.Size -= new Size(100, 100);
                child.Dispose();
            }
        }

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            toggle = !toggle;
            if (toggle)
            {
                AddManyObject();
            }
            else
            {
                toggleRemoveMany = !toggleRemoveMany;
                if (toggleRemoveMany)
                {
                    RemoveManyObject();
                }
                else
                {
                    DisposeManyObject();
                }
            }

            if (TURN_ON_GC)
            {
                FullGC();
            }
            return true;
        }

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

    }
}
