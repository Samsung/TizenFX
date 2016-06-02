using Tizen.Applications;

namespace TestFramework
{
    public class MyApplication : UIApplication
    {
        protected override void OnCreate()
        {
            Assert.Init();
            TestManager manager = new TestManager();
            manager.RunTestFromTCList();
        }

        protected override void OnResume()
        {
            LogUtils.write(LogUtils.DEBUG, LogUtils.INFO, "Resumed!");
        }

        protected override void OnPause()
        {
            LogUtils.write(LogUtils.DEBUG, LogUtils.INFO, "Paused!");
        }

        protected override void OnTerminate()
        {
            LogUtils.write(LogUtils.DEBUG, LogUtils.INFO, "Terminated!");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyApplication app = new MyApplication();
            app.Run(args);
        }
    }
}
