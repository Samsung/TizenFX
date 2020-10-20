using System;
using Tizen.Applications;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace FrameComponentDll
{

    public class MyFrameComponent3 : NUIFrameComponent
    {
        private TextLabel text;

        public override bool OnCreate()
        {
            Tizen.Log.Error("MYLOG", "MyFrameComponent OnCreate");

            Window.BackgroundColor = Color.Yellow;
            text = new TextLabel("dll Frame");
            text.HorizontalAlignment = HorizontalAlignment.Center;
            text.VerticalAlignment = VerticalAlignment.Bottom;
            text.TextColor = Color.Red;
            text.PointSize = 30.0f;
            text.HeightResizePolicy = ResizePolicyType.FillToParent;
            text.WidthResizePolicy = ResizePolicyType.FillToParent;
            Window.Add(text);
            return true;
        }


        public override void OnDestroy()
        {
            Tizen.Log.Error("MYLOG", "MyFrameComponent OnDestroy");
            text.Dispose();
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

        static void Main(string[] args)
        {
        }
    }
}
