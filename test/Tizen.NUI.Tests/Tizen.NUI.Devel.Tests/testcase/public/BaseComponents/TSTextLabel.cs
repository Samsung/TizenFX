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
    [Description("public/BaseComponents/TextLabel")]
    public class PublicTextLabelTest
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
        [Description("TextLabel FontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.FontSizeScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelFontSizeScale()
        {
            tlog.Debug(tag, $"TextLabelFontSizeScale START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            testingTarget.FontSizeScale = 2.0f;
            Assert.AreEqual(2.0f, testingTarget.FontSizeScale, "Should be equal!");

            testingTarget.FontSizeScale = Tizen.NUI.FontSizeScale.UseSystemSetting;
            Assert.AreEqual(Tizen.NUI.FontSizeScale.UseSystemSetting, testingTarget.FontSizeScale, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelFontSizeScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel EnableFontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.EnableFontSizeScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelEnableFontSizeScale()
        {
            tlog.Debug(tag, $"TextLabelEnableFontSizeScale START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            testingTarget.EnableFontSizeScale = false;
            Assert.AreEqual(false, testingTarget.EnableFontSizeScale, "Should be equal!");

            testingTarget.EnableFontSizeScale = true;
            Assert.AreEqual(true, testingTarget.EnableFontSizeScale, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelEnableFontSizeScale END (OK)");
        }
    }   
}
