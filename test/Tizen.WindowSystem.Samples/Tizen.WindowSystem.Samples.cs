using System;
using System.Threading.Tasks;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.WindowSystem.Shell;
using Tizen.Common;
using Color = Tizen.NUI.Color;

namespace Tizen.WindowSystem.Samples
{
    class Program : NUIApplication
    {
        TizenShell tzShell;
        QuickPanelClient qpClient;
        Button BtnClient;
        TextLabel textClientVisible;
        TextLabel textClientScrollable;
        TextLabel textClientOrientation;

        QuickPanelService qpService;
        Button BtnService;
        Timer _timer;

        SoftkeyClient softkeyClient;
        Button BtnSoftkeyClient;
        TextLabel textSoftkeyClientVisible;
        TextLabel textSoftkeyClientExpand;
        TextLabel textSoftkeyClientOpacity;

        SoftkeyService softkeyService;
        Button BtnSoftkeyService;
        TextLabel textSoftkeyServiceVisible;
        TextLabel textSoftkeyServiceExpand;
        TextLabel textSoftkeyServiceOpacity;

        ScreensaverService screensaverService;
        Button BtnScreensaverService;
        TextLabel textScreensaverServiceTitle;

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
                Position = new Position(100, 340),
                Margin = 10,
            };

            BtnSoftkeyClient = new Button()
            {
                Text = "SoftkeyClient",
                Size = new Size(400, 100),
                Position = new Position(100, 480),
                Margin = 10,
            };

            BtnSoftkeyService = new Button()
            {
                Text = "SoftkeyService",
                Size = new Size(400, 100),
                Position = new Position(100, 620),
                Margin = 10,
            };

            BtnScreensaverService = new Button()
            {
                Text = "ScreensaverService",
                Size = new Size(400, 100),
                Position = new Position(100, 760),
                Margin = 10,
            };

            window.Add(BtnClient);
            window.Add(BtnService);
            window.Add(BtnSoftkeyClient);
            window.Add(BtnSoftkeyService);
            window.Add(BtnScreensaverService);

            BtnClient.Clicked += BtnClient_ClickEvent;
            BtnService.Clicked += BtnService_ClickEvent;
            BtnSoftkeyClient.Clicked += BtnSoftkeyClient_ClickEvent;
            BtnSoftkeyService.Clicked += BtnSoftkeyService_ClickEvent;
            BtnScreensaverService.Clicked += BtnScreensaverService_ClickEvent;

            tzShell = new TizenShell();

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

        // =====================================================================
        // QuickPanelClient
        // =====================================================================

        public void OnVisibleEvent(object sender, QuickPanelVisibility state)
        {
            textClientVisible.Text = $"Visible: {qpClient.Visibility}";
        }

        public void OnOrientationEvent(object sender, WindowOrientation state)
        {
            textClientOrientation.Text = $"Orientation: {qpClient.Orientation}";
        }

        private void BtnClient_ClickEvent(object sender, ClickedEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();
            RemoveMenuButtons(window);

            qpClient = new QuickPanelClient(tzShell, (IWindowProvider)window, QuickPanelCategory.SystemDefault);

            qpClient.VisibleChanged += OnVisibleEvent;
            qpClient.OrientationChanged += OnOrientationEvent;

            textClientVisible = new TextLabel($"Visible: {qpClient.Visibility}");
            textClientVisible.Position = new Position(0, -100);
            textClientVisible.HorizontalAlignment = HorizontalAlignment.Center;
            textClientVisible.VerticalAlignment = VerticalAlignment.Center;
            textClientVisible.TextColor = Color.Blue;
            textClientVisible.PointSize = 12.0f;
            textClientVisible.HeightResizePolicy = ResizePolicyType.FillToParent;
            textClientVisible.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textClientVisible);

            textClientScrollable = new TextLabel($"Scrollable: {qpClient.ScrollMode}");
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

            BtnScrollableSet.Clicked += BtnScrollableSet_ClickEvent;
            BtnScrollableUnset.Clicked += BtnScrollableUnset_ClickEvent;
            BtnScrollableRetain.Clicked += BtnScrollableRetain_ClickEvent;
            BtnShow.Clicked += BtnClientShow_ClickEvent;
            BtnHide.Clicked += BtnClientHide_ClickEvent;

            window.Add(BtnScrollableSet);
            window.Add(BtnScrollableUnset);
            window.Add(BtnScrollableRetain);
            window.Add(BtnShow);
            window.Add(BtnHide);
        }

        private void BtnScrollableSet_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpClient.ScrollMode = QuickPanelScrollMode.Scrollable;
            textClientScrollable.Text = $"Scrollable: {qpClient.ScrollMode}";
        }
        private void BtnScrollableUnset_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpClient.ScrollMode = QuickPanelScrollMode.NotScrollable;
            textClientScrollable.Text = $"Scrollable: {qpClient.ScrollMode}";
        }
        private void BtnScrollableRetain_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpClient.ScrollMode = QuickPanelScrollMode.Retain;
            textClientScrollable.Text = $"Scrollable: {qpClient.ScrollMode}";
        }
        private void BtnClientShow_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpClient.Show();
        }
        private void BtnClientHide_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpClient.Hide();
        }

        // =====================================================================
        // QuickPanelService
        // =====================================================================

        private void BtnService_ClickEvent(object sender, ClickedEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();
            QuickPanelCategory type = QuickPanelCategory.AppsMenu;

            RemoveMenuButtons(window);

            qpService = new QuickPanelService(tzShell, (IWindowProvider)window, type);

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
            Button BtnTimerStop = new Button()
            {
                Text = "TimerStop",
                Size = new Size(300, 80),
                Position = new Position(50, 50),
                Margin = 10,
            };

            BtnShow.Clicked += BtnServiceShow_ClickEvent;
            BtnHide.Clicked += BtnServiceHide_ClickEvent;

            BtnEffectSwipe.Clicked += BtnEffectSwipe_ClickEvent;
            BtnEffectMove.Clicked += BtnEffectMove_ClickEvent;
            BtnEffectAppCustom.Clicked += BtnEffectAppCustom_ClickEvent;

            BtnLockTrue.Clicked += BtnLockTrue_ClickEvent;
            BtnLockFalse.Clicked += BtnLockFalse_ClickEvent;

            BtnTimerStop.Clicked += BtnTimerStop_ClickEvent;

            window.Add(BtnShow);
            window.Add(BtnHide);

            window.Add(BtnEffectSwipe);
            window.Add(BtnEffectMove);
            window.Add(BtnEffectAppCustom);

            window.Add(BtnLockTrue);
            window.Add(BtnLockFalse);

            window.Add(BtnTimerStop);

            // SetContentRegion / SetHandlerRegion now use params tuples instead of TizenRegion
            int winX = window.WindowPosition.X;
            int winY = window.WindowPosition.Y;
            int winW = window.WindowSize.Width;
            int winH = window.WindowSize.Height;

            qpService.SetContentRegion(0, (winX, winY, winW, winH - 50));
            qpService.SetHandlerRegion(0, (winX, winY + winH - 50, winW, 50));

            _timer = new Timer(2000);
            _timer.Tick += Timer_Tick;
            _timer.Start();
        }

        bool _cnt = true;

        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            if (_cnt)
            {
                qpService.Show();
            }
            else
            {
                qpService.Hide();
            }
            _cnt = !_cnt;
            return true;
        }

        private void BtnServiceShow_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.Show();
        }
        private void BtnServiceHide_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.Hide();
        }

        private void BtnEffectSwipe_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.Effect = QuickPanelEffect.Swipe;
        }
        private void BtnEffectMove_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.Effect = QuickPanelEffect.Move;
        }
        private void BtnEffectAppCustom_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.Effect = QuickPanelEffect.Custom;
        }
        private void BtnLockTrue_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.IsLocked = true;
        }
        private void BtnLockFalse_ClickEvent(object sender, ClickedEventArgs e)
        {
            qpService.IsLocked = false;
        }
        private void BtnTimerStop_ClickEvent(object sender, ClickedEventArgs e)
        {
            _timer.Stop();
        }

        // =====================================================================
        // SoftkeyClient
        // =====================================================================

        private void BtnSoftkeyClient_ClickEvent(object sender, ClickedEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();
            RemoveMenuButtons(window);

            softkeyClient = new SoftkeyClient(tzShell, (IWindowProvider)window);

            textSoftkeyClientVisible = new TextLabel($"Visible: {softkeyClient.IsVisible}");
            textSoftkeyClientVisible.Position = new Position(0, -100);
            textSoftkeyClientVisible.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyClientVisible.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyClientVisible.TextColor = Color.Blue;
            textSoftkeyClientVisible.PointSize = 12.0f;
            textSoftkeyClientVisible.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyClientVisible.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyClientVisible);

            textSoftkeyClientExpand = new TextLabel($"Expandable: {softkeyClient.IsExpandable}");
            textSoftkeyClientExpand.Position = new Position(0, 0);
            textSoftkeyClientExpand.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyClientExpand.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyClientExpand.TextColor = Color.Blue;
            textSoftkeyClientExpand.PointSize = 12.0f;
            textSoftkeyClientExpand.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyClientExpand.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyClientExpand);

            textSoftkeyClientOpacity = new TextLabel($"Opaque: {softkeyClient.IsOpaque}");
            textSoftkeyClientOpacity.Position = new Position(0, 100);
            textSoftkeyClientOpacity.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyClientOpacity.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyClientOpacity.TextColor = Color.Blue;
            textSoftkeyClientOpacity.PointSize = 12.0f;
            textSoftkeyClientOpacity.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyClientOpacity.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyClientOpacity);

            Button BtnExpandSetOn = new Button()
            {
                Text = "Expand On",
                Size = new Size(300, 100),
                Position = new Position(50, 800),
                Margin = 10,
            };
            Button BtnExpandSetOff = new Button()
            {
                Text = "Expand Off",
                Size = new Size(300, 100),
                Position = new Position(400, 800),
                Margin = 10,
            };
            Button BtnOpacitySetOpaque = new Button()
            {
                Text = "Opacity Opaque",
                Size = new Size(300, 100),
                Position = new Position(50, 1000),
                Margin = 10,
            };
            Button BtnOpacitySetTransparent = new Button()
            {
                Text = "Opacity Transparent",
                Size = new Size(300, 100),
                Position = new Position(400, 1000),
                Margin = 10,
            };
            Button BtnShow = new Button()
            {
                Text = "Show",
                Size = new Size(200, 100),
                Position = new Position(50, 1100),
                Margin = 10,
            };
            Button BtnHide = new Button()
            {
                Text = "Hide",
                Size = new Size(200, 100),
                Position = new Position(410, 1100),
                Margin = 10,
            };

            BtnExpandSetOn.Clicked += BtnExpandSetOn_ClickEvent;
            BtnExpandSetOff.Clicked += BtnExpandSetOff_ClickEvent;
            BtnOpacitySetOpaque.Clicked += BtnOpacitySetOpaque_ClickEvent;
            BtnOpacitySetTransparent.Clicked += BtnOpacitySetTransparent_ClickEvent;
            BtnShow.Clicked += BtnSoftkeyClientShow_ClickEvent;
            BtnHide.Clicked += BtnSoftkeyClientHide_ClickEvent;

            window.Add(BtnExpandSetOn);
            window.Add(BtnExpandSetOff);
            window.Add(BtnOpacitySetOpaque);
            window.Add(BtnOpacitySetTransparent);
            window.Add(BtnShow);
            window.Add(BtnHide);
        }

        private void BtnExpandSetOn_ClickEvent(object sender, ClickedEventArgs e)
        {
            softkeyClient.IsExpandable = true;
            textSoftkeyClientExpand.Text = $"Expandable: {softkeyClient.IsExpandable}";
        }

        private void BtnExpandSetOff_ClickEvent(object sender, ClickedEventArgs e)
        {
            softkeyClient.IsExpandable = false;
            textSoftkeyClientExpand.Text = $"Expandable: {softkeyClient.IsExpandable}";
        }

        private void BtnOpacitySetOpaque_ClickEvent(object sender, ClickedEventArgs e)
        {
            softkeyClient.IsOpaque = true;
            textSoftkeyClientOpacity.Text = $"Opaque: {softkeyClient.IsOpaque}";
        }

        private void BtnOpacitySetTransparent_ClickEvent(object sender, ClickedEventArgs e)
        {
            softkeyClient.IsOpaque = false;
            textSoftkeyClientOpacity.Text = $"Opaque: {softkeyClient.IsOpaque}";
        }

        private async Task ControlSoftKeyVisible(bool visible)
        {
            if (visible)
                softkeyClient.Show();
            else
                softkeyClient.Hide();
            await Task.Delay(50);
            textSoftkeyClientVisible.Text = $"Visible: {softkeyClient.IsVisible}";
        }

        private void BtnSoftkeyClientShow_ClickEvent(object sender, ClickedEventArgs e)
        {
            _ = ControlSoftKeyVisible(true);
        }

        private void BtnSoftkeyClientHide_ClickEvent(object sender, ClickedEventArgs e)
        {
            _ = ControlSoftKeyVisible(false);
        }

        // =====================================================================
        // SoftkeyService
        // =====================================================================

        private void BtnSoftkeyService_ClickEvent(object sender, ClickedEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.WindowSize = new Size(500, 500);
            window.WindowPosition = new Position(0, 700);

            RemoveMenuButtons(window);

            softkeyService = new SoftkeyService(tzShell, (IWindowProvider)window);

            textSoftkeyServiceVisible = new TextLabel($"Visible: None");
            textSoftkeyServiceVisible.Position = new Position(0, -100);
            textSoftkeyServiceVisible.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyServiceVisible.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyServiceVisible.TextColor = Color.Blue;
            textSoftkeyServiceVisible.PointSize = 12.0f;
            textSoftkeyServiceVisible.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyServiceVisible.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyServiceVisible);

            textSoftkeyServiceExpand = new TextLabel($"Expand: None");
            textSoftkeyServiceExpand.Position = new Position(0, 0);
            textSoftkeyServiceExpand.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyServiceExpand.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyServiceExpand.TextColor = Color.Blue;
            textSoftkeyServiceExpand.PointSize = 12.0f;
            textSoftkeyServiceExpand.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyServiceExpand.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyServiceExpand);

            textSoftkeyServiceOpacity = new TextLabel($"Opacity: None");
            textSoftkeyServiceOpacity.Position = new Position(0, 100);
            textSoftkeyServiceOpacity.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyServiceOpacity.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyServiceOpacity.TextColor = Color.Blue;
            textSoftkeyServiceOpacity.PointSize = 12.0f;
            textSoftkeyServiceOpacity.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyServiceOpacity.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyServiceOpacity);

            Button BtnShow = new Button()
            {
                Text = "Show",
                Size = new Size(200, 100),
                Position = new Position(50, 800),
                Margin = 10,
            };
            Button BtnHide = new Button()
            {
                Text = "Hide",
                Size = new Size(200, 100),
                Position = new Position(410, 800),
                Margin = 10,
            };

            window.Add(BtnShow);
            window.Add(BtnHide);

            BtnShow.Clicked += BtnSoftkeyServiceShow_ClickEvent;
            BtnHide.Clicked += BtnSoftkeyServiceHide_ClickEvent;

            softkeyService.VisibleChanged += OnSoftkeyServiceVisibleEvent;
            softkeyService.ExpandChanged += OnSoftkeyServiceExpandEvent;
            softkeyService.OpacityChanged += OnSoftkeyServiceOpacityEvent;
        }

        public void OnSoftkeyServiceVisibleEvent(object sender, SoftkeyVisibleChangedEventArgs e)
        {
            SoftkeyService obj = (SoftkeyService)sender;
            textSoftkeyServiceVisible.Text = $"Visible: {e.IsVisible}";
            if (e.IsVisible)
            {
                obj.Show();
            }
            else
            {
                obj.Hide();
            }
        }

        public void OnSoftkeyServiceExpandEvent(object sender, SoftkeyExpandChangedEventArgs e)
        {
            textSoftkeyServiceExpand.Text = $"Expand: {e.IsExpandable}";
        }

        public void OnSoftkeyServiceOpacityEvent(object sender, SoftkeyOpacityChangedEventArgs e)
        {
            textSoftkeyServiceOpacity.Text = $"Opacity: {e.IsOpaque}";
        }

        private void BtnSoftkeyServiceShow_ClickEvent(object sender, ClickedEventArgs e)
        {
            softkeyService.Show();
        }

        private void BtnSoftkeyServiceHide_ClickEvent(object sender, ClickedEventArgs e)
        {
            softkeyService.Hide();
        }

        // =====================================================================
        // ScreensaverService
        // =====================================================================

        private void BtnScreensaverService_ClickEvent(object sender, ClickedEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.WindowSize = new Size(1920, 1080);
            window.WindowPosition = new Position(0, 0);

            RemoveMenuButtons(window);

            screensaverService = new ScreensaverService(tzShell, (IWindowProvider)window);

            textScreensaverServiceTitle = new TextLabel($"Screen Saver");
            textScreensaverServiceTitle.Position = new Position(0, 0);
            textScreensaverServiceTitle.HorizontalAlignment = HorizontalAlignment.Center;
            textScreensaverServiceTitle.VerticalAlignment = VerticalAlignment.Center;
            textScreensaverServiceTitle.TextColor = Color.Blue;
            textScreensaverServiceTitle.PointSize = 12.0f;
            textScreensaverServiceTitle.HeightResizePolicy = ResizePolicyType.FillToParent;
            textScreensaverServiceTitle.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textScreensaverServiceTitle);
        }

        // =====================================================================
        // Helper
        // =====================================================================

        private void RemoveMenuButtons(Window window)
        {
            window.Remove(BtnService);
            window.Remove(BtnClient);
            window.Remove(BtnScreensaverService);
            window.Remove(BtnSoftkeyService);
            window.Remove(BtnSoftkeyClient);
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
