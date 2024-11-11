using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;

using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using Tizen.NUI.PenWave;

namespace PenWaveSample
{
    class Program : NUIApplication
    {
        public static Program app;
        private Window mWindow;
        // private ToolPickerView mToolPickerView;
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
            // canvasView = new PWCanvasView();
            // PencilTool pencilTool = new PencilTool();
            // canvasView.AddTool(pencilTool);

            var pencilTool = (PencilTool)canvasView.GetTool(PWToolType.Pencil);
            pencilTool.BrushColor = Color.Red;
            pencilTool.BrushType = PWBrushType.DashedLine;;

            // canvasView.SelectTool(pencilTool.Type);
            // var selectionTool = (SelectionTool)canvasView.GetTool(PWToolType.Selection);
            // selectionTool.SelectionType = PWSelectionType.Rotate;
            // canvasView.SelectTool(PWToolType.Selection);

            mWindow.Add(canvasView);

            // mToolPickerView = new ToolPickerView(canvasView);

            // canvasView.Add(mToolPickerView);

            canvasView.TouchEvent += OnTouchEvent;

            canvasView.AddPicture(Tizen.Applications.Application.Current.DirectoryInfo.Resource+"images/pictures/venus.png", new Size2D(100, 100), new Position2D(0, 0));


            // canvasView.SelectTool(PWToolType.Select);




            var button = new Button()
            {
                Text = "Eraser"
            };
            button.Clicked += (o, e) => {
                var eraserTool = (EraserTool)canvasView.GetTool(PWToolType.Eraser);
                eraserTool.EraserType = PWEraserType.Full;
                canvasView.SelectTool(PWToolType.Eraser);
            };
            canvasView.Add(button);

            canvasView.ToggleGrid(PWGridDensityType.Medium);
            canvasView.ToggleGrid(PWGridDensityType.Small);
            canvasView.SetCanvasColor(Color.AquaMarine);
        }


        private bool OnTouchEvent(object sender, View.TouchEventArgs args)
        {
            canvasView.HandleInput(args.Touch);
            return false;
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
