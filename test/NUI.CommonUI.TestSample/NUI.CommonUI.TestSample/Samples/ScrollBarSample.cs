using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.NUI.CommonUI.Samples
{
    public class ScrollbarSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button3, button4, button5;
        private ScrollBar scrollBar1_1, scrollBar1_2, scrollBar2_1, scrollBar2_2;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            CreateBoardAndButtons();

            scrollBar1_1 = new ScrollBar();
            scrollBar1_1.Position2D = new Position2D(50, 300);
            scrollBar1_1.Size2D = new Size2D(300, 4);
            scrollBar1_1.TrackColor = Color.Green;           
            scrollBar1_1.MaxValue = (int)scrollBar1_1.SizeWidth / 10;
            scrollBar1_1.MinValue = 0;
            scrollBar1_1.ThumbSize = new Size2D(30, 4);
            scrollBar1_1.CurrentValue = 0; //set after thumbsize
            scrollBar1_1.ThumbColor = Color.Black;
            root.Add(scrollBar1_1);

            scrollBar1_2 = new ScrollBar();
            scrollBar1_2.Position2D = new Position2D(50, 400);
            scrollBar1_2.Size2D = new Size2D(300, 4);
            scrollBar1_2.TrackColor = Color.Green;
            scrollBar1_2.MaxValue = (int)scrollBar1_2.SizeWidth / 10;
            scrollBar1_2.MinValue = 0;
            scrollBar1_2.ThumbSize = new Size2D(30, 4);
            scrollBar1_2.CurrentValue = 0;//set after thumbsize
            scrollBar1_2.ThumbColor = Color.Yellow;
            scrollBar1_2.TrackImageURL = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";

            root.Add(scrollBar1_2);

            ScrollBarAttributes attr = new ScrollBarAttributes
            {
                TrackImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.43f, 0.43f, 0.43f, 0.1f),
                    }
                },
                ThumbImageAttributes = new ImageAttributes
                {
                    BackgroundColor = new ColorSelector
                    {
                        All = new Color(0.0f, 0.0f, 0.0f, 0.2f),
                    }
                },

            };

            scrollBar2_1 = new ScrollBar(attr);
            scrollBar2_1.Position2D = new Position2D(500, 300);
            scrollBar2_1.Size2D = new Size2D(300, 4);
            scrollBar2_1.MaxValue = (int)scrollBar2_1.SizeWidth / 10;
            scrollBar2_1.MinValue = 0;
            scrollBar2_1.ThumbSize = new Size2D(30, 4);
            scrollBar2_1.CurrentValue = 0; //set after thumbsize
            root.Add(scrollBar2_1);

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
            board1.Position2D = new Position2D(50, 150);
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
            board2.Position2D = new Position2D(500, 150);
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
            button1.Text = "+";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += Scroll1Add;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 700);
            button2.Size2D = new Size2D(80, 50);
            button2.Text = "-";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += Scroll1Minus;

            button5 = new Button();
            button5.BackgroundColor = Color.Green;
            button5.Position2D = new Position2D(400, 800);
            button5.Size2D = new Size2D(100, 50);
            button5.Text = "+ / - 4";
            root.Add(button5);
            button5.Focusable = true;
            button5.ClickEvent += Scroll1_2move;

            Button  button22 = new Button();
            button22.BackgroundColor = Color.Green;
            button22.Position2D = new Position2D(100, 800);
            button22.Size2D = new Size2D(200, 50);
            button22.Text = "change direction";
            root.Add(button22);
            button22.Focusable = true;
            button22.ClickEvent += Scroll1_2Changed;

            button3 = new Button();
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(450, 700);
            button3.Size2D = new Size2D(80, 50);
            button3.Text = "+";
            root.Add(button3);
            button3.Focusable = true;
            button3.ClickEvent += Scroll2Add;

            button4 = new Button();
            button4.BackgroundColor = Color.Green;
            button4.Position2D = new Position2D(550, 700);
            button4.Size2D = new Size2D(80, 50);
            button4.Text = "-";
            root.Add(button4);
            button4.Focusable = true;
            button4.ClickEvent += Scroll2Minus;
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Cyan;
        }

        private void Scroll1Add(object sender, global::System.EventArgs e)
        {
            scrollBar1_1.CurrentValue++;
        }
        private void Scroll1Minus(object sender, global::System.EventArgs e)
        {
            scrollBar1_1.CurrentValue--;
        }
        private void Scroll2Add(object sender, global::System.EventArgs e)
        {
            scrollBar2_1.CurrentValue++;
        }
        private void Scroll2Minus(object sender, global::System.EventArgs e)
        {
            scrollBar2_1.CurrentValue--;
        }

        private void Scroll1_2Changed(object sender, global::System.EventArgs e)
        {
            if(scrollBar1_2.LayoutDirection == ViewLayoutDirectionType.LTR)
                scrollBar1_2.LayoutDirection= ViewLayoutDirectionType.RTL;
            else
                scrollBar1_2.LayoutDirection = ViewLayoutDirectionType.LTR;
        }

        private void Scroll1_2move(object sender, global::System.EventArgs e)
        {
            if (scrollBar1_2.CurrentValue < scrollBar1_2.MaxValue / 2)
            {
                scrollBar1_2.SetCurrentValue(scrollBar1_2.MaxValue - 2);
            }
            else
            {
                scrollBar1_2.SetCurrentValue(2);
            }
        }

        private void ScrollPan(object sender, global::System.EventArgs e)
        {
            board.Text = board.Text + " 1";
            if (board.Text.Length > 20)
                board.Text = "";
        }

        public void Deactivate()
        {
            if (root != null)
            {
                Window.Instance.Remove(root);
                root.Dispose();
            }
        }
    }
}
