using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/NativeImageSource")]
    public class PublicNativeImageSourceTest
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
        [Description("NativeImageSource constructor.")]
        [Property("SPEC", "Tizen.NUI.NativeImageSource.NativeImageSource C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageSourceConstructor()
        {
            tlog.Debug(tag, $"NativeImageSourceConstructor START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Bits16);
            Assert.IsNotNull(testingTarget, "Can't create success object NativeImageSource");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an instance of NativeImageSource type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageSourceConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageSource Url.")]
        [Property("SPEC", "Tizen.NUI.NativeImageSource.Url A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageSourceUrl()
        {
            tlog.Debug(tag, $"NativeImageSourceUrl START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Bits16);
            Assert.IsNotNull(testingTarget, "Can't create success object NativeImageSource");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an instance of NativeImageSource type.");

            var result = testingTarget.Url;
            Assert.IsNotNull(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageSourceUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageSource AcquireBuffer.")]
        [Property("SPEC", "Tizen.NUI.NativeImageSource.AcquireBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageSourceAcquireBuffer()
        {
            tlog.Debug(tag, $"NativeImageSourceAcquireBuffer START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Bits16);
            Assert.IsNotNull(testingTarget, "Can't create success object NativeImageSource");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an instance of NativeImageSource type.");

            int width = 0, height = 0, stride = 0;
            try
            {
                testingTarget.AcquireBuffer(ref width, ref height, ref stride);
            }
            catch (Exception e)
            {
                Assert.Fail("Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageSourceAcquireBuffer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageSource ReleaseBuffer.")]
        [Property("SPEC", "Tizen.NUI.NativeImageSource.ReleaseBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageSourceReleaseBuffer()
        {
            tlog.Debug(tag, $"NativeImageSourceReleaseBuffer START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Bits16);
            Assert.IsNotNull(testingTarget, "Can't create success object NativeImageSource");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an instance of NativeImageSource type.");

            var result = testingTarget.ReleaseBuffer();
            Assert.IsTrue(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageSourceReleaseBuffer END (OK)");
        }
    }
}
