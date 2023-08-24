using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class PinchGestureTest1Page : ContentPage
    {
        private PinchGestureDetector pinchDetector;
        private Vector3 startingScale;
        public PinchGestureTest1Page()
        {
            InitializeComponent();

            pinchDetector = new PinchGestureDetector();
            pinchDetector.Attach(imageView);

            pinchDetector.Detected += (obj, e) =>
            {
                View view = e.View;
                if (view != null)
                {
                    if(e.PinchGesture.State == Gesture.StateType.Started)
                    {
                        startingScale = view.Scale;
                    }
                    view.Scale = startingScale * e.PinchGesture.Scale;
                }
            };
        }
    }
}