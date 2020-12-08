using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace NUIMusicPlayer
{
    public partial class XamlPage : View
    {
        public XamlPage()
        {
            InitializeComponent();

            HideInitObject();
        }

        private bool OnBackTouchEvent(object source, View.TouchEventArgs e)
        {
            if (e.Touch.GetState(0) == PointStateType.Up)
            {
                Window.Instance.Hide();
            }
            return false;
        }

        public void ShowInitObject()
        {
            profileContainer.Opacity = 1.0f;
            addContainer.Opacity = 1.0f;
            profileText1.Opacity = 1.0f;
            profileText2.Opacity = 1.0f;
            cinematicText.Show();
        }

        public void HideInitObject()
        {
            profileContainer.Opacity = 0.0f;
            addContainer.Opacity = 0.0f;
            profileText1.Opacity = 0.0f;
            profileText2.Opacity = 0.0f;
            cinematicText.Hide();
        }
    }
}
