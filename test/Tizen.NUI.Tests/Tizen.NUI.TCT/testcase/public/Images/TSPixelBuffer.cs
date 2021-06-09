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
    [Description("public/Common/PixelBuffer")]
    public class PublicPixelBufferTest
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
        [Description("PixelBuffer constructor.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.PixelBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferConstructor()
        {
            tlog.Debug(tag, $"PixelBufferConstructor START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.L8);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer constructor. By PixelBuffer.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.PixelBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferConstructorByPixelBuffer()
        {
            tlog.Debug(tag, $"PixelBufferConstructorByPixelBuffer START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 50, PixelFormat.L8))
            {
                var testingTarget = new PixelBuffer(pixelBuffer);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

                testingTarget.Dispose();
            }
            
            tlog.Debug(tag, $"PixelBufferConstructorByPixelBuffer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer constructor. By IntPtr.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.PixelBuffer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferConstructorByIntPtr()
        {
            tlog.Debug(tag, $"PixelBufferConstructorByIntPtr START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 50, PixelFormat.BGR8888))
            {
                var testingTarget = new PixelBuffer(PixelBuffer.getCPtr(pixelBuffer).Handle, true);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PixelBufferConstructorByIntPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer Convert.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.Convert M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferConvert()
        {
            tlog.Debug(tag, $"PixelBufferConvert START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 50, PixelFormat.BGR8888))
            {
                var testingTarget = PixelBuffer.Convert(pixelBuffer);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
                Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PixelBufferConvert END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer CreatePixelData.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.CreatePixelData M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferCreatePixelData()
        {
            tlog.Debug(tag, $"PixelBufferCreatePixelData START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 50, PixelFormat.BGR8888))
            {
                var testingTarget = pixelBuffer.CreatePixelData();
                Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
                Assert.IsInstanceOf<PixelData>(testingTarget, "Should be an instance of PixelData type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PixelBufferCreatePixelData END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer GetWidth.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.GetWidth M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferGetWidth()
        {
            tlog.Debug(tag, $"PixelBufferGetWidth START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

            var result = testingTarget.GetWidth();
            Assert.AreEqual(100, result, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferGetWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer GetHeight.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.GetHeight M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferGetHeight()
        {
            tlog.Debug(tag, $"PixelBufferGetHeight START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

            var result = testingTarget.GetHeight();
            Assert.AreEqual(50, result, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferGetHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer GetPixelFormat.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.GetPixelFormat M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferGetPixelFormat()
        {
            tlog.Debug(tag, $"PixelBufferGetPixelFormat START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

            var result = testingTarget.GetPixelFormat();
            Assert.AreEqual(PixelFormat.BGR8888, result, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferGetPixelFormat END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer Assign.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferAssign()
        {
            tlog.Debug(tag, $"PixelBufferAssign START");

            using (PixelBuffer pixelBuffer = new PixelBuffer(100, 50, PixelFormat.BGR8888))
            {
                var testingTarget = pixelBuffer.Assign(pixelBuffer);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

                var result = testingTarget.GetPixelFormat();
                Assert.AreEqual(PixelFormat.BGR8888, result, "Should be equal!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PixelBufferAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer GetBuffer.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.GetBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferGetBuffer()
        {
            tlog.Debug(tag, $"PixelBufferGetBuffer START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            var result = testingTarget.GetBuffer();
            Assert.IsNotNull(result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferGetBuffer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer Rotate.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.Rotate M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferRotate()
        {
            tlog.Debug(tag, $"PixelBufferRotate START");

            using (Degree degree = new Degree(30))
            {
                var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
                Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
                Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

                var result = testingTarget.Rotate(degree);
                Assert.IsTrue(result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PixelBufferRotate END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer Resize.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.Resize M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferResize()
        {
            tlog.Debug(tag, $"PixelBufferResize START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            Assert.AreEqual(100, testingTarget.GetWidth(), "Shoule be equal!");
            Assert.AreEqual(50, testingTarget.GetHeight(), "Shoule be equal!");

            testingTarget.Resize(50, 100);
            Assert.AreEqual(50, testingTarget.GetWidth(), "Shoule be equal!");
            Assert.AreEqual(100, testingTarget.GetHeight(), "Shoule be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferResize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer Crop.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.Crop M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferCrop()
        {
            tlog.Debug(tag, $"PixelBufferCrop START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            Assert.AreEqual(100, testingTarget.GetWidth(), "Shoule be equal!");
            Assert.AreEqual(50, testingTarget.GetHeight(), "Shoule be equal!");

            testingTarget.Crop(150, 100, 50, 100);
            Assert.AreEqual(50, testingTarget.GetWidth(), "Shoule be equal!");
            Assert.AreEqual(100, testingTarget.GetHeight(), "Shoule be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferCrop END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer ApplyGaussianBlur.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.ApplyGaussianBlur M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferApplyGaussianBlur()
        {
            tlog.Debug(tag, $"PixelBufferApplyGaussianBlur START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            try
            {
                testingTarget.ApplyGaussianBlur(1.0f);
            }
            catch (Exception e)
            {
                Assert.Fail("Fail!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferApplyGaussianBlur END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer ApplyMask.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.ApplyMask M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferApplyMask()
        {
            tlog.Debug(tag, $"PixelBufferApplyMask START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            try
            {
                using (PixelBuffer pixelBuffer = new PixelBuffer(50, 100, PixelFormat.A8))
                {
                    testingTarget.ApplyMask(pixelBuffer);
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Fail!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferApplyMask END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer ApplyMask. With scaling.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.ApplyMask M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferApplyMaskWithScaling()
        {
            tlog.Debug(tag, $"PixelBufferApplyMaskWithScaling START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            try
            {
                using (PixelBuffer pixelBuffer = new PixelBuffer(50, 100, PixelFormat.A8))
                {
                    testingTarget.ApplyMask(pixelBuffer, 0.5f);
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Fail!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferApplyMaskWithScaling END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("PixelBuffer ApplyMask. With Whether to crop.")]
        [Property("SPEC", "Tizen.NUI.PixelBuffer.ApplyMask M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PixelBufferApplyMaskWithCropOrNot()
        {
            tlog.Debug(tag, $"PixelBufferApplyMaskWithCropOrNot START");

            var testingTarget = new PixelBuffer(100, 50, PixelFormat.BGR8888);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelData");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelData type.");

            try
            {
                using (PixelBuffer pixelBuffer = new PixelBuffer(50, 100, PixelFormat.A8))
                {
                    testingTarget.ApplyMask(pixelBuffer, 0.5f, true);
                }
            }
            catch (Exception e)
            {
                Assert.Fail("Fail!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"PixelBufferApplyMaskWithCropOrNot END (OK)");
        }
    }
}
