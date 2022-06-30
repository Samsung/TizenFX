using System;
using System.Collections.Generic;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class ScrollableBaseTestPage2 : ContentPage
    {
        private View root;
        ScrollableBase scrollableBase;
        private View[] items;
        private TextLabel[] pages;
        private TextLabel text1;
        private TextLabel text2;
        private TextLabel text3;
        private Button btn1;
        private Button btn2;
        private Button btn3;
        private Button btn4;
        private Button btn5;
        private Button btn6;

        private View bottomView;

        internal ScrollableBaseTestPage2(Window window)
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
                    CellPadding = new Size(10, 20),
                }
            };

            scrollableBase = new ScrollableBase
            {
                Size = new Size(window.WindowSize.Width / 2, window.WindowSize.Height / 2),
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                SnapToPage = true,
                HideScrollbar = false,
                Padding = new Extents(20, 20, 20, 20),
                ScrollAlphaFunction = new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOut),
            };

            items = new View[10];
            pages = new TextLabel[10];
            for (int i = 0; i < 10; i++)
            {
                items[i] = new View
                {
                    Position = new Position(i * (window.WindowSize.Width / 2), 0),
                    Size = new Size(window.WindowSize.Width / 2, window.WindowSize.Height / 2),
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

            root.Add(scrollableBase);
            scrollableBase.ScrollAnimationStarted += OnScrollAnimationStarted;
            scrollableBase.ScrollAnimationEnded += OnScrollAnimationEnded;

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
            text1.Text = "Children count :  " + scrollableBase.Children.Count;
            text2.Text = "ScrollAlphaFunction : " + scrollableBase.ScrollAlphaFunction.GetBuiltinFunction();
            text3.Text = "ScrollCurrentPosition : " + scrollableBase.ScrollCurrentPosition.X;

            btn1 = new Button()
            {
                Text = "ScrollTo",
                Size = new Size(window.WindowSize.Width / 4, window.WindowSize.Height / 12),
            };
            btn1.TextLabel.Ellipsis = false;
            btn1.TextLabel.MultiLine = true;
            btn1.TextLabel.LineWrapMode = LineWrapMode.Word;
            btn1.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn1.TextLabel.HeightSpecification = LayoutParamPolicies.MatchParent;
            btn1.Clicked += OnScrollToClicked;

            btn2 = new Button()
            {
                Text = "ScrollToIndex",
                Size = new Size(window.WindowSize.Width / 4, window.WindowSize.Height / 12),
            };
            btn2.TextLabel.Ellipsis = false;
            btn2.TextLabel.MultiLine = true;
            btn2.TextLabel.LineWrapMode = LineWrapMode.Word;
            btn2.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn2.TextLabel.HeightSpecification = LayoutParamPolicies.MatchParent;
            btn2.Clicked += OnScrollToIndexClicked;

            btn3 = new Button()
            {
                Text = "Remove",
                Size = new Size(window.WindowSize.Width / 4, window.WindowSize.Height / 12),
            };
            btn3.TextLabel.Ellipsis = false;
            btn3.TextLabel.MultiLine = true;
            btn3.TextLabel.LineWrapMode = LineWrapMode.Word;
            btn3.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn3.TextLabel.HeightSpecification = LayoutParamPolicies.MatchParent;
            btn3.Clicked += OnRemoveClicked;

            btn4 = new Button()
            {
                Text = "RemoveAll",
                Size = new Size(window.WindowSize.Width / 4, window.WindowSize.Height / 12),
            };
            btn4.TextLabel.Ellipsis = false;
            btn4.TextLabel.MultiLine = true;
            btn4.TextLabel.LineWrapMode = LineWrapMode.Word;
            btn4.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn4.TextLabel.HeightSpecification = LayoutParamPolicies.MatchParent;
            btn4.Clicked += OnRemoveAllClicked;

            btn5 = new Button()
            {
                Text = "ReplaceLayout",
                Size = new Size(window.WindowSize.Width / 4, window.WindowSize.Height / 12),
            };
            btn5.TextLabel.Ellipsis = false;
            btn5.TextLabel.MultiLine = true;
            btn5.TextLabel.LineWrapMode = LineWrapMode.Word;
            btn5.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn5.TextLabel.HeightSpecification = LayoutParamPolicies.MatchParent;
            btn5.Clicked += OnReplaceLayoutClicked;

            btn6 = new Button()
            {
                Text = "SetScrollAvailableArea",
                Size = new Size(window.WindowSize.Width / 4, window.WindowSize.Height / 12),
            };
            btn6.TextLabel.Ellipsis = false;
            btn6.TextLabel.MultiLine = true;
            btn6.TextLabel.LineWrapMode = LineWrapMode.Word;
            btn6.TextLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn6.TextLabel.HeightSpecification = LayoutParamPolicies.MatchParent;
            btn6.Clicked += OnSetScrollAvailableArea;

            bottomView = new View()
            {
                Size = new Size(window.WindowSize.Width, window.WindowSize.Height / 10),
                CellHorizontalAlignment = HorizontalAlignmentType.Center,
                Layout = new GridLayout()
                {
                    Columns = 4,
                    ColumnSpacing = 10.0f,
                    RowSpacing = 20.0f,
                }
            };

            root.Add(text1);
            root.Add(text2);
            root.Add(text3);
            bottomView.Add(btn1);
            bottomView.Add(btn2);
            bottomView.Add(btn3);
            bottomView.Add(btn4);
            bottomView.Add(btn5);
            bottomView.Add(btn6);
            root.Add(bottomView);

            Content = root;
        }

        private void OnSetScrollAvailableArea(object sender, ClickedEventArgs e)
        {
            scrollableBase.ScrollAvailableArea = new Vector2(root.SizeWidth / 2, root.SizeHeight / 2);
            text1.Text = "Children count :  " + scrollableBase.Children.Count + " ; ScrollAvailableArea , X : " + scrollableBase.ScrollAvailableArea.X + " Y : " + scrollableBase.ScrollAvailableArea.Y;
        }

        private void OnScrollAnimationEnded(object sender, ScrollEventArgs e)
        {
            text3.Text = "Scroll Animation Ended! ScrollCurrentPosition : X = " + scrollableBase.ScrollCurrentPosition.X + ", Y = " + scrollableBase.ScrollCurrentPosition.Y +  "; CurrentPage : " +scrollableBase.CurrentPage;
        }

        private void OnScrollAnimationStarted(object sender, ScrollEventArgs e)
        {
            text3.Text = "Scroll Animation Started!";
        }

        private void OnReplaceLayoutClicked(object sender, ClickedEventArgs e)
        {
            scrollableBase.ScrollTo(0, false);
            if (scrollableBase.ScrollingDirection == ScrollableBase.Direction.Horizontal)
            {
                scrollableBase.Layout = new GridLayout()
                {
                    Rows = 10,
                };
                scrollableBase.ScrollingDirection = ScrollableBase.Direction.Vertical;
                scrollableBase.Padding = new Extents(0, 0, 0, 0);
            }
            else
            {
                scrollableBase.Layout = new LinearLayout();
                scrollableBase.ScrollingDirection = ScrollableBase.Direction.Horizontal;
            }
        }

        private void OnRemoveAllClicked(object sender, ClickedEventArgs e)
        {
            scrollableBase.RemoveAllChildren();
            text1.Text = "Children count :  " + scrollableBase.Children.Count;

            btn1.IsEnabled = false;
            btn1.Opacity = 0.3f;
            btn2.IsEnabled = false;
            btn2.Opacity = 0.3f;
            btn3.IsEnabled = false;
            btn3.Opacity = 0.3f;
            btn4.IsEnabled = false;
            btn4.Opacity = 0.3f;
            btn5.IsEnabled = false;
            btn5.Opacity = 0.3f;
            btn6.IsEnabled = false;
            btn6.Opacity = 0.3f;
        }

        private void OnRemoveClicked(object sender, ClickedEventArgs e)
        {
            scrollableBase.Remove(items[scrollableBase.Children.Count - 1]);
            text1.Text = "Children count :  " + scrollableBase.Children.Count;
        }

        private void OnScrollToIndexClicked(object sender, ClickedEventArgs e)
        {
            scrollableBase.ScrollToIndex(5);
        }

        private void OnScrollToClicked(object sender, ClickedEventArgs e)
        {
            scrollableBase.ScrollTo(root.SizeWidth * 4, true);
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

    class ScrollableBaseTest2 : IExample
    {
        private Window window;

        public void Activate()
        {
#pragma warning disable Reflection // The code contains reflection
            Log.Info(this.GetType().Name, $"@@@ this.GetType().Name={this.GetType().Name}, Activate()");
#pragma warning restore Reflection // The code contains reflection

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new ScrollableBaseTestPage2(window));
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
