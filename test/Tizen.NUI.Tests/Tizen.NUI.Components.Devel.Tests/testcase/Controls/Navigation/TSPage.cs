using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Controls/Navigation/Page")]
    public class NavigationPageTest
    {
        private const string tag = "NUITEST";

        internal class MyPage : Page { }

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
        [Description("Page AppearingTransition.")]
        [Property("SPEC", "Tizen.NUI.Components.Page.AppearingTransition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageAppearingTransition()
        {
            tlog.Debug(tag, $"PageAppearingTransition START");

            var testingTarget = new MyPage();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Page>(testingTarget, "Should return Page instance.");

            TransitionBase tb = new TransitionBase()
            {
                AlphaFunction = new AlphaFunction(Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseIn),
                TimePeriod = new TimePeriod(300)
            };

            testingTarget.AppearingTransition = tb;
            tlog.Debug(tag, "AppearingTransition : " + testingTarget.AppearingTransition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageAppearingTransition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Page DisappearingTransition.")]
        [Property("SPEC", "Tizen.NUI.Components.Page.DisappearingTransition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PageDisappearingTransition()
        {
            tlog.Debug(tag, $"PageDisappearingTransition START");

            var testingTarget = new MyPage();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Page>(testingTarget, "Should return Page instance.");

            TransitionBase tb = new TransitionBase()
            {
                AlphaFunction = new AlphaFunction(Tizen.NUI.AlphaFunction.BuiltinFunctions.EaseOut),
                TimePeriod = new TimePeriod(300)
            };

            testingTarget.DisappearingTransition = tb;
            tlog.Debug(tag, "DisappearingTransition : " + testingTarget.DisappearingTransition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PageDisappearingTransition END (OK)");
        }
    }
}
