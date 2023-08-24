using Tizen.FH.NUI.Controls;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using StyleManager = Tizen.NUI.CommonUI.StyleManager;

namespace NuiCommonUiSamples
{
    public class SampleLayout : ImageView
    {
        private Tizen.FH.NUI.Controls.Header LayoutHeader;

        private bool isThemeButtonVisible = true;
        private Tizen.NUI.CommonUI.Button UtilityButton;
        private Tizen.NUI.CommonUI.Button FoodButton;
        private Tizen.NUI.CommonUI.Button FamilyButton;
        private Tizen.NUI.CommonUI.Button KitchenButton;

        private View Content;
        private View LayoutContent;
        public string HeaderText
        {
            get
            {
                return LayoutHeader.HeaderText;
            }

            set
            {
                LayoutHeader.HeaderText = value;
            }
        }


        public new void Add(View view)
        {
            Content.Add(view);
        }


        public SampleLayout(bool isThemeButtonVisiable = true)
        {
            Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height);
            //Window.Instance.Add(this);
            LayoutHeader = new Tizen.FH.NUI.Controls.Header("DefaultHeader");
            LayoutHeader.PositionY = 0;

            LayoutContent = new View
            {
                Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height - 128),
                Position2D = new Position2D(0, 128),
            };

            Content = new View
            {
                Size2D = new Size2D(Window.Instance.Size.Width, Window.Instance.Size.Height - 128 - 150),
                Position2D = new Position2D(0, 150),
            };
            LayoutContent.Add(Content);

            if (isThemeButtonVisiable)
            {
                ButtonAttributes buttonAttributes = new ButtonAttributes
                {
                    IsSelectable = true,
                    BackgroundImageAttributes = new ImageAttributes
                    {
                        ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "3. Button/rectangle_point_btn_normal.png" },
                        Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                    },

                    ShadowImageAttributes = new ImageAttributes
                    {
                        ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "3. Button/rectangle_btn_shadow.png" },
                        Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) }
                    },

                    OverlayImageAttributes = new ImageAttributes
                    {
                        ResourceURL = new StringSelector { Pressed = CommonResource.GetResourcePath() + "3. Button/rectangle_btn_press_overlay.png", Other = "" },
                        Border = new RectangleSelector { All = new Rectangle(5, 5, 5, 5) },
                    },

                    TextAttributes = new TextAttributes
                    {
                        PointSize = new FloatSelector { All = 30 },
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,

                        TextColor = new ColorSelector
                        {
                            All = new Color(0, 0, 0, 1),
                        },
                    }
                };

                UtilityButton = new Tizen.NUI.CommonUI.Button(buttonAttributes);
                UtilityButton.Size2D = new Size2D(200, 80);
                UtilityButton.Position2D = new Position2D(56, 32);
                UtilityButton.Text = "Utility";
                UtilityButton.ClickEvent += UtilityButton_ClickEvent;
                LayoutContent.Add(UtilityButton);

                buttonAttributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.GetResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_ec7510.png";
                FoodButton = new Tizen.NUI.CommonUI.Button(buttonAttributes);
                FoodButton.Size2D = new Size2D(200, 80);
                FoodButton.Position2D = new Position2D(312, 32);
                FoodButton.Text = "Food";
                FoodButton.ClickEvent += FoodButton_ClickEvent;
                LayoutContent.Add(FoodButton);

                buttonAttributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.GetResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_24c447.png";
                FamilyButton = new Tizen.NUI.CommonUI.Button(buttonAttributes);
                FamilyButton.Size2D = new Size2D(200, 80);
                FamilyButton.Position2D = new Position2D(578, 32);
                FamilyButton.Text = "Family";
                FamilyButton.ClickEvent += FamilyButton_ClickEvent;
                LayoutContent.Add(FamilyButton);

                buttonAttributes.BackgroundImageAttributes.ResourceURL.All = CommonResource.GetResourcePath() + "3. Button/[Button] App Primary Color/rectangle_point_btn_normal_9762d9.png";
                KitchenButton = new Tizen.NUI.CommonUI.Button(buttonAttributes);
                KitchenButton.Size2D = new Size2D(200, 80);
                KitchenButton.Position2D = new Position2D(834, 32);
                KitchenButton.Text = "Kitchen";
                KitchenButton.ClickEvent += KitchenButton_ClickEvent;
                LayoutContent.Add(KitchenButton);
            }

            this.isThemeButtonVisible = isThemeButtonVisiable;
            Window.Instance.Add(LayoutHeader);
            Window.Instance.Add(LayoutContent);

            //SampleMain.SampleNaviFrame.NaviFrameItemPush(LayoutHeader, LayoutContent);

            //this.ResourceUrl = CommonResource.GetResourcePath() + "0. BG/background_default_overlay.png";
        }

        public void AttachSearchBar(Tizen.FH.NUI.Controls.SearchBar searchBar)
        {
            LayoutHeader.HeaderText = "";
            searchBar.WidthResizePolicy = ResizePolicyType.FillToParent;
            searchBar.SizeHeight = 92;
            searchBar.PositionY = 16;
            LayoutHeader.Add(searchBar);
            //LayoutHeader.PositionY = 100;
        }

        private void KitchenButton_ClickEvent(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Kitchen";
        }

        private void FamilyButton_ClickEvent(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Family";
        }

        private void FoodButton_ClickEvent(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Food";
        }

        private void UtilityButton_ClickEvent(object sender, Tizen.NUI.CommonUI.Button.ClickEventArgs e)
        {
            StyleManager.Instance.Theme = "Utility";
        }

        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                if (LayoutContent != null)
                {
                    LayoutContent.Remove(Content);
                    Content.Dispose();
                    Content = null;

                    if (isThemeButtonVisible)
                    {
                        LayoutContent.Remove(UtilityButton);
                        UtilityButton.Dispose();
                        LayoutContent.Remove(FoodButton);
                        FoodButton.Dispose();
                        LayoutContent.Remove(FamilyButton);
                        FamilyButton.Dispose();
                        LayoutContent.Remove(KitchenButton);
                        KitchenButton.Dispose();
                    }

                    LayoutContent.GetParent().Remove(LayoutContent);
                    LayoutContent.Dispose();
                    LayoutContent = null;
                }

                if (LayoutHeader != null)
                {
                    LayoutHeader.GetParent().Remove(LayoutHeader);
                    LayoutHeader.Dispose();
                    LayoutHeader = null;
                }
            }

            base.Dispose(type);
        }
    }
}
