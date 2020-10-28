using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace ImageViewOrientationCorrectionTest
{
    class Test : NUIApplication
    {
        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        static string testUrl0 = resourcePath + "/images/test-image0.png";
        static string testUrl1 = resourcePath + "/images/test-image1.png";
        static string testUrl3 = resourcePath + "/images/test-image2.jpg";
        static string testUrl4 = resourcePath + "/images/test-image3.jpg";

        string TAG = "NUI";

        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
        }

        TextField[] textField = new TextField[5];
        ImageView[] imageView = new ImageView[5];
        int resol = 1;
        int iPointSize = 20;

        void Initialize()
        {
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;
            Vector2 dpi = new Vector2();
            dpi = window.Dpi;
            Tizen.Log.Fatal(TAG, $"Window.Dpi X={dpi.X}, Y={dpi.Y}");

            textField[0] = new TextField();
            textField[0].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[0].Position2D = new Position2D(10 * resol, 600 * resol);
            textField[0].PivotPoint = PivotPoint.TopLeft;
            textField[0].BackgroundColor = Color.White;
            textField[0].PointSize = iPointSize * resol;
            textField[0].Text = "png file, orientation correct=false";
            textField[0].TextColor = Color.Red;

            textField[1] = new TextField();
            textField[1].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[1].Position2D = new Position2D(400 * resol, 600 * resol);
            textField[1].PivotPoint = PivotPoint.TopLeft;
            textField[1].BackgroundColor = Color.White;
            textField[1].PointSize = iPointSize * resol;
            textField[1].Text = "png file, orientation correct=true";
            textField[1].TextColor = Color.Red;

            textField[2] = new TextField();
            textField[2].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[2].Position2D = new Position2D(750 * resol, 600 * resol);
            textField[2].PivotPoint = PivotPoint.TopLeft;
            textField[2].BackgroundColor = Color.White;
            textField[2].PointSize = iPointSize * resol;
            textField[2].Text = "jpg file, orientation correct=false";
            textField[2].TextColor = Color.Red;

            textField[3] = new TextField();
            textField[3].Size2D = new Size2D(350 * resol, 64 * resol);
            textField[3].Position2D = new Position2D(1100 * resol, 600 * resol);
            textField[3].PivotPoint = PivotPoint.TopLeft;
            textField[3].BackgroundColor = Color.White;
            textField[3].PointSize = iPointSize * resol;
            textField[3].Text = "jpg file, orientation correct=true";
            textField[3].TextColor = Color.Red;

            window.Add(textField[0]);
            window.Add(textField[1]);
            window.Add(textField[2]);
            window.Add(textField[3]);

            //Tizen.Log.Fatal(TAG, $"imageView[0].ResourceUrl={imageView[0].ResourceUrl}");

            imageView[0] = new ImageView();
            imageView[0].ResourceUrl = testUrl0;
            imageView[0].OrientationCorrection = false;
            imageView[0].Size2D = new Size2D(300 * resol, 400 * resol);
            imageView[0].Position2D = new Position2D(10 * resol, 20 * resol);
            imageView[0].PivotPoint = PivotPoint.TopLeft;
            imageView[0].ParentOrigin = ParentOrigin.TopLeft;
            imageView[0].BackgroundColor = Color.Black;
            window.Add(imageView[0]);

            imageView[1] = new ImageView();
            imageView[1].ResourceUrl = testUrl1;
            imageView[1].OrientationCorrection = true;
            imageView[1].Size2D = new Size2D(300 * resol, 400 * resol);
            imageView[1].Position2D = new Position2D(400 * resol, 20 * resol);
            imageView[1].PivotPoint = PivotPoint.TopLeft;
            imageView[1].ParentOrigin = ParentOrigin.TopLeft;
            imageView[1].BackgroundColor = Color.Black;
            window.Add(imageView[1]);

            imageView[2] = new ImageView();
            imageView[2].ResourceUrl = testUrl3;
            imageView[2].OrientationCorrection = false;
            imageView[2].Size2D = new Size2D(300 * resol, 400 * resol);
            imageView[2].Position2D = new Position2D(750 * resol, 20 * resol);
            imageView[2].PivotPoint = PivotPoint.TopLeft;
            imageView[2].ParentOrigin = ParentOrigin.TopLeft;
            imageView[2].BackgroundColor = Color.Black;
            window.Add(imageView[2]);

            imageView[3] = new ImageView();
            imageView[3].ResourceUrl = testUrl4;
            imageView[3].OrientationCorrection = true;
            imageView[3].Size2D = new Size2D(300 * resol, 400 * resol);
            imageView[3].Position2D = new Position2D(1100 * resol, 20 * resol);
            imageView[3].PivotPoint = PivotPoint.TopLeft;
            imageView[3].ParentOrigin = ParentOrigin.TopLeft;
            imageView[3].BackgroundColor = Color.Black;
            window.Add(imageView[3]);
        }
    }
}
