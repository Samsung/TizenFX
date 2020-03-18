using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using System.ComponentModel;

namespace Tizen.NUI.Examples
{
    public class GetPageTest : NUIApplication
    {
        public class MyContentPage1 : ContentPage
        {
            public MyContentPage1(Window win) : base(win) { }
        }
        public class MyContentPage2 : ContentPage
        {
            public MyContentPage2(Window win) : base(win) { }
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            MyContentPage1 myContentPage1 = new MyContentPage1(window);
            MyContentPage2 myContentPage2 = new MyContentPage2(window);
            Page page1 = window.GetPage(myContentPage1.GetType());
            Page page2 = window.GetPage(myContentPage2.GetType());
            if (page1 == myContentPage1)
            {
                Tizen.Log.Fatal("NUITest", "page1 == myContentPage1");
            }
            if (page2 == myContentPage2)
            {
                Tizen.Log.Fatal("NUITest", "page2 == myContentPage2");
            }
        }
    }
}
