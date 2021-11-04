
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace NUITizenGallery
{
    public partial class IconTestPage : ContentPage
    {
        string ImageURL = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";
        public IconTestPage()
        {
            InitializeComponent();
            image1.ResourceUrl = ImageURL + "NUITizenGallery.png";
            image2.ResourceUrl = ImageURL + "NUITizenGallery.png";
            image3.ResourceUrl = ImageURL + "NUITizenGallery.png";
        }
    }
}