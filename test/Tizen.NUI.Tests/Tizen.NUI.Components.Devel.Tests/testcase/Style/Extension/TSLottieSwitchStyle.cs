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
    [Description("Style/Extension/LottieSwitchStyle")]
    public class LottieSwitchStyleTest
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
        [Description("LottieSwitchStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchStyle.LottieSwitchStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchStyleConstructor()
        {
            tlog.Debug(tag, $"LottieSwitchStyleConstructor START");

            var testingTarget = new LottieSwitchStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchStyle>(testingTarget, "Should return LottieSwitchStyle instance.");

            tlog.Debug(tag, $"LottieSwitchStyleConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieSwitchStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchStyle.LottieSwitchStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchStyleConstructorWithLottieSwitchStyle()
        {
            tlog.Debug(tag, $"LottieSwitchStyleConstructorWithLottieSwitchStyle START");

            var style = new LottieSwitchStyle()
            {
                BackgroundColor = Color.Cyan
            };

            var testingTarget = new LottieSwitchStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchStyle>(testingTarget, "Should return LottieSwitchStyle instance.");

            testingTarget.LottieUrl = lottie_url;
            tlog.Debug(tag, "LottieUrl : " + testingTarget.LottieUrl);

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            testingTarget.PlayRange = info;
            tlog.Debug(tag, "PlayRange : " + testingTarget.PlayRange);

            tlog.Debug(tag, $"LottieSwitchStyleConstructorWithLottieSwitchStyle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieSwitchStyle CopyFrom.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchStyle.CopyFrom M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchStyleCopyFrom()
        {
            tlog.Debug(tag, $"LottieSwitchStyleCopyFrom START");

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            var style = new LottieSwitchStyle()
            {
                BackgroundColor = Color.Cyan,
                LottieUrl = lottie_url,
                PlayRange = info
            };

            var testingTarget = new LottieSwitchStyle();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchStyle>(testingTarget, "Should return LottieSwitchStyle instance.");

            try
            {
                testingTarget.CopyFrom(style);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"LottieSwitchStyleCopyFrom END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("LottieSwitchStyle CreateExtension.")]
        [Property("SPEC", "Tizen.NUI.Components.LottieSwitchStyle.CreateExtension M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LottieSwitchStyleCreateExtension()
        {
            tlog.Debug(tag, $"LottieSwitchStyleCreateExtension START");

            LottieFrameInfo info = new LottieFrameInfo(0, 100);
            Selector<LottieFrameInfo> selector = new Selector<LottieFrameInfo>(info);

            var style = new LottieSwitchStyle()
            {
                BackgroundColor = Color.Cyan,
                LottieUrl = lottie_url,
                PlayRange = info
            };

            var testingTarget = new LottieSwitchStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<LottieSwitchStyle>(testingTarget, "Should return LottieSwitchStyle instance.");

            try
            {
                testingTarget.CreateExtension();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"LottieSwitchStyleCreateExtension END (OK)");
        }
    }
}
