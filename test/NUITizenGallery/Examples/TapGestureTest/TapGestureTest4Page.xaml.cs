using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class TapGestureTest4Page : ContentPage
    {
        private TapGestureDetector imageTapDetector;
        private TapGestureDetector boxviewTapDetector;
        private TapGestureDetector labelTapDetector;

        public TapGestureTest4Page()
        {
            InitializeComponent();

            text1.Text = "  Please tap the following widgets. \n : Image / BoxView / Button / Label";

            imageTapDetector = new TapGestureDetector();
            boxviewTapDetector = new TapGestureDetector();
            labelTapDetector = new TapGestureDetector();

            imageTapDetector.Attach(imageView);
            imageTapDetector.Detected += (obj, e) =>
            {
                text2.Text = "An image is tapped";
            };

            boxviewTapDetector.Attach(boxView);
            boxviewTapDetector.Detected += (obj, e) =>
            {
                text2.Text = "A boxview is tapped";
            };

            button1.Clicked += (obj, e) =>
            {
                text2.Text = "A button is tapped";
            };

            labelTapDetector.Attach(label1);
            labelTapDetector.Detected += (obj, e) =>
            {
                text2.Text = "A label is tapped";
            };

        }
    }
}
