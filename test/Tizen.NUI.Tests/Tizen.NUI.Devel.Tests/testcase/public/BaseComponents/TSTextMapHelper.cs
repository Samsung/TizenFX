using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Text;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/TextMapHelper")]
    class PublicTextMapHelperTest
    {
        private const string tag = "NUITEST";

        public bool CheckColor(Color colorSrc, Color colorDst)
        {
            if (colorSrc.R == colorDst.R && colorSrc.G == colorDst.G && colorSrc.B == colorDst.B && colorSrc.A == colorDst.A)
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
        [Description("TextMapHelper GetFontWidthString.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontWidthString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontWidthString()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontWidthString START");

            string fontWidthString;

            fontWidthString = TextMapHelper.GetFontWidthString(FontWidthType.ExtraCondensed);
            Assert.AreEqual("extraCondensed", fontWidthString, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFontWidthString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontWeightString.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontWeightString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontWeightString()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontWeightString START");

            string fontWeightString;

            fontWeightString = TextMapHelper.GetFontWeightString(FontWeightType.Light);
            Assert.AreEqual("light", fontWeightString, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFontWeightString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontSlantString.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontSlantString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontSlantString()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontSlantString START");

            string fontSlantString;

            fontSlantString = TextMapHelper.GetFontSlantString(FontSlantType.Italic);
            Assert.AreEqual("italic", fontSlantString, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFontSlantString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontWidthType.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontWidthType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontWidthType()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontWidthType START");

            FontWidthType fontWidthType;
            
            fontWidthType = TextMapHelper.GetFontWidthType("ExtraCondensed");
            Assert.AreEqual(FontWidthType.ExtraCondensed, fontWidthType, "Should be equal!");

            fontWidthType = TextMapHelper.GetFontWidthType("InvalidType");
            Assert.AreEqual(FontWidthType.None, fontWidthType, "If invalid type, should be None type!");

            tlog.Debug(tag, $"TextMapHelperGetFontWidthType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontWeightType.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontWeightType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontWeightType()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontWeightType START");

            FontWeightType fontWeightType;
            
            fontWeightType = TextMapHelper.GetFontWeightType("Light");
            Assert.AreEqual(FontWeightType.Light, fontWeightType, "Should be equal!");

            fontWeightType = TextMapHelper.GetFontWeightType("InvalidType");
            Assert.AreEqual(FontWeightType.None, fontWeightType, "If invalid type, should be None type!");

            tlog.Debug(tag, $"TextMapHelperGetFontWeightType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontSlantType.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontSlantType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontSlantType()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontSlantType START");

            FontSlantType fontSlantType;
            
            fontSlantType = TextMapHelper.GetFontSlantType("Italic");
            Assert.AreEqual(FontSlantType.Italic, fontSlantType, "Should be equal!");

            fontSlantType = TextMapHelper.GetFontSlantType("InvalidType");
            Assert.AreEqual(FontSlantType.None, fontSlantType, "If invalid type, should be None type!");

            tlog.Debug(tag, $"TextMapHelperGetFontSlantType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontStyleMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontStyleMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontStyleMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontStyleMap START");

            var fontStyle = new Tizen.NUI.Text.FontStyle()
            {
                Width = FontWidthType.Expanded,
                Weight = FontWeightType.Bold,
                Slant = FontSlantType.Italic
            };

            var map = TextMapHelper.GetFontStyleMap(fontStyle);
            map["width"].Get(out string width);
            map["weight"].Get(out string weight);
            map["slant"].Get(out string slant);

            Assert.AreEqual("expanded", width, "Should be equal!");
            Assert.AreEqual("bold", weight, "Should be equal!");
            Assert.AreEqual("italic", slant, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFontStyleMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontStyleStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontStyleStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontStyleStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontStyleStruct START");

            var map = new PropertyMap();
            map.Add("width", new PropertyValue("expanded"));
            map.Add("weight", new PropertyValue("bold"));
            map.Add("slant", new PropertyValue("italic"));

            FontStyle fontStyle = TextMapHelper.GetFontStyleStruct(map);
            Assert.AreEqual(FontWidthType.Expanded, fontStyle.Width, "Should be equal!");
            Assert.AreEqual(FontWeightType.Bold, fontStyle.Weight, "Should be equal!");
            Assert.AreEqual(FontSlantType.Italic, fontStyle.Slant, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFontStyleStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetInputFilterMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetInputFilterMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetInputFilterMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetInputFilterMap START");

            var inputFilter = new Tizen.NUI.Text.InputFilter()
            {
                Accepted = @"[\d]",
                Rejected = "[0-3]"
            };

            var map = TextMapHelper.GetInputFilterMap(inputFilter);
            map.Find(0).Get(out string accepted);
            map.Find(1).Get(out string rejected);

            Assert.AreEqual(accepted, inputFilter.Accepted, "Should be equal!");
            Assert.AreEqual(rejected, inputFilter.Rejected, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetInputFilterMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetInputFilterStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetInputFilterStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGGetInputFilterStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetInputFilterStruct START");

            var map = new PropertyMap();
            map.Add(0, new PropertyValue(@"[\d]"));
            map.Add(1, new PropertyValue("[0-3]"));

            var inputFilter = TextMapHelper.GetInputFilterStruct(map);
            Assert.AreEqual(@"[\d]", inputFilter.Accepted, "Should be equal!");
            Assert.AreEqual("[0-3]", inputFilter.Rejected, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetInputFilterStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetUnderlineMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetUnderlineMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetUnderlineMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetUnderlineMap START");

            var underline = new Tizen.NUI.Text.Underline()
            {
                Enable = true,
                Color = new Color("#3498DB"),
                Height = 2.0f
            };

            var map = TextMapHelper.GetUnderlineMap(underline);
            var color = new Color();
            map.Find(0, "enable").Get(out bool enable);
            map.Find(0, "color").Get(color);
            map.Find(0, "height").Get(out float height);

            Assert.AreEqual(enable, underline.Enable, "Should be equal!");
            Assert.AreEqual(height, underline.Height, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, underline.Color), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetUnderlineMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetUnderlineStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetUnderlineStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetUnderlineStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetUnderlineStruct START");

            var map = new PropertyMap();
            var color = new Color("#3498DB");
            map.Add("enable", new PropertyValue(true));
            map.Add("color", new PropertyValue(color));
            map.Add("height", new PropertyValue((float)2.0f));

            var underline = TextMapHelper.GetUnderlineStruct(map);

            Assert.AreEqual(true, underline.Enable, "Should be equal!");
            Assert.AreEqual(2.0f, underline.Height, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, underline.Color), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetUnderlineStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetShadowMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetShadowMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetShadowMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetShadowMap START");

            var shadow = new Tizen.NUI.Text.Shadow()
            {
                Offset = new Vector2(3, 3),
                Color = new Color("#F1C40F"),
                BlurRadius = 2.0f,
            };

            var map = TextMapHelper.GetShadowMap(shadow);
            var offset = new Vector2();
            var color = new Color();
            map.Find(0, "offset").Get(offset);
            map.Find(0, "color").Get(color);
            map.Find(0, "blurRadius").Get(out float blurRadius);

            Assert.AreEqual(blurRadius, shadow.BlurRadius, "Should be equal!");
            Assert.AreEqual(offset.X, shadow.Offset.X, "Should be equal!");
            Assert.AreEqual(offset.Y, shadow.Offset.Y, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, shadow.Color), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetShadowMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetShadowStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetShadowStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetShadowStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetShadowStruct START");

            var offset = new Vector2(5, 5);
            var color = new Color("#F1C40F");
            float blurRadius = 5.0f;

            var map = new PropertyMap();
            map.Add("offset", new PropertyValue(offset));
            map.Add("color", new PropertyValue(color));
            map.Add("blurRadius", new PropertyValue((float)blurRadius));

            var shadow = TextMapHelper.GetShadowStruct(map);

            Assert.AreEqual(blurRadius, shadow.BlurRadius, "Should be equal!");
            Assert.AreEqual(offset.X, shadow.Offset.X, "Should be equal!");
            Assert.AreEqual(offset.Y, shadow.Offset.Y, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, shadow.Color), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetShadowStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetOutlineMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetOutlineMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextMapHelperGetOutlineMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetOutlineMap START");

            var outline = new Tizen.NUI.Text.Outline()
            {
                Width = 2.0f,
                Color = new Color("#45B39D"),
            };

            var map = TextMapHelper.GetOutlineMap(outline);
            var color = new Color();
            map.Find(0, "color").Get(color);
            map.Find(0, "width").Get(out float width);

            Assert.AreEqual(width, outline.Width, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, outline.Color), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetOutlineMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetOutlineStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetOutlineStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextMapHelperGetOutlineStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetOutlineStruct START");

            var width = 2.0f;
            var color = new Color("#45B39D");

            var map = new PropertyMap();
            map.Add("color", new PropertyValue(color));
            map.Add("width", new PropertyValue((float)width));

            var outline = TextMapHelper.GetOutlineStruct(map);
            Assert.AreEqual(width, outline.Width, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, outline.Color), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetOutlineStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontSizeString.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontSizeString M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontSizeString()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontSizeString START");

            string fontSizeTypeString = TextMapHelper.GetFontSizeString(FontSizeType.PointSize);
            Assert.AreEqual("pointSize", fontSizeTypeString, "Should be equal!");

            fontSizeTypeString = TextMapHelper.GetFontSizeString(FontSizeType.PixelSize);
            Assert.AreEqual("pixelSize", fontSizeTypeString, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFontSizeString END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFontSizeType.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFontSizeType M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFontSizeType()
        {
            tlog.Debug(tag, $"TextMapHelperGetFontSizeType START");
 
            FontSizeType fontSizeType;

            fontSizeType = TextMapHelper.GetFontSizeType("PointSize");
            Assert.AreEqual(FontSizeType.PointSize, fontSizeType, "Should be equal!");

            fontSizeType = TextMapHelper.GetFontSizeType("PixelSize");
            Assert.AreEqual(FontSizeType.PixelSize, fontSizeType, "Should be equal!");

            fontSizeType = TextMapHelper.GetFontSizeType("InvalidType");
            Assert.AreEqual(FontSizeType.PointSize, fontSizeType, "If invalid type, should be PointSize type!");
      
            tlog.Debug(tag, $"TextMapHelperGetFontSizeType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetTextFitMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetTextFitMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetTextFitMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetTextFitMap START");

            var textFit = new Tizen.NUI.Text.TextFit()
            {
                Enable = true,
                MinSize = 10.0f,
                MaxSize = 100.0f,
                StepSize = 5.0f,
                FontSizeType = FontSizeType.PointSize
            };

            var map = TextMapHelper.GetTextFitMap(textFit);
            map.Find(0, "enable").Get(out bool enable);
            map.Find(0, "minSize").Get(out float minSize);
            map.Find(0, "maxSize").Get(out float maxSize);
            map.Find(0, "stepSize").Get(out float stepSize);
            map.Find(0, "fontSizeType").Get(out string fontSizeType);

            Assert.AreEqual(enable, textFit.Enable, "Should be equal!");
            Assert.AreEqual(minSize, textFit.MinSize, "Should be equal!");
            Assert.AreEqual(maxSize, textFit.MaxSize, "Should be equal!");
            Assert.AreEqual(stepSize, textFit.StepSize, "Should be equal!");
            Assert.AreEqual(fontSizeType, "pointSize", "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetTextFitMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetTextFitStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetTextFitStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetTextFitStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetTextFitStruct START");

            bool enable = true;
            float minSize = 10.0f;
            float maxSize = 100.0f;
            float stepSize = 5.0f;

            var map = new PropertyMap();
            map.Add("enable", new PropertyValue(enable));
            map.Add("minSize", new PropertyValue((float)minSize));
            map.Add("maxSize", new PropertyValue((float)maxSize));
            map.Add("stepSize", new PropertyValue((float)stepSize));
            map.Add("fontSizeType", new PropertyValue("pointSize"));

            var textFit = TextMapHelper.GetTextFitStruct(map);

            Assert.AreEqual(enable, textFit.Enable, "Should be equal!");
            Assert.AreEqual(minSize, textFit.MinSize, "Should be equal!");
            Assert.AreEqual(maxSize, textFit.MaxSize, "Should be equal!");
            Assert.AreEqual(stepSize, textFit.StepSize, "Should be equal!");
            Assert.AreEqual(FontSizeType.PointSize, textFit.FontSizeType, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetTextFitStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetPlaceholderMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetPlaceholderMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetPlaceholderMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetPlaceholderMap START");

            var placeholder = new Tizen.NUI.Text.Placeholder()
            {
                Text = "placeholder text",
                TextFocused = "placeholder textFocused",
                Color = new Color("#45B39D"),
                FontFamily = "BreezeSans",
                FontStyle = new Tizen.NUI.Text.FontStyle()
                {
                    Width = FontWidthType.Expanded,
                    Weight = FontWeightType.Bold,
                    Slant = FontSlantType.Italic,
                },
                PointSize = 25.0f,
                Ellipsis = true
            };

            string text = "";
            string textFocused = "";
            Color color = new Color();
            string fontFamily = null;
            var fontStyle = new PropertyMap();
            float pointSize;
            bool ellipsis = false;

            var map = TextMapHelper.GetPlaceholderMap(placeholder);
            map.Find(0).Get(out text);
            map.Find(1).Get(out textFocused);
            map.Find(2).Get(color);
            map.Find(3).Get(out fontFamily);
            map.Find(4).Get(fontStyle);
            map.Find(5).Get(out pointSize);
            map.Find(7).Get(out ellipsis);

            fontStyle["width"].Get(out string width);
            fontStyle["weight"].Get(out string weight);
            fontStyle["slant"].Get(out string slant);

            Assert.AreEqual(text, placeholder.Text, "Should be equal!");
            Assert.AreEqual(textFocused, placeholder.TextFocused, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, placeholder.Color), "Should be true!");
            Assert.AreEqual(fontFamily, placeholder.FontFamily, "Should be equal!");
            Assert.AreEqual(width, "expanded", "Should be equal!");
            Assert.AreEqual(weight, "bold", "Should be equal!");
            Assert.AreEqual(slant, "italic", "Should be equal!");
            Assert.AreEqual(pointSize, placeholder.PointSize, "Should be equal!");
            Assert.AreEqual(ellipsis, placeholder.Ellipsis, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetPlaceholderMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetPlaceholderStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetPlaceholderStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetPlaceholderStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetPlaceholderStruct START");

            string text = "placeholder text";
            string textFocused = "placeholder textFocused";
            Color color = new Color("#45B39D");
            string fontFamily = "BreezeSans";
            var fontStyle = new PropertyMap();
            fontStyle.Add("width", new PropertyValue("expanded"));
            fontStyle.Add("weight", new PropertyValue("bold"));
            fontStyle.Add("slant", new PropertyValue("italic"));
            float pointSize = 25.0f;
            bool ellipsis = false;

            var map = new PropertyMap();
            map.Add(0, new PropertyValue(text));
            map.Add(1, new PropertyValue(textFocused));
            map.Add(2, new PropertyValue(color));
            map.Add(3, new PropertyValue(fontFamily));
            map.Add(4, new PropertyValue(fontStyle));
            map.Add(5, new PropertyValue((float)pointSize));
            map.Add(7, new PropertyValue(ellipsis));

            var placeholder = TextMapHelper.GetPlaceholderStruct(map);

            Assert.AreEqual(text, placeholder.Text, "Should be equal!");
            Assert.AreEqual(textFocused, placeholder.TextFocused, "Should be equal!");
            Assert.AreEqual(true, CheckColor(color, placeholder.Color), "Should be true!");
            Assert.AreEqual(fontFamily, placeholder.FontFamily, "Should be equal!");
            Assert.AreEqual(FontWidthType.Expanded, placeholder.FontStyle?.Width, "Should be equal!");
            Assert.AreEqual(FontWeightType.Bold, placeholder.FontStyle?.Weight, "Should be equal!");
            Assert.AreEqual(FontSlantType.Italic, placeholder.FontStyle?.Slant, "Should be equal!");
            Assert.AreEqual(pointSize, placeholder.PointSize, "Should be equal!");
            Assert.AreEqual(ellipsis, false, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetPlaceholderStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetHiddenInputMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetHiddenInputMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetHiddenInputMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetHiddenInputMap START");

            var hiddenInput = new Tizen.NUI.Text.HiddenInput()
            {
                Mode = HiddenInputModeType.ShowLastCharacter,
                SubstituteCharacter = '★',
                SubstituteCount = 0,
                ShowLastCharacterDuration = 1000
            };

            var map = TextMapHelper.GetHiddenInputMap(hiddenInput);

            map.Find(0).Get(out int mode);
            map.Find(1).Get(out int substituteCharacter);
            map.Find(2).Get(out int substituteCount);
            map.Find(3).Get(out int showLastCharacterDuration);

            Assert.AreEqual(mode, (int)hiddenInput.Mode, "Should be equal!");
            Assert.AreEqual(substituteCharacter, Convert.ToInt32(hiddenInput.SubstituteCharacter), "Should be equal!");
            Assert.AreEqual(substituteCount, hiddenInput.SubstituteCount, "Should be equal!");
            Assert.AreEqual(showLastCharacterDuration, hiddenInput.ShowLastCharacterDuration, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetHiddenInputMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetHiddenInputStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetHiddenInputStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetHiddenInputStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetHiddenInputStruct START");

            int mode = (int)HiddenInputModeType.ShowLastCharacter;
            int substituteCharacter = Convert.ToInt32('★');
            int substituteCount = 0;
            int showLastCharacterDuration = 1000;

            var map = new PropertyMap();
            map.Add(0, new PropertyValue(mode));
            map.Add(1, new PropertyValue(substituteCharacter));
            map.Add(2, new PropertyValue(substituteCount));
            map.Add(3, new PropertyValue(showLastCharacterDuration));

            var hiddenInput = TextMapHelper.GetHiddenInputStruct(map);

            Assert.AreEqual(mode, (int)hiddenInput.Mode, "Should be equal!");
            Assert.AreEqual(substituteCharacter, Convert.ToInt32(hiddenInput.SubstituteCharacter), "Should be equal!");
            Assert.AreEqual(substituteCount, hiddenInput.SubstituteCount, "Should be equal!");
            Assert.AreEqual(showLastCharacterDuration, hiddenInput.ShowLastCharacterDuration, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetHiddenInputStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFileNameMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFileNameMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFileNameMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetFileNameMap START");

            string url = "filePath";

            var map = TextMapHelper.GetFileNameMap(url);
            map.Find(0, "filename").Get(out string fileName);

            Assert.AreEqual(url, fileName, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFileNameMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetSelectionHandleImageStruct.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetSelectionHandleImageStruct M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetSelectionHandleImageStruct()
        {
            tlog.Debug(tag, $"TextMapHelperGetSelectionHandleImageStruct START");

            string leftImageUrl = "leftImageUrl";
            string rightImageUrl = "rightImageUrl";

            var leftImageMap = new PropertyMap().Add("filename", new PropertyValue(leftImageUrl));
            var rightImageMap = new PropertyMap().Add("filename", new PropertyValue(rightImageUrl));

            var selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);

            Assert.AreEqual(leftImageUrl, selectionHandleImage.LeftImageUrl, "Should be equal!");
            Assert.AreEqual(rightImageUrl, selectionHandleImage.RightImageUrl, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetSelectionHandleImageStruct END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetCamelCase.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetCamelCase M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetCamelCase()
        {
            tlog.Debug(tag, $"TextMapHelperGetCamelCase START");

            string pascalCase = "TextMapHelper";
            string camelCase = "textMapHelper";
            string expectedResult = TextMapHelper.GetCamelCase(pascalCase);

            Assert.AreEqual(camelCase, expectedResult, "Should be equal!");

            string emptyString = "";
            expectedResult = TextMapHelper.GetCamelCase(emptyString);            

            Assert.AreEqual(emptyString, expectedResult, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetCamelCase END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetStringFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetStringFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetStringFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetStringFromMap START");

            var stringKey = "width";
            var stringInvalidKey = "invalidKey";
            var intKey = 1;
            var intInvalidKey = 10;
            var value = "expanded";
            var defaultValue = "none";

            var map = new PropertyMap();
            map.Add(stringKey, new PropertyValue(value));
            map.Add(intKey, new PropertyValue(value));

            var result = TextMapHelper.GetStringFromMap(map, stringKey, defaultValue);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetStringFromMap(map, stringInvalidKey, defaultValue);
            Assert.AreEqual(defaultValue, result, "Should be equal!");

            result = TextMapHelper.GetStringFromMap(map, intKey, defaultValue);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetStringFromMap(map, intInvalidKey, defaultValue);
            Assert.AreEqual(defaultValue, result, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetStringFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetBoolFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetBoolFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetBoolFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetBoolFromMap START");

            var stringKey = "width";
            var stringInvalidKey = "invalidKey";
            var intKey = 1;
            var intInvalidKey = 10;
            var value = true;
            var defaultValue = false;

            var map = new PropertyMap();
            map.Add(stringKey, new PropertyValue(value));
            map.Add(intKey, new PropertyValue(value));

            var result = TextMapHelper.GetBoolFromMap(map, stringKey, defaultValue);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetBoolFromMap(map, stringInvalidKey, defaultValue);
            Assert.AreEqual(defaultValue, result, "Should be equal!");

            result = TextMapHelper.GetBoolFromMap(map, intKey, defaultValue);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetBoolFromMap(map, intInvalidKey, defaultValue);
            Assert.AreEqual(defaultValue, result, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetBoolFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetIntFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetIntFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetIntFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetIntFromMap START");

            var intKey = 1;
            var intInvalidKey = 10;
            var value = 3080;
            var defaultValue = 0;

            var map = new PropertyMap();
            map.Add(intKey, new PropertyValue(value));

            var result = TextMapHelper.GetIntFromMap(map, intKey, defaultValue);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetIntFromMap(map, intInvalidKey, defaultValue);
            Assert.AreEqual(defaultValue, result, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetIntFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetFloatFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetFloatFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetFloatFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetFloatFromMap START");

            var stringKey = "width";
            var stringInvalidKey = "invalidKey";
            float value = 3.14f;
            float defaultValue = 0.0f;

            var map = new PropertyMap();
            map.Add(stringKey, new PropertyValue(value));

            var result = TextMapHelper.GetFloatFromMap(map, stringKey, defaultValue);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetFloatFromMap(map, stringInvalidKey, defaultValue);
            Assert.AreEqual(defaultValue, result, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetFloatFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetColorFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetColorFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetColorFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetColorFromMap START");

            var stringKey = "color";
            var stringInvalidKey = "invalidKey";
            var intKey = 1;
            var value = new Color(1.0f, 0.2f, 0.5f, 1.0f);

            var map = new PropertyMap();
            map.Add(stringKey, new PropertyValue(value));
            map.Add(intKey, new PropertyValue(value));

            var result = TextMapHelper.GetColorFromMap(map, stringKey);
            Assert.AreEqual(true, CheckColor(value, result), "Should be true!");

            result = TextMapHelper.GetColorFromMap(map, intKey);
            Assert.AreEqual(true, CheckColor(value, result), "Should be true!");

            tlog.Debug(tag, $"TextMapHelperGetColorFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetVector2FromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetVector2FromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetVector2FromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetVector2FromMap START");

            var stringKey = "position";
            var stringInvalidKey = "invalidKey";
            var value = new Vector2(3, 10);

            var map = new PropertyMap();
            map.Add(stringKey, new PropertyValue(value));

            var result = TextMapHelper.GetVector2FromMap(map, stringKey);
            Assert.AreEqual(value.X, result.X, "Should be equal!");
            Assert.AreEqual(value.Y, result.Y, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetVector2FromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetMapFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetMapFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetMapFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetMapFromMap START");

            var intKey = 1;
            var value = new PropertyMap();
            value.Add("width", new PropertyValue(10));
            value.Add("height", new PropertyValue(20));

            var map = new PropertyMap();
            map.Add(intKey, new PropertyValue(value));

            var result = TextMapHelper.GetMapFromMap(map, intKey);
            result.Find(0, "width").Get(out int width);
            result.Find(0, "height").Get(out int height);
            Assert.AreEqual(10, width, "Should be equal!");
            Assert.AreEqual(20, height, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetMapFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetNullableIntFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetNullableIntFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetNullableIntFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetNullableIntFromMap START");

            var intKey = 1;
            var intInvalidKey = 10;
            int value = 3080;
            int? result = null;

            var map = new PropertyMap();
            map.Add(intKey, new PropertyValue(value));

            result = TextMapHelper.GetNullableIntFromMap(map, intKey);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetNullableIntFromMap(map, intInvalidKey);
            Assert.AreEqual(null, result, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetNullableIntFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper GetNullableFloatFromMap.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.GetNullableFloatFromMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperGetNullableFloatFromMap()
        {
            tlog.Debug(tag, $"TextMapHelperGetNullableFloatFromMap START");

            var intKey = 1;
            var intInvalidKey = 10;
            float value = 3.14f;
            float? result = null;

            var map = new PropertyMap();
            map.Add(intKey, new PropertyValue(value));

            result = TextMapHelper.GetNullableFloatFromMap(map, intKey);
            Assert.AreEqual(value, result, "Should be equal!");

            result = TextMapHelper.GetNullableFloatFromMap(map, intInvalidKey);
            Assert.AreEqual(null, result, "Should be equal!");

            tlog.Debug(tag, $"TextMapHelperGetNullableFloatFromMap END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextMapHelper IsValue.")]
        [Property("SPEC", "Tizen.NUI.TextMapHelper.IsValue M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "bowon.ryu@samsung.com")]
        public void TextMapHelperIsValue()
        {
            tlog.Debug(tag, $"TextMapHelperIsValue START");

            var intKey = 1;
            var intInvalidKey = 10;
            var value = "value";
            
            var map = new PropertyMap();
            map.Add(intKey, new PropertyValue(value));

            var result = TextMapHelper.IsValue(map, intKey);
            Assert.AreEqual(true, result, "Should be true!");

            result = TextMapHelper.IsValue(map, intInvalidKey);
            Assert.AreEqual(false, result, "Should be false!");

            tlog.Debug(tag, $"TextMapHelperIsValue END (OK)");
        }
    }
}
