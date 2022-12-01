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
    [Description("public/BaseComponents/TextLabelBindableProperty")]
    class TSLabelBindableProperty
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
        [Description("TextLabelBindableProperty TextLabel .")]
        [Property("SPEC", "Tizen.NUI.TextLabelBindableProperty.TextLabelBindableProperty C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelBindablePropertypartialTextLabel()
        {
            tlog.Debug(tag, $"TextLabelBindablePropertypartialTextLabel START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            try
            {
                Selector<string> sSelector = testingTarget.TranslatableTextSelector;
                testingTarget.TranslatableTextSelector = sSelector;

                sSelector = testingTarget.FontFamilySelector;

                Selector<float?> fSelector = testingTarget.PointSizeSelector;
                testingTarget.PointSizeSelector = fSelector;

                Selector<Color> cSelector = testingTarget.TextColorSelector;
                testingTarget.TextColorSelector = cSelector;

                Selector<TextShadow> tSelector = testingTarget.TextShadowSelector;
                testingTarget.TextShadowSelector = tSelector;

            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelBindablePropertypartialTextLabel END (OK)");
        }
    }
}
