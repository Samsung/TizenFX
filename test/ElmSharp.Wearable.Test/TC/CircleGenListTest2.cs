/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    class CircleGenListTest2 : TestCaseBase
    {
        public override string TestName => "CircleGenListTest2";
        public override string TestDescription => "To display a genlist applied a circle UI on a layout";

        public override void Run(Window window)
        {
            var layout = new Layout(window);
            layout.Show();

            layout.Move(0, 0);
            layout.Resize(360, 360);

            var surface = new CircleSurface(layout);

            var list = new CircleGenList(layout, surface)
            {
                Homogeneous = true,
                VerticalScrollBackgroundRadius = 165,
                VerticalScrollBarRadius = 165,
                VerticalScrollBackgroundLineWidth = 30,
                VerticalScrollBarLineWidth = 30,
            };
            list.Show();
            ((IRotaryActionWidget)list).Activate();
            list.Move(0, 0);
            list.Resize(360, 360);
            list.Lower();


            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}",(string)obj, part);
                }
            };

            for (int i = 0; i < 100; i++)
            {
                list.Append(defaultClass, string.Format("{0} Item", i));
            }
            list.ItemSelected += List_ItemSelected; ;
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Log.Debug(TestName, "{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
