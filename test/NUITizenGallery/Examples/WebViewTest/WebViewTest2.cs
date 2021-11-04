using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class WebViewTest2 : IExample
    {
        private Window window;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new WebViewTest2Page());
        }
        public void Deactivate()
        {
            window.GetDefaultNavigator().Pop();
        }
    }
}

