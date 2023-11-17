using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/Style/TextFieldStyle")]
    public class PublicBaseComponentsStyleTextFieldStyleTest
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
        [Description("TextFieldStyle TextFieldStyle.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Style.TextFieldStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseComponentsStyleTextFieldStyle()
        {
            tlog.Debug(tag, $"BaseComponentsStyleTextFieldStyle START");

            var testingTarget = new TextFieldStyle();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TextFieldStyle>(testingTarget, "should be an instance of TextFieldStyle class!");

            try
            {
                testingTarget.PlaceholderText = "You can input text here!";
                Assert.AreEqual("You can input text here!", testingTarget.PlaceholderText, "Should be equal!");

                testingTarget.PlaceholderTextFocused = "Inputting...";
                Assert.AreEqual("Inputting...", testingTarget.PlaceholderTextFocused, "Should be equal!");

                testingTarget.FontFamily = "SamsungOneUI400";
                Assert.AreEqual("SamsungOneUI400", testingTarget.FontFamily, "Should be equal!");

                testingTarget.MaxLength = 1024;
                Assert.AreEqual(1024, testingTarget.MaxLength, "Should be equal!");

                testingTarget.ExceedPolicy = Interop.TextField.ExceedPolicyGet();
                tlog.Debug(tag, "ExceedPlicy : " + testingTarget.ExceedPolicy);

                testingTarget.HorizontalAlignment = HorizontalAlignment.End;
                Assert.AreEqual(HorizontalAlignment.End, testingTarget.HorizontalAlignment, "Should be equal!");

                testingTarget.VerticalAlignment = VerticalAlignment.Bottom;
                Assert.AreEqual(VerticalAlignment.Bottom, testingTarget.VerticalAlignment, "Should be equal!");

                testingTarget.SecondaryCursorColor = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
                Assert.AreEqual(4.0f, testingTarget.SecondaryCursorColor.A, "Should be equal!");

                testingTarget.EnableCursorBlink = true;
                Assert.IsTrue(testingTarget.EnableCursorBlink);

                testingTarget.CursorBlinkInterval = 0.2f;
                Assert.AreEqual(0.2f, testingTarget.CursorBlinkInterval, "Should be equal!");

                testingTarget.CursorBlinkDuration = 0.2f;
                Assert.AreEqual(0.2f, testingTarget.CursorBlinkDuration, "Should be equal!");

                testingTarget.CursorWidth = 2;
                Assert.AreEqual(2, testingTarget.CursorWidth, "Should be equal!");

                testingTarget.GrabHandleColor = new Color(1.0f, 1.0f, 1.0f, 0.0f);
                Assert.AreEqual(0.0f, testingTarget.GrabHandleColor.A, "Should be equal!");

                testingTarget.GrabHandleImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "GrabHandleImage : " + testingTarget.GrabHandleImage);

                testingTarget.GrabHandlePressedImage = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "GrabHandlePressedImage : " + testingTarget.GrabHandlePressedImage);

                testingTarget.SelectionHandleImageLeft = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downleftW.png"));
                Assert.IsTrue(testingTarget.SelectionHandleImageLeft.Find(-1, "filename").Get(out string left));

                testingTarget.SelectionHandleImageRight = new PropertyMap().Add("filename", new PropertyValue(FrameworkInformation.ResourcePath + "IoT_handler_downrightW.png"));
                Assert.IsTrue(testingTarget.SelectionHandleImageRight.Find(-1, "filename").Get(out string right));

                testingTarget.ScrollThreshold = 2.0f;
                Assert.AreEqual(2.0f, testingTarget.ScrollThreshold, "Should be equal!");

                testingTarget.ScrollSpeed = 2.0f;
                Assert.AreEqual(2.0f, testingTarget.ScrollSpeed, "Should be equal!");

                testingTarget.SelectionHighlightColor = new Vector4(1.0f, 0.3f, 0.0f, 0.8f);
                Assert.AreEqual(0.8f, testingTarget.SelectionHighlightColor.A, "Should be equal!");

                testingTarget.DecorationBoundingBox = new Rectangle(5, 6, 100, 200);
                Assert.AreEqual(5, testingTarget.DecorationBoundingBox.X, "Should be equal!");

                testingTarget.InputColor = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
                Assert.AreEqual(4.0f, testingTarget.InputColor.A, "Should be equal!");

                testingTarget.EnableMarkup = true;
                Assert.IsTrue(testingTarget.EnableMarkup);

                testingTarget.InputFontFamily = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "InputFontFamily : " + testingTarget.InputFontFamily);

                testingTarget.InputPointSize = 1.0f;
                Assert.AreEqual(1.0f, testingTarget.InputPointSize, "Should be equal!");

                testingTarget.InputUnderline = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "InputUnderline : " + testingTarget.InputUnderline);

                testingTarget.InputShadow = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "InputShadow : " + testingTarget.InputShadow);

                testingTarget.Emboss = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "Emboss : " + testingTarget.Emboss);

                testingTarget.InputEmboss = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "InputEmboss : " + testingTarget.InputEmboss);

                testingTarget.InputOutline = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
                tlog.Debug(tag, "InputOutline : " + testingTarget.InputOutline);

                testingTarget.PixelSize = 16.0f;
                Assert.AreEqual(16.0f, testingTarget.PixelSize, "Should be equal!");

                testingTarget.EnableSelection = true;
                Assert.IsTrue(testingTarget.EnableSelection);

                testingTarget.Ellipsis = true;
                Assert.IsTrue(testingTarget.Ellipsis);

                testingTarget.MatchSystemLanguageDirection = true;
                Assert.IsTrue(testingTarget.MatchSystemLanguageDirection);

                testingTarget.TextColor = new Color(0.04f, 0.05f, 0.13f, 1.0f);
                Assert.AreEqual(1.0f, testingTarget.TextColor.A, "Should be equal!");

                testingTarget.PointSize = 16.0f;
                Assert.AreEqual(16.0f, testingTarget.PointSize, "Should be equal!");

                testingTarget.PlaceholderTextColor = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
                Assert.AreEqual(4.0f, testingTarget.PlaceholderTextColor.A, "Should be equal!");

                testingTarget.PrimaryCursorColor = new Vector4(1.0f, 2.0f, 3.0f, 4.0f);
                Assert.AreEqual(4.0f, testingTarget.PrimaryCursorColor.A, "Should be equal!");

                testingTarget.FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular"));
                testingTarget.FontStyle.Find(-1, "weight").Get(out string style);
                Assert.AreEqual("regular", style, "Should be equal!");

                testingTarget.SelectionPopupStyle = new PropertyMap()
                .Add(SelectionPopupStyleProperty.MaxSize, new PropertyValue(new Vector2(1200.0f, 40.0f)))
                .Add(SelectionPopupStyleProperty.DividerSize, new PropertyValue(new Vector2(0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.DividerPadding, new PropertyValue(new Vector4(0.0f, 0.0f, 0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.Background, new PropertyValue(new PropertyMap().Add(ImageVisualProperty.URL, new PropertyValue(FrameworkInformation.ResourcePath + "IoT-selection-popup-background.9.png"))))
                .Add(SelectionPopupStyleProperty.BackgroundBorder, new PropertyValue(new PropertyMap().Add(ImageVisualProperty.URL, new PropertyValue(FrameworkInformation.ResourcePath + "IoT-selection-popup-border.9.png"))))
                .Add(SelectionPopupStyleProperty.PressedColor, new PropertyValue(new Vector4(1.0f, 0.39f, 0.0f, 0.16f)))
                .Add(SelectionPopupStyleProperty.PressedCornerRadius, new PropertyValue(12.0f))
                .Add(SelectionPopupStyleProperty.FadeInDuration, new PropertyValue(0.25f))
                .Add(SelectionPopupStyleProperty.FadeOutDuration, new PropertyValue(0.25f))
                .Add(SelectionPopupStyleProperty.EnableScrollBar, new PropertyValue(false))
                .Add(SelectionPopupStyleProperty.LabelMinimumSize, new PropertyValue(new Vector2(0, 40.0f)))
                .Add(SelectionPopupStyleProperty.LabelPadding, new PropertyValue(new Vector4(-4.0f, -4.0f, 0.0f, 0.0f)))
                .Add(SelectionPopupStyleProperty.LabelTextVisual, new PropertyValue(new PropertyMap()
                    .Add(TextVisualProperty.PointSize, new PropertyValue(6.0f))
                    .Add(TextVisualProperty.TextColor, new PropertyValue(new Vector4(1.00f, 0.38f, 0.00f, 1)))
                    .Add(TextVisualProperty.FontFamily, new PropertyValue("TizenSans"))
                    .Add(TextVisualProperty.FontStyle, new PropertyValue(new PropertyMap().Add("weight", new PropertyValue("regular"))))));

                testingTarget.SelectionPopupStyle.Find(10001016).Get(out float radius);
                Assert.AreEqual(12.0f, radius, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"BaseComponentsStyleTextFieldStyle END (OK)");
        }
    }
}
