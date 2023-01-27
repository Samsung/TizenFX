using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/Style/TextLabelStyle")]
    public class PublicBaseComponentsStyleTextLabelStyleTest
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
        [Description("TextLabelStyle TextLabelStyle.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Style.TextLabelStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseComponentsStyleTextLabelStyle()
        {
            tlog.Debug(tag, $"BaseComponentsStyleTextLabelStyle START");

            var testingTarget = new TextLabelStyle();
			Assert.IsNotNull(testingTarget, "should be not null");
			Assert.IsInstanceOf<TextLabelStyle>(testingTarget, "should be an instance of TextLabelStyle class!");

			try
			{
				testingTarget.TranslatableText = new Selector<string>()
				{
					All = "SamsungOneUI400",
                };
                Assert.AreEqual("SamsungOneUI400", testingTarget.TranslatableText.All, "Should be equal!");

                testingTarget.FontFamily = new Selector<string>()
                {
					All = "SamsungOneUI400",
					Normal = "BreezeSans",
				};
				Assert.AreEqual("BreezeSans", testingTarget.FontFamily.Normal, "Should be equal!");

				testingTarget.MultiLine = true ;
				Assert.IsTrue(testingTarget.MultiLine);

				testingTarget.HorizontalAlignment = HorizontalAlignment.Center;
				Assert.AreEqual(HorizontalAlignment.Center, testingTarget.HorizontalAlignment, "Should be equal!");

				testingTarget.VerticalAlignment = VerticalAlignment.Center;
				Assert.AreEqual(VerticalAlignment.Center, testingTarget.VerticalAlignment, "Should be equal!");

				testingTarget.EnableMarkup = false ;
				Assert.IsTrue(!testingTarget.EnableMarkup);	

				testingTarget.EnableAutoScroll = true ;
				Assert.IsTrue(testingTarget.EnableAutoScroll);	

				testingTarget.AutoScrollSpeed = 80 ;
				Assert.AreEqual(80, testingTarget.AutoScrollSpeed, "Should be equal!");

				testingTarget.AutoScrollLoopCount = 2 ;
				Assert.AreEqual(2, testingTarget.AutoScrollLoopCount, "Should be equal!");

				testingTarget.AutoScrollGap = 50.0f ;
				Assert.AreEqual(50.0f, testingTarget.AutoScrollGap, "Should be equal!");

				testingTarget.LineSpacing = 2.0f ;
				Assert.AreEqual(2.0f, testingTarget.LineSpacing, "Should be equal!");	

				testingTarget.RelativeLineHeight = 5.0f ;
				Assert.AreEqual(5.0f, testingTarget.RelativeLineHeight, "Should be equal!");

				testingTarget.Emboss = FrameworkInformation.ResourcePath + "IoT_handler_center_downW.png";
				tlog.Debug(tag, "Emboss : " + testingTarget.Emboss);

				testingTarget.PixelSize = new Selector<float?>()
				{
					All = 24.0f,
				};
				Assert.AreEqual(24.0f, testingTarget.PixelSize.All, "Should be equal!");

				testingTarget.Ellipsis = true ;
				Assert.IsTrue(testingTarget.Ellipsis);

				testingTarget.AutoScrollLoopDelay = 2.0f ;
				Assert.AreEqual(2.0f, testingTarget.AutoScrollLoopDelay, "Should be equal!");

				testingTarget.AutoScrollStopMode = AutoScrollStopMode.Immediate;
				Assert.AreEqual(AutoScrollStopMode.Immediate, testingTarget.AutoScrollStopMode, "Should be equal!");

				testingTarget.LineWrapMode = LineWrapMode.Character;
				Assert.AreEqual(LineWrapMode.Character, testingTarget.LineWrapMode, "Should be equal!");

				testingTarget.VerticalLineAlignment = VerticalLineAlignment.Center;
				Assert.AreEqual(VerticalLineAlignment.Center, testingTarget.VerticalLineAlignment, "Should be equal!");	

				testingTarget.EllipsisPosition = EllipsisPosition.Start;
				Assert.AreEqual(EllipsisPosition.Start, testingTarget.EllipsisPosition, "Should be equal!");

				testingTarget.CharacterSpacing = 0;
				Assert.AreEqual(0, testingTarget.CharacterSpacing, "Should be equal!");

				testingTarget.MatchSystemLanguageDirection = false;
				Assert.IsTrue(!testingTarget.MatchSystemLanguageDirection);
				
				testingTarget.TextColor = new Selector<Color>()
                {
                    Normal = new Color(0.2196f, 0.6131f, 0.9882f, 1),
                    Disabled = new Color(1, 1, 1, 0.35f),
                };
                Assert.AreEqual(0.35f, testingTarget.TextColor.Disabled.A, "Should be equal!");

                testingTarget.PointSize = new Selector<float?>()
                {
					All = 16.0f,
				};
				Assert.AreEqual(16.0f, testingTarget.PointSize.All, "Should be equal!");

				using (TextLabel textLabel = new TextLabel())
				{
					textLabel.Text = "TextShadowConstructor";
					textLabel.Color = Color.Red;
					textLabel.PointSize = 15.0f;

					using (PropertyMap temp = new PropertyMap())
                    {
						Tizen.NUI.Object.GetProperty((global::System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);

						TextShadow shadow = new TextShadow(temp);

						testingTarget.TextShadow = new Selector<TextShadow>()
						{
							All = shadow,
						};
						Assert.AreEqual(1.0f, testingTarget.TextShadow.All.Color.A, "Should be equal!");
					}
				}

				testingTarget.FontStyle = new PropertyMap().Add("weight", new PropertyValue("regular"));
				testingTarget.FontStyle.Find(-1, "weight").Get(out string style);
				Assert.AreEqual("regular", style, "Should be equal!");
			}
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }			

			testingTarget.Dispose();
            tlog.Debug(tag, $"BaseComponentsStyleTextLabelStyle END (OK)");
        }
    }
}
