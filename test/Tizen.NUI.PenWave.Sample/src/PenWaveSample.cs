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
        public static Program App;
        private Window _window;
        private PenWaveToolPicker _toolPickerView;
        private PenWaveCanvas _canvasView;
        private ImageView _thumbnailView;

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
            _toolPickerView = new PenWaveToolPicker(_canvasView);

            _toolPickerView.AddButtonToPickerView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/icon_picture.png", () =>
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
                        _canvasView.AddPicture(Tizen.Applications.Application.Current.DirectoryInfo.Resource+"images/pictures/venus.png", 100, 200, 500, 500);
                    };
                    picker.Add(button);
                }
                _toolPickerView.SetViewToPopupView(picker);
                _toolPickerView.ShowPopupView();
            });

            _toolPickerView.AddButtonToPickerView(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/icon_picture.png", () =>
            {
                _canvasView.TakeScreenShot("/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/screenshot.png", 0, 0, 1920, 1080, OnThumbnails);
            });
        }

        private void OnThumbnails(object sender, EventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnThumbnails\n");
            string source = "/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/screenshot.png";
            string destination = "/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/screenshot_copy.png";
            File.Copy(source, destination, true);
            _thumbnailView.ResourceUrl = destination;
            _thumbnailView.Size2D = new Size2D(300, 300);
        }

        private void Buttons()
        {

            _canvasView.AddPicture(Tizen.Applications.Application.Current.DirectoryInfo.Resource+"images/pictures/venus.png", 100, 100, 500, 500);
            _canvasView.CurrentTool = new PencilTool(BrushType.DashedLine, Color.Blue, 10);
            var view = new View()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                },
            };
            _canvasView.Add(view);
            var button = new Button()
            {
                Text = "Eraser"
            };
            button.Clicked += (o, e) => {
                _canvasView.CurrentTool = new EraserTool(EraserType.Partial, 20);
            };
            view.Add(button);

            var button2 = new Button()
            {
                Text = "Move"
            };
            button2.Clicked += (o, e) => {
                _canvasView.CurrentTool = new SelectionTool(SelectionTransformType.Move);
            };
            view.Add(button2);

            var button3 = new Button()
            {
                Text = "Scale"
            };
            button3.Clicked += (o, e) => {
                _canvasView.CurrentTool = new SelectionTool(SelectionTransformType.Scale);
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

            Undo.IsEnabled = _canvasView.CanUndo;
            Undo.Clicked += (o, e) => {
                _canvasView.Undo();
                Redo.IsEnabled = _canvasView.CanRedo;
                Undo.IsEnabled = _canvasView.CanUndo;
            };
            view.Add(Undo);

            Redo.IsEnabled = _canvasView.CanRedo;
            Redo.Clicked += (o, e) => {
                _canvasView.Redo();
                Undo.IsEnabled = _canvasView.CanUndo;
                Redo.IsEnabled = _canvasView.CanRedo;
            };
            view.Add(Redo);


            var Save = new Button()
            {
                Text = "Save"
            };
            Save.Clicked += (o, e) => {
                _canvasView.SaveCanvas("/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/savecanvas.txt");
            };
            view.Add(Save);

            var Load = new Button()
            {
                Text = "Load"
            };
            Load.Clicked += (o, e) => {
                _canvasView.LoadCanvas("/home/puro/workspace/submit/TizenFX/test/Tizen.NUI.PenWave.Sample/savecanvas.txt");
            };
            view.Add(Load);



            var Clear = new Button()
            {
                Text = "Clear"
            };
            Clear.Clicked += (o, e) => {
                _canvasView.ClearCanvas();
            };
            view.Add(Clear);


            _canvasView.ToggleGrid(GridDensityType.Small);
            _canvasView.SetCanvasColor(Color.AquaMarine);
        }

        private void InitializeView()
        {
            _window = GetDefaultWindow();
            _window.BackgroundColor = Color.White;
            _canvasView = new PenWaveCanvas();
            _window.Add(_canvasView);


            _canvasView.TouchEvent += OnTouchEvent;
            _canvasView.WheelEvent += OnWheelEvent;
            _thumbnailView = new ImageView();
            _canvasView.Add(_thumbnailView);

            ToolPicker();

            // Buttons();

        }


        private float _initialTouchX;
        private float _initialTouchY;
        private bool _isCanvasMoving = false;
        private bool OnTouchEvent(object sender, View.TouchEventArgs args)
        {
            _canvasView.HandleInput(args.Touch);
            return false;
        }

        private bool OnWheelEvent(object sender, View.WheelEventArgs args)
        {
            _canvasView.HandleInput(args.Wheel);
            return false;
        }


        static void Main(string[] args)
        {
            WindowData newWindowData = new WindowData();
            newWindowData.FrontBufferRendering = true;
            newWindowData.WindowMode = WindowMode.Opaque;
            App = new Program(ThemeOptions.None, newWindowData);
            App.Run(args);
            App.Dispose();
        }
    }
}
