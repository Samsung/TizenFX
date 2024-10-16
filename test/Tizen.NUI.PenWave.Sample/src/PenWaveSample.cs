using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.PenWave;

namespace PenWaveSample
{
    class Program : NUIApplication
    {
        public static Program app;
        private Window mWindow;
        private LongPressGestureDetector longPressGestureDetector;

        public Program(ThemeOptions option, WindowData windowData) : base(option, windowData)
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            InitializeView();
        }

        protected override void OnTerminate()
        {
            // ExtRenderer.TerminateGL();
            base.OnTerminate();
        }

        private void InitializeView()
        {
            mWindow = GetDefaultWindow();
            mWindow.BackgroundColor = Color.White;
            PWCanvasView canvasView = new PWCanvasView();
            mWindow.Add(canvasView);

            PencilTool pencilTool = new PencilTool(Color.Black, 5.0f);
            ToolManager toolManager = canvasView.ToolManager;
            toolManager.RegisterTool(pencilTool);

            canvasView.ToolManager.SelectTool(pencilTool.Type);

            ToolPickerView toolPickerView = new ToolPickerView(toolManager);
            mWindow.Add(toolPickerView);


            longPressGestureDetector = new LongPressGestureDetector();
            longPressGestureDetector.Attach(canvasView);
            longPressGestureDetector.Detected += OnLongPressDetected;
        }

        private void OnWindowResized(object sender, Window.ResizedEventArgs args)
        {
        }


        private bool OnTouchMainView(object sender, View.TouchEventArgs args)
        {
            return false;
        }

        private void HandleErase(Vector2 touchPosition, bool partial)
        {
        }

// #if NOTES
        private void HandleNotes()
        {
        }
// #endif


        private void OnTouchEvent(object sender, Window.TouchEventArgs args)
        {
        }

        private void OnLongPressDetected(object sender, LongPressGestureDetector.DetectedEventArgs args)
        {
            Tizen.Log.Error("NUI", $"OnLongPressDetected\n");
        }

        private void OnMouseTouch(object sender, Window.TouchEventArgs args)
        {
        }

        private void OnWheelEvent(object sender, Window.WheelEventArgs args)
        {
        }

        static void Main(string[] args)
        {
            WindowData newWindowData = new WindowData();
            newWindowData.FrontBufferRendering = true;
            newWindowData.WindowMode = WindowMode.Opaque;
            app = new Program(ThemeOptions.None, newWindowData);
            app.Run(args);
            app.Dispose();
        }
    }
}
