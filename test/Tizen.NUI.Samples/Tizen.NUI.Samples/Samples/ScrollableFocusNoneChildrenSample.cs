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
            Window window = NUIApplication.GetDefaultWindow();

            root = new View();
            root.Layout = new AbsoluteLayout();
            root.Size = new Size(500, 800);

            root.BackgroundColor = Color.White;
            window.Add(root);

            FocusManager.Instance.EnableDefaultAlgorithm(true);
            root.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical
            };
            root.WidthSpecification = LayoutParamPolicies.MatchParent;
            root.HeightSpecification = LayoutParamPolicies.MatchParent;


            var top = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Top"
            };
            root.Add(top);

            var scrollView = new ScrollableBase
            {
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Gray,
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                }
            };

            Random rnd = new Random();

            for (int i = 0; i < SCROLLMAX; i++)
            {
                var colorLabel = new TextLabel();
                colorLabel.WidthSpecification = LayoutParamPolicies.MatchParent;
                colorLabel.HeightSpecification = LayoutParamPolicies.WrapContent;
                colorLabel.BackgroundColor = new Color((float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, 1);
                colorLabel.Text = $"[{i}]th Child";
                colorLabel.PointSize = 20;
                colorLabel.Padding = new Extents(5, 5, 5, 5);
                scrollView.Add(colorLabel);
            }

            root.Add(scrollView);

            var bottom = new Button
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
