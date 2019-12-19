using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ButtonSample : IExample
    {
        private static readonly int XBase = 100;
        private static readonly int YBase = 300;
        private static readonly int XPadding = 350;
        private View root;
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
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);
            window.KeyEvent += Window_KeyEvent;

            textButton = new Button();
            textButton.Style.Background.ResourceUrl = SampleResource.GetDaliResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            textButton.Style.Background.Border = new Rectangle(4, 4, 5, 5);
            textButton.Size2D = new Size2D(300, 80);
            textButton.Position2D = new Position2D(100, 100);
            textButton.Style.Text.Text = "Button";
            root.Add(textButton);

            iconButton = new Button();
            iconButton.Style.Background.ResourceUrl = SampleResource.GetDaliResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconButton.Style.Background.Border = new Rectangle(4, 4, 5, 5);
            iconButton.Size2D = new Size2D(100, 100);
            iconButton.Position2D = new Position2D(600, 100);
            iconButton.Style.Icon.ResourceUrl = SampleResource.GetDaliResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            root.Add(iconButton);

            iconTextButton = new Button();
            iconTextButton.Style.Background.ResourceUrl = SampleResource.GetDaliResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconTextButton.Style.Background.Border = new Rectangle(4, 4, 5, 5);
            iconTextButton.IconRelativeOrientation = Button.IconOrientation.Left;
            iconTextButton.Style.Icon.ResourceUrl = SampleResource.GetDaliResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            iconTextButton.Style.Icon.Padding.Top = 20;
            iconTextButton.Style.Icon.Padding.Bottom = 20;
            iconTextButton.Style.Icon.Padding.Start = 20;
            iconTextButton.Style.Icon.Padding.End = 20;
            iconTextButton.Style.Text.Text = "IconTextButton";
            iconTextButton.Style.Text.Padding.Top = 20;
            iconTextButton.Style.Text.Padding.Bottom = 20;
            iconTextButton.Style.Text.Padding.Start = 20;
            iconTextButton.Style.Text.Padding.End = 50;
            iconTextButton.Size2D = new Size2D(500, 300);
            iconTextButton.Position2D = new Position2D(900, 100);
            root.Add(iconTextButton);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            utilityBasicButton = new Button();
            utilityBasicButton.IsSelectable = true;
            utilityBasicButton.Style.Background.ResourceUrl = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_normal.png";
            utilityBasicButton.Style.Background.Border = new Rectangle(5, 5, 5, 5);
            utilityBasicButton.Style.Shadow.ResourceUrl = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_shadow.png";
            utilityBasicButton.Style.Shadow.Border = new Rectangle(5, 5, 5, 5);
            utilityBasicButton.Style.Overlay.ResourceUrl = new Selector<string>
            {
                Pressed = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                Other = ""
            };
            utilityBasicButton.Style.Overlay.Border = new Rectangle(5, 5, 5, 5);

            utilityBasicButton.Style.Text.TextColor = new Selector<Color>
            {
                Normal = new Color(0, 0, 0, 1),
                Pressed = new Color(0, 0, 0, 0.7f),
                Selected = new Color(0.058f, 0.631f, 0.92f, 1),
                Disabled = new Color(0, 0, 0, 0.4f)
            };

            utilityBasicButton.Size2D = new Size2D(300, 80);
            utilityBasicButton.Position2D = new Position2D(XBase, 300);
            utilityBasicButton.Style.Text.PointSize = 20;
            utilityBasicButton.Style.Text.Text = "UtilityBasicButton";
            //utilityBasicButton.IsEnabled = false;
            root.Add(utilityBasicButton);

            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            utilityServiceButton = new Button();
            utilityServiceButton.Style.Background.ResourceUrl = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_point_btn_normal.png";
            utilityServiceButton.Style.Background.Border = new Rectangle(5, 5, 5, 5);
            utilityServiceButton.Style.Shadow.ResourceUrl = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_shadow.png";
            utilityServiceButton.Style.Shadow.Border = new Rectangle(5, 5, 5, 5);
            utilityServiceButton.Style.Overlay.ResourceUrl = new Selector<string>
            {
                Pressed = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                Other = ""
            };
            utilityServiceButton.Style.Overlay.Border = new Rectangle(5, 5, 5, 5);
            utilityServiceButton.Style.Text.TextColor = new Selector<Color>
            {
                Normal = new Color(1, 1, 1, 1),
                Pressed = new Color(1, 1, 1, 0.7f),
                Disabled = new Color(1, 1, 1, 0.4f)
            };

            utilityServiceButton.Size2D = new Size2D(300, 80);
            utilityServiceButton.Position2D = new Position2D(XBase, 500);
            utilityServiceButton.Style.Text.PointSize = 20;
            utilityServiceButton.Style.Text.Text = "ServiceBasicButton";
            root.Add(utilityServiceButton);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            utilityToggleButton = new Button();
            utilityToggleButton.IsSelectable = true;
            utilityToggleButton.Style.Background.ResourceUrl = new Selector<string>
            {
                Normal = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_toggle_btn_normal.png",
                Selected = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_point_btn_normal.png",
            };

            utilityToggleButton.Style.Background.Border = new Rectangle(5, 5, 5, 5);
            utilityToggleButton.Style.Shadow.ResourceUrl = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_shadow.png";
            utilityToggleButton.Style.Shadow.Border = new Rectangle(5, 5, 5, 5);
            utilityToggleButton.Style.Overlay.ResourceUrl = new Selector<string>
            {
                Pressed = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                Other = ""
            };
            utilityToggleButton.Style.Overlay.Border = new Rectangle(5, 5, 5, 5);


            utilityToggleButton.Style.Text.TextColor = new Selector<Color>
            {
                Normal = new Color(0.058f, 0.631f, 0.92f, 1),
                Selected = new Color(1, 1, 1, 1),
            };

            utilityToggleButton.Size2D = new Size2D(300, 80);
            utilityToggleButton.Position2D = new Position2D(XBase, 700);
            utilityToggleButton.Style.Text.PointSize = 20;
            utilityToggleButton.Style.Text.Text = new Selector<string>
            {
                Normal = "Toggle Off",
                Selected = "Toggle On"
            };
            root.Add(utilityToggleButton);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            utilityOvalButton = new Button();
            utilityOvalButton.IsSelectable = true;
            utilityOvalButton.Style.Background.ResourceUrl = new Selector<string>
            {
                Normal = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                Selected = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_select.png",
            };
            utilityOvalButton.Style.Background.Border = new Rectangle(5, 5, 5, 5);
            utilityOvalButton.Style.Shadow.ResourceUrl = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_shadow.png";
            utilityOvalButton.Style.Shadow.Border = new Rectangle(5, 5, 5, 5);
            utilityOvalButton.Style.Overlay.ResourceUrl = new Selector<string>
            {
                Pressed = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png",
                Other = ""
            };
            utilityOvalButton.Style.Overlay.Border = new Rectangle(5, 5, 5, 5);

            utilityOvalButton.Size2D = new Size2D(104, 104);
            utilityOvalButton.Position2D = new Position2D(XBase, 900);
            utilityOvalButton.Style.Text.PointSize = 20;
            root.Add(utilityOvalButton);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            ButtonStyle familyBasicButtonAttributes = new ButtonStyle
            {
                IsSelectable = true,
                Background = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_normal.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Shadow = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
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
                }
            };
            familyBasicButton = new Button(familyBasicButtonAttributes);
            familyBasicButton.Size2D = new Size2D(300, 80);
            familyBasicButton.Position2D = new Position2D(XBase + XPadding, 300);
            familyBasicButton.Style.Text.PointSize = 20;
            familyBasicButton.Style.Text.Text = "FamilyBasicButton";
            root.Add(familyBasicButton);

            //////////////////////////////////////////////////////////////////////////////////////////////////
            ButtonStyle familyServiceButtonAttributes = new ButtonStyle
            {
                IsSelectable = false,
                Background = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = SampleResource.GetDaliResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Shadow = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
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
                }
            };
            familyServiceButton = new Button(familyServiceButtonAttributes);
            familyServiceButton.Size2D = new Size2D(300, 80);
            familyServiceButton.Position2D = new Position2D(XBase + XPadding, 500);
            familyServiceButton.Style.Text.PointSize = 20;
            familyServiceButton.Style.Text.Text = "FamilySeviceButton";
            root.Add(familyServiceButton);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            ButtonStyle familyToggleButtonAttributes = new ButtonStyle
            {
                IsSelectable = true,
                Background = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = SampleResource.GetDaliResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_24c447.png",
                        Selected = SampleResource.GetDaliResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png",

                    },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Shadow = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = SampleResource.GetDaliResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
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
                }
            };
            familyToggleButton = new Button(familyToggleButtonAttributes);
            familyToggleButton.Size2D = new Size2D(300, 80);
            familyToggleButton.Position2D = new Position2D(XBase + XPadding, 700);
            familyToggleButton.Style.Text.PointSize = 20;
            familyToggleButton.Style.Text.Text = new Selector<string>
            {
                Normal = "Toggle Off",
                Selected = "Toggle On"
            };
            root.Add(familyToggleButton);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            ButtonStyle familyOvalButtonAttributes = new ButtonStyle
            {
                IsSelectable = true,
                Background = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                        Selected = SampleResource.GetDaliResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_24c447.png",

                    },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Shadow = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { All = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_shadow.png" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) }
                },

                Overlay = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string> { Pressed = SampleResource.GetDaliResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png", Other = "" },
                    Border = new Selector<Rectangle> { All = new Rectangle(5, 5, 5, 5) },
                },
            };
            familyOvalButton = new Button(familyOvalButtonAttributes);
            familyOvalButton.Size2D = new Size2D(104, 104);
            familyOvalButton.Position2D = new Position2D(XBase + XPadding, 900);
            familyOvalButton.Style.Text.PointSize = 20;
            root.Add(familyOvalButton);
        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                switch (e.Key.KeyPressedName)
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
                        iconTextButton.Style.Icon.Padding.Start = 50;
                        break;
                    case "6":
                        iconTextButton.Style.Icon.Padding.End = 50;
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
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
