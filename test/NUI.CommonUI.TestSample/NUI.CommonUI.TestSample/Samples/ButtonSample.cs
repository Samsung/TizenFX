using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.NUI.CommonUI.Samples
{
    public class ButtonSample : IExample
    {
        private static readonly int XBase = 200;
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
            //window.KeyEvent += Window_KeyEvent;

            textButton = new Button();
            textButton.BackgroundImageURL = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            textButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            textButton.Size2D = new Size2D(300, 80);
            textButton.Position2D = new Position2D(100, 100);
            textButton.Text = "Button";
            root.Add(textButton);

            iconButton = new Button();
            iconButton.BackgroundImageURL = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            iconButton.Size2D = new Size2D(100, 100);
            iconButton.Position2D = new Position2D(600, 100);
            iconButton.IconURL = CommonResource.GetTVResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            root.Add(iconButton);

            iconTextButton = new Button();
            iconTextButton.BackgroundImageURL = CommonResource.GetTVResourcePath() + "component/c_buttonbasic/c_basic_button_white_bg_normal_9patch.png";
            iconTextButton.BackgroundImageBorder = new Rectangle(4, 4, 5, 5);
            iconTextButton.IconRelativeOrientation = Button.IconOrientation.Left;
            iconTextButton.IconURL = CommonResource.GetTVResourcePath() + "component/c_radiobutton/c_radiobutton_white_check.png";
            iconTextButton.IconPaddingTop = 20;
            iconTextButton.IconPaddingBottom = 20;
            iconTextButton.IconPaddingLeft = 20;
            iconTextButton.IconPaddingRight = 20;
            iconTextButton.Text = "IconTextButton";
            iconTextButton.TextPaddingTop = 20;
            iconTextButton.TextPaddingBottom = 20;
            iconTextButton.TextPaddingLeft = 20;
            iconTextButton.TextPaddingRight = 50;
            iconTextButton.Size2D = new Size2D(500, 300);
            iconTextButton.Position2D = new Position2D(800, 100);
            root.Add(iconTextButton);


            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            utilityBasicButton = new Button();
            utilityBasicButton.IsSelectable = true;
            utilityBasicButton.BackgroundImageURL = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png";
            utilityBasicButton.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            utilityBasicButton.ShadowImageURL = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png";
            utilityBasicButton.ShadowImageBorder = new Rectangle(5, 5, 5, 5);
            utilityBasicButton.OverlayImageURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                Other = ""
            };
            utilityBasicButton.OverlayImageBorder = new Rectangle(5, 5, 5, 5);

            utilityBasicButton.TextColorSelector = new ColorSelector
            {
                Normal = new Color(0, 0, 0, 1),
                Pressed = new Color(0, 0, 0, 0.7f),
                Selected = new Color(0.058f, 0.631f, 0.92f, 1),
                Disabled = new Color(0, 0, 0, 0.4f)
            };

            utilityBasicButton.Size2D = new Size2D(300, 80);
            utilityBasicButton.Position2D = new Position2D(XBase, 300);
            utilityBasicButton.PointSize = 20;
            utilityBasicButton.Text = "UtilityBasicButton";
            //utilityBasicButton.IsEnabled = false;
            root.Add(utilityBasicButton);


            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            utilityServiceButton = new Button();
            utilityServiceButton.BackgroundImageURL = CommonResource.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png";
            utilityServiceButton.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            utilityServiceButton.ShadowImageURL = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png";
            utilityServiceButton.ShadowImageBorder = new Rectangle(5, 5, 5, 5);
            utilityServiceButton.OverlayImageURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                Other = ""
            };
            utilityServiceButton.OverlayImageBorder = new Rectangle(5, 5, 5, 5);
            utilityServiceButton.TextColorSelector = new ColorSelector
            {
                Normal = new Color(1, 1, 1, 1),
                Pressed = new Color(1, 1, 1, 0.7f),
                Disabled = new Color(1, 1, 1, 0.4f)
            };

            utilityServiceButton.Size2D = new Size2D(300, 80);
            utilityServiceButton.Position2D = new Position2D(XBase, 500);
            utilityServiceButton.PointSize = 20;
            utilityServiceButton.Text = "ServiceBasicButton";
            root.Add(utilityServiceButton);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            utilityToggleButton = new Button();
            utilityToggleButton.IsSelectable = true;
            utilityToggleButton.BackgroundImageURLSelector = new StringSelector
            {
                Normal = CommonResource.GetFHResourcePath() + "3. Button/rectangle_toggle_btn_normal.png",
                Selected = CommonResource.GetFHResourcePath() + "3. Button/rectangle_point_btn_normal.png",
            };
                
            utilityToggleButton.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            utilityToggleButton.ShadowImageURL = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png";
            utilityToggleButton.ShadowImageBorder = new Rectangle(5, 5, 5, 5);
            utilityToggleButton.OverlayImageURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png",
                Other = ""
            };
            utilityToggleButton.OverlayImageBorder = new Rectangle(5, 5, 5, 5);
     

            utilityToggleButton.TextColorSelector = new ColorSelector
            {
                Normal = new Color(0.058f, 0.631f, 0.92f, 1),
                Selected = new Color(1, 1, 1, 1),
            };

            utilityToggleButton.Size2D = new Size2D(300, 80);
            utilityToggleButton.Position2D = new Position2D(XBase, 700);
            utilityToggleButton.PointSize = 20;
            utilityToggleButton.TextSelector = new StringSelector
            {
                Normal = "Toggle Off",
                Selected = "Toggle On"
            };
            root.Add(utilityToggleButton);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////
            utilityOvalButton = new Button();
            utilityOvalButton.IsSelectable = true;
            utilityOvalButton.BackgroundImageURLSelector = new StringSelector
            {
                Normal = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                Selected = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_select.png",
            };
            utilityOvalButton.BackgroundImageBorder = new Rectangle(5, 5, 5, 5);
            utilityOvalButton.ShadowImageURL = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_shadow.png";
            utilityOvalButton.ShadowImageBorder = new Rectangle(5, 5, 5, 5);
            utilityOvalButton.OverlayImageURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png",
                Other = ""
            };
            utilityOvalButton.OverlayImageBorder = new Rectangle(5, 5, 5, 5);

            utilityOvalButton.Size2D = new Size2D(104, 104);
            utilityOvalButton.Position2D = new Position2D(XBase, 900);
            utilityOvalButton.PointSize = 20;
            root.Add(utilityOvalButton);

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            ButtonAttributes familyBasicButtonAttributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_normal.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },

                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new ColorSelector
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
            familyBasicButton.PointSize = 20;
            familyBasicButton.Text = "FamilyBasicButton";
            root.Add(familyBasicButton);

            //////////////////////////////////////////////////////////////////////////////////////////////////
            ButtonAttributes familyServiceButtonAttributes = new ButtonAttributes
            {
                IsSelectable = false,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },

                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new ColorSelector
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
            familyServiceButton.PointSize = 20;
            familyServiceButton.Text = "FamilySeviceButton";
            root.Add(familyServiceButton);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            ButtonAttributes familyToggleButtonAttributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_toggle_btn_normal_24c447.png",
                        Selected = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png",

                    },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { Pressed = CommonResource.GetFHResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },

                TextAttributes = new TextAttributes
                {
                    PointSize = new FloatSelector { All = 20 },
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,

                    TextColor = new ColorSelector
                    {
                        Normal = new Color(0.141f, 0.769f, 0.278f, 1),
                        Selected = new Color(1, 1, 1, 1),
                    },
                }
            };
            familyToggleButton = new Button(familyToggleButtonAttributes);
            familyToggleButton.Size2D = new Size2D(300, 80);
            familyToggleButton.Position2D = new Position2D(XBase + XPadding, 700);
            familyToggleButton.PointSize = 20;
            familyToggleButton.TextSelector = new StringSelector
            {
                Normal = "Toggle Off",
                Selected = "Toggle On"
            };
            root.Add(familyToggleButton);
            //////////////////////////////////////////////////////////////////////////////////////////////////
            ButtonAttributes familyOvalButtonAttributes = new ButtonAttributes
            {
                IsSelectable = true,
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_normal.png",
                        Selected = CommonResource.GetFHResourcePath() + "3. Button/[Button] App Primary Color/oval_toggle_btn_select_24c447.png",

                    },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                ShadowImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { All = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_shadow.png" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                },

                OverlayImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector { Pressed = CommonResource.GetFHResourcePath() + "3. Button/oval_toggle_btn_press_overlay.png", Other = "" },
                    Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                },
            };
            familyOvalButton = new Button(familyOvalButtonAttributes);
            familyOvalButton.Size2D = new Size2D(104, 104);
            familyOvalButton.Position2D = new Position2D(XBase + XPadding, 900);
            familyOvalButton.PointSize = 20;
            root.Add(familyOvalButton);

        }

        private void Window_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if(e.Key.State == Key.StateType.Down)
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
                        iconTextButton.IconPaddingLeft = 50;
                        break;
                    case "6":
                        iconTextButton.IconPaddingRight = 50;
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
