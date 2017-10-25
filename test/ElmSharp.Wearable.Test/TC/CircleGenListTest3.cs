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

using ElmSharp.Wearable;

namespace ElmSharp.Test.TC
{
    class CircleGenListTest3 : TestCaseBase
    {
        public override string TestName => "CircleGenListTest3";
        public override string TestDescription => "To display a genlist applied a circle UI on a naviframe";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            var naviframe = new Naviframe(conformant);

            conformant.SetContent(naviframe);

            var surface = new CircleSurface(conformant);

            var list = new CircleGenList(naviframe, surface)
            {
                Homogeneous = true,
                VerticalScrollBarVisiblePolicy = ScrollBarVisiblePolicy.Auto,
                IsEnabled = false,
            };
            ((IRotaryActionWidget)list).Activate();
            var item = naviframe.Push(list);
            item.Style = "empty";

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
