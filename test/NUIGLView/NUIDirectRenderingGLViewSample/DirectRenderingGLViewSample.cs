using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System;

namespace DRGLApplication
{
    using log = Tizen.Log;    
    class Program : NUIApplication
    {
        const string lib = "libNUIDirectRenderingGLView-callbacks.so";
        string[] IMAGE_PATH = {
            "gallery-small-1.jpg",
            "gallery-small-2.jpg",
            "gallery-small-3.jpg",
            "gallery-small-4.jpg",
            "gallery-small-5.jpg",
            "gallery-small-6.jpg"
        };

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "initializeGL")]
        public static extern void initializeGL();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "renderFrameGL")]
        public static extern int renderFrameGL();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "terminateGL")]
        public static extern void terminateGL();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "setMVP")]
        public static extern void setMVP(IntPtr mvp);

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "setSize")]
        public static extern void setSize(int width, int height);

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "setBindings")]
        public static extern void setBindings(IntPtr binding);

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "setClippingBox")]
        public static extern void setClippingBox(int xx, int yy, int ww, int hh);

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "setViewport")]
        public static extern void setViewport(int xx, int yy, int ww, int hh);

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "getAngle")]
        public static extern int getAngle();

        [global::System.Runtime.InteropServices.DllImport(lib, EntryPoint = "setWorldColor")]
        public static extern int setWorldColor(float r, float g, float b, float a);

        private string TAG = "NUIDRGLVIEW";

        private DirectRenderingGLView glView;
        private View glViewLayout;
        private View buttonLayout;
        private Button stopButton;
        private Button regenerateButton;

        private object windowLock = new object();
        private Rectangle windowPositionSize;

        private List<Texture> list;
        private Window window;

        private int mNumTouched = 0;

        private Animation opacityAnimation;

        private bool _useUnsafeMode = true;

        private bool _useLibrary = true;

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        void Initialize()
        {
            window = Window.Default;
            window.KeyEvent += OnKeyEvent;
            window.BackgroundColor = Color.White;

            // Partial window test!
            //window.WindowPositionSize = new Rectangle(100, 200, 300, 500);

            window.ResizeCompleted += OnWindowResizedEvent;
            window.MoveCompleted += OnWindowMovedEvent;
            window.OrientationChanged += OnWindowOrientationChangedEvent;

            windowPositionSize = window.WindowPositionSize;

            window.AddAvailableOrientation(Window.WindowOrientation.Portrait);
            window.AddAvailableOrientation(Window.WindowOrientation.Landscape);
            window.AddAvailableOrientation(Window.WindowOrientation.PortraitInverse);
            window.AddAvailableOrientation(Window.WindowOrientation.LandscapeInverse);

            var backgroundView = new ImageView()
            {
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,
                ResourceUrl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "bg_2.png",
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    CellPadding = new Size(0, 0),
                },
            };
            window.GetDefaultLayer().Add(backgroundView);

            log.Error(TAG, $"image Path: {backgroundView.ResourceUrl}\n");

            View layoutView = new View();
            var linearLayout = new LinearLayout();
            linearLayout.LinearOrientation = LinearLayout.Orientation.Vertical;
            linearLayout.CellPadding = new Size(0, 10);
            layoutView.Layout = linearLayout;
            layoutView.WidthSpecification = LayoutParamPolicies.MatchParent;
            layoutView.HeightSpecification = LayoutParamPolicies.MatchParent;
            window.GetDefaultLayer().Add(layoutView);

            TextLabel label = new TextLabel("NUI DirectRenderingGLView");
            label.TextColor = Color.White;
            label.BackgroundColor = Color.MidnightBlue;
            label.Weight = 0.2f;

            label.HorizontalAlignment = HorizontalAlignment.Center;
            label.VerticalAlignment = VerticalAlignment.Center;
            label.WidthSpecification = LayoutParamPolicies.MatchParent;
            label.HeightSpecification = LayoutParamPolicies.MatchParent;

            glViewLayout = new View();
            var glViewLinearLayout = new LinearLayout();
            glViewLinearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            glViewLinearLayout.CellPadding = new Size(10, 0);
            glViewLayout.Layout = glViewLinearLayout;
            glViewLayout.Weight = 0.7f;
            glViewLayout.WidthSpecification = LayoutParamPolicies.MatchParent;
            glViewLayout.HeightSpecification = LayoutParamPolicies.MatchParent;

            CreateDRGLView();

            TextLabel dummyLeft = new TextLabel("Dummy Left")
            {
                BackgroundColor = new Color(0.1f, 0.8f, 0.0f, 0.5f),
                Weight = 0.2f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            TextLabel dummyRight = new TextLabel("Dummy Right")
            {
                BackgroundColor = new Color(0.8f, 0.1f, 0.0f, 0.5f),
                Weight = 0.1f,
                WidthSpecification = LayoutParamPolicies.MatchParent,
                HeightSpecification = LayoutParamPolicies.MatchParent,

                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
            };
            glViewLayout.Add(dummyLeft);
            glViewLayout.Add(dummyRight);
            glViewLayout.Add(glView);
            glView.SiblingOrder = 1;

            buttonLayout = new View();
            var buttonViewLinearLayout = new LinearLayout();
            buttonViewLinearLayout.LinearOrientation = LinearLayout.Orientation.Horizontal;
            buttonViewLinearLayout.CellPadding = new Size(10, 0);
            buttonLayout.Layout = buttonViewLinearLayout;
            buttonLayout.Weight = 0.1f;
            buttonLayout.WidthSpecification = LayoutParamPolicies.MatchParent;
            buttonLayout.HeightSpecification = LayoutParamPolicies.MatchParent;

            stopButton = new Button();
            stopButton.BackgroundColor = Color.MidnightBlue;
            stopButton.TextLabel.TextColor = Color.White;
            stopButton.TextLabel.Text = "Stop";
            stopButton.Weight = 0.5f;
            stopButton.WidthSpecification = LayoutParamPolicies.MatchParent;
            stopButton.HeightSpecification = LayoutParamPolicies.MatchParent;
            stopButton.Clicked += OnStopClicked;

            regenerateButton = new Button();
            regenerateButton.BackgroundColor = Color.MidnightBlue;
            regenerateButton.TextLabel.TextColor = Color.White;
            if (_useUnsafeMode)
            {
                regenerateButton.TextLabel.Text = "Change BackendMode = DirectRendering";
            }
            else
            {
                regenerateButton.TextLabel.Text = "Change BackendMode = UnsafeDirectRendering";
            }
            regenerateButton.Weight = 0.5f;
            regenerateButton.WidthSpecification = LayoutParamPolicies.MatchParent;
            regenerateButton.HeightSpecification = LayoutParamPolicies.MatchParent;
            regenerateButton.Clicked += OnRegenerateClicked;

            buttonLayout.Add(stopButton);
            buttonLayout.Add(regenerateButton);

            layoutView.Add(label);
            layoutView.Add(glViewLayout);
            layoutView.Add(buttonLayout);

            opacityAnimation = new Animation(10000);
            opacityAnimation.LoopingMode = Animation.LoopingModes.AutoReverse;
            opacityAnimation.Looping = true;
            opacityAnimation.AnimateTo(layoutView, "Opacity", 0.25f, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseInOutSine));
            opacityAnimation.Play();

            TextLabel labelz = new TextLabel("Hello World!");
            labelz.BackgroundColor = new Color(1.0f, 1.0f, 0.0f, 0.5f);
            labelz.Size = new Size(400.0f, 200.0f);
            labelz.HorizontalAlignment = HorizontalAlignment.Center;
            labelz.VerticalAlignment = VerticalAlignment.Center;
            labelz.ParentOrigin = ParentOrigin.TopLeft;
            labelz.PivotPoint = PivotPoint.TopLeft;
            window.GetDefaultLayer().Add(labelz);
        }

        private void OnWindowMovedEvent(object sender, WindowMoveCompletedEventArgs e)
        {
            log.Info(TAG, $"OnWindowMovedEvent() called!, {e.WindowCompletedPosition.X}, {e.WindowCompletedPosition.Y}\n");
            lock (windowLock)
            {
                windowPositionSize = new Rectangle(e.WindowCompletedPosition.X, e.WindowCompletedPosition.Y, windowPositionSize.Width, windowPositionSize.Height);
            }
        }

        private void OnWindowResizedEvent(object sender, WindowResizeCompletedEventArgs e)
        {
            log.Info(TAG, $"OnWindowResizedEvent() called!, {e.WindowCompletedSize.Width}, {e.WindowCompletedSize.Height}\n");
            lock (windowLock)
            {
                windowPositionSize = new Rectangle(windowPositionSize.X, windowPositionSize.Y, e.WindowCompletedSize.Width, e.WindowCompletedSize.Height);
            }
        }

        private void OnWindowOrientationChangedEvent(object sender, WindowOrientationChangedEventArgs e)
        {
            Window.WindowOrientation orientation = e.WindowOrientation;
            log.Info(TAG, $"OnWindowOrientationChangedEvent() called!, orientation:{orientation}\n");
        }

        private void CreateDRGLView()
        {
            glView = new DirectRenderingGLView(DirectRenderingGLView.ColorFormat.RGBA8888, _useUnsafeMode ? DirectRenderingGLView.BackendMode.UnsafeDirectRendering : DirectRenderingGLView.BackendMode.DirectRendering);
            glView.Weight = 0.7f;
            glView.WidthSpecification = LayoutParamPolicies.MatchParent;
            glView.HeightSpecification = LayoutParamPolicies.MatchParent;

            glView.SetGraphicsConfig(true, true, 0, GLESVersion.Version20);
            glView.RenderingMode = GLRenderingMode.Continuous;

            _useLibrary = true;
            try
            {
                _ = getAngle();
                glView.RegisterGLCallbacks(initializeGL, OnRender, terminateGL);
            }
            catch(Exception ex)
            {
                log.Error(TAG, $"Exception occurred: {ex.Message}");
                _useLibrary = false;
                glView.RegisterGLCallbacks(OnInitializeCSharp, OnRenderCSharp, OnTerminateCSharp);
            }
            glView.TouchEvent += OnTouchEvent;

            LoadTexture();

            if (stopButton != null)
            {
                stopButton.TextLabel.Text = "Stop";
            }
            opacityAnimation?.Play();
        }

        private void LoadTexture()
        {
            list = new List<Texture>();

            for (int i = 0; i < 6; i++)
            {
                PixelBuffer pixelBuffer = ImageLoader.LoadImageFromFile(Tizen.Applications.Application.Current.DirectoryInfo.Resource + IMAGE_PATH[i]);
                PixelData pixelData = PixelBuffer.Convert(pixelBuffer);
                Texture texture = new Texture(TextureType.TEXTURE_2D, pixelData.GetPixelFormat(), pixelData.GetWidth(), pixelData.GetHeight());
                texture.Upload(pixelData);
                list.Add(texture);
            }

            glView.BindTextureResources(list);
        }

        private void GLViewTouched()
        {
            mNumTouched++;
            switch (mNumTouched % 4)
            {
                case 0:
                {
                    glView.Weight = 0.7f;
                    glViewLayout.Weight = 0.7f;
                    break;
                }
                case 1:
                {
                    glView.Weight = 0.7f;
                    glViewLayout.Weight = 0.1f;
                    break;
                }
                case 2:
                {
                    glView.Weight = 0.1f;
                    glViewLayout.Weight = 0.7f;
                    break;
                }
                case 3:
                {
                    glView.Weight = 0.1f;
                    glViewLayout.Weight = 0.1f;
                    break;
                }
            }
        }

        // GLView Callbacks if library link error occured (For example, Ubunut backend)
        public void OnInitializeCSharp()
        {
            log.Error(TAG, $"OnInitializeCSharp\n");
        }

        public int OnRenderCSharp(in DirectRenderingGLView.RenderCallbackInput input)
        {
            log.Error(TAG, $"OnRenderCSharp\n");

            Rectangle localWindowPositionSize;
            lock (windowLock)
            {
                localWindowPositionSize = new Rectangle(windowPositionSize.X, windowPositionSize.Y, windowPositionSize.Width, windowPositionSize.Height);
            }

            if (input.TextureBindings.Count > 0u)
            {
                log.Error(TAG, $"  TextureBindings {input.TextureBindings.Count}\n");
                int[] bindings = new int[input.TextureBindings.Count];
                for (int i = 0; i < input.TextureBindings.Count; i++)
                {
                    bindings[i] = input.TextureBindings[i];
                    log.Error(TAG, $"   [{i}] : {bindings[i]}\n");
                }
            }

            // Trick to check window rotated or not.
            // For now, just consider 90 degree cases.
            bool isRotated = Math.Abs(input.Projection.ValueOfIndex(0, 0)) + Math.Abs(input.Projection.ValueOfIndex(1, 1)) < Math.Abs(input.Projection.ValueOfIndex(0, 1)) + Math.Abs(input.Projection.ValueOfIndex(1, 0));

            log.Error(TAG, $"  Window Rotated? : {isRotated}\n");
            log.Error(TAG, $"  Window PositionSize : {localWindowPositionSize.X},{localWindowPositionSize.Y} : {localWindowPositionSize.Width}x{localWindowPositionSize.Height}\n");
            log.Error(TAG, $"  Size : {input.Size.Width}, {input.Size.Height}\n");
            log.Error(TAG, $"  WorldColor : {input.WorldColor.R}, {input.WorldColor.G} {input.WorldColor.B} {input.WorldColor.A}\n");
            log.Error(TAG, $"  Clipping : {input.ClippingBox.X},{input.ClippingBox.Y} : {input.ClippingBox.Width}x{input.ClippingBox.Height}\n");

            int mAngle = 0;
            Matrix local = new Matrix(new Rotation(new Radian(new Degree(mAngle)), new Vector3(1.0f, 1.0f, 0.0f)));
            Matrix mvp = new Matrix();
            Matrix.Multiply(mvp, local, input.Mvp);
            log.Error(TAG, $"  Local angle : {mAngle}\n");

            float[] mvpArray = new float[16];
            for (uint i = 0; i < mvpArray.Length; i++)
            {
                mvpArray[i] = mvp[i];
            }
            log.Error(TAG, $"  Local mvp :\n");
            for (uint i = 0; i < 4; i++)
            {
                log.Error(TAG, $"  {mvpArray[i]}, {mvpArray[4 + i]}, {mvpArray[8 + i]}, {mvpArray[12 + i]}\n");
            }
            return 1;
        }

        public void OnTerminateCSharp()
        {
            log.Error(TAG, $"OnTerminateCSharp\n");
        }

        // GLView Callbacks
        public int OnRender(in DirectRenderingGLView.RenderCallbackInput input)
        {
            log.Error(TAG, $"OnRender\n");
            Rectangle localWindowPositionSize;
            lock (windowLock)
            {
                localWindowPositionSize = new Rectangle(windowPositionSize.X, windowPositionSize.Y, windowPositionSize.Width, windowPositionSize.Height);
            }

            if (input.TextureBindings.Count > 0u)
            {
                log.Error(TAG, $"  TextureBindings {input.TextureBindings.Count}\n");
                int[] bindings = new int[input.TextureBindings.Count];
                for (int i = 0; i < input.TextureBindings.Count; i++)
                {
                    bindings[i] = input.TextureBindings[i];
                    log.Error(TAG, $"   [{i}] : {bindings[i]}\n");
                }

                unsafe
                {
                    IntPtr unmanagedPointer = Marshal.AllocHGlobal(sizeof(int) * 6);
                    System.Runtime.InteropServices.Marshal.Copy(bindings, 0, unmanagedPointer, 6);
                    setBindings(unmanagedPointer);
                    Marshal.FreeHGlobal(unmanagedPointer);
                }
            }

            // Trick to check window rotated or not.
            // For now, just consider 90 degree cases.
            bool isRotated = Math.Abs(input.Projection.ValueOfIndex(0, 0)) + Math.Abs(input.Projection.ValueOfIndex(1, 1)) < Math.Abs(input.Projection.ValueOfIndex(0, 1)) + Math.Abs(input.Projection.ValueOfIndex(1, 0));

            log.Error(TAG, $"  Window Rotated? : {isRotated}\n");
            log.Error(TAG, $"  Window PositionSize : {localWindowPositionSize.X},{localWindowPositionSize.Y} : {localWindowPositionSize.Width}x{localWindowPositionSize.Height}\n");
            log.Error(TAG, $"  Size : {input.Size.Width}, {input.Size.Height}\n");
            log.Error(TAG, $"  WorldColor : {input.WorldColor.R}, {input.WorldColor.G} {input.WorldColor.B} {input.WorldColor.A}\n");
            log.Error(TAG, $"  Clipping : {input.ClippingBox.X},{input.ClippingBox.Y} : {input.ClippingBox.Width}x{input.ClippingBox.Height}\n");

            // Note that we should use view port position always (0,0), since it depend on window size
            setViewport(0, 0, localWindowPositionSize.Width, localWindowPositionSize.Height);
            setSize((int)input.Size.Width, (int)input.Size.Height);
            setWorldColor(input.WorldColor.R, input.WorldColor.G, input.WorldColor.B, input.WorldColor.A);

            // Note that input.ClippingBox's (0,0) is left-bottom of window (not include rotation!).
            // And glScissor need to (0,0) is left-bottom of window (not include rotation!).
            // We can call glScissor directly.
            setClippingBox(input.ClippingBox.X, input.ClippingBox.Y, input.ClippingBox.Width, input.ClippingBox.Height);

            log.Error(TAG, $"  MVP :\n");
            for (uint i = 0; i < 4; i++)
            {
                log.Error(TAG, $"  {input.Mvp.ValueOfIndex(i, 0)}, {input.Mvp.ValueOfIndex(i, 1)}, {input.Mvp.ValueOfIndex(i, 2)}, {input.Mvp.ValueOfIndex(i, 3)}\n");
            }
            log.Error(TAG, $"  Projection :\n");
            for (uint i = 0; i < 4; i++)
            {
                log.Error(TAG, $"  {input.Projection.ValueOfIndex(i, 0)}, {input.Projection.ValueOfIndex(i, 1)}, {input.Projection.ValueOfIndex(i, 2)}, {input.Projection.ValueOfIndex(i, 3)}\n");
            }

            int mAngle = getAngle();
            Matrix local = new Matrix(new Rotation(new Radian(new Degree(mAngle)), new Vector3(1.0f, 1.0f, 0.0f)));
            Matrix mvp = new Matrix();
            Matrix.Multiply(mvp, local, input.Mvp);
            log.Error(TAG, $"  Local angle : {mAngle}\n");

            float[] mvpArray = new float[16];
            for (uint i = 0; i < mvpArray.Length; i++)
            {
                mvpArray[i] = mvp[i];
            }
            log.Error(TAG, $"  Local mvp :\n");
            for (uint i = 0; i < 4; i++)
            {
                log.Error(TAG, $"  {mvpArray[i]}, {mvpArray[4 + i]}, {mvpArray[8 + i]}, {mvpArray[12 + i]}\n");
            }

            unsafe
            {
                IntPtr unmanagedPointer = Marshal.AllocHGlobal(sizeof(float) * 16);
                System.Runtime.InteropServices.Marshal.Copy(mvpArray, 0, unmanagedPointer, 16);
                setMVP(unmanagedPointer);
                Marshal.FreeHGlobal(unmanagedPointer);
            }
            log.Error(TAG, $"OnRender done\n");

            return renderFrameGL();
        }

        private void OnStopClicked(object sender, ClickedEventArgs e)
        {
            if (glView.RenderingMode == GLRenderingMode.Continuous)
            {
                stopButton.TextLabel.Text = "Start";
                glView.RenderingMode = GLRenderingMode.OnDemand;
                opacityAnimation.Pause();
            }
            else
            {
                stopButton.TextLabel.Text = "Stop";
                glView.RenderingMode = GLRenderingMode.Continuous;
                opacityAnimation.Play();
            }
        }

        private void OnRegenerateClicked(object sender, ClickedEventArgs e)
        {
            if (glView != null)
            {
                glView.Terminate();
                glView.TouchEvent -= OnTouchEvent;
                glView.Dispose();
                glView = null;
            }

            _useUnsafeMode = !_useUnsafeMode;
            if (_useUnsafeMode)
            {
                regenerateButton.TextLabel.Text = "Change BackendMode = DirectRendering";
            }
            else
            {
                regenerateButton.TextLabel.Text = "Change BackendMode = UnsafeDirectRendering";
            }

            // Note : For this sample, we can assume that old glView's terminateGL() will be called before new glView's initializeGL().
            // So we can use same function pointer.
            // But the order of function call could not be guaranteed in real world scenarios. Be careful!

            CreateDRGLView();
            glViewLayout.Add(glView);
            glView.SiblingOrder = 1;
        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape")
                {
                    Exit();
                }
                else if (e.Key.KeyPressedName == "1")
                {
                    GLViewTouched();
                }
            }
        }

        public bool OnTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                GLViewTouched();
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

