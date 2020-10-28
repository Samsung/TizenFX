using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using mypath = Tizen.Applications.Application.Current;

namespace mytest
{
    public class myTestApp : NUIApplication
    {
        public myTestApp() : base()
        {
        }
        public myTestApp(string styleSheet) : base(styleSheet)
        {
        }

        Window win;
        protected override void OnCreate()
        {
            base.OnCreate();
            win = Window.Instance;
            win.BackgroundColor = Color.Cyan;
            View v1 = new View();
            v1.Size2D = new Size2D(100, 100);
            v1.BackgroundColor = Color.Blue;
            win.GetDefaultLayer().Add(v1);

            ImageView iv = new ImageView();
            iv.ResourceUrl = mypath.DirectoryInfo.Resource + @"/images/Dali/DaliDemo/Logo-for-demo.png";
            iv.Position2D = new Position2D(50, 200);
            win.GetDefaultLayer().Add(iv);

            Size2D imageSize = ImageLoading.GetOriginalImageSize(iv.ResourceUrl);
            TextLabel tl = new TextLabel();
            tl.Position2D = new Position2D(iv.Position2D.X, iv.Position2D.Y + imageSize.Height);
            tl.MultiLine = true;
            tl.Text = $"ResourceUrl: {iv.ResourceUrl} \nOriginalImageSize: W({imageSize.Width}), H({imageSize.Height})";
            win.GetDefaultLayer().Add(tl);

            //==================
            iv = new ImageView();
            iv.ResourceUrl = mypath.DirectoryInfo.Resource + @"/images/Dali/DaliDemo/demo-tile-texture.9.png";
            iv.Position2D = new Position2D(50, 600);
            win.GetDefaultLayer().Add(iv);

            imageSize = ImageLoading.GetOriginalImageSize(iv.ResourceUrl);
            tl = new TextLabel();
            tl.Position2D = new Position2D(iv.Position2D.X, iv.Position2D.Y + imageSize.Height);
            tl.MultiLine = true;
            tl.Text = $"ResourceUrl: {iv.ResourceUrl} \nOriginalImageSize: W({imageSize.Width}), H({imageSize.Height})";
            win.GetDefaultLayer().Add(tl);
        }

        //[STAThread]
        //static void Main(string[] args)
        //{
        //    new myTestApp().Run(args);
        //}
    }
}
