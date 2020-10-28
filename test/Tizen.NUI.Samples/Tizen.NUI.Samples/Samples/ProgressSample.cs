using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI;

namespace Tizen.NUI.Samples
{
    public class ProgressSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button3, button4, button5;
        int status = 0;
        private Progress progressBar1_1, progressBar1_2, progressBar2_1, progressBar2_2; //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            CreateBoardAndButtons();

            //button1.ClickEvent += bar1Add;   
            //button2.ClickEvent += bar1Minus;         
            //button3.ClickEvent += circle1Add;    
            //button4.ClickEvent += circle1Minus;          
            //button5.ClickEvent += circleStatusChanged;

            progressBar1_1 = new Progress();
            progressBar1_1.Position2D = new Position2D(80, 350);
            progressBar1_1.Size2D = new Size2D(140, 4);
            progressBar1_1.MaxValue = 100;
            progressBar1_1.MinValue = 0;
            progressBar1_1.CurrentValue = 45;
            progressBar1_1.Style.Track.BackgroundColor = Color.Green;
            progressBar1_1.Style.Progress.BackgroundColor = Color.Black;
            root.Add(progressBar1_1);

            progressBar1_2 = new Progress();
            progressBar1_2.Position2D = new Position2D(80, 420);
            progressBar1_2.Size2D = new Size2D(140, 4);
            progressBar1_2.MaxValue = 100;
            progressBar1_2.MinValue = 0;
            progressBar1_2.CurrentValue = 15;
            progressBar1_2.Style.Track.BackgroundColor = Color.Green;
            progressBar1_2.Style.Progress.BackgroundColor = Color.Black;

            root.Add(progressBar1_2);

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
            progressBar2_1.Position2D = new Position2D(380, 350);
            progressBar2_1.Size2D = new Size2D(140, 4);
            progressBar2_1.MaxValue = 100;
            progressBar2_1.MinValue = 0;
            progressBar2_1.CurrentValue = 30;
            root.Add(progressBar2_1);

            //progressBar2_2 = new Progress(att);
            //progressBar2_2.Position2D = new Position2D(80, 560);
            //progressBar2_2.Size2D = new Size2D(140, 4);
            //progressBar2_2.MaxValue = 100;
            //progressBar2_2.MinValue = 0;
            //progressBar2_2.CurrentValue = 75;
            //progressBar2_2.UpdateValue();
            //progressBar2_2.Direction = Progress.DirectionType.Horizontal;
            //root.Add(progressBar2_2);

            board.UpFocusableView = button1;
            window.Add(root);
            FocusManager.Instance.SetCurrentFocusView(button1);

        }

        void CreateBoardAndButtons()
        {
            board = new TextLabel();
            board.Size2D = new Size2D(1000, 100);
            board.Position2D = new Position2D(430, 900);
            board.PointSize = 30;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            board.Text = "log pad";
            root.Add(board);
            board.Focusable = true;
            board.FocusGained += Board_FocusGained;
            board.FocusLost += Board_FocusLost;

            board1 = new TextLabel();
            board1.Size2D = new Size2D(300, 70);
            board1.Position2D = new Position2D(50, 200);
            board1.PointSize = 20;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "NULL parameter construction";
            root.Add(board1);
            board1.Focusable = true;
            board1.FocusGained += Board_FocusGained;
            board1.FocusLost += Board_FocusLost;

            board2 = new TextLabel();
            board2.Size2D = new Size2D(300, 70);
            board2.Position2D = new Position2D(400, 200);
            board2.PointSize = 20;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "Attribute construction";
            root.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            button1 = new Button();
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(100, 700);
            button1.Size2D = new Size2D(80, 50);
            button1.Style.Text.Text = "+";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += bar1Add;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 700);
            button2.Size2D = new Size2D(80, 50);
            button2.Style.Text.Text = "-";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += bar1Minus;

            //button3 = new Button();
            //button3.BackgroundColor = Color.Green;
            //button3.Position2D = new Position2D(450, 700);
            //button3.Size2D = new Size2D(80, 50);
            //button3.Text = "+";
            //root.Add(button3);
            //button3.Focusable = true;
            //button3.ClickEvent += Scroll2Add;

            //button4 = new Button();
            //button4.BackgroundColor = Color.Green;
            //button4.Position2D = new Position2D(550, 700);
            //button4.Size2D = new Size2D(80, 50);
            //button4.Text = "-";
            //root.Add(button4);
            //button4.Focusable = true;
            //button4.ClickEvent += Scroll2Minus;
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
            board.Text = "+";
            progressBar1_1.CurrentValue++;
        }
        private void bar1Minus(object sender, global::System.EventArgs e)
        {
            board.Text = "-";
            progressBar1_1.CurrentValue--;
        }

        private void circleStatusChanged(object sender, global::System.EventArgs e)
        {
            global::System.Console.WriteLine("----------------");

            status++;
            if (status > 2)
                status = 0;
            if (status == 0)
            {
                button5.Style.Text.Text = "Buffer";
                //progressCircle1.ProgressState = Progress.ProgressStatusType.Buffering;
            }
            if (status == 1)
            {
                button5.Style.Text.Text = "Deter";
                //progressCircle1.ProgressState = Progress.ProgressStatusType.Determinate;
            }
            if (status == 2)
            {
                button5.Style.Text.Text = "indeter";
                //progressCircle1.ProgressState = Progress.ProgressStatusType.Indeterminate;
            }
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
