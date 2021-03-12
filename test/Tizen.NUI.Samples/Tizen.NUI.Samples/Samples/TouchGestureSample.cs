using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class TouchGestureSample : IExample
    {
        private View root;
        private TextLabel frontView;
        private TextLabel backView;

        public void ChangeText()
        {
            backView.Text = "From OnTap BackView";
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View();


           frontView = new TextLabel
            {
                Size = new Size(300, 300),
                Text = "Front View",
                Position = new Position(150, 170),
                PointSize = 11,
                BackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f),
            };
            frontView.TouchEvent += OnFrontTouchEvent;
            frontView.TouchAreaOffset = new Offset(-10, 20, 30, -40); // left, right, bottom, top


            backView = new TextLabel
            {
                Size = new Size(300, 300),
                Text = "Back View",
                Position = new Position(50, 70),
                PointSize = 11,
                BackgroundColor = new Color(1.0f, 1.0f, 0.0f, 1.0f),
            };

            backView.TouchEvent += OnBackTouchEvent;

            backView.Add(frontView);

            root.Add(backView);
            window.Add(root);
        }

        private bool OnFrontTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnFrontTouchEvent {e.Touch.GetState(0)}\n");
            return true;
        }


        private bool OnBackTouchEvent(object source, View.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnBackTouchEvent {e.Touch.GetState(0)}\n");
            return false;
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
