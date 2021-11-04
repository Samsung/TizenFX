
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class ImageButtonTestPage : ContentPage
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
