using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.IO;

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
        private PenWaveToolPicker mToolPickerView;
        private PenWaveCanvas canvasView;
        private ImageView thumbnailView;

        public class TestTool : ToolBase
        {
            public override void Activate()
            {
            }

            public override void Deactivate()
            {
            }

            public override bool HandleInput(Touch touch)
            {
                NotifyActionFinished();
                return true;
            }

            public override bool HandleInput(Wheel wheel)
            {
                return true;
            }
        }

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
            mToolPickerView = new PenWaveToolPicker(canvasView);

            mToolPickerView.AddButtonToPickerView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/icon_picture.png", () =>
            {
                var picker = new View
                {
                    Layout = new LinearLayout
                    {
                        LinearOrientation = LinearLayout.Orientation.Horizontal
                    }
                };
                for (int i=0; i<2; i++)
                {
                    var button = new Button()
                    {
                        Text = "test_"+i.ToString(),
                    };
                    button.Clicked += (o, e) =>
                    {
                        canvasView.AddPicture(Tizen.Applications.Application.Current.DirectoryInfo.Resource+"images/pictures/venus.png", 100, 200, 500, 500);
                    };
                    picker.Add(button);
                }
                mToolPickerView.SetViewToPopupView(picker);
                mToolPickerView.ShowPopupView();
            });

            mToolPickerView.AddButtonToPickerView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/icon_picture.png", () =>
            {
                canvasView.TakeScreenShot("/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/screenshot.png", 0, 0, 1920, 1080, OnThumbnails);
            });
        }

        private void OnThumbnails(object sender, EventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnThumbnails\n");
            string source = "/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/screenshot.png";
            string destination = "/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/screenshot_copy.png";
            File.Copy(source, destination, true);
            thumbnailView.ResourceUrl = destination;
            thumbnailView.Size2D = new Size2D(300, 300);
        }

        private void Buttons()
        {

            canvasView.AddPicture(Tizen.Applications.Application.Current.DirectoryInfo.Resource+"images/pictures/venus.png", 100, 100, 500, 500);
            canvasView.CurrentTool = new PencilTool(BrushType.DashedLine, Color.Blue, 10);
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
                canvasView.CurrentTool = new EraserTool(EraserType.Partial, 20);
            };
            view.Add(button);

            var button2 = new Button()
            {
                Text = "Move"
            };
            button2.Clicked += (o, e) => {
                canvasView.CurrentTool = new SelectionTool(SelectionType.Move);
            };
            view.Add(button2);

            var button3 = new Button()
            {
                Text = "Scale"
            };
            button3.Clicked += (o, e) => {
                canvasView.CurrentTool = new SelectionTool(SelectionType.Scale);
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
            canvasView = new PenWaveCanvas();
            mWindow.Add(canvasView);


            canvasView.TouchEvent += OnTouchEvent;
            canvasView.WheelEvent += OnWheelEvent;
            thumbnailView = new ImageView();
            canvasView.Add(thumbnailView);

            ToolPicker();

            // Buttons();

        }


        private float mInitialTouchX;
        private float mInitialTouchY;
        private bool mIsCanvasMoving = false;
        private bool OnTouchEvent(object sender, View.TouchEventArgs args)
        {
            canvasView.HandleInput(args.Touch);
            return false;
        }

        private bool OnWheelEvent(object sender, View.WheelEventArgs args)
        {
            canvasView.HandleInput(args.Wheel);
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
