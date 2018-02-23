using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ColorTest
{
    internal class Example : NUIApplication
    {
        View mainView;
        TextLabel title;

        public Example() : base("", WindowMode.Transparent)
        {
        }

        Size2D screenSize;
        int pixelSize;

        protected override void OnCreate()
        {
            base.OnCreate();

            Window.Instance.BackgroundColor = Color.Transparent;
            Window.Instance.KeyEvent += Instance_KeyEvent;

            screenSize = Window.Instance.Size;
            pixelSize = screenSize.Width / 10;

            mainView = new View();
            mainView.Size2D = screenSize;
            mainView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
            mainView.PivotPoint = PivotPoint.TopLeft;
            mainView.Position = new Position(0, 0, 0);
            Window.Instance.GetDefaultLayer().Add(mainView);

            title = new TextLabel("Ambient is the new off");
            title.PivotPoint = PivotPoint.TopLeft;
            title.Size2D = new Size2D(screenSize.Width, screenSize.Height / 2);
            title.Position = new Position(0, 0, 0);
            //title.TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
            title.TextColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
            title.PixelSize = pixelSize;
            title.HorizontalAlignment = HorizontalAlignment.Center;
            title.VerticalAlignment = VerticalAlignment.Center;
            title.MultiLine = true;

            mainView.Add(title);
        }

        private void Instance_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            //////NUILog.Debug("State=" + e.Key.State.ToString() + " Pressed=" + e.Key.KeyPressedName + " Time=" + e.Key.Time);

            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "BackSpace" || e.Key.KeyPressedName == "XF86Back"))
            {
                Exit();
            }

            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Left")
                {
                    mainView.Remove(title);
                    title.Dispose();
                    title = null;

                    mainView = new View();
                    mainView.Size2D = screenSize;
                    mainView.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    mainView.PivotPoint = PivotPoint.TopLeft;
                    mainView.Position = new Position(0, 0, 0);
                    Window.Instance.GetDefaultLayer().Add(mainView);

                    title = new TextLabel("Ambient is the new off");
                    title.PivotPoint = PivotPoint.TopLeft;
                    title.Size2D = new Size2D(screenSize.Width, screenSize.Height / 2);
                    title.Position = new Position(0, 0, 0);
                    //title.TextColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    title.TextColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
                    title.PixelSize = pixelSize;
                    title.HorizontalAlignment = HorizontalAlignment.Center;
                    title.VerticalAlignment = VerticalAlignment.Center;
                    title.MultiLine = true;

                    mainView.Add(title);
                }
            }
        }
    }
}