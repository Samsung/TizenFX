
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.Samples
{
    public class EncodedImageTest : IExample
    {
        Window win;
        ImageView imageView;

        static public string DEMO_IMAGE_DIR = CommonResource.GetDaliResourcePath() + "DaliDemo/";

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();
            
            EncodedImageBuffer buffer;
            ImageUrl imageUrl;
            
            buffer = CreateEncodedImageBuffer(DEMO_IMAGE_DIR + "Logo-for-demo.png");

            imageUrl = buffer?.GenerateUrl();

            imageView = new ImageView()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,

                ResourceUrl = imageUrl?.ToString(),
            };

            imageUrl?.Dispose();
            buffer?.Dispose();

            win.GetDefaultLayer().Add(imageView);
        }

        private EncodedImageBuffer CreateEncodedImageBuffer(string filename)
        {
            EncodedImageBuffer buffer = null;
            global::System.IO.Stream stream = new global::System.IO.FileStream(filename, global::System.IO.FileMode.Open);
            buffer = new EncodedImageBuffer(stream);
            return buffer;
        }

        public void Deactivate()
        {
            imageView?.Unparent();
            imageView?.Dispose();
        }
    }
}
