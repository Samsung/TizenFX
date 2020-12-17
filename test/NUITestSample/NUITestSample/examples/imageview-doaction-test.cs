
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace ImageViewDoActionTest
{
    class Example : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Initialize();
            DoActionTest();
        }

        private static string resourcePath = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
        private Window window;
        private Layer defaultLayer;
        public void Initialize()
        {
            Tizen.Log.Error("NUI", "Initialize() START!");
            window = Window.Instance;
            window.BackgroundColor = Color.Green;
            window.TouchEvent += OnWindowTouched;
            window.WheelEvent += OnWindowWheelMoved;
            window.KeyEvent += OnWindowKeyPressed;

            defaultLayer = window.GetDefaultLayer();

            Tizen.Log.Error("NUI", "Initialize() END!");

        }

        ImageView imageView1, imageView2;
        public void DoActionTest()
        {
            string myUrl = resourcePath + "/images/gallery-0.jpg";

            imageView1 = new ImageView();
            imageView1.ResourceUrl = myUrl;
            imageView1.Position2D = new Position2D(100, 100);
            imageView1.Size2D = new Size2D(200, 200);
            defaultLayer.Add(imageView1);

            imageView2 = new ImageView();
            imageView2.ResourceUrl = myUrl;
            imageView2.Position2D = new Position2D(500, 100);
            imageView2.Size2D = new Size2D(400, 400);
            defaultLayer.Add(imageView2);
        }

        public void OnWindowKeyPressed(object sender, Window.KeyEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnWindowKeyPressed()! keyPressedName={e.Key.KeyPressedName} state={e.Key.State}");

            if(e.Key.State == Key.StateType.Down)
            {
                if(e.Key.KeyPressedName == "Up")
                {
                    PropertyMap attributes = new PropertyMap();
                    imageView1.Reload();
                }
                else if (e.Key.KeyPressedName == "Down")
                {

                }
            }
        }

        public void OnWindowWheelMoved(object sender, Window.WheelEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnWindowWheelMoved()! direction={e.Wheel.Direction} type={e.Wheel.Type}");
        }

        public void OnWindowTouched(object sender, Window.TouchEventArgs e)
        {
            Tizen.Log.Error("NUI", $"OnWindowTouched()! e.TouchData.GetState(0)={e.Touch.GetState(0)}");
        }

        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
