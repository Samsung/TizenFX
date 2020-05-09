using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class CheckBoxSample : IExample
    {
        private View root;
        private View left;
        private View right;
        private View leftbody;
        private View rightbody;

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
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
                Padding = new Extents(40, 40, 40, 40),
            };
            root.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, CellPadding = new Size(40, 40) };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            left = new View();
            left.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            left.WidthSpecification = 920;
            left.HeightSpecification = 800;

            createText[0] = new TextLabel();
            createText[0].Text = "Create CheckBox just by properties";
            createText[0].TextColor = Color.White;
            createText[0].WidthSpecification =500;
            createText[0].HeightSpecification =100;
            left.Add(createText[0]);

            leftbody = new View();
            leftbody.Layout = new GridLayout() { Columns = 4 };
            int num = 4;
            for (int i = 0; i < num; i++)
            {
                group[i] = new CheckBoxGroup();
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].WidthSpecification = 200;
                modeText[i].HeightSpecification = 48;
                leftbody.Add(modeText[i]);
            }

            for (int i = 0; i < num; i++)
            {
                utilityCheckBox[i] = new CheckBox();
                var utilityStyle = utilityCheckBox[i].Style;
                utilityStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                utilityStyle.Icon.BackgroundImage = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_on.png",
                };
                utilityStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = "",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                    Disabled = "",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check.png",
                };
                utilityStyle.Icon.ImageShadow = new Selector<ImageShadow>
                {
                    Normal = "",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                    Disabled = "",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                };
                utilityCheckBox[i].ApplyStyle(utilityStyle);

                utilityCheckBox[i].WidthSpecification = 48;
                utilityCheckBox[i].HeightSpecification = 48;
                utilityCheckBox[i].Margin = new Extents(76, 76, 25, 25);
                utilityCheckBox[i].ButtonIcon.Size = new Size(48, 48);

                group[0].Add(utilityCheckBox[i]);
                //////
                familyCheckBox[i] = new CheckBox();
                var familyStyle = familyCheckBox[i].Style;
                familyStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                familyStyle.Icon.BackgroundImage = "";
                familyStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_24c447.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_24c447.png",
                };
                familyCheckBox[i].ApplyStyle(familyStyle);

                familyCheckBox[i].WidthSpecification = 48;
                familyCheckBox[i].HeightSpecification = 48;
                familyCheckBox[i].Margin = new Extents(76, 76, 25, 25);
                familyCheckBox[i].ButtonIcon.Size = new Size(48, 48);
                group[1].Add(familyCheckBox[i]);
                /////////
                foodCheckBox[i] = new CheckBox();
                var foodStyle = foodCheckBox[i].Style;
                foodStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                foodStyle.Icon.BackgroundImage = "";
                foodStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_ec7510.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_ec7510.png",
                };
                foodCheckBox[i].ApplyStyle(foodStyle);
                foodCheckBox[i].WidthSpecification = 48;
                foodCheckBox[i].HeightSpecification = 48;
                familyCheckBox[i].Margin = new Extents(76, 76, 25, 25);
                foodCheckBox[i].ButtonIcon.Size = new Size(48, 48);

                group[2].Add(foodCheckBox[i]);
                ////////
                kitchenCheckBox[i] = new CheckBox();
                var kitchenStyle = kitchenCheckBox[i].Style;
                kitchenStyle.Icon.Opacity = new Selector<float?>
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                kitchenStyle.Icon.BackgroundImage = "";
                kitchenStyle.Icon.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_9762d9.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_check_on_9762d9.png",
                };
                kitchenCheckBox[i].ApplyStyle(kitchenStyle);
                kitchenCheckBox[i].WidthSpecification = 48;
                kitchenCheckBox[i].HeightSpecification = 48;
                kitchenCheckBox[i].Margin = new Extents(76, 76, 25, 25);
                kitchenCheckBox[i].ButtonIcon.Size = new Size(48, 48);

                group[3].Add(kitchenCheckBox[i]);

                leftbody.Add(utilityCheckBox[i]);
                leftbody.Add(familyCheckBox[i]);
                leftbody.Add(foodCheckBox[i]);
                leftbody.Add(kitchenCheckBox[i]);
            }
            /////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            right = new View();
            right.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            right.WidthSpecification = 920;
            right.HeightSpecification = 800;

            rightbody = new View();
            rightbody.Layout = new GridLayout() { Columns = 4 };
            createText[1] = new TextLabel();
            createText[1].Text = "Create CheckBox just by Attributes";
            createText[1].TextColor = Color.White;
            createText[1].WidthSpecification = 500;
            createText[1].HeightSpecification = 100;
            right.Add(createText[1]);

            for (int i = 0; i < num; i++)
            {
                group2[i] = new CheckBoxGroup();
                modeText2[i] = new TextLabel();
                modeText2[i].Text = mode[i];
                modeText2[i].WidthSpecification = 200;
                modeText2[i].HeightSpecification = 48;
                rightbody.Add(modeText2[i]);
            }

            ButtonStyle utilityAttrs = new ButtonStyle
            {
                Icon = new ImageViewStyle
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
                    ImageShadow = new Selector<ImageShadow>
                    {
                        Normal = "",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                        Disabled = "",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_check_shadow.png",
                    },
                }
            };
            ButtonStyle familyAttrs = new ButtonStyle
            {
                Icon = new ImageViewStyle
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
                Icon = new ImageViewStyle
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
                Icon = new ImageViewStyle
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
                utilityCheckBox2[i].WidthSpecification = 48;
                utilityCheckBox2[i].HeightSpecification = 48;
                utilityCheckBox2[i].Margin = new Extents(76, 76, 25, 25);
                group2[0].Add(utilityCheckBox2[i]);

                familyCheckBox2[i] = new CheckBox(familyAttrs);
                familyCheckBox2[i].WidthSpecification = 48;
                familyCheckBox2[i].HeightSpecification = 48;
                familyCheckBox2[i].Margin = new Extents(76, 76, 25, 25);
                group2[1].Add(familyCheckBox2[i]);

                foodCheckBox2[i] = new CheckBox(foodAttrs);
                foodCheckBox2[i].WidthSpecification = 48;
                foodCheckBox2[i].HeightSpecification = 48;
                foodCheckBox2[i].Margin = new Extents(76, 76, 25, 25);
                group2[2].Add(foodCheckBox2[i]);

                kitchenCheckBox2[i] = new CheckBox(kitchenAttrs);
                kitchenCheckBox2[i].WidthSpecification = 48;
                kitchenCheckBox2[i].HeightSpecification = 48;
                kitchenCheckBox2[i].Margin = new Extents(76, 76, 25, 25);
                group2[3].Add(kitchenCheckBox2[i]);

                rightbody.Add(utilityCheckBox2[i]);
                rightbody.Add(familyCheckBox2[i]);
                rightbody.Add(foodCheckBox2[i]);
                rightbody.Add(kitchenCheckBox2[i]);
            }

            root.Add(left);
            root.Add(right);
            left.Add(leftbody);
            right.Add(rightbody);

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
                    leftbody.Remove(utilityCheckBox[i]);
                    utilityCheckBox[i].Dispose();
                    utilityCheckBox[i] = null;

                    leftbody.Remove(familyCheckBox[i]);
                    familyCheckBox[i].Dispose();
                    familyCheckBox[i] = null;

                    leftbody.Remove(foodCheckBox[i]);
                    foodCheckBox[i].Dispose();
                    foodCheckBox[i] = null;

                    leftbody.Remove(kitchenCheckBox[i]);
                    kitchenCheckBox[i].Dispose();
                    kitchenCheckBox[i] = null;

                    leftbody.Remove(modeText[i]);
                    modeText[i].Dispose();
                    modeText[i] = null;

                    rightbody.Remove(utilityCheckBox2[i]);
                    utilityCheckBox2[i].Dispose();
                    utilityCheckBox2[i] = null;

                    rightbody.Remove(familyCheckBox2[i]);
                    familyCheckBox2[i].Dispose();
                    familyCheckBox2[i] = null;

                    rightbody.Remove(foodCheckBox2[i]);
                    foodCheckBox2[i].Dispose();
                    foodCheckBox2[i] = null;

                    rightbody.Remove(kitchenCheckBox2[i]);
                    kitchenCheckBox2[i].Dispose();
                    kitchenCheckBox2[i] = null;

                    rightbody.Remove(modeText2[i]);
                    modeText2[i].Dispose();
                    modeText2[i] = null;
                }

                left.Remove(createText[0]);
                createText[0].Dispose();
                createText[0] = null;
                left.Remove(leftbody);
                leftbody.Dispose();
                leftbody = null;
                right.Remove(createText[1]);
                createText[1].Dispose();
                createText[1] = null;
                right.Remove(rightbody);
                rightbody.Dispose();
                rightbody = null;

                root.Remove(left);
                left.Dispose();
                left = null;
                root.Remove(right);
                right.Dispose();
                right = null;

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
