using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class DefaultGrabTouchAfterLeaveSample : IExample
    {
        private View root;

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            // If this is set to true, all views are created with GrabTouchAfterLeave set to true.
            View.SetDefaultGrabTouchAfterLeave(true);

            root = new View
            {
                Layout = new AbsoluteLayout(),
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };

            var textLabel = new TextLabel
            {
                Size = new Size(300, 300),
                MultiLine = true,
                BackgroundColor = Color.Grey,
                WidthSpecification = LayoutParamPolicies.MatchParent,
            };

            // greenView is created with the size 250x250 and GrabTouchAfterLeave=true
            var greenView = new View()
            {
                Size = new Size(300, 300),
                Position = new Position(50, 320),
                BackgroundColor = Color.Green,
            };
            textLabel.Text ="greenView GrabTouchAfterLeave : "+greenView.GrabTouchAfterLeave;

            greenView.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"greenView {e.Touch.GetState(0)}\n");
                return true;
            };

            // If userTheme is applied,
            Theme userTheme = new Theme();
            userTheme.AddStyle("Tizen.NUI.BaseComponents.TextLabel",  new TextLabelStyle()
            {
                Size = new Size(500, 500),
            });
            ThemeManager.ApplyTheme(userTheme);

            // BlueView is created with size 500x500 defined in userTheme and GrabTouchAfterLeave=true
            var blueView = new TextLabel
            (new TextLabelStyle
            {
                Size = new Size(300, 300),
                Text = "BlueView",
            })
            {
                Position = new Position(10, 100),
                BackgroundColor = Color.Blue,
            };
            textLabel.Text +="\nblueView GrabTouchAfterLeave : "+blueView.GrabTouchAfterLeave;
            blueView.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"blueView {e.Touch.GetState(0)}\n");
                return true;
            };

            // BlueView is created with size 100x100 defined in userStyle and GrabTouchAfterLeave=true
            var redView = new TextLabel
            (new TextLabelStyle
            {
                PixelSize = 24,
                Size = new Size(100, 100),
            })
            {
                Text = "RedView",
                Position = new Position(50, 120),
                BackgroundColor = Color.Red,
            };
            textLabel.Text +="\redView GrabTouchAfterLeave : "+redView.GrabTouchAfterLeave;
            redView.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"redView {e.Touch.GetState(0)}\n");
                return true;
            };

            greenView.Add(blueView);
            blueView.Add(redView);
            root.Add(textLabel);
            root.Add(greenView);
            window.Add(root);
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
