using System;
using ElmSharp;

namespace ElmSharp.Test
{
    public class ListTest1 : TestCaseBase
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
            box.PackEnd(append);
            box.PackEnd(prepend);
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
