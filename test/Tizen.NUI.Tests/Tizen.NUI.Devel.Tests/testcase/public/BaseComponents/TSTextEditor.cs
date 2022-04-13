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

        public bool CheckVector2(Vector2 vectorSrc, Vector2 vectorDst)
        {
            if (vectorSrc.X == vectorDst.X && vectorSrc.Y == vectorDst.Y)
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

        [Test]
        [Category("P1")]
        [Description("TextEditor VerticalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorVerticalAlignment()
        {
            tlog.Debug(tag, $"TextEditorVerticalAlignment START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            testingTarget.VerticalAlignment = VerticalAlignment.Bottom;
            Assert.AreEqual(VerticalAlignment.Bottom, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.VerticalAlignment = VerticalAlignment.Top;
            Assert.AreEqual(VerticalAlignment.Top, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetFontStyle.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetFontStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetFontStyle()
        {
            tlog.Debug(tag, $"TextEditorGetFontStyle START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

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
            tlog.Debug(tag, $"TextEditorGetFontStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetUnderline.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetUnderline M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetUnderline()
        {
            tlog.Debug(tag, $"TextEditorGetUnderline START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

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
            tlog.Debug(tag, $"TextEditorGetUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetShadow.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetShadow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetShadow()
        {
            tlog.Debug(tag, $"TextEditorGetShadow START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

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
            tlog.Debug(tag, $"TextEditorGetShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetOutline.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetOutline M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetOutline()
        {
            tlog.Debug(tag, $"TextEditorGetOutline START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

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
            tlog.Debug(tag, $"TextEditorGetOutline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetSelectionHandleImage.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetSelectionHandleImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetSelectionHandleImage()
        {
            tlog.Debug(tag, $"TextEditorGetSelectionHandleImage START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var setSelectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage()
            {
                LeftImageUrl = "leftImage",
                RightImageUrl = "rightImage",
            };

            testingTarget.SetSelectionHandleImage(setSelectionHandleImage);

            var getSelectionHandleImage = testingTarget.GetSelectionHandleImage();
            Assert.AreEqual(getSelectionHandleImage.LeftImageUrl, setSelectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(getSelectionHandleImage.RightImageUrl, setSelectionHandleImage.RightImageUrl, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorGetSelectionHandleImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetSelectionHandlePressedImage.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetSelectionHandlePressedImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetSelectionHandlePressedImage()
        {
            tlog.Debug(tag, $"TextEditorGetSelectionHandlePressedImage START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var setSelectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage()
            {
                LeftImageUrl = "leftImage",
                RightImageUrl = "rightImage",
            };

            testingTarget.SetSelectionHandlePressedImage(setSelectionHandleImage);

            var getSelectionHandleImage = testingTarget.GetSelectionHandlePressedImage();
            Assert.AreEqual(getSelectionHandleImage.LeftImageUrl, setSelectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(getSelectionHandleImage.RightImageUrl, setSelectionHandleImage.RightImageUrl, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorGetSelectionHandlePressedImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetSelectionHandleMarkerImage.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetSelectionHandleMarkerImage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetSelectionHandleMarkerImage()
        {
            tlog.Debug(tag, $"TextEditorGetSelectionHandleMarkerImage START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var setSelectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage()
            {
                LeftImageUrl = "leftImage",
                RightImageUrl = "rightImage",
            };

            testingTarget.SetSelectionHandleMarkerImage(setSelectionHandleImage);

            var getSelectionHandleImage = testingTarget.GetSelectionHandleMarkerImage();
            Assert.AreEqual(getSelectionHandleImage.LeftImageUrl, setSelectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(getSelectionHandleImage.RightImageUrl, setSelectionHandleImage.RightImageUrl, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorGetSelectionHandleMarkerImage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetInputFilter.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetInputFilter M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetInputFilter()
        {
            tlog.Debug(tag, $"TextEditorGetInputFilter START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var setInputFilter = new Tizen.NUI.Text.InputFilter()
            {
                Accepted = @"[\d]",
                Rejected = "[0-3]",
            };

            testingTarget.SetInputFilter(setInputFilter);

            var getInputFilter = testingTarget.GetInputFilter();
            Assert.AreEqual(getInputFilter.Accepted, setInputFilter.Accepted, "Should be equal!");
            Assert.AreEqual(getInputFilter.Rejected, setInputFilter.Rejected, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorGetInputFilter END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextEditor GetPlaceholder.")]
        [Property("SPEC", "Tizen.NUI.TextEditor.GetPlaceholder M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextEditorGetPlaceholder()
        {
            tlog.Debug(tag, $"TextEditorGetPlaceholder START");

            var testingTarget = new TextEditor(true);
            Assert.IsNotNull(testingTarget, "Can't create success object TextEditor");
            Assert.IsInstanceOf<TextEditor>(testingTarget, "Should be an instance of TextEditor type.");

            var setPlaceholder = new Tizen.NUI.Text.Placeholder()
            {
                Text = "placeholder text",
                TextFocused = "placeholder TextFocused",
                Color = Color.Red,
                FontFamily = "BreezeSans",
                FontStyle = new Tizen.NUI.Text.FontStyle()
                {
                    Width = FontWidthType.Expanded,
                    Weight = FontWeightType.ExtraLight,
                    Slant = FontSlantType.Italic,
                },
                PointSize = 15.0f,
                Ellipsis = true,
            };

            testingTarget.SetPlaceholder(setPlaceholder);

            var getPlaceholder = testingTarget.GetPlaceholder();
            Assert.AreEqual(getPlaceholder.Text, setPlaceholder.Text, "Should be equal!");
            Assert.AreEqual(getPlaceholder.TextFocused, setPlaceholder.TextFocused, "Should be equal!");
            Assert.AreEqual(true, CheckColor(getPlaceholder.Color, setPlaceholder.Color), "Should be true!");
            Assert.AreEqual(getPlaceholder.FontFamily, setPlaceholder.FontFamily, "Should be equal!");
            Assert.AreEqual(true, getPlaceholder.FontStyle == setPlaceholder.FontStyle, "Should be true!");
            Assert.AreEqual(getPlaceholder.PointSize, setPlaceholder.PointSize, "Should be equal!");
            Assert.AreEqual(getPlaceholder.Ellipsis, setPlaceholder.Ellipsis, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextEditorGetPlaceholder END (OK)");
        }
    }
}
