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

namespace ElmSharp.Test.Wearable
{
    public class GenListTest5 : WearableTestCase
    {
        public override string TestName => "GenListTest5";
        public override string TestDescription => "To test event operation of GenList";

        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            GenList list = new GenList(window)
            {
                Homogeneous = true
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
            list.Show();
            list.ItemSelected += List_ItemSelected; ;
            list.ItemActivated += List_ItemActivated;
            list.ItemUnselected += List_ItemUnselected;
            list.ItemPressed += List_ItemPressed;
            list.ItemRealized += List_ItemRealized;
            list.ItemReleased += List_ItemReleased;
            list.ItemUnrealized += List_ItemUnrealized;
            list.ItemLongPressed += List_ItemLongPressed;
            list.ItemDoubleClicked += List_ItemDoubleClicked;

            list.Geometry = window.GetInnerSquare();
        }

        private void List_ItemDoubleClicked(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was double clicked", (string)(e.Item.Data)));
        }

        private void List_ItemLongPressed(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was Long pressed", (string)(e.Item.Data)));
        }

        private void List_ItemUnrealized(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was unrealzed", (string)(e.Item.Data)));
        }

        private void List_ItemReleased(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was released", (string)(e.Item.Data)));
        }

        private void List_ItemRealized(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was Realized", (string)(e.Item.Data)));
        }

        private void List_ItemPressed(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was Pressed", (string)(e.Item.Data)));
        }

        private void List_ItemUnselected(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was unselected", (string)(e.Item.Data)));
        }

        private void List_ItemActivated(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was Activated", (string)(e.Item.Data)));
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Log.Debug(string.Format("{0} Item was selected", (string)(e.Item.Data)));
        }
    }
}
