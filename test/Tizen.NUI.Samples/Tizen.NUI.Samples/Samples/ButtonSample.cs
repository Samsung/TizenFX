using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ButtonSample : IExample
    {
        private View root;
        private View parent1;
        private View parent2;
        private View parent3;
        Button textButton;
        Button iconButton;

        Button iconTextButton;

        Button utilityBasicButton;
        Button utilityServiceButton;
        Button utilityToggleButton;
        Button utilityOvalButton;

        Button familyBasicButton;
        Button familyServiceButton;
        Button familyToggleButton;
        Button familyOvalButton;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Center,
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size(50, 50),
                }
            };
            window.Add(root);
            window.KeyEvent += Window_KeyEvent;

            parent1 = new View()
            {
                Size = new Size(300, 900),
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size(50, 50),
                }
            };

            parent2 = new View()
            {
                Size = new Size(300, 900),
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size(50, 50),
                }
            };

            // Only show a text button.
            textButton = new Button();
            textButton.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            textButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            textButton.Size = new Size(300, 80);
            textButton.TextLabel.Text = "Button";
            parent1.Add(textButton);

            //Only show an icon button.
            iconButton = new Button();
            iconButton.Text = "";
            iconButton.Name = "IconButton";
            iconButton.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            iconButton.Size = new Size(80, 80);
            iconButton.Icon.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            parent2.Add(iconButton);
            iconButton.Clicked += (ojb, e) => {
                var btn = iconButton.Icon.GetParent() as Button;
                string name = btn.Name;
            };

            parent3 = new View()
            {
                Size = new Size(600, 400),
                Layout = new LinearLayout()
                {
                    LinearAlignment = LinearLayout.Alignment.Top,
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size(50, 50),
                }
            };

            //Show a button with icon and text.
            iconTextButton = new Button();
            iconTextButton.Text = "IconTextButton";
            iconTextButton.BackgroundImage = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconTextButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            iconTextButton.IconRelativeOrientation = Button.IconOrientation.Left;
            iconTextButton.Icon.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            iconTextButton.IconPadding = new Extents(20, 20, 20, 20);
            iconTextButton.TextPadding = new Extents(20, 50, 20, 20);
            iconTextButton.Size = new Size(500, 300);
            parent3.Add(iconTextButton);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            //Create utility basic style of button.
            var utilityBasicButtonStyle = new ButtonStyle()
            {
                Overlay = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>
                    {
                        Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                        Other = ""
                    },
                    Border = new Rectangle(5, 5, 5, 5)
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 0.7f),
                        Selected = new Color(0.058f, 0.631f, 0.92f, 1),
                        Disabled = new Color(0, 0, 0, 0.4f)
                    },
                    Text = "UtilityBasicButton",
                    PointSize = 20,
                },
                BackgroundImage = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png",
                BackgroundImageBorder = new Rectangle(5, 5, 5, 5),
            };
            utilityBasicButton = new Button();
            utilityBasicButton.ApplyStyle(utilityBasicButtonStyle);
            utilityBasicButton.IsSelectable = true;
            utilityBasicButton.ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5));
            utilityBasicButton.Size = new Size(300, 80);
            utilityBasicButton.IsEnabled = false;
            parent1.Add(utilityBasicButton);

            //Create utility service style of button.
            var utilityServiceButtonStyle = new ButtonStyle()
            {
                Overlay = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>
                    {
                        Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                        Other = ""
                    },
                    Border = new Rectangle(5, 5, 5, 5)
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(1, 1, 1, 1),
                        Pressed = new Color(1, 1, 1, 0.7f),
                        Disabled = new Color(1, 1, 1, 0.4f)
                    },
                    Text = "ServiceBasicButton",
                    PointSize = 20,
                },
                BackgroundImage = CommonResource.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png",
                BackgroundImageBorder = new Rectangle(5, 5, 5, 5)
            };
            utilityServiceButton = new Button();
            utilityServiceButton.ApplyStyle(utilityServiceButtonStyle);
            utilityServiceButton.ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5));

            utilityServiceButton.Size = new Size(300, 80);
            parent1.Add(utilityServiceButton);

            //Create utility toggle style of button.
            var utilityToggleButtonStyle = new ButtonStyle()
            {
                BackgroundImage = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "3. Button/rectangle_toggle_btn_normal.png",
                    Selected = CommonResource.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png",
                },
                Overlay = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>
                    {
                        Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                        Other = ""
                    }
                },
                Text = new TextLabelStyle()
                {
                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0.058f, 0.631f, 0.92f, 1),
                        Selected = new Color(1, 1, 1, 1),
                    },
                    Text = new Selector<string>
                    {
                        Normal = "Toggle Off",
                        Selected = "Toggle On"
                    },
                    PointSize = 20
                },
                BackgroundColor = new Selector<Color>()
            };
            utilityToggleButton = new Button();
            utilityToggleButton.ApplyStyle(utilityToggleButtonStyle);
            utilityToggleButton.IsSelectable = true;
            utilityToggleButton.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            utilityToggleButton.ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5));
            utilityToggleButton.OverlayImage.Border = new Rectangle(5, 5, 5, 5);

            utilityToggleButton.Size = new Size(300, 80);
            parent1.Add(utilityToggleButton);

            //Create utility oval style of button.
            var utilityOvalButtonStyle = new ButtonStyle()
            {
                BackgroundImage = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                    Selected = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_select.png",
                },
                Overlay = new ImageViewStyle()
                {
                    ResourceUrl = new Selector<string>
                    {
                        Pressed = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png",
                        Other = ""
                    }
                },
                Text = new TextLabelStyle()
                {
                    Text = "",
                },
                BackgroundColor = new Selector<Color>(),
            };
            utilityOvalButton = new Button();
            utilityOvalButton.ApplyStyle(utilityOvalButtonStyle);
            utilityOvalButton.IsSelectable = true;
            utilityOvalButton.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            utilityOvalButton.ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_shadow.png", new Rectangle(5, 5, 5, 5));
            utilityOvalButton.OverlayImage.Border = new Rectangle(5, 5, 5, 5);

            utilityOvalButton.Size = new Size(104, 104);
            utilityOvalButton.TextLabel.PointSize = 20;
            parent1.Add(utilityOvalButton);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            //Create family basic style of Button.
            ButtonStyle familyBasicButtonStyle = new ButtonStyle
            {
                IsSelectable = true,
                BackgroundImage = new Selector<string> { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5)),

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                },

                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0, 0, 0, 1),
                        Pressed = new Color(0, 0, 0, 0.7f),
                        Selected = new Color(0.141f, 0.769f, 0.278f, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                    },
                    Text = "FamilyBasicButton",
                }
            };
            familyBasicButton = new Button(familyBasicButtonStyle);
            familyBasicButton.Size = new Size(300, 80);
            parent2.Add(familyBasicButton);

            //Create family service style of button.
            ButtonStyle familyServiceButtonStyle = new ButtonStyle
            {
                IsSelectable = false,
                BackgroundImage = new Selector<string> { All = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png" },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },

                ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5)),

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                },

                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(1, 1, 1, 1),
                        Pressed = new Color(1, 1, 1, 0.7f),
                        Disabled = new Color(1, 1, 1, 0.4f),
                    },
                    Text = "FamilySeviceButton"
                }
            };
            familyServiceButton = new Button(familyServiceButtonStyle);
            familyServiceButton.Size = new Size(300, 80);
            parent2.Add(familyServiceButton);

            //Create family toggle style of button.
            ButtonStyle familyToggleButtonStyle = new ButtonStyle
            {
                IsSelectable = true,
                BackgroundImage = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_24c447.png",
                    Selected = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png",
                },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },

                ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png", new Rectangle(5, 5, 5, 5)),

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                },

                Text = new TextLabelStyle
                {
                    PointSize = new Selector<float?> { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new Selector<Color>
                    {
                        Normal = new Color(0.141f, 0.769f, 0.278f, 1),
                        Selected = new Color(1, 1, 1, 1),
                    },
                    Text = new Selector<string>
                    {
                        Normal = "Toggle Off",
                        Selected = "Toggle On"
                    }
                }
            };
            familyToggleButton = new Button(familyToggleButtonStyle);
            familyToggleButton.Size = new Size(300, 80);
            parent2.Add(familyToggleButton);

            //Create family oval style of button.
            ButtonStyle familyOvalButtonStyle = new ButtonStyle
            {
                IsSelectable = true,
                BackgroundImage = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                    Selected = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_24c447.png",
                },
                BackgroundImageBorder = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },

                ImageShadow = new ImageShadow(CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_shadow.png", new Rectangle(5, 5, 5, 5)),

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                },
            };
            familyOvalButton = new Button(familyOvalButtonStyle);
            familyOvalButton.Size = new Size(104, 104);
            parent2.Add(familyOvalButton);

            // Add three layout into root
            root.Add(parent1);
            root.Add(parent2);
            root.Add(parent3);
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if(e.Key.State == Key.StateType.Up)
            {
                switch(e.Key.KeyPressedName)
                {
                    case "1":
                        iconTextButton.IconRelativeOrientation = Button.IconOrientation.Right;
                        break;
                    case "2":
                        iconTextButton.IconRelativeOrientation = Button.IconOrientation.Top;
                        break;
                    case "3":
                        iconTextButton.IconRelativeOrientation = Button.IconOrientation.Bottom;
                        break;
                    case "4":
                        iconTextButton.IconRelativeOrientation = Button.IconOrientation.Left;
                        break;
                    case "5":
                        iconTextButton.Icon.Padding.Start = 50;
                        break;
                    case "6":
                        iconTextButton.Icon.Padding.End = 50;
                        break;
                    case "7":
                        iconTextButton.LayoutDirection = ViewLayoutDirectionType.RTL;
                        break;
                    case "8":
                        iconTextButton.LayoutDirection = ViewLayoutDirectionType.LTR;
                        break;
                }
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                parent1.Remove(textButton);
                textButton.Dispose();
                textButton = null;
                parent1.Remove(utilityBasicButton);
                utilityBasicButton.Dispose();
                utilityBasicButton = null;
                parent1.Remove(utilityServiceButton);
                utilityServiceButton.Dispose();
                utilityServiceButton = null;
                parent1.Remove(utilityToggleButton);
                utilityToggleButton.Dispose();
                utilityToggleButton = null;
                parent1.Remove(utilityOvalButton);
                utilityOvalButton.Dispose();
                utilityOvalButton = null;

                parent1.Remove(familyBasicButton);
                familyBasicButton.Dispose();
                familyBasicButton = null;
                parent1.Remove(familyServiceButton);
                familyServiceButton.Dispose();
                familyServiceButton = null;
                parent1.Remove(familyToggleButton);
                familyToggleButton.Dispose();
                familyToggleButton = null;
                parent1.Remove(familyOvalButton);
                familyOvalButton.Dispose();
                familyOvalButton = null;

                parent3.Remove(iconTextButton);
                iconTextButton.Dispose();
                iconTextButton = null;

                root.Remove(parent1);
                parent1.Dispose();
                parent1 = null;

                root.Remove(parent2);
                parent2.Dispose();
                parent2 = null;

                root.Remove(parent3);
                parent3.Dispose();
                parent3 = null;

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
