
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class PropertyNotificationTest : IExample
    {
        Window win;
        int cnt;
        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            win.BackgroundColor = Color.White;

            View view = new View()
            {
                Size = new Size(100, 100),
                BackgroundColor = Color.Red,
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
                }
                Tizen.Log.Error("NUI", "Size changed");
            };

            Button button = new Button()
            {
                Size = new Size(100, 100),
                Position = new Position(200, 200),
                Text = "Click me",
                Name = "test button",
            };

            button.Clicked += (object source, ClickedEventArgs args) =>
            {
                if (++cnt % 2 == 0)
                {
                    view.Size += new Size(5, 5);
                }
                else
                {
                    view.Position += new Position(10, 10);
                }
            };

            win.GetDefaultLayer().Add(view);
            win.GetDefaultLayer().Add(button);
        }

        public void Deactivate()
        {
            win.GetDefaultLayer().FindChildByName("test view")?.Unparent();
            win.GetDefaultLayer().FindChildByName("test button")?.Unparent();
        }
    }
}
