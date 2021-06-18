using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Layouting/MeasureSpecification")]
    public class PublicMeasureSpecificationTest
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
        [Description("MeasureSpecification constructor")]
        [Property("SPEC", "Tizen.NUI.MeasureSpecification.MeasureSpecification C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeasureSpecificationConstructor()
        {
            tlog.Debug(tag, $"MeasureSpecificationConstructor START");

            var testingTarget = new MeasureSpecification(new LayoutLength(10), MeasureSpecification.ModeType.Exactly);
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<MeasureSpecification>(testingTarget, "Should return MeasureSpecification instance.");

            tlog.Debug(tag, $"MeasureSpecificationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeasureSpecification Size")]
        [Property("SPEC", "Tizen.NUI.MeasureSpecification.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeasureSpecificationSize()
        {
            tlog.Debug(tag, $"MeasureSpecificationSize START");

            var testingTarget = new MeasureSpecification(new LayoutLength(10), MeasureSpecification.ModeType.Exactly);
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<MeasureSpecification>(testingTarget, "Should return MeasureSpecification instance.");

            Assert.AreEqual(testingTarget.GetSize().AsRoundedValue(), 10, "Should be 10.");

            var testValue = 20.0f;
            testingTarget.SetSize(new LayoutLength(testValue));

            Assert.AreEqual(testingTarget.GetSize().AsRoundedValue(), testValue, "Should be TestValue.");

            tlog.Debug(tag, $"MeasureSpecificationSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeasureSpecification Mode")]
        [Property("SPEC", "Tizen.NUI.MeasureSpecification.Mode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeasureSpecificationMode()
        {
            tlog.Debug(tag, $"MeasureSpecificationMode START");

            var testingTarget = new MeasureSpecification(new LayoutLength(10), MeasureSpecification.ModeType.Exactly);
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<MeasureSpecification>(testingTarget, "Should return MeasureSpecification instance.");

            Assert.AreEqual(testingTarget.GetMode(), MeasureSpecification.ModeType.Exactly, "Should be Exactly.");

            var mode = MeasureSpecification.ModeType.AtMost;
            testingTarget.SetMode(mode);
            Assert.AreEqual(testingTarget.GetMode(), mode, "Should be TestValue.");

            mode = MeasureSpecification.ModeType.Unspecified;
            testingTarget.SetMode(mode);
            Assert.AreEqual(testingTarget.GetMode(), mode, "Should be TestValue.");

            mode = MeasureSpecification.ModeType.Exactly;
            testingTarget.SetMode(mode);
            Assert.AreEqual(testingTarget.GetMode(), mode, "Should be TestValue.");

            tlog.Debug(tag, $"MeasureSpecificationMode END (OK)");
        }
    }
}
