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
    [Description("Style/PopupStyle")]
    public class PopupStyleTest
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
        [Description("PopupStyle constructor.")]
        [Property("SPEC", "Tizen.NUI.Components.PopupStyle.PopupStyle C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PopupStyleConstructor()
        {
            tlog.Debug(tag, $"PopupStyleConstructor START");

            PopupStyle style = new PopupStyle()
            {
                BackgroundColor = Color.Cyan,
            };
            var testingTarget = new PopupStyle(style);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<PopupStyle>(testingTarget, "Should return PopupStyle instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PopupStyleConstructor END (OK)");
        }
    }
}
