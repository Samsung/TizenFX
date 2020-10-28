using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace SvgTest
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        string test_url = "/home/owner/apps_rw/org.tizen.example.NUITemplate3/res/3.svg";

        TextField[] textField = new TextField[5];
        ImageView[] imageView = new ImageView[10];
        int iSVGimage = 50, iSynchronous = 0, iTextColor = 0, iPointSize = 20, iPointSize2 = 20, mImageCombinationIndex = 0;
        int resol = 1;

        void Initialize()
        {
            //NUILog.Debug("### SvgTest => OnCreate()!");

            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            //NUILog.Debug($"### window.Dpi={window.Dpi}");

            Vector2 dpi = new Vector2();
            dpi = window.Dpi;
            //NUILog.Debug($"### window.Dpi x={dpi.X}, y={dpi.Y}");

            textField[0] = new TextField();
            textField[0].Size2D = new Size2D(300 * resol, 64 * resol);
            textField[0].Position2D = new Position2D(10 * resol, 600 * resol);
            textField[0].PivotPoint = PivotPoint.TopLeft;
            textField[0].BackgroundColor = Color.White;
            textField[0].PointSize = iPointSize * resol;
            textField[0].PlaceholderText = "imageview setsize X";
            textField[0].TextColor = Color.Red;

            textField[1] = new TextField();
            textField[1].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[1].Position2D = new Position2D(400 * resol, 600 * resol);
            textField[1].PivotPoint = PivotPoint.TopLeft;
            textField[1].BackgroundColor = Color.White;
            textField[1].PointSize = iPointSize * resol;
            textField[1].PlaceholderText = "imageview setsize 200,400";
            textField[1].TextColor = Color.Red;

            textField[2] = new TextField();
            textField[2].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[2].Position2D = new Position2D(750 * resol, 600 * resol);
            textField[2].PivotPoint = PivotPoint.TopLeft;
            textField[2].BackgroundColor = Color.White;
            textField[2].PointSize = iPointSize * resol;
            textField[2].PlaceholderText = "imageview setsize 300,300";
            textField[2].TextColor = Color.Red;

            textField[3] = new TextField();
            textField[3].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[3].Position2D = new Position2D(1100 * resol, 600 * resol);
            textField[3].PivotPoint = PivotPoint.TopLeft;
            textField[3].BackgroundColor = Color.White;
            textField[3].PointSize = iPointSize * resol;
            textField[3].PlaceholderText = "imageview setsize 500,500";
            textField[3].TextColor = Color.Red;

            window.Add(textField[0]);
            window.Add(textField[1]);
            window.Add(textField[2]);
            window.Add(textField[3]);

            PropertyMap map0 = new PropertyMap();
            map0.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.Image));
            string test_url0 = "/home/owner/apps_rw/org.tizen.example.NUITemplate3/res/images/test-image.png";
            map0.Add(ImageVisualProperty.URL, new PropertyValue(test_url0));
            map0.Add(ImageVisualProperty.CropToMask + 3, new PropertyValue(true));
            imageView[0] = new ImageView();
            imageView[0].Position2D = new Position2D(10 * resol, 20 * resol);
            imageView[0].PivotPoint = PivotPoint.TopLeft;
            imageView[0].ParentOrigin = ParentOrigin.TopLeft;
            imageView[0].ImageMap = map0;
            imageView[0].BackgroundColor = Color.Black;
            window.Add(imageView[0]);

            return;

            PropertyMap map1 = new PropertyMap();
            map1.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.SVG));
            //map1.Add(ImageVisualProperty.URL, new PropertyValue(IMAGE_PATH[iSVGimage]));
            map1.Add(ImageVisualProperty.URL, new PropertyValue(test_url));
            map1.Add((int)Visual.Property.MixColor, new PropertyValue(new Color(0.7f, 0.0f, 0.0f, 1.0f)));
            imageView[1] = new ImageView();
            imageView[1].Size2D = new Size2D(200 * resol, 400 * resol);
            imageView[1].Position2D = new Position2D(400 * resol, 20 * resol);
            imageView[1].PivotPoint = PivotPoint.TopLeft;
            imageView[1].ParentOrigin = ParentOrigin.TopLeft;
            imageView[1].Image = map1;
            imageView[1].BackgroundColor = Color.Black;
            //            ConnectSignal(imageView[1]);

            PropertyMap map2 = new PropertyMap();
            map2.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.SVG));
            //map2.Add(ImageVisualProperty.URL, new PropertyValue(IMAGE_PATH[iSVGimage]));
            map2.Add(ImageVisualProperty.URL, new PropertyValue(test_url));
            imageView[2] = new ImageView();
            imageView[2].Size2D = new Size2D(300 * resol, 300 * resol);
            imageView[2].Position2D = new Position2D(700 * resol, 20 * resol);
            imageView[2].PivotPoint = PivotPoint.TopLeft;
            imageView[2].ParentOrigin = ParentOrigin.TopLeft;
            imageView[2].Image = map2;
            imageView[2].BackgroundColor = Color.Black;
            //            ConnectSignal(imageView[2]);

            PropertyMap map3 = new PropertyMap();
            map3.Add(Visual.Property.Type, new PropertyValue((int)Visual.Type.SVG));
            //map3.Add(ImageVisualProperty.URL, new PropertyValue(IMAGE_PATH[iSVGimage]));
            map3.Add(ImageVisualProperty.URL, new PropertyValue(test_url));
            imageView[3] = new ImageView();
            imageView[3].Size2D = new Size2D(500 * resol, 500 * resol);
            imageView[3].Position2D = new Position2D(1100 * resol, 20 * resol);
            imageView[3].PivotPoint = PivotPoint.TopLeft;
            imageView[3].ParentOrigin = ParentOrigin.TopLeft;
            imageView[3].Image = map3;
            imageView[3].BackgroundColor = Color.Black;
            //            ConnectSignal(imageView[3]);



            window.Add(imageView[1]);
            window.Add(imageView[2]);
            window.Add(imageView[3]);
        }

        static void _Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
