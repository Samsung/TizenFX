using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/SVGVisual")]
    public class PublicSVGVisualTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static bool flagComposingPropertyMap;
        internal class MySVGVisual : SVGVisual
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
        [Description("SVGVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.SVGVisual.SVGVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SVGVisualConstructor()
        {
            tlog.Debug(tag, $"SVGVisualConstructor START");

            var testingTarget = new SVGVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object SVGVisual");
            Assert.IsInstanceOf<SVGVisual>(testingTarget, "Should be an instance of SVGVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SVGVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SVGVisual URL.")]
        [Property("SPEC", "Tizen.NUI.SVGVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SVGVisualURL()
        {
            tlog.Debug(tag, $"SVGVisualURL START");

            var testingTarget = new SVGVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object SVGVisual");
            Assert.IsInstanceOf<SVGVisual>(testingTarget, "Should be an instance of SVGVisual type.");

            testingTarget.URL = image_path;
            Assert.AreEqual(image_path, testingTarget.URL, "Retrieved URL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SVGVisualURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("SVGVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.SVGVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void SVGVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"SVGVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");
            
            var testingTarget = new MySVGVisual()
            {
                URL = image_path,
            };
            Assert.IsInstanceOf<SVGVisual>(testingTarget, "Should be an instance of SVGVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"SVGVisualComposingPropertyMap END (OK)");
        }
    }
}
