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

            var myContentPage1 = new MyContentPage1(window);
            var myContentPage2 = new MyContentPage2(window);
            var pages1 = window.GetPage(myContentPage1.GetType());
            var pages2 = window.GetPage(myContentPage2.GetType());
            if (pages1[0] == myContentPage1)
            {
                Tizen.Log.Fatal("NUITest", "pages1[0] == myContentPage1");
            }
            if (pages2[0] == myContentPage2)
            {
                Tizen.Log.Fatal("NUITest", "pages2[0] == myContentPage2");
            }

            window.RemovePage(pages1[0]);
            var pages = window.GetAllPages();
            int i3 = pages.Count;
            if(pages[0] == myContentPage2)
            {
                Tizen.Log.Fatal("NUITest", "pages[0] == myContentPage2");
            }
            window.RemovePage(myContentPage2);
            pages = window.GetAllPages();
            int i4 = pages.Count;
            Tizen.Log.Fatal("NUITest", "i4 should be 0");

            var page3 = new ContentPage(window);
            var page4 = new ContentPage(window);
            var pages5 = window.GetPage(page3.GetType());
            int i5 = pages5.Count;
            if (pages5[0] == page3)
            {
                Tizen.Log.Fatal("NUITest", "pages5[0] == page3");
            }
            if (pages5[1] == page4)
            {
                Tizen.Log.Fatal("NUITest", "pages5[1] == page4");
            }
            if (pages5[0] == page4)
            {
                Tizen.Log.Fatal("NUITest", "pages5[0] shouldn't be page4");
            }
            if (pages5[1] == page3)
            {
                Tizen.Log.Fatal("NUITest", "pages5[1] shouldn't be page3");
            }
            window.RemovePage(page3);
            pages5 = window.GetPage(page3.GetType());
            int i6 = pages5.Count;
            if (pages5[0] == page3)
            {
                Tizen.Log.Fatal("NUITest", "pages5[0] shouldn't be page3");
            }
            if (pages5[0] == page4)
            {
                Tizen.Log.Fatal("NUITest", "pages5[0] == page4");
            }
        }
    }
}
