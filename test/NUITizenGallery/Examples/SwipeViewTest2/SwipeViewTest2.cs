using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class SwipeViewTest2 : IExample
    {
        private Window window;
        private SwipeViewTest2Page page;
        public void Activate()
        {
            Console.WriteLine($"@@@ this.GetType().Name={this.GetType().Name}, Activate()");

            window = NUIApplication.GetDefaultWindow();
            page = new SwipeViewTest2Page();
            page.PositionUsesPivotPoint = true;
            page.ParentOrigin = ParentOrigin.Center;
            page.PivotPoint = PivotPoint.Center;
            page.HeightResizePolicy = ResizePolicyType.FillToParent;
            page.WidthResizePolicy = ResizePolicyType.FillToParent;
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
