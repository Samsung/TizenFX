using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class TapGestureTest1Page : ContentPage
    {
        private string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        private TapGestureDetector imageTapDetector;
        private TapGestureDetector frameTapDetector;
        private int imageTapCount;
        private int frameTapCount;

        public TapGestureTest1Page()
        {
            InitializeComponent();
            tabView.Padding = new Extents(20, 20, 20, 20);

            CreateImageTab();
            CreateFrameTab();
        }

        private void CreateImageTab()
        {
          imageTapCount = 0;
          TabButton button = new TabButton() { Text = "Image", };
          View view = new View
          {
            Layout = new LinearLayout()
              {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
                  LinearAlignment = LinearLayout.Alignment.Center,
                  CellPadding = new Size2D(30, 30),
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
          };

          ImageView image = new ImageView
          {
              ResourceUrl = ImageURL + "picture.png",
              BorderlineWidth = 5f,
              BorderlineColor = Color.Red,
          };

          TextLabel label = new TextLabel
          {
            Text = "tap the photo!",
            PointSize = 8,
          };

          view.Add(image);
          view.Add(label);

          tabView.AddTab(button, view);

          imageTapDetector = new TapGestureDetector();
          imageTapDetector.Attach(image);
          imageTapDetector.Detected += (obj, e) =>
          {
              ++imageTapCount;
              label.Text = imageTapCount + " taps so far!";
          };

        }

        private void CreateFrameTab()
        {
          frameTapCount = 0;
          TabButton button = new TabButton() { Text = "Frame", };

          View view = new View
          {
            Layout = new LinearLayout()
              {
                  LinearOrientation = LinearLayout.Orientation.Vertical,
                  LinearAlignment = LinearLayout.Alignment.Center,
                  CellPadding = new Size2D(30, 30),
              },
              WidthSpecification = LayoutParamPolicies.MatchParent,
              HeightSpecification = LayoutParamPolicies.MatchParent,
          };

          View image = new View
          {
              BackgroundColor = Color.White,
              Size = new Size(200, 200),

              BorderlineWidth = 5f,
              BorderlineColor = Color.Red,
          };

          TextLabel label = new TextLabel
          {
            Text = "tap the frame!",
            PointSize = 8,
          };

          view.Add(image);
          view.Add(label);

          tabView.AddTab(button, view);

          frameTapDetector = new TapGestureDetector();
          frameTapDetector.Attach(image);
          frameTapDetector.Detected += (obj, e) =>
          {
              ++frameTapCount;
              label.Text = frameTapCount + " taps so far!";
          };

        }
    }
}
