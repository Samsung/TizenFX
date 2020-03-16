using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class LoadingSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2, button3, button4;
        private Loading loading1_1, loading2_1;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            CreateBoardAndButtons();
            string[] imageArray = new string[36];
            for (int i=0; i<36; i++)
            {
                if (i < 10)
                {
                    imageArray[i] = CommonResource.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_0" + i + ".png";
                }
                else
                {
                    imageArray[i] = CommonResource.GetFHResourcePath() + "9. Controller/Loading Sequence_Native/loading_" + i + ".png";
                }
            }

            loading1_1 = new Loading();
            loading1_1.Position2D = new Position2D(100, 350);
            loading1_1.Size2D = new Size2D(100, 100);

            loading1_1.Images = imageArray;
            root.Add(loading1_1);

            LoadingStyle style = new LoadingStyle
            {
                Images = imageArray
            };

            loading2_1 = new Loading(style);
            loading2_1.Position2D = new Position2D(500, 350);
            loading2_1.Size2D = new Size2D(100, 100);
            root.Add(loading2_1);

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

            board1 = new TextLabel();
            board1.Size2D = new Size2D(300, 70);
            board1.Position2D = new Position2D(50, 200);
            board1.PointSize = 20;
            board1.HorizontalAlignment = HorizontalAlignment.Center;
            board1.VerticalAlignment = VerticalAlignment.Center;
            board1.BackgroundColor = Color.Magenta;
            board1.Text = "NULL parameter construction";
            root.Add(board1);

            board2 = new TextLabel();
            board2.Size2D = new Size2D(300, 70);
            board2.Position2D = new Position2D(400, 200);
            board2.PointSize = 20;
            board2.HorizontalAlignment = HorizontalAlignment.Center;
            board2.VerticalAlignment = VerticalAlignment.Center;
            board2.BackgroundColor = Color.Magenta;
            board2.Text = "Attribute parameter construction";
            root.Add(board2);

            button1 = new Button();
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(80, 600);
            button1.Size2D = new Size2D(100, 50);
            button1.Style.Text.Text = "FPS++";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += Loading1FPSAdd;
            button1.FocusGained += FocusGained;
            button1.FocusLost += FocusLost;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(200, 600);
            button2.Size2D = new Size2D(100, 50);
            button2.Style.Text.Text = "FPS--";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += Loading1FPSMinus;
            button2.FocusGained += FocusGained;
            button2.FocusLost += FocusLost;

            button1.RightFocusableView = button2;
            button2.LeftFocusableView = button1;

            button3 = new Button();
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(450, 600);
            button3.Size2D = new Size2D(180, 50);
            button3.Style.Text.Text = "Normal Loading";
            root.Add(button3);
        }

        private void Loading1FPSAdd(object sender, global::System.EventArgs e)
        {
            loading1_1.FrameRate += 1;
            board.Text = "loading1_1 FPS: "+loading1_1.FrameRate.ToString();
        }

        private void Loading1FPSMinus(object sender, global::System.EventArgs e)
        {
            loading1_1.FrameRate -= 1;
            board.Text = "loading1_1 FPS: " + loading1_1.FrameRate.ToString();
        }

        private void FocusLost(object sender, global::System.EventArgs e)
        {
            View view = sender as View;
            view.Scale = new Vector3(1.2f, 1.2f, 1.0f);
        }

        private void FocusGained(object sender, global::System.EventArgs e)
        {
            View view = sender as View;
            view.Scale = new Vector3(1.0f, 1.0f, 1.0f);
        }

        public void Deactivate()
        {
            if (board != null)
            {
                root.Remove(board);
                board.Dispose();
                board = null;
            }
            if (board1 != null)
            {
                root.Remove(board1);
                board1.Dispose();
                board1 = null;
            }
            if (board2 != null)
            {
                root.Remove(board2);
                board2.Dispose();
                board2 = null;
            }
            if (button1 != null)
            {
                button1.ClickEvent -= Loading1FPSAdd;
                button1.FocusGained -= FocusGained;
                button1.FocusLost -= FocusLost;
                root.Remove(button1);
                button1.Dispose();
                button1 = null;
            }
            if (button2 != null)
            {
                button2.ClickEvent -= Loading1FPSMinus;
                button2.FocusGained -= FocusGained;
                button2.FocusLost -= FocusLost;
                root.Remove(button2);
                button2.Dispose();
                button2 = null;
            }
            if (button3 != null)
            {
                root.Remove(button3);
                button3.Dispose();
                button3 = null;
            }
            if (loading1_1 != null)
            {
                root.Remove(loading1_1);
                loading1_1.Dispose();
                loading1_1 = null;
            }
            if (loading2_1 != null)
            {
                root.Remove(loading2_1);
                loading2_1.Dispose();
                loading2_1 = null;
            }
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
                root = null;
            }
        }
    }
}
