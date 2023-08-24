using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/Extension/LottieButtonStyle")]
    public class LottieButtonStyleTest
    {
        private const string tag = "NUITEST";
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
        [Description("LottieButtonStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonStyle.LottieButtonStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonStyleConstructor()
        {
            tlog.Debug(tag, $"LottieButtonStyleConstructor START");

            var testingTarget = new LottieButtonStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonStyle>(testingTarget, "Should return LottieButtonStyle instance.");

            tlog.Debug(tag, $"LottieButtonStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieButtonStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonStyle.LottieButtonStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonStyleConstructorWithLottieButtonStyle()
        {
            tlog.Debug(tag, $"LottieButtonStyleConstructorWithLottieButtonStyle START");

            var style = new LottieButtonStyle()
            { 
                BackgroundColor = Color.Cyan
            };

            var testingTarget = new LottieButtonStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonStyle>(testingTarget, "Should return LottieButtonStyle instance.");

            testingTarget.LottieUrl = lottie_url;
            tlog.Debug(tag, "LottieUrl : " + testingTarget.LottieUrl);
            
            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            testingTarget.PlayRange = info;
            tlog.Debug(tag, "PlayRange : " + testingTarget.PlayRange);

            tlog.Debug(tag, $"LottieButtonStyleConstructorWithLottieButtonStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieButtonStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonStyleCopyFrom()
        {
            tlog.Debug(tag, $"LottieButtonStyleCopyFrom START");

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            var style = new LottieButtonStyle()
            {
                BackgroundColor = Color.Cyan,
                LottieUrl = lottie_url,
                PlayRange = info
            };

            var testingTarget = new LottieButtonStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonStyle>(testingTarget, "Should return LottieButtonStyle instance.");

            try
            {
                testingTarget.CopyFrom(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"LottieButtonStyleCopyFrom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieButtonStyle CreateExtension.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieButtonStyle.CreateExtension M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieButtonStyleCreateExtension()
        {
            tlog.Debug(tag, $"LottieButtonStyleCreateExtension START");

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            var style = new LottieButtonStyle()
            {
                BackgroundColor = Color.Cyan,
                LottieUrl = lottie_url,
                PlayRange = info
            };

            var testingTarget = new LottieButtonStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieButtonStyle>(testingTarget, "Should return LottieButtonStyle instance.");

            try
            {
                testingTarget.CreateExtension();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"LottieButtonStyleCreateExtension END (OK)");
        }
    }
}
