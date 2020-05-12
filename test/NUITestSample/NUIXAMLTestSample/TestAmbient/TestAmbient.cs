using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Examples
{
    public class TestAmbient : NUIApplication
    {
        private ContentPage myPage;

        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = new Color(0.75f, 0.75f, 0.75f, 0.8f);

            myPage = new AmbientMonoPage(window);

            Extensions.LoadFromXaml(myPage, typeof(AmbientMonoPage));

            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();

            window.KeyEvent += (obj, e) => {
                if (e.Key.State == Key.StateType.Down)
                {
                    if (e.Key.KeyPressedName == "1")
                    {
                        Console.WriteLine("==================  1  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new AmbientMonoPage(window);
                        Extensions.LoadFromXaml(myPage, typeof(AmbientMonoPage));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "2")
                    {
                        Console.WriteLine("==================  2  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new AmbientDuoPage(window);
                        Extensions.LoadFromXaml(myPage, typeof(AmbientDuoPage));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "3")
                    {
                        Console.WriteLine("==================  3  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new AmbientMultiPage(window);
                        Extensions.LoadFromXaml(myPage, typeof(AmbientMultiPage));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "4")
                    {
                        Console.WriteLine("==================  4  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new AmbientMultiPage2(window);
                        Extensions.LoadFromXaml(myPage, typeof(AmbientMultiPage2));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "5")
                    {
                        Console.WriteLine("==================  5  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new AmbientMultiPage3(window);
                        Extensions.LoadFromXaml(myPage, typeof(AmbientMultiPage3));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "6")
                    {
                        Console.WriteLine("==================  6  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new BixbyWidgetPage(window);
                        Extensions.LoadFromXaml(myPage, typeof(BixbyWidgetPage));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "7")
                    {
                        Console.WriteLine("==================  7  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new BixbyFinancePage(window);
                        Extensions.LoadFromXaml(myPage, typeof(BixbyFinancePage));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "8")
                    {
                        Console.WriteLine("==================  8  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new SearchPage(window);
                        Extensions.LoadFromXaml(myPage, typeof(SearchPage));
                        myPage.SetFocus();
                    }
                    else if (e.Key.KeyPressedName == "9")
                    {
                        Console.WriteLine("==================  9  ==================");
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                            myPage.Dispose();
                            myPage = null;
                        }
                        myPage = new WeatherPage(window);
                        Extensions.LoadFromXaml(myPage, typeof(WeatherPage));
                        myPage.SetFocus();
                    }
                    else
                    {
                        Console.WriteLine("==================  Input Error !!!! ==================");
                    }
                }
            };
        }

        public static void _Main(string[] args)
        {
            TestAmbient p = new TestAmbient();
            p.Run(args);
        }
    }
}
