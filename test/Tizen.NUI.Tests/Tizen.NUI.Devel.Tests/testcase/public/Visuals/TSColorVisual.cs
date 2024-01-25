using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/ColorVisual")]
    public class PublicColorVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyColorVisual : ColorVisual
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
        [Description("ColorVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.ColorVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorVisualConstructor()
        {
            tlog.Debug(tag, $"ColorVisualConstructor START");

            var testingTarget = new ColorVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ColorVisual");
            Assert.IsInstanceOf<ColorVisual>(testingTarget, "Should be an instance of ColorVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorVisual Color.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorVisualColor()
        {
            tlog.Debug(tag, $"ColorVisualColor START");

            var testingTarget = new ColorVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ColorVisual");
            Assert.IsInstanceOf<ColorVisual>(testingTarget, "Should be an instance of ColorVisual type.");

            using (Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f))
            {
                testingTarget.Color = color;
                Assert.AreEqual(1.0f, testingTarget.Color.R, "Retrieved Color.R should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Color.G, "Retrieved Color.G should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Color.B, "Retrieved Color.B should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.Color.A, "Retrieved Color.A should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorVisualColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorVisual RenderIfTransparent.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.RenderIfTransparent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorVisualRenderIfTransparent()
        {
            tlog.Debug(tag, $"ColorVisualRenderIfTransparent START");

            var testingTarget = new ColorVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object ColorVisual");
            Assert.IsInstanceOf<ColorVisual>(testingTarget, "Should be an instance of ColorVisual type.");

            testingTarget.RenderIfTransparent = true;
            Assert.AreEqual(true, testingTarget.RenderIfTransparent, "Retrieved RenderIfTransparent should be equal to set value");

            testingTarget.RenderIfTransparent = false;
            Assert.AreEqual(false, testingTarget.RenderIfTransparent, "Retrieved RenderIfTransparent should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorVisualRenderIfTransparent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ColorVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.ColorVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ColorVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"ColorVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyColorVisual()
            {
                Color = new Color(1.0f, 0.3f, 0.5f, 1.0f),
            };
            Assert.IsInstanceOf<ColorVisual>(testingTarget, "Should be an instance of ColorVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ColorVisualComposingPropertyMap END (OK)");
        }
    }
}
