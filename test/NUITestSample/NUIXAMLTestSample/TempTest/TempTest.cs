using System;
using System.IO;
using System.Reflection;

using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;
using Tizen.NUI;
using Tizen.NUI.UIComponents;
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

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
    class MyAppViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;
        private Command _firstClick;
        private int clickCounter = 0;
        public string message;

        //static readonly BindableProperty MessageProperty = BindableProperty.Create<MyAppViewModel, string> ((MyAppViewModel v) => v.Message, "- - - - - Message - - -");
        public string Message
        {
            set
            {                
                Console.WriteLine ("Message : {0}, {1}",message,value);
                if (message != value)
                {
                    message = value;

                    Console.WriteLine ("Message111 : {0}",message);

                    if (PropertyChanged != null)
                    {
                        Console.WriteLine ("Message222 : {0}",message);
                        PropertyChanged(this, 
                            new PropertyChangedEventArgs("Message"));
                    }
                }
            }
            get
            {
                return message;
            }
        }

        public Command ShowClickCount {
            get {
                return _firstClick ?? (_firstClick = new Command (() => {
                    Console.WriteLine ("First button clicked");
                    clickCounter += 1;
                    Message = "Clicked " + clickCounter.ToString() + " times";
                }));
            }
        }    

        public MyAppViewModel()
        {
            this.message = String.Format("------test-----");
            this.Message = String.Format("------test111-----");;
        }
    }


    public class TempTest : NUIApplication
    {

        protected override void OnCreate() 
        {
            base.OnCreate();
            Window window = Window.Instance;
            window.BackgroundColor = Color.White;

            TempPage myPage = new TempPage(window);
            // myPage.InitializeComponents(myPage, typeof(TempPage));
            Extensions.LoadFromXaml(myPage, typeof(TempPage));
            // myPage.BindingContext = new MyAppViewModel ();
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
