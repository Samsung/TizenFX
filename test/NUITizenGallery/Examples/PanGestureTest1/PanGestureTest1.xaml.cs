using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class PanGestureTest1Page : ContentPage
    {
        private PanGestureDetector mPanDetector;
        public PanGestureTest1Page()
        {
            InitializeComponent();

            mPanDetector = new PanGestureDetector();
            mPanDetector.Attach(imageView);

            mPanDetector.Detected += (obj, e) =>
            {
                View view = e.View;
                if (view != null)
                {
                    view.Position += new Position(e.PanGesture.ScreenDisplacement.X, e.PanGesture.ScreenDisplacement.Y, 0);
                }
            };
        }
    }
}