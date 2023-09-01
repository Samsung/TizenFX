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
            // window that will act as KVM Service.
            kvmService = new Tizen.NUI.WindowSystem.Shell.KVMService(tzShell, Window.Instance); 
            kvmService.SetSecondarySelction();

            // Add a dummy view for easy debugging.
            View view = NewView();
            Window.Instance.GetDefaultLayer().Add(view);

            // Register event handler.
            Clipboard.Instance.DataSelected += OnClipboardDataSelected;
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
