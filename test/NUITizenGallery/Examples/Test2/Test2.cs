using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class Test2 : IExample
    {
        Window window;
        Test2Page page;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new Test2Page();

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
