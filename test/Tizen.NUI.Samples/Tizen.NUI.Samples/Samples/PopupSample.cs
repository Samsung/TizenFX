using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PopupSample : IExample
    {
        private View root;

        private TextLabel[] createText = new TextLabel[2];

        private Popup popup = null;
        private Popup popup2 = null;
        private TextLabel contentText = null;
        private TextLabel contentText2 = null;
        private int index = 0;
        private int index2 = 0;
        private Button button = null;

        private static string[] buttonStyles = new string[]
        {
            "UtilityPopupButton",
            "FamilyPopupButton",
            "FoodPopupButton",
            "KitchenPopupButton",
        };
        private static Color[] color = new Color[]
        {
            new Color(0.05f, 0.63f, 0.9f, 1),//#ff0ea1e6
            new Color(0.14f, 0.77f, 0.28f, 1),//#ff24c447
            new Color(0.75f, 0.46f, 0.06f, 1),//#ffec7510
            new Color(0.59f, 0.38f, 0.85f, 1),//#ff9762d9
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
            createText[0].Text = "Create Popup just by properties";
            createText[0].Size2D = new Size2D(500, 100);
            createText[0].Position2D = new Position2D(500, 50);
            root.Add(createText[0]);

            popup = new Popup();
            popup.MinimumSize = new Size2D(1032, 184);
            popup.Size = new Size(1032, 400);
            popup.Position = new Position(200, 100);

            // Title
            popup.Style.Title.PointSize = 25;
            popup.Style.Title.SizeHeight = 68;
            popup.Style.Title.HorizontalAlignment = HorizontalAlignment.Begin;
            popup.Style.Title.Position = new Position(64, 52);
            popup.Style.Title.Text = "Popup Title";

            // Shadow and background
		    popup.Style.ShadowExtents = new Extents(24, 24, 24, 24);
            popup.ShadowImage = CommonResource.GetFHResourcePath() + "11. Popup/popup_background_shadow.png";
            popup.ShadowImageBorder = new Rectangle(0, 0, 105, 105);
            popup.BackgroundImage = CommonResource.GetFHResourcePath() + "11. Popup/popup_background.png";
            popup.BackgroundImageBorder = new Rectangle(0, 0, 81, 81);

            // Buttons
            popup.AddButton("Yes");
            popup.AddButton("Exit");
            popup.ButtonBackground = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png";
            popup.ButtonBackgroundBorder = new Rectangle(5, 5, 5, 5);
            popup.ButtonOverLayBackgroundColorSelector = new Selector<Color>
            {
                Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
            };
            popup.ButtonShadow = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png";
            popup.ButtonShadowBorder = new Rectangle(5, 5, 5, 5);
            popup.ButtonTextColor = color[0];
            popup.ButtonHeight = 132;
            popup.PopupButtonClickEvent += PopupButtonClickedEvent;
            popup.LayoutDirectionChanged += PopupLayoutDirectionChanged;
            popup.Post(window);

            contentText = new TextLabel();
            contentText.Size2D = new Size2D(904, 100);
            contentText.PointSize = 20;
            contentText.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            contentText.Text = "Popup ButtonStyle is " + buttonStyles[index];
            contentText.TextColor = new Color(0,0,222,1);
            popup.AddContentText(contentText);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create Popup just by Attributes";
            createText[1].Size2D = new Size2D(500, 100);
            createText[1].Position2D = new Position2D(500, 550);
            root.Add(createText[1]);

            PopupStyle attrs = new PopupStyle
            {
                MinimumSize = new Size2D(1032, 184),
                ShadowExtents = new Extents(24, 24, 24, 24),
                BackgroundImage = new Selector<string> { All = CommonResource.GetFHResourcePath() + "11. Popup/popup_background.png" },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(0, 0, 81, 81) },
                Shadow = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = CommonResource.GetFHResourcePath() + "11. Popup/popup_background_shadow.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(0, 0, 105, 105) }
                },
                Title = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 25 },
                    TextColor = new Selector<Color> { All = Color.Black },
                    Size = new Size(0, 68),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Begin,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Position = new Position(64, 52),
                    Text = new Selector<string> { All = "Popup Title" },
                },
                Buttons = new ButtonStyle
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.BottomLeft,
                    BackgroundImage = new Selector<string> { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                    BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                    Shadow = new ImageViewStyle
                    {
                        ResourceUrl = new Selector<string> { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                        Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                    },
                    Overlay = new ImageViewStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        BackgroundColor = new Selector<Color>
                        {
                            Normal = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                            Pressed = new Color(0.0f, 0.0f, 0.0f, 0.1f),
                            Selected = new Color(1.0f, 1.0f, 1.0f, 1.0f),
                        }
                    },
                    Text = new TextLabelStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextColor = new Selector<Color> { All = color[index2] },
                    },
                },
            };

            popup2 = new Popup(attrs);
            popup2.Size = new Size(1032, 400);
            popup2.Position = new Position(200, 600);     
            popup2.AddButton("Yes");
            popup2.AddButton("Exit");
            popup2.ButtonHeight = 132;
            popup2.PopupButtonClickEvent += PopupButtonClickedEvent;
            popup2.LayoutDirectionChanged += Popup2LayoutDirectionChanged;
            popup2.Post(window);

            contentText2 = new TextLabel();
            contentText2.Size2D = new Size2D(904, 100);
            contentText2.PointSize = 20;
            contentText2.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText2.VerticalAlignment = VerticalAlignment.Center;
            contentText2.Text = "Popup2 ButtonStyle is " + buttonStyles[index];
            popup2.ContentView.Add(contentText2);

            button = new Button();
            button.Style.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            button.Style.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            button.Size2D = new Size2D(580, 80);
            button.Position2D = new Position2D(1300, 500);
            button.Style.Text.Text = "LayoutDirection is left to right";
            button.ClickEvent += ButtonClickEvent;
            root.Add(button);
        }

        private void Popup2LayoutDirectionChanged(object sender, View.LayoutDirectionChangedEventArgs e)
        {
            if (contentText2.HorizontalAlignment == HorizontalAlignment.Begin)
            {
                contentText2.HorizontalAlignment = HorizontalAlignment.End;
            }
            else if (contentText2.HorizontalAlignment == HorizontalAlignment.End)
            {
                contentText2.HorizontalAlignment = HorizontalAlignment.Begin;
            }
        }

        private void PopupLayoutDirectionChanged(object sender, View.LayoutDirectionChangedEventArgs e)
        {
            if (contentText.HorizontalAlignment == HorizontalAlignment.Begin)
            {
                contentText.HorizontalAlignment = HorizontalAlignment.End;
            }
            else if (contentText.HorizontalAlignment == HorizontalAlignment.End)
            {
                contentText.HorizontalAlignment = HorizontalAlignment.Begin;
            }
        }

        private void PopupButtonClickedEvent(object sender, Popup.ButtonClickEventArgs e)
        {
            Popup obj = sender as Popup;
            if (obj != null && e.ButtonIndex == 0)
            {
                if(obj == popup)
                {
                    index++;
                    index = index % buttonStyles.Length;
                    obj.ButtonTextColor = color[index];
                    contentText.Text = "Popup ButtonStyle is " + buttonStyles[index];
                }
                else
                {
                    index2++;
                    index2 = index2 % buttonStyles.Length;
                    obj.ButtonTextColor = color[index2];
                    contentText2.Text = "Popup2 ButtonStyle is " + buttonStyles[index2];
                }               
            }
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            if (popup.LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                popup.LayoutDirection = ViewLayoutDirectionType.RTL;
                popup2.LayoutDirection = ViewLayoutDirectionType.RTL;
                button.Style.Text.Text = "LayoutDirection is right to left";
            }
            else
            {
                popup.LayoutDirection = ViewLayoutDirectionType.LTR;
                popup2.LayoutDirection = ViewLayoutDirectionType.LTR;
                button.Style.Text.Text = "LayoutDirection is left to right";
            }           
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (popup != null)
                {
                    if (contentText != null)
                    {
                        popup.ContentView.Remove(contentText);
                        contentText.Dispose();
                        contentText = null;
                    }

                    root.Remove(popup);
                    popup.Dispose();
                    popup = null;
                }

                if (popup2 != null)
                {
                    if (contentText2 != null)
                    {
                        popup2.ContentView.Remove(contentText2);
                        contentText2.Dispose();
                        contentText2 = null;
                    }

                    root.Remove(popup2);
                    popup2.Dispose();
                    popup2 = null;
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

                if (button != null)
                {
                    root.Remove(button);
                    button.Dispose();
                    button = null;
                }

                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
