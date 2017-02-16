using System;


namespace FirstScreen
{
    public class MainClass
    {
        [STAThread]
        static void Main(string[] args)
        {
            Tizen.Log.Debug("NUI", "Main() is called! ");
            FirstScreenApp.Run();
        }
    }
}
