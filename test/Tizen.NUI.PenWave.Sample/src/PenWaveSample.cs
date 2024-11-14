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
        private PWToolPicker mToolPickerView;
        private PWCanvasView canvasView;

        public Program(ThemeOptions option, WindowData windowData) : base(option, windowData)
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            InitializeView();
        }

        private void ToolPicker()
        {
            mToolPickerView = new PWToolPicker(canvasView);
            mToolPickerView.InitializeToolPicker();

            //custom button
            var customButton = new Button()
            {
                Text = "Custom"
            };
            customButton.Clicked += (o, e) => {
                mToolPickerView.ClearPopupView();
                mToolPickerView.PopupView.Show();
                mToolPickerView.PopupView.Add(new Button() { Text = "PopupBustom" });
            };
            mToolPickerView.PickerView.Add(customButton);
        }

        private void Buttons()
        {

            canvasView.AddPicture(Tizen.Applications.Application.Current.DirectoryInfo.Resource+"images/pictures/venus.png", new Size2D(100, 100), new Position2D(0, 0));
            canvasView.Tool = new PencilTool(PencilTool.BrushType.DashedLine, Color.Blue, 10);
            var view = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
            };
            canvasView.Add(view);
            var button = new Button()
            {
                Text = "Eraser"
            };
            button.Clicked += (o, e) => {
                canvasView.Tool = new EraserTool(EraserTool.EraserType.Partial, 20);
            };
            view.Add(button);

            var button2 = new Button()
            {
                Text = "Move"
            };
            button2.Clicked += (o, e) => {
                canvasView.Tool = new SelectionTool(SelectionTool.SelectionType.Move);
            };
            view.Add(button2);

            var button3 = new Button()
            {
                Text = "Scale"
            };
            button3.Clicked += (o, e) => {
                canvasView.Tool = new SelectionTool(SelectionTool.SelectionType.Scale);
            };
            view.Add(button3);

            var Undo = new Button()
            {
                Text = "Undo"
            };

            var Redo = new Button()
            {
                Text = "Redo"
            };

            Undo.IsEnabled = canvasView.CanUndo;
            Undo.Clicked += (o, e) => {
                canvasView.Undo();
                Redo.IsEnabled = canvasView.CanRedo;
                Undo.IsEnabled = canvasView.CanUndo;
            };
            view.Add(Undo);

            Redo.IsEnabled = canvasView.CanRedo;
            Redo.Clicked += (o, e) => {
                canvasView.Redo();
                Undo.IsEnabled = canvasView.CanUndo;
                Redo.IsEnabled = canvasView.CanRedo;
            };
            view.Add(Redo);


            var Save = new Button()
            {
                Text = "Save"
            };
            Save.Clicked += (o, e) => {
                canvasView.SaveCanvas("/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/savecanvas.txt");
            };
            view.Add(Save);

            var Load = new Button()
            {
                Text = "Load"
            };
            Load.Clicked += (o, e) => {
                canvasView.LoadCanvas("/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/savecanvas.txt");
            };
            view.Add(Load);



            var Clear = new Button()
            {
                Text = "Clear"
            };
            Clear.Clicked += (o, e) => {
                canvasView.ClearCanvas();
            };
            view.Add(Clear);


            canvasView.ToggleGrid(GridDensityType.Small);
            canvasView.SetCanvasColor(Color.AquaMarine);
        }

        private void InitializeView()
        {
            mWindow = GetDefaultWindow();
            mWindow.BackgroundColor = Color.White;
            canvasView = new PWCanvasView();
            mWindow.Add(canvasView);


            canvasView.TouchEvent += OnTouchEvent;

            ToolPicker();

            // Buttons();

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
