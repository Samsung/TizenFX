using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PopupSample : IExample
    {
        private View root;
        private View parent1;
        private View parent2;

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
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            window.Add(root);

            parent1 = new View()
            {
                Size = new Size(1920, 1080),
            };
            parent1.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                LinearAlignment = LinearLayout.Alignment.Center,
                CellPadding = new Size(50, 50)
            };

            parent2 = new View()
            {
                Size = new Size(1032, 980),
            };
            parent2.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size(400, 400)
            };
            
            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            createText[0] = new TextLabel();
            createText[0].Text = "Create Popup just by properties";
            createText[0].WidthSpecification = 500;
            createText[0].HeightSpecification = 100;
            parent2.Add(createText[0]);

            popup = new Popup();
            popup.MinimumSize = new Size(1032, 184);
            popup.Size = new Size(1032, 400);
            popup.Position = new Position(150, 100);

            // Title
            popup.Title.PointSize = 25;
            popup.Title.Size = new Size(0, 68);
            popup.Title.PositionUsesPivotPoint = true;
            popup.Title.ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft;
            popup.Title.PivotPoint = Tizen.NUI.PivotPoint.TopLeft;
            popup.Title.HorizontalAlignment = HorizontalAlignment.Begin;
            popup.Title.VerticalAlignment = VerticalAlignment.Bottom;
            popup.Title.Position = new Position(64, 52);
            popup.Title.Text = "Popup Title";
            popup.Title.Padding = 0;

            // Shadow
            popup.ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "11. Popup/popup_background_shadow.png", new Rectangle(24, 24, 24, 24), extents: new Vector2(48, 48));

            // Background
            popup.BackgroundImage = CommonResource.GetFHResourcePath() + "11. Popup/popup_background.png";
            popup.BackgroundImageBorder = new Rectangle(0, 0, 81, 81);

            // Buttons
            popup.AddButton("Yes");
            popup.AddButton("Exit");
            popup.ButtonBackground = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png";
            popup.ButtonBackgroundBorder = new Rectangle(5, 5, 5, 5);
            popup.ButtonOverLayBackgroundColorSelector = new Selector<Color>
            {
                Normal = new Color(1.0f, 1.0f, 1.0f, 0.5f),
                Pressed = new Color(0.0f, 0.0f, 0.0f, 0.5f)
            };
            popup.ButtonImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5));
            popup.ButtonTextColor = color[0];
            popup.ButtonHeight = 132;
            popup.PopupButtonClickEvent += PopupButtonClickedEvent;
            popup.LayoutDirectionChanged += PopupLayoutDirectionChanged;
            popup.Post(window);

            contentText = new TextLabel();
            contentText.Size = new Size(1032, 100);
            contentText.PointSize = 20;
            contentText.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText.VerticalAlignment = VerticalAlignment.Center;
            contentText.Text = "Popup ButtonStyle is " + buttonStyles[index];
            contentText.TextColor = new Color(0,0,222,1);
            popup.AddContentText(contentText);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create Popup just by Attributes";
            createText[1].WidthSpecification = 500;
            createText[1].HeightSpecification = 100;
            parent2.Add(createText[1]);

            PopupStyle attrs = new PopupStyle
            {
                MinimumSize = new Size(1032, 184),
                BackgroundImage = new Selector<string> { All = CommonResource.GetFHResourcePath() + "11. Popup/popup_background.png" },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(0, 0, 81, 81) },
                ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "11. Popup/popup_background_shadow.png", new Rectangle(24, 24, 24, 24), extents: new Vector2(48, 48)),
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
                    ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5)),
                    Overlay = new ImageViewStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                        BackgroundColor = new Selector<Color>
                        {
                            Normal = new Color(1.0f, 1.0f, 1.0f, 0.5f),
                            Pressed = new Color(0.0f, 0.0f, 0.0f, 0.5f),
                        }
                    },
                    Text = new TextLabelStyle
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                        PivotPoint = Tizen.NUI.PivotPoint.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        TextColor = new Selector<Color> { All = color[index2] }
                    },
                },
            };

            popup2 = new Popup(attrs);
            popup2.Size = new Size(1032, 400);
            popup2.Position = new Position(150, 600);
            popup2.AddButton("Yes");
            popup2.AddButton("Exit");
            popup2.ButtonHeight = 132;
            popup2.PopupButtonClickEvent += PopupButtonClickedEvent;
            popup2.LayoutDirectionChanged += Popup2LayoutDirectionChanged;
            popup2.Post(window);

            contentText2 = new TextLabel();
            contentText2.Size = new Size(1032, 100);
            contentText2.PointSize = 20;
            contentText2.HorizontalAlignment = HorizontalAlignment.Begin;
            contentText2.VerticalAlignment = VerticalAlignment.Center;
            contentText2.Text = "Popup2 ButtonStyle is " + buttonStyles[index];
            popup2.ContentView.Add(contentText2);

            button = new Button();
            button.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            button.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            button.WidthSpecification = 580;
            button.HeightSpecification = 80;
            button.TextLabel.Text = "LayoutDirection is left to right";
            button.Clicked += ButtonClicked;

            parent1.Add(parent2);
            parent1.Add(button);
            root.Add(parent1);
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

        private void ButtonClicked(object sender, ClickedEventArgs e)
        {
            if (popup.LayoutDirection == ViewLayoutDirectionType.LTR)
            {
                popup.LayoutDirection = ViewLayoutDirectionType.RTL;
                popup2.LayoutDirection = ViewLayoutDirectionType.RTL;
                button.TextLabel.Text = "LayoutDirection is right to left";
            }
            else
            {
                popup.LayoutDirection = ViewLayoutDirectionType.LTR;
                popup2.LayoutDirection = ViewLayoutDirectionType.LTR;
                button.TextLabel.Text = "LayoutDirection is left to right";
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
                    popup.Dismiss();
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
                    popup2.Dismiss();
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

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
