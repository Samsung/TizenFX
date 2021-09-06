using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ButtonTest6Page : ContentPage
    {
        private TapGestureDetector mTapDetector;
        public ButtonTest6Page()
        {
            InitializeComponent();

            mTapDetector = new TapGestureDetector();
            mTapDetector.Attach(redText);
            mTapDetector.Attach(greenText);
            mTapDetector.Attach(grayText);

            mTapDetector.Detected += (obj, e) =>
            {
                View view = e.View;
                if (view != null)
                {
                    button1.BackgroundColor = view.BackgroundColor;
                }
            };
        }
    }
}