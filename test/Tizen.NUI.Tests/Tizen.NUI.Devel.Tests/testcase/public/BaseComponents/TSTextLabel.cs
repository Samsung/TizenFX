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

        public bool CheckColor(Color colorSrc, Color colorDst)
        {
            if (colorSrc.R == colorDst.R && colorSrc.G == colorDst.G && colorSrc.B == colorDst.B && colorSrc.A == colorDst.A)
                return true;

            return false;
        }

        public bool CheckColor(Vector4 colorSrc, Vector4 colorDst)
        {
            if (colorSrc.X == colorDst.X && colorSrc.Y == colorDst.Y && colorSrc.Z == colorDst.Z && colorSrc.W == colorDst.W)
                return true;

            return false;
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

        [Test]
        [Category("P1")]
        [Description("TextLabel Strikethrough.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.GetStrikethrough M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.sabah@samsung.com")]
        public void TextLabelStrikethrough()
        {
            tlog.Debug(tag, $"TextLabelStrikethrough START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var setStrikethrough = new Tizen.NUI.Text.Strikethrough()
            {
                Enable = true,
                Color = new Color("#3498DB"),
                Height = 2.0f
            };

            testingTarget.SetStrikethrough(setStrikethrough);

            var getStrikethrough = testingTarget.GetStrikethrough();
            Assert.AreEqual(getStrikethrough.Enable, setStrikethrough.Enable, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getStrikethrough.Color, setStrikethrough.Color), "Should be true!");
            Assert.AreEqual(getStrikethrough.Height, setStrikethrough.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelStrikethrough END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel CharacterSpacing.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.CharacterSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "s.sabah@samsung.com")]
        public void TextLabelCharacterSpacing()
        {
            tlog.Debug(tag, $"TextLabelCharacterSpacing START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            float expandedValue = 1.5f;
            testingTarget.CharacterSpacing = expandedValue;
            Assert.AreEqual(expandedValue, testingTarget.CharacterSpacing, "Should be equal!");

            float condensedValue = -1.5f;
            testingTarget.CharacterSpacing = condensedValue;
            Assert.AreEqual(condensedValue, testingTarget.CharacterSpacing, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelCharacterSpacing END (OK)");
        }

    }
}
