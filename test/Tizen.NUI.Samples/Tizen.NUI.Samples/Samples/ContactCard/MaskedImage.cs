using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Samples
{
    public class MaskedImage
    {
        private static readonly string IMAGE_MASK = CommonResource.GetDaliResourcePath() + "ContactCard/contact-cards-mask.png";

        public static View Create(string imagePath)
        {
            View maskedImage = new ImageView();
            ImageVisual imageVisual = new ImageVisual();
            imageVisual.URL = imagePath;
            imageVisual.AlphaMaskURL = IMAGE_MASK;
            maskedImage.Background = imageVisual.OutputVisualMap;

            return maskedImage;
        }
    }
}
