
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
  public class HitTestResultSample : IExample
  {
    class LogOutput : ScrollableBase
    {
        public LogOutput()
        {
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            HideScrollbar = false;

            ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                VerticalAlignment = VerticalAlignment.Top,
            };
        }

        public void AddLog(string log)
        {
            Console.WriteLine($"{log}");
            var txt = new TextLabel
            {
                Text = log
            };

            ContentContainer.Add(txt);
            if (ContentContainer.Children.Count > 30)
            {
                var remove = ContentContainer.Children.GetRange(0, 10);
                foreach (var child in remove)
                {
                    ContentContainer.Remove(child);
                }
            }
            ElmSharp.EcoreMainloop.Post(() =>
            {
                ScrollTo((ContentContainer.Children.Count) * (txt.NaturalSize.Height), true);
            });
        }
        public override View GetNextFocusableView(View currentFocusedView, View.FocusDirection direction, bool loopEnabled)
        {
            return null;
        }
    }

    View rootView;
    bool hitTestResult = true;
    public void Activate()
    {
        var log = new LogOutput();
        Window window = NUIApplication.GetDefaultWindow();

        rootView = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            HeightResizePolicy = ResizePolicyType.FillToParent,
            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
            },
        };

        View container = new View()
        {
            WidthResizePolicy = ResizePolicyType.FillToParent,
            SizeHeight = 400,
            Layout = new AbsoluteLayout(),
        };

        View blueView = new View()
        {
            Size = new Size(200, 100),
            Position = new Position(75, 125),
            BackgroundColor = Color.Blue,
        };

        blueView.HitTestResult += (o, e) =>
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                if(hitTestResult == true)
                {
                    log.AddLog($"BlueView hittest hitted");
                }
                else
                {
                    log.AddLog($"BlueView hittest passed");
                }
            }
            // If false is returned, the hit-test is continued.
            // If true is returned, the current View is hit. Event propagation starts from the current View.
            return hitTestResult;
        };
        blueView.TouchEvent += (s, e) =>
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                log.AddLog($"TouchEvent on BlueView");
            }
            return false;
        };

        TapGestureDetector blueTap = new TapGestureDetector();
        blueTap.Detected += (s, e) =>
        {
            if (e.TapGesture.State == Gesture.StateType.Started)
            {
                log.AddLog($"Gesture Detected on blueView");
            }
        };
        blueTap.Attach(blueView);


        View greenView = new View()
        {
            Size = new Size(300, 200),
            Position = new Position(50, 100),
            BackgroundColor = Color.Green,
        };
        greenView.TouchEvent += (s, e) =>
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                log.AddLog($"TouchEvent on greenView");
            }
            return false;
        };

        TapGestureDetector greenTap = new TapGestureDetector();
        greenTap.Detected += (s, e) =>
        {
            if (e.TapGesture.State == Gesture.StateType.Started)
            {

                log.AddLog($"Gesture Detected on greenView");
            }
        };
        greenTap.Attach(greenView);



        Button hitTestPass = new Button()
        {
            Text = "Blue HitTest Pass",
        };
        hitTestPass.Clicked += (o, e) => {
            hitTestResult = false;
        };

        Button hitTestHit = new Button()
        {
            Text = "Blue HitTest Hit",
            Position = new Position(350, 0),
        };
        hitTestHit.Clicked += (o, e) => {
            hitTestResult = true;
        };

        container.Add(greenView);
        container.Add(blueView);
        container.Add(hitTestPass);
        container.Add(hitTestHit);

        rootView.Add(container);
        rootView.Add(log);
        window.Add(rootView);

    }

    public void Deactivate()
    {
        if (rootView != null)
        {
            NUIApplication.GetDefaultWindow().Remove(rootView);
            rootView.Dispose();
        }
    }


  }
}
