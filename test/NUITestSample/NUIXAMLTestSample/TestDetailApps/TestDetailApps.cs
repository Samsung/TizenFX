using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Examples
{
    public class TestDetailApps : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            AppDetailPage detailPage = new AppDetailPage(window);

            Extensions.LoadFromXaml(detailPage, typeof(AppDetailPage));
            detailPage.SetFocus();

            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
        }

        public static void _Main(string[] args)
        {
            TestDetailApps p = new TestDetailApps();
            p.Run(args);
        }
    }
}
