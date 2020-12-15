using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class SwitchSample : IExample
    {
        private View root;
        private View[] parentView = new View[3];
        private TextLabel[] createText = new TextLabel[2];
        private TextLabel[] modeText = new TextLabel[4];
        private TextLabel[] modeText2 = new TextLabel[4];

        private Switch[] utilitySwitch = new Switch[4];
        private Switch[] familySwitch = new Switch[4];
        private Switch[] foodSwitch = new Switch[4];
        private Switch[] kitchenSwitch = new Switch[4];

        private Switch[] utilitySwitch2 = new Switch[4];
        private Switch[] familySwitch2 = new Switch[4];
        private Switch[] foodSwitch2 = new Switch[4];
        private Switch[] kitchenSwitch2 = new Switch[4];
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
            };
            root.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            window.Add(root);

            CreateTextView();
            CreateModeView();
            CreateSwitchView();
        }

        private void CreateTextView()
        {
            // Init parent of TextView
            parentView[0] = new View();
            parentView[0].Size = new Size(1920, 200);
            parentView[0].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.CenterVertical, CellPadding = new Size2D(180, 0) };
            root.Add(parentView[0]);

            for (int i = 0; i < 2; i++)
            {
                createText[i] = new TextLabel();
                createText[i].Size = new Size(600, 100);
                createText[i].PointSize = 20.0f;
                createText[i].BackgroundColor = Color.Magenta;
                createText[i].HorizontalAlignment = HorizontalAlignment.Center;
                createText[i].VerticalAlignment = VerticalAlignment.Center;
                parentView[0].Add(createText[i]);
            }

            // Text of "Create Switch just by properties"
            createText[0].Text = "Create Switch just by Properties";
            createText[0].Margin = new Extents(160, 0, 0, 0);

            // Text of "Create Switch just by Style"
            createText[1].Text = "Create Switch just by Style";
        }

        private void CreateModeView()
        {
            // Init parent of ModeView
            parentView[1] = new View();
            parentView[1].Size = new Size(1920, 100);
            parentView[1].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, CellPadding = new Size2D(0, 0) };
            root.Add(parentView[1]);

            // Create mode text
            for (int i = 0; i < 4; i++)
            {
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].Size = new Size(196, 48);
                modeText[i].PointSize = 20.0f;
                parentView[1].Add(modeText[i]);
            }
            modeText[0].Margin = new Extents(100, 0, 0, 0);

            for (int j = 0; j < 4; j++)
            {
                modeText2[j] = new TextLabel();
                modeText2[j].Text = mode[j];
                modeText2[j].Size = new Size(196, 48);
                modeText2[j].PointSize = 20.0f;
                parentView[1].Add(modeText2[j]);
            }
        }

        private void CreateSwitchView()
        {
            // Init parent of SwitchView
            parentView[2] = new View();
            parentView[2].Size = new Size(1920, 680);
            parentView[2].Layout = new GridLayout() { Rows = 4, GridOrientation = GridLayout.Orientation.Horizontal };
            root.Add(parentView[2]);

            // Create switch styles
            SwitchStyle utilitySt = new SwitchStyle
            {
                Size = new Size(96, 60),
                IsSelectable = true,
                Track = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_on.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_on_dim.png",
                    },
                    Border = new Rectangle(30, 30, 30, 30),
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    },
                },
            };
            SwitchStyle familySt = new SwitchStyle
            {
                IsSelectable = true,
                Track = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_24c447.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_dim_24c447.png",
                    },
                    Border = new Rectangle(30, 30, 30, 30),
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    },
                },
            };
            SwitchStyle foodSt = new SwitchStyle
            {
                IsSelectable = true,
                Track = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_ec7510.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_dim_ec7510.png",
                    },
                    Border = new Rectangle(30, 30, 30, 30),
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    },
                },
            };
            SwitchStyle kitchenSt = new SwitchStyle
            {
                IsSelectable = true,
                Track = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_9762d9.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_dim_9762d9.png",
                    },
                    Border = new Rectangle(30, 30, 30, 30),
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    },
                },
            };

            ///////////////////////////////////////////////Create by Property//////////////////////////////////////////////////////////
            int i = 0;
            for (; i < 4; i++)
            {
                utilitySwitch[i] = new Switch();
                utilitySwitch[i].ApplyStyle(utilitySt);
                utilitySwitch[i].Size = new Size(96, 60);
                utilitySwitch[i].Margin = new Extents(100, 0, 20, 0);
                utilitySwitch[i].Feedback = true;
                parentView[2].Add(utilitySwitch[i]);
            }
            for (i = 0; i < 4; i++)
            {
                familySwitch[i] = new Switch();
                familySwitch[i].ApplyStyle(familySt);
                familySwitch[i].Size = new Size(96, 60);
                familySwitch[i].Feedback = true;
                parentView[2].Add(familySwitch[i]);
            }
            for (i = 0; i < 4; i++)
            {
                foodSwitch[i] = new Switch();
                foodSwitch[i].ApplyStyle(foodSt);
                foodSwitch[i].Size = new Size(96, 60);
                foodSwitch[i].Feedback = true;
                parentView[2].Add(foodSwitch[i]);
            }
            for (i = 0; i < 4; i++)
            {
                kitchenSwitch[i] = new Switch();
                kitchenSwitch[i].ApplyStyle(kitchenSt);
                kitchenSwitch[i].Size = new Size(96, 60);
                kitchenSwitch[i].Feedback = true;
                parentView[2].Add(kitchenSwitch[i]);
            }

            ///////////////////////////////////////////////Create by Style//////////////////////////////////////////////////////////
            for (i = 0; i < 4; i++)
            {
                utilitySwitch2[i] = new Switch();
                utilitySwitch2[i].ApplyStyle(utilitySt);
                utilitySwitch2[i].Size = new Size(96, 60);
                utilitySwitch2[i].Feedback = true;
                parentView[2].Add(utilitySwitch2[i]);
            }
            for (i = 0; i < 4; i++)
            {
                familySwitch2[i] = new Switch();
                familySwitch2[i].ApplyStyle(familySt);
                familySwitch2[i].Size = new Size(96, 60);
                familySwitch2[i].Feedback = true;
                parentView[2].Add(familySwitch2[i]);
            }
            for (i = 0; i < 4; i++)
            {
                foodSwitch2[i] = new Switch();
                foodSwitch2[i].ApplyStyle(foodSt);
                foodSwitch2[i].Size = new Size(96, 60);
                foodSwitch2[i].Feedback = true;
                parentView[2].Add(foodSwitch2[i]);
            }
            for (i = 0; i < 4; i++)
            {
                kitchenSwitch2[i] = new Switch();
                kitchenSwitch2[i].ApplyStyle(kitchenSt);
                kitchenSwitch2[i].Size = new Size(96, 60);
                kitchenSwitch2[i].Feedback = true;
                parentView[2].Add(kitchenSwitch2[i]);
            }

            utilitySwitch[2].IsEnabled = false;
            familySwitch[2].IsEnabled = false;
            foodSwitch[2].IsEnabled = false;
            kitchenSwitch[2].IsEnabled = false;

            utilitySwitch2[2].IsEnabled = false;
            familySwitch2[2].IsEnabled = false;
            foodSwitch2[2].IsEnabled = false;
            kitchenSwitch2[2].IsEnabled = false;

            utilitySwitch[3].IsEnabled = false;
            familySwitch[3].IsEnabled = false;
            foodSwitch[3].IsEnabled = false;
            kitchenSwitch[3].IsEnabled = false;
            utilitySwitch[3].IsSelected = true;
            familySwitch[3].IsSelected = true;
            foodSwitch[3].IsSelected = true;
            kitchenSwitch[3].IsSelected = true;

            utilitySwitch2[3].IsEnabled = false;
            familySwitch2[3].IsEnabled = false;
            foodSwitch2[3].IsEnabled = false;
            kitchenSwitch2[3].IsEnabled = false;
            utilitySwitch2[3].IsSelected = true;
            familySwitch2[3].IsSelected = true;
            foodSwitch2[3].IsSelected = true;
            kitchenSwitch2[3].IsSelected = true;
        }

        public void Deactivate()
        {
            if (root != null)
            {
                int num = 4;
                for (int i = 0; i < num; i++)
                {
                    utilitySwitch[i].Dispose();
                    utilitySwitch[i] = null;

                    familySwitch[i].Dispose();
                    familySwitch[i] = null;

                    foodSwitch[i].Dispose();
                    foodSwitch[i] = null;

                    kitchenSwitch[i].Dispose();
                    kitchenSwitch[i] = null;

                    modeText[i].Dispose();
                    modeText[i] = null;

                    utilitySwitch2[i].Dispose();
                    utilitySwitch2[i] = null;

                    familySwitch2[i].Dispose();
                    familySwitch2[i] = null;

                    foodSwitch2[i].Dispose();
                    foodSwitch2[i] = null;

                    kitchenSwitch2[i].Dispose();
                    kitchenSwitch2[i] = null;

                    modeText2[i].Dispose();
                    modeText2[i] = null;
                }

                createText[0].Dispose();
                createText[0] = null;
                createText[1].Dispose();
                createText[1] = null;

                for (int j = 0; j < 3; j++)
                {
                    if (parentView[j] != null)
                    {
                        parentView[j].Dispose();
                        parentView[j] = null;
                    }
                }
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
