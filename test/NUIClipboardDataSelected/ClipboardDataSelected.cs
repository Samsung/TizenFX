using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.WindowSystem;

/*
 * This app has no UI.
 * After the app is launched, it is hidden and the focus is skipped.
 * This is a sample app that becomes SecondarySelection and catches the Copy event of another process.
 * If there is another SecondarySelection already running on the device, this sample will not work properly.
 */

namespace NUIClipboardDataSelected
{
    class Program : NUIApplication
    {
        const string TAG = "clipboard";
        const string MIME_TYPE_PLAIN_TEXT = "text/plain;charset=utf-8";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.WindowSize = new Size(1, 1);
            Window.Instance.BackgroundColor = Color.White;

            Tizen.NUI.WindowSystem.Shell.TizenShell tzShell;
            tzShell = new Tizen.NUI.WindowSystem.Shell.TizenShell();
            Window.Instance.SetAcceptFocus(false);

            Tizen.NUI.WindowSystem.Shell.KVMService kvmService;
            // Window that will act as KVM Service.
            kvmService = new Tizen.NUI.WindowSystem.Shell.KVMService(tzShell, Window.Instance);
            kvmService.SetSecondarySelection();

            // This view has nothing to do with this test, just for easy debugging.
            // If there is a view, it is exposed to the process monitor.
            View view = NewView();
            Window.Instance.GetDefaultLayer().Add(view);

            // Register event handler.
            Clipboard.Instance.DataSelected += OnClipboardDataSelected;

            // Self copy test.
            CopyTest();
        }

        // When copy occurs somewhere, this callback is invoked.
        public void OnClipboardDataSelected(object sender, ClipboardDataSelectedEventArgs e)
        {
            // e.MimeType is the MIME type of the copy data that invoked this callback.
            string selectedType = e.MimeType;
            Tizen.Log.Info(TAG, $"OnClipboardDataSelected type:{selectedType}\n");

            // Do something here.
            // For example, MC app can call Clipboard's GetData() with the MIME type of the event argument.
            Clipboard.Instance.GetData(selectedType, OnClipboardDataReceived);
        }

        // When call Clipboard's GetData(), the user callback is called.
        public void OnClipboardDataReceived(bool success, ClipEvent clipEvent)
        {
            if (!success)
            {
                Tizen.Log.Error(TAG, $"Data receive fail");
                return;
            }

            Tizen.Log.Info(TAG, $"OnClipboardDataReceived type:{clipEvent.MimeType}, data:{clipEvent.Data}\n");
        }

        public void CopyTest()
        {
            // Self copy test.
            // * SetData() is called 5 seconds after app execution.
            // * Observe the Log of OnClipboardDataSelected.
            // * If the log is output, there is a problem somewhere.
            // * DataSelected event should not be invoked
            // * by the SetData() called within the SecondarySelection.
            Timer timer = new Timer(5000);
            timer.Tick += (s, e) =>
            {
                string data = "Lorem ipsum dolor sit amet consectetuer";
                Tizen.Log.Info(TAG, $"SetData type:{MIME_TYPE_PLAIN_TEXT}, data:{data}\n");
                Clipboard.Instance.SetData(MIME_TYPE_PLAIN_TEXT, data);
                return false;
            };
            timer.Start();
        }

        public View NewView()
        {
            var view = new View()
            {
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    LinearAlignment = LinearLayout.Alignment.Begin,
                },
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.WrapContent,
                BackgroundColor = Color.White,
            };
            return view;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
