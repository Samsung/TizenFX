using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.CommonUI;

namespace Tizen.NUI.CommonUI.Samples
{
    public class ToastSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2;
        private Toast toast1_1, toast2_1;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;

        public void Activate()
        {
            Window window = Window.Instance;

            root = new View()
            {
                Size2D = new Size2D(1920, 1080),
            };

            CreateBoardAndButtons();

            toast1_1 = new Toast();
            toast1_1.Position2D = new Position2D(50, 350);
            toast1_1.Size2D = new Size2D(512, 132);
            toast1_1.BackgroundImageBorder = new Rectangle(64, 64, 4, 4);
            toast1_1.TextArray = new string[1] { "null parameter construction" };
            toast1_1.PointSize = 26;
            toast1_1.TextColor = Color.White;
            toast1_1.BackgroundImageURL = CommonResource.GetFHResourcePath() + "12. Toast Popup/toast_background.png";
            toast1_1.TextPaddingTop = 38;
            toast1_1.TextPaddingBottom = 38;
            toast1_1.TextPaddingLeft = 96;
            toast1_1.TextPaddingRight = 96;
            
            toast1_1.Duration = 1500;
            root.Add(toast1_1);

            ToastAttributes attr = new ToastAttributes
            {
                Size2D = new Size2D(512, 132),
                TextAttributes = new TextAttributes
                {
                    PaddingTop = 38,
                    PaddingBottom = 38,
                    PaddingLeft = 96,
                    PaddingRight = 96,
                    PointSize = new FloatSelector { All = 26 },
                    TextColor = new ColorSelector { All = Color.White },
                },
                BackgroundImageAttributes = new ImageAttributes
                {
                    ResourceUrl = new StringSelector
                    {
                        All = CommonResource.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                    },
                    Border = new RectangleSelector()
                    {
                        All = new Rectangle(64, 64, 4, 4),
                    }
                },
                TextLineHeight = 56,
                TextLineSpace = 4,
                Duration = 3000,
            };

            toast2_1 = new Toast(attr);
            toast2_1.TextArray = new string[1] {"attibute parameter construction" };
            toast2_1.Position2D = new Position2D(650, 350);
            //toast2_1.Size2D = new Size2D(512, 132);
            root.Add(toast2_1);

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
            board2.Position2D = new Position2D(650, 200);
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
            button1.Position2D = new Position2D(80, 600);
            button1.Size2D = new Size2D(200, 50);
            button1.Text = "toast1_1 Show";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += toast1_1Show;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(700, 600);
            button2.Size2D = new Size2D(100, 50);
            button2.Text = "toast2_1 Show";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += toast2_1Show;
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            board.BackgroundColor = Color.Cyan;
        }

        private void toast1_1Show(object sender, global::System.EventArgs e)
        {
            board.Text = "toast1_1 show: ";
            toast1_1.Show();
        }

        private void toast2_1Show(object sender, global::System.EventArgs e)
        {
            board.Text = "toast2_1 show: ";
            toast2_1.Show();
        }

        private void toast1FPSMinus(object sender, global::System.EventArgs e)
        {
            //board.Text = "toast1_1 FPS: " + toast1_1.FPS.ToString();
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
