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
    internal class DefaultGridItemExample : ContentPage, IExample
    {
        private Window window;
        public void Activate()
        {
        }
        public void Deactivate()
        {
            window = null;
        }
        DefaultGridItem CreateItem(int width, int height, string resource = null, string text = null)
        {
            var item = new DefaultGridItem()
            {
                WidthSpecification = width,
                HeightSpecification = height,
                LabelOrientationType = DefaultGridItem.LabelOrientation.InsideBottom,
            };
            item.Image.ResourceUrl = resource;
            item.Image.WidthResizePolicy = ResizePolicyType.FillToParent;
            item.Image.HeightResizePolicy = ResizePolicyType.FillToParent;
            if (text != null) item.Text = text;
            return item;
        }

        void CreateItems(View parent, int width, int height, string resource = null, string text = null)
        {
            var horizBox = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = height + 30,
                ScrollingDirection = ScrollableBase.Direction.Horizontal,
                HideScrollbar = false,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 0),
                },
            };

            var enabledItem = CreateItem(width, height, null, text);
            horizBox.Add(enabledItem);

            var disabledItem = CreateItem(width, height, null, text);
            disabledItem.IsEnabled = false;
            horizBox.Add(disabledItem);

            var selectedItem = CreateItem(width, height, null, text);
            selectedItem.IsSelectable = true;
            selectedItem.IsSelected = true;
            horizBox.Add(selectedItem);

            var imageItem = CreateItem(width, height, resource, text);
            horizBox.Add(imageItem);


            parent.Add(horizBox);
        }

        /// Modify this method for adding other examples.
        public DefaultGridItemExample() : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "DefaultLinearItem Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            var rootContent = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ScrollingDirection = ScrollableBase.Direction.Vertical,
                HideScrollbar = false,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(0, 20),
                },
            };

            var path = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

            CreateItems(rootContent, 114, 114, path + "/images/grid_01.jpg");
            CreateItems(rootContent, 114, 114, path + "/images/grid_01.jpg", "Small");
            CreateItems(rootContent, 138, 138, path + "/images/grid_02.jpg");
            CreateItems(rootContent, 138, 138, path + "/images/grid_02.jpg", "Medium");
            CreateItems(rootContent, 252, 252, path + "/images/grid_03.jpg");
            CreateItems(rootContent, 252, 252, path + "/images/grid_03.jpg", "Large");

            Content = rootContent;
        }
    }
}
