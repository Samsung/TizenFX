using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("Style/TabButtonStyle")]
    public class TabButtonStyleTest
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
        [Description("TabButtonStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButtonStyle.TabButtonStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabButtonStyleConstructor()
        {
            tlog.Debug(tag, $"TabButtonStyleConstructor START");

            TabButtonStyle style = new TabButtonStyle()
            {
                BackgroundColor = Color.Cyan,
            };
            var testingTarget = new TabButtonStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButtonStyle>(testingTarget, "Should return TabButtonStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TabButtonStyleConstructor END (OK)");
        }
    }
}
