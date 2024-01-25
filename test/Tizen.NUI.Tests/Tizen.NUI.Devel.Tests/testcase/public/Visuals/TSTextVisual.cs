using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Visuals/TextVisual")]
    public class PublicTextVisualTest
    {
        private const string tag = "NUITEST";
        private static bool flagComposingPropertyMap;
        internal class MyTextVisual : TextVisual
        {
            protected override void ComposingPropertyMap()
            {
                flagComposingPropertyMap = true;
                base.ComposingPropertyMap();
            }
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
        [Description("TextVisual constructor.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.TextVisual C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualConstructor()
        {
            tlog.Debug(tag, $"TextVisualConstructor START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual Text.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Text A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualText()
        {
            tlog.Debug(tag, $"TextVisualText START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            testingTarget.Text = "Text";
            Assert.AreEqual("Text", testingTarget.Text, "Retrieved Text should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualText END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual FontFamily.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.FontFamily A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualFontFamily()
        {
            tlog.Debug(tag, $"TextVisualFontFamily START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            testingTarget.FontFamily = "FontFamily";
            Assert.AreEqual("FontFamily", testingTarget.FontFamily, "Retrieved FontFamily should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualFontFamily END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual FontStyle.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.FontStyle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualFontStyle()
        {
            tlog.Debug(tag, $"TextVisualFontStyle START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            PropertyMap fontStyleMapSet = new PropertyMap();
            fontStyleMapSet.Add("weight", new PropertyValue("bold"));
            fontStyleMapSet.Add("width", new PropertyValue("condensed"));
            fontStyleMapSet.Add("slant", new PropertyValue("italic"));

            testingTarget.FontStyle = fontStyleMapSet;
                
            PropertyMap fontStyleMapGet = new PropertyMap();
            fontStyleMapGet = testingTarget.FontStyle;
            Assert.IsNotNull(fontStyleMapGet, "Should not be null");

            string str = "";
            fontStyleMapGet.Find(0, "weight").Get(out str);
            Assert.AreEqual("bold", str, "fontStyleMapGet.Find(\"weight\") should equals to the set value");
            fontStyleMapGet.Find(1, "width").Get(out str);
            Assert.AreEqual("condensed", str, "fontStyleMapGet.Find(\"width\") should equals to the set value");
            fontStyleMapGet.Find(2, "slant").Get(out str);
            Assert.AreEqual("italic", str, "fontStyleMapGet.Find(\"slant\") should equals to the set value");

            fontStyleMapSet.Dispose();
            fontStyleMapGet.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualFontStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual PointSize.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.PointSize A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualPointSize()
        {
            tlog.Debug(tag, $"TextVisualPointSize START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            testingTarget.PointSize = 1.0f;
            Assert.AreEqual(1.0f, testingTarget.PointSize, "Retrieved PointSize should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualPointSize END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual MultiLine.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.MultiLine A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualMultiLine()
        {
            tlog.Debug(tag, $"TextVisualMultiLine START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            testingTarget.MultiLine = true;
            Assert.AreEqual(true, testingTarget.MultiLine, "Retrieved MultiLine should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualMultiLine END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual HorizontalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.HorizontalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualHorizontalAlignment()
        {
            tlog.Debug(tag, $"TextVisualHorizontalAlignment START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            Assert.AreEqual(HorizontalAlignment.Begin, testingTarget.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");

            testingTarget.HorizontalAlignment = HorizontalAlignment.Center;
            Assert.AreEqual(HorizontalAlignment.Center, testingTarget.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");

            testingTarget.HorizontalAlignment = HorizontalAlignment.End;
            Assert.AreEqual(HorizontalAlignment.End, testingTarget.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");

            testingTarget.HorizontalAlignment = HorizontalAlignment.Begin;
            Assert.AreEqual(HorizontalAlignment.Begin, testingTarget.HorizontalAlignment, "Retrieved HorizontalAlignment should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualHorizontalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual VerticalAlignment.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.VerticalAlignment A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualVerticalAlignment()
        {
            tlog.Debug(tag, $"TextVisualVerticalAlignment START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            Assert.AreEqual(VerticalAlignment.Top, testingTarget.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");

            testingTarget.VerticalAlignment = VerticalAlignment.Center;
            Assert.AreEqual(VerticalAlignment.Center, testingTarget.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");

            testingTarget.VerticalAlignment = VerticalAlignment.Bottom;
            Assert.AreEqual(VerticalAlignment.Bottom, testingTarget.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");

            testingTarget.VerticalAlignment = VerticalAlignment.Top;
            Assert.AreEqual(VerticalAlignment.Top, testingTarget.VerticalAlignment, "Retrieved VerticalAlignment should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualVerticalAlignment END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual TextColor.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.TextColor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualTextColor()
        {
            tlog.Debug(tag, $"TextVisualTextColor START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            using (Color color = new Color(1.0f, 1.0f, 1.0f, 1.0f))
            {
                testingTarget.TextColor = color;
                Assert.AreEqual(1.0f, testingTarget.TextColor.R, "Retrieved TextColor.R should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.TextColor.G, "Retrieved TextColor.G should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.TextColor.B, "Retrieved TextColor.B should be equal to set value");
                Assert.AreEqual(1.0f, testingTarget.TextColor.A, "Retrieved TextColor.A should be equal to set value");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualTextColor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual EnableMarkup.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.EnableMarkup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualEnableMarkup()
        {
            tlog.Debug(tag, $"TextVisualEnableMarkup START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            testingTarget.EnableMarkup = true;
            Assert.AreEqual(true, testingTarget.EnableMarkup, "Retrieved EnableMarkup should be equal to set value");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualEnableMarkup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual Shadow.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Shadow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualShadow()
        {
            tlog.Debug(tag, $"TextVisualShadow START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            PropertyMap shadowMapSet = new PropertyMap();
            shadowMapSet.Add("color", new PropertyValue(new Color(1.0f, 0.1f, 0.3f, 0.5f)));
            shadowMapSet.Add("offset", new PropertyValue(new Vector2(2.0f, 1.0f)));
            shadowMapSet.Add("blurRadius", new PropertyValue(3.0f));
            testingTarget.Shadow = shadowMapSet;

            PropertyMap shadowMapGet = new PropertyMap();
            shadowMapGet = testingTarget.Shadow;
            Assert.IsNotNull(shadowMapGet, "Should not be null");

            using (Color color = new Color())
            {
                shadowMapGet["color"].Get(color);
                Assert.AreEqual(1.0f, color.R, "Retrieved color.R should be equal to set value");
                Assert.AreEqual(0.1f, color.G, "Retrieved color.G should be equal to set value");
                Assert.AreEqual(0.3f, color.B, "Retrieved color.B should be equal to set value");
                Assert.AreEqual(0.5f, color.A, "Retrieved color.A should be equal to set value");
            }

            using (Vector2 vector2 = new Vector2())
            {
                shadowMapGet["offset"].Get(vector2);
                Assert.AreEqual(2.0f, vector2.X, "Retrieved vector2.X should be equal to set value");
                Assert.AreEqual(1.0f, vector2.Y, "Retrieved vector2.Y should be equal to set value");
            }

            float blurRadius;
            shadowMapGet["blurRadius"].Get(out blurRadius);
            Assert.AreEqual(3.0f, blurRadius, "Retrieved blurRadius should equals to the set value");

            shadowMapSet.Dispose();
            shadowMapGet.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualShadow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual Underline.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Underline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualUnderline()
        {
            tlog.Debug(tag, $"TextVisualUnderline START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            PropertyMap underlineMapSet = new PropertyMap();
            underlineMapSet.Add("enable", new PropertyValue("true"));
            underlineMapSet.Add("color", new PropertyValue("green"));
            underlineMapSet.Add("height", new PropertyValue("1"));
            testingTarget.Underline = underlineMapSet;

            PropertyMap underlineMapGet = new PropertyMap();
            underlineMapGet = testingTarget.Underline;
            Assert.IsNotNull(underlineMapGet, "Should not be null");

            string str = "";
            underlineMapGet["enable"].Get(out str);
            Assert.AreEqual("true", str, "Retrieved enable should equals to the set value");
            underlineMapGet["color"].Get(out str);
            Assert.AreEqual("green", str, "Retrieved color should equals to the set value");
            underlineMapGet["height"].Get(out str);
            Assert.AreEqual("1", str, "Retrieved height should equals to the set value");

            underlineMapGet.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualUnderline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual Outline.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Outline A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.comm")]
        public void TextVisualOutline()
        {
            tlog.Debug(tag, $"TextVisualOutline START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            PropertyMap outlineMapSet = new PropertyMap();
            outlineMapSet.Add("color", new PropertyValue(new Color(1.0f, 0.1f, 0.3f, 0.5f)));
            outlineMapSet.Add("width", new PropertyValue("1"));
            testingTarget.Outline = outlineMapSet;

            PropertyMap outlineMapGet = new PropertyMap();
            outlineMapGet = testingTarget.Outline;
            Assert.IsNotNull(outlineMapGet, "Should not be null");

            using (Color color = new Color())
            {
                outlineMapGet["color"].Get(color);
                Assert.AreEqual(1.0f, color.R, "Retrieved color.R should be equal to set value");
                Assert.AreEqual(0.1f, color.G, "Retrieved color.G should be equal to set value");
                Assert.AreEqual(0.3f, color.B, "Retrieved color.B should be equal to set value");
                Assert.AreEqual(0.5f, color.A, "Retrieved color.A should be equal to set value");
            }

            string str = "";
            outlineMapGet["width"].Get(out str);
            Assert.AreEqual("1", str, "Retrieved width should equals to the set value");

            outlineMapSet.Dispose();
            outlineMapGet.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualOutline END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual Background.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.Background A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.comm")]
        public void TextVisualBackground()
        {
            tlog.Debug(tag, $"TextVisualBackground START");

            var testingTarget = new TextVisual();
            Assert.IsNotNull(testingTarget, "Can't create success object TextVisual");
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");

            PropertyMap backgroundMapSet = new PropertyMap();
            backgroundMapSet.Add("enable", new PropertyValue(true));
            backgroundMapSet.Add("color", new PropertyValue(new Color(1.0f, 0.1f, 0.3f, 0.5f)));
            testingTarget.Background = backgroundMapSet;

            PropertyMap backgroundMapGet = new PropertyMap();
            backgroundMapGet = testingTarget.Background;
            Assert.IsNotNull(backgroundMapGet, "Should not be null");

            bool enable = false;
            backgroundMapGet["enable"].Get(out enable);
            Assert.AreEqual(true, enable, "Retrieved enable should equals to the set value");

            using (Color color = new Color())
            {
                backgroundMapGet["color"].Get(color);
                Assert.AreEqual(1.0f, color.R, "Retrieved color.R should be equal to set value");
                Assert.AreEqual(0.1f, color.G, "Retrieved color.G should be equal to set value");
                Assert.AreEqual(0.3f, color.B, "Retrieved color.B should be equal to set value");
                Assert.AreEqual(0.5f, color.A, "Retrieved color.A should be equal to set value");
            }

            backgroundMapSet.Dispose();
            backgroundMapGet.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualBackground END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TextVisual ComposingPropertyMap.")]
        [Property("SPEC", "Tizen.NUI.TextVisual.ComposingPropertyMap M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TextVisualComposingPropertyMap()
        {
            tlog.Debug(tag, $"TextVisualComposingPropertyMap START");

            flagComposingPropertyMap = false;
            Assert.False(flagComposingPropertyMap, "flagComposingPropertyMap should false initial");

            var testingTarget = new MyTextVisual()
            {
                Text = "Text",
                PointSize = 1.0f,
                FontFamily = "FontFamily",
                FontStyle = new PropertyMap(),
                MultiLine = true,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = new Color(1.0f, 0.3f, 0.5f, 1.0f),
                EnableMarkup = true,
                Shadow = new PropertyMap(),
                Underline = new PropertyMap(),
                Outline = new PropertyMap(),
                Background = new PropertyMap() 
            };
            Assert.IsInstanceOf<TextVisual>(testingTarget, "Should be an instance of TextVisual type.");
            PropertyMap propertyMap = testingTarget.OutputVisualMap;
            Assert.True(flagComposingPropertyMap, "ComposingPropertyMap overrided method not invoked.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TextVisualComposingPropertyMap END (OK)");
        }
    }
}
