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
            createText[0].Text = "Create Switch just by properties";
            createText[0].Size2D = new Size2D(500, 100);
            createText[0].Position2D = new Position2D(400, 100);
            root.Add(createText[0]);

            int num = 4;
            for (int i = 0; i < num; i++)
            {
                modeText[i] = new TextLabel();
                modeText[i].Text = mode[i];
                modeText[i].Size2D = new Size2D(200, 48);
                modeText[i].Position2D = new Position2D(300 + 200 * i, 200);
                root.Add(modeText[i]);
            }

            for (int i = 0; i < num; i++)
            {
                utilitySwitch[i] = new Switch();
                utilitySwitch[i].Size2D = new Size2D(96, 60);
                utilitySwitch[i].Position2D = new Position2D(300, 300 + i * 100);
                utilitySwitch[i].Style.Thumb.Size = new Size(60, 60);
                utilitySwitch[i].Style.Track.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_on.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off_dim.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_on_dim.png",
                };
                utilitySwitch[i].Style.Thumb.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                };

                ////////
                familySwitch[i] = new Switch();
                familySwitch[i].Size2D = new Size2D(96, 60);
                familySwitch[i].Position2D = new Position2D(500, 300 + i * 100);
                familySwitch[i].Style.Thumb.Size = new Size(60, 60);
                familySwitch[i].Style.Track.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_24c447.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_dim_24c447.png",
                };
                familySwitch[i].Style.Thumb.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                };
                /////////
                foodSwitch[i] = new Switch();
                foodSwitch[i].Size2D = new Size2D(96, 60);
                foodSwitch[i].Position2D = new Position2D(700, 300 + i * 100);
                foodSwitch[i].Style.Thumb.Size = new Size(60, 60);
                foodSwitch[i].Style.Track.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_ec7510.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_dim_ec7510.png",
                };
                foodSwitch[i].Style.Thumb.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                };

                ////////
                kitchenSwitch[i] = new Switch();
                kitchenSwitch[i].Size2D = new Size2D(96, 60);
                kitchenSwitch[i].Position2D = new Position2D(900, 300 + i * 100);
                kitchenSwitch[i].Style.Thumb.Size = new Size(60, 60);
                kitchenSwitch[i].Style.Track.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_9762d9.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_bg_off.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/[Controller] App Primary Color/controller_switch_bg_on_dim_9762d9.png",
                };
                kitchenSwitch[i].Style.Thumb.ResourceUrl = new Selector<string>
                {
                    Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                    Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                };

                root.Add(utilitySwitch[i]);
                root.Add(familySwitch[i]);
                root.Add(foodSwitch[i]);
                root.Add(kitchenSwitch[i]);
            }

            ///////////////////////////////////////////////Create by Attributes//////////////////////////////////////////////////////////
            createText[1] = new TextLabel();
            createText[1].Text = "Create Switch just by Attributes";
            createText[1].Size2D = new Size2D(500, 100);
            createText[1].Position2D = new Position2D(1200, 100);
            root.Add(createText[1]);

            for (int i = 0; i < num; i++)
            {
                modeText2[i] = new TextLabel();
                modeText2[i].Text = mode[i];
                modeText2[i].Size2D = new Size2D(200, 48);
                modeText2[i].Position2D = new Position2D(1100 + 200 * i, 200);
                root.Add(modeText2[i]);
            }

            SwitchStyle utilityAttrs = new SwitchStyle
            {
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
                },
                Thumb = new ImageViewStyle
                {
                    Size =  new Size(60, 60),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Selected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler.png",
                        Disabled = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                        DisabledSelected = CommonResource.GetFHResourcePath() + "9. Controller/controller_switch_handler_dim.png",
                    },
                },               
            };
            for (int i = 0; i < num; i++)
            {
                utilitySwitch2[i] = new Switch(utilityAttrs);
                utilitySwitch2[i].Size2D = new Size2D(96, 60);
                utilitySwitch2[i].Position2D = new Position2D(1100, 300 + i * 100);

                familySwitch2[i] = new Switch(familyAttrs);
                familySwitch2[i].Size2D = new Size2D(96, 60);
                familySwitch2[i].Position2D = new Position2D(1300, 300 + i * 100);

                foodSwitch2[i] = new Switch(foodAttrs);
                foodSwitch2[i].Size2D = new Size2D(96, 60);
                foodSwitch2[i].Position2D = new Position2D(1500, 300 + i * 100);

                kitchenSwitch2[i] = new Switch(kitchenAttrs);
                kitchenSwitch2[i].Size2D = new Size2D(96, 60);
                kitchenSwitch2[i].Position2D = new Position2D(1700, 300 + i * 100);

                root.Add(utilitySwitch2[i]);
                root.Add(familySwitch2[i]);
                root.Add(foodSwitch2[i]);
                root.Add(kitchenSwitch2[i]);
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

                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
