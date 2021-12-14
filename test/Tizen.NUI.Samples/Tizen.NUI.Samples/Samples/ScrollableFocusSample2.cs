using System;
using Tizen.NUI.BaseComponents;
using Tizen.NUI;
using Tizen.NUI.Components;


namespace Tizen.NUI.Samples
{
    public class ScrollableFocusSample2 : IExample
    {
        public View root;
        TextLabel _label;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View();
            root.Layout = new AbsoluteLayout();
            root.Size = new Size(300, 800);

            root.BackgroundColor = Color.White;
            window.Add(root);

            FocusManager.Instance.EnableDefaultAlgorithm(true);
            root.Layout = new AbsoluteLayout();
            root.WidthSpecification = LayoutParamPolicies.MatchParent;
            root.HeightSpecification = LayoutParamPolicies.MatchParent;


            _label = new TextLabel();
            root.Add(_label);
            _label.Position = new Position(0, 0);
            _label.SizeWidth = 300;
            _label.SizeHeight = 100;

            var topPanel = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
            };

            for (int i = 0; i < 10; i++)
            {
                topPanel.Add(CreateButton(i, false));
            }
            root.Add(topPanel);
            topPanel.Position = new Position(0, 100);

            var bottomPanel = new View
            {
                Layout = new LinearLayout
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                BackgroundColor = Color.Yellow,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                SizeHeight = 500,
            };

            for (int i = 0; i < 10; i++)
            {
                bottomPanel.Add(CreateButton(11 + i, true));
            }

            root.Add(bottomPanel);
            bottomPanel.Position = new Position(0, 500);

            topPanel.RaiseToTop();

        }

        View CreateButton(int index, bool second)
        {
            var rnd = new Random();

            var btn = new Button
            {
                Focusable = true,
                FocusableInTouch = true,
                Text = $"Item {index}",
            };
            if (second)
                btn.BackgroundColor = Color.Red;

            btn.WidthSpecification = LayoutParamPolicies.MatchParent;
            btn.SizeHeight = 60;

            btn.FocusGained += (s, e) =>
            {
                btn.Text = $"[Item {index}]";
                _label.Text = btn.Text;
            };
            btn.FocusLost += (s, e) =>
            {
                btn.Text = $"Item {index}";
            };

            return btn;
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
