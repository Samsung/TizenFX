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

            kvmServiceWindow = new KVMServiceWindow(new Rectangle(2500, 0, 60, 1440));
            kvmServiceWindow.Show();
        }

        private void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "d" || e.Key.KeyPressedName == "D"))
            {
                Log.Debug("KVMSample", e.Key.KeyPressedName + " pressed!");
                dropTimer = new Timer(5000);
                dropTimer.Tick += (source, args) => {
                    Log.Debug("KVMSample", "Timer tick!");
                    kvmServiceWindow.PerformDrop();
                    dropTimer.Stop();
                    return false;
                };
                dropTimer.Start();
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
        private KVMServiceWindow kvmServiceWindow;
        private Timer dropTimer;
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

            // The First argument of listener should be window, not view.
            // The listener of view couldn't catch receive data from ReceiveDragData of KVMService
            dnd.AddListener(this, OnDnDEvent);

            tzShell = new Tizen.NUI.WindowSystem.Shell.TizenShell();
            kvmService = new Tizen.NUI.WindowSystem.Shell.KVMService(tzShell, this);
            kvmService.SetSecondarySelection();
            kvmService.DragStarted += OnDragStarted;
            kvmService.DragEnded += OnDragEnded;
        }

        public void PerformDrop()
        {
            kvmService.PerformDrop(Tizen.NUI.WindowSystem.Shell.KVMService.DropTarget.UnderPointer);
        }

        private void OnDnDEvent(object sender, DragEvent e)
        {
            if (e.DragType == DragType.Enter)
            {
                Log.Debug("KVMSample", "Target(KVM) App DRagEvnetType: Enter");
                // PerformDrop is drop into the KVM window and finish the current drag.
                // If you want to get the current drag data without end the drag,
                // use ReceiveDragData(mimetype) instead of PerformDrop().
                //kvmService.PerformDrop();

                // The drag data will be received by ReceiveDragData of OnDragStarted callback and DragEvent of the OnDnDEvent callback.
                // and the drag will be ended by enter the KVM window as UX of the app.
                // If you want to end the drag without receive drag data, use CancelDrag().
                kvmService.CancelDrag();
            }
            if (e.DragType == DragType.Drop)
            {
                Log.Debug("KVMSample", "Target(KVM) App DRagEvnetType: Drop, Data: " + e.Data);
            }
        }

        private void OnDragStarted(object sender, EventArgs e)
        {
            Log.Debug("KVMSample", "Tizen KVM: Drag started");

            List<string> mimeTypes;
            mimeTypes = kvmService.GetSourceMimetypes();
            if (mimeTypes == null)
                Log.Debug("KVMSample", "Tizen KVM: There're no Source mimetypes");
            else
                Log.Debug("KVMSample", "Tizen KVM: Source mimetypes: " + string.Join(", ", mimeTypes));
            string mimeType = mimeTypes[0];

            // Request the drag data to the Display server.
            // The drag data can get at DnD Listener (OnDnDEvent function)
            kvmService.ReceiveDragData(mimeType);
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
