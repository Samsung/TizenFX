using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.NUI.Samples
{
    public class ProgressSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button5;
        int status = 0;
        private Progress progressBar1_1, progressBar1_2, progressBar2_1; //1-null para 2-attributes;
        private View root;
        private View  parent, progressParent, propParent, attrParent;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size = new Size(1920, 1080),
            };

            parent = new View()
            {
                Position = new Position(430, 200),
                Size = new Size(1000, 730)
            };
            parent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal
            };

            progressParent = new View()
            {
                Position = new Position(480, 200),
                Size = new Size(900, 630)
            };
            progressParent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal
            };
            parent.Add(progressParent);

            propParent = new View()
            {
                Position = new Position(480, 200),
                Size = new Size(450, 630)
            };
            propParent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size2D(50, 50)
            };
            progressParent.Add(propParent);

            attrParent = new View()
            {
                Position = new Position(480, 930),
                Size = new Size(450, 630)
            };
            attrParent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.CenterHorizontal,
                CellPadding = new Size2D(50, 50)
            };
            progressParent.Add(attrParent);

            board = new TextLabel();
            board.WidthSpecification = 900;
            board.HeightSpecification = 100;
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            board.Text = "log pad";
            parent.Add(board);
            board.Focusable = true;
            board.FocusGained += Board_FocusGained;
            board.FocusLost += Board_FocusLost;

            CreatePropParentLayout();
            CreateAttrParentLayout();

            window.Add(root);
            root.Add(parent);
            board.UpFocusableView = button1;
            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        void CreatePropParentLayout()
        {
            board1 = new TextLabel();
            board1.WidthSpecification = 380;
            board1.HeightSpecification = 70;
            board1.PointSize = 20;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "Property construction";
            propParent.Add(board1);
            board1.Focusable = true;
            board1.FocusGained += Board_FocusGained;
            board1.FocusLost += Board_FocusLost;

            progressBar1_1 = new Progress();
            progressBar1_1.WidthSpecification = 240;
            progressBar1_1.HeightSpecification = 4;
            progressBar1_1.MaxValue = 100;
            progressBar1_1.MinValue = 0;
            progressBar1_1.CurrentValue = 45;
            propParent.Add(progressBar1_1);

            progressBar1_2 = new Progress();
            progressBar1_2.WidthSpecification = 240;
            progressBar1_2.HeightSpecification = 4;
            progressBar1_2.MaxValue = 100;
            progressBar1_2.MinValue = 0;
            progressBar1_2.CurrentValue = 15;
            progressBar1_2.TrackColor = Color.Yellow;
            progressBar1_2.ProgressColor = Color.Red;
            propParent.Add(progressBar1_2);

            button1 = new Button();
            button1.WidthSpecification = 140;
            button1.HeightSpecification = 50;
            button1.ButtonText.Text = "+";
            propParent.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += bar1Add;

            button2 = new Button();
            button2.WidthSpecification = 140;
            button2.HeightSpecification = 50;
            button2.ButtonText.Text = "-";
            propParent.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += bar1Minus;
        }

        private void CreateAttrParentLayout()
        {
            board2 = new TextLabel();
            board2.WidthSpecification = 380;
            board2.HeightSpecification = 70;
            board2.PointSize = 20;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "Attribute construction";
            attrParent.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            ProgressStyle attr = new ProgressStyle
            {
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = Color.Cyan,
                    }
                },
                Progress = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = Color.Black,
                    }
                },
            };
            progressBar2_1 = new Progress(attr);
            progressBar2_1.WidthSpecification = 240;
            progressBar2_1.HeightSpecification = 4;
            progressBar2_1.MaxValue = 100;
            progressBar2_1.MinValue = 0;
            progressBar2_1.CurrentValue = 30;
            attrParent.Add(progressBar2_1);
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Cyan;
        }

        private void bar1Add(object sender, global::System.EventArgs e)
        {
            if (progressBar1_1.CurrentValue == 100)
            {
                board.Text = "Current value is: 100";
            }
            else
            {
                board.Text = "Current value is: " + ++progressBar1_1.CurrentValue;
            }
        }
        private void bar1Minus(object sender, global::System.EventArgs e)
        {
            if (progressBar1_1.CurrentValue == 0)
            {
                board.Text = "Current value is: 0";
            }
            else
            {
                board.Text = "Current value is: " + --progressBar1_1.CurrentValue;
            }
        }

        private void circleStatusChanged(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("----------------");

            status++;
            if (status > 2)
                status = 0;
            if (status == 0)
            {
                button5.ButtonText.Text = "Buffer";
            }
            if (status == 1)
            {
                button5.ButtonText.Text = "Deter";
            }
            if (status == 2)
            {
                button5.ButtonText.Text = "indeter";
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                propParent.Remove(board1);
                board1.Dispose();
                board1 = null;
                propParent.Remove(progressBar1_1);
                progressBar1_1.Dispose();
                progressBar1_1 = null;
                propParent.Remove(progressBar1_2);
                progressBar1_2.Dispose();
                progressBar1_2 = null;
                propParent.Remove(button1);
                button1.Dispose();
                button1 = null;
                propParent.Remove(button2);
                button2.Dispose();
                button2 = null;

                attrParent.Remove(board2);
                board2.Dispose();
                board2 = null;
                attrParent.Remove(progressBar2_1);
                progressBar2_1.Dispose();
                progressBar2_1 = null;

                progressParent.Remove(propParent);
                propParent.Dispose();
                propParent = null;
                progressParent.Remove(attrParent);
                attrParent.Dispose();
                attrParent = null;

                parent.Remove(progressParent);
                progressParent.Dispose();
                progressParent = null;
                parent.Remove(board);
                board.Dispose();
                board = null;

                root.Remove(parent);
                parent.Dispose();
                parent = null;

                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
