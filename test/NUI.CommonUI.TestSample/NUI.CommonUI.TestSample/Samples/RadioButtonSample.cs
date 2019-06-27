using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.NUI.CommonUI.Samples
{
    public class RadioButtonSample : IExample
    {
        private View root;

        private TextLabel[] createText = new TextLabel[2];
        private TextLabel[] modeText = new TextLabel[4];
        private TextLabel[] modeText2 = new TextLabel[4];

        private RadioButton[] utilityRadioButton = new RadioButton[4];
        private RadioButton[] familyRadioButton = new RadioButton[4];
        private RadioButton[] foodRadioButton = new RadioButton[4];
        private RadioButton[] kitchenRadioButton = new RadioButton[4];
        private RadioButtonGroup[] group = new RadioButtonGroup[4];

        private RadioButton[] utilityRadioButton2 = new RadioButton[4];
        private RadioButton[] familyRadioButton2 = new RadioButton[4];
        private RadioButton[] foodRadioButton2 = new RadioButton[4];
        private RadioButton[] kitchenRadioButton2 = new RadioButton[4];
        private RadioButtonGroup[] group2 = new RadioButtonGroup[4];

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
            };
            window.Add(root);

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            createText[0] = new TextLabel();
            createText[0].Text = "Create RadioButton just by properties";
            createText[0].Size2D = new Size2D(500, 100);
            createText[0].Position2D = new Position2D(400, 100);
            root.Add(createText[0]);

            int num = 4;
            for (int i = 0; i < num; i++)
            {
                group[i] = new RadioButtonGroup();
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].Size2D = new Size2D(200, 48);
                modeText[i].Position2D = new Position2D(300 + 200 * i, 200);
                root.Add(modeText[i]);
            }

            for (int i = 0; i < num; i++)
            {
                utilityRadioButton[i] = new RadioButton();
                utilityRadioButton[i].Size2D = new Size2D(48, 48);
                utilityRadioButton[i].Position2D = new Position2D(300, 300 + i * 100);
                utilityRadioButton[i].CheckImageSize2D = new Size2D(48, 48);
                utilityRadioButton[i].CheckImagePaddingLeft = 5;
                utilityRadioButton[i].CheckImagePaddingRight = 5;
                utilityRadioButton[i].CheckImageOpacitySelector = new FloatSelector
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                utilityRadioButton[i].CheckImageURLSelector = new StringSelector
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
                };

                group[0].Add(utilityRadioButton[i]);
                ////////
                familyRadioButton[i] = new RadioButton();
                familyRadioButton[i].Size2D = new Size2D(48, 48);
                familyRadioButton[i].Position2D = new Position2D(500, 300 + i * 100);
                familyRadioButton[i].CheckImageSize2D = new Size2D(48, 48);
                familyRadioButton[i].CheckImagePaddingLeft = 5;
                familyRadioButton[i].CheckImagePaddingRight = 5;
                familyRadioButton[i].CheckImageOpacitySelector = new FloatSelector
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                familyRadioButton[i].CheckImageURLSelector = new StringSelector
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                };

                group[1].Add(familyRadioButton[i]);
                /////////
                foodRadioButton[i] = new RadioButton();
                foodRadioButton[i].Size2D = new Size2D(150, 48);
                foodRadioButton[i].Position2D = new Position2D(700, 300 + i * 100);
                foodRadioButton[i].CheckImageSize2D = new Size2D(48, 48);
                foodRadioButton[i].CheckImagePaddingLeft = 5;
                foodRadioButton[i].CheckImagePaddingRight = 5;
                foodRadioButton[i].CheckImageOpacitySelector = new FloatSelector
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                foodRadioButton[i].CheckImageURLSelector = new StringSelector
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                };

                //foodRadioButton[i].Text = "Radio" + i;
                //foodRadioButton[i].TextAlignment = HorizontalAlignment.Begin;
                //foodRadioButton[i].PointSize = 12;
                //foodRadioButton[i].TextPaddingLeft = 70;

                group[2].Add(foodRadioButton[i]);
                ////////
                kitchenRadioButton[i] = new RadioButton();
                kitchenRadioButton[i].Size2D = new Size2D(48, 48);
                kitchenRadioButton[i].Position2D = new Position2D(900, 300 + i * 100);
                kitchenRadioButton[i].CheckImageSize2D = new Size2D(48, 48);
                kitchenRadioButton[i].CheckImagePaddingLeft = 5;
                kitchenRadioButton[i].CheckImagePaddingRight = 5;
                kitchenRadioButton[i].CheckImageOpacitySelector = new FloatSelector
                {
                    Normal = 1.0f,
                    Selected = 1.0f,
                    Disabled = 0.4f,
                    DisabledSelected = 0.4f
                };
                kitchenRadioButton[i].CheckImageURLSelector = new StringSelector
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                };

                group[3].Add(kitchenRadioButton[i]);

                root.Add(utilityRadioButton[i]);
                root.Add(familyRadioButton[i]);
                root.Add(foodRadioButton[i]);
                root.Add(kitchenRadioButton[i]);
            }
            //foodRadioButton[0].LayoutDirection = ViewLayoutDirectionType.RTL;
            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create RadioButton just by Attributes";
            createText[1].Size2D = new Size2D(500, 100);
            createText[1].Position2D = new Position2D(1200, 100);
            root.Add(createText[1]);

            for (int i = 0; i < num; i++)
            {
                group2[i] = new RadioButtonGroup();
                modeText2[i] = new TextLabel();
                modeText2[i].Text = mode[i];
                modeText2[i].Size2D = new Size2D(200, 48);
                modeText2[i].Position2D = new Position2D(1100 + 200 * i, 200);
                root.Add(modeText2[i]);
            }

            SelectButtonAttributes utilityAttrs = new SelectButtonAttributes
            {
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D =  new Size2D(48, 48),
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_on.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },            
            };         
            SelectButtonAttributes familyAttrs = new SelectButtonAttributes
            {
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D =  new Size2D(48, 48),
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_24c447.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },
            };
            SelectButtonAttributes foodAttrs = new SelectButtonAttributes
            {
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_ec7510.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },
            };
            SelectButtonAttributes kitchenAttrs = new SelectButtonAttributes
            {
                CheckImageAttributes = new ImageAttributes
                {
                    Size2D = new Size2D(48, 48),
                    ResourceUrl = new StringSelector
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_btn_radio_off.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_btn_radio_on_9762d9.png",
                    },
                    Opacity = new FloatSelector
                    {
                        Normal = 1.0f,
                        Selected = 1.0f,
                        Disabled = 0.4f,
                        DisabledSelected = 0.4f
                    },
                },               
            };
            for (int i = 0; i < num; i++)
            {
                utilityRadioButton2[i] = new RadioButton(utilityAttrs);
                utilityRadioButton2[i].Size2D = new Size2D(48, 48);
                utilityRadioButton2[i].Position2D = new Position2D(1100, 300 + i * 100);
                group2[0].Add(utilityRadioButton2[i]);

                familyRadioButton2[i] = new RadioButton(familyAttrs);
                familyRadioButton2[i].Size2D = new Size2D(48, 48);
                familyRadioButton2[i].Position2D = new Position2D(1300, 300 + i * 100);
                group2[1].Add(familyRadioButton2[i]);

                foodRadioButton2[i] = new RadioButton(foodAttrs);
                foodRadioButton2[i].Size2D = new Size2D(48, 48);
                foodRadioButton2[i].Position2D = new Position2D(1500, 300 + i * 100);
                group2[2].Add(foodRadioButton2[i]);

                kitchenRadioButton2[i] = new RadioButton(kitchenAttrs);
                kitchenRadioButton2[i].Size2D = new Size2D(48, 48);
                kitchenRadioButton2[i].Position2D = new Position2D(1700, 300 + i * 100);
                group2[3].Add(kitchenRadioButton2[i]);

                root.Add(utilityRadioButton2[i]);
                root.Add(familyRadioButton2[i]);
                root.Add(foodRadioButton2[i]);
                root.Add(kitchenRadioButton2[i]);
            }

            utilityRadioButton[2].IsEnabled = false;
            familyRadioButton[2].IsEnabled = false;
            foodRadioButton[2].IsEnabled = false;
            kitchenRadioButton[2].IsEnabled = false;

            utilityRadioButton2[2].IsEnabled = false;
            familyRadioButton2[2].IsEnabled = false;
            foodRadioButton2[2].IsEnabled = false;
            kitchenRadioButton2[2].IsEnabled = false;

            utilityRadioButton[3].IsEnabled = false;
            familyRadioButton[3].IsEnabled = false;
            foodRadioButton[3].IsEnabled = false;
            kitchenRadioButton[3].IsEnabled = false;
            utilityRadioButton[3].IsSelected = true;
            familyRadioButton[3].IsSelected = true;
            foodRadioButton[3].IsSelected = true;
            kitchenRadioButton[3].IsSelected = true;

            utilityRadioButton2[3].IsEnabled = false;
            familyRadioButton2[3].IsEnabled = false;
            foodRadioButton2[3].IsEnabled = false;
            kitchenRadioButton2[3].IsEnabled = false;
            utilityRadioButton2[3].IsSelected = true;
            familyRadioButton2[3].IsSelected = true;
            foodRadioButton2[3].IsSelected = true;
            kitchenRadioButton2[3].IsSelected = true;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                int num = 4;
                for (int i = 0; i < num; i++)
                {
                    root.Remove(utilityRadioButton[i]);
                    utilityRadioButton[i].Dispose();
                    utilityRadioButton[i] = null;

                    root.Remove(familyRadioButton[i]);
                    familyRadioButton[i].Dispose();
                    familyRadioButton[i] = null;

                    root.Remove(foodRadioButton[i]);
                    foodRadioButton[i].Dispose();
                    foodRadioButton[i] = null;

                    root.Remove(kitchenRadioButton[i]);
                    kitchenRadioButton[i].Dispose();
                    kitchenRadioButton[i] = null;

                    root.Remove(modeText[i]);
                    modeText[i].Dispose();
                    modeText[i] = null;

                    root.Remove(utilityRadioButton2[i]);
                    utilityRadioButton2[i].Dispose();
                    utilityRadioButton2[i] = null;

                    root.Remove(familyRadioButton2[i]);
                    familyRadioButton2[i].Dispose();
                    familyRadioButton2[i] = null;

                    root.Remove(foodRadioButton2[i]);
                    foodRadioButton2[i].Dispose();
                    foodRadioButton2[i] = null;

                    root.Remove(kitchenRadioButton2[i]);
                    kitchenRadioButton2[i].Dispose();
                    kitchenRadioButton2[i] = null;

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
