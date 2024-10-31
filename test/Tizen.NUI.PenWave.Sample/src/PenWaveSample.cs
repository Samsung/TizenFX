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
        private ToolPickerView mToolPickerView;
        private PWCanvasView canvasView;

        public Program(ThemeOptions option, WindowData windowData) : base(option, windowData)
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            InitializeView();
        }

        private void InitializeView()
        {
            mWindow = GetDefaultWindow();
            mWindow.BackgroundColor = Color.White;
            canvasView = PWCanvasView.CreateDefaultCanvas();
            mWindow.Add(canvasView);

            mToolPickerView = new ToolPickerView(canvasView.ToolManager);
            canvasView.Layout = new LinearLayout()
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,
            };
            canvasView.Add(mToolPickerView);

            canvasView.TouchEvent += OnTouchEvent;
        }

        private void OnWindowResized(object sender, Window.ResizedEventArgs args)
        {
        }


        private bool OnTouchEvent(object sender, View.TouchEventArgs args)
        {
            canvasView.HandleInput(args.Touch);
            return false;
        }

        private void HandleErase(Vector2 touchPosition, bool partial)
        {
        }

        private void HandleNotes()
        {
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
