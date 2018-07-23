using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
//using System.ComponentModel;

namespace Tizen.NUI.Examples
{
    
    // class MyAppViewModel : INotifyPropertyChanged
    // {

    //     public event PropertyChangedEventHandler PropertyChanged;
    //     private Command _firstClick;
    //     private int count = 0;
        
    //     private string[] colors = new string[] {"Black", "Blue", "Gray", "Green", "Purple", "Pink", "Red" };
    //     public string TextColor = "Red";
    //     public Command ChangeColor {
    //         get {
    //             return _firstClick ?? (_firstClick = new Command (() => {
    //                 Console.WriteLine ("First button clicked");
    //                 count += 1;
    //                 TextColor = colors[count % 7];
    //             }));
    //         }
    //     }
    
    //     public MyAppViewModel()
    //     {
    //     }

    // }


    public class TestButton : NUIApplication
    {

        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            ButtonTestPage myPage = new ButtonTestPage(window);

            Extensions.LoadFromXaml(myPage, typeof(ButtonTestPage));

            Console.WriteLine("==================  Set BindingContext in Application !!!! ==================");
            myPage.SetFocus();
        }

        public static void _Main(string[] args)
        {
            TestButton p = new TestButton();
            p.Run(args);
        }
    }
}
