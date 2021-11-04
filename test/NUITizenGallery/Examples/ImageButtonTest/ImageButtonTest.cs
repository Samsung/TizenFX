using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class ImageButtonTest : IExample
    {
        private Window window;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new ImageButtonTestPage());
        }

        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
