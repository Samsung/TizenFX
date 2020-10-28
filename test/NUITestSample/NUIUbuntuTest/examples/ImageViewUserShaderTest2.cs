using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ImageViewUserShaderTest2
{
    internal class Test : NUIApplication
    {
        private string vertexShader =
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

        private readonly string fragmentShader =

            "varying mediump vec2 vTexCoord;\n" +
            "uniform lowp vec4 uColor;\n" +
            "uniform sampler2D sTexture;\n" +
            "uniform mediump vec4 userColor;\n" +
            "\n" +
            "void main()\n" +
            "{\n" +
            "   mediump vec4 blend_color = userColor;\n" +
            "   mediump vec4 fColor = vec4(1.0, 1.0, 1.0, texture2D( sTexture, vTexCoord ).a);\n" +
            "   gl_FragColor = blend_color * fColor * uColor;\n" +
            "}\n";


        private View myView;
        private ImageView myImageView;
        private int count = 0;
        private bool changeImgResource = true;
        static string res = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        protected override void OnCreate()
        {
            base.OnCreate();

            Window.Instance.BackgroundColor = Color.White;

            //Create a View instance and add it to the stage
            myView = new View();
            myView.Focusable = true;
            myView.KeyEvent += MyView_KeyEvent;

            Window.Instance.GetDefaultLayer().Add(myView);

            myImageView = new ImageView(@res + @"/images/star-dim.png");
            myImageView.Size2D = new Size2D(96, 96);
            myImageView.Position2D = new Position2D(400, 400);

            ChangePropertyMap(Color.Red);

            Window.Instance.GetDefaultLayer().Add(myImageView);

            FocusManager.Instance.SetCurrentFocusView(myView);
        }

        private bool MyView_KeyEvent(object source, View.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down)
            {
                if (e.Key.KeyPressedName == "Right")
                {
                    switch (count++ % 2)
                    {
                        case 0:
                            if (changeImgResource)
                            {
                                myImageView.SetImage(@res + @"/images/mask.png");
                            }
                            ChangePropertyMap(Color.Blue);
                            break;
                        case 1:
                            if (changeImgResource)
                            {
                                myImageView.SetImage(@res + @"/images/star-dim.png");
                            }
                            ChangePropertyMap(Color.Green);
                            break;
                    }
                }
            }

            return false;
        }

        private void ChangePropertyMap(Color color)
        {
            PropertyMap shaderMap = new PropertyMap();
            shaderMap.Add("vertexShader", new PropertyValue(vertexShader));
            shaderMap.Add("fragmentShader", new PropertyValue(fragmentShader));

            PropertyMap imageMap = new PropertyMap();
            imageMap.Add("shader", new PropertyValue(shaderMap));
            myImageView.Image = imageMap;

            myImageView.RegisterProperty("userColor", new PropertyValue(color));
        }

    }
}