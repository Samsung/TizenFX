using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class DaliDemo : NUIApplication
    {
        public DaliDemo(string styleSheet) : base(styleSheet)
        {
        }

        public DaliDemo(Size2D winSize, Position2D winPos, bool border) : base("", WindowMode.Transparent, winSize, winPos, border)
        {
        }

        private IExample curExample = null;

        private void FullGC()
        {
            global::System.GC.Collect();
            global::System.GC.WaitForPendingFinalizers();
            global::System.GC.Collect();
        }

        private void DeleteDaliDemo()
        {
            NUIApplication.GetDefaultWindow().Remove(demo.mRootActor);
            demo.mRootActor.Dispose();
            demo = null;

            FullGC();
        }

        private void CreateDaliDemo()
        {
            demo = new DaliTableView((string name) =>
            {
                string fileName = global::System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

                //global::System.Diagnostics.Process.Start(fileName, name);

                RunSample(name);
            });

            Assembly assembly = this.GetType().Assembly;

            Type exampleType = assembly.GetType("Tizen.NUI.Samples.IExample");

            foreach (Type type in assembly.GetTypes())
            {
                if (exampleType.IsAssignableFrom(type) && type.Name != "SampleMain" && this.GetType() != type && true == type.IsClass)
                {
                    demo.AddExample(new Example(type.FullName, type.Name));
                }
            }

            demo.SortAlphabetically(true);

            demo.Initialize();

            NUIApplication.GetDefaultWindow().GetDefaultLayer().Add(demo.mRootActor);
        }

        private void RunSample(string name)
        {
            Assembly assembly = typeof(DaliDemo).Assembly;

            Type exampleType = assembly?.GetType(name);
            IExample example = assembly?.CreateInstance(name) as IExample;

            if (null != example)
            {
                DeleteDaliDemo();
                int exceptNum = 0;
                string exceptionMessage = "Unknown!";
                try
                {
                    example.Activate();
                }
                catch (Exception e)
                {
                    if (e is global::System.EntryPointNotFoundException)
                    {
                        Tizen.Log.Fatal("NUI", $"@@ ERROR! No dali-csharp-binding! Exception={e.Message} \n");
                        exceptNum = 1;
                        exceptionMessage = e.Message;
                    }
                    else if (e is global::System.ArgumentException)
                    {
                        Tizen.Log.Fatal("NUI", $"@@ ERROR! this comes when VideoView test on Ubuntu! Exception={e.Message} \n");
                        exceptNum = 2;
                        exceptionMessage = e.Message;
                    }
                }
                switch (exceptNum)
                {
                    case 0:
                    default:
                        break;
                    case 1:
                    case 2:
                        example.Deactivate();
                        var errorPage = assembly?.CreateInstance("Tizen.NUI.Samples.ShowErrorPage") as ShowErrorPage;
                        errorPage.Activate();
                        errorPage.ShowExcpetionText(exceptionMessage);
                        example = errorPage;
                        break;
                }
                curExample = example;
            }
        }

        private void ExitSample()
        {
            curExample?.Deactivate();
            curExample = null;

            FullGC();

            CreateDaliDemo();
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            StyleManager.Get().ApplyTheme(Tizen.Applications.Application.Current.DirectoryInfo.Resource + "style/demo-theme.json");
            CreateDaliDemo();

            NUIApplication.GetDefaultWindow().KeyEvent += Instance_KeyEvent;
            NUIApplication.GetDefaultWindow().BackgroundColor = Color.White;
        }

        private void Instance_KeyEvent(object sender, Window.KeyEventArgs e)
        {
            if (e.Key.State == Key.StateType.Up)
            {
                if (e.Key.KeyPressedName == "Escape" || e.Key.KeyPressedName == "XF86Back" || e.Key.KeyPressedName == "BackSpace")
                {
                    if (null != curExample)
                    {
                        ExitSample();
                    }
                    else
                    {
                        Exit();
                    }
                }
            }
        }

        public void Deactivate()
        {
            demo = null;
        }

        private DaliTableView demo;
    }
}
