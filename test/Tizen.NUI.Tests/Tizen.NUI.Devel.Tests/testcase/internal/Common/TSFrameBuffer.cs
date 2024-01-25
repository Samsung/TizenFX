using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FrameBuffer")]
    public class InternalFrameBufferTest
    {
        private const string tag = "NUITEST";

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
        [Description("FrameBuffer constructor.")]
        [Property("SPEC", "Tizen.NUI.FrameBuffer.FrameBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameBufferConstructor()
        {
            tlog.Debug(tag, $"FrameBufferConstructor START");

            var testingTarget = new FrameBuffer(10, 20, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object FrameBuffer.");
            Assert.IsInstanceOf<FrameBuffer>(testingTarget, "Should return FrameBuffer instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameBufferConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameBuffer AttachColorTexture.")]
        [Property("SPEC", "Tizen.NUI.FrameBuffer.AttachColorTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameBufferAttachColorTexture()
        {
            tlog.Debug(tag, $"FrameBufferAttachColorTexture START");

            var testingTarget = new FrameBuffer(10, 20, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object FrameBuffer.");
            Assert.IsInstanceOf<FrameBuffer>(testingTarget, "Should return FrameBuffer instance.");

            using (Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.BGR8888, 100, 80))
            {
                try
                {
                    testingTarget.AttachColorTexture(texture);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameBufferAttachColorTexture END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameBuffer AttachColorTexture. With uint.")]
        [Property("SPEC", "Tizen.NUI.FrameBuffer.AttachColorTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameBufferAttachColorTextureWithUInt()
        {
            tlog.Debug(tag, $"FrameBufferAttachColorTextureWithUInt START");

            var testingTarget = new FrameBuffer(10, 20, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object FrameBuffer.");
            Assert.IsInstanceOf<FrameBuffer>(testingTarget, "Should return FrameBuffer instance.");

            using (Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.BGR8888, 100, 80))
            {
                try
                {
                    testingTarget.AttachColorTexture(texture, 2, 1);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameBufferAttachColorTextureWithUInt END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FrameBuffer GetColorTexture.")]
        [Property("SPEC", "Tizen.NUI.FrameBuffer.GetColorTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FrameBufferGetColorTexture()
        {
            tlog.Debug(tag, $"FrameBufferGetColorTexture START");

            var testingTarget = new FrameBuffer(10, 20, 3);
            Assert.IsNotNull(testingTarget, "Can't create success object FrameBuffer.");
            Assert.IsInstanceOf<FrameBuffer>(testingTarget, "Should return FrameBuffer instance.");

            using (Texture texture = new Texture(TextureType.TEXTURE_2D, PixelFormat.BGR8888, 100, 80))
            {
                testingTarget.AttachColorTexture(texture);

                try
                {
                    testingTarget.GetColorTexture();
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"FrameBufferGetColorTexture END (OK)");
        }
    }
}
