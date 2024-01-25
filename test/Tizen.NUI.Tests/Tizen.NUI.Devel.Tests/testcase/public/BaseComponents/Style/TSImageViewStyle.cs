using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/Style/ImageViewStyle")]
    public class PublicBaseComponentsStyleImageViewStyleTest
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
        [Description("ImageViewStyle ImageViewStyle.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.Style.ImageViewStyle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void BaseComponentsStyleImageViewStyle()
        {
            tlog.Debug(tag, $"BaseComponentsStyleImageViewStyle START");
			
            var testingTarget = new ImageViewStyle();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ImageViewStyle>(testingTarget, "should be an instance of ImageViewStyle class!");

            try
			{
			    testingTarget.BorderOnly = true;
                Assert.IsTrue(testingTarget.BorderOnly);
			
			    testingTarget.SynchronosLoading = true;
                Assert.IsTrue(testingTarget.SynchronosLoading);

                testingTarget.SynchronousLoading = true;
                Assert.IsTrue(testingTarget.SynchronousLoading);

                testingTarget.OrientationCorrection = true;
                Assert.IsTrue(testingTarget.OrientationCorrection);

                testingTarget.ResourceUrl = new Selector<string>()
                {
                    Normal = FrameworkInformation.ResourcePath + "IoT_switch_thumb.png",
                    Disabled = FrameworkInformation.ResourcePath + "IoT_switch_thumb_d.png",
                    Selected = FrameworkInformation.ResourcePath + "IoT_switch_thumb_s.png",
                    SelectedPressed = FrameworkInformation.ResourcePath + "IoT_switch_thumb_sp.png",
                    SelectedFocused = FrameworkInformation.ResourcePath + "IoT_switch_thumb_sf.png",
                };
                Assert.AreEqual(5, testingTarget.ResourceUrl.Count, "Should be equal!");	

			    testingTarget.Border = new Selector<Rectangle>()
                { 
                    All = new Rectangle(40, 40, 40, 40),
                };
                Assert.AreEqual(1, testingTarget.Border.Count, "Should be equal!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }			
			
			testingTarget.Dispose();
            tlog.Debug(tag, $"BaseComponentsStyleImageViewStyle END (OK)");
        }
    }
}
