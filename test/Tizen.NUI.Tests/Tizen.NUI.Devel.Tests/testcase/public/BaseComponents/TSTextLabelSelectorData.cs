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
    [Description("public/BaseComponents/TextLabelSelectorData")]
    public class PublicTextLabelSelectorDataTest
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
        [Description("TextLabelSelectorData Reset.")]
        [Property("SPEC", "Tizen.NUI.TextLabelSelectorData.Reset M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextLabelSelectorDataReset()
        {
            tlog.Debug(tag, $"TextLabelSelectorDataReset START");

            var testingTarget = new TextLabelSelectorData();
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabelSelectorData");
            Assert.IsInstanceOf<TextLabelSelectorData>(testingTarget, "Should be an instance of TextLabelSelectorData type.");

            TextLabel textLabel = new TextLabel()
            {
                Text = "PublicTextLabelSelectorDataTest",
                FontFamily = "BreezeSans",
                TextColor = Color.Green,
                PointSize = 15.0f,
                PixelSize = 0.3f
            };

            try
            {
                testingTarget.Reset(textLabel);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"TextLabelSelectorDataReset END (OK)");
        }
    }
}
