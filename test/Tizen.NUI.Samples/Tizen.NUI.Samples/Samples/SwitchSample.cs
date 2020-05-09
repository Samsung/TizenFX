using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class SwitchSample : IExample
    {
        private View root;

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

        private View parentTextView;
        private View[] parentView = new View[4];
        private void InitParentView()
        {
            parentTextView = new View();
            parentTextView.Position = new Position(310, 200);
            parentTextView.Size = new Size(1800, 60);
            parentTextView.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
            };
            root.Add(parentTextView);

            for (int i = 0; i < 4; i++)
            {
                parentView[i] = new View();
                parentView[i].Position = new Position(300, 300 + 100 * i);
                parentView[i].Size = new Size(1800, 60);
                parentView[i].Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    CellPadding = new Size2D(104, 60)
                };
                root.Add(parentView[i]);
            }
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            window.Add(root);
            InitParentView();

            SwitchStyle utilityAttrs = new SwitchStyle
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
            SwitchStyle familyAttrs = new SwitchStyle
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
            SwitchStyle foodAttrs = new SwitchStyle
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
            SwitchStyle kitchenAttrs = new SwitchStyle
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
            createText[0] = new TextLabel();
            createText[0].Text = "Create Switch just by properties";
            createText[0].Size = new Size(500, 100);
            createText[0].Position = new Position(400, 100);
            root.Add(createText[0]);

            int num = 4;
            for (int i = 0; i < num; i++)
            {
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].Size = new Size(200, 48);
                modeText[i].PointSize = 20.0f;
                parentTextView.Add(modeText[i]);
            }
            for (int i = 0; i < num; i++)
            {
                utilitySwitch[i] = new Switch();
                utilitySwitch[i].ApplyStyle(utilityAttrs);
                utilitySwitch[i].Size = new Size(96, 60);

                ////////
                familySwitch[i] = new Switch();
                familySwitch[i].ApplyStyle(familyAttrs);
                familySwitch[i].Size = new Size(96, 60);

                ///////////
                foodSwitch[i] = new Switch();
                foodSwitch[i].ApplyStyle(foodAttrs);
                foodSwitch[i].Size = new Size(96, 60);

                //////////
                kitchenSwitch[i] = new Switch();
                kitchenSwitch[i].ApplyStyle(kitchenAttrs);
                kitchenSwitch[i].Size = new Size(96, 60);

                parentView[i].Add(utilitySwitch[i]);
                parentView[i].Add(familySwitch[i]);
                parentView[i].Add(foodSwitch[i]);
                parentView[i].Add(kitchenSwitch[i]);
            }

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create Switch just by Attributes";
            createText[1].Size = new Size(500, 100);
            createText[1].Position = new Position(1200, 100);
            root.Add(createText[1]);

            for (int i = 0; i < num; i++)
            {
                modeText2[i] = new TextLabel();
                modeText2[i].Text = mode[i];
                modeText2[i].Size = new Size(200, 48);
                modeText2[i].PointSize = 20.0f;
                parentTextView.Add(modeText2[i]);
            }

            for (int i = 0; i < num; i++)
            {
                utilitySwitch2[i] = new Switch(utilityAttrs);
                utilitySwitch2[i].Size = new Size(96, 60);

                familySwitch2[i] = new Switch(familyAttrs);
                familySwitch2[i].Size = new Size(96, 60);

                foodSwitch2[i] = new Switch(foodAttrs);
                foodSwitch2[i].Size = new Size(96, 60);

                kitchenSwitch2[i] = new Switch(kitchenAttrs);
                kitchenSwitch2[i].Size = new Size(96, 60);

                parentView[i].Add(utilitySwitch2[i]);
                parentView[i].Add(familySwitch2[i]);
                parentView[i].Add(foodSwitch2[i]);
                parentView[i].Add(kitchenSwitch2[i]);
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
                    root.Remove(utilitySwitch[i]);
                    utilitySwitch[i].Dispose();
                    utilitySwitch[i] = null;

                    root.Remove(familySwitch[i]);
                    familySwitch[i].Dispose();
                    familySwitch[i] = null;

                    root.Remove(foodSwitch[i]);
                    foodSwitch[i].Dispose();
                    foodSwitch[i] = null;

                    root.Remove(kitchenSwitch[i]);
                    kitchenSwitch[i].Dispose();
                    kitchenSwitch[i] = null;

                    root.Remove(modeText[i]);
                    modeText[i].Dispose();
                    modeText[i] = null;

                    root.Remove(utilitySwitch2[i]);
                    utilitySwitch2[i].Dispose();
                    utilitySwitch2[i] = null;

                    root.Remove(familySwitch2[i]);
                    familySwitch2[i].Dispose();
                    familySwitch2[i] = null;

                    root.Remove(foodSwitch2[i]);
                    foodSwitch2[i].Dispose();
                    foodSwitch2[i] = null;

                    root.Remove(kitchenSwitch2[i]);
                    kitchenSwitch2[i].Dispose();
                    kitchenSwitch2[i] = null;

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

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
