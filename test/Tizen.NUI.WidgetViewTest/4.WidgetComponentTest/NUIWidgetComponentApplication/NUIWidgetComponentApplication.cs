using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIWidgetComponentApplicationSample
{
    public class Program : NUIComponentApplication
    {
        public static MyWidgetComponent myWidget = null;

        public Program(IDictionary<Type, string> typeInfo) : base(typeInfo)
        {
        }

        public class MyWidgetComponent : NUIWidgetComponent
        {
            private TextLabel text;
            private Animation animation;

            public override bool OnCreate(int width, int height)
            {
                myWidget = this;
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnCreate .. START ,size:" + width +"x"+height);
                Window.BackgroundColor = Color.Yellow;
                Window.WindowSize = new Size(width, height);
                text = new TextLabel("Widget Component");
                text.HorizontalAlignment = HorizontalAlignment.Center;
                text.VerticalAlignment = VerticalAlignment.Center;
                text.TextColor = Color.Black;
                text.PointSize = 20.0f;
                text.HeightResizePolicy = ResizePolicyType.FillToParent;
                text.WidthResizePolicy = ResizePolicyType.FillToParent;
                Window.Add(text);
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnCreate.. DONE");

                animation = new Animation(3000);
                animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(180.0f)), PositionAxis.X), 0, 500);
                animation.AnimateTo(text, "Orientation", new Rotation(new Radian(new Degree(0.0f)), PositionAxis.X), 500, 1000);
                animation.Looping = true;
                animation.Play();
                return true;
            }

            public override void OnDestroy(bool permanent)
            {
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnDestroy");
                text.Dispose();
                animation.Dispose();
            }

            public override void OnPause()
            {
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnPause");
            }

            public override void OnResume()
            {
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnResume");
            }

            public override void OnStart(bool restarted)
            {
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnStart");
            }

            public override void OnStop()
            {
                Tizen.Log.Error("MYLOG", "MyWidgetComponent OnStop");
            }
        }

        static void Main(string[] args)
        {
            Dictionary<Type, string> dict = new Dictionary<Type, string>();
            dict.Add(typeof(MyWidgetComponent), "csharp_widget");
            var app = new Program(dict);
            app.Run(args);
            app.Dispose();
        }
    }
}
