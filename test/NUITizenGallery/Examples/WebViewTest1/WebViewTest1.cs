using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class WebViewTest1 : IExample
    {
        private Window window;
        private WebViewTest1Page page;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            page = new WebViewTest1Page();

            window.Add(page);
        }
        public void Deactivate()
        {
            page.Unparent();
            page.Dispose();
        }
    }
}

