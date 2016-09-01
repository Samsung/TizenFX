using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class GenListTest2 : TestCaseBase
    {
        public override string TestName => "GenListTest2";
        public override string TestDescription => "To test ScrollTo operation of GenList";

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
            GenListItem[] items = new GenListItem[100];
            for (int i = 0; i < 100; i++)
            {
                items[i] = list.Append(defaultClass, string.Format("{0} Item", i));
            }
            list.Show();
            list.ItemSelected += List_ItemSelected;

            box.PackEnd(list);
            Button first = new Button(window)
            {
                Text = "First",
                AlignmentX = -1,
                WeightX = 1,
            };
            Button last = new Button(window)
            {
                Text = "last",
                AlignmentX = -1,
                WeightX = 1,
            };
            first.Clicked += (s, e) =>
            {
                list.ScrollTo(items[0], ScrollToPosition.In, true);
            };
            last.Clicked += (s, e) =>
            {
                list.ScrollTo(items[99], ScrollToPosition.In, true);
            };
            first.Show();
            last.Show();
            box.PackEnd(first);
            box.PackEnd(last);

        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
    }
}
