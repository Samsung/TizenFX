using System;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.Examples
{
    public class TestMyContents : NUIApplication
    {
        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.Transparent;

            MediaHubPage myPage = new MediaHubPage(window);

            Extensions.LoadFromXaml(myPage, typeof(MediaHubPage));

            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");

            // FocusManager.Instance.PreFocusChange += OnPreFocusChange;
            myPage.SetFocus();

            window.KeyEvent += (obj, e) => {
                if (e.Key.State == Key.StateType.Down)
                {
                    if (e.Key.KeyPressedName == "1")
                    {
                        if ( !myPage.IsEmpty )
                        {
                            myPage.ClearContent();
                        }
                    }
                    if (e.Key.KeyPressedName == "2")
                    {
                        if ( myPage.IsEmpty )
                        {
                            Extensions.LoadFromXaml(myPage, typeof(MediaHubPage));
                            myPage.SetFocus();
                        }
                    }
                }
            };
        }

        public static void _Main(string[] args)
        {
            TestMyContents p = new TestMyContents();
            p.Run(args);
        }
    }
}
