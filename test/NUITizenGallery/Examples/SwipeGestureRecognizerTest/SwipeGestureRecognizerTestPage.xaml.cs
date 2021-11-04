using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class SwipeGestureRecognizerTestPage : ContentPage
    {
        private PanGestureDetector panGestureDetector;

        public SwipeGestureRecognizerTestPage()
        {
            InitializeComponent();

            panGestureDetector = new PanGestureDetector();

            panGestureDetector.Attach(areaView);
            panGestureDetector.Detected += (obj, e) =>
            {
                Vector2 velocity = e.PanGesture.Velocity;

                if (velocity.X > 0 )
                {
                    text1.Text = "Direction : Right";
                }
                else if (velocity.X < 0)
                {
                    text1.Text = "Direction : Left";
                }
            };

        }
    }
}
