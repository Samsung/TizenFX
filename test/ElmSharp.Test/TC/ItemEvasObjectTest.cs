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
using ElmSharp;

namespace ElmSharp.Test
{
    class ItemEvasObjectTest : TestCaseBase
    {
        public override string TestName => "ItemEvasObjectTest";
        public override string TestDescription => "To test basic operation of ItemEvasObject";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();

            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            conformant.SetContent(box);
            box.Show();

            Label label = new Label(window)
            {
                AlignmentX = -1,
                WeightX = 1,
                BackgroundColor = Color.White,
                Text = "Selected"
            };

            GenList list = new GenList(window)
            {
                Homogeneous = true,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass defaultClass = new GenItemClass("default")
            {
                GetTextHandler = (obj, part) =>
                {
                    return string.Format("{0} - {1}", (string)obj, part);
                }
            };

            for (int i = 0; i < 100; i++)
            {
                list.Append(defaultClass, string.Format("{0} Item", i));
            }
            list.SelectionMode = GenItemSelectionMode.Always;
            list.ItemSelected += (s, e) =>
            {
                Log.Debug((string)(e.Item.Data) + "item selected");
                Log.Debug("Item Geometry: " + e.Item.TrackObject.Geometry.ToString());

                label.Text = "selected Item Geometry: " + e.Item.TrackObject.Geometry.ToString();
            };

            label.Show();
            list.Show();

            box.PackEnd(label);
            box.PackEnd(list);
        }
    }
}
