
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
  public class EventPropagationSample : IExample
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

    public View TargetView;
    TapGestureDetector tap;

    public void Activate()
    {
      Window window = NUIApplication.GetDefaultWindow();
      TargetView = new View()
      {
        WidthResizePolicy = ResizePolicyType.FillToParent,
        HeightResizePolicy = ResizePolicyType.FillToParent,
        Layout = new LinearLayout()
        {
            LinearOrientation = LinearLayout.Orientation.Vertical,
        },
      };
      window.Add(TargetView);

      var log = new LogOutput();

      TargetView.TouchEvent += (s, e) =>
      {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
              log.AddLog($"TouchEvent on Layout");
          }
          return false;
      };

      var margin = new View
      {
          SizeHeight = 50,
          WidthResizePolicy = ResizePolicyType.FillToParent
      };
      TargetView.Add(margin);
      var container = new View
      {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          SizeHeight = 400,
          BackgroundColor = Color.Gray,
          Layout = new AbsoluteLayout(),
      };
      container.TouchEvent += (s, e) =>
      {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
              log.AddLog($"TouchEvent on Gray");
          }
          return false;
      };
      TargetView.Add(container);

      var layer = new Layer();
      window.AddLayer(layer);
      var overlayContainer = new View
      {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          SizeHeight = 150,
          BackgroundColor = Color.Red,
          Layout = new AbsoluteLayout(),
      };

      overlayContainer.HitTestResult += (s, e) =>
      {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
            log.AddLog($"HitTestResult");
          }
          return false;
      };

      overlayContainer.TouchEvent += (s, e) =>
      {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
              log.AddLog($"TouchEvent on Red");
          }
          return false;
      };

      var overlayContainer2 = new View
      {
          WidthResizePolicy = ResizePolicyType.FillToParent,
          SizeHeight = 200,
          BackgroundColor = Color.Yellow,
          Layout = new AbsoluteLayout(),
      };
      tap = new TapGestureDetector();
      tap.Detected += (s, e) =>
      {
          if (e.TapGesture.State == Gesture.StateType.Started)
          {
              log.AddLog($"Gesture Detected on Yellow");
          }
      };
      tap.Attach(overlayContainer2);

      overlayContainer2.TouchEvent += (s, e) =>
      {
          if (e.Touch.GetState(0) == PointStateType.Down)
          {
              log.AddLog($"TouchEvent on Yellow");
          }
          return false;
      };

      layer.Add(overlayContainer);
      layer.Add(overlayContainer2);
      overlayContainer2.Position = new Position(0, 150);

      TargetView.RemovedFromWindow += (s, e) =>
      {
          window.RemoveLayer(layer);
      };

      TargetView.Add(log);
    }

    public void Deactivate()
    {
    }


  }
}
