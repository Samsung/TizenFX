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
    [Description("public/Layouting/MeasuredSize")]
    public class PublicMeasuredSizeTest
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
        [Description("MeasuredSize constructor")]
        [Property("SPEC", "Tizen.NUI.MeasuredSize.MeasuredSize C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "LayoutLength, MeasuredSize.StateType")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeasuredSizeConstructor()
        {
            tlog.Debug(tag, $"MeasuredSizeConstructor START");

            var testingTarget = new MeasuredSize(new LayoutLength(10), MeasuredSize.StateType.MeasuredSizeOK);
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<MeasuredSize>(testingTarget, "Should return MeasuredSize instance.");

            tlog.Debug(tag, $"MeasuredSizeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeasuredSize Size")]
        [Property("SPEC", "Tizen.NUI.MeasuredSize.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeasuredSizeSize()
        {
            tlog.Debug(tag, $"MeasuredSizeSize START");

            var testingTarget = new MeasuredSize(new LayoutLength(10), MeasuredSize.StateType.MeasuredSizeOK);
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<MeasuredSize>(testingTarget, "Should return MeasuredSize instance.");

            float length = testingTarget.Size.AsRoundedValue();
            Assert.AreEqual(length, 10.0f, "Should be value set.");

            testingTarget.Size = new LayoutLength(20);

            length = testingTarget.Size.AsRoundedValue();
            Assert.AreEqual(length, 20.0f, "Should be value set.");

            tlog.Debug(tag, $"MeasuredSizeSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("MeasuredSize State")]
        [Property("SPEC", "Tizen.NUI.MeasuredSize.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MeasuredSizeState()
        {
            tlog.Debug(tag, $"MeasuredSizeState START");

            var testingTarget = new MeasuredSize(new LayoutLength(10), MeasuredSize.StateType.MeasuredSizeOK);
            Assert.IsNotNull(testingTarget, "null handle returned");
            Assert.IsInstanceOf<MeasuredSize>(testingTarget, "Should return MeasuredSize instance.");

            Assert.AreEqual(testingTarget.State, MeasuredSize.StateType.MeasuredSizeOK, "Should match default state");

            testingTarget.State = MeasuredSize.StateType.MeasuredSizeTooSmall;
            Assert.AreEqual(testingTarget.State, MeasuredSize.StateType.MeasuredSizeTooSmall, "Should state set");

            tlog.Debug(tag, $"MeasuredSizeState END (OK)");
        }
    }
}
