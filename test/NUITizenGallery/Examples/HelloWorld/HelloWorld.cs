using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class HelloWorld : IExample
    {
        private Window window;
        private HelloWorldPage page;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new HelloWorldPage();

            window.Add(page);
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            page.Unparent();
            page.Dispose();
        }
    }
}
