using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class FeedTapAndPanGestureSample : IExample
    {
        private View root;

        public class MyScrollView : View {
            public enum Direction
            {
                Horizontal,
                Vertical
            }
            public View ContentContainer { get; set; }

            private PanGestureDetector mPanGestureDetector;
            private Direction mScrollDirection = Direction.Vertical;
            private float maxScrollDistance;
            private float childTargetPosition = 0.0f;

            public MyScrollView() : base()
            {
                Tizen.Log.Error("NUI", $"MyScrollView\n");
                ClippingMode = ClippingModeType.ClipToBoundingBox;
                base.Layout = new AbsoluteLayout();
                ContentContainer = new View()
                {
                    BackgroundColor = Color.Grey,
                };

                ContentContainer.Relayout += OnScrollingChildRelayout;
                base.Add(ContentContainer);
                base.Relayout += OnScrollingChildRelayout;
                this.TouchEvent += OnTouchEvent;
                mPanGestureDetector = new PanGestureDetector();
                mPanGestureDetector.Detected += OnPanGestureDetected;
            }

            public override void Add(View view)
            {
                ContentContainer.Add(view);
            }

            public void SetDirection(Direction direction)
            {
                mScrollDirection = direction;
                mPanGestureDetector.ClearAngles();
                mPanGestureDetector.AddDirection(direction == Direction.Horizontal ?
                        PanGestureDetector.DirectionHorizontal : PanGestureDetector.DirectionVertical);
            }

            private bool OnTouchEvent(object source, View.TouchEventArgs e)
            {
                bool ret = mPanGestureDetector.HandleEvent(source as View, e.Touch);
                Tizen.Log.Error("NUI", $"OnTouchEvent {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            }

            private void OnPanGestureDetected(object source, PanGestureDetector.DetectedEventArgs e)
            {
                if(e.PanGesture.State == Gesture.StateType.Started)
                {
                    Tizen.Log.Error("NUI", $"OnPanGestureDetected Started\n");
                }
                else if (e.PanGesture.State == Gesture.StateType.Continuing)
                {
                    Tizen.Log.Error("NUI", $"OnPanGestureDetected mScrollDirection : {mScrollDirection} \n");
                    if(mScrollDirection == Direction.Horizontal)
                    {
                        ScrollBy(e.PanGesture.Displacement.X);
                    }
                    else
                    {
                        ScrollBy(e.PanGesture.Displacement.Y);
                    }

                }
                else if (e.PanGesture.State == Gesture.StateType.Finished || e.PanGesture.State == Gesture.StateType.Cancelled)
                {
                    Tizen.Log.Error("NUI", $"OnPanGestureDetected Finished or Cancelled\n");
                }
            }

            private void OnScrollingChildRelayout(object source, EventArgs args)
            {
                maxScrollDistance = CalculateMaximumScrollDistance();
            }

            private float CalculateMaximumScrollDistance()
            {
                float scrollingChildLength = 0;
                float scrollerLength = 0;
                if (mScrollDirection == Direction.Horizontal)
                {
                    scrollingChildLength = ContentContainer.Size.Width;
                    scrollerLength = Size.Width;
                }
                else
                {
                    scrollingChildLength = ContentContainer.Size.Height;
                    scrollerLength = Size.Height;
                }
                return Math.Max(scrollingChildLength - scrollerLength, 0);
            }

            private void ScrollBy(float displacement)
            {
                float childCurrentPosition = (mScrollDirection == Direction.Horizontal) ? ContentContainer.PositionX : ContentContainer.PositionY;
                childTargetPosition = childCurrentPosition + displacement;
                float finalTargetPosition = BoundScrollPosition(childTargetPosition);

                if (mScrollDirection == Direction.Horizontal)
                {
                    ContentContainer.PositionX = finalTargetPosition;
                }
                else
                {
                    ContentContainer.PositionY = finalTargetPosition;
                }
            }

            private float BoundScrollPosition(float targetPosition)
            {
                targetPosition = Math.Min(0, targetPosition);
                targetPosition = Math.Max(-maxScrollDistance, targetPosition);
                return targetPosition;
            }

        }

        private TapGestureDetector mTapGestureDetector;
        private int view1TapCount = 0;
        private int view3TapCount = 0;
        private TextLabel view1;
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
            };

            mTapGestureDetector = new TapGestureDetector();
            mTapGestureDetector.Detected += OnTapGestureDetected;
            view1.TouchEvent += (s, e) =>
            {
                bool ret = mTapGestureDetector.HandleEvent(s as View, e.Touch);
                Tizen.Log.Error("NUI", $"view1 OnTouchEvent {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            };

            var view2 = new View()
            {
                Position2D = new Position2D(100, 100),
                Size2D = new Size2D(1000,300),
                BackgroundColor = Color.Aqua,
            };
            view2.Add(GetNewScrollView(Color.Azure));

            view3 = new TextLabel()
            {
                Position2D = new Position2D(500, 500),
                Size2D = new Size2D(300,300),
                BackgroundColor = Color.Red,
            };
            view3.TouchEvent += (s, e) =>
            {
                bool ret = mTapGestureDetector.HandleEvent(s as View, e.Touch);
                Tizen.Log.Error("NUI", $"view3 OnTouchEvent {e.Touch.GetState(0)} : {ret}\n");
                return ret;
            };

            view1.Add(view2);
            view1.Add(view3);
            root.Add(view1);

            window.Add(root);
        }

        public View GetNewScrollView(Color color)
        {
            var scrollView = new MyScrollView()
            {
                Size2D = new Size2D(1000, 300),
            };
            scrollView.ContentContainer.Size2D = new Size2D(2000, 300);
            scrollView.ContentContainer.BackgroundColor = color;
            scrollView.SetDirection(MyScrollView.Direction.Horizontal);
            scrollView.ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Begin,
                VerticalAlignment = VerticalAlignment.Center,
                CellPadding = new Size2D(50, 50),
            };
            for (int i=0; i<20; i++)
            {
                var item = new View()
                {
                    Size2D = new Size2D(100, 100),
                    BackgroundColor = Color.DarkBlue,
                };
                scrollView.Add(item);
            }
            return scrollView;
        }

        private void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnTapGestureDetected\n");
            if(e.View == view1)
            {
                view1.Text = "view1 tap count "+(++view1TapCount);
            }
            else if (e.View == view3)
            {
                view3.Text = "view3 tap count "+(++view3TapCount);
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
