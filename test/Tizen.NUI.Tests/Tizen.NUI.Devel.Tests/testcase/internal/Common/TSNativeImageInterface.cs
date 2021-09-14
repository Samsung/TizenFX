using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/NativeImageInterface")]
    public class InternalNativeImageInterfaceTest
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
        [Description("NativeImageInterface constructor.")]
        [Property("SPEC", "Tizen.NUI.NativeImageInterface.NativeImageInterface C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageInterfaceConstructor()
        {
            tlog.Debug(tag, $"NativeImageInterfaceConstructor START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Default);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an Instance of NativeImageSource!");

            tlog.Debug(tag, "getCPtr : " + NativeImageInterface.getCPtr(testingTarget));
           
            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageInterfaceConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageInterface TargetTexture.")]
        [Property("SPEC", "Tizen.NUI.NativeImageInterface.TargetTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageInterfaceTargetTexture()
        {
            tlog.Debug(tag, $"NativeImageInterfaceTargetTexture START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Default);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an Instance of NativeImageSource!");

            try
            {
                testingTarget.TargetTexture();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NativeImageInterfaceTargetTexture END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageInterface PrepareTexture.")]
        [Property("SPEC", "Tizen.NUI.NativeImageInterface.PrepareTexture M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageInterfacePrepareTexture()
        {
            tlog.Debug(tag, $"NativeImageInterfacePrepareTexture START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Default);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an Instance of NativeImageSource!");

            try
            {
                testingTarget.PrepareTexture();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"NativeImageInterfacePrepareTexture END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageInterface GetWidth.")]
        [Property("SPEC", "Tizen.NUI.NativeImageInterface.GetWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageInterfaceGetWidth()
        {
            tlog.Debug(tag, $"NativeImageInterfaceGetWidth START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Default);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an Instance of NativeImageSource!");

            var width = testingTarget.GetWidth();
            Assert.AreEqual(100, width, "should be equal!");
            var height = testingTarget.GetHeight();
            Assert.AreEqual(50, height, "should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageInterfaceGetWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NativeImageInterface RequiresBlending.")]
        [Property("SPEC", "Tizen.NUI.NativeImageInterface.RequiresBlending M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NativeImageInterfaceRequiresBlending()
        {
            tlog.Debug(tag, $"NativeImageInterfaceRequiresBlending START");

            var testingTarget = new NativeImageSource(100, 50, NativeImageSource.ColorDepth.Default);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<NativeImageSource>(testingTarget, "Should be an Instance of NativeImageSource!");

            var result = testingTarget.RequiresBlending();
            tlog.Debug(tag, "RequiresBlending : " +  result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NativeImageInterfaceRequiresBlending END (OK)");
        }
    }
}
