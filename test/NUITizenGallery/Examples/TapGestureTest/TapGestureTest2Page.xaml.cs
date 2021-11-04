using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class TapGestureTest2Page : ContentPage
    {
        private TapGestureDetector tapDetector;
        private int tapCount;
        private Vector3 initScale;

        public TapGestureTest2Page()
        {
            InitializeComponent();
            initScale = imageView.Scale;

            text1.Text = "  Tap the image!\n  Onte tap: Rotate 45 degrees\n  Two taps: Increase scale by 0.5\n  Three taps: Reset the image\n";

            tapDetector = new TapGestureDetector();
            tapDetector.SetMaximumTapsRequired(3);

            tapDetector.Attach(imageView);

            tapDetector.Detected += (obj, e) =>
            {
                if (e.TapGesture.NumberOfTaps == 1)
                {
                    ++tapCount;
                    int rotation = tapCount % 8;
                    imageView.Orientation = new Rotation(new Radian(new Degree(45 * rotation)), new Vector3(0f, 0f, 1f));
                }
                else if (e.TapGesture.NumberOfTaps == 2)
                {
                    imageView.Scale = imageView.Scale * new Vector3(1.5f, 1.5f, 1.0f);
                }
                else if (e.TapGesture.NumberOfTaps == 3)
                {
                    imageView.Scale = initScale;
                    imageView.Orientation = new Rotation(new Radian(new Degree(0)), new Vector3(0f, 0f, 1f));
                }
            };

        }
    }
}
