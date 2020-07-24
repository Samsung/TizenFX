using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace SystemSettingsUnitTest
{
    class Program : NUIApplication
    {
        static public Progress testProgress;
        static public TextLabel text;
        protected override void OnCreate()
        {
            base.OnCreate();
            DisplayString();
            SystemSettingsTests.TestAllAsync();
            
        }

        public static void PrintOkFuncName(String str_in)
        {
            String func_name = str_in.ToString();
            String[] parse_func = func_name.Split(' ');
            Console.WriteLine(parse_func[1] + " >>>>>> ok");

        }

        public void DisplayString()
        {
            Window.Instance.KeyEvent += OnKeyEvent;

            testProgress = new Progress();
            testProgress.MaxValue = 100;
            testProgress.MinValue = 0;
            testProgress.CurrentValue = 0;
            testProgress.TrackColor = Color.Black;
            testProgress.ProgressColor = Color.Green; 
            testProgress.Position2D = new Position2D(30, 100);
            testProgress.Size2D = new Size2D(300, 5);

            text = new TextLabel("SystemSettings Unit Test");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Center;
            text.TextColor = Color.Blue;
            text.PointSize = 12.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);
            Window.Instance.GetDefaultLayer().Add(testProgress);

        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Down && (e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "Escape"))
            {
                Exit();
            }
        }

        static void Main(string[] args)
        {

            var app = new Program();
            app.Run(args);

        }
    }
}
