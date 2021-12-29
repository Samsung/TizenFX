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
    [Description("public/BaseComponents/TextUtils")]
    class PublicTextUtilsTest
    {
        private const string tag = "NUITEST";
        private string imageurl = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        public bool CheckColor(Vector4 colorSrc, Vector4 colorDst)
        {
            if (colorSrc.X == colorDst.X && colorSrc.Y == colorDst.Y && colorSrc.Z == colorDst.Z && colorSrc.W == colorDst.W)
                return true;

            return false;
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
        [Description("TextUtils.RendererParameters constructor.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.RendererParameters C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersConstructor()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersConstructor START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters Text.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.RendererParameters A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersText()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersText START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Text = "RendererParameters";
            Assert.AreEqual("RendererParameters", testingTarget.Text, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters HorizontalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersHorizontalAlignment()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersHorizontalAlignment START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.HorizontalAlignment = HorizontalAlignment.Begin;
            Assert.AreEqual(HorizontalAlignment.Begin, testingTarget.HorizontalAlignment, "Should be equal!");

            testingTarget.HorizontalAlignment = HorizontalAlignment.Center;
            Assert.AreEqual(HorizontalAlignment.Center, testingTarget.HorizontalAlignment, "Should be equal!");

            testingTarget.HorizontalAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, testingTarget.HorizontalAlignment, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters VerticalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersVerticalAlignment()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersVerticalAlignment START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.VerticalAlignment = VerticalAlignment.Bottom;
            Assert.AreEqual(VerticalAlignment.Bottom, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.VerticalAlignment = VerticalAlignment.Top;
            Assert.AreEqual(VerticalAlignment.Top, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, testingTarget.VerticalAlignment, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters FontFamily.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersFontFamily()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersFontFamily START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.FontFamily = "BreezeSans";
            Assert.AreEqual("BreezeSans", testingTarget.FontFamily, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters FontWeight.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.FontWeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersFontWeight()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersFontWeight START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.FontWeight = "demiLight";
            Assert.AreEqual("demiLight", testingTarget.FontWeight, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersFontWeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters FontWidth.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.FontWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersFontWidth()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersFontWidth START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.FontWidth = "condensed";
            Assert.AreEqual("condensed", testingTarget.FontWidth, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersFontWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters FontSlant.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.FontSlant A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersFontSlant()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersFontSlant START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.FontSlant = "italic";
            Assert.AreEqual("italic", testingTarget.FontSlant, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersFontSlant END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters Layout.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.Layout A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersLayout()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersLayout START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Layout = TextLayout.MultiLine;
            Assert.AreEqual(TextLayout.MultiLine, testingTarget.Layout, "Should be equal!");

            testingTarget.Layout = TextLayout.Circular;
            Assert.AreEqual(TextLayout.Circular, testingTarget.Layout, "Should be equal!");

            testingTarget.Layout = TextLayout.SingleLine;
            Assert.AreEqual(TextLayout.SingleLine, testingTarget.Layout, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersLayout END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters CircularAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.CircularAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersCircularAlignment()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersCircularAlignment START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.CircularAlignment = CircularAlignment.End;
            Assert.AreEqual(CircularAlignment.End, testingTarget.CircularAlignment, "Should be equal!");

            testingTarget.CircularAlignment = CircularAlignment.Center;
            Assert.AreEqual(CircularAlignment.Center, testingTarget.CircularAlignment, "Should be equal!");

            testingTarget.CircularAlignment = CircularAlignment.Begin;
            Assert.AreEqual(CircularAlignment.Begin, testingTarget.CircularAlignment, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersCircularAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters TextColor.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersTextColor()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersTextColor START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.TextColor = new Vector4(0.3f, 0.8f, 1.0f, 0.0f);
            var color = new Vector4(0.3f, 0.8f, 1.0f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.TextColor), "Should be true!");

            color.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters FontSize.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.FontSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersFontSize()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersFontSize START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.FontSize = 15.0f;
            Assert.AreEqual(15.0f, testingTarget.FontSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersFontSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters TextWidth.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.TextWidth A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersTextWidth()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersTextWidth START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.TextWidth = 32;
            Assert.AreEqual(32, testingTarget.TextWidth, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersTextWidth END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters TextHeight.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.TextHeight A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersTextHeight()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersTextHeight START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.TextHeight = 16;
            Assert.AreEqual(16, testingTarget.TextHeight, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersTextHeight END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters Radius.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.Radius A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersRadius()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersRadius START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Radius = 16;
            Assert.AreEqual(16, testingTarget.Radius, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersRadius END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters BeginAngle.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.BeginAngle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersBeginAngle()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersBeginAngle START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.BeginAngle = 30.0f;
            Assert.AreEqual(30.0f, testingTarget.BeginAngle, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersBeginAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters IncrementAngle.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.IncrementAngle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersIncrementAngle()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersIncrementAngle START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.IncrementAngle = 5.0f;
            Assert.AreEqual(5.0f, testingTarget.IncrementAngle, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersIncrementAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters EllipsisEnabled.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.EllipsisEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersEllipsisEnabled()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersEllipsisEnabled START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Layout = TextLayout.SingleLine;

            testingTarget.EllipsisEnabled = true;
            Assert.AreEqual(true, testingTarget.EllipsisEnabled, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersEllipsisEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters MarkupEnabled.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.MarkupEnabled A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersMarkupEnabled()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersMarkupEnabled START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Layout = TextLayout.SingleLine;

            testingTarget.MarkupEnabled = true;
            Assert.AreEqual(true, testingTarget.MarkupEnabled, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersMarkupEnabled END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters IsTextColorSet.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.IsTextColorSet A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersIsTextColorSet()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersIsTextColorSet START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.TextColor = Color.Cyan;
            tlog.Debug(tag, "IsTextColorSet : " + testingTarget.IsTextColorSet);

            testingTarget.IsTextColorSet = false;
            tlog.Debug(tag, "IsTextColorSet : " + testingTarget.IsTextColorSet);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersIsTextColorSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters MinLineSize.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.MinLineSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersMinLineSize()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersMinLineSize START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.MinLineSize = 1.5f;
            Assert.AreEqual(1.5f, testingTarget.MinLineSize, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersMinLineSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.RendererParameters Padding.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.RendererParameters.Padding A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRendererParametersPadding()
        {
            tlog.Debug(tag, $"TextUtilsRendererParametersPadding START");

            var testingTarget = new RendererParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object RendererParameters");
            Assert.IsInstanceOf<RendererParameters>(testingTarget, "Should be an instance of RendererParameters type.");

            testingTarget.Padding = new Extents(4, 4, 4, 4);
            Assert.AreEqual(4, testingTarget.Padding.Start, "Should be equal!");
            Assert.AreEqual(4, testingTarget.Padding.End, "Should be equal!");
            Assert.AreEqual(4, testingTarget.Padding.Top, "Should be equal!");
            Assert.AreEqual(4, testingTarget.Padding.Bottom, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsRendererParametersPadding END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo constructor.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.EmbeddedItemInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoConstructor()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoConstructor START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo CharacterIndex.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.CharacterIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoCharacterIndex()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoCharacterIndex START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.CharacterIndex = 911;
            Assert.AreEqual(911, testingTarget.CharacterIndex, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoCharacterIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo GlyphIndex.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.GlyphIndex A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoGlyphIndex()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoGlyphIndex START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.GlyphIndex = 911;
            Assert.AreEqual(911, testingTarget.GlyphIndex, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoGlyphIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo Position.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.Position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoPosition()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoPosition START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.Position = new Vector2(100.0f, 200.0f);
            Assert.AreEqual(100.0f, testingTarget.Position.X, "Should be equal!");
            Assert.AreEqual(200.0f, testingTarget.Position.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo Size.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.Size A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoSize()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoSize START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.Size = new Size(100.0f, 200.0f);
            Assert.AreEqual(100.0f, testingTarget.Size.Width, "Should be equal!");
            Assert.AreEqual(200.0f, testingTarget.Size.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo RotatedSize.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.RotatedSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoRotatedSize()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoRotatedSize START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.RotatedSize = new Size(100.0f, 200.0f);
            Assert.AreEqual(100.0f, testingTarget.RotatedSize.Width, "Should be equal!");
            Assert.AreEqual(200.0f, testingTarget.RotatedSize.Height, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoRotatedSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo Angle.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.Angle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoAngle()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoAngle START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.Angle = new Degree(30.0f);
            Assert.AreEqual(30.0f, testingTarget.Angle.Value, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.EmbeddedItemInfo ColorBlendingMode.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.EmbeddedItemInfo.ColorBlendingMode A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsEmbeddedItemInfoColorBlendingModee()
        {
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoColorBlendingModee START");

            var testingTarget = new EmbeddedItemInfo();
            Assert.IsNotNull(testingTarget, "Can't create success object EmbeddedItemInfo");
            Assert.IsInstanceOf<EmbeddedItemInfo>(testingTarget, "Should be an instance of EmbeddedItemInfo type.");

            testingTarget.ColorBlendingMode = Tizen.NUI.ColorBlendingMode.Multiply;
            Assert.AreEqual(Tizen.NUI.ColorBlendingMode.Multiply, testingTarget.ColorBlendingMode, "Should be equal!");

            testingTarget.ColorBlendingMode = Tizen.NUI.ColorBlendingMode.None;
            Assert.AreEqual(Tizen.NUI.ColorBlendingMode.None, testingTarget.ColorBlendingMode, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsEmbeddedItemInfoColorBlendingModee END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.ShadowParameters constructor.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ShadowParameters.ShadowParameters C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsShadowParametersConstructor()
        {
            tlog.Debug(tag, $"TextUtilsShadowParametersConstructor START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsShadowParametersConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.ShadowParameters Input.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ShadowParameters.Input A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsShadowParametersInput()
        {
            tlog.Debug(tag, $"TextUtilsShadowParametersInput START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.Input = new PixelBuffer(30, 50, PixelFormat.A8);
            Assert.AreEqual(30, testingTarget.Input.GetWidth(), "Should be equal!");
            Assert.AreEqual(50, testingTarget.Input.GetHeight(), "Should be equal!");
            Assert.AreEqual(PixelFormat.A8, testingTarget.Input.GetPixelFormat(), "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsShadowParametersInput END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.ShadowParameters TextColor.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ShadowParameters.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsShadowParametersTextColor()
        {
            tlog.Debug(tag, $"TextUtilsShadowParametersTextColor START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.TextColor = new Vector4(0.3f, 0.8f, 1.0f, 0.0f);
            var color = new Vector4(0.3f, 0.8f, 1.0f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.TextColor), "Should be true!");

            color.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsShadowParametersTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.ShadowParameters Color.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ShadowParameters.Color A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsShadowParametersColor()
        {
            tlog.Debug(tag, $"TextUtilsShadowParametersColor START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.Input = new PixelBuffer(30, 50, PixelFormat.A8);

            testingTarget.Color = new Vector4(0.3f, 0.8f, 1.0f, 0.0f);
            var color = new Vector4(0.3f, 0.8f, 1.0f, 0.0f);
            Assert.AreEqual(true, CheckColor(color, testingTarget.Color), "Should be true!");

            color.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsShadowParametersColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.ShadowParameters Offset.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ShadowParameters.Offset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsShadowParametersOffset()
        {
            tlog.Debug(tag, $"TextUtilsShadowParametersOffset START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.Offset = new Vector2(0.3f, 0.8f);
            Assert.AreEqual(0.3f, testingTarget.Offset.X, "Should be equal!");
            Assert.AreEqual(0.8f, testingTarget.Offset.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsShadowParametersOffset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils.ShadowParameters blendShadow.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ShadowParameters.blendShadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsShadowParametersblendShadow()
        {
            tlog.Debug(tag, $"TextUtilsShadowParametersblendShadow START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.blendShadow = true;

            try
            {
                var result = testingTarget.blendShadow;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsShadowParametersblendShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils Render.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.Render M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsRender()
        {
            tlog.Debug(tag, $"TextUtilsRender START");

            TextLabel label = new TextLabel()
            {
                Size = new Size(50, 20),
                Text = "TextUtilsGetLastCharacterIndex"
            };

            RendererParameters textParameters = new RendererParameters();
            textParameters.Text = label.Text;
            textParameters.TextWidth = (uint)label.Size.Width;
            textParameters.TextHeight = (uint)label.Size.Height;
            textParameters.Layout = TextLayout.MultiLine;
            textParameters.EllipsisEnabled = true;

            EmbeddedItemInfo[] embeddedItemLayout = new EmbeddedItemInfo[3];

            var result = TextUtils.Render(textParameters, ref embeddedItemLayout);
            Assert.IsNotNull(result, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(result, "Should be an instance of PixelBuffer type.");

            tlog.Debug(tag, $"TextUtilsRender END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils CreateShadow.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.CreateShadow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsCreateShadow()
        {
            tlog.Debug(tag, $"TextUtilsCreateShadow START");

            var testingTarget = new ShadowParameters();
            Assert.IsNotNull(testingTarget, "Can't create success object ShadowParameters");
            Assert.IsInstanceOf<ShadowParameters>(testingTarget, "Should be an instance of ShadowParameters type.");

            testingTarget.Input = new PixelBuffer(30, 50, PixelFormat.A8);
            testingTarget.blendShadow = true;

            var result = TextUtils.CreateShadow(testingTarget);
            Assert.IsNotNull(result, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(result, "Should be an instance of PixelBuffer type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsCreateShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils ConvertToRgba8888.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.ConvertToRgba8888 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsConvertToRgba8888()
        {
            tlog.Debug(tag, $"TextUtilsConvertToRgba8888 START");

            var testingTarget = TextUtils.ConvertToRgba8888(new PixelBuffer(30, 50, PixelFormat.A8), new Vector4(0.3f, 0.8f, 1.0f, 0.0f), true);
            Assert.IsNotNull(testingTarget, "Can't create success object PixelBuffer");
            Assert.IsInstanceOf<PixelBuffer>(testingTarget, "Should be an instance of PixelBuffer type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextUtilsConvertToRgba8888 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils UpdateBuffer.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.UpdateBuffer M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsUpdateBuffer()
        {
            tlog.Debug(tag, $"TextUtilsUpdateBuffer START");

            try
            {
                TextUtils.UpdateBuffer(new PixelBuffer(30, 50, PixelFormat.A8), new PixelBuffer(60, 100, PixelFormat.A8), 70, 90, true);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"TextUtilsUpdateBuffer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils GetLastCharacterIndex.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.GetLastCharacterIndex M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsGetLastCharacterIndex()
        {
            tlog.Debug(tag, $"TextUtilsGetLastCharacterIndex START");

            TextLabel label = new TextLabel()
            {
                Size = new Size(50, 20),
                Text = "TextUtilsGetLastCharacterIndex"
            };

            RendererParameters textParameters = new RendererParameters();
            textParameters.Text = label.Text;
            textParameters.TextWidth = (uint)label.Size.Width;
            textParameters.TextHeight = (uint)label.Size.Height;
            textParameters.Layout = TextLayout.MultiLine;
            textParameters.EllipsisEnabled = true;

            var testingTarget = TextUtils.GetLastCharacterIndex(textParameters);
            Assert.IsNotNull(testingTarget, "Can't create success object PropertyArray");
            Assert.IsInstanceOf<PropertyArray>(testingTarget, "Should be an instance of PropertyArray type.");

            tlog.Debug(tag, $"TextUtilsGetLastCharacterIndex END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils GetFontSizeScale.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.GetFontSizeScale M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsGetFontSizeScale()
        {
            tlog.Debug(tag, $"TextUtilsGetFontSizeScale START");

            var giant = TextUtils.GetFontSizeScale(System.SystemSettingsFontSize.Giant);
            Assert.AreEqual(2.5f, giant, "Should be equal!");

            var huge = TextUtils.GetFontSizeScale(System.SystemSettingsFontSize.Huge);
            Assert.AreEqual(1.9f, huge, "Should be equal!");

            var large = TextUtils.GetFontSizeScale(System.SystemSettingsFontSize.Large);
            Assert.AreEqual(1.5f, large, "Should be equal!");

            var normal = TextUtils.GetFontSizeScale(System.SystemSettingsFontSize.Normal);
            Assert.AreEqual(1.0f, normal, "Should be equal!");

            var small = TextUtils.GetFontSizeScale(System.SystemSettingsFontSize.Small);
            Assert.AreEqual(0.8f, small, "Should be equal!");

            tlog.Debug(tag, $"TextUtilsGetFontSizeScale END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextUtils CopyToClipboard.")]
        [Property("SPEC", "Tizen.NUI.TextUtils.CopyToClipboard M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextUtilsCopyToClipboard()
        {
            tlog.Debug(tag, $"TextUtilsCopyToClipboard START");

            TextEditor editor = new TextEditor()
            { 
                Text = "editor",
            };
            var result = TextUtils.CopyToClipboard(editor);
            tlog.Debug(tag, "CopyToClipboard : " + result);

            result = TextUtils.CutToClipboard(editor);
            tlog.Debug(tag, "CutToClipboard : " + result);

            try
            {
                TextUtils.PasteTo(editor);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            TextField field = new TextField()
            {
                Text = "field",
            };
            result = TextUtils.CopyToClipboard(field);
            tlog.Debug(tag, "CopyToClipboard : " + field);

            result = TextUtils.CutToClipboard(field);
            tlog.Debug(tag, "CutToClipboard : " + field);

            try
            {
                TextUtils.PasteTo(field);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"TextUtilsCopyToClipboard END (OK)");
        }
    }
}
