using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ToastSample : IExample
    {
        private TextLabel board1, board2, board;
        private Button button1, button2;
        private Toast toast1_1, toast2_1;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;
        private View parentView;
        private void InitParentView()
        {
            parentView = new View();
            parentView.Position = new Position(80, 650);
            parentView.Size = new Size(1800, 108);
            parentView.Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Horizontal,
                CellPadding = new Size2D(450, 50)
            };
            root.Add(parentView);
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            InitParentView();
            CreateBoardAndButtons();

            toast1_1 = Toast.FromText("null parameter construction", 1000);
            toast1_1.Size = new Size(700, 132);
            toast1_1.Post(window);

            ToastStyle attr = new ToastStyle
            {
                Size = new Size(712, 132),
                BackgroundImage = CommonResource.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                BackgroundImageBorder = new Rectangle(64, 64, 4, 4),
                Duration = 3000
            };
        
            toast2_1 = new Toast(attr);
            toast2_1.Message = "attibute parameter construction";
            toast2_1.Post(window);

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
            board1.Position = new Position(50, 200);
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
            board2.Position = new Position(650, 200);
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
            button1.Size = new Size(200, 50);
            button1.ButtonText.Text= "toast1_1 Show";
            parentView.Add(button1);
            button1.Focusable = true;
            button1.ClickEvent += toast1_1Show;

            button2 = new Button();
            button2.BackgroundColor = Color.Green;
            button2.Size = new Size(100, 50);
            button2.ButtonText.Text = "toast2_1 Show";
            parentView.Add(button2);
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
                NUIApplication.GetDefaultWindow().Remove(root);
                root.Dispose();
            }
        }
    }
}
