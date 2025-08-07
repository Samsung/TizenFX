using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class FeedTapAndLongPressGestureSample : IExample
    {
        private View root;
        private TapGestureDetector mTapGestureDetector;
        private LongPressGestureDetector mLongPressGestureDetector;
        private int view1TapCount = 0;
        private int view1LongCount = 0;
        private int view2TapCount = 0;
        private int view3TapCount = 0;
        private TextLabel view1;
        private TextLabel view2;
        private TextLabel view3;
        public void Activate()
        {
            NUIApplication.SetGeometryHittestEnabled(true);
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            view1 = new TextLabel()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                BackgroundColor = Color.Orange,
                Text = "Long and Tap"
            };

            mTapGestureDetector = new TapGestureDetector();
            mTapGestureDetector.Detected += OnTapGestureDetected;

            mLongPressGestureDetector = new LongPressGestureDetector();
            mLongPressGestureDetector.Detected += OnLongPressGestureDetected;
            view1.TouchEvent += (s, e) =>
            {
                bool ret = mTapGestureDetector.HandleEvent(s as View, e.Touch);
                // ret |= mLongPressGestureDetector.HandleEvent(s as View, e.Touch);
                Tizen.Log.Error("NUI", $"view1 OnTouchEvent Tap {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            };

            view1.TouchEvent += (s, e) =>
            {
                bool ret = mLongPressGestureDetector.HandleEvent(s as View, e.Touch);
                Tizen.Log.Error("NUI", $"view1 OnTouchEvent Long {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            };

            view2 = new TextLabel()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                Size2D = new Size2D(500, 300),
                BackgroundColor = Color.Aqua,
                Text = "Tap"
            };
            view2.TouchEvent += (s, e) =>
            {
                bool ret = mTapGestureDetector.HandleEvent(s as View, e.Touch);
                Tizen.Log.Error("NUI", $"view2 OnTouchEvent {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            };


            view3 = new TextLabel()
            {
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true,
                Size2D = new Size2D(300, 200),
                BackgroundColor = Color.Red,
                Text = "Tap"
            };
            view3.TouchEvent += (s, e) =>
            {
                bool ret = mTapGestureDetector.HandleEvent(s as View, e.Touch);
                Tizen.Log.Error("NUI", $"view3 OnTouchEvent {e.Touch.GetState(0)} : {ret}\n");
                return false;
            };


            view1.Add(view2);
            view2.Add(view3);
            root.Add(view1);

            window.Add(root);
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnTapGestureDetected\n");
            if(e.View == view1)
            {
                view1.Text = "view1 Long count "+view1LongCount +" Tap count "+(++view1TapCount);
            }
            else if (e.View == view2)
            {
                view2.Text = "view2 tap count "+(++view2TapCount);
            }
            else if (e.View == view3)
            {
                view3.Text = "view3 tap count "+(++view3TapCount);
            }
        }

        private void OnLongPressGestureDetected(object source, LongPressGestureDetector.DetectedEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnLongPressGestureDetected {e.LongPressGesture.State}\n");
            if(e.LongPressGesture.State == Gesture.StateType.Started)
            {
                view1.Text = "view1 Long count "+(++view1LongCount) +" Tap count "+view1TapCount;
            }
        }


        public void Deactivate()
        {
            NUIApplication.SetGeometryHittestEnabled(false);
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
