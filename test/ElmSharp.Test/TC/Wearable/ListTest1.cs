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

namespace ElmSharp.Test.Wearable
{
    public class ListTest1 : WearableTestCase
    {
        public override string TestName => "ListTest1";
        public override string TestDescription => "To test basic operation of List";
        private int _count = 0;
        public override void Run(Window window)
        {
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
            };
            box.Show();
            conformant.SetContent(box);

            List list = new List(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            _count = 0;

            for (int i = 0; i < 5; i++)
            {
                list.Append(string.Format("{0} item", _count++));
            }

            list.ItemSelected += List_Selected;
            list.ItemUnselected += List_Unselected;
            list.ItemActivated += List_ItemActivated;
            list.ItemDoubleClicked += List_ItemDoubleClicked;
            list.ItemLongPressed += List_ItemLongPressed;
            list.RenderPost += List_RenderPost;
            list.Update();
            list.Show();

            box.PackEnd(list);

            Box buttonBox = new Box(window)
            {
                IsHorizontal = true,
                AlignmentX = -1,
                AlignmentY = 0,
            };
            buttonBox.Show();

            Button append = new Button(window)
            {
                Text = "Append",
                AlignmentX = -1,
                WeightX = 1,
            };
            Button prepend = new Button(window)
            {
                Text = "Prepend",
                AlignmentX = -1,
                WeightX = 1,
            };
            append.Clicked += (s, e) =>
            {
                list.Append(string.Format("{0} item", _count++));
                list.Update();
            };
            prepend.Clicked += (s, e) =>
            {
                list.Prepend(string.Format("{0} item", _count++));
                list.Update();
            };
            append.Show();
            prepend.Show();
            buttonBox.PackEnd(append);
            buttonBox.PackEnd(prepend);
            box.PackEnd(buttonBox);
        }

        int count = 0;
        private void List_RenderPost(object sender, EventArgs e)
        {
            Console.WriteLine("{0} List_RenderPost", count++);
        }

        private void List_ItemLongPressed(object sender, ListItemEventArgs e)
        {
            Console.WriteLine("{0} item was long pressed", e.Item.Text);
        }

        private void List_ItemDoubleClicked(object sender, ListItemEventArgs e)
        {
            Console.WriteLine("{0} item was Double clicked", e.Item.Text);
        }

        private void List_ItemActivated(object sender, ListItemEventArgs e)
        {
            Console.WriteLine("{0} item was Activated", e.Item.Text);
        }

        private void List_Unselected(object sender, ListItemEventArgs e)
        {
            Console.WriteLine("{0} item was unselected", e.Item.Text);
        }

        private void List_Selected(object sender, ListItemEventArgs e)
        {
            Console.WriteLine("{0} item was selected", e.Item.Text);
        }
    }
}
