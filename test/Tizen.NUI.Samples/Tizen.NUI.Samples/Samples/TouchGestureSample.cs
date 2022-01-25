using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class TouchGestureSample : IExample
    {
        private View root;
        private View frontView;
        private TextLabel backView;
        private TapGestureDetector tapGestureDetector;
        private LongPressGestureDetector longPressGestureDetector;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View();

            window.WheelEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"window WheelEvent!!!!{e.Wheel.Type}\n");
            };

            frontView = new View
            {
                Size = new Size(300, 300),
                Position = new Position(150, 170),
                BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f),
                Focusable = true,
                FocusableInTouch = true,
            };
            frontView.TouchEvent += OnFrontTouchEvent;
            frontView.WheelEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"frontView WheelEvent!!!!{e.Wheel.Type}\n");
                if (e.Wheel.Type == Wheel.WheelType.CustomWheel)
                {
                       // rotary event
                }
                else if (e.Wheel.Type == Wheel.WheelType.MouseWheel)
                {
                      // mouse wheel event
                }
                return false;
            };

            var middleView = new View
            {
                Size = new Size(300, 300),
                Position = new Position(110, 120),
                BackgroundColor = new Color(0.0f, 1.0f, 0.0f, 1.0f),
                Focusable = true,
                FocusableInTouch = true,
            };


            // The default the maximum allowed time is 500ms.
            // If you want to change this time, do as below.
            // But keep in mind this is a global option. Affects all gestures.
            GestureOptions.Instance.SetDoubleTapTimeout(300);
            tapGestureDetector = new TapGestureDetector();
            tapGestureDetector.Attach(frontView);
            tapGestureDetector.SetMaximumTapsRequired(2);
            tapGestureDetector.Detected += (s, e) =>
            {
              Tizen.Log.Error("NUI", $"OnTap {e.TapGesture.NumberOfTaps}\n");
            };

            backView = new TextLabel
            {
                Size = new Size(300, 300),
                Text = "Back View",
                Position = new Position(50, 70),
                PointSize = 11,
                BackgroundColor = new Color(1.0f, 1.0f, 0.0f, 1.0f),
                Focusable = true,
                FocusableInTouch = true,
            };
            backView.TouchEvent += OnBackTouchEvent;
            backView.WheelEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"backView WheelEvent!!!!{e.Wheel.Type}\n");
                return true;
            };

            // The default the minimum holding time is 500ms.
            // If you want to change this time, do as below.
            // But keep in mind this is a global option. Affects all gestures.
            GestureOptions.Instance.SetLongPressMinimumHoldingTime(300);

            longPressGestureDetector = new LongPressGestureDetector();
            longPressGestureDetector.Attach(backView);
            longPressGestureDetector.Detected += (s, e) =>
            {
              Tizen.Log.Error("NUI", $"OnLongPress\n");
            };

            backView.Add(middleView);
            backView.Add(frontView);
            root.Add(backView);
            window.Add(root);
        }

        private bool OnFrontTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnFrontTouchEvent {e.Touch.GetState(0)}\n");
            return false;
        }


        private bool OnBackTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnBackTouchEvent {e.Touch.GetState(0)}\n");
            return false;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
