using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class TouchGestureSample : IExample
    {
        private View root;
        GestureDetectorManager mGestureDetector;
        private TextLabel frontView;
        private TextLabel backView;

        public void ChangeText()
        {
            backView.Text = "From OnTap BackView";
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View();


           frontView = new TextLabel
            {
                Size = new Size(300, 300),
                Text = "Front View",
                Position = new Position(150, 170),
                PointSize = 11,
                BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f),
            };
            frontView.TouchEvent += OnFrontTouchEvent;


            backView = new TextLabel
            {
                Size = new Size(300, 300),
                Text = "Back View",
                Position = new Position(50, 70),
                PointSize = 11,
                BackgroundColor = new Color(1.0f, 1.0f, 0.0f, 1.0f),
            };

            mGestureDetector = new GestureDetectorManager(backView, new MyGestureListener());
            backView.TouchEvent += OnBackTouchEvent;

            backView.Add(frontView);

            root.Add(backView);
            window.Add(root);
        }

        private bool OnFrontTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnFrontTouchEvent {e.Touch.GetState(0)}\n");
            return true;
        }


        private bool OnBackTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnBackTouchEvent {e.Touch.GetState(0)}\n");
            mGestureDetector.FeedTouchEvent(source, e, this);
            return false;
        }

        class MyGestureListener : GestureDetectorManager.GestureListener
        {
          public override void OnTap(object sender, TapGestureDetector.DetectedEventArgs e, object userData)
          {
            Tizen.Log.Error("NUI", $"OnTap \n");
            if(userData != null)
            {
              TouchGestureSample sample = (TouchGestureSample) userData;
              sample.ChangeText();
            }
          }

          public override void OnPan(object sender, PanGestureDetector.DetectedEventArgs e, object userData)
          {
            Tizen.Log.Error("NUI", $"OnPan \n");
          }

          public override void OnPinch(object sender, PinchGestureDetector.DetectedEventArgs e, object userData)
          {
            Tizen.Log.Error("NUI", $"OnPinch \n");
          }

          public override void OnLongPress(object sender, LongPressGestureDetector.DetectedEventArgs e, object userData)
          {
            Tizen.Log.Error("NUI", $"OnLongPress \n");
          }
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
