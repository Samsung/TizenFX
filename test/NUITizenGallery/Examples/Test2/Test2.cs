using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class Test2 : IExample
    {
        Window window;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new Test2Page());
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
        }
    }
}
