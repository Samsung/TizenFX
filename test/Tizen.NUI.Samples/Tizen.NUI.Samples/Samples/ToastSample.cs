using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class ToastSample : IExample
    {
        private TextLabel[] text = new TextLabel[3];
        private Button[] button = new Button[2];
        private Toast toast1_1, toast2_1;  //1-null para 2-attributes; X_1-color; X_2 image track
        private View root;
        private View[] parentView = new View[3];

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(1920, 1080),
                BackgroundColor = new Color(0.7f, 0.9f, 0.8f, 1.0f),
            };
            root.Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Vertical };
            window.Add(root);

            CreateTextView();
            CreateToastView();
            CreateLogPadView();
        }

        private void CreateTextView()
        {
            // Init parent of TextView
            parentView[0] = new View();
            parentView[0].Size = new Size(1920, 200);
            parentView[0].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(300, 0) };
            root.Add(parentView[0]);

            for (int i = 0; i < 2; i++)
            {
                text[i] = new TextLabel();
                text[i].Size = new Size(400, 70);
                text[i].PointSize = 20.0f;
                text[i].BackgroundColor = Color.Magenta;
                text[i].HorizontalAlignment = HorizontalAlignment.Center;
                text[i].VerticalAlignment = VerticalAlignment.Center;
                text[i].Focusable = true;
                text[i].FocusGained += Board_FocusGained;
                text[i].FocusLost += Board_FocusLost;
                parentView[0].Add(text[i]);
            }

            // Text of "Create Switch just by properties"
            text[0].Text = "Null Style construction";

            // Text of "Create Switch just by Style"
            text[1].Text = "Style construction";
        }

        private void CreateToastView()
        {
            // Init parent of ToastView
            parentView[1] = new View();
            parentView[1].Size = new Size(1920, 500);
            parentView[1].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center, CellPadding = new Size2D(300, 0) };
            root.Add(parentView[1]);

            // Create Toasts
            toast1_1 = Toast.FromText("Null parameter construction", 1000);
            toast1_1.Size = new Size(700, 132);
            toast1_1.Post(NUIApplication.GetDefaultWindow());

            ToastStyle attr = new ToastStyle
            {
                Size = new Size(712, 132),
                BackgroundImage = CommonResource.GetFHResourcePath() + "12. Toast Popup/toast_background.png",
                BackgroundImageBorder = new Rectangle(64, 64, 4, 4),
                Duration = 3000
            };

            toast2_1 = new Toast(attr);
            toast2_1.Message = "Style parameter construction";
            toast2_1.Post(NUIApplication.GetDefaultWindow());

            // Create Buttons
            CreateBoardAndButtons();
        }

        private void CreateLogPadView()
        {
            // Init parent of LogPadView
            parentView[2] = new View();
            parentView[2].Size = new Size(1920, 380);
            parentView[2].Layout = new LinearLayout() { LinearOrientation = LinearLayout.Orientation.Horizontal, LinearAlignment = LinearLayout.Alignment.Center};
            root.Add(parentView[2]);

            // Create log pad
            text[2] = new TextLabel();
            text[2].Size = new Size(1000, 100);
            text[2].PointSize = 30.0f;
            text[2].HorizontalAlignment = HorizontalAlignment.Center;
            text[2].VerticalAlignment = VerticalAlignment.Center;
            text[2].BackgroundColor = Color.Magenta;
            text[2].Text = "log pad";
            text[2].Focusable = true;
            text[2].FocusGained += Board_FocusGained;
            text[2].FocusLost += Board_FocusLost;
            text[2].UpFocusableView = button[0];
            parentView[2].Add(text[2]);
        }

        void CreateBoardAndButtons()
        {
            for (int i = 0; i < 2; i++)
            {
                button[i] = new Button();
                button[i].BackgroundColor = Color.Green;
                button[i].Size = new Size(200, 50);
                button[i].Focusable = true;
                parentView[1].Add(button[i]);
            }
            button[0].Text = "toast1_1 Show";
            button[0].Clicked += toast1_1Show;
            button[1].Text = "toast2_1 Show";
            button[1].Clicked += toast2_1Show;

            // Set init focus
            FocusManager.Instance.SetCurrentFocusView(button[0]);
        }

        private void Board_FocusLost(object sender, global::System.EventArgs e)
        {
            text[2].BackgroundColor = Color.Magenta;
        }

        private void Board_FocusGained(object sender, global::System.EventArgs e)
        {
            text[2].BackgroundColor = Color.Cyan;
        }

        private void toast1_1Show(object sender, global::System.EventArgs e)
        {
            text[2].Text = "toast1_1 show: ";
            toast1_1.Show();
        }

        private void toast2_1Show(object sender, global::System.EventArgs e)
        {
            text[2].Text = "toast2_1 show: ";
            toast2_1.Show();
        }

        public void Deactivate()
        {
            if (root != null)
            {
                NUIApplication.GetDefaultWindow().Remove(root);

                if (toast1_1 != null)
                {
                    NUIApplication.GetDefaultWindow().Remove(toast1_1);
                    toast1_1.Dispose();
                    toast1_1 = null;
                }

                if (toast2_1 != null)
                {
                    NUIApplication.GetDefaultWindow().Remove(toast2_1);
                    toast2_1.Dispose();
                    toast2_1 = null;
                }

                int i = 0;
                for (; i < 2; i++)
                {
                    button[i].Dispose();
                    button[i] = null;
                }

                for (i = 0; i < 3; i++)
                {
                    text[i].Dispose();
                    text[i] = null;
                    parentView[i].Dispose();
                    parentView[i] = null;
                }
                root.Dispose();
                root = null;
            }
        }
    }
}
