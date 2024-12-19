using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.NUI.Samples
{
    public class EncodedImageTest : IExample
    {
        Window win;
        ImageView imageView;
        int index = 0;
        Timer timer;

        static private string DEMO_IMAGE_DIR = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "images/";

        static private readonly List<(string, EncodedImageBuffer.ImageTypes)> TestImages = new()
        {
            (DEMO_IMAGE_DIR + "Dali/DaliDemo/Logo-for-demo.png", EncodedImageBuffer.ImageTypes.RegularImage),
            (DEMO_IMAGE_DIR + "Dali/DaliDemo/Kid1.svg", EncodedImageBuffer.ImageTypes.VectorImage),
            (DEMO_IMAGE_DIR + "../a.json", EncodedImageBuffer.ImageTypes.AnimatedVectorImage),
        };

        string TestMaskImage = DEMO_IMAGE_DIR + "Dali/DaliDemo/shape-circle.png";

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();

            SetImage(index);
        }

        private bool OnTick(object o, Timer.TickEventArgs e)
        {
            index = (index + 1) % TestImages.Count;
            SetImage(index);
            return false;
        }

        private void OnResourceReady(object o, global::System.EventArgs e)
        {
            timer = new Timer(2000);
            timer.Tick += OnTick;
            timer.Start();
        }

        private async void SetImage(int index)
        {
            var encodedTask = CreateEncodedImageBufferAsync(TestImages[index].Item1, TestImages[index].Item2);

            imageView?.Unparent();
            imageView?.Dispose();

            EncodedImageBuffer buffer;
            ImageUrl imageUrl;

            imageView = new ImageView()
            {
                WidthResizePolicy = ResizePolicyType.FillToParent,
                HeightResizePolicy = ResizePolicyType.FillToParent,
            };
            imageView.ResourceReady += OnResourceReady;

            buffer = await encodedTask;

            imageUrl = buffer?.GenerateUrl();
            imageView.ResourceUrl = imageUrl?.ToString();

            if (TestImages[index].Item2 == EncodedImageBuffer.ImageTypes.RegularImage)
            {
                var encodedMaskTask = CreateEncodedImageBufferAsync(TestMaskImage, EncodedImageBuffer.ImageTypes.RegularImage);
                using var maskBuffer = await encodedMaskTask;
                using var maskImageUrl = maskBuffer?.GenerateUrl();
                imageView.AlphaMaskURL = maskImageUrl?.ToString();
            }
            else if (TestImages[index].Item2 == EncodedImageBuffer.ImageTypes.AnimatedVectorImage)
            {
                imageView.Play();
            }

            imageUrl?.Dispose();
            buffer?.Dispose();

            win.GetDefaultLayer().Add(imageView);
        }

        private async Task<EncodedImageBuffer> CreateEncodedImageBufferAsync(string filename, EncodedImageBuffer.ImageTypes imageType)
        {
            EncodedImageBuffer buffer = null;
            global::System.IO.Stream stream = new global::System.IO.FileStream(filename, global::System.IO.FileMode.Open);
            buffer = new EncodedImageBuffer(stream, imageType);
            return buffer;
        }

        public void Deactivate()
        {
            timer?.Stop();
            timer?.Dispose();
            imageView?.Unparent();
            imageView?.Dispose();
        }
    }
}
