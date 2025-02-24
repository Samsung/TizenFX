using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace GLApplication
{
    using log = Tizen.Log;    
    class Program : NUIApplication
    {
        const string lib = "libNUIGLView-callbacks.so.0.0.1";
        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "initializeGL")]
        public static extern void initializeGL();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "renderFrameGL")]
        public static extern int renderFrameGL();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "terminateGL")]
        public static extern void terminateGL();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "updateTouchPosition")]
        public static extern void updateTouchPosition(int state, int x, int y);

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "updateGLViewSize")]
        public static extern void updateGLViewSize(int w, int h);

        private string TAG = "NUIGLVIEW";

        private GLView glView;
        
        private Button textButton;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            Window.Instance.KeyEvent += OnKeyEvent;
            Window.Instance.BackgroundColor = Color.White;

            var backgroundView = new ImageView()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "bg_2.png",
            };
            Window.Instance.Add(backgroundView);

            log.Error(TAG, $"image Path: {backgroundView.ResourceUrl}\n");

            View layoutView = new View();
            var linearLayout = new LinearLayout();
            linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
            linearLayout.CellPadding = new Size(0, 0);
            layoutView.Layout = linearLayout;
            layoutView.WidthResizePolicy = ResizePolicyType.FillToParent;
            layoutView.HeightResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(layoutView);

            TextLabel label = new TextLabel("NUI GLView");
            label.TextColor = Color.White;
            label.BackgroundColor = Color.MidnightBlue;
            label.Weight = 0.1f;

            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.WidthResizePolicy = ResizePolicyType.FillToParent;
            label.HeightResizePolicy = ResizePolicyType.FillToParent;

            glView = new GLView(GLView.ColorFormat.RGBA8888);
            glView.Weight = 0.7f;
            glView.WidthResizePolicy = ResizePolicyType.FillToParent;
            glView.HeightResizePolicy = ResizePolicyType.FillToParent;

            glView.SetGraphicsConfig(true, true, 0, GLESVersion.Version20);
            glView.RenderingMode = GLRenderingMode.Continuous;
            glView.RegisterGLCallbacks(initializeGL, renderFrameGL, terminateGL);
            glView.SetResizeCallback(updateGLViewSize);
            glView.TouchEvent += OnTouchEvent;

            textButton = new Button();
            textButton.BackgroundColor = Color.MidnightBlue;
            textButton.TextLabel.TextColor = Color.White;
            textButton.TextLabel.Text = "Stop";
            textButton.Weight = 0.1f;
            textButton.WidthResizePolicy = ResizePolicyType.FillToParent;
            textButton.HeightResizePolicy = ResizePolicyType.FillToParent;
            textButton.Clicked += OnClicked;

            layoutView.Add(label);
            layoutView.Add(glView);
            layoutView.Add(textButton);
        }

        private int OnRender(in DirectRenderingGLView.RenderCallbackInput input)
        {
            return renderFrameGL();
        }

        private void OnClicked(object sender, ClickedEventArgs e)
        {
            if (glView.RenderingMode == GLRenderingMode.Continuous)
            {
                textButton.TextLabel.Text = "Start";
                glView.RenderingMode = GLRenderingMode.OnDemand;
            }
            else
            {
                textButton.TextLabel.Text = "Stop";
                glView.RenderingMode = GLRenderingMode.Continuous;
            }
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape")
                {
                    Exit();
                }
            }
        }

        public bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (glView.RenderingMode == GLRenderingMode.Continuous)
            {
                if (e.Touch.GetState(0) == PointStateType.Up)
                {
                    updateTouchPosition(1, (int)(e.Touch.GetScreenPosition(0).X), (int)(e.Touch.GetScreenPosition(0).Y));
                }
                else if (e.Touch.GetState(0) == PointStateType.Down)
                {
                    updateTouchPosition(0, (int)(e.Touch.GetScreenPosition(0).X), (int)(e.Touch.GetScreenPosition(0).Y));
                }
                else if (e.Touch.GetState(0) == PointStateType.Motion)
                {
                    updateTouchPosition(2, (int)(e.Touch.GetScreenPosition(0).X), (int)(e.Touch.GetScreenPosition(0).Y));
                }
            }

            return true;
        }

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}

