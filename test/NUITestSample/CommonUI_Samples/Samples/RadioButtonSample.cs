using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace NuiCommonUiSamples
{
    public class RadioButton : IExample
    {
        private SampleLayout root;

        private static readonly int Height = 150;
        private static readonly int Width = 216;

        private uint colNum;
        private uint rowNum;

        private Tizen.NUI.CommonUI.RadioButtonGroup[] group;

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
            root.HeaderText = "RadioButton";

            if (styles.Length == 0 || applications.Length == 0)
            {
                return;
            }
            colNum = (uint)applications.Length + 1;
            rowNum = (uint)styles.Length + 1;

            table = new TableView(rowNum, colNum)
            {
                Size2D = new Size2D(1920, 1080),
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

            group = new RadioButtonGroup[4];
            for (uint j = 1; j < colNum; j++)
            {
                group[j - 1] = new RadioButtonGroup();
                for (uint i = 1; i < rowNum; i++)
                {
                    Tizen.NUI.CommonUI.RadioButton radioButton = new Tizen.NUI.CommonUI.RadioButton("RadioButton");
                    radioButton.Size2D = new Size2D(48, 48);
                    if (i == 3)
                    {
                        radioButton.IsEnabled = false;
                    }
                    else if (i == 4)
                    {
                        radioButton.IsEnabled = false;
                        radioButton.IsSelected = true;
                    }
                    else
                    {
                        group[j - 1].Add(radioButton);
                    }
                    radioButton.Focusable = true;
                    //radioButton.Text = radioButton.IsSelected.ToString();
                    radioButton.SelectedEvent += RadioButtonSelectedEvent;
                    table.AddChild(radioButton, new TableView.CellPosition(i, j));
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

        private void RadioButtonSelectedEvent(object sender, SelectButton.SelectEventArgs e)
        {
            Tizen.NUI.CommonUI.RadioButton obj = sender as Tizen.NUI.CommonUI.RadioButton;
            for (uint i = 0; i < rowNum; i++)
            {
                for (uint j = 0; j < colNum; j++)
                {
                    Tizen.NUI.CommonUI.RadioButton child = table.GetChildAt(new TableView.CellPosition(i, j)) as Tizen.NUI.CommonUI.RadioButton;
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
