using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class DropDownSample : IExample
    {
        private View root;

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
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
                BackgroundColor = Color.White,
            };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            createText[0] = new TextLabel();
            createText[0].Text = "Create DropDown just by properties";
            createText[0].Size2D = new Size2D(450, 100);
            createText[0].Position2D = new Position2D(200, 100);
            createText[0].MultiLine = true;
            root.Add(createText[0]);

            #region CreateByProperty
            dropDown = new DropDown();
            dropDown.Size2D = new Size2D(900, 108);
            dropDown.Position2D = new Position2D(50, 300);
            dropDown.Style.HeaderText.Text = "TitleArea";
            dropDown.Style.HeaderText.TextColor = new Color(0, 0, 0, 1);
            dropDown.Style.HeaderText.PointSize = 28;
            dropDown.Style.HeaderText.FontFamily = "SamsungOneUI 500C";
            dropDown.Style.Button.Text.Text = "DropDown Text";
            dropDown.Style.Button.Text.TextColor = new Color(0, 0, 0, 1);
            dropDown.Style.Button.Text.PointSize = 20;
            dropDown.Style.Button.Text.FontFamily = "SamsungOneUI 500";
            dropDown.Style.Button.Icon.ResourceUrl = CommonResource.GetFHResourcePath() + "6. List/list_ic_dropdown.png";
            dropDown.Style.Button.Icon.Size = new Size(48, 48);
            dropDown.Style.Button.IconRelativeOrientation = Button.IconOrientation.Right;
            dropDown.Style.Button.PositionX = 56;
            dropDown.SpaceBetweenButtonTextAndIcon = 8;
            dropDown.Style.ListBackgroundImage.ResourceUrl = CommonResource.GetFHResourcePath() + "10. Drop Down/dropdown_bg.png";
            dropDown.Style.ListBackgroundImage.Border = new Rectangle(51, 51, 51, 51);
            dropDown.Style.ListBackgroundImage.Size = new Size(360, 500);
            dropDown.ListMargin.Start = 20;
            dropDown.ListMargin.Top = 20;
            dropDown.ListPadding = new Extents(4, 4, 4, 4);
            root.Add(dropDown);

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
            //dropDown.DeleteItem(1);

            //DropDown.DropDownItemData insertItem = new DropDown.DropDownItemData();
            //insertItem.Size2D = new Size2D(360, 96);
            //insertItem.BackgroundColorSelector = new Selector<Color>
            //{
            //    Pressed = new Color(0, 0, 0, 0.4f),
            //    Other = new Color(1, 1, 1, 0),
            //};
            //insertItem.Text = "Insert Normal list ";
            //insertItem.PointSize = 18;
            //insertItem.FontFamily = "SamsungOne 500";
            //insertItem.TextPosition2D = new Position2D(28, 0);
            //insertItem.CheckImageSize = new Size2D(40, 40);
            //insertItem.CheckImageResourceUrl = CommonReosurce.GetFHResourcePath() + "10. Drop Down/dropdown_checkbox_on.png";
            //insertItem.CheckImageRightSpace = 16;
            //dropDown.InsertItem(insertItem, 1);
            ////////Attach scrollbar///////////
            scrollBar = new ScrollBar();
            scrollBar.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar.Position2D = new Position2D(394, 2);
            scrollBar.Size2D = new Size2D(4, 446);
            scrollBar.Style.Track.BackgroundColor = Color.Green;
            scrollBar.Style.Thumb.Size = new Size(4, 30);
            scrollBar.Style.Thumb.BackgroundColor = Color.Yellow;
            scrollBar.Style.Track.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            dropDown.AttachScrollBar(scrollBar);

            #endregion
            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create DropDown just by Attributes";
            createText[1].Size2D = new Size2D(450, 100);
            createText[1].Position2D = new Position2D(1000, 100);
            createText[1].MultiLine = true;
            root.Add(createText[1]);

            #region CreateByAttributes

            DropDownStyle attrs = new DropDownStyle
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

            dropDown2 = new DropDown(attrs);
            dropDown2.Size2D = new Size2D(900, 108);
            dropDown2.Position2D = new Position2D(1000, 300);
            root.Add(dropDown2);

            DropDownItemStyle itemAttrs = new DropDownItemStyle
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
                DropDown.DropDownDataItem item = new DropDown.DropDownDataItem(itemAttrs);
                item.Size = new Size(360, 96);
                item.Text = "Normal list " + i;
                dropDown2.AddItem(item);
            }
            dropDown2.SelectedItemIndex = 0;

            ////////Attach scrollbar///////////
            scrollBar2 = new ScrollBar();
            scrollBar2.Direction = ScrollBar.DirectionType.Vertical;
            scrollBar2.Position2D = new Position2D(394, 2);
            scrollBar2.Size2D = new Size2D(4, 446);
            scrollBar2.Style.Track.BackgroundColor = Color.Green;
            scrollBar2.Style.Thumb.Size = new Size(4, 30);
            scrollBar2.Style.Thumb.BackgroundColor = Color.Yellow;
            scrollBar2.Style.Track.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";
            dropDown2.AttachScrollBar(scrollBar2);

            #endregion
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

                    root.Remove(dropDown);
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

                    root.Remove(dropDown2);
                    dropDown2.Dispose();
                    dropDown2 = null;
                }

                if (createText[0] != null)
                {
                    root.Remove(createText[0]);
                    createText[0].Dispose();
                    createText[0] = null;
                }
                if (createText[1] != null)
                {
                    root.Remove(createText[1]);
                    createText[1].Dispose();
                    createText[1] = null;
                }

                Window.Instance.Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
