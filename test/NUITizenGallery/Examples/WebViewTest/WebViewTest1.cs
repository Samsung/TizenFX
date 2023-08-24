using System;
using Tizen.NUI;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    internal class WebViewTest1 : IExample
    {
        private Window window;
        public void Activate()
        {
            window = NUIApplication.GetDefaultWindow();
            window.GetDefaultNavigator().Push(new WebViewTest1Page());
        }
        public void Deactivate()
        {
            window.GetDefaultNavigator().Pop();
        }
    }
}

