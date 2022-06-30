using System;
using System.Collections.Generic;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Threading.Tasks;
using System.Threading;


namespace NUITizenGallery
{
    internal class ScrollableBaseTestPage4 : ContentPage
    {
        private View root;

        internal ScrollableBaseTestPage4(Window window)
        {
            AppBar = new AppBar()
            {
                Title = "ScrollableBase Sample 4",
            };

            root = new View()
            {
                Size = new Size(window.WindowSize.Width, window.WindowSize.Height),
                BackgroundColor = Color.White,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CellPadding = new Size(5, 5),
                }
            };
            Content = root;

            var button = new Button
            {
                Text = "Create"
            };
            root.Add(button);

            var button2 = new Button
            {
                Text = "Test"
            };
            root.Add(button2);

            var target = new View
            {
                BackgroundColor = Color.Blue,
                SizeWidth = 200,
                SizeHeight = 200,
            };
            root.Add(target);

            bool createDummy = false;

            var texts = new List<TextLabel>();

            for (int i = 0; i < 10; i++)
            {
                var text = new TextLabel
                {
                    Text = "Text.."
                };
                root.Add(text);
                texts.Add(text);
            }

            View container = null;
            MyCustomScrolableBase scrollview = null;

            button.Clicked += async (s, e) =>
            {
                if (scrollview != null)
                    return;

                container = new View
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent
                };

                scrollview = new MyCustomScrolableBase
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.MatchParent
                };
                scrollview.ContentContainer.Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal
                };

                scrollview.ScrollingDirection = ScrollableBase.Direction.Horizontal;

                for (int i = 0; i < 100; i++)
                {
                    var rnd = new Random();
                    scrollview.ContentContainer.Add(new View
                    {
                        HeightSpecification = LayoutParamPolicies.MatchParent,
                        SizeWidth = 200,
                        BackgroundColor = new Color((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1)
                    });
                }
                container.Add(scrollview);
                root.Add(container);

                scrollview.Scrolling += (s, e) =>
                {
                    foreach (var view in texts)
                    {
                        view.Text = $"Text.. {e.Position.X}";
                    }
                };

                createDummy = false;

                await Task.Delay(1000);

                createDummy = true;
                int count = 0;
                while (createDummy)
                {
                    await Task.Delay(10);
                    var dummy = new PixelBuffer((uint)1400, (uint)1400, PixelFormat.RGBA8888);
                    var tmp = new byte[1024 * 1024 * 1024];

                    if (count++ % 100 == 0)
                        Tizen.Log.Fatal("NUITEST", $"Buffer created {count}");
                }

            };

            this.RemovedFromWindow += (s, e) =>
            {
                Tizen.Log.Fatal("NUITEST", $"Remove");
                root.Remove(container);
                container = null;
                scrollview = null;

                GC.Collect();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            };

            button2.Clicked += (s, e) =>
            {
                Tizen.Log.Fatal("NUITEST", $"Remove");
                root.Remove(container);
                container = null;
                scrollview = null;

                GC.Collect();
                GC.WaitForFullGCComplete();
                GC.Collect();
                GC.WaitForFullGCComplete();

                Tizen.Log.Fatal("NUITEST", $"Remove -- end");
            };

        }

        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Deactivate();
            }

            base.Dispose(type);
        }

        private void Deactivate()
        {
            if (root != null)
            {

            }
        }


        class MyCustomScrolableBase : ScrollableBase
        {
            delegate float UserAlphaFunctionDelegate(float progress);
            UserAlphaFunctionDelegate? _customScrollingAlphaFunctionDelegate;
            Func<float, float>? _scrollingAlpha;
            AlphaFunction? _customScrollingAlphaFunction;

            public MyCustomScrolableBase()
            {
                _customScrollingAlphaFunctionDelegate = new UserAlphaFunctionDelegate(ScrollingAlpha);
                _customScrollingAlphaFunction = new AlphaFunction(_customScrollingAlphaFunctionDelegate);
                this.Scrolling += OnScrolling;
            }

            void OnScrolling(object sender, ScrollEventArgs e)
            {
                Tizen.Log.Fatal("NUITEST", $"Scrolling...");
            }

            float ScrollingAlpha(float progress)
            {
                Tizen.Log.Fatal("NUITEST", $"ScrollingAlpha({progress})");
                return _scrollingAlpha?.Invoke(progress) ?? 1.0f;
            }

            protected override void Dispose(bool disposing)
            {
                Tizen.Log.Fatal("NUITEST", $"Dispose scrollview : {disposing} thread: {Thread.CurrentThread.ManagedThreadId} - start");
                base.Dispose(disposing);
                Tizen.Log.Fatal("NUITEST", $"Dispose scrollview : {disposing} thread: {Thread.CurrentThread.ManagedThreadId} - end");

            }

            protected override void Dispose(DisposeTypes type)
            {
                Tizen.Log.Fatal("NUITEST", $"Dispose DisposeTypes : {type} thread: {Thread.CurrentThread.ManagedThreadId} - start");
                base.Dispose(type);
                Tizen.Log.Fatal("NUITEST", $"Dispose DisposeTypes : {type} thread: {Thread.CurrentThread.ManagedThreadId} - end");
            }

            protected override void Decelerating(float velocity, Animation animation)
            {
                //base.Decelerating(velocity, animation);
                float absVelocity = Math.Abs(velocity);
                float friction = 0.0001f;

                float totalTime = Math.Abs(velocity / friction);
                float totalDistance = absVelocity * totalTime - (friction * (float)Math.Pow(totalTime, 2) / 2f);

                float currentPosition = (ScrollingDirection == Direction.Horizontal ? ContentContainer.PositionX : ContentContainer.PositionY);
                float targetPosition = currentPosition + (velocity > 0 ? totalDistance : -totalDistance);
                float maximumScrollableSize = ScrollingDirection == Direction.Horizontal ? ContentContainer.SizeWidth - SizeWidth : ContentContainer.SizeHeight - SizeHeight;

                if (targetPosition > 0)
                {
                    totalDistance -= targetPosition;
                    targetPosition = 0;
                }
                else if (targetPosition < -maximumScrollableSize)
                {
                    var overlapped = -maximumScrollableSize - targetPosition;
                    totalDistance -= overlapped;
                    targetPosition = -maximumScrollableSize;
                }

                if (totalDistance < 1)
                {
                    base.Decelerating(0, animation);
                    return;
                }

                _scrollingAlpha = (progress) =>
                {
                    if (totalDistance == 0)
                        return 1;

                    var time = totalTime * progress;
                    var distance = absVelocity * time - (friction * (float)Math.Pow(time, 2) / 2f);
                    Tizen.Log.Fatal("NUITEST", $"alpha : progress : {progress},  {distance / totalDistance} - thread: {Thread.CurrentThread.ManagedThreadId}");
                    return Math.Min(distance / totalDistance, 1);
                };

                animation.Duration = (int)totalTime;
                animation.AnimateTo(ContentContainer, (ScrollingDirection == Direction.Horizontal) ? "PositionX" : "PositionY", targetPosition, _customScrollingAlphaFunction);
                animation.Play();
            }
        }

    }

    class ScrollableBaseTest4 : IExample
    {
        private Window window;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new ScrollableBaseTestPage4(window));
        }

        public void Deactivate()
        {
            window.GetDefaultNavigator().Pop();
        }
    }
}
