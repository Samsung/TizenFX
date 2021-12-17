using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using static Tizen.NUI.Window;

namespace Tizen.NUI.Samples
{
    public class WindowSample : IExample
    {

        Window subWindow;
        private int check = 0;
        public void Activate()
        {
            Window window = NUIApplication.GetDefaultWindow();
            window.WindowSize = new Size2D(500, 600);

             subWindow = new Window("subwin1", new Rectangle(300, 300, 300, 300), false);
             subWindow.BackgroundColor = Color.Blue;
             subWindow.KeyEvent += OnKeyEvent;

        }

        public void OnKeyEvent(object sender, Window.KeyEventArgs e)
        {
            {
                for(int i=0; i<100; i++) 
                {
                    subWindow.WindowSize += new Size2D(1, 1);
                }
            }
        }

        public void Deactivate()
        {
            
        }
    }
}
