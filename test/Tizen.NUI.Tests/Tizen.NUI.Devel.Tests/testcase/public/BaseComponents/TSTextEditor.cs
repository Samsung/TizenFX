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
    [Description("public/BaseComponents/TextEditor")]
    public class PublicTextEditorTest
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
        [Description("TextEditor constructor. With status of Shown.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.TextEditor C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextEditorConstructorWithStatusOfShown()
        {
            tlog.Debug(tag, $"TextEditorConstructorWithStatusOfShown START");

            var testingTarget = new TextEditor(false);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorConstructorWithStatusOfShown END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor TranslatableText.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.TranslatableText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextEditorTranslatableText()
        {
            tlog.Debug(tag, $"TextEditorTranslatableText START");

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            tlog.Debug(tag, "TranslatableText : " + testingTarget.TranslatableText);

            if (Tizen.NUI.NUIApplication.MultilingualResourceManager != null)
            {
                testingTarget.TranslatableText = "textEditorTextSid";
                Assert.AreEqual("textEditorTextSid", testingTarget.TranslatableText, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorTranslatableText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor TranslatablePlaceholderText.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.TranslatablePlaceholderText A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TextEditorTranslatablePlaceholderText()
        {
            tlog.Debug(tag, $"TextEditorTranslatablePlaceholderText START");

            var testingTarget = new TextEditor();
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            tlog.Debug(tag, "TranslatablePlaceholderText : " + testingTarget.TranslatablePlaceholderText);

            if (Tizen.NUI.NUIApplication.MultilingualResourceManager != null)
            {
                testingTarget.TranslatablePlaceholderText = "textEditorTextSid";
                Assert.AreEqual("textEditorTextSid", testingTarget.TranslatablePlaceholderText, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorTranslatablePlaceholderText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor FontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.FontSizeScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorFontSizeScale()
        {
            tlog.Debug(tag, $"TextEditorFontSizeScale START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            testingTarget.FontSizeScale = 2.0f;
            Assert.AreEqual(2.0f, testingTarget.FontSizeScale, "Should be equal!");

            testingTarget.FontSizeScale = Tizen.NUI.FontSizeScale.UseSystemSetting;
            Assert.AreEqual(Tizen.NUI.FontSizeScale.UseSystemSetting, testingTarget.FontSizeScale, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorFontSizeScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor EnableFontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.EnableFontSizeScale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorEnableFontSizeScale()
        {
            tlog.Debug(tag, $"TextEditorEnableFontSizeScale START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            testingTarget.EnableFontSizeScale = false;
            Assert.AreEqual(false, testingTarget.EnableFontSizeScale, "Should be equal!");

            testingTarget.EnableFontSizeScale = true;
            Assert.AreEqual(true, testingTarget.EnableFontSizeScale, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorEnableFontSizeScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor Strikethrough.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetStrikethrough M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "s.sabah@samsung.com")]
        public void TextEditorStrikethrough()
        {
            tlog.Debug(tag, $"TextEditorStrikethrough START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

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
            tlog.Debug(tag, $"TextEditorStrikethrough END (OK)");
        }


        [Test]
        [Category("P1")]
        [Description("TextEditor CharacterSpacing.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.CharacterSpacing A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "s.sabah@samsung.com")]
        public void TextEditorCharacterSpacing()
        {
            tlog.Debug(tag, $"TextEditorCharacterSpacing START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            float expandedValue = 1.5f;
            testingTarget.CharacterSpacing = expandedValue;
            Assert.AreEqual(expandedValue, testingTarget.CharacterSpacing, "Should be equal!");

            float condensedValue = -1.5f;
            testingTarget.CharacterSpacing = condensedValue;
            Assert.AreEqual(condensedValue, testingTarget.CharacterSpacing, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorCharacterSpacing END (OK)");
        }
    }
}
