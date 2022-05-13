using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Components;


namespace Tizen.NUI.Samples
{
    public class ScrollableFocusNoneChildrenSample : IExample
    {
        int SCROLLMAX = 50;
        public View root;

        public void Activate()
        {

            Random rnd = new Random();
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                BackgroundColor = Color.White,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CellPadding = new Size(10, 10),
                },
            };
            window.Add(root);

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            var top = new Button()
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Top"
            };
            root.Add(top);

            /* Important Notice : To navigate ScrollableBase over the none-focusable childrens,
             *                    ScrollableBase itself need to be focusable.
             */
            var verticalScrollView = new ScrollableBase()
            {
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Gray,
                Focusable = true,
                FocusableInTouch = true,
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                }
            };
            root.Add(verticalScrollView);

            for (int i = 0; i < SCROLLMAX; i++)
            {
                var colorItem = new View()
                {
                    WidthSpecification = LayoutParamPolicies.MatchParent,
                    HeightSpecification = LayoutParamPolicies.WrapContent,
                    BackgroundColor = new Color((float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, 1),
                    Layout = new LinearLayout
                    {
                        LinearOrientation = LinearLayout.Orientation.Horizontal,
                        VerticalAlignment = VerticalAlignment.Center,
                        CellPadding = new Size2D(10, 10),
                    }
                };
                var label = new TextLabel()
                {
                    Text = $"[{i}]",
                    PointSize = 20,
                };
                colorItem.Add(label);
                verticalScrollView.Add(colorItem);
            }

            var middle = new Button()
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Middle"
            };
            root.Add(middle);

            var horizontalLayout = new View()
            {
                BackgroundColor = Color.White,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size(10, 10),
                },
            };
            root.Add(horizontalLayout);

            var leftIcon = new RadioButton()
            {
                WidthSpecification = 50,
                HeightSpecification = 50,
                Focusable = true,
                FocusableInTouch = true,
            };
            horizontalLayout.Add(leftIcon);

            /* Important Notice : To navigate ScrollableBase over the none-focusable childrens,
             *                    ScrollableBase itself need to be focusable.
             */
            var horizontalScrollView = new ScrollableBase()
            {
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Gray,
                Focusable = true,
                FocusableInTouch = true,
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                }
            };
            horizontalLayout.Add(horizontalScrollView);

            for (int i = 0; i < SCROLLMAX; i++)
            {
                var colorItem = new View()
                {
                    WidthSpecification = LayoutParamPolicies.WrapContent,
                    HeightSpecification = LayoutParamPolicies.MatchParent,
                    BackgroundColor = new Color((float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, 1),
                    Layout = new LinearLayout
                    {
                        LinearOrientation = LinearLayout.Orientation.Vertical,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        CellPadding = new Size2D(10, 10),
                    }
                };
                var label = new TextLabel()
                {
                    Text = $"[{i}]",
                    PointSize = 20,
                };
                colorItem.Add(label);
                horizontalScrollView.Add(colorItem);
            }

            var rightIcon = new RadioButton()
            {
                WidthSpecification = 50,
                HeightSpecification = 50,
                Focusable = true,
                FocusableInTouch = true,
            };
            horizontalLayout.Add(rightIcon);

            var bottom = new Button()
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Bottom"
            };
            root.Add(bottom);
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
