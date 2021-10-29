using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components.Devel.Tests
{
    using static Tizen.NUI.BaseComponents.View;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Extension/LottieButtonExtension")]
    public class LottieButtonExtensionTest
    {
        private const string tag = "NUITEST";
        private string image_path = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private string lottie_url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "lottie.json";

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
        [Description("LottieButtonExtension constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonExtension.LottieButtonExtension C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonExtensionConstructor()
        {
            tlog.Debug(tag, $"LottieButtonExtensionConstructor START");

            var testingTarget = new LottieButtonExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonExtension>(testingTarget, "Should return LottieButtonExtension instance.");

            tlog.Debug(tag, $"LottieButtonExtensionConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieButtonExtension OnControlStateChanged.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonExtension.OnControlStateChanged M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonExtensionOnControlStateChanged()
        {
            tlog.Debug(tag, $"LottieButtonExtensionOnControlStateChanged START");

            var testingTarget = new LottieButtonExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonExtension>(testingTarget, "Should return LottieButtonExtension instance.");

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            var style = new LottieButtonStyle()
            {
                BackgroundColor = Color.Cyan,
                LottieUrl = lottie_url,
                PlayRange = info
            };

            using (Button button = new Button(style))
            {
                ControlStateChangedEventArgs args = new ControlStateChangedEventArgs(ControlState.Pressed, ControlState.Selected);
                
                try
                {
                    testingTarget.OnControlStateChanged(button, args);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"LottieButtonExtensionOnControlStateChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieButtonExtension OnCreateIcon.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonExtension.OnCreateIcon M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonExtensionOnCreateIcon()
        {
            tlog.Debug(tag, $"LottieButtonExtensionOnCreateIcon START");

            var testingTarget = new LottieButtonExtension();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonExtension>(testingTarget, "Should return LottieButtonExtension instance.");

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            var style = new LottieButtonStyle()
            {
                BackgroundColor = Color.Cyan,
                LottieUrl = lottie_url,
                PlayRange = info
            };

            using (Button button = new Button(style))
            {
                using (ImageView view = new ImageView(image_path))
                {
                    var result = testingTarget.OnCreateIcon(button, view);
                    tlog.Debug(tag, "OnCreateIcon : " + result);
                }
            }

            tlog.Debug(tag, $"LottieButtonExtensionOnCreateIcon END (OK)");
        }
    }
}
