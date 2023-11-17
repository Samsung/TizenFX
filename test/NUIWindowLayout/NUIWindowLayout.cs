using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.Collections.Generic;

namespace NUIWindowLayout
{
    class Program : NUIApplication
    {
        private uint numOfWindows;
        private List<Window> windows = new List<Window>();
        private Color[] colors = { Color.DarkGreen, Color.Aqua, Color.Coral, Color.DimGrey };

        public Program(uint numOfWindows) : base(ThemeOptions.None, new DefaultBorder())
        {
            if (numOfWindows > 0 && numOfWindows <= 4)
            {
                this.numOfWindows = numOfWindows;
            }
            else
            {
                Tizen.Log.Error("WindowLayout", "numOfWindows is not valid. Put 0 < numOfWindows <= 4");
            }
        }
        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = NUIApplication.GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;
            Initialize();
        }

        void Initialize()
        {
            windows.Add(NUIApplication.GetDefaultWindow());

            for (int i = 1; i < numOfWindows; i++)
            {
                windows.Add(new Window((i + 1).ToString() + "window", new DefaultBorder()));
            }

            for (int i = 0; i < numOfWindows; i++)
            {
                Window window = windows[i];
                window.BackgroundColor = colors[i];

                ScrollableBase scrollableBase = new ScrollableBase();
                scrollableBase.WidthSpecification = LayoutParamPolicies.MatchParent;
                scrollableBase.HeightSpecification = LayoutParamPolicies.MatchParent;
                scrollableBase.ScrollingDirection = ScrollableBase.Direction.Vertical;

                scrollableBase.Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                };

                for (int idxType = 0; idxType < System.Enum.GetValues(typeof(WindowLayoutType)).Length; idxType++)
                {
                    Button button = new Button();
                    button.TextLabel.Text = idxType.ToString() + "." + (WindowLayoutType)idxType; // Set text to the enum value
                    button.Size = new Size(200, 50);

                    button.Clicked += (object sender, ClickedEventArgs e) =>
                    {
                        int number;
                        number = int.Parse(((Button)sender).TextLabel.Text.Split('.')[0]);
                        WindowLayoutType type = (WindowLayoutType)number;
                        Tizen.Log.Info("WindowLayout", type.ToString());
                        window.SetLayout((WindowLayoutType)number);
                    };
                    scrollableBase.Add(button);
                }

                window.Add(scrollableBase);
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {
            var app = new Program(4);
            app.Run(args);
        }
    }
}
