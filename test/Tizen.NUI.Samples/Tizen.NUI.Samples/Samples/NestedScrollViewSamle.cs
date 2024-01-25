using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;


namespace Tizen.NUI.Samples
{
    public class NestedScrollViewSamle : IExample
    {
        private View root;


        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            FocusManager.Instance.EnableDefaultAlgorithm(true);

            root = new View();
            root.Layout = new AbsoluteLayout();
            root.Size = new Size(300, 800);

            var scrollview = new ScrollableBase{
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Focusable = true,
                FocusableInTouch = true,
            };

            root.Add(scrollview);

            scrollview.ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical
            };

            scrollview.ContentContainer.Add(new View
            {
                BackgroundColor = new Vector4(1.0f, 0.6f, 0.2f, 1.0f),
                SizeHeight = 100,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            });

            var scroll2 = new ScrollableBase{
                BackgroundColor = Color.Gray,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                Focusable = true,
                FocusableInTouch = true,
            };

            scroll2.WidthSpecification = LayoutParamPolicies.MatchParent;
            scroll2.HeightSpecification = LayoutParamPolicies.MatchParent;
            scroll2.WidthResizePolicy = ResizePolicyType.FillToParent;
            scroll2.SizeHeight = 400;

            var abscontainer = new View
            {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 400,
            };
            abscontainer.Add(scroll2);

            scrollview.ContentContainer.Add(abscontainer);

            scroll2.ContentContainer.Layout = new LinearLayout
            {
                LinearOrientation = LinearLayout.Orientation.Vertical
            };

            for(int i=0; i<50; i++)
            {
                scroll2.ContentContainer.Add(new TextLabel
                {
                    Text = $"Text {i}",
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    Focusable = true,
                    FocusableInTouch = true,
                    // Position = new Position(0, i*50+200),
                });
            }

            scrollview.ContentContainer.Add(new View{
                BackgroundColor = Color.Yellow,
                SizeHeight = 400,
                WidthResizePolicy = ResizePolicyType.FillToParent,
            });

            TextLabel titleView = new TextLabel
            {
                Text = "Title",
                Focusable = true,
                FocusableInTouch = true,
                Size = new Size(300, 100),
            };

            TextLabel footView = new TextLabel
            {
                Text = "Foot",
                Focusable = true,
                FocusableInTouch = true,
                Size = new Size(300, 100),
                Position = new Position(0, 500),
            };

            window.Add(root);
            window.Add(titleView);
            window.Add(footView);
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
