using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.Events;


namespace Tizen.NUI.Samples
{
    public class DefaultViewStyleChangeSample : IExample
    {
        private View root;
        public class MyDefaultTheme : IThemeCreator
        {
            public Theme Create()
            {
                Theme theme = new Theme();
                theme.AddStyle("Tizen.NUI.BaseComponents.View",  new ViewStyle()
                {
                    Size = new Size(250, 250),
                    GrabTouchAfterLeave = true,
                });
                return theme;
            }
        }

        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            root = new View();

            // Add defaultTheme applied to application.
            ThemeManager.AddPackageTheme(new MyDefaultTheme());

            var textLabel = new TextLabel
            {
                Size = new Size(500, 200),
                MultiLine = true,
            };

            // greenView is created with the size 250x250 and GrabTouchAfterLeave=true defined in defaultTheme.
            var greenView = new View()
            {
                Position = new Position(50, 120),
                BackgroundColor = Color.Green,
            };
            textLabel.Text ="greenView GrabTouchAfterLeave : "+greenView.GrabTouchAfterLeave;

            greenView.TouchEvent += (s, e) =>
            {
                Tizen.Log.Error("NUI", $"greenView {e.Touch.GetState(0)}\n");
                return true;
            };

            // If userTheme is applied, it is merged with defaultTheme.
            Theme userTheme = new Theme();
            userTheme.AddStyle("Tizen.NUI.BaseComponents.View",  new ViewStyle()
            {
                Size = new Size(500, 500),
            });
            ThemeManager.ApplyTheme(userTheme);

            // BlueView is created with size 500x500 defined in userTheme and GrabTouchAfterLeave=true defined in defaultTheme.
            var blueView = new ImageView
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

            blueView.Add(greenView);
            root.Add(textLabel);
            root.Add(blueView);
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
