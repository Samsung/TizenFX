using global::System;	
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Images/EncodedImageBuffer")]
    public class PublicImageEncodedImageBufferTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        private Stream FileToStream(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            Stream stream = new MemoryStream(bytes);

            return stream;
        }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("EncodedImageBuffer GenerateUrl.")]
        [Property("SPEC", "Tizen.NUI.EncodedImageBuffer.GenerateUrl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "M")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicImagesEncodedImageBufferGenerateUrl()
        {
            tlog.Debug(tag, $"publicImagesEncodedImageBufferGenerateUrl START");

            var stream = FileToStream(image_path);
            long streamLength = stream.Length;

            using (VectorUnsignedChar buffer = new VectorUnsignedChar())
            {
                buffer.Resize((uint)streamLength);

                try
                {
                    var testingTarget = new EncodedImageBuffer(buffer);
                    Assert.IsNotNull(testingTarget, "Can't create success object EncodedImageBuffer");
                    Assert.IsInstanceOf<EncodedImageBuffer>(testingTarget, "Should be an instance of EncodedImageBuffer type.");

                    var url = testingTarget.GenerateUrl();
                    Assert.IsInstanceOf<ImageUrl>(url, "Should be an instance of ImageUrl type.");

                    var rawBuf = testingTarget.GetRawBuffer();
                    Assert.IsInstanceOf<VectorUnsignedChar>(rawBuf, "Should be an instance of VectorUnsignedChar type.");

                    testingTarget.Dispose();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }
            }

            tlog.Debug(tag, $"publicImagesEncodedImageBufferGenerateUrl END (OK)");
        }
    }
}