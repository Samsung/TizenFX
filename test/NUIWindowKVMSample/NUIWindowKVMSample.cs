using System;
using Tizen;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.WindowSystem;
using System.Collections.Generic;

namespace NUIWindowKVMSample
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window win = Window.Instance;
            dnd = DragAndDrop.Instance;

            win.WindowSize = new Size2D(500, 500);
            win.KeyEvent += OnKeyEvent;
            win.BackgroundColor = Color.White;

            View windowView = new View();
            windowView.Size2D = new Size2D(500, 500);
            windowView.BackgroundColor = Color.White;
            windowView.TouchEvent += OnTouchEvent;
            win.Add(windowView);

            TextLabel text = new TextLabel("Start drag here");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Black;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            windowView.Add(text);

            KVMServiceWindow kvmServiceWindow = new KVMServiceWindow(new Rectangle(2500, 0, 60, 1440));
            kvmServiceWindow.Show();
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        private bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                View shadowView = new ImageView(Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "NUIWindowKVMSample.png");
                shadowView.Size = new Size(100, 100);

                DragData dragData;
                dragData.MimeType = "text/plain";
                dragData.Data = "Hello World";
                dnd.StartDragAndDrop((View)sender, shadowView, dragData, OnSourceEventHandler);

                return true;
            }

            return false;
        }

        private void OnSourceEventHandler(DragSourceEventType e)
        {
            if (e == DragSourceEventType.Start)
            {
                Log.Debug("KVMSample", "Source App SourceEvnetType: Start");
            }
            else if (e == DragSourceEventType.Cancel)
            {
                Log.Debug("KVMSample", "Source App SourceEvnetType: Cancel");
            }
            else if (e == DragSourceEventType.Accept)
            {
                Log.Debug("KVMSample", "Source App SourceEvnetType: Accept");
            }
            else if (e == DragSourceEventType.Finish)
            {
                Log.Debug("KVMSample", "Source App SourceEvnetType: Finish");
            }
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }

        private DragAndDrop dnd;
    }

    class KVMServiceWindow : Window
    {
        public KVMServiceWindow(Rectangle winGeometry) :
        base("KVM service Window", new Rectangle(winGeometry.X, winGeometry.Y, winGeometry.Width, winGeometry.Height))
        {
            dnd = DragAndDrop.Instance;
            this.WindowSize = new Size2D(winGeometry.Width, winGeometry.Height);
            this.BackgroundColor = Color.Yellow;

            View windowView = new View();
            windowView.Size2D = new Size2D(winGeometry.Width, winGeometry.Height);
            windowView.BackgroundColor = Color.Yellow;
            this.Add(windowView);

            dnd.AddListener(windowView, OnDnDEvent);

            tzShell = new Tizen.NUI.WindowSystem.Shell.TizenShell();
            kvmService = new Tizen.NUI.WindowSystem.Shell.KVMService(tzShell, this);
            kvmService.SetSecondarySelction();
            kvmService.DragStarted += OnDragStarted;
            kvmService.DragEnded += OnDragEnded;
        }

        private void OnDnDEvent(object sender, DragEvent e)
        {
            if (e.DragType == DragType.Enter)
            {
                Log.Debug("KVMSample", "Target(KVM) App DRagEvnetType: Enter");
                kvmService.PerformDrop();
            }
            if (e.DragType == DragType.Drop)
            {
                Log.Debug("KVMSample", "Target(KVM) App DRagEvnetType: Drop, Data: " + e.Data);
            }
        }

        private void OnDragStarted(object sender, EventArgs e)
        {
            Log.Debug("KVMSample", "Tizen KVM: Drag started");
        }

        private void OnDragEnded(object sender, EventArgs e)
        {
            Log.Debug("KVMSample", "Tizen KVM: Drag ended");
        }

        private DragAndDrop dnd;
        private Tizen.NUI.WindowSystem.Shell.TizenShell tzShell;
        private Tizen.NUI.WindowSystem.Shell.KVMService kvmService;
    }
}
