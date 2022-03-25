/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.StyleGuide
{
    // IExample inehrited class will be automatically added in the main examples list.
    internal class SwitchExample : ContentPage, IExample
    {
        private View rootContent;
        private Switch[] switchTest = new Switch[4];
        private string path;

        public void Activate()
        {
        }
        public void Deactivate()
        {
        }

        /// Modify this method for adding other examples.
        public SwitchExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "Switch Default Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            rootContent = new View()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 20),
                },
            };

            path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            CreateSwitchView();

            Content = rootContent;
        }

        private void CreateSwitchView()
        {
            // Create switch styles
            SwitchStyle styleTest = new SwitchStyle
            {
                Size = new Size(100, 100),
                IsSelectable = true,
                Track = new ImageViewStyle
                {
                    ResourceUrl = new Selector<string>
                    {
                        Normal = path + "/switch/controller_switch_bg_off.png",
                        Selected = path + "/switch/controller_switch_bg_on.png",
                        Disabled = path + "/switch/controller_switch_bg_off_dim.png",
                        DisabledSelected = path + "/switch/controller_switch_bg_on_dim.png",
                    },
                    Size = new Size(200, 100),
                    Border = new Rectangle(30, 30, 30, 30),
                },
                Thumb = new ImageViewStyle
                {
                    Size = new Size(100, 100),
                    ResourceUrl = new Selector<string>
                    {
                        Normal = path + "/switch/controller_switch_handler.png",
                        Selected = path + "/switch/controller_switch_handler.png",
                        Disabled = path + "/switch/controller_switch_handler_dim.png",
                        DisabledSelected = path + "/switch/controller_switch_handler_dim.png",
                    },
                },
            };

            // Create by Property
            for (int i = 0; i < 4; i++)
            {
                switchTest[i] = new Switch();
                switchTest[i].ApplyStyle(styleTest);
                switchTest[i].Size = new Size(200, 100);
                switchTest[i].Margin = new Extents(10, 10, 10, 10);
                switchTest[i].Feedback = true;
                rootContent.Add(switchTest[i]);
            }
            switchTest[2].IsEnabled = false;
            switchTest[3].IsSelected = true;
        }
    }
}
