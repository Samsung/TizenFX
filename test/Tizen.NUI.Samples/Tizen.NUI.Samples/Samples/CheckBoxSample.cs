using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class CheckBoxSample : IExample
    {
        private View root;

        private TextLabel[] createText = new TextLabel[2];
        private TextLabel[] modeText = new TextLabel[4];
        private TextLabel[] modeText2 = new TextLabel[4];

        private CheckBox[] utilityCheckBox = new CheckBox[4];
        private CheckBox[] familyCheckBox = new CheckBox[4];
        private CheckBox[] foodCheckBox = new CheckBox[4];
        private CheckBox[] kitchenCheckBox = new CheckBox[4];
        private CheckBoxGroup[] group = new CheckBoxGroup[4];

        private CheckBox[] utilityCheckBox2 = new CheckBox[4];
        private CheckBox[] familyCheckBox2 = new CheckBox[4];
        private CheckBox[] foodCheckBox2 = new CheckBox[4];
        private CheckBox[] kitchenCheckBox2 = new CheckBox[4];
        private CheckBoxGroup[] group2 = new CheckBoxGroup[4];

        private static string[] mode = new string[]
        {
            "Utility",
            "Family",
            "Food",
            "Kitchen",
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
            createText[0].Text = "Create CheckBox just by properties";
            createText[0].TextColor = Color.White;
            createText[0].Size2D = new Size2D(500, 100);
            createText[0].Position2D = new Position2D(400, 100);
            root.Add(createText[0]);

            int num = 4;
            for (int i = 0; i < num; i++)
            {
                group[i] = new CheckBoxGroup();
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].Size2D = new Size2D(200, 48);
                modeText[i].Position2D = new Position2D(300 + 200 * i, 200);
                root.Add(modeText[i]);
            }

            for (int i = 0; i < num; i++)
            {
                utilityCheckBox[i] = new CheckBox();
                utilityCheckBox[i].Size2D = new Size2D(150, 48);
                utilityCheckBox[i].Position2D = new Position2D(300, 300 + i * 100);
                utilityCheckBox[i].Style.Icon.Size = new Size(48, 48);
                utilityCheckBox[i].Style.Icon.Padding.Start = 0;
                utilityCheckBox[i].Style.Icon.Padding.End = 0;
                utilityCheckBox[i].Style.Icon.Padding.Top = 0;
                utilityCheckBox[i].Style.Icon.Padding.Bottom = 0;
                utilityCheckBox[i].Style.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                utilityCheckBox[i].Style.Icon.BackgroundImage = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                };
                utilityCheckBox[i].Style.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = "",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                    Disabled = "",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                };
                utilityCheckBox[i].Style.Icon.Shadow.ResourceUrl = new Selector<string>
                {
                    Normal = "",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                    Disabled = "",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                };

                //utilityCheckBox[i].Text = "Check" + i;
                //utilityCheckBox[i].TextAlignment = HorizontalAlignment.Begin;
                //utilityCheckBox[i].PointSize = 12;
                //utilityCheckBox[i].TextPaddingLeft = 70;

                group[0].Add(utilityCheckBox[i]);
                //////
                familyCheckBox[i] = new CheckBox();
                familyCheckBox[i].Size2D = new Size2D(48, 48);
                familyCheckBox[i].Position2D = new Position2D(500, 300 + i * 100);
                familyCheckBox[i].Style.Icon.Size = new Size(48, 48);
                familyCheckBox[i].Style.Icon.Padding.Start = 0;
                familyCheckBox[i].Style.Icon.Padding.End = 0;
                familyCheckBox[i].Style.Icon.Padding.Top = 0;
                familyCheckBox[i].Style.Icon.Padding.Bottom = 0;
                familyCheckBox[i].Style.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                familyCheckBox[i].Style.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_24c447.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_24c447.png",
                };

                group[1].Add(familyCheckBox[i]);
                /////////
                foodCheckBox[i] = new CheckBox();
                foodCheckBox[i].Size2D = new Size2D(48, 48);
                foodCheckBox[i].Position2D = new Position2D(700, 300 + i * 100);
                foodCheckBox[i].Style.Icon.Size = new Size(48, 48);
                foodCheckBox[i].Style.Icon.Padding.Start = 0;
                foodCheckBox[i].Style.Icon.Padding.End = 0;
                foodCheckBox[i].Style.Icon.Padding.Top = 0;
                foodCheckBox[i].Style.Icon.Padding.Bottom = 0;
                foodCheckBox[i].Style.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                foodCheckBox[i].Style.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_ec7510.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_ec7510.png",
                };

                group[2].Add(foodCheckBox[i]);
                ////////
                kitchenCheckBox[i] = new CheckBox();
                kitchenCheckBox[i].Size2D = new Size2D(48, 48);
                kitchenCheckBox[i].Position2D = new Position2D(900, 300 + i * 100);
                kitchenCheckBox[i].Style.Icon.Size = new Size(48, 48);
                kitchenCheckBox[i].Style.Icon.Padding.Start = 0;
                kitchenCheckBox[i].Style.Icon.Padding.End = 0;
                kitchenCheckBox[i].Style.Icon.Padding.Top = 0;
                kitchenCheckBox[i].Style.Icon.Padding.Bottom = 0;

                kitchenCheckBox[i].Style.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                kitchenCheckBox[i].Style.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_9762d9.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_9762d9.png",
                };

                group[3].Add(kitchenCheckBox[i]);

                root.Add(utilityCheckBox[i]);
                root.Add(familyCheckBox[i]);
                root.Add(foodCheckBox[i]);
                root.Add(kitchenCheckBox[i]);
            }
            /////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create CheckBox just by Attributes";
            createText[1].TextColor = Color.White;
            createText[1].Size2D = new Size2D(500, 100);
            createText[1].Position2D = new Position2D(1200, 100);
            root.Add(createText[1]);

            for (int i = 0; i < num; i++)
            {
                group2[i] = new CheckBoxGroup();
                modeText2[i] = new TextLabel();
                modeText2[i].Text = mode[i];
                modeText2[i].Size2D = new Size2D(200, 48);
                modeText2[i].Position2D = new Position2D(1100 + 200 * i, 200);
                root.Add(modeText2[i]);
            }

            ButtonStyle utilityAttrs = new ButtonStyle
            {
                Icon = new ImageControlStyle
                {
                    Size = new Size(48, 48),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    BackgroundImage = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = "",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                        Disabled = "",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                    },
                    Shadow = new ImageViewStyle
                    {
                        ResourceUrl = new Selector<string>
                        {
                            Normal = "",
                            Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                            Disabled = "",
                            DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                        },
                    },
                }
            };
            ButtonStyle familyAttrs = new ButtonStyle
            {
                Icon = new ImageControlStyle
                {
                    Size = new Size(48, 48),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_24c447.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_24c447.png",
                    },
                }
            };
            ButtonStyle foodAttrs = new ButtonStyle
            {
                Icon = new ImageControlStyle
                {
                    Size = new Size(48, 48),
                    Position = new Position(0, 0),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_ec7510.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_ec7510.png",
                    },
                },
            };
            ButtonStyle kitchenAttrs = new ButtonStyle
            {
                Icon = new ImageControlStyle
                {
                    Size = new Size(48, 48),
                    Position = new Position(0, 0),
                    Opacity = new Selector<float?>
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_9762d9.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_9762d9.png",
                    },
                },
            };
            for (int i = 0; i < num; i++)
            {
                utilityCheckBox2[i] = new CheckBox(utilityAttrs);
                utilityCheckBox2[i].Size2D = new Size2D(48, 48);
                utilityCheckBox2[i].Position2D = new Position2D(1100, 300 + i * 100);
                group2[0].Add(utilityCheckBox2[i]);

                familyCheckBox2[i] = new CheckBox(familyAttrs);
                familyCheckBox2[i].Size2D = new Size2D(48, 48);
                familyCheckBox2[i].Position2D = new Position2D(1300, 300 + i * 100);
                group2[1].Add(familyCheckBox2[i]);

                foodCheckBox2[i] = new CheckBox(foodAttrs);
                foodCheckBox2[i].Size2D = new Size2D(48, 48);
                foodCheckBox2[i].Position2D = new Position2D(1500, 300 + i * 100);
                group2[2].Add(foodCheckBox2[i]);

                kitchenCheckBox2[i] = new CheckBox(kitchenAttrs);
                kitchenCheckBox2[i].Size2D = new Size2D(48, 48);
                kitchenCheckBox2[i].Position2D = new Position2D(1700, 300 + i * 100);
                group2[3].Add(kitchenCheckBox2[i]);

                root.Add(utilityCheckBox2[i]);
                root.Add(familyCheckBox2[i]);
                root.Add(foodCheckBox2[i]);
                root.Add(kitchenCheckBox2[i]);
            }

            utilityCheckBox[2].IsEnabled = false;
            familyCheckBox[2].IsEnabled = false;
            foodCheckBox[2].IsEnabled = false;
            kitchenCheckBox[2].IsEnabled = false;

            utilityCheckBox2[2].IsEnabled = false;
            familyCheckBox2[2].IsEnabled = false;
            foodCheckBox2[2].IsEnabled = false;
            kitchenCheckBox2[2].IsEnabled = false;

            utilityCheckBox[3].IsEnabled = false;
            familyCheckBox[3].IsEnabled = false;
            foodCheckBox[3].IsEnabled = false;
            kitchenCheckBox[3].IsEnabled = false;
            utilityCheckBox[3].IsSelected = true;
            familyCheckBox[3].IsSelected = true;
            foodCheckBox[3].IsSelected = true;
            kitchenCheckBox[3].IsSelected = true;

            utilityCheckBox2[3].IsEnabled = false;
            familyCheckBox2[3].IsEnabled = false;
            foodCheckBox2[3].IsEnabled = false;
            kitchenCheckBox2[3].IsEnabled = false;
            utilityCheckBox2[3].IsSelected = true;
            familyCheckBox2[3].IsSelected = true;
            foodCheckBox2[3].IsSelected = true;
            kitchenCheckBox2[3].IsSelected = true;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                int num = 4;
                for (int i = 0; i < num; i++)
                {
                    root.Remove(utilityCheckBox[i]);
                    utilityCheckBox[i].Dispose();
                    utilityCheckBox[i] = null;

                    root.Remove(familyCheckBox[i]);
                    familyCheckBox[i].Dispose();
                    familyCheckBox[i] = null;

                    root.Remove(foodCheckBox[i]);
                    foodCheckBox[i].Dispose();
                    foodCheckBox[i] = null;

                    root.Remove(kitchenCheckBox[i]);
                    kitchenCheckBox[i].Dispose();
                    kitchenCheckBox[i] = null;

                    root.Remove(modeText[i]);
                    modeText[i].Dispose();
                    modeText[i] = null;

                    root.Remove(utilityCheckBox2[i]);
                    utilityCheckBox2[i].Dispose();
                    utilityCheckBox2[i] = null;

                    root.Remove(familyCheckBox2[i]);
                    familyCheckBox2[i].Dispose();
                    familyCheckBox2[i] = null;

                    root.Remove(foodCheckBox2[i]);
                    foodCheckBox2[i].Dispose();
                    foodCheckBox2[i] = null;

                    root.Remove(kitchenCheckBox2[i]);
                    kitchenCheckBox2[i].Dispose();
                    kitchenCheckBox2[i] = null;

                    root.Remove(modeText2[i]);
                    modeText2[i].Dispose();
                    modeText2[i] = null;
                }

                root.Remove(createText[0]);
                createText[0].Dispose();
                createText[0] = null;
                root.Remove(createText[1]);
                createText[1].Dispose();
                createText[1] = null;

                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
