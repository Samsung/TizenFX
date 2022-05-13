using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Components;


namespace Tizen.NUI.Samples
{
    public class ScrollableFocusSample : IExample
    {
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


            var topbtn = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Top"
            };
            root.Add(topbtn);

            var scrollview = new ScrollableBase
            {
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Gray
            };
            scrollview.ContentContainer.Layout = new AbsoluteLayout();
            scrollview.ContentContainer.WidthSpecification = LayoutParamPolicies.MatchParent;
            scrollview.ContentContainer.SizeHeight = 1800;
            root.Add(scrollview);
            for (int i = 0; i < 40; i++)
            {
                scrollview.ContentContainer.Add(CreateButton(i));
            }

            var middle = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "Middle"
            };
            root.Add(middle);

            var myscrollview = new ScrollableBase
            {
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Yellow
            };
            myscrollview.ContentContainer.Layout = new AbsoluteLayout();
            myscrollview.ContentContainer.WidthSpecification = LayoutParamPolicies.MatchParent;
            myscrollview.ContentContainer.SizeHeight = 1800;
            root.Add(myscrollview);
            for (int i = 0; i < 40; i++)
            {
                myscrollview.ContentContainer.Add(CreateButton(i));
            }

            var bottom = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = "bottom"
            };
            root.Add(bottom);

        }

        static View CreateButton(int index)
        {
            var rnd = new Random();

            var btn = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = $"Item {index}",
            };
            // btn.FocusGained += (s, e) =>
            // {
            //   Tizen.Log.Error("NUI", $"[[{btn.Text}]] \n");
            // };

            var item = Wrapping(btn);
            item.SizeWidth = 200;
            item.SizeHeight = 90;

            item.Position = new Position(220 * (index % 3), 100 * (index / 3) );

            if (item is Button button)
            {
                button.Text = $"[{button.Text}]";
            }

            return item;
        }

        static View Wrapping(View view)
        {
            int cnt = new Random().Next(0, 4);

            for (int i = 0; i < cnt; i++)
            {
                var wrapper = new View();
                view.WidthSpecification = LayoutParamPolicies.MatchParent;
                view.HeightSpecification = LayoutParamPolicies.MatchParent;
                wrapper.Add(view);
                view = wrapper;
            }

            return view;
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
