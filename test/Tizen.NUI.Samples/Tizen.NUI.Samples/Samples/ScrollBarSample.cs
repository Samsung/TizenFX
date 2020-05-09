using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ScrollbarSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button5;
        private ScrollBar scrollBar1_1, scrollBar1_2, scrollBar2_1;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;
        private View btn_parent;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
            };

            CreateBoardAndButtons();

            scrollBar1_1 = new ScrollBar();
            scrollBar1_1.Position = new Position(50, 300);
            scrollBar1_1.Size = new Size(300, 4);
            scrollBar1_1.TrackImage.BackgroundColor = Color.Green;
            scrollBar1_1.MaxValue = (int)scrollBar1_1.SizeWidth / 10;
            scrollBar1_1.MinValue = 0;
            scrollBar1_1.ThumbImage.Size = new Size(30, 4);
            scrollBar1_1.CurrentValue = 0; //set after thumbsize
            scrollBar1_1.ThumbImage.BackgroundColor = Color.Black;
            root.Add(scrollBar1_1);

            scrollBar1_2 = new ScrollBar();
            scrollBar1_2.Position = new Position(50, 400);
            scrollBar1_2.Size = new Size(300, 4);
            scrollBar1_2.TrackImage.BackgroundColor = Color.Green;
            scrollBar1_2.MaxValue = (int)scrollBar1_2.SizeWidth / 10;
            scrollBar1_2.MinValue = 0;
            scrollBar1_2.ThumbImage.Size = new Size(30, 4);
            scrollBar1_2.CurrentValue = 0;//set after thumbsize
            scrollBar1_2.ThumbImage.BackgroundColor = Color.Yellow;
            scrollBar1_2.TrackImage.ResourceUrl = CommonResource.GetTVResourcePath() + "component/c_progressbar/c_progressbar_white_buffering.png";

            root.Add(scrollBar1_2);

            ScrollBarStyle attr = new ScrollBarStyle
            {
                Track = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = new Color(0.43f, 0.43f, 0.43f, 0.1f),
                    }
                },
                Thumb = new ImageViewStyle
                {
                    BackgroundColor = new Selector<Color>
                    {
                        All = new Color(1.0f, 0.0f, 0.0f, 0.2f),
                    }
                },
            };

            scrollBar2_1 = new ScrollBar(attr);
            scrollBar2_1.Position = new Position(500, 300);
            scrollBar2_1.Size = new Size(300, 4);
            scrollBar2_1.MaxValue = (int)scrollBar2_1.SizeWidth / 10;
            scrollBar2_1.MinValue = 0;
            scrollBar2_1.ThumbImage.Size = new Size(30, 4);
            scrollBar2_1.CurrentValue = 0; //set after thumbsize
            root.Add(scrollBar2_1);

            board.UpFocusableView = button1;

            window.Add(root);

            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        void CreateBoardAndButtons()
        {
            board = new TextLabel();
            board.Size = new Size(1000, 100);
            board.Position = new Position(430, 900);
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
            board1.Size = new Size(300, 70);
            board1.Position = new Position(50, 150);
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
            board2.Size = new Size(300, 70);
            board2.Position = new Position(500, 150);
            board2.PointSize = 20;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "Attribute construction";
            root.Add(board2);
            board2.Focusable = true;
            board2.FocusGained += Board_FocusGained;
            board2.FocusLost += Board_FocusLost;

            // Button
            btn_parent = new View();
            btn_parent.Position = new Position(100, 700);
            btn_parent.Size = new Size(600, 50);
            btn_parent.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                CellPadding = new Size2D(50, 50)
            };
            root.Add(btn_parent);

            button1 = new Button();
            button1.BackgroundColor = Color.Green;
            button1.Size = new Size(80, 50);
            button1.ButtonText.Text = "+";
            btn_parent.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += Scroll1Add;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Size = new Size(80, 50);
            button2.ButtonText.Text = "-";
            btn_parent.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += Scroll1Minus;

            button5 = new Button();
            button5.BackgroundColor = Color.Green;
            button5.Size = new Size(100, 50);
            button5.ButtonText.Text = "+ / - 4";
            btn_parent.Add(button5);
            button5.Focusable = true;
            button5.ClickEvent += Scroll1_2move;

            Button  button22 = new Button();
            button22.BackgroundColor = Color.Green;
            button22.Size = new Size(200, 50);
            button22.ButtonText.Text = "change direction";
            btn_parent.Add(button22);
            button22.Focusable = true;
            button22.ClickEvent += Scroll1_2Changed;
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
            scrollBar2_1.CurrentValue++;
        }
        private void Scroll1Minus(object sender, global::System.EventArgs e)
        {
            scrollBar1_1.CurrentValue--;
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
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
