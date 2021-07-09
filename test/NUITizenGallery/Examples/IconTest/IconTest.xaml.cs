
using Tizen.NUI.BaseComponents;

namespace NUITizenGallery
{
    public partial class IconTestPage : View
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