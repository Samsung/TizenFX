using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/NPatchVisual")]
    public class PublicNPatchVisualTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "Tizen.NUI.Tests.png";
        private static bool flagComposingPropertyMap;
        internal class MyNPatchVisual : NPatchVisual
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
        [Description("NPatchVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.NPatchVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NPatchVisualConstructor()
        {
            tlog.Debug(tag, $"NPatchVisualConstructor START");

            var testingTarget = new NPatchVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object NPatchVisual");
            Assert.IsInstanceOf<NPatchVisual>(testingTarget, "Should be an instance of NPatchVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NPatchVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NPatchVisual URL.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.URL A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NPatchVisualURL()
        {
            tlog.Debug(tag, $"NPatchVisualURL START");

            var testingTarget = new NPatchVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object NPatchVisual");
            Assert.IsInstanceOf<NPatchVisual>(testingTarget, "Should be an instance of NPatchVisual type.");

            testingTarget.URL = image_path;
            Assert.AreEqual(image_path, testingTarget.URL, "Retrieved URL should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NPatchVisualURL END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NPatchVisual BorderOnly.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.BorderOnly A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NPatchVisualBorderOnly()
        {
            tlog.Debug(tag, $"NPatchVisualBorderOnly START");

            var testingTarget = new NPatchVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object NPatchVisual");
            Assert.IsInstanceOf<NPatchVisual>(testingTarget, "Should be an instance of NPatchVisual type.");

            testingTarget.BorderOnly = true;
            Assert.AreEqual(true, testingTarget.BorderOnly, "Retrieved BorderOnly should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NPatchVisualBorderOnly END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NPatchVisual Border.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.Border A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NPatchVisualBorder()
        {
            tlog.Debug(tag, $"NPatchVisualBorder START");

            var testingTarget = new NPatchVisual();

            using (Rectangle rec = new Rectangle(0, 0, 10, 10))
            {
                testingTarget.Border = rec;
                Assert.AreEqual(0, testingTarget.Border.X, "Retrieved BorderOnly should be equal to set value");
                Assert.AreEqual(0, testingTarget.Border.Y, "Retrieved BorderOnly should be equal to set value");
                Assert.AreEqual(10, testingTarget.Border.Width, "Retrieved BorderOnly should be equal to set value");
                Assert.AreEqual(10, testingTarget.Border.Height, "Retrieved BorderOnly should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NPatchVisualBorder END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CNPatchVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.NPatchVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NPatchVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"NPatchVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyNPatchVisual()
            {
                URL = image_path,
                BorderOnly = true,
                Border = new Rectangle(0, 0, 10, 10)

            };
            Assert.IsInstanceOf<NPatchVisual>(testingTarget, "Should be an instance of NPatchVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NPatchVisualComposingPropertyMap END (OK)");
        }
    }
}
