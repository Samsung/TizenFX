
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class ImageButtonTestPage : View
    {
        string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        public ImageButtonTestPage()
        {
            InitializeComponent();
            imageview1.ResourceUrl = ImageURL + "NUITizenGallery.png";

            button1.ControlStateChangedEvent += (o, e) =>
            {
                if (e.CurrentState == ControlState.Normal) {
                    text1.Text = "Normal";
                }
                if (e.CurrentState == ControlState.Pressed) {
                    text1.Text = "Pressed";
                }   
            };
        }
    }
}