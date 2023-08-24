using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Examples
{
    class VideoViewTest : NUIApplication
    {

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TempPage myPage = new TempPage(window);
            Extensions.LoadFromXaml(myPage, typeof(TempPage));
            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            TempTest p = new TempTest();
            p.Run(args);
        }
    }
}
