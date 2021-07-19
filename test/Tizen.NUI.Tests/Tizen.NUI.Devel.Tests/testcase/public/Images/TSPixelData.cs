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
    [Description("public/Images/PixelData")]
    public class PublicPixelDataTest
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
        [Description("PixelData constructor.")]
        [Property("SPEC", "Tizen.NUI.PixelData.PixelData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelDataConstructor()
        {
            tlog.Debug(tag, $"PixelDataConstructor START");

            byte[] buffer = new byte[1024];

            var testingTarget = new PixelData(buffer, 1024, 100, 150, PixelFormat.L8, PixelData.ReleaseFunction.Free);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelDataConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelData constructor. By IntPtr.")]
        [Property("SPEC", "Tizen.NUI.PixelData.PixelData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelDataConstructorByIntPtr()
        {
            tlog.Debug(tag, $"PixelDataConstructorByIntPtr START");

            byte[] buffer = new byte[1024];

            using (PixelData pixelData = new PixelData(buffer, 1024, 100, 150, PixelFormat.L8, PixelData.ReleaseFunction.Free))
            {
                var testingTarget = new PixelData(PixelData.getCPtr(pixelData).Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
                Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

                testingTarget.Dispose();
            }

            buffer = null;
            tlog.Debug(tag, $"PixelDataConstructorByIntPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelData GenerateUrl.")]
        [Property("SPEC", "Tizen.NUI.PixelData.GenerateUrl M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelDataUrl()
        {
            tlog.Debug(tag, $"PixelDataGenerateUrl START");

            byte[] buffer = new byte[1024];

            var testingTarget = new PixelData(buffer, 1024, 100, 150, PixelFormat.L8, PixelData.ReleaseFunction.Free);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

            var result = testingTarget.GenerateUrl();
            Assert.IsNotNull(result);

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelDataGenerateUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelData GetWidth.")]
        [Property("SPEC", "Tizen.NUI.PixelData.GetWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelGetWidth()
        {
            tlog.Debug(tag, $"PixelGetWidth START");

            byte[] buffer = new byte[1024];

            var testingTarget = new PixelData(buffer, 1024, 100, 150, PixelFormat.L8, PixelData.ReleaseFunction.Free);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

            var result = testingTarget.GetWidth();
            Assert.AreEqual(100, result, "Should be equal!");

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelGetWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelData GetHeight.")]
        [Property("SPEC", "Tizen.NUI.PixelData.GetHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelGetHeight()
        {
            tlog.Debug(tag, $"PixelGetHeight START");

            byte[] buffer = new byte[1024];

            var testingTarget = new PixelData(buffer, 1024, 100, 150, PixelFormat.L8, PixelData.ReleaseFunction.Free);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

            var result = testingTarget.GetHeight();
            Assert.AreEqual(150, result, "Should be equal!");

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelGetHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelData GetPixelFormat.")]
        [Property("SPEC", "Tizen.NUI.PixelData.GetPixelFormat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelGetPixelFormat()
        {
            tlog.Debug(tag, $"PixelGetPixelFormat START");

            byte[] buffer = new byte[1024];

            var testingTarget = new PixelData(buffer, 1024, 100, 150, PixelFormat.BGR8888, PixelData.ReleaseFunction.Free);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

            var result = testingTarget.GetPixelFormat();
            Assert.AreEqual(PixelFormat.BGR8888, result, "Should be equal!");

            buffer = null;
            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelGetPixelFormat END (OK)");
        }
    }
}
