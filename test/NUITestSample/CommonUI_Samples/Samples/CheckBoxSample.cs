using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace NuiCommonUiSamples
{

    public class CheckBox : IExample
    {
        private SampleLayout root;

        private static readonly int Height = 150;
        private static readonly int Width = 216;

        private uint colNum;
        private uint rowNum;

        private Tizen.NUI.CommonUI.CheckBoxGroup[] group;

        private static string[] styles = new string[]
        {
            "enabled",
            "enabled",
            "disabled",
            "disabledSelected",
        };

        private static string[] applications = new string[]
        {
            "Group1",
            "Group2",
            "Group3",
            "Group4",
        };

        private TableView table;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout();
            root.HeaderText = "CheckBox";

            if (styles.Length == 0 || applications.Length == 0)
            {
                return;
            }
            colNum = (uint)applications.Length + 1;
            rowNum = (uint)styles.Length + 1;

            table = new TableView(rowNum, colNum)
            {
                Size2D = new Size2D(1080, 1920),
            };
            for (uint i = 1; i < rowNum; i++)
            {
                TextLabel text = new TextLabel();
                text.Size2D = new Size2D(Width, Height);
                text.PointSize = 12;
                text.Focusable = true;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = styles[i - 1];
                table.AddChild(text, new TableView.CellPosition(i, 0));
            }

            for (uint i = 1; i < colNum; i++)
            {
                TextLabel text = new TextLabel();
                text.Size2D = new Size2D(Width, Height);
                text.PointSize = 12;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = applications[i - 1];
                text.Focusable = true;
                table.AddChild(text, new TableView.CellPosition(0, i));
            }
            group = new CheckBoxGroup[4];
            for (uint j = 1; j < colNum; j++)
            {
                group[j - 1] = new CheckBoxGroup();
                for (uint i = 1; i < rowNum; i++)
                {
                    Tizen.NUI.CommonUI.CheckBox checkBox = new Tizen.NUI.CommonUI.CheckBox("CheckBox");
                    checkBox.Size2D = new Size2D(48, 48);
                    if (i == 3)
                    {
                        checkBox.IsEnabled = false;
                    }
                    else if (i == 4)
                    {
                        checkBox.IsEnabled = false;
                        checkBox.IsSelected = true;
                    }
                    else
                    {
                        group[j - 1].Add(checkBox);
                    }
                    checkBox.Focusable = true;
                    //checkBox.Text = checkBox.IsSelected.ToString();
                    checkBox.SelectedEvent += CheckBoxSelectedEvent;
                    table.AddChild(checkBox, new TableView.CellPosition(i, j));
                }
            }

            for (uint i = 0; i < rowNum; i++)
            {
                table.SetFixedHeight(i, Height);
                for (uint j = 0; j < colNum; j++)
                {
                    table.SetFixedWidth(j, Width);
                    table.SetCellAlignment(new TableView.CellPosition(i, j), HorizontalAlignmentType.Center, VerticalAlignmentType.Center);
                }
            }

            root.Add(table);
        }

        private void CheckBoxSelectedEvent(object sender, SelectButton.SelectEventArgs e)
        {
            Tizen.NUI.CommonUI.CheckBox obj = sender as Tizen.NUI.CommonUI.CheckBox;
            for (uint i = 0; i < rowNum; i++)
            {
                for (uint j = 0; j < colNum; j++)
                {
                    Tizen.NUI.CommonUI.CheckBox child = table.GetChildAt(new TableView.CellPosition(i, j)) as Tizen.NUI.CommonUI.CheckBox;
                    if (child != null)
                    {
                        //child.Text = child.IsSelected.ToString();
                    }
                }
            }
        }

        public void Deactivate()
        {
            for (uint i = 0; i < rowNum; i++)
            {
                for (uint j = 0; j < colNum; j++)
                {
                    View child = table.GetChildAt(new TableView.CellPosition(i, j));
                    if (child != null)
                    {
                        table.RemoveChildAt(new TableView.CellPosition(i, j));
                        child.Dispose();
                    }
                }
            }

            if (root != null)
            {
                if (table != null)
                {
                    root.Remove(table);
                    table.Dispose();
                }
                root.Dispose();
            }
        }
    }
}
