using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using Tizen;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    class Program : NUIApplication
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            SystemSettingsTests.TestAllAsync();

            //Initialize();
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
            TextLabel text = new TextLabel("SystemSettings Unit Test");
            //text.HorizontalAlignment = HorizontalAlignment.Center;
            //text.VerticalAlignment = VerticalAlignment.Center;
            //text.TextColor = Color.Blue;
            //text.PointSize = 12.0f;
            //text.HeightResizePolicy = ResizePolicyType.FillToParent;
            //text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Instance.GetDefaultLayer().Add(text);

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
