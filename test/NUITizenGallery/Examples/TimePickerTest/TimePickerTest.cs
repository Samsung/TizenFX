using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class TimePickerTest : IExample
    {
        private Window window;
        private TimePickerTestPage page;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new TimePickerTestPage();

            window.GetDefaultNavigator().Push(page);
        }
        public void Deactivate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Deactivate()");
            window.GetDefaultNavigator().Pop();
            page = null;
        }
    }
}
