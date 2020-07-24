
using System;
using Tizen.NUI.BaseComponents;
using NUnit.Framework;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class DimTest : IExample
    {
        const string tag = "NUITEST";

        Window win;
        DimmableView dimView;

        class DimmableView : View
        {
            private View content;
            private bool dimmed;
            private View overlay;

            public DimmableView()
            {
                overlay = new View();
                overlay.BackgroundColor = Color.Black;
                overlay.Opacity = 0.0f;
                overlay.HeightResizePolicy = ResizePolicyType.FillToParent;
                overlay.WidthResizePolicy = ResizePolicyType.FillToParent;
                this.Add(overlay);
            }

            public View Content
            {
                get
                {
                    return content;
                }
                set
                {
                    if (content) Remove(content);
                    Add(value);
                    Remove(overlay);
                    Add(overlay);
                }
            }

            public bool Dimmed
            {
                get { return dimmed; }
                set
                {
                    if (value)
                    {
                        overlay.Opacity = 0.5f;
                    }
                    else
                    {
                        overlay.Opacity = 0.0f;
                    }
                }
            }
        }

        View filter;
        public void Activate()
        {

            Assert.IsFalse(true, "TDD test, Exception throw");

            win = Window.Instance;
            win.BackgroundColor = Color.Green;
            win.KeyEvent += Window_KeyEvent;
            win.WheelEvent += Win_WheelEvent;

            dimView = new DimmableView();
            dimView.PositionUsesPivotPoint = true;
            dimView.ParentOrigin = ParentOrigin.Center;
            dimView.PivotPoint = PivotPoint.Center;
            dimView.Size = new Size(150, 300);
            win.Add(dimView);

            var child1 = new TextLabel();
            child1.Position = new Position(10, 10);
            child1.Size = new Size(100, 100);
            child1.BackgroundColor = Color.Blue;
            child1.Text = "child1";
            child1.PointSize = 9;
            child1.TouchEvent += Child1_TouchEvent;
            dimView.Content = child1;

            var child2 = new TextLabel();
            child2.Position = new Position(100, 100);
            child2.Size = new Size(100, 200);
            child2.BackgroundColor = Color.Yellow;
            child2.Text = "child2";
            child2.PointSize = 8;
            dimView.Content = child2;
            child2.WheelEvent += Child2_DetentEvent;
            child2.WheelEvent += Child2_DetentEvent2;

            filter = new View();
            filter.Position = new Position(50, 50);
            filter.Size = new Size(300, 300);
            filter.BackgroundColor = Color.Red;
            filter.Opacity = 0;
            filter.WheelEvent += Filter_WheelEvent;
            win.Add(filter);
        }

        private bool Child2_DetentEvent(object sender, View.WheelEventArgs e)
        {
            tlog.Fatal(tag, $"Child2_DetentEvent() direction={e.Wheel.Direction} timestamp={e.Wheel.TimeStamp}");
            if (sender is TextLabel)
            {
                var me = sender as TextLabel;
                if (e.Wheel.Direction == 1)
                {
                    me.PositionX += 10;
                }
                else if (e.Wheel.Direction == -1)
                {
                    me.PositionX -= 10;
                }
            }
            return true;
        }

        private bool Child2_DetentEvent2(object sender, View.WheelEventArgs e)
        {
            tlog.Fatal(tag, $"Child2_DetentEvent2() direction={e.Wheel.Direction} timestamp={e.Wheel.TimeStamp}");
            if (sender is TextLabel)
            {
                var me = sender as TextLabel;
                me.Text = "child2 pos x=" + me.PositionX;
                me.MultiLine = true;
            }
            return true;
        }

        private bool Child1_TouchEvent(object source, View.TouchEventArgs e)
        {
            tlog.Fatal(tag, $"Child1_TouchEvent()");
            return false;
        }

        private void Win_WheelEvent(object sender, Window.WheelEventArgs e)
        {
            tlog.Fatal(tag, $"Win_WheelEvent()");

            if (e.Wheel.Type == Wheel.WheelType.CustomWheel)
            {
                tlog.Fatal(tag, $"z: {e.Wheel.Z}");
            }
        }

        private bool Filter_WheelEvent(object source, View.WheelEventArgs e)
        {
            tlog.Fatal(tag, $"Filter_WheelEvent()");

            if (e.Wheel.Type == Wheel.WheelType.CustomWheel)
            {
                tlog.Fatal(tag, $"z: {e.Wheel.Z}");
            }
            return true;
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                tlog.Fatal(tag, $"Window_KeyEvent() key:{e.Key.KeyPressedName}");
                switch (e.Key.KeyPressedName)
                {
                    case "1":
                        dimView.Dimmed = true;
                        break;
                    case "2":
                        dimView.Dimmed = false;
                        break;
                    case "3":
                        filter.RaiseToTop();
                        break;
                    case "4":
                        filter.LowerToBottom();
                        break;
                    case "5":
                        filter.Opacity = 0;
                        break;
                    case "6":
                        filter.Opacity = 0.5f;
                        break;
                    case "7":
                        filter.Opacity = 1;
                        break;
                }
            }
        }

        public void Deactivate()
        {
            dimView.Unparent();
        }
    }
}