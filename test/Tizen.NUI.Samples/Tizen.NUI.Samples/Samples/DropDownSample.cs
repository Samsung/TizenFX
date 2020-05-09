using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class DropDownSample : IExample
    {
        private View root;
        private View parent1;
        private View parent2;

        private TextLabel[] createText = new TextLabel[2];

        private DropDown dropDown = null;
        private DropDown dropDown2 = null;
        private ScrollBar scrollBar = null;
        private ScrollBar scrollBar2 = null;

        private static string[] mode = new string[]
        {
            "Utility DropDown",
            "Family DropDown",
            "Food DropDown",
            "Kitchen DropDown",
        };
        private static Color[] color = new Color[]
        {
        new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6 Utility
        new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447 Family
        new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510 Food
        new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9 Kitchen
        };
        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.White,
            };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            parent1 = new View()
            {
                Size = new Size(900, 800),
            };

            root.Add(parent1);
            createText[0] = new TextLabel();
            createText[0].Text = "Create DropDown just by properties";
            createText[0].WidthSpecification = 450;
            createText[0].HeightSpecification = 100;
            createText[0].Position = new Position(50, 100);
            createText[0].MultiLine = true;
            parent1.Add(createText[0]);

            #region CreateByProperty
            dropDown = new DropDown();
            var style = dropDown.Style;
            style.Button.BackgroundImage = "";
            style.Button.Icon.ResourceUrl = CommonResource.GetFHResourcePath() + "6. List/list_ic_dropdown.png";
            style.Button.Text.PointSize = 20;
            style.Button.Text.FontFamily = "SamsungOneUI 500";
            style.Button.Text.TextColor = new Color(0, 0, 0, 1);
            dropDown.ApplyStyle(style);
            dropDown.WidthSpecification = 900;
            dropDown.HeightSpecification = 108;
            dropDown.Position = new Position(50, 300);
            dropDown.HeaderText.Text = "TitleArea";
            dropDown.HeaderText.TextColor = new Color(0, 0, 0, 1);
            dropDown.HeaderText.PointSize = 28;
            dropDown.HeaderText.FontFamily = "SamsungOneUI 500C";
            dropDown.Button.ButtonText.Text = "DropDown Text";
            dropDown.Button.ButtonIcon.Size = new Size(48, 48);
            dropDown.Button.IconRelativeOrientation = Button.IconOrientation.Right;
            dropDown.Button.ParentOrigin = ParentOrigin.CenterLeft;
            dropDown.Button.PivotPoint = PivotPoint.CenterLeft;
            dropDown.Button.PositionX = 56;
            dropDown.SpaceBetweenButtonTextAndIcon = 8;
            dropDown.ListBackgroundImage.ResourceUrl = CommonResource.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png";
            dropDown.ListBackgroundImage.Border = new Rectangle(51, 51, 51, 51);
            dropDown.ListBackgroundImage.Size = new Size(360, 500);
            dropDown.ListMargin.Start = 20;
            dropDown.ListMargin.Top = 20;
            dropDown.ListPadding = new Extents(4, 4, 4, 4);
            dropDown.BackgroundColor = new Color(1, 1, 1, 1);
            parent1.Add(dropDown);
            for (int i = 0; i < 8; i++)
            {
                DropDown.DropDownDataItem item = new DropDown.DropDownDataItem();
                item.Size = new Size(360, 96);
                item.BackgroundColor= new Selector<Color>
                {
                    Pressed = new Color(0, 0, 0, 0.4f),
                    Other = new Color(1, 1, 1, 0),
                };
                item.Text = "Normal list " + i;
                item.PointSize = 18;
                item.FontFamily = "SamsungOne 500";
                item.TextPosition = new Position(28, 0);
                item.CheckImageSize = new Size(40, 40);
                item.CheckImageResourceUrl = CommonResource.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png";
                item.CheckImageGapToBoundary = 16;
                dropDown.AddItem(item);
            }

            dropDown.SelectedItemIndex = 3;
            ////////Attach scrollbar///////////
            scrollBar = new ScrollBar();
            scrollBar.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar.Size = new Size(4, 446);
            scrollBar.TrackImage.BackgroundColor = Color.Green;
            scrollBar.ThumbImage.Size = new Size(4, 30);
            scrollBar.ThumbImage.BackgroundColor = Color.Yellow;
            scrollBar.TrackImage.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            dropDown.AttachScrollBar(scrollBar);

            #endregion
            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            parent2 = new View()
            {
                Size = new Size(900, 800),
            };
            root.Add(parent2);

            createText[1] = new TextLabel();
            createText[1].Text = "Create DropDown just by Attributes";
            createText[1].WidthSpecification = 450;
            createText[1].HeightSpecification = 100;
            createText[1].Position = new Position(1000, 100);
            createText[1].MultiLine = true;
            parent2.Add(createText[1]);

            #region CreateByAttributes

            DropDownStyle dropDownStyle = new DropDownStyle
            {
                HeaderText = new TextLabelStyle
                {
                    Text = new Selector<string> { All = "TitleArea" },
                    PointSize = new Selector<float?> { All = 28 },
                    TextColor = new Selector<Color> { All = new Color(0, 0, 0, 1) },
                    FontFamily = "SamsungOneUI 500C",
                },

                Button = new ButtonStyle
                {
                    Text = new TextLabelStyle
                    {
                        Text = new Selector<string> { All = "DropDown Text" },
                        PointSize = new Selector<float?> { All = 20 },
                        TextColor = new Selector<Color> { All = new Color(0, 0, 0, 1) },
                        FontFamily = "SamsungOneUI 500",
                    },
                    Icon = new ImageViewStyle
                    {
                        Size = new Size(48, 48),
                        ResourceUrl = new Selector<string> { All = CommonResource.GetFHResourcePath() + "6. List/list_ic_dropdown.png" },
                    },
                    IconRelativeOrientation = Button.IconOrientation.Right,
                    PositionX = 56,
                },
                ListBackgroundImage = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = CommonResource.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(51, 51, 51, 51) },
                    Size = new Size(360, 500),
                },
                SpaceBetweenButtonTextAndIcon = 8,
                ListMargin = new Extents(20, 0, 20, 0),
                BackgroundColor = new Selector<Color> { All = new Color(1, 1, 1, 1) },
                ListPadding = new Extents(4, 4, 4, 4),
            };

            dropDown2 = new DropDown(dropDownStyle);
            dropDown2.WidthSpecification = 900;
            dropDown2.HeightSpecification = 108;
            dropDown2.Position = new Position(1000, 300);
            parent2.Add(dropDown2);

            DropDownItemStyle itemStyle = new DropDownItemStyle
            {
                BackgroundColor = new Selector<Color>
                {
                    Pressed = new Color(0, 0, 0, 0.4f),
                    Other = new Color(1, 1, 1, 0),
                },
                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 18 },
                    FontFamily = "SamsungOne 500",
                    Position = new Position(28, 0),
                },
                CheckImage = new ImageViewStyle
                {
                    Size = new Size(40, 40),
                    ResourceUrl = new Selector<string> { All = CommonResource.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png" },
                },
                CheckImageGapToBoundary = 16,
            };

            for (int i = 0; i < 8; i++)
            {
                DropDown.DropDownDataItem item = new DropDown.DropDownDataItem(itemStyle);
                item.Size = new Size(360, 96);
                item.Text = "Normal list " + i;
                dropDown2.AddItem(item);
            }
            dropDown2.SelectedItemIndex = 0;

            ////////Attach scrollbar///////////
            scrollBar2 = new ScrollBar();
            scrollBar2.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar2.WidthSpecification = 4;
            scrollBar2.HeightSpecification = 446;
            scrollBar2.TrackImage.BackgroundColor = Color.Green;
            scrollBar2.ThumbImage.Size = new Size(4, 30);
            scrollBar2.ThumbImage.BackgroundColor = Color.Yellow;
            scrollBar2.TrackImage.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            dropDown2.AttachScrollBar(scrollBar2);

            #endregion
            root.Add(parent1);
            root.Add(parent2);
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (dropDown != null)
                {
                    if (scrollBar != null)
                    {
                        dropDown.DetachScrollBar();
                        scrollBar.Dispose();
                        scrollBar = null;
                    }

                    parent1.Remove(dropDown);
                    dropDown.Dispose();
                    dropDown = null;
                }
                if (dropDown2 != null)
                {
                    if (scrollBar2 != null)
                    {
                        dropDown2.DetachScrollBar();
                        scrollBar2.Dispose();
                        scrollBar2 = null;
                    }

                    parent2.Remove(dropDown2);
                    dropDown2.Dispose();
                    dropDown2 = null;
                }

                if (createText[0] != null)
                {
                    parent1.Remove(createText[0]);
                    createText[0].Dispose();
                    createText[0] = null;
                }
                if (createText[1] != null)
                {
                    parent2.Remove(createText[1]);
                    createText[1].Dispose();
                    createText[1] = null;
                }

                root.Remove(parent1);
                parent1.Dispose();
                parent1 = null;
                root.Remove(parent2);
                parent2.Dispose();
                parent2 = null;

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
