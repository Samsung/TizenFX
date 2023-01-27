using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/Style/TextEditorStyle")]
    public class PublicTextEditorStyleTest
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
        [Description("TextEditorStyle TextEditorStyle.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Style.TextEditorStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void publicBaseComponentTextEditorStyleFontFamily()
        {
            tlog.Debug(tag, $"publicBaseComponentTextEditorStyleFontFamily START");

            var testingTarget = new TextEditorStyle();
            Assert.IsNotNull(testingTarget, "should be not null");
			Assert.IsInstanceOf<TextEditorStyle>(testingTarget, "should be an instance of TextEditorStyle class!");

			try
			{
				testingTarget.FontFamily = "BreezeSans";
				Assert.AreEqual("BreezeSans", testingTarget.FontFamily, "Should be equal!");

				testingTarget.HorizontalAlignment = HorizontalAlignment.End;
				Assert.AreEqual(HorizontalAlignment.End, testingTarget.HorizontalAlignment, "Should be equal!");
				
				var temp2 = testingTarget.VerticalAlignment = VerticalAlignment.Bottom;
				Assert.AreEqual(VerticalAlignment.Bottom, testingTarget.VerticalAlignment, "Should be equal!");

				testingTarget.SecondaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1.0f);
				Assert.AreEqual(1.0f, testingTarget.SecondaryCursorColor.A, "Should be equal!");
				
				testingTarget.EnableCursorBlink = true;
				Assert.IsTrue(testingTarget.EnableCursorBlink);

				testingTarget.CursorBlinkInterval = 5.0f;
				Assert.AreEqual(5.0f, testingTarget.CursorBlinkInterval, "Should be equal!");	

				testingTarget.CursorBlinkDuration = 5.0f;
				Assert.AreEqual(5.0f, testingTarget.CursorBlinkDuration, "Should be equal!");				
		
				testingTarget.CursorWidth = 2;
				Assert.AreEqual(2, testingTarget.CursorWidth, "Should be equal!");

				testingTarget.GrabHandleColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
				Assert.AreEqual(1.0f, testingTarget.GrabHandleColor.A, "Should be equal!");	

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

				testingTarget.InputColor = new Vector4(0.04f, 0.05f, 0.13f, 1.0f);
				Assert.AreEqual(1.0f, testingTarget.InputColor.A, "Should be equal!");

				testingTarget.InputFontFamily = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
				tlog.Debug(tag, "InputFontFamily : " + testingTarget.InputFontFamily);

				testingTarget.InputPointSize = 2.0f;
				Assert.AreEqual(2.0f, testingTarget.InputPointSize, "Should be equal!");

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

				testingTarget.PixelSize = 24.0f;
				Assert.AreEqual(24.0f, testingTarget.PixelSize, "Should be equal!");

				testingTarget.EnableSelection = true;
				Assert.IsTrue(testingTarget.EnableSelection);	

				testingTarget.MatchSystemLanguageDirection = true;
				Assert.IsTrue(testingTarget.MatchSystemLanguageDirection);

				testingTarget.TextColor = new Color(0.04f, 0.05f, 0.13f, 1.0f);
				Assert.AreEqual(1.0f, testingTarget.TextColor.A, "Should be equal!");

				testingTarget.PointSize = 2.0f;
				Assert.AreEqual(2.0f, testingTarget.PointSize, "Should be equal!");	

				testingTarget.PlaceholderTextColor = new Vector4(0.79f, 0.79f, 0.79f, 1.0f);
				Assert.AreEqual(1.0f, testingTarget.PlaceholderTextColor.A, "Should be equal!");

				testingTarget.PrimaryCursorColor = new Vector4(0.04f, 0.05f, 0.13f, 1.0f);
				Assert.AreEqual(1.0f, testingTarget.PrimaryCursorColor.A, "Should be equal!");

				testingTarget.FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular"));
				testingTarget.FontStyle.Find(-1, "weight").Get(out string style);
				Assert.AreEqual("regular", style, "Should be equal!");

				testingTarget.Ellipsis = true;
				Assert.IsTrue(testingTarget.Ellipsis);

				testingTarget.LineSpacing = 10.0f;
                Assert.AreEqual(10.0f, testingTarget.LineSpacing, "Should be equal!");

				testingTarget.MinLineSize = 0.8f;
                Assert.AreEqual(0.8f, testingTarget.MinLineSize, "Should be equal!");

                testingTarget.RelativeLineHeight = 2.0f;
				Assert.AreEqual(2.0f, testingTarget.RelativeLineHeight, "Should be equal!");

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
            tlog.Debug(tag, $"publicBaseComponentTextEditorStyleFontFamily END (OK)");
        }

    }
}
