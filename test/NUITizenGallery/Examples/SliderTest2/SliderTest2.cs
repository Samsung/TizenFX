using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class SliderTest2 : IExample
    {
        private Window window;
        private SliderTest2Page page;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new SliderTest2Page();
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.Center;
            page.PivotPoint = PivotPoint.Center;
            page.HeightResizePolicy = ResizePolicyType.FillToParent;
            page.WidthResizePolicy = ResizePolicyType.FillToParent;
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
