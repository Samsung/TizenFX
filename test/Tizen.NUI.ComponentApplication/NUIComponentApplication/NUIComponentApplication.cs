using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIComponentApplicationSample
{
    public class Program : NUIComponentApplication
    {
        public static MyFrameComponent myFrame1 = null;
        public static MyFrameComponent2 myFrame2 = null;

        public Program(IDictionary<Type, string> typeInfo) : base(typeInfo)
        {
        }

        public class MyFrameComponent : NUIFrameComponent
        {
            private TextLabel text;
            private Animation animation;

            public override bool OnCreate()
            {
                myFrame1 = this;
                Tizen.Log.Error("MYLOG", "MyFrameComponent OnCreate");

                Window.BackgroundColor = Color.White;
                text = new TextLabel("First Frame");
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Bottom;
                text.TextColor = Color.Blue;
                text.PointSize = 12.0f;
                text.HeightResizePolicy = ResizePolicyType.FillToParent;
                text.WidthResizePolicy = ResizePolicyType.FillToParent;
                Window.Add(text);

                animation = new Animation(2000);
                animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
                animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
                animation.Looping = true;
                animation.Play();
                return true;
            }

            
            public override void OnDestroy()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent OnDestroy");
                text.Dispose();
                animation.Dispose();
            }

            public override void OnPause()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent OnPause");
            }

            public override void OnResume()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent OnResume");
            }

            public override void OnStart(AppControl appControl, bool restarted)
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent OnStart");
            }

            public override void OnStop()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent OnStop");
            }

            public void ChangeSharedText(string strText)
            {
                text.Text = strText;
            }

        }
        public class MyFrameComponent2 : NUIFrameComponent
        {
            private TextLabel text;
            private Animation animation;

            public override bool OnCreate()
            {
                myFrame2 = this;
                Tizen.Log.Error("MYLOG", "MyFrameComponent2 OnCreate");
                Window.BackgroundColor = Color.Red;
                Window.WindowSize = new Size(360, 180);
                Window.Instance.TouchEvent += Instance_TouchEvent;
                text = new TextLabel("Second Frame");
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.TextColor = Color.Blue;
                text.PointSize = 12.0f;
                text.HeightResizePolicy = ResizePolicyType.FillToParent;
                text.WidthResizePolicy = ResizePolicyType.FillToParent;
                Window.Add(text);
                return true;
            }

            private void Instance_TouchEvent(object sender, Window.TouchEventArgs e)
            {
                if(e.Touch.GetState(0) == PointStateType.Up)
                {
                    myFrame1?.ChangeSharedText("Change - text");
                }
            }

            public override void OnDestroy()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent2 OnDestroy");
                text.Dispose();
                animation.Dispose();
            }

            public override void OnPause()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent2 OnPause");
            }

            public override void OnResume()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent2 OnResume");
            }

            public override void OnStart(AppControl appControl, bool restarted)
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent2 OnStart");
            }

            public override void OnStop()
            {
                Tizen.Log.Error("MYLOG", "MyFrameComponent2 OnStop");
            }
        }

        static private Type LoadFrameComponentDll()
        {
            string path = @"/opt/usr/FrameComponentDll.dll";
            FileInfo fi = new FileInfo(path);
            if (fi.Exists)
            {
                Assembly assembly = Assembly.LoadFile(path);
                if (assembly != null)
                {
                    Module[] modules = assembly.GetModules();
                    Type frameComponent3 = modules[0].GetType("FrameComponentDll.MyFrameComponent3");
                    return frameComponent3;
                }
            }
            return null;
        }

        static void Main(string[] args)
        {

            Dictionary<Type, string> dict = new Dictionary<Type, string>();
            dict.Add(typeof(MyFrameComponent), "csharp_frame");
            dict.Add(typeof(MyFrameComponent2), "csharp_frame2");

            Type type = LoadFrameComponentDll();
            if (type != null)
            {
                Tizen.Log.Error("MYLOG", "Add type : " + type);
                dict.Add(type, "csharp_frame3");
            }


            var app = new Program(dict);
            app.Run(args);
            app.Dispose();
        }
    }
}
