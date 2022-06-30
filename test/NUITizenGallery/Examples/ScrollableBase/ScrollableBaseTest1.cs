using System;
using System.Collections.Generic;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class ScrollableBaseTestPage1 : ContentPage
    {
        private View root;
        ScrollableBase scrollableBase;
        private View[] items;
        private TextLabel[] pages;
        private TextLabel text0;
        private TextLabel text1;
        private TextLabel text2;
        private TextLabel text3;
        private Button btn1;

        private bool flag;

        internal class ScrollbarBaseImpl : ScrollbarBase
        { 
            public ScrollbarBaseImpl() : base()
            { }

            public override float ScrollPosition => 55.0f;

            public override float ScrollCurrentPosition => 55.0f;

            public override void Initialize(float contentLength, float viewportLength, float currentPosition, bool isHorizontal = false)
            { }

            public override void ScrollTo(float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
            { }

            public override void Update(float contentLength, float viewportLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
            { }

            public override void Update(float contentLength, float position, uint durationMs = 0, AlphaFunction alphaFunction = null)
            { }
        }

        internal ScrollableBaseTestPage1(Window window)
        {
            AppBar = new AppBar()
            {
                Title = "ScrollableBase Sample",
            };

            root = new View()
            {
                Size = new Size(window.WindowSize.Width, window.WindowSize.Height),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    VerticalAlignment = VerticalAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CellPadding = new Size(10, 30),
                }
            };

            scrollableBase = new ScrollableBase
            {
                Size = new Size(window.WindowSize.Width / 2, window.WindowSize.Height / 3),
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                ScrollEnabled = false,
                HideScrollbar = true,
            };

            items = new View[10];
            pages = new TextLabel[10];
            for (int i = 0; i < 10; i++)
            {
                items[i] = new View
                {
                    Position = new Position(i * (window.WindowSize.Width / 2), 0),
                    Size = new Size(window.WindowSize.Width / 2, window.WindowSize.Height / 3),
                };
                if (i % 2 == 0)
                {
                    items[i].BackgroundColor = Color.Magenta;
                }
                else
                {
                    items[i].BackgroundColor = Color.Cyan;
                }
                pages[i] = new TextLabel()
                {
                    Text = "Page" + i,
                    PointSize = 24.0f
                };
                items[i].Add(pages[i]);
                scrollableBase.Add(items[i]);
            }

            scrollableBase.Scrollbar = new ScrollbarBaseImpl();

            scrollableBase.ScrollDragStarted += OnScrollDragStarted;
            scrollableBase.ScrollDragEnded += OnScrollDragEnded;
            scrollableBase.Scrolling += OnScrolling;
            scrollableBase.ScrollOutOfBound += OnScrollOutOfBound;
            scrollableBase.ScrollAnimationEnded += OnScrollAnimationEnded;

            root.Add(scrollableBase);

            text0 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Ellipsis = false,
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
            };
            text1 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Ellipsis = false,
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
            };
            text2 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Ellipsis = false,
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
            };
            text3 = new TextLabel()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                Ellipsis = false,
                MultiLine = true,
                LineWrapMode = LineWrapMode.Word,
            };

            text0.Text = " ContentContainerName : " + scrollableBase.ContentContainer.Name + ",\n Scrollbar.ScrollPosition : " + scrollableBase.Scrollbar.ScrollPosition;

            text1.Text = @" EnableOverShootingEffect : " + scrollableBase.EnableOverShootingEffect + "," +
                "\n NoticeAnimationEndBeforePosition : " + scrollableBase.NoticeAnimationEndBeforePosition + "," +
                "\n ScrollEnabled : " + scrollableBase.ScrollEnabled + "," +
                "\n SnapToPage : " + scrollableBase.SnapToPage.ToString() + "," +
                "\n ScrollDuration : " + scrollableBase.ScrollDuration.ToString() + "," +
                "\n HideScrollbar : " + scrollableBase.HideScrollbar.ToString() + "," +
                "\n DecelerationRate : " + scrollableBase.DecelerationRate.ToString() + "," +
                "\n DecelerationThreshold : " + scrollableBase.DecelerationThreshold.ToString() + "," +
                "\n ScrollingEventThreshold : " + scrollableBase.ScrollingEventThreshold.ToString() + "," +
                "\n PageFlickThreshold : " + scrollableBase.PageFlickThreshold.ToString();

            text2.Text = " No Drag!";
            text3.Text = " Scrolling emit : " + flag;

            root.Add(text0);
            root.Add(text1);
            root.Add(text2);
            root.Add(text3);

            btn1 = new Button()
            {
                Text = "Change Property",
            };
            btn1.Clicked += OnChangePropertyClicked;

            root.Add(btn1);
            Content = root;
        }

        private void OnScrollAnimationEnded(object sender, ScrollEventArgs e)
        {
            text2.Text = "Drag Ended: CurrentPage = " + scrollableBase.CurrentPage;
        }

        private void OnScrollOutOfBound(object sender, ScrollOutOfBoundEventArgs e)
        {
            text2.Text = "Warning: Scroll out of the bound!";
        }

        private void OnScrolling(object sender, ScrollEventArgs e)
        {
            flag = true;
            text3.Text = "Scrolling Emit : " + flag;
        }

        private void OnScrollDragEnded(object sender, ScrollEventArgs e)
        {
            text2.Text = "Drag Ended!";
        }

        private void OnScrollDragStarted(object sender, ScrollEventArgs e)
        {
            text2.Text = "Darg Started!";
        }

        private void OnChangePropertyClicked(object sender, ClickedEventArgs e)
        {
            scrollableBase.ScrollEnabled = true;
            scrollableBase.HideScrollbar = false;
            scrollableBase.EnableOverShootingEffect = true;
            scrollableBase.NoticeAnimationEndBeforePosition = 0.6f;
            scrollableBase.SnapToPage = true;
            scrollableBase.ScrollDuration = 150;
            scrollableBase.DecelerationRate = 0.8f;
            scrollableBase.DecelerationThreshold = 0.05f;
            scrollableBase.ScrollingEventThreshold = 0.01f;
            scrollableBase.PageFlickThreshold = 0.5f;

            //text1.Text = " EnableOverShootingEffect : " + scrollableBase.EnableOverShootingEffect + ", NoticeAnimationEndBeforePosition : " + scrollableBase.NoticeAnimationEndBeforePosition + ", ScrollEnabled : " + scrollableBase.ScrollEnabled + ", SnapToPage : " + scrollableBase.SnapToPage.ToString() + ", ScrollDuration : " + scrollableBase.ScrollDuration.ToString() + ", HideScrollbar : " + scrollableBase.HideScrollbar.ToString() + ", DecelerationRate : " + scrollableBase.DecelerationRate.ToString() + ", DecelerationThreshold : " + scrollableBase.DecelerationThreshold.ToString() + ", ScrollingEventThreshold : " + scrollableBase.ScrollingEventThreshold.ToString() + ", PageFlickThreshold : " + scrollableBase.PageFlickThreshold.ToString();

            text1.Text = "";
            var str = " EnableOverShootingEffect : " + scrollableBase.EnableOverShootingEffect + ", NoticeAnimationEndBeforePosition : " + scrollableBase.NoticeAnimationEndBeforePosition + ", ScrollEnabled : " + scrollableBase.ScrollEnabled + ", SnapToPage : " + scrollableBase.SnapToPage.ToString() + ", ScrollDuration : " + scrollableBase.ScrollDuration.ToString() + ", HideScrollbar : " + scrollableBase.HideScrollbar.ToString() + ", DecelerationRate : " + scrollableBase.DecelerationRate.ToString() + ", DecelerationThreshold : " + scrollableBase.DecelerationThreshold.ToString() + ", ScrollingEventThreshold : " + scrollableBase.ScrollingEventThreshold.ToString() + ", PageFlickThreshold : " + scrollableBase.PageFlickThreshold.ToString();
            string[] arr = str.Split(',');

            for (int i = 0; i < arr.Length; i++)
            {
                text1.Text += arr[i] + '\n';
            }

            btn1.IsEnabled = false;
            btn1.Opacity = 0.3f;
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
    }

    class ScrollableBaseTest1 : IExample
    {
        private Window window;

        public void Activate()
        {
#pragma warning disable Reflection // The code contains reflection
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");
#pragma warning restore Reflection // The code contains reflection

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new ScrollableBaseTestPage1(window));
        }

        public void Deactivate()
        {
#pragma warning disable Reflection // The code contains reflection
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
#pragma warning restore Reflection // The code contains reflection
            window.GetDefaultNavigator().Pop();
        }
    }
}
