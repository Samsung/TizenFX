using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/FontDescription")]
    public class InternalFontDescriptionTest
    {
        private const string tag = "NUITEST";
        private string path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

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
        [Description("FontDescription constructor.")]
        [Property("SPEC", "Tizen.NUI.FontDescription.FontDescription C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontDescriptionConstructor()
        {
            tlog.Debug(tag, $"FontDescriptionConstructor START");

            var testingTarget = new FontDescription();
            Assert.IsNotNull(testingTarget, "Can't create success object FontDescription.");
            Assert.IsInstanceOf<FontDescription>(testingTarget, "Should return FontDescription instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontDescriptionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontDescription Path.")]
        [Property("SPEC", "Tizen.NUI.FontDescription.Path A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontDescriptionPath()
        {
            tlog.Debug(tag, $"FontDescriptionPath START");

            var testingTarget = new FontDescription();
            Assert.IsNotNull(testingTarget, "Can't create success object FontDescription.");
            Assert.IsInstanceOf<FontDescription>(testingTarget, "Should return FontDescription instance.");

            testingTarget.Path = path;
            Assert.AreEqual(path, testingTarget.Path, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontDescriptionPath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontDescription Family.")]
        [Property("SPEC", "Tizen.NUI.FontDescription.Family A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontDescriptionFamily()
        {
            tlog.Debug(tag, $"FontDescriptionFamily START");

            var testingTarget = new FontDescription();
            Assert.IsNotNull(testingTarget, "Can't create success object FontDescription.");
            Assert.IsInstanceOf<FontDescription>(testingTarget, "Should return FontDescription instance.");

            testingTarget.Family = "BreezeSans";
            Assert.AreEqual("BreezeSans", testingTarget.Family, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontDescriptionFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontDescription Width.")]
        [Property("SPEC", "Tizen.NUI.FontDescription.Width A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontDescriptionWidth()
        {
            tlog.Debug(tag, $"FontDescriptionWidth START");

            var testingTarget = new FontDescription();
            Assert.IsNotNull(testingTarget, "Can't create success object FontDescription.");
            Assert.IsInstanceOf<FontDescription>(testingTarget, "Should return FontDescription instance.");

            testingTarget.Width = FontWidthType.SemiExpanded;
            Assert.AreEqual(FontWidthType.SemiExpanded, testingTarget.Width, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontDescriptionWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontDescription Weight.")]
        [Property("SPEC", "Tizen.NUI.FontDescription.Weight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontDescriptionWeight()
        {
            tlog.Debug(tag, $"FontDescriptionWeight START");

            var testingTarget = new FontDescription();
            Assert.IsNotNull(testingTarget, "Can't create success object FontDescription.");
            Assert.IsInstanceOf<FontDescription>(testingTarget, "Should return FontDescription instance.");

            testingTarget.Weight = FontWeightType.Bold;
            Assert.AreEqual(FontWeightType.Bold, testingTarget.Weight, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontDescriptionWeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FontDescription Slant.")]
        [Property("SPEC", "Tizen.NUI.FontDescription.Slant A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FontDescriptionSlant()
        {
            tlog.Debug(tag, $"FontDescriptionSlant START");

            var testingTarget = new FontDescription();
            Assert.IsNotNull(testingTarget, "Can't create success object FontDescription.");
            Assert.IsInstanceOf<FontDescription>(testingTarget, "Should return FontDescription instance.");

            testingTarget.Slant = FontSlantType.Italic;
            Assert.AreEqual(FontSlantType.Italic, testingTarget.Slant, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"FontDescriptionSlant END (OK)");
        }
    }
}
