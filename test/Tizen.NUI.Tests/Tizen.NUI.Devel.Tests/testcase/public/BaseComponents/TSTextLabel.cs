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

        public bool CheckVector2(Vector2 vectorSrc, Vector2 vectorDst)
        {
            if (vectorSrc.X == vectorDst.X && vectorSrc.Y == vectorDst.Y)
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

        [Test]
        [Category("P1")]
        [Description("TextLabel GetFontStyle.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.GetFontStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelGetFontStyle()
        {
            tlog.Debug(tag, $"TextLabelGetFontStyle START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var setFontStyle = new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Condensed,
                Weight = FontWeightType.Light,
                Slant = FontSlantType.Italic,
            };

            testingTarget.SetFontStyle(setFontStyle);

            var getFontStyle = testingTarget.GetFontStyle();
            Assert.AreEqual(getFontStyle.Width, setFontStyle.Width, "Should be equal!");
            Assert.AreEqual(getFontStyle.Weight, setFontStyle.Weight, "Should be equal!");
            Assert.AreEqual(getFontStyle.Slant, setFontStyle.Slant, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelGetFontStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel GetUnderline.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.GetUnderline M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelGetUnderline()
        {
            tlog.Debug(tag, $"TextLabelGetUnderline START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var setUnderline = new Tizen.NUI.Text.Underline()
            {
                Enable = true,
                Color = new Color("#3498DB"),
                Height = 2.0f,
                Type = UnderlineType.Dashed,
                DashWidth = 4.0f,
                DashGap = 6.0f,
            };

            testingTarget.SetUnderline(setUnderline);

            var getUnderline = testingTarget.GetUnderline();
            Assert.AreEqual(getUnderline.Enable, setUnderline.Enable, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getUnderline.Color, setUnderline.Color), "Should be true!");
            Assert.AreEqual(getUnderline.Height, setUnderline.Height, "Should be equal!");
            Assert.AreEqual(getUnderline.Type, setUnderline.Type, "Should be equal!");
            Assert.AreEqual(getUnderline.DashWidth, setUnderline.DashWidth, "Should be equal!");
            Assert.AreEqual(getUnderline.DashGap, setUnderline.DashGap, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelGetUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel GetShadow.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.GetShadow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelGetShadow()
        {
            tlog.Debug(tag, $"TextLabelGetShadow START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var setShadow = new Tizen.NUI.Text.Shadow()
            {
                BlurRadius = 5.0f,
                Color = Color.Red,
                Offset = new Vector2(3, 3),
            };

            testingTarget.SetShadow(setShadow);

            var getShadow = testingTarget.GetShadow();
            Assert.AreEqual(getShadow.BlurRadius, setShadow.BlurRadius, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getShadow.Color, setShadow.Color), "Should be true!");
            Assert.AreEqual(true, CheckVector2(getShadow.Offset, setShadow.Offset), "Should be true!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelGetShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel GetOutline.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.GetOutline M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelGetOutline()
        {
            tlog.Debug(tag, $"TextLabelGetOutline START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var setOutline = new Tizen.NUI.Text.Outline()
            {
                Width = 2.0f,
                Color = Color.Red,
            };

            testingTarget.SetOutline(setOutline);

            var getOutline = testingTarget.GetOutline();
            Assert.AreEqual(getOutline.Width, setOutline.Width, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getOutline.Color, setOutline.Color), "Should be true!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelGetOutline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel GetTextFit.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.GetTextFit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelGetTextFit()
        {
            tlog.Debug(tag, $"TextLabelGetTextFit START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            var setTextFit = new Tizen.NUI.Text.TextFit()
            {
                Enable = true,
                MinSize = 30.0f,
                MaxSize = 200.0f,
                StepSize = 1.0f,
                FontSizeType = FontSizeType.PointSize,
            };

            testingTarget.SetTextFit(setTextFit);

            var getTextFit = testingTarget.GetTextFit();
            Assert.AreEqual(getTextFit.Enable, setTextFit.Enable, "Should be equal!");
            Assert.AreEqual(getTextFit.MinSize, setTextFit.MinSize, "Should be equal!");
            Assert.AreEqual(getTextFit.MaxSize, setTextFit.MaxSize, "Should be equal!");
            Assert.AreEqual(getTextFit.StepSize, setTextFit.StepSize, "Should be equal!");
            Assert.AreEqual(getTextFit.FontSizeType, setTextFit.FontSizeType, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelGetTextFit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel MinLineSize.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.MinLineSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelMinLineSize()
        {
            tlog.Debug(tag, $"TextLabelMinLineSize START");

            var testingTarget = new TextLabel(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextLabel");
            Assert.IsInstanceOf<TextLabel>(testingTarget, "Should be an instance of TextLabel type.");

            testingTarget.MinLineSize = 20;
            Assert.AreEqual(20, testingTarget.MinLineSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextLabelMinLineSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextLabel DownCast.")]
        [Property("SPEC", "Tizen.NUI.TextLabel.DownCast M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextLabelDownCast()
        {
            tlog.Debug(tag, $"TextLabelDownCast START");
            try
            {
                BaseHandle handle = new TextLabel("Hello World!");
                TextLabel label = handle as TextLabel;

                TextLabel.DownCast(handle);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"TextLabelDownCast END (OK)");
        }
    }
}
