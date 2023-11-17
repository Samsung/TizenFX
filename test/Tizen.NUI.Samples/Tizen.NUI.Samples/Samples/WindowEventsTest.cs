﻿
using global::System;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    using log = Tizen.Log;

    public class WindowEventsTest : IExample
    {
        const string tag = "NUITEST";

        private Window childViewWindow;
        private View parent1;
        private View parent2;
        private View child;

        public void Activate()
        {
            parent1 = new View()
            {
                Size2D = new Size2D(500, 500),
                Position = new Position(100, 100),
                BackgroundColor = Color.Red,
                Focusable = true,
            };

            parent2 = new View()
            {
                Size2D = new Size2D(500, 500),
                Position = new Position(700, 100),
                BackgroundColor = Color.Blue,
                Focusable = true,
            };

            child = new View()
            {
                Size2D = new Size2D(250, 250),
                BackgroundColor = Color.White,
            };

            child.AddedToWindow += OnChildAddedToWindow;
            child.RemovedFromWindow += OnChildRemovedFromWindow;

            Window.Instance.GetDefaultLayer().Add(parent1);
            Window.Instance.GetDefaultLayer().Add(parent2);

            Window.Instance.OrientationChanged += OnWindowOrientationChangedEvent;

            parent1.LeftFocusableView = parent2;
            parent2.RightFocusableView = parent1;

            parent1.FocusGained += OnParentFocusGained;
            parent2.FocusGained += OnParentFocusGained;

            FocusManager.Instance.SetCurrentFocusView(parent1);
            Window.Instance.BackgroundColor = new Color(1.0f, 0.92f, 0.80f, 1.0f);

            Window.Instance.AddAvailableOrientation(Window.WindowOrientation.Portrait);
            Window.Instance.AddAvailableOrientation(Window.WindowOrientation.Landscape);
            Window.Instance.AddAvailableOrientation(Window.WindowOrientation.PortraitInverse);
            Window.Instance.AddAvailableOrientation(Window.WindowOrientation.LandscapeInverse);
        }

        private void OnWindowOrientationChangedEvent(object sender, WindowOrientationChangedEventArgs e)
        {
            Window.WindowOrientation orientation = e.WindowOrientation;
            log.Fatal(tag, $"OnWindowOrientationChangedEvent() called!, orientation:{orientation}");
        }

        private void OnParentFocusGained(object sender, EventArgs e)
        {
            child.Unparent();
            (sender as View).Add(child);
        }

        private void OnChildRemovedFromWindow(object sender, EventArgs e)
        {
            UnsetChildViewWindow();
        }

        private void OnChildAddedToWindow(object sender, EventArgs e)
        {
            UnsetChildViewWindow();
            SetChildViewWindow();
        }

        private void SetChildViewWindow()
        {
            childViewWindow = Window.Instance; // Window.Get(childView)?

            if (childViewWindow != null)
            {
                
                childViewWindow.AddAuxiliaryHint("wm.policy.win.msg.use", "1");
                childViewWindow.VisibilityChanged += OnChildViewWindowVisibilityChanged;
                childViewWindow.Resized += OnChildViewWindowResized;

                childViewWindow.FocusChanged += OnChildViewWindowFocusChanged;
                childViewWindow.TouchEvent += OnChildViewWindowTouchEvent;
                childViewWindow.WheelEvent += OnChildViewWindowWheelEvent;
                childViewWindow.KeyEvent += OnChildViewWindowKeyEvent;
                childViewWindow.TransitionEffect += OnChildViewWindowTransitionEffect;
                childViewWindow.KeyboardRepeatSettingsChanged += OnChildViewWindowKeyboardRepeatSettingsChanged;
                //childViewWindow.ViewAdded += OnChildViewWindowViewAdded; // Block this signal for temprary
                childViewWindow.AuxiliaryMessage += OnAuxiliaryMessageEvent;
            }
        }

        private void UnsetChildViewWindow()
        {
            if (childViewWindow != null)
            {
                childViewWindow.VisibilityChanged -= OnChildViewWindowVisibilityChanged;
                childViewWindow.Resized -= OnChildViewWindowResized;

                childViewWindow.FocusChanged -= OnChildViewWindowFocusChanged;
                childViewWindow.TouchEvent -= OnChildViewWindowTouchEvent;
                childViewWindow.WheelEvent -= OnChildViewWindowWheelEvent;
                childViewWindow.KeyEvent -= OnChildViewWindowKeyEvent;
                childViewWindow.TransitionEffect -= OnChildViewWindowTransitionEffect;
                childViewWindow.KeyboardRepeatSettingsChanged -= OnChildViewWindowKeyboardRepeatSettingsChanged;
                //childViewWindow.ViewAdded -= OnChildViewWindowViewAdded; // Block this signal for temprary
                childViewWindow.AuxiliaryMessage -= OnAuxiliaryMessageEvent;
                childViewWindow = null;
            }
        }

        private void OnChildViewWindowResized(object sender, Window.ResizedEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowResized() called!");
        }

        private void OnChildViewWindowVisibilityChanged(object sender, Window.VisibilityChangedEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowVisibilityChanged() called!");
        }

        private void OnChildViewWindowViewAdded(object sender, EventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowViewAdded() called!");
        }

        private void OnChildViewWindowKeyboardRepeatSettingsChanged(object sender, EventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowKeyboardRepeatSettingsChanged() called!");
        }

        private void OnChildViewWindowTransitionEffect(object sender, Window.TransitionEffectEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowTransitionEffect() called!");
        }

        private void OnChildViewWindowKeyEvent(object sender, Window.KeyEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowKeyEvent() called!");
        }

        private void OnChildViewWindowWheelEvent(object sender, Window.WheelEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowWheelEvent() called!");
        }

        private void OnChildViewWindowTouchEvent(object sender, Window.TouchEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowTouchEvent() called!");
        }

        private void OnChildViewWindowFocusChanged(object sender, Window.FocusChangedEventArgs e)
        {
            log.Fatal(tag, $"OnChildViewWindowFocusChanged() called!");
        }

        private void OnAuxiliaryMessageEvent(object sender, AuxiliaryMessageEventArgs e)
        {
            log.Fatal(tag, $"OnAuxiliaryMessageEvent() called!");
            if(e != null)
            {
                Console.WriteLine($"Key={e.Key} Value={e.Value}");
                log.Fatal(tag, $"Key={e.Key} Value={e.Value}");
                var cnt = 0;
                foreach(var option in e.Options)
                {
                    cnt++;
                    Console.WriteLine($"option[{cnt}]={option}");
                    log.Fatal(tag, $"option[{cnt}]={option}");
                }
            }
        }

        public void Deactivate()
        {
            if (child)
            {
                child.Unparent();
                child.Dispose();
            }

            if (parent1)
            {
                parent1.Unparent();
                parent1.Dispose();
            }
            if (parent2)
            {
                parent2.Unparent();
                parent2.Dispose();
            }
        }
    }
}
