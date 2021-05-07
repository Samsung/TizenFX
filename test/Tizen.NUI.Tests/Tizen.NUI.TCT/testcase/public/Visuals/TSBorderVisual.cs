using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/BorderVisual")]
    public class PublicBorderVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyBorderVisual : BorderVisual
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
        [Description("BorderVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.BorderVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BorderVisualConstructor()
        {
            tlog.Debug(tag, $"BorderVisualConstructor START");

            var testingTarget = new BorderVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object BorderVisual");
            Assert.IsInstanceOf<BorderVisual>(testingTarget, "Should be an instance of BorderVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BorderVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BorderVisual Color.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BorderVisualColor()
        {
            tlog.Debug(tag, $"BorderVisualColor START");

            var testingTarget = new BorderVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object BorderVisual");
            Assert.IsInstanceOf<BorderVisual>(testingTarget, "Should be an instance of BorderVisual type.");

            using (Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f)) 
            {
                testingTarget.Color = color;
                Assert.AreEqual(1.0f, testingTarget.Color.R, "Retrieved Color.R should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Color.G, "Retrieved Color.G should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Color.B, "Retrieved Color.B should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Color.A, "Retrieved Color.A should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BorderVisualColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BorderVisual BorderSize.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.BorderSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BorderVisualBorderSize()
        {
            tlog.Debug(tag, $"BorderVisualBorderSize START");

            var testingTarget = new BorderVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object BorderVisual");
            Assert.IsInstanceOf<BorderVisual>(testingTarget, "Should be an instance of BorderVisual type.");

            testingTarget.BorderSize = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.BorderSize, "Retrieved BorderSize should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BorderVisualBorderSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BorderVisual AntiAliasing.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.AntiAliasing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BorderVisualAntiAliasing()
        {
            tlog.Debug(tag, $"BorderVisualAntiAliasing START");

            var testingTarget = new BorderVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object BorderVisual");
            Assert.IsInstanceOf<BorderVisual>(testingTarget, "Should be an instance of BorderVisual type.");

            testingTarget.AntiAliasing = true;
            Assert.AreEqual(true, testingTarget.AntiAliasing, "Retrieved AntiAliasing should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BorderVisualAntiAliasing END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("BorderVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.BorderVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BorderVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"BorderVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyBorderVisual()
            {
                Color = new Color(1.0f, 0.3f, 0.5f, 1.0f),
                BorderSize = 1.0f,
            };
            Assert.IsInstanceOf<BorderVisual>(testingTarget, "Should be an instance of BorderVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"BorderVisualComposingPropertyMap END (OK)");
        }
    }
}
