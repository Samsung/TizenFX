using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;
using System;
using Tizen.NUI;

namespace NuiCommonUiSamples
{
    using Controls = Tizen.FH.NUI.Controls;
    public class NavigationAttributes : IExample
    {
        private View root;

        private TextLabel[] createText = new TextLabel[2];

        private Controls.Navigation whiteNavigation = null;
        private Controls.Navigation blackNavigation = null;
        private Controls.Navigation conditionNavigation = null;
        private Controls.Navigation blackConditionNavigation = null;
        private Controls.Navigation whiteEditNavigation = null;
        private Controls.Navigation blackEditNavigation = null;

        private Controls.Navigation whiteNavigation2 = null;
        private Controls.Navigation blackNavigation2 = null;
        private Controls.Navigation conditionNavigation2 = null;
        private Controls.Navigation blackConditionNavigation2 = null;
        private Controls.Navigation whiteEditNavigation2 = null;
        private Controls.Navigation blackEditNavigation2 = null;
        private static string[] itemPressImage = new string[]
        {
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_slideshow_press.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_calendar_press.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_copy_press.png",
        };
        private static string[] itemNormalImage = new string[]
        {
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_slideshow.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_calendar.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_copy.png",
        };
        private static string[] itemDimImage = new string[]
        {
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_slideshow_dim.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_calendar_dim.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_copy_dim.png",
        };

        private static string[] itemBlackPressImage = new string[]
        {
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_copy_b_press.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_play_b_press.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_search_b_press.png",
        };
        private static string[] itemBlackNormalImage = new string[]
        {
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_copy_b.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_play_b.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_search_b.png",
        };
        private static string[] itemBlackDimImage = new string[]
        {
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_copy_b_dim.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_play_b_dim.png",
            CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_search_b_dim.png",
        };
        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            #region CreateByProperty
            createText[0] = new TextLabel();
            createText[0].PointSize = 14;
            createText[0].Text = "Create Navigation just by properties";
            createText[0].Size2D = new Size2D(450, 100);
            createText[0].Position2D = new Position2D(200, 60);
            createText[0].MultiLine = true;
            root.Add(createText[0]);

            ////////white navigation//////////
            #region WhiteNaviagtion
            whiteNavigation = new Controls.Navigation();
            whiteNavigation.Position2D = new Position2D(100, 150);
            whiteNavigation.IsFitWithItems = true;

            root.Add(whiteNavigation);
            Controls.Navigation.NavigationItemData backItem = new Controls.Navigation.NavigationItemData();
            backItem.Size2D = new Size2D(120, 140);
            backItem.IconURL = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_back.png";
            backItem.BackgroundImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_back_bg.png";
            backItem.OverlayImageURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_back_bg_press_overlay.png",
                Other = "",
            };
            backItem.IconSize2D = new Size2D(56, 56);
            backItem.EnableIconCenter = true;
            whiteNavigation.AddItem(backItem);
            #endregion
            ////////black navigation//////////
            #region BlackNavigation
            blackNavigation = new Controls.Navigation();
            blackNavigation.Position2D = new Position2D(300, 150);
            blackNavigation.IsFitWithItems = true;

            root.Add(blackNavigation);

            Tizen.FH.NUI.Controls.Navigation.NavigationItemData blackBackItem = new Tizen.FH.NUI.Controls.Navigation.NavigationItemData();
            blackBackItem.Size2D = new Size2D(120, 140);
            blackBackItem.BackgroundImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_back_bg_b.png";
            blackBackItem.IconURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_back_b_press.png",
                Other = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_back_b.png"
            };
            blackBackItem.IconSize2D = new Size2D(56, 56);
            blackBackItem.EnableIconCenter = true;
            blackNavigation.AddItem(blackBackItem);
            #endregion
            //////condition navigation//////////
            #region WhiteConditionNavigation
            conditionNavigation = new Controls.Navigation();
            conditionNavigation.Position2D = new Position2D(100, 300);
            conditionNavigation.BackgroundImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_bg.png";
            conditionNavigation.BackgroundImageBorder = new Rectangle(0, 0, 103, 103);
            conditionNavigation.LeftSpace = 8;
            conditionNavigation.RightSpace = 0;
            conditionNavigation.TopSpace = 40;
            conditionNavigation.BottomSpace = 40;
            conditionNavigation.ItemGap = 2;
            conditionNavigation.DividerLineColor = new Color(0, 0, 0, 0.1f);
            conditionNavigation.IsFitWithItems = true;
            conditionNavigation.ItemChangedEvent += NavigationItemChangedEvent;

            root.Add(conditionNavigation);
            for (int i = 0; i < 3; i++)
            {
                Controls.Navigation.NavigationItemData conditionItem = new Controls.Navigation.NavigationItemData();
                conditionItem.Size2D = new Size2D(116, 128);
                conditionItem.Text = "Text " + i;
                conditionItem.SubText = "SubText " + i;
                conditionItem.TextColorSelector = new ColorSelector
                {
                    Pressed = new Color(0, 0, 0, 1),
                    Disabled = new Color(0, 0, 0, 0.4f),
                    Other = new Color(0, 0, 0, 1),
                };
                conditionItem.PointSize = 8;
                conditionItem.FontFamily = "SamsungOneUI 500C";
                conditionItem.SubTextColorSelector = new ColorSelector
                {
                    Pressed = new Color(0, 0, 0, 1),
                    Disabled = new Color(0, 0, 0, 0.4f),
                    Other = new Color(0, 0, 0, 1),
                };
                conditionItem.SubTextPointSize = 8;
                conditionItem.SubTextFontFamily = "SamsungOneUI 500C";
                conditionItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemPressImage[i],
                    Disabled = itemDimImage[i],
                    DisabledFocused = itemDimImage[i],
                    DisabledSelected = itemDimImage[i],
                    Other = itemNormalImage[i]
                };
                conditionItem.LeftSpace = 4;
                conditionItem.RightSpace = 4;
                conditionItem.TopSpace = 8;
                conditionItem.BottomSpace = 16;
                conditionItem.IconSize2D = new Size2D(56, 56);
                conditionItem.TextSize2D = new Size2D(108, 24);
                conditionItem.SubTextSize2D = new Size2D(108, 24);

                conditionNavigation.AddItem(conditionItem);
            }
            #endregion
            //////black condition navigation//////////
            #region BlackConditionNavigation
            blackConditionNavigation = new Controls.Navigation();
            blackConditionNavigation.Position2D = new Position2D(300, 300);
            blackConditionNavigation.BackgroundImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_bg_b.png";
            blackConditionNavigation.BackgroundImageBorder = new Rectangle(0, 0, 103, 103);
            blackConditionNavigation.LeftSpace = 8;
            blackConditionNavigation.RightSpace = 0;
            blackConditionNavigation.TopSpace = 40;
            blackConditionNavigation.BottomSpace = 40;
            blackConditionNavigation.ItemGap = 2;
            blackConditionNavigation.DividerLineColor = new Color(1, 1, 1, 0.1f);
            blackConditionNavigation.IsFitWithItems = true;
            blackConditionNavigation.ItemChangedEvent += NavigationItemChangedEvent;

            root.Add(blackConditionNavigation);
            for (int i = 0; i < 3; i++)
            {
                Controls.Navigation.NavigationItemData blackConditionItem = new Controls.Navigation.NavigationItemData();
                blackConditionItem.Size2D = new Size2D(116, 128);
                blackConditionItem.Text = "Text " + i;
                blackConditionItem.SubText = "SubText " + i;
                blackConditionItem.TextColorSelector = new ColorSelector
                {
                    Pressed = new Color(1, 1, 1, 0.85f),
                    Disabled = new Color(1, 1, 1, 0.4f),
                    Other = new Color(1, 1, 1, 0.85f),
                };
                blackConditionItem.PointSize = 8;
                blackConditionItem.FontFamily = "SamsungOneUI 500C";
                blackConditionItem.SubTextColorSelector = new ColorSelector
                {
                    Pressed = new Color(1, 1, 1, 0.85f),
                    Disabled = new Color(1, 1, 1, 0.4f),
                    Other = new Color(1, 1, 1, 0.85f),
                };
                blackConditionItem.SubTextPointSize = 8;
                blackConditionItem.SubTextFontFamily = "SamsungOneUI 500C";
                blackConditionItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemBlackPressImage[i],
                    Disabled = itemBlackDimImage[i],
                    DisabledFocused = itemBlackDimImage[i],
                    DisabledSelected = itemBlackDimImage[i],
                    Other = itemBlackNormalImage[i]
                };
                blackConditionItem.LeftSpace = 4;
                blackConditionItem.RightSpace = 4;
                blackConditionItem.TopSpace = 8;
                blackConditionItem.BottomSpace = 16;
                blackConditionItem.IconSize2D = new Size2D(56, 56);
                blackConditionItem.TextSize2D = new Size2D(108, 24);
                blackConditionItem.SubTextSize2D = new Size2D(108, 24);

                blackConditionNavigation.AddItem(blackConditionItem);
            }
            #endregion
            //////////White Edit Mode///////////////
            #region WhiteEditModeNavigation
            whiteEditNavigation = new Controls.Navigation();
            whiteEditNavigation.Size2D = new Size2D(178, 800);
            whiteEditNavigation.ShadowImageSize2D = new Size2D(6, 800);
            whiteEditNavigation.Position2D = new Position2D(500, 150);
            whiteEditNavigation.ShadowImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_editmode_shadow.png";
            whiteEditNavigation.BackgroundImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_editmode_bg.png";
            whiteEditNavigation.BackgroundColor = new Color(1, 1, 1, 0.9f);
            whiteEditNavigation.IsFitWithItems = false;

            root.Add(whiteEditNavigation);

            Controls.Navigation.NavigationItemData firstEditItem = new Controls.Navigation.NavigationItemData();
            firstEditItem.Size2D = new Size2D(178, 184);
            firstEditItem.LeftSpace = 24;
            firstEditItem.RightSpace = 24;
            firstEditItem.TopSpace = 0;
            firstEditItem.BottomSpace = 0;
            firstEditItem.TextSize2D = new Size2D(130, 76);
            firstEditItem.Text = "1";
            firstEditItem.TextColor = new Color(14.0f / 255.0f, 14.0f / 255.0f, 230.0f / 255.0f, 1);
            firstEditItem.PointSize = 32;
            firstEditItem.FontFamily = "SamsungOneUI 300C";

            firstEditItem.SubTextSize2D = new Size2D(130, 42);
            firstEditItem.SubText = "SELECTED";
            firstEditItem.SubTextColor = new Color(0, 0, 0, 1);
            firstEditItem.SubTextPointSize = 16;
            firstEditItem.SubTextFontFamily = "SamsungOneUI 600";

            firstEditItem.DividerLineSize2D = new Size2D(178, 2);
            firstEditItem.DividerLineColor = new Color(0, 0, 0, 0.1f);
            firstEditItem.DividerLinePosition2D = new Position2D(0, 166);

            whiteEditNavigation.AddItem(firstEditItem);

            for (int i = 0; i < 2; i++)
            {
                Controls.Navigation.NavigationItemData editItem = new Controls.Navigation.NavigationItemData();
                editItem.Size2D = new Size2D(178, 108);
                editItem.Text = "Text " + i;
                editItem.TextColorSelector = new ColorSelector
                {
                    Pressed = new Color(0, 0, 0, 1),
                    Disabled = new Color(0, 0, 0, 0.4f),
                    Other = new Color(0, 0, 0, 1),
                };
                editItem.PointSize = 8;
                editItem.FontFamily = "SamsungOneUI 500C";

                editItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemPressImage[i],
                    Disabled = itemDimImage[i],
                    DisabledFocused = itemDimImage[i],
                    DisabledSelected = itemDimImage[i],
                    Other = itemNormalImage[i]
                };
                editItem.LeftSpace = 24;
                editItem.RightSpace = 24;
                editItem.TopSpace = 24;
                editItem.BottomSpace = 24;
                editItem.IconSize2D = new Size2D(56, 56);
                editItem.TextSize2D = new Size2D(130, 52);

                whiteEditNavigation.AddItem(editItem);
            }

            Controls.Navigation.NavigationItemData lastEditItem = new Controls.Navigation.NavigationItemData();
            lastEditItem.Size2D = new Size2D(178, 166);
            lastEditItem.LeftSpace = 24;
            lastEditItem.RightSpace = 24;
            lastEditItem.TopSpace = 58;
            lastEditItem.BottomSpace = 0;
            lastEditItem.TextSize2D = new Size2D(130, 52);
            lastEditItem.Text = "Cancel";
            lastEditItem.TextColor = new Color(0, 0, 0, 0.85f);
            lastEditItem.PointSize = 8;
            lastEditItem.FontFamily = "SamsungOneUI 500C";

            lastEditItem.IconURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_press.png",
                Disabled = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                DisabledFocused = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                DisabledSelected = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                Other = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel.png"
            };
            lastEditItem.IconSize2D = new Size2D(56, 56);

            lastEditItem.DividerLineSize2D = new Size2D(178, 2);
            lastEditItem.DividerLineColor = new Color(0, 0, 0, 0.1f);
            lastEditItem.DividerLinePosition2D = new Position2D(0, 16);

            whiteEditNavigation.AddItem(lastEditItem);
            #endregion
            //////////Black Edit Mode///////////////
            #region BlackEditModeNavigation
            blackEditNavigation = new Controls.Navigation();
            blackEditNavigation.Size2D = new Size2D(178, 800);
            blackEditNavigation.ShadowImageSize2D = new Size2D(6, 800);
            blackEditNavigation.Position2D = new Position2D(750, 150);
            blackEditNavigation.ShadowImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_editmode_shadow_b.png";
            blackEditNavigation.BackgroundImageURL = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_editmode_bg_b.png";
            blackEditNavigation.BackgroundColor = new Color(1, 1, 1, 0.9f);
            blackEditNavigation.IsFitWithItems = false;

            root.Add(blackEditNavigation);

            Controls.Navigation.NavigationItemData bFirstEditItem = new Controls.Navigation.NavigationItemData();
            bFirstEditItem.Size2D = new Size2D(178, 184);
            bFirstEditItem.LeftSpace = 24;
            bFirstEditItem.RightSpace = 24;
            bFirstEditItem.TopSpace = 0;
            bFirstEditItem.BottomSpace = 0;
            bFirstEditItem.TextSize2D = new Size2D(130, 76);
            bFirstEditItem.Text = "1";
            bFirstEditItem.TextColor = new Color(14.0f / 255.0f, 14.0f / 255.0f, 230.0f / 255.0f, 1);
            bFirstEditItem.PointSize = 32;
            bFirstEditItem.FontFamily = "SamsungOneUI 300C";

            bFirstEditItem.SubTextSize2D = new Size2D(130, 42);
            bFirstEditItem.SubText = "SELECTED";
            bFirstEditItem.SubTextColor = new Color(1, 1, 1, 1);
            bFirstEditItem.SubTextPointSize = 16;
            bFirstEditItem.SubTextFontFamily = "SamsungOneUI 600";

            bFirstEditItem.DividerLineSize2D = new Size2D(178, 2);
            bFirstEditItem.DividerLineColor = new Color(1, 1, 1, 0.1f);
            bFirstEditItem.DividerLinePosition2D = new Position2D(0, 166);

            blackEditNavigation.AddItem(bFirstEditItem);

            for (int i = 0; i < 2; i++)
            {
                Controls.Navigation.NavigationItemData bEditItem = new Controls.Navigation.NavigationItemData();
                bEditItem.Size2D = new Size2D(178, 108);
                bEditItem.Text = "Text " + i;
                bEditItem.TextColorSelector = new ColorSelector
                {
                    Pressed = new Color(1, 1, 1, 0.85f),
                    Disabled = new Color(0, 0, 0, 0.4f),
                    Other = new Color(1, 1, 1, 0.85f),
                };
                bEditItem.PointSize = 8;
                bEditItem.FontFamily = "SamsungOneUI 500C";

                bEditItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemBlackPressImage[i],
                    Disabled = itemBlackDimImage[i],
                    DisabledFocused = itemBlackDimImage[i],
                    DisabledSelected = itemBlackDimImage[i],
                    Other = itemBlackNormalImage[i]
                };
                bEditItem.Space = new Vector4(24, 24, 24, 24);
                bEditItem.IconSize2D = new Size2D(56, 56);
                bEditItem.TextSize2D = new Size2D(130, 52);

                blackEditNavigation.AddItem(bEditItem);
            }

            Controls.Navigation.NavigationItemData bLastEditItem = new Controls.Navigation.NavigationItemData();
            bLastEditItem.Size2D = new Size2D(178, 166);
            bLastEditItem.LeftSpace = 24;
            bLastEditItem.RightSpace = 24;
            bLastEditItem.TopSpace = 58;
            bLastEditItem.BottomSpace = 0;
            bLastEditItem.TextSize2D = new Size2D(130, 52);
            bLastEditItem.Text = "Cancel";
            bLastEditItem.TextColor = new Color(1, 1, 1, 0.85f);
            bLastEditItem.PointSize = 8;
            bLastEditItem.FontFamily = "SamsungOneUI 500C";

            bLastEditItem.IconURLSelector = new StringSelector
            {
                Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_press.png",
                Disabled = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                DisabledFocused = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                DisabledSelected = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                Other = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b.png"
            };
            bLastEditItem.IconSize2D = new Size2D(56, 56);

            bLastEditItem.DividerLineSize2D = new Size2D(178, 2);
            bLastEditItem.DividerLineColor = new Color(1, 1, 1, 0.1f);
            bLastEditItem.DividerLinePosition2D = new Position2D(0, 16);

            blackEditNavigation.AddItem(bLastEditItem);
            #endregion
            #endregion
            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            #region CreateByAttributes
            createText[1] = new TextLabel();
            createText[1].PointSize = 14;
            createText[1].Text = "Create Navigation just by Attributes";
            createText[1].Size2D = new Size2D(450, 100);
            createText[1].Position2D = new Position2D(1000, 60);
            createText[1].MultiLine = true;
            root.Add(createText[1]);

            ////////white navigation//////////
            #region WhiteNavigation
            Controls.NavigationAttributes whiteNavAttrs = new Controls.NavigationAttributes
            {
                IsFitWithItems = true,
            };
            whiteNavigation2 = new Controls.Navigation(whiteNavAttrs);
            whiteNavigation2.Position2D = new Position2D(1000, 150);

            root.Add(whiteNavigation2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes attrs = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                Size2D = new Size2D(120, 140),
                IconAttributes = new ImageAttributes()
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_back.png" },
                },
                BackgroundImageAttributes = new ImageAttributes()
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_back_bg.png" },
                },
                OverlayImageAttributes = new ImageAttributes()
                {
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_back_bg_press_overlay.png",
                        Other = "",
                    },
                },
                EnableIconCenter = true
            };
            Controls.Navigation.NavigationItemData backItem2 = new Controls.Navigation.NavigationItemData(attrs);
            whiteNavigation2.AddItem(backItem2);
            #endregion

            ////////black navigation//////////
            #region BlackNavigation
            Controls.NavigationAttributes blackNavAttrs = new Controls.NavigationAttributes
            {
                IsFitWithItems = true,
            };
            blackNavigation2 = new Controls.Navigation(blackNavAttrs);
            blackNavigation2.Position2D = new Position2D(1200, 150);

            root.Add(blackNavigation2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes blackItemAttrs = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                Size2D = new Size2D(120, 140),
                IconAttributes = new ImageAttributes()
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_back_b_press.png",
                        Other = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_back_b.png"
                    },
                },
                BackgroundImageAttributes = new ImageAttributes()
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_back_bg_b.png" },
                },
                EnableIconCenter = true
            };
            Controls.Navigation.NavigationItemData blackBackItem2 = new Controls.Navigation.NavigationItemData(blackItemAttrs);
            blackNavigation2.AddItem(blackBackItem2);
            #endregion
            //////condition navigation//////////
            #region WhiteConditionNavigation
            Controls.NavigationAttributes whiteNavAttrs2 = new Controls.NavigationAttributes
            {
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_bg.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 103, 103) },
                },
                Space = new Vector4(8, 0, 40, 40),
                ItemGap = 2,
                DividerLineColor = new Color(0, 0, 0, 0.1f),
                IsFitWithItems = true,
            };
            conditionNavigation2 = new Controls.Navigation(whiteNavAttrs2);
            conditionNavigation2.Position2D = new Position2D(1000, 300);
            conditionNavigation2.ItemChangedEvent += NavigationItemChangedEvent2;

            root.Add(conditionNavigation2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes conditionItemAttr2 = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(108, 24),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(0, 0, 0, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                        Other = new Color(0, 0, 0, 1),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                SubTextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(108, 24),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(0, 0, 0, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                        Other = new Color(0, 0, 0, 1),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                },
                Space = new Vector4(4, 4, 8, 16),
            };
            for (int i = 0; i < 3; i++)
            {
                Controls.Navigation.NavigationItemData conditionItem2 = new Controls.Navigation.NavigationItemData(conditionItemAttr2);
                conditionItem2.Size2D = new Size2D(116, 128);
                conditionItem2.Text = "Text " + i;
                conditionItem2.SubText = "SubText " + i;
                conditionItem2.IconURLSelector = new StringSelector
                {
                    Pressed = itemPressImage[i],
                    Disabled = itemDimImage[i],
                    DisabledFocused = itemDimImage[i],
                    DisabledSelected = itemDimImage[i],
                    Other = itemNormalImage[i]
                };
                conditionNavigation2.AddItem(conditionItem2);
            }
            #endregion
            //////black condition navigation//////////
            #region BlackConditionNavigation
            Controls.NavigationAttributes blackNavAttrs2 = new Controls.NavigationAttributes
            {
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_bg_b.png" },
                    Border = new RectangleSelector { All = new Rectangle(0, 0, 103, 103) },
                },
                Space = new Vector4(8, 0, 40, 40),
                ItemGap = 2,
                DividerLineColor = new Color(1, 1, 1, 0.1f),
                IsFitWithItems = true,
            };
            blackConditionNavigation2 = new Controls.Navigation(blackNavAttrs2);
            blackConditionNavigation2.Position2D = new Position2D(1200, 300);
            blackConditionNavigation2.ItemChangedEvent += NavigationItemChangedEvent2;

            root.Add(blackConditionNavigation2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes blackConditionItemAttr2 = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(108, 24),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(1, 1, 1, 0.85f),
                        Disabled = new Color(1, 1, 1, 0.4f),
                        Other = new Color(1, 1, 1, 0.85f),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                SubTextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(108, 24),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(1, 1, 1, 0.85f),
                        Disabled = new Color(1, 1, 1, 0.4f),
                        Other = new Color(1, 1, 1, 0.85f),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                },
                Space = new Vector4(4, 4, 8, 16),
            };
            for (int i = 0; i < 3; i++)
            {
                Controls.Navigation.NavigationItemData conditionItem2 = new Controls.Navigation.NavigationItemData(blackConditionItemAttr2);
                conditionItem2.Size2D = new Size2D(116, 128);
                conditionItem2.Text = "Text " + i;
                conditionItem2.SubText = "SubText " + i;
                conditionItem2.IconURLSelector = new StringSelector
                {
                    Pressed = itemBlackPressImage[i],
                    Disabled = itemBlackDimImage[i],
                    DisabledFocused = itemBlackDimImage[i],
                    DisabledSelected = itemBlackDimImage[i],
                    Other = itemBlackNormalImage[i]
                };
                blackConditionNavigation2.AddItem(conditionItem2);
            }
            #endregion
            //////////White Edit Mode///////////////
            #region WhiteEditModeNavigation
            Controls.NavigationAttributes editAttrs = new Controls.NavigationAttributes
            {
                ShadowImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(6, 800),
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_editmode_shadow.png" },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_editmode_bg.png" },
                },
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.9f) },
                IsFitWithItems = false,
            };
            whiteEditNavigation2 = new Controls.Navigation(editAttrs);
            whiteEditNavigation2.Size2D = new Size2D(178, 800);
            whiteEditNavigation2.Position2D = new Position2D(1400, 150);

            root.Add(whiteEditNavigation2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes firstItemAttrs = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                Space = new Vector4(24, 24, 0, 0),
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 76),
                    Text = new StringSelector { All = "1" },
                    TextColor = new ColorSelector { All = new Color(14.0f / 255.0f, 14.0f / 255.0f, 230.0f / 255.0f, 1) },
                    PointSize = new FloatSelector { All = 32 },
                    FontFamily = "SamsungOneUI 300C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                SubTextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 42),
                    Text = new StringSelector { All = "SELECTED" },
                    TextColor = new ColorSelector { All = new Color(0, 0, 0, 1) },
                    PointSize = new FloatSelector { All = 16 },
                    FontFamily = "SamsungOneUI 600",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                DividerLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(178, 2),
                    BackgroundColor = new ColorSelector { All = new Color(0, 0, 0, 0.1f) },
                    Position2D = new Position2D(0, 166),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                },
            };
            Controls.Navigation.NavigationItemData firstEditItem2 = new Controls.Navigation.NavigationItemData(firstItemAttrs);
            firstEditItem2.Size2D = new Size2D(178, 184);
            whiteEditNavigation2.AddItem(firstEditItem2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes itemAttributes2 = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 52),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(0, 0, 0, 1),
                        Disabled = new Color(0, 0, 0, 0.4f),
                        Other = new Color(0, 0, 0, 1),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                },
                Space = new Vector4(24, 24, 24, 24),
            };
            for (int i = 0; i < 2; i++)
            {
                Controls.Navigation.NavigationItemData editItem = new Controls.Navigation.NavigationItemData(itemAttributes2);
                editItem.Size2D = new Size2D(178, 108);
                editItem.Text = "Text " + i;
                editItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemPressImage[i],
                    Disabled = itemDimImage[i],
                    DisabledFocused = itemDimImage[i],
                    DisabledSelected = itemDimImage[i],
                    Other = itemNormalImage[i]
                };
                whiteEditNavigation2.AddItem(editItem);
            }

            Tizen.FH.NUI.Controls.NavigationItemAttributes lastItemAttrs = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                Space = new Vector4(24, 24, 58, 0),
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 52),
                    TextColor = new ColorSelector { All = new Color(0, 0, 0, 0.85f) },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    Text = new StringSelector { All = "Cancel" },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_press.png",
                        Disabled = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                        DisabledFocused = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                        DisabledSelected = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel_dim.png",
                        Other = CommonResource.GetResourcePath() + "2. Side Navigation/sidenavi_btn_cancel.png"
                    },
                },
                DividerLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(178, 2),
                    BackgroundColor = new ColorSelector { All = new Color(0, 0, 0, 0.1f) },
                    Position2D = new Position2D(0, 16),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                },
            };

            Controls.Navigation.NavigationItemData lastEditItem2 = new Controls.Navigation.NavigationItemData(lastItemAttrs);
            lastEditItem2.Size2D = new Size2D(178, 166);
            whiteEditNavigation2.AddItem(lastEditItem2);
            #endregion
            //////////Black Edit Mode///////////////
            #region BlackEditModeNavigation
            Controls.NavigationAttributes blackEditAttrs = new Controls.NavigationAttributes
            {
                ShadowImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(6, 800),
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_editmode_shadow_b.png" },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceURL = new StringSelector { All = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_editmode_bg_b.png" },
                },
                BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.9f) },
                IsFitWithItems = false,
            };
            blackEditNavigation2 = new Controls.Navigation(blackEditAttrs);
            blackEditNavigation2.Size2D = new Size2D(178, 800);
            blackEditNavigation2.Position2D = new Position2D(1650, 150);

            root.Add(blackEditNavigation2);

            Tizen.FH.NUI.Controls.NavigationItemAttributes blackFirstItemAttrs = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                Space = new Vector4(24, 24, 0, 0),
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 76),
                    Text = new StringSelector { All = "1" },
                    TextColor = new ColorSelector { All = new Color(14.0f / 255.0f, 14.0f / 255.0f, 230.0f / 255.0f, 1) },
                    PointSize = new FloatSelector { All = 32 },
                    FontFamily = "SamsungOneUI 300C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                SubTextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 42),
                    Text = new StringSelector { All = "SELECTED" },
                    TextColor = new ColorSelector { All = new Color(1, 1, 1, 1) },
                    PointSize = new FloatSelector { All = 16 },
                    FontFamily = "SamsungOneUI 600",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                },
                DividerLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(178, 2),
                    BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.1f) },
                    Position2D = new Position2D(0, 166),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                },
            };
            Controls.Navigation.NavigationItemData blackFirstEditItem = new Controls.Navigation.NavigationItemData(blackFirstItemAttrs);
            blackFirstEditItem.Size2D = new Size2D(178, 184);
            blackEditNavigation2.AddItem(blackFirstEditItem);

            Tizen.FH.NUI.Controls.NavigationItemAttributes blackItemAttributes = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 52),
                    TextColor = new ColorSelector
                    {
                        Pressed = new Color(1, 1, 1, 0.85f),
                        Disabled = new Color(0, 0, 0, 0.4f),
                        Other = new Color(1, 1, 1, 0.85f),
                    },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                },
                Space = new Vector4(24, 24, 24, 24),
            };
            for (int i = 0; i < 2; i++)
            {
                Controls.Navigation.NavigationItemData editItem = new Controls.Navigation.NavigationItemData(blackItemAttributes);
                editItem.Size2D = new Size2D(178, 108);
                editItem.Text = "Text " + i;
                editItem.IconURLSelector = new StringSelector
                {
                    Pressed = itemBlackPressImage[i],
                    Disabled = itemBlackDimImage[i],
                    DisabledFocused = itemBlackDimImage[i],
                    DisabledSelected = itemBlackDimImage[i],
                    Other = itemBlackNormalImage[i]
                };
                blackEditNavigation2.AddItem(editItem);
            }

            Tizen.FH.NUI.Controls.NavigationItemAttributes blackLastItemAttrs = new Tizen.FH.NUI.Controls.NavigationItemAttributes
            {
                Space = new Vector4(24, 24, 58, 0),
                TextAttributes = new TextAttributes
                {
                    Size2D = new Size2D(130, 52),
                    TextColor = new ColorSelector { All = new Color(1, 1, 1, 0.85f) },
                    PointSize = new FloatSelector { All = 8 },
                    FontFamily = "SamsungOneUI 500C",
                    Text = new StringSelector { All = "Cancel" },
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                },
                IconAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(56, 56),
                    ResourceURL = new StringSelector
                    {
                        Pressed = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_press.png",
                        Disabled = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                        DisabledFocused = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                        DisabledSelected = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b_dim.png",
                        Other = CommonResource.GetResourcePath() + "2. Side Navigation/[Black ver.]/sidenavi_btn_cancel_b.png"
                    },
                },
                DividerLineAttributes = new ViewAttributes
                {
                    Size2D = new Size2D(178, 2),
                    BackgroundColor = new ColorSelector { All = new Color(1, 1, 1, 0.1f) },
                    Position2D = new Position2D(0, 16),
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                },
            };

            Controls.Navigation.NavigationItemData blackLastEditItem = new Controls.Navigation.NavigationItemData(blackLastItemAttrs);
            blackLastEditItem.Size2D = new Size2D(178, 166);
            blackEditNavigation2.AddItem(blackLastEditItem);
            #endregion
            #endregion
        }

        private void NavigationItemChangedEvent(object sender, Controls.Navigation.ItemChangeEventArgs e)
        {
            createText[0].Text = "Create Navigation just by properties, Selected index from " + e.PreviousIndex + " to " + e.CurrentIndex;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                if (whiteNavigation != null)
                {
                    root.Remove(whiteNavigation);
                    whiteNavigation.Dispose();
                    whiteNavigation = null;
                }
                if (blackNavigation != null)
                {
                    root.Remove(blackNavigation);
                    blackNavigation.Dispose();
                    blackNavigation = null;
                }
                if (conditionNavigation != null)
                {
                    root.Remove(conditionNavigation);
                    conditionNavigation.Dispose();
                    conditionNavigation = null;
                }
                if (blackConditionNavigation != null)
                {
                    root.Remove(blackConditionNavigation);
                    blackConditionNavigation.Dispose();
                    blackConditionNavigation = null;
                }

                if (whiteEditNavigation != null)
                {
                    root.Remove(whiteEditNavigation);
                    whiteEditNavigation.Dispose();
                    whiteEditNavigation = null;
                }

                if (blackEditNavigation != null)
                {
                    root.Remove(blackEditNavigation);
                    blackEditNavigation.Dispose();
                    blackEditNavigation = null;
                }

                if (whiteNavigation2 != null)
                {
                    root.Remove(whiteNavigation2);
                    whiteNavigation2.Dispose();
                    whiteNavigation2 = null;
                }

                if (blackNavigation2 != null)
                {
                    root.Remove(blackNavigation2);
                    blackNavigation2.Dispose();
                    blackNavigation2 = null;
                }
                if (conditionNavigation2 != null)
                {
                    root.Remove(conditionNavigation2);
                    conditionNavigation2.Dispose();
                    conditionNavigation2 = null;
                }
                if (blackConditionNavigation2 != null)
                {
                    root.Remove(blackConditionNavigation2);
                    blackConditionNavigation2.Dispose();
                    blackConditionNavigation2 = null;
                }

                if (whiteEditNavigation2 != null)
                {
                    root.Remove(whiteEditNavigation2);
                    whiteEditNavigation2.Dispose();
                    whiteEditNavigation2 = null;
                }

                if (blackEditNavigation2 != null)
                {
                    root.Remove(blackEditNavigation2);
                    blackEditNavigation2.Dispose();
                    blackEditNavigation2 = null;
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

        private void NavigationItemChangedEvent2(object sender, Tizen.FH.NUI.Controls.Navigation.ItemChangeEventArgs e)
        {
            createText[1].Text = "Create Navigation just by Attributes, Selected index from " + e.PreviousIndex + " to " + e.CurrentIndex;
        }
    }
}
