using Tizen.NUI.BaseComponents;
using Tizen.NUI.Extension;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class RiveAnimationStateMachineTomatoes : IExample
    {
        private Window window;
        private Layer defaultLayer;

        private Tizen.NUI.Extension.RiveAnimationView rav;

        private TextLabel errorLabel;

        private Button addButton;
        private Button removeButton;

        private int numberOfTomatoes;

        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            defaultLayer = window.GetDefaultLayer();
            window.TouchEvent += OnRiveWindowTouchEvent;

            rav = new Tizen.NUI.Extension.RiveAnimationView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "rive/tomat-o-meter.riv")
            {
                Size = new Size(720.0f, 720.0f),
                ParentOrigin = ParentOrigin.Center,
                PivotPoint = PivotPoint.Center,
                PositionUsesPivotPoint = true
            };

            rav.EnableAnimation("idle", true);
            rav.Play();

            errorLabel = new TextLabel()
            {
                Size = new Size(300.0f, 100.0f),
                Position = new Position(415.0f, 5.0f),
                Text = ""
            };

            addButton = new Button()
            {
                Size = new Size(200.0f, 100.0f),
                Position = new Position(5.0f, 5.0f),
                Text = "+"
            };
            addButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                if (numberOfTomatoes == 5)
                    return;

                numberOfTomatoes++;
                if(!rav.SetNumberState("", "Rating", numberOfTomatoes))
                    errorLabel.Text = "addButton returned false";
            };

            removeButton = new Button()
            {
                Size = new Size(200.0f, 100.0f),
                Position = new Position(210.0f, 5.0f),
                Text = "-"
            };
            removeButton.Clicked += (object source, ClickedEventArgs args) =>
            {
                if (numberOfTomatoes == 0)
                    return;

                numberOfTomatoes--;
                if (!rav.SetNumberState("", "Rating", numberOfTomatoes))
                    errorLabel.Text = "removeButton returned false";
            };

            defaultLayer.Add(rav);
            defaultLayer.Add(addButton);
            defaultLayer.Add(removeButton);
            defaultLayer.Add(errorLabel);
        }

        public void Deactivate()
        {
            window.TouchEvent -= OnRiveWindowTouchEvent;

            if (rav)
                defaultLayer.Remove(rav);

            if (addButton)
                defaultLayer.Remove(addButton);

            if (removeButton)
                defaultLayer.Remove(removeButton);

            if (errorLabel)
                defaultLayer.Remove(errorLabel);
        }

        private void OnRiveWindowTouchEvent(object source, Window.TouchEventArgs args)
        {
            Vector2 position = args.Touch.GetScreenPosition(0);

            rav.PointerDown(position.X, position.Y - 275.0f);
        }
    }
}
