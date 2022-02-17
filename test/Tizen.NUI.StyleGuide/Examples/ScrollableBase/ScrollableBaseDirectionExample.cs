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
    internal class ScrollableBaseDirectionExample : ContentPage
    {
        int SCROLLMAX = 20;
        public ScrollableBaseDirectionExample(string dir)  : base()
        {
            Log.Info(this.GetType().Name, $"{this.GetType().Name} is contructed\n");

            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;

            bool isHorizontal = (dir == "Horizontal");

            // Navigator bar title is added here.
            AppBar = new AppBar()
            {
                Title = "ScrollableBase " + dir + " Style",
            };

            // Example root content view.
            // you can decorate, add children on this view.
            var scrollView = new ScrollableBase()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                HideScrollbar = false,
            };
            // FIXME: should work focus on ScrollableBase.
            // scrollView.EnableFocus();

            if (isHorizontal)
            {
                scrollView.ScrollingDirection = ScrollableBase.Direction.Horizontal;
                scrollView.Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Horizontal,
                    VerticalAlignment = VerticalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                };
            }
            else
            {
                scrollView.ScrollingDirection = ScrollableBase.Direction.Vertical;
                scrollView.Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    CellPadding = new Size2D(10, 10),
                };
            }

            Random rnd = new Random();

            for (int i = 0; i < SCROLLMAX; i++)
            {
                var colorView = new View();
                colorView.WidthSpecification = (isHorizontal? 200 : LayoutParamPolicies.MatchParent);
                colorView.HeightSpecification = (isHorizontal? LayoutParamPolicies.MatchParent : 200);
                colorView.BackgroundColor = new Color((float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, (float)rnd.Next(256)/256f, 1);
                colorView.EnableFocus();
                scrollView.Add(colorView);
            }

            Content = scrollView;
        }
    }
}