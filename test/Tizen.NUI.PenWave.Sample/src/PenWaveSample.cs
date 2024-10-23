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
            canvasView = new PWCanvasView();
            mWindow.Add(canvasView);

            PencilTool pencilTool = new PencilTool();
            ToolManager toolManager = canvasView.ToolManager;
            toolManager.RegisterTool(pencilTool);

            canvasView.ToolManager.SelectTool(pencilTool.Type);

            mToolPickerView = new ToolPickerView(toolManager);
            // mToolPickerView.HideTool(pencilTool.Type);
            mToolPickerView.Hide();
            mWindow.Add(mToolPickerView);


            longPressGestureDetector = new LongPressGestureDetector();
            longPressGestureDetector.Attach(canvasView);
            longPressGestureDetector.Detected += OnLongPressDetected;

            canvasView.TouchEvent += OnTouchEvent;
        }

        private void OnWindowResized(object sender, Window.ResizedEventArgs args)
        {
        }


        private bool OnTouchEvent(object sender, View.TouchEventArgs args)
        {
            if (args.Touch.GetState(0) == PointStateType.Down)
            {
                mToolPickerView.Hide();
            }
            canvasView.HandleInput(args.Touch);
            return false;
        }

        private void HandleErase(Vector2 touchPosition, bool partial)
        {
        }

        private void HandleNotes()
        {
        }

        private void OnLongPressDetected(object sender, LongPressGestureDetector.DetectedEventArgs args)
        {
            if (args.LongPressGesture.State == Gesture.StateType.Started)
            {
                mToolPickerView.Show();
            }
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
