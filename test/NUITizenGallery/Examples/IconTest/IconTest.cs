using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class IconTest : IExample
    {
        private Window window;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new IconTestPage());

        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
