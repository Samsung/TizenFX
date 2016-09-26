using System;
using ElmSharp;

namespace ElmSharp.Test
{
    class GenListTest6 : TestCaseBase
    {
        public override string TestName => "GenListTest6";
        public override string TestDescription => "To test deletion of GenListItem";
        GenListItem selected = null;


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
                },
                DeleteHandler = new GenItemClass.DeleteDelegate((obj) =>
                {
                    Console.WriteLine("DeleteHandler was called with... {0}", (string)obj);
                }),
            };
            GenListItem[] items = new GenListItem[100];
            for (int i = 0; i < 100; i++)
            {
                items[i] = list.Append(defaultClass, string.Format("{0} Item", i));
            }
            list.Show();
            list.ItemSelected += List_ItemSelected;
            list.ItemActivated += List_ItemActivated;
            list.ItemUnselected += List_ItemUnselected;
            list.ItemPressed += List_ItemPressed;
            list.ItemRealized += List_ItemRealized;
            list.ItemReleased += List_ItemReleased;
            list.ItemUnrealized += List_ItemUnrealized;
            list.ItemLongPressed += List_ItemLongPressed;
            list.ItemDoubleClicked += List_ItemDoubleClicked;
            box.PackEnd(list);
            Button first = new Button(window)
            {
                Text = "Delete",
                AlignmentX = -1,
                WeightX = 1,
            };
            first.Clicked += (s, e) =>
            {
                selected?.Delete();
            };
            first.Show();
            box.PackEnd(first);

        }

        private void List_ItemSelected(object sender, GenListItemEventArgs e)
        {
            selected = e.Item;
            Console.WriteLine("{0} Item was selected", (string)(e.Item.Data));
        }
        private void List_ItemDoubleClicked(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was double clicked", (string)(e.Item.Data));
        }

        private void List_ItemLongPressed(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was Long pressed", (string)(e.Item.Data));
        }

        private void List_ItemUnrealized(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("!!!! Item was Unrealized!!!");
            Console.WriteLine("{0} Item was unrealzed", (string)(e.Item.Data));
        }

        private void List_ItemReleased(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was released", (string)(e.Item.Data));
        }

        private void List_ItemRealized(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was Realized", (string)(e.Item.Data));
        }

        private void List_ItemPressed(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was Pressed", (string)(e.Item.Data));
        }

        private void List_ItemUnselected(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was unselected", (string)(e.Item.Data));
        }

        private void List_ItemActivated(object sender, GenListItemEventArgs e)
        {
            Console.WriteLine("{0} Item was Activated", (string)(e.Item.Data));
        }
    }
}
