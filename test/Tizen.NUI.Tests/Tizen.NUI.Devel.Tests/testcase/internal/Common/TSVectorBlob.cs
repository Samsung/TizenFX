using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/VectorBlob")]
    public class InternalVectorBlobTest
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
        [Description("VectorBlob constructor.")]
        [Property("SPEC", "Tizen.NUI.VectorBlob.VectorBlob C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBlobConstructor()
        {
            tlog.Debug(tag, $"VectorBlobConstructor START");

            var testingTarget = new VectorBlob();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VectorBlob>(testingTarget, "Should be an Instance of VectorBlob!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorBlobConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBlob R.")]
        [Property("SPEC", "Tizen.NUI.VectorBlob.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBlobR()
        {
            tlog.Debug(tag, $"VectorBlobR START");

            var testingTarget = new VectorBlob();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VectorBlob>(testingTarget, "Should be an Instance of VectorBlob!");

            testingTarget.R = 111;
            Assert.AreEqual(111, testingTarget.R, "Shoule be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorBlobR END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBlob G.")]
        [Property("SPEC", "Tizen.NUI.VectorBlob.R A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBlobG()
        {
            tlog.Debug(tag, $"VectorBlobG START");

            var testingTarget = new VectorBlob();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VectorBlob>(testingTarget, "Should be an Instance of VectorBlob!");

            testingTarget.G = 111;
            Assert.AreEqual(111, testingTarget.G, "Shoule be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorBlobG END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBlob B.")]
        [Property("SPEC", "Tizen.NUI.VectorBlob.VectorBlob A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBlobB()
        {
            tlog.Debug(tag, $"VectorBlobB START");

            var testingTarget = new VectorBlob();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VectorBlob>(testingTarget, "Should be an Instance of VectorBlob!");

            testingTarget.B = 111;
            Assert.AreEqual(111, testingTarget.B, "Shoule be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorBlobB END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("VectorBlob A.")]
        [Property("SPEC", "Tizen.NUI.VectorBlob.A A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void VectorBlobA()
        {
            tlog.Debug(tag, $"VectorBlobA START");

            var testingTarget = new VectorBlob();
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<VectorBlob>(testingTarget, "Should be an Instance of VectorBlob!");

            testingTarget.A = 111;
            Assert.AreEqual(111, testingTarget.A, "Shoule be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"VectorBlobA END (OK)");
        }
    }
}
