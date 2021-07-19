using System;
using Tizen.NUI;

namespace NUITizenGallery
{
    internal class WebViewTest2 : IExample
    {
        private Window window;
        private WebViewTest2Page page;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            page = new WebViewTest2Page();

            window.Add(page);
        }
        public void Deactivate()
        {
            page.Unparent();
            page.Dispose();
        }
    }
}

