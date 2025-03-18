/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUILayout
{
    internal class AbsoluteBoundsPMargin : View, IExample
    {
        public AbsoluteBoundsPMargin()
        {
            Layout = new AbsoluteLayout();
            WidthSpecification = LayoutParamPolicies.MatchParent;
            HeightSpecification = LayoutParamPolicies.MatchParent;
            BackgroundColor = Color.Gray;

            var absoluteLayout = new View()
            {
                Layout = new AbsoluteLayout(),
                BackgroundColor = Color.DarkGray,
                Margin = 100,
            };
            AbsoluteLayout.SetLayoutBounds(absoluteLayout, new UIRect(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(absoluteLayout, AbsoluteLayoutFlags.All);
            Add(absoluteLayout);

            var origin = new View()
            {
                Layout = new AbsoluteLayout(),
                BackgroundColor = Color.LightBlue,
            };
            AbsoluteLayout.SetLayoutBounds(origin, new UIRect(0, 0, 100, 100));
            absoluteLayout.Add(origin);

            var view = new View()
            {
                Layout = new AbsoluteLayout(),
                BackgroundColor = Color.Blue,
            };
            AbsoluteLayout.SetLayoutBounds(view, new UIRect(100, 100, 100, 100));
            absoluteLayout.Add(view);

            var timer = new Tizen.NUI.Timer(1000);
            timer.Tick += (o, e) =>
            {
                view.Layout.RequestLayout(); // Test if AbsoluteLayout position is updated unexpectedly.
                return true;
            };
            timer.Start();
        }

        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            var contentPage = new ContentPage()
            {
                AppBar = new AppBar() { Title = "Bounds ParentMargin", BackgroundColor = Color.White },
                Content = this,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                BackgroundColor = Color.LightGray,
            };
            Window.Default.GetDefaultNavigator().Push(contentPage);
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            Window.Default.GetDefaultNavigator().Pop();
        }
    }
}
