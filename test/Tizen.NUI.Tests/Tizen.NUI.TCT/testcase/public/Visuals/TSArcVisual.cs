using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/ArcVisual")]
    public class PublicArcVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyArcVisual : ArcVisual
        {
            protected override void ComposingPropertyMap()
            {
                flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
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
        [Description("ArcVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.Visuals.ArcVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArcVisualConstructor()
        {
            tlog.Debug(tag, $"ArcVisualConstructor START");

            var testingTarget = new ArcVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object AnimatedImageVisual");
            Assert.IsInstanceOf<ArcVisual>(testingTarget, "Should be an instance of ArcVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ArcVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ArcVisual Thickness.")]
        [Property("SPEC", "Tizen.NUI.Visuals.Thickness A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArcVisualThickness()
        {
            tlog.Debug(tag, $"ArcVisualThickness START");

            var testingTarget = new ArcVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ArcVisual");
            Assert.IsInstanceOf<ArcVisual>(testingTarget, "Should be an instance of ArcVisual type.");

            testingTarget.Thickness = 0.3f;
            var result = testingTarget.Thickness;
            Assert.AreEqual(0.3f, result, "Retrived result should be equal to set value.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ArcVisualThickness END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ArcVisual StartAngle.")]
        [Property("SPEC", "Tizen.NUI.Visuals.StartAngle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArcVisualStartAngle()
        {
            tlog.Debug(tag, $"ArcVisualStartAngle START");

            var testingTarget = new ArcVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ArcVisual");
            Assert.IsInstanceOf<ArcVisual>(testingTarget, "Should be an instance of ArcVisual type.");

            testingTarget.StartAngle = 30.0f;
            var result = testingTarget.StartAngle;
            Assert.AreEqual(30.0f, result, "Retrived result should be equal to set value.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ArcVisualStartAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ArcVisual SweepAngle.")]
        [Property("SPEC", "Tizen.NUI.Visuals.SweepAngle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArcVisualSweepAngle()
        {
            tlog.Debug(tag, $"ArcVisualSweepAngle START");

            var testingTarget = new ArcVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ArcVisual");
            Assert.IsInstanceOf<ArcVisual>(testingTarget, "Should be an instance of ArcVisual type.");

            testingTarget.SweepAngle = 30.0f;
            var result = testingTarget.SweepAngle;
            Assert.AreEqual(30.0f, result, "Retrived result should be equal to set value.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ArcVisualSweepAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ArcVisual Cap.")]
        [Property("SPEC", "Tizen.NUI.Visuals.Cap A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArcVisualCap()
        {
            tlog.Debug(tag, $"ArcVisualCap START");

            var testingTarget = new ArcVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ArcVisual");
            Assert.IsInstanceOf<ArcVisual>(testingTarget, "Should be an instance of ArcVisual type.");

            testingTarget.Cap = ArcVisual.CapType.Butt;
            var result = testingTarget.Cap;
            Assert.AreEqual(ArcVisual.CapType.Butt, result, "Retrived result should be equal to set value.");

            testingTarget.Cap = ArcVisual.CapType.Round;
            result = testingTarget.Cap;
            Assert.AreEqual(ArcVisual.CapType.Round, result, "Retrived result should be equal to set value.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ArcVisualCap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ArcVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.Visuals.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ArcVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"ArcVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyArcVisual()
            {
                Thickness = 0.3f,
                StartAngle = 30.0f,
                SweepAngle = 40.0f,
                Cap = ArcVisual.CapType.Butt
            };
            Assert.IsInstanceOf<ArcVisual>(testingTarget, "Should be an instance of ArcVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ArcVisualComposingPropertyMap END (OK)");
        }
    }
}
