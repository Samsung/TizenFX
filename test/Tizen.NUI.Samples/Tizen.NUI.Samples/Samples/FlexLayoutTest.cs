using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class FlexLayoutTest : IExample
    {
        private Window window;
        private ScrollableBase rootView;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();

            rootView = new ScrollableBase()
            {
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                HideScrollbar = false,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            window.Add(rootView);

            var mainView = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 20),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            rootView.Add(mainView);

            var flexRowViewTitle = new TextLabel()
            {
                Text = "Row with MatchParent",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(flexRowViewTitle);

            var flexRowView = new View()
            {
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Row,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 400,
                Margin = new Extents(20, 20, 20, 20),
                Padding = new Extents(20, 20, 20, 20),
                BackgroundColor = Color.White,
            };
            mainView.Add(flexRowView);

            var rowChild = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            flexRowView.Add(rowChild);

            var rowGrandChild = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            rowChild.Add(rowGrandChild);

            var rowGrandChild2 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Green,
            };
            rowChild.Add(rowGrandChild2);

            var rowChild2 = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            flexRowView.Add(rowChild2);

            var rowGrandChild3 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Blue,
            };
            rowChild2.Add(rowGrandChild3);

            var rowGrandChild4 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Yellow,
            };
            rowChild2.Add(rowGrandChild4);

            var flexColViewTitle = new TextLabel()
            {
                Text = "Column with MatchParent",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(flexColViewTitle);

            var flexColView = new View()
            {
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 400,
                Margin = new Extents(20, 20, 20, 20),
                Padding = new Extents(20, 20, 20, 20),
                BackgroundColor = Color.White,
            };
            mainView.Add(flexColView);

            var colChild = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            flexColView.Add(colChild);

            var colGrandChild = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            colChild.Add(colGrandChild);

            var colGrandChild2 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Green,
            };
            colChild.Add(colGrandChild2);

            var colChild2 = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Black,
            };
            flexColView.Add(colChild2);

            var colGrandChild3 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Blue,
            };
            colChild2.Add(colGrandChild3);

            var colGrandChild4 = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Yellow,
            };
            colChild2.Add(colGrandChild4);
        }

        public void Deactivate()
        {
            window.Remove(rootView);
            rootView.Dispose();
            rootView = null;
            window = null;
        }
    }
}
