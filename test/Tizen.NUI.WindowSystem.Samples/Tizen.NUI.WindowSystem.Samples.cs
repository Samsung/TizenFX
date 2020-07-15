using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.WindowSystem;

namespace Tizen.NUI.WindowSystem.Samples
{
    class Program : NUIApplication
    {
        Shell.TizenShell tzShell;
        Shell.QuickPanelClient qpClient;
        Button BtnClient;
        TextLabel textClientVisible;
        TextLabel textClientScrollable;
        TextLabel textClientOrientation;

        Shell.QuickPanelService qpService;
        Shell.TizenRegion qpRegion;
        Button BtnService;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.KeyEvent += OnKeyEvent;
            window.BackgroundColor = Color.White;

            BtnClient = new Button()
            {
                Text = "QuickPanelClient",
                Size = new Size(400, 100),
                Position = new Position(100, 200),
                Margin = 10,
            };

            BtnService = new Button()
            {
                Text = "QuickPanelService",
                Size = new Size(400, 100),
                Position = new Position(100, 500),
                Margin = 10,
            };

            window.Add(BtnClient);
            window.Add(BtnService);

            BtnClient.ClickEvent += BtnClient_ClickEvent;
            BtnService.ClickEvent += BtnService_ClickEvent;

            tzShell = new Shell.TizenShell();

            window.AddAvailableOrientation(Window.WindowOrientation.Portrait);
            window.AddAvailableOrientation(Window.WindowOrientation.Landscape);
            window.AddAvailableOrientation(Window.WindowOrientation.PortraitInverse);
            window.AddAvailableOrientation(Window.WindowOrientation.LandscapeInverse);
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        public void OnVisibleEvent(object sender, Shell.QuickPanelClient.VisibleState state)
        {
            textClientVisible.Text = $"Visible: {qpClient.Visible}";
        }

        public void OnOrientationEvent(object sender, Window.WindowOrientation state)
        {
            textClientOrientation.Text = $"Orientation: {qpClient.Orientation}";
        }

        private void BtnClient_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();

            window.Remove(BtnService);
            window.Remove(BtnClient);
            qpClient = new Shell.QuickPanelClient(tzShell, window, Shell.QuickPanelClient.Types.SystemDefault);

            qpClient.VisibleChanged += OnVisibleEvent;
            qpClient.OrientationChanged += OnOrientationEvent;

            textClientVisible = new TextLabel($"Visible: {qpClient.Visible}");
            textClientVisible.Position = new Position(0, -100);
            textClientVisible.HorizontalAlignment = HorizontalAlignment.Center;
            textClientVisible.VerticalAlignment = VerticalAlignment.Center;
            textClientVisible.TextColor = Color.Blue;
            textClientVisible.PointSize = 12.0f;
            textClientVisible.HeightResizePolicy = ResizePolicyType.FillToParent;
            textClientVisible.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textClientVisible);

            textClientScrollable = new TextLabel($"Scrollable: {qpClient.Scrollable}");
            textClientScrollable.HorizontalAlignment = HorizontalAlignment.Center;
            textClientScrollable.VerticalAlignment = VerticalAlignment.Center;
            textClientScrollable.TextColor = Color.Blue;
            textClientScrollable.PointSize = 12.0f;
            textClientScrollable.HeightResizePolicy = ResizePolicyType.FillToParent;
            textClientScrollable.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textClientScrollable);

            textClientOrientation = new TextLabel($"Orientation: {qpClient.Orientation}");
            textClientOrientation.Position = new Position(0, 100);
            textClientOrientation.HorizontalAlignment = HorizontalAlignment.Center;
            textClientOrientation.VerticalAlignment = VerticalAlignment.Center;
            textClientOrientation.TextColor = Color.Blue;
            textClientOrientation.PointSize = 12.0f;
            textClientOrientation.HeightResizePolicy = ResizePolicyType.FillToParent;
            textClientOrientation.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textClientOrientation);

            Button BtnScrollableSet = new Button()
            {
                Text = "Scrollable Set",
                Size = new Size(400, 100),
                Position = new Position(50, 800),
                Margin = 10,
            };
            Button BtnScrollableUnset = new Button()
            {
                Text = "Scrollable Unset",
                Size = new Size(400, 100),
                Position = new Position(50, 920),
                Margin = 10,
            };
            Button BtnScrollableRetain = new Button()
            {
                Text = "Scrollable Retain",
                Size = new Size(400, 100),
                Position = new Position(50, 1040),
                Margin = 10,
            };
            Button BtnShow = new Button()
            {
                Text = "Show",
                Size = new Size(200, 100),
                Position = new Position(470, 850),
                Margin = 10,
            };
            Button BtnHide = new Button()
            {
                Text = "Hide",
                Size = new Size(200, 100),
                Position = new Position(470, 990),
                Margin = 10,
            };

            BtnScrollableSet.ClickEvent += BtnScrollableSet_ClickEvent;
            BtnScrollableUnset.ClickEvent += BtnScrollableUnset_ClickEvent;
            BtnScrollableRetain.ClickEvent += BtnScrollableRetain_ClickEvent;
            BtnShow.ClickEvent += BtnClientShow_ClickEvent;
            BtnHide.ClickEvent += BtnClientHide_ClickEvent;

            window.Add(BtnScrollableSet);
            window.Add(BtnScrollableUnset);
            window.Add(BtnScrollableRetain);
            window.Add(BtnShow);
            window.Add(BtnHide);
        }

        private void BtnScrollableSet_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpClient.Scrollable = Shell.QuickPanelClient.ScrollableState.Set;
            textClientScrollable.Text = $"Scrollable: {qpClient.Scrollable}";
        }
        private void BtnScrollableUnset_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpClient.Scrollable = Shell.QuickPanelClient.ScrollableState.Unset;
            textClientScrollable.Text = $"Scrollable: {qpClient.Scrollable}";
        }
        private void BtnScrollableRetain_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpClient.Scrollable = Shell.QuickPanelClient.ScrollableState.Retain;
            textClientScrollable.Text = $"Scrollable: {qpClient.Scrollable}";
        }
        private void BtnClientShow_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpClient.Show();
        }
        private void BtnClientHide_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpClient.Hide();
        }

        private void BtnService_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();

            window.Remove(BtnService);
            window.Remove(BtnClient);
            qpService = new Shell.QuickPanelService(tzShell, window, Shell.QuickPanelService.Types.SystemDefault);

            TextLabel textServiceType = new TextLabel($"Type: {qpService.ServiceType}");
            textServiceType.Position = new Position(0, -300);
            textServiceType.HorizontalAlignment = HorizontalAlignment.Center;
            textServiceType.VerticalAlignment = VerticalAlignment.Center;
            textServiceType.TextColor = Color.Blue;
            textServiceType.PointSize = 12.0f;
            textServiceType.HeightResizePolicy = ResizePolicyType.FillToParent;
            textServiceType.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textServiceType);

            Button BtnShow = new Button()
            {
                Text = "Show",
                Size = new Size(200, 100),
                Position = new Position(50, 500),
                Margin = 10,
            };
            Button BtnHide = new Button()
            {
                Text = "Hide",
                Size = new Size(200, 100),
                Position = new Position(410, 500),
                Margin = 10,
            };

            Button BtnEffectSwipe = new Button()
            {
                Text = "EffectSwipe",
                Size = new Size(400, 80),
                Position = new Position(50, 700),
                Margin = 10,
            };
            Button BtnEffectMove = new Button()
            {
                Text = "EffectMove",
                Size = new Size(400, 80),
                Position = new Position(50, 800),
                Margin = 10,
            };
            Button BtnEffectAppCustom = new Button()
            {
                Text = "EffectAppCustom",
                Size = new Size(400, 80),
                Position = new Position(50, 900),
                Margin = 10,
            };

            Button BtnLockTrue = new Button()
            {
                Text = "LockTrue",
                Size = new Size(300, 80),
                Position = new Position(50, 1000),
                Margin = 10,
            };
            Button BtnLockFalse = new Button()
            {
                Text = "LockFalse",
                Size = new Size(300, 80),
                Position = new Position(400, 1000),
                Margin = 10,
            };

            BtnShow.ClickEvent += BtnServiceShow_ClickEvent;
            BtnHide.ClickEvent += BtnServiceHide_ClickEvent;

            BtnEffectSwipe.ClickEvent += BtnEffectSwipe_ClickEvent;
            BtnEffectMove.ClickEvent += BtnEffectMove_ClickEvent;
            BtnEffectAppCustom.ClickEvent += BtnEffectAppCustom_ClickEvent;

            BtnLockTrue.ClickEvent += BtnLockTrue_ClickEvent;
            BtnLockFalse.ClickEvent += BtnLockFalse_ClickEvent;

            window.Add(BtnShow);
            window.Add(BtnHide);

            window.Add(BtnEffectSwipe);
            window.Add(BtnEffectMove);
            window.Add(BtnEffectAppCustom);

            window.Add(BtnLockTrue);
            window.Add(BtnLockFalse);

            qpRegion = new Shell.TizenRegion(tzShell);
            qpRegion.Add(window.WindowPosition.X, window.WindowPosition.Y, window.WindowSize.Width, window.WindowSize.Height - 50);
            qpService.SetContentRegion(0, qpRegion);
            qpRegion.Dispose();

            qpRegion = new Shell.TizenRegion(tzShell);
            qpRegion.Add(window.WindowPosition.X, window.WindowPosition.Y + window.WindowSize.Height - 50, window.WindowSize.Width, 50);
            qpService.SetHandlerRegion(0, qpRegion);
            qpRegion.Dispose();
        }

        private void BtnServiceShow_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.Show();
        }
        private void BtnServiceHide_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.Hide();
        }

        private void BtnEffectSwipe_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.SetEffectType(Shell.QuickPanelService.EffectType.Swipe);
        }
        private void BtnEffectMove_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.SetEffectType(Shell.QuickPanelService.EffectType.Move);
        }
        private void BtnEffectAppCustom_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.SetEffectType(Shell.QuickPanelService.EffectType.Custom);
        }
        private void BtnLockTrue_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.LockScroll(true);
        }
        private void BtnLockFalse_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            qpService.LockScroll(false);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
