
using System;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace ImageViewResourceUrlSetNullTest
{
    class Example : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Activate();	
        }

        Window win;
        Timer timer1;
        View view1;
        TextLabel textlabel1;
        ImageView imageview1;
        string res;

        public void Activate()
        {
            Console.WriteLine("\n ##### _MyTestResourceUrlNull test!\n");

            win = Window.Instance;
            win.BackgroundColor = Color.Green;
            Vector2 dpi = win.Dpi;
            Console.WriteLine($"dpi x={dpi.X} y={dpi.Y} \n");
            win.TouchEvent += Win_TouchEvent;

            res = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
            Console.WriteLine($"res={res} \n");

            view1 = new View();
            view1.Size2D = new Size2D(1000, 1000);
            view1.Position2D = new Position2D(460, 40);
            view1.BackgroundColor = Color.Yellow;
            win.GetDefaultLayer().Add(view1);

            textlabel1 = new TextLabel();
            textlabel1.Size2D = new Size2D(1000, 200);
            textlabel1.Position2D = new Position2D(0, 0);
            textlabel1.Text = "ImageView ResourceUrl property NULL/empty string assigning Test \n click this window!";
            textlabel1.BackgroundColor = Color.Magenta;
            textlabel1.HorizontalAlignment = HorizontalAlignment.Center;
            textlabel1.VerticalAlignment = VerticalAlignment.Center;
            textlabel1.PointSize = dpi.X / 4;
            textlabel1.MultiLine = true;
            textlabel1.TextColor = Color.White;
            view1.Add(textlabel1);

            timer1 = new Timer(300);
            timer1.Tick += Timer1_Tick;
        }

        int teststate = 0;
        private bool Timer1_Tick(object source, Timer.TickEventArgs e)
        {
            switch (teststate)
            {
                case 0:
                    imageview1 = new ImageView();
                    imageview1.Size2D = new Size2D(300, 300);
                    imageview1.Position2D = new Position2D(350, 300);
                    view1.Add(imageview1);
                    textlabel1.Text = $"0. new ImageView but NOT set ResourceUrl! (Is ResourceUrl NULL? {(imageview1.ResourceUrl == null)}) " +
                        $"ResourceUrl=({imageview1.ResourceUrl})";
                    teststate = 1;
                    break;
                case 1:
                    imageview1.ResourceUrl = res + "images/gallery-0.jpg";
                    textlabel1.Text = $"1. set proper picture path into ResourceUrl! (should show the image!) " +
                        $"ResourceUrl=( {imageview1.ResourceUrl} )";
                    textlabel1.PointSize /= 2;
                    teststate = 2;
                    break;
                case 2:
                    imageview1.ResourceUrl = "";
                    textlabel1.Text = $"2. set empty string into ResourceUrl! (picture should be disappeared!) " +
                        $"ResourceUrl=( {imageview1.ResourceUrl} )";
                    textlabel1.PointSize *= 2;
                    teststate = 3;
                    break;
                case 3:
                    imageview1.ResourceUrl = res + "images/gallery-1.jpg";
                    textlabel1.Text = $"3. set proper path into ResourceUrl! (different picture should be shown!) " +
                        $"ResourceUrl=( {imageview1.ResourceUrl} )";
                    textlabel1.PointSize /= 2;
                    teststate = 4;
                    break;
                case 4:
                    imageview1.ResourceUrl = null;
                    textlabel1.Text = $"4. set NULL into ResourceUrl! (picture disappeared and ResourceUrl should NOT be NULL!) " +
                        $"(Is ResourceUrl NULL? { (imageview1.ResourceUrl == null)}) " + $"ResourceUrl=( {imageview1.ResourceUrl} )";
                    teststate = 5;
                    textlabel1.PointSize *= 2;
                    break;
                case 5:
                    view1.Remove(imageview1);
                    imageview1.Dispose();
                    imageview1 = null;
                    textlabel1.Text = $"5. dispose and make NULL for ImageView!";
                    teststate = 0;
                    break;

            }
            return false;
        }

        private void Win_TouchEvent(object sender, Window.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Down)
            {
                timer1.Start();
            }
        }

        public void Deactivate()
        {
            win.Remove(view1);
            view1.Dispose();
            view1 = null;
        }


        [STAThread]
        static void _Main(string[] args)
        {
            Example example = new Example();
            example.Run(args);
        }
    }
}
