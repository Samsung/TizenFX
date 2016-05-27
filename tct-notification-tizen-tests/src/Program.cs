using System;
using System.Threading.Tasks;
using Tizen.Applications;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using TestFramework;

namespace TestFramework {
    public class App : Xamarin.Forms.Application
    {
        public App()
        {
             MainPage = new NavigationPage(new TestMainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

    public class MyApp : FormsApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Forms.Init(this);
            LoadApplication(new App());
        }
    }

    class Program {
        static void Main(string[] args) {
            MyApp myApp = new MyApp();
            myApp.Run(args);
        }
    }
}
