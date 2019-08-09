using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NuiCommonUiSamples
{
    using FH = Tizen.FH;
    public class Toast : IExample
    {
        private TextLabel board1, board2, board;
        private Tizen.NUI.CommonUI.Button button1, button2, button3, button4;
        private FH.NUI.Controls.Toast toast1_1, toast1_2, toast2_1, toast2_2,/*;private Tizen.NUI.CommonUI.Toast */toast2_3;  //1-no loading 2-have loading; X_1-long; X_2 short
        private SampleLayout root;

        public void Activate()
        {
            Window.Instance.BackgroundColor = Color.White;
            root = new SampleLayout(false);
            root.HeaderText = "Toast";

            CreateBoardAndButtons();

            toast1_1 = new FH.NUI.Controls.Toast("BasicShortToast");
            toast1_1.Position2D = new Position2D(30, 0);
            root.Add(toast1_1);
            toast1_1.TextArray = new string[1] { "Basic Short Toast" };


            toast2_1 = new FH.NUI.Controls.Toast("BasicLongToast");
            toast2_1.Position2D = new Position2D(30, 200);
            root.Add(toast2_1);
            toast2_1.TextArray = new string[1] { "Long Toast, I can have a loading, I have a very long long long text, I have a very long long" };
            toast2_1.LoadingEnable = true;
            //toast2_1.TextPaddingLeft = 204;

            toast2_3 = new Tizen.FH.NUI.Controls.Toast();
            toast2_3.PointSize = 14;
            toast2_3.BackgroundImageURL = CommonResource.GetResourcePath() + "12. Toast Popup/toast_background.png";
            toast2_3.BackgroundImageBorder = new Rectangle(64, 64, 4, 4);
            toast2_3.Position2D = new Position2D(30, 350);
            toast2_3.Size2D = new Size2D(1000, 272);
            toast2_3.TextPaddingLeft = 96;
            toast2_3.TextPaddingTop = 48;
            toast2_3.TextArray = new string[3] {
                "I have a very long long text, I have a very long long text, I have a very long long text",
                "This is my 2 line, I have a very long long text, I have a very long long text",
                "This is my 3 line, I have a very long long text, I have a very long long text" };
            root.Add(toast2_3);

            board.UpFocusableView = button1;

            FocusManager.Instance.SetCurrentFocusView(button1);
        }

        void CreateBoardAndButtons()
        {
            board = new TextLabel();
            board.Size2D = new Size2D(800, 100);
            board.Position2D = new Position2D(94, 650);
            board.PointSize = 14;
            board.HorizontalAlignment = HorizontalAlignment.Center;
            board.VerticalAlignment = VerticalAlignment.Center;
            board.BackgroundColor = Color.Magenta;
            board.Text = "log pad";
            root.Add(board);
            board.Focusable = true;
            board.FocusGained += Board_FocusGained;
            board.FocusLost += Board_FocusLost;

            button1 = new Tizen.NUI.CommonUI.Button();
            button1.PointSize = 14;
            button1.BackgroundColor = Color.Green;
            button1.Position2D = new Position2D(30, 125);
            button1.Size2D = new Size2D(220, 80);
            button1.Text = "toast1_1 Show";
            root.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += toast1_1Show;

            button2 = new Tizen.NUI.CommonUI.Button();
            button2.PointSize = 14;
            button2.BackgroundColor = Color.Green;
            button2.Position2D = new Position2D(270, 125);
            button2.Size2D = new Size2D(220, 80);
            button2.Text = "toast2_1 Show";
            root.Add(button2);
            button2.Focusable = true;
            button2.ClickEvent += toast2_1Show;

            button3 = new Tizen.NUI.CommonUI.Button();
            button3.PointSize = 14;
            button3.BackgroundColor = Color.Green;
            button3.Position2D = new Position2D(510, 125);
            button3.Size2D = new Size2D(270, 80);
            button3.Text = "changed Direction";
            root.Add(button3);
            button3.Focusable = true;
            button3.ClickEvent += toast2_1ChangeDirection;

            button4 = new Tizen.NUI.CommonUI.Button();
            button4.PointSize = 14;
            button4.BackgroundColor = Color.Green;
            button4.Position2D = new Position2D(800, 125);
            button4.Size2D = new Size2D(220, 80);
            button4.Text = "change loading";
            root.Add(button4);
            button4.Focusable = true;
            button4.ClickEvent += toast2_1ChangeLoading;
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

        private void toast2_1ChangeDirection(object sender, global::System.EventArgs e)
        {
            if (toast2_1.LayoutDirection == ViewLayoutDirectionType.LTR)
                toast2_1.LayoutDirection = ViewLayoutDirectionType.RTL;
            else
                toast2_1.LayoutDirection = ViewLayoutDirectionType.LTR;
            toast2_1.Show();
        }

        private void toast2_1ChangeLoading(object sender, global::System.EventArgs e)
        {
            board.Text = "toast2_1 remove loading ";
            if (toast2_1.LoadingEnable == true)
                toast2_1.LoadingEnable = false;
            else
                toast2_1.LoadingEnable = true;
            toast2_1.Show();
        }

        public void Deactivate()
        {
            if (root != null)
            {
                root.Dispose();
            }
        }
    }
}

