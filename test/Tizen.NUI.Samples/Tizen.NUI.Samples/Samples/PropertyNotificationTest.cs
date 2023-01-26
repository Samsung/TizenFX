
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PropertyNotificationTest : IExample
    {
        Window win;
        TextLabel statusText;
        global::System.Random rand = new global::System.Random();

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = Color.Green;

            statusText = new TextLabel()
            {
                Size = new Size(300, 300),
                Position = new Position(300, 10),
                Text = "Status Text",
                PointSize = 12,
                BackgroundColor = Color.Cyan,
                MultiLine = true,
                Opacity = 0.6f,
                Name = "test text",
            };

            View view = new View()
            {
                Size = new Size(100, 100),
                Position = new Position(10, 10),
                Color = Color.Yellow,
                BackgroundColor = Color.White,
                Name = "test view",
            };

            PropertyNotification propertyNotification = view.AddPropertyNotification("size", PropertyCondition.Step(1.0f));

            propertyNotification.Notified += (object source, PropertyNotification.NotifyEventArgs args) =>
            {
                View target = args.PropertyNotification.GetTarget() as View;
                if (target != null)
                {
                    Tizen.Log.Error("NUI", $"Size changed! ({target.SizeWidth},{target.SizeHeight})");
                    global::System.Console.WriteLine($"Size changed! ({target.SizeWidth},{target.SizeHeight})");
                    statusText.Text = $"size changed! \n CurrentSize:({target.CurrentSize.Width},{target.CurrentSize.Height}) \n" +
                        $" CurrentPosition:({target.CurrentPosition.X},{target.CurrentPosition.Y},{target.CurrentPosition.Z}) \n" +
                        $" CurrentColor:({target.CurrentColor.R},{target.CurrentColor.G},{target.CurrentColor.B}) \n" +
                        $" CurrentScale:({target.CurrentScale.X},{target.CurrentScale.Y},{target.CurrentScale.Z}) \n";
                }
                Tizen.Log.Error("NUI", "Size changed");
            };

            Button button = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 200),
                Text = "change size",
                Name = "test button",
            };
            button.Clicked += (object source, ClickedEventArgs args) =>
            {
                view.Size += new Size(2, 2);
                view.Position += new Position(30, 30);
                view.Color += new Color(0.03f, 0.06f, 0.03f, 1f);
                view.Scale += new Vector3(0.3f, 0.2f, 0);
            };

            Button resetBtn = new Button()
            {
                Size = new Size(200, 100),
                Position = new Position(200, 310),
                Text = "reset",
                Name = "reset button",
            };
            resetBtn.Clicked += (object source, ClickedEventArgs args) =>
            {
                view.Size = new Size(rand.Next(50, 100), rand.Next(50, 100));
                view.Position = new Position(rand.Next(5, 10), rand.Next(5, 10));
                view.Color = new Color(rand.Next(5, 10) / 255.0f, rand.Next(5, 10) / 255.0f, rand.Next(5, 10) / 255.0f, 1);
                view.Scale = new Vector3(1, 1, 0);
            };

            win.GetDefaultLayer().Add(view);
            win.GetDefaultLayer().Add(button);
            win.GetDefaultLayer().Add(statusText);
            win.GetDefaultLayer().Add(resetBtn);

            view.SetColorMode(ColorMode.UseOwnColor);
            view.LowerToBottom();
            button.RaiseAbove(statusText);
            resetBtn.RaiseAbove(statusText);
        }

        public void Deactivate()
        {
            win.GetDefaultLayer().FindChildByName("test view")?.Unparent();
            win.GetDefaultLayer().FindChildByName("test button")?.Unparent();
            win.GetDefaultLayer().FindChildByName("test text")?.Unparent();
            win.GetDefaultLayer().FindChildByName("reset button")?.Unparent();
        }
    }
}
