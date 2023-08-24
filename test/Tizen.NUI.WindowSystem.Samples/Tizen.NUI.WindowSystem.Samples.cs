using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Tizen.Applications.ComponentBased.Common;
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
        Timer _timer;

        Shell.SoftkeyClient softkeyClient;
        Button BtnSoftkeyClient;
        TextLabel textSoftkeyClientVisible;
        TextLabel textSoftkeyClientExpand;
        TextLabel textSoftkeyClientOpacity;

        Shell.SoftkeyService softkeyService;
        Button BtnSoftkeyService;
        TextLabel textSoftkeyServiceVisible;
        TextLabel textSoftkeyServiceExpand;
        TextLabel textSoftkeyServiceOpacity;

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
                Position = new Position(100, 400),
                Margin = 10,
            };

            BtnSoftkeyClient = new Button()
            {
                Text = "SoftkeyClient",
                Size = new Size(400, 100),
                Position = new Position(100, 600),
                Margin = 10,
            };

            BtnSoftkeyService = new Button()
            {
                Text = "SoftkeyService",
                Size = new Size(400, 100),
                Position = new Position(100, 800),
                Margin = 10,
            };

            window.Add(BtnClient);
            window.Add(BtnService);
            window.Add(BtnSoftkeyClient);
            window.Add(BtnSoftkeyService);

            BtnClient.ClickEvent += BtnClient_ClickEvent;
            BtnService.ClickEvent += BtnService_ClickEvent;
            BtnSoftkeyClient.ClickEvent += BtnSoftkeyClient_ClickEvent;
            BtnSoftkeyService.ClickEvent += BtnSoftkeyService_ClickEvent;

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
            window.Remove(BtnSoftkeyService);
            window.Remove(BtnSoftkeyClient);
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
            Shell.QuickPanelService.Types type = Shell.QuickPanelService.Types.AppsMenu;

            window.Remove(BtnService);
            window.Remove(BtnClient);
            window.Remove(BtnSoftkeyService);
            window.Remove(BtnSoftkeyClient);
            qpService = new Shell.QuickPanelService(tzShell, window, type);
            //if ((type == Shell.QuickPanelService.Types.ContextMenu) || (type == Shell.QuickPanelService.Types.AppsMenu))
                //window.AddAuxiliaryHint("wm.policy.win.user.geometry", "1");

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

            BtnShow.ClickEvent += BtnServiceShow_ClickEvent;
            BtnHide.ClickEvent += BtnServiceHide_ClickEvent;

            BtnEffectSwipe.ClickEvent += BtnEffectSwipe_ClickEvent;
            BtnEffectMove.ClickEvent += BtnEffectMove_ClickEvent;
            BtnEffectAppCustom.ClickEvent += BtnEffectAppCustom_ClickEvent;

            BtnLockTrue.ClickEvent += BtnLockTrue_ClickEvent;
            BtnLockFalse.ClickEvent += BtnLockFalse_ClickEvent;

            BtnTimerStop.ClickEvent += BtnTimerStop_ClickEvent;

            window.Add(BtnShow);
            window.Add(BtnHide);

            window.Add(BtnEffectSwipe);
            window.Add(BtnEffectMove);
            window.Add(BtnEffectAppCustom);

            window.Add(BtnLockTrue);
            window.Add(BtnLockFalse);

            window.Add(BtnTimerStop);

            qpRegion = new Shell.TizenRegion(tzShell);
            qpRegion.Add(window.WindowPosition.X, window.WindowPosition.Y, window.WindowSize.Width, window.WindowSize.Height - 50);
            qpService.SetContentRegion(0, qpRegion);
            qpRegion.Dispose();

            qpRegion = new Shell.TizenRegion(tzShell);
            qpRegion.Add(window.WindowPosition.X, window.WindowPosition.Y + window.WindowSize.Height - 50, window.WindowSize.Width, 50);
            qpService.SetHandlerRegion(0, qpRegion);
            qpRegion.Dispose();

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
        private void BtnTimerStop_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            _timer.Stop();
        }

        private void BtnSoftkeyClient_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();

            window.Remove(BtnService);
            window.Remove(BtnClient);
            window.Remove(BtnSoftkeyService);
            window.Remove(BtnSoftkeyClient);
            softkeyClient = new Shell.SoftkeyClient(tzShell, window);

            textSoftkeyClientVisible = new TextLabel($"Visible: {softkeyClient.Visible}");
            textSoftkeyClientVisible.Position = new Position(0, -100);
            textSoftkeyClientVisible.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyClientVisible.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyClientVisible.TextColor = Color.Blue;
            textSoftkeyClientVisible.PointSize = 12.0f;
            textSoftkeyClientVisible.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyClientVisible.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyClientVisible);

            textSoftkeyClientExpand = new TextLabel($"Expand: {softkeyClient.Expand}");
            textSoftkeyClientExpand.Position = new Position(0, 0);
            textSoftkeyClientExpand.HorizontalAlignment = HorizontalAlignment.Center;
            textSoftkeyClientExpand.VerticalAlignment = VerticalAlignment.Center;
            textSoftkeyClientExpand.TextColor = Color.Blue;
            textSoftkeyClientExpand.PointSize = 12.0f;
            textSoftkeyClientExpand.HeightResizePolicy = ResizePolicyType.FillToParent;
            textSoftkeyClientExpand.WidthResizePolicy = ResizePolicyType.FillToParent;
            window.Add(textSoftkeyClientExpand);

            textSoftkeyClientOpacity = new TextLabel($"Opacity: {softkeyClient.Opacity}");
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

            BtnExpandSetOn.ClickEvent += BtnExpandSetOn_ClickEvent;
            BtnExpandSetOff.ClickEvent += BtnExpandSetOff_ClickEvent;
            BtnOpacitySetOpaque.ClickEvent += BtnOpacitySetOpaque_ClickEvent;
            BtnOpacitySetTransparent.ClickEvent += BtnOpacitySetTransparent_ClickEvent;
            BtnShow.ClickEvent += BtnSoftkeyClientShow_ClickEvent;
            BtnHide.ClickEvent += BtnSoftkeyClientHide_ClickEvent;

            window.Add(BtnExpandSetOn);
            window.Add(BtnExpandSetOff);
            window.Add(BtnOpacitySetOpaque);
            window.Add(BtnOpacitySetTransparent);
            window.Add(BtnShow);
            window.Add(BtnHide);
        }

        private void BtnExpandSetOn_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            softkeyClient.Expand = Shell.SoftkeyExpandState.On;
            textSoftkeyClientExpand.Text = $"Expand: {softkeyClient.Expand}";
        }

        private void BtnExpandSetOff_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            softkeyClient.Expand = Shell.SoftkeyExpandState.Off;
            textSoftkeyClientExpand.Text = $"Expand: {softkeyClient.Expand}";
        }

        private void BtnOpacitySetOpaque_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            softkeyClient.Opacity = Shell.SoftkeyOpacityState.Opaque;
            textSoftkeyClientOpacity.Text = $"Opacity: {softkeyClient.Opacity}";
        }

        private void BtnOpacitySetTransparent_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            softkeyClient.Opacity = Shell.SoftkeyOpacityState.Transparent;
            textSoftkeyClientOpacity.Text = $"Opacity: {softkeyClient.Opacity}";
        }

        private async Task ControlSoftKeyVisible(bool visible)
        {
            if (visible)
                softkeyClient.Show();
            else
                softkeyClient.Hide();
            await Task.Delay(50);
            textSoftkeyClientVisible.Text = $"Visible: {softkeyClient.Visible}";
        }

        private void BtnSoftkeyClientShow_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            _ = ControlSoftKeyVisible(true);
        }

        private void BtnSoftkeyClientHide_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            _ = ControlSoftKeyVisible(false);
        }

        private void BtnSoftkeyService_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.WindowSize = new Size(500, 500);
            window.WindowPosition = new Position(0, 700);

            window.Remove(BtnService);
            window.Remove(BtnClient);
            window.Remove(BtnSoftkeyService);
            window.Remove(BtnSoftkeyClient);
            softkeyService = new Shell.SoftkeyService(tzShell, window);

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

            BtnShow.ClickEvent += BtnSoftkeyServiceShow_ClickEvent;
            BtnHide.ClickEvent += BtnSoftkeyServiceHide_ClickEvent;

            softkeyService.VisibleChanged += OnSoftkeyServiceVisibleEvent;
            softkeyService.ExpandChanged += OnSoftkeyServiceExpandEvent;
            softkeyService.OpacityChanged += OnSoftkeyServiceOpacityEvent;
        }

        public void OnSoftkeyServiceVisibleEvent(object sender, Shell.SoftkeyVisibleState state)
        {
            Shell.SoftkeyService obj = (Shell.SoftkeyService)sender;
            textSoftkeyServiceVisible.Text = $"Visible: {state}";
            if (state == Shell.SoftkeyVisibleState.Shown)
            {
                obj.Show();
            }
            else
            {
                obj.Hide();
            }
        }

        public void OnSoftkeyServiceExpandEvent(object sender, Shell.SoftkeyExpandState state)
        {
            textSoftkeyServiceExpand.Text = $"Expand: {state}";
        }

        public void OnSoftkeyServiceOpacityEvent(object sender, Shell.SoftkeyOpacityState state)
        {
            textSoftkeyServiceOpacity.Text = $"Opacity: {state}";
        }

        private void BtnSoftkeyServiceShow_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            softkeyService.Show();
        }

        private void BtnSoftkeyServiceHide_ClickEvent(object sender, Button.ClickEventArgs e)
        {
            softkeyService.Hide();
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
