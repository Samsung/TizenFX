using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class TextEditorLayoutTest : IExample
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
                BackgroundColor = Color.White,
            };
            rootView.Add(mainView);

            var absoluteViewTitle = new TextLabel()
            {
                Text = "AbsoluteLayout",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            mainView.Add(absoluteViewTitle);

            var absoluteView = new View()
            {
                Layout = new AbsoluteLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 300,
                BackgroundColor = Color.White,
            };
            mainView.Add(absoluteView);

            var absoluteTopText = new TextEditor()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            absoluteTopText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"AbsoluteLayout Top Text has been changed to \"{args.TextEditor.Text}\".");
            };
            absoluteView.Add(absoluteTopText);

            var absoluteCenterText = new TextEditor()
            {
                Text = "Center\nNew Line",
                BackgroundColor = Color.Blue,
                ParentOrigin = new Position(0.5f, 0.5f, 0.5f),
                PivotPoint = new Position(0.5f, 0.5f, 0.5f),
                PositionUsesPivotPoint = true,
            };
            absoluteCenterText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"AbsoluteLayout Center Text has been changed to \"{args.TextEditor.Text}\".");
            };
            absoluteView.Add(absoluteCenterText);

            var absoluteBottomText = new TextEditor()
            {
                Text = "Bottom\nNew Line",
                BackgroundColor = Color.Green,
                ParentOrigin = new Position(0.5f, 1.0f, 0.5f),
                PivotPoint = new Position(0.5f, 1.0f, 0.5f),
                PositionUsesPivotPoint = true,
            };
            absoluteBottomText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"AbsoluteLayout Bottom Text has been changed to \"{args.TextEditor.Text}\".");
            };
            absoluteView.Add(absoluteBottomText);

            var linearViewTitle = new TextLabel()
            {
                Text = "LinearLayout",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            mainView.Add(linearViewTitle);

            var linearView = new View()
            {
                Layout = new LinearLayout()
                {
                    CellPadding = new Size2D(10, 0),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(linearView);

            var linearLeft = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            linearView.Add(linearLeft);

            var linearLeftText1 = new TextEditor()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            linearLeftText1.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Left default size Text has been changed to \"{args.TextEditor.Text}\".");
            };
            linearLeft.Add(linearLeftText1);

            var linearLeftText2 = new TextEditor()
            {
                PixelSize = 16,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            linearLeftText2.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Left PixelSize 16 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            linearLeft.Add(linearLeftText2);

            var linearLeftText3 = new TextEditor()
            {
                PixelSize = 64,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            linearLeftText3.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Left PixelSize 64 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            linearLeft.Add(linearLeftText3);

            var linearLeftText4 = new TextEditor()
            {
                BackgroundColor = Color.Red,
            };
            linearLeftText4.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Left Text with WrapContent WidthSpecification has been changed to \"{args.TextEditor.Text}\".");
            };
            linearLeft.Add(linearLeftText4);

            var linearRight = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size2D(0, 10),
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            linearView.Add(linearRight);

            var linearRightText1 = new TextEditor()
            {
                Text = "Default\nNew Line",
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            linearRightText1.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Right default size Text has been changed to \"{args.TextEditor.Text}\".");
            };
            linearRight.Add(linearRightText1);

            var linearRightText2 = new TextEditor()
            {
                Text = "16\nNew Line",
                PixelSize = 16,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            linearRightText2.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Right PixelSize 16 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            linearRight.Add(linearRightText2);

            var linearRightText3 = new TextEditor()
            {
                Text = "64\nNew Line",
                PixelSize = 64,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.Red,
            };
            linearRightText3.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Right PixelSize 64 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            linearRight.Add(linearRightText3);

            var linearRightText4 = new TextEditor()
            {
                Text = "WrapContent\nNew Line",
                BackgroundColor = Color.Red,
            };
            linearRightText4.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"LinearLayout Right Text with WrapContent WidthSpecification has been changed to \"{args.TextEditor.Text}\".");
            };
            linearRight.Add(linearRightText4);

            var gridViewTitle = new TextLabel()
            {
                Text = "GridLayout",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            mainView.Add(gridViewTitle);

            var gridView = new View()
            {
                Layout = new GridLayout()
                {
                    Rows = 5,
                    Columns = 2,
                    RowSpacing = 10,
                    ColumnSpacing = 10,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(gridView);

            var gridCol1Text1 = new TextEditor()
            {
                BackgroundColor = Color.Green,
            };
            gridCol1Text1.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 1 default size Text has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol1Text1, 0);
            GridLayout.SetColumn(gridCol1Text1, 0);
            GridLayout.SetHorizontalStretch(gridCol1Text1, GridLayout.StretchFlags.ExpandAndFill);
            GridLayout.SetVerticalStretch(gridCol1Text1, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol1Text1);

            var gridCol1Text2 = new TextEditor()
            {
                PixelSize = 16,
                BackgroundColor = Color.Green,
            };
            gridCol1Text2.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 1 PixelSize 16 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol1Text2, 1);
            GridLayout.SetColumn(gridCol1Text2, 0);
            GridLayout.SetHorizontalStretch(gridCol1Text2, GridLayout.StretchFlags.ExpandAndFill);
            GridLayout.SetVerticalStretch(gridCol1Text2, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol1Text2);

            var gridCol1Text3 = new TextEditor()
            {
                PixelSize = 64,
                BackgroundColor = Color.Green,
            };
            gridCol1Text3.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 1 PixelSize 64 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol1Text3, 2);
            GridLayout.SetColumn(gridCol1Text3, 0);
            GridLayout.SetHorizontalStretch(gridCol1Text3, GridLayout.StretchFlags.ExpandAndFill);
            GridLayout.SetVerticalStretch(gridCol1Text3, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol1Text3);

            var gridCol1Text4 = new TextEditor()
            {
                BackgroundColor = Color.Green,
            };
            gridCol1Text4.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 1 Text with Fill has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol1Text4, 3);
            GridLayout.SetColumn(gridCol1Text4, 0);
            GridLayout.SetHorizontalStretch(gridCol1Text4, GridLayout.StretchFlags.Fill);
            GridLayout.SetVerticalStretch(gridCol1Text4, GridLayout.StretchFlags.Fill);
            gridView.Add(gridCol1Text4);

            var gridCol1Text5 = new TextEditor()
            {
                BackgroundColor = Color.Green,
            };
            gridCol1Text5.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 1 Text with Expand has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol1Text5, 4);
            GridLayout.SetColumn(gridCol1Text5, 0);
            GridLayout.SetHorizontalStretch(gridCol1Text5, GridLayout.StretchFlags.Expand);
            GridLayout.SetVerticalStretch(gridCol1Text5, GridLayout.StretchFlags.Expand);
            gridView.Add(gridCol1Text5);

            var gridCol2Text1 = new TextEditor()
            {
                Text = "Default\nNew Line",
                BackgroundColor = Color.Green,
            };
            gridCol2Text1.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 2 default size Text has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol2Text1, 0);
            GridLayout.SetColumn(gridCol2Text1, 1);
            GridLayout.SetHorizontalStretch(gridCol2Text1, GridLayout.StretchFlags.ExpandAndFill);
            GridLayout.SetVerticalStretch(gridCol2Text1, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol2Text1);

            var gridCol2Text2 = new TextEditor()
            {
                Text = "16\nNew Line",
                PixelSize = 16,
                BackgroundColor = Color.Green,
            };
            gridCol2Text2.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 2 PixelSize 16 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol2Text2, 1);
            GridLayout.SetColumn(gridCol2Text2, 1);
            GridLayout.SetHorizontalStretch(gridCol2Text2, GridLayout.StretchFlags.ExpandAndFill);
            GridLayout.SetVerticalStretch(gridCol2Text2, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol2Text2);

            var gridCol2Text3 = new TextEditor()
            {
                Text = "64\nNew Line",
                PixelSize = 64,
                BackgroundColor = Color.Green,
            };
            gridCol2Text3.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 2 PixelSize 64 Text has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol2Text3, 2);
            GridLayout.SetColumn(gridCol2Text3, 1);
            GridLayout.SetHorizontalStretch(gridCol2Text3, GridLayout.StretchFlags.ExpandAndFill);
            GridLayout.SetVerticalStretch(gridCol2Text3, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol2Text3);

            var gridCol2Text4 = new TextEditor()
            {
                Text = "Fill\nNew Line",
                BackgroundColor = Color.Green,
            };
            gridCol2Text4.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 2 Text with Fill has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol2Text4, 3);
            GridLayout.SetColumn(gridCol2Text4, 1);
            GridLayout.SetHorizontalStretch(gridCol2Text4, GridLayout.StretchFlags.Fill);
            GridLayout.SetVerticalStretch(gridCol2Text4, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol2Text4);

            var gridCol2Text5 = new TextEditor()
            {
                Text = "Expand\nNew Line",
                BackgroundColor = Color.Green,
            };
            gridCol2Text5.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"GridLayout Column 2 Text with Expand has been changed to \"{args.TextEditor.Text}\".");
            };
            GridLayout.SetRow(gridCol2Text5, 4);
            GridLayout.SetColumn(gridCol2Text5, 1);
            GridLayout.SetHorizontalStretch(gridCol2Text5, GridLayout.StretchFlags.Expand);
            GridLayout.SetVerticalStretch(gridCol2Text5, GridLayout.StretchFlags.ExpandAndFill);
            gridView.Add(gridCol2Text5);

            var relativeViewTitle = new TextLabel()
            {
                Text = "RelativeLayout",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            mainView.Add(relativeViewTitle);

            var relativeView = new View()
            {
                Layout = new RelativeLayout(),
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(relativeView);

            var relTopText = new TextEditor()
            {
                Text = "Top with Fill\nNew Line",
                HorizontalAlignment = HorizontalAlignment.Center,
                BackgroundColor = Color.Red,
            };
            relTopText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"RelativeLayout Top Text has been changed to \"{args.TextEditor.Text}\".");
            };
            RelativeLayout.SetTopRelativeOffset(relTopText, 0.0f);
            RelativeLayout.SetBottomRelativeOffset(relTopText, 0.0f);
            RelativeLayout.SetLeftRelativeOffset(relTopText, 0.0f);
            RelativeLayout.SetRightRelativeOffset(relTopText, 1.0f);
            RelativeLayout.SetFillHorizontal(relTopText, true);
            relativeView.Add(relTopText);

            var relLeftText = new TextEditor()
            {
                Text = "Left\nNew Line",
                BackgroundColor = Color.Green,
            };
            relLeftText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"RelativeLayout Left Text has been changed to \"{args.TextEditor.Text}\".");
            };
            RelativeLayout.SetTopTarget(relLeftText, relTopText);
            RelativeLayout.SetTopRelativeOffset(relLeftText, 1.0f);
            RelativeLayout.SetBottomTarget(relLeftText, relTopText);
            RelativeLayout.SetBottomRelativeOffset(relLeftText, 1.0f);
            RelativeLayout.SetLeftRelativeOffset(relLeftText, 0.0f);
            RelativeLayout.SetRightRelativeOffset(relLeftText, 0.0f);
            relativeView.Add(relLeftText);

            var relRightText = new TextEditor()
            {
                Text = "Right\nNew Line",
                BackgroundColor = Color.Blue,
            };
            relRightText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"RelativeLayout Right Text has been changed to \"{args.TextEditor.Text}\".");
            };
            RelativeLayout.SetTopTarget(relRightText, relTopText);
            RelativeLayout.SetTopRelativeOffset(relRightText, 1.0f);
            RelativeLayout.SetBottomTarget(relRightText, relTopText);
            RelativeLayout.SetBottomRelativeOffset(relRightText, 1.0f);
            RelativeLayout.SetLeftRelativeOffset(relRightText, 1.0f);
            RelativeLayout.SetRightRelativeOffset(relRightText, 1.0f);
            RelativeLayout.SetHorizontalAlignment(relRightText, RelativeLayout.Alignment.End);
            relativeView.Add(relRightText);

            var relBottomText = new TextEditor()
            {
                Text = "Bottom\nNew Line",
                BackgroundColor = Color.Yellow,
            };
            relBottomText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"RelativeLayout Bottom Text has been changed to \"{args.TextEditor.Text}\".");
            };
            RelativeLayout.SetTopRelativeOffset(relBottomText, 1.0f);
            RelativeLayout.SetBottomRelativeOffset(relBottomText, 1.0f);
            RelativeLayout.SetLeftTarget(relBottomText, relLeftText);
            RelativeLayout.SetLeftRelativeOffset(relBottomText, 1.0f);
            RelativeLayout.SetRightTarget(relBottomText, relRightText);
            RelativeLayout.SetRightRelativeOffset(relBottomText, 0.0f);
            RelativeLayout.SetHorizontalAlignment(relBottomText, RelativeLayout.Alignment.Center);
            RelativeLayout.SetVerticalAlignment(relBottomText, RelativeLayout.Alignment.End);
            relativeView.Add(relBottomText);

            var relCenterText = new TextEditor()
            {
                BackgroundColor = Color.Purple,
            };
            relCenterText.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"RelativeLayout Center Text has been changed to \"{args.TextEditor.Text}\".");
            };
            RelativeLayout.SetTopTarget(relCenterText, relTopText);
            RelativeLayout.SetTopRelativeOffset(relCenterText, 1.0f);
            RelativeLayout.SetBottomTarget(relCenterText, relBottomText);
            RelativeLayout.SetBottomRelativeOffset(relCenterText, 0.0f);
            RelativeLayout.SetLeftTarget(relCenterText, relLeftText);
            RelativeLayout.SetLeftRelativeOffset(relCenterText, 1.0f);
            RelativeLayout.SetRightTarget(relCenterText, relRightText);
            RelativeLayout.SetRightRelativeOffset(relCenterText, 0.0f);
            RelativeLayout.SetFillHorizontal(relCenterText, true);
            relativeView.Add(relCenterText);

            var flexRowViewTitle = new TextLabel()
            {
                Text = "FlexLayout with Row Direction",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            mainView.Add(flexRowViewTitle);

            var flexRowView = new View()
            {
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Row,
                    WrapType = FlexLayout.FlexWrapType.Wrap,
                    Alignment = FlexLayout.AlignmentType.Center,
                    ItemsAlignment = FlexLayout.AlignmentType.Center,
                    Justification = FlexLayout.FlexJustification.SpaceEvenly,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.White,
            };
            mainView.Add(flexRowView);

            var flexRowText1 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Red,
            };
            flexRowText1.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Row First Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexRowView.Add(flexRowText1);

            var flexRowText2 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Green,
            };
            flexRowText2.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Row Second Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexRowView.Add(flexRowText2);

            var flexRowText3 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Blue,
            };
            flexRowText3.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Row Third Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexRowView.Add(flexRowText3);

            var flexRowText4 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Yellow,
            };
            flexRowText4.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Row Fourth Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexRowView.Add(flexRowText4);

            var flexColViewTitle = new TextEditor()
            {
                Text = "FlexLayout with Column Direction",
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };
            mainView.Add(flexColViewTitle);

            var flexColView = new View()
            {
                Layout = new FlexLayout()
                {
                    Direction = FlexLayout.FlexDirection.Column,
                    WrapType = FlexLayout.FlexWrapType.Wrap,
                    Alignment = FlexLayout.AlignmentType.Center,
                    ItemsAlignment = FlexLayout.AlignmentType.Center,
                    Justification = FlexLayout.FlexJustification.SpaceEvenly,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = 300,
                BackgroundColor = Color.White,
            };
            mainView.Add(flexColView);

            var flexColText1 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Red,
            };
            flexColText1.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Column First Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexColView.Add(flexColText1);

            var flexColText2 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Green,
            };
            flexColText2.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Column Second Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexColView.Add(flexColText2);

            var flexColText3 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Blue,
            };
            flexColText3.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Column Third Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexColView.Add(flexColText3);

            var flexColText4 = new TextEditor()
            {
                Text = "TextEditor\nNew Line",
                BackgroundColor = Color.Yellow,
            };
            flexColText4.TextChanged += (object sender, TextEditor.TextChangedEventArgs args) =>
            {
                global::System.Console.WriteLine($"FlexLayout with Column Fourth Text has been changed to \"{args.TextEditor.Text}\".");
            };
            flexColView.Add(flexColText4);
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
