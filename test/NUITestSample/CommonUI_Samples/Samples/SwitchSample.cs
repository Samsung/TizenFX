using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace NuiCommonUiSamples
{
    public class Switch : IExample
    {
        private SampleLayout root;

        private static readonly int Height = 150;
        private static readonly int Width = 216;

        private uint colNum;
        private uint rowNum;

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
            root.HeaderText = "Switch";

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
                text.Size2D = new Size2D(Width, 150);
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
                text.Size2D = new Size2D(Width, 150);
                text.PointSize = 12;
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.Text = applications[i - 1];
                text.Focusable = true;
                table.AddChild(text, new TableView.CellPosition(0, i));
            }

            for (uint j = 1; j < colNum; j++)
            {
                for (uint i = 1; i < rowNum; i++)
                {
                    Tizen.NUI.CommonUI.Switch switchControl = new Tizen.NUI.CommonUI.Switch("Switch");
                    switchControl.Size2D = new Size2D(96, 60);
                    if (i == 3)
                    {
                        switchControl.IsEnabled = false;
                    }
                    else if (i == 4)
                    {
                        switchControl.IsEnabled = false;
                        switchControl.IsSelected = true;
                    }
                    table.AddChild(switchControl, new TableView.CellPosition(i, j));
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
