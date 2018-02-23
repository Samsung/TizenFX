using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ImageViewUserShaderTest
{
    class Test : NUIApplication
    {
        public Test() : base("", WindowMode.Transparent)
        {
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }
        static string TAG = "NUI";
        static readonly string vertexShaderSource =
            "attribute mediump vec2 aPosition;\n" +
            "uniform mediump mat4 uMvpMatrix;\n" +
            "uniform mediump vec3 uSize;\n" +
            "varying mediump vec2 vTexCoord;\n" +
            "\n" +
            "void main()\n" +
            "{\n" +
            "  mediump vec4 position = vec4( aPosition, 0.0, 1.0 );\n" +
            "  position.xyz *= uSize;\n" +
            "  gl_Position = uMvpMatrix * position;\n" +
            "  vTexCoord = aPosition + vec2( 0.5 );\n" +
            "}\n";

        static readonly string fragmentShaderSource =
            "varying mediump vec2 vTexCoord;\n" +
            "uniform lowp vec4 uColor;\n" +
            "uniform sampler2D sTexture;\n" +
            "\n" +
            "void main()\n" +
            "{\n" +
            "   lowp vec4 color = texture2D( sTexture, vTexCoord ) * uColor;\n" +
            "   gl_FragColor = vec4(vec3(1.0)  - color.rgb, color.a);\n" +
            "}\n";

        Timer timer;
        Window window;
        ImageView imageView, imageView2;
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        static string url_shader = resourcePath + "/images/image-2.jpg";
        void Initialize()
        {
            window = Window.Instance;
            window.BackgroundColor = new Color(0.0f, 0.0f, 0.0f, 0.0f);

            Tizen.Log.Fatal(TAG, $"url_shader={url_shader}");
            imageView = new ImageView(url_shader);
            imageView.PositionUsesPivotPoint = true;
            imageView.PivotPoint = PivotPoint.Center;
            imageView.ParentOrigin = ParentOrigin.Center;
            imageView.Size2D = new Size2D(500, 500);
            Tizen.Log.Fatal(TAG, $"#1 imageView.LoadingStatus={imageView.LoadingStatus}");
            window.Add(imageView);

            map = new PropertyMap();
            customShader = new PropertyMap();
            customShader.Add("vertexShader", new PropertyValue(vertexShaderSource));
            customShader.Add("fragmentShader", new PropertyValue(fragmentShaderSource));
            map.Add("shader", new PropertyValue(customShader));
            imageView.Image = map;

            Tizen.Log.Fatal(TAG, $"#2 imageView.LoadingStatus={imageView.LoadingStatus}");

            timer = new Timer(1000);
            timer.Tick += Timer_Tick;
            timer.Start();

            string url = "   ";
            imageView2 = new ImageView(url);
            imageView2.PositionUsesPivotPoint = true;
            imageView2.PivotPoint = PivotPoint.BottomCenter;
            imageView2.ParentOrigin = ParentOrigin.BottomCenter;
            imageView2.Size2D = new Size2D(300, 300);
            Tizen.Log.Fatal(TAG, $"###1 imageView2.LoadingStatus={imageView2.LoadingStatus}");
            window.Add(imageView2);
            Tizen.Log.Fatal(TAG, $"###2 imageView2.LoadingStatus={imageView2.LoadingStatus}");
        }

        int cnt;
        PropertyMap map;
        PropertyMap customShader;
        private bool Timer_Tick(object source, Timer.TickEventArgs e)
        {
            Tizen.Log.Fatal(TAG, $"#3 imageView.LoadingStatus={imageView?.LoadingStatus}");
            Tizen.Log.Fatal(TAG, $"###3 imageView2.LoadingStatus={imageView2?.LoadingStatus}");
            Tizen.Log.Fatal(TAG, $"Timer_Tick() comes!");

            if (cnt++ % 2 == 0)
            {
                map.Clear();
                customShader.Clear();
                map.Add("shader", new PropertyValue(customShader));
                imageView.Image = map;
            }
            else
            {
                map.Clear();
                customShader.Clear();
                customShader.Add("vertexShader", new PropertyValue(vertexShaderSource));
                customShader.Add("fragmentShader", new PropertyValue(fragmentShaderSource));
                map.Add("shader", new PropertyValue(customShader));
                imageView.Image = map;
            }

            Tizen.Log.Fatal(TAG, $"#4 imageView.LoadingStatus={imageView.LoadingStatus}");

            if (cnt % 3 == 0)
            {
                window.SetTransparency(false);
                Random rand = new Random();
                float value = rand.Next(0, 255) / 255.0f;
                window.BackgroundColor = new Color(value, value, 1 - value, 1.0f);
            }
            else
            {
                window.SetTransparency(true);
                window.BackgroundColor = new Color(0, 0, 0, 0);
            }

            string url1 = resourcePath + "/images/image-" + (cnt % 3 + 1) + ".jpg";
            Tizen.Log.Fatal(TAG, $"url1={url1}");
            imageView2?.Dispose();
            imageView2 = null;
            imageView2 = new ImageView(url1);
            imageView2.PositionUsesPivotPoint = true;
            imageView2.PivotPoint = PivotPoint.BottomCenter;
            imageView2.ParentOrigin = ParentOrigin.BottomCenter;
            imageView2.Size2D = new Size2D(300, 300);
            Tizen.Log.Fatal(TAG, $"###4 imageView2.LoadingStatus={imageView2.LoadingStatus}");
            window.Add(imageView2);

            Tizen.Log.Fatal(TAG, $"#5 imageView.LoadingStatus={imageView.LoadingStatus}");
            Tizen.Log.Fatal(TAG, $"###5 imageView2.LoadingStatus={imageView2.LoadingStatus}");
            return true;
        }
    }
}
