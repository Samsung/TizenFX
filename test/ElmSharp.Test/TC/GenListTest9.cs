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
using System.Collections.Generic;

namespace ElmSharp.Test
{
    class GenListTest9 : TestCaseBase
    {

        public class ItemContext
        {
            public object Data;
            public GenListItem Item;
            public EvasObject Realized;
        }

        Dictionary<EvasObject, Button> _cacheMap = new Dictionary<EvasObject, Button>();

        Dictionary<ItemObject, EvasObject> _realizedMap = new Dictionary<ItemObject, EvasObject>();
        public override string TestName => "GenListTest9";
        public override string TestDescription => "To test FieldUpdate operation of GenList";

        public override void Run(Window window)
        {
            Background bg = new Background(window)
            {
                Color = Color.White,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            bg.Show();
            bg.Lower();

            window.AddResizeObject(bg);
            Conformant conformant = new Conformant(window);
            conformant.Show();
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            GenList list = new GenList(window)
            {
                Homogeneous = false,
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };

            GenItemClass fullyCustomizeClass = new GenItemClass("full")
            {
                GetContentHandler = (obj, part) =>
                {
                    Console.WriteLine("{0} part create requested", part);
                    var btn = new Button(window)
                    {
                        AlignmentX = -1,
                        WeightX = 1,
                        Text = (string)(obj as ItemContext).Data
                    };
                    btn.MinimumHeight = 100;
                    (obj as ItemContext).Realized = btn;
                    (obj as ItemContext).Item?.UpdateField("elm.swallow.content", GenListItemFieldType.None);
                    return btn;
                },
            };

            for (int i = 0; i < 100; i++)
            {
                var context = new ItemContext();
                context.Data = string.Format("{0} Item", i);
                context.Item = list.Append(fullyCustomizeClass, context, GenListItemType.Normal);
            }

            list.Show();
            list.ItemSelected += List_ItemSelected; ;
            box.Show();
            box.PackEnd(list);
            conformant.SetContent(box);
        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            var itemContext = e.Item.Data as ItemContext;
            Console.WriteLine("{0} Item was selected", (string)(itemContext.Data));
            itemContext.Realized.MinimumHeight += 20;
            e.Item.UpdateField("elm.swallow.content", GenListItemFieldType.None);
        }
    }
}
