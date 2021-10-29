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
    [Description("Controls/Extension/ButtonExtension")]
    public class ButtonExtensionTest
    {
        private const string tag = "NUITEST";

        internal class ButtonExtensionImpl : ButtonExtension
        {
            public ButtonExtensionImpl() : base()
            { }

            public Touch TouchInfoTest 
            {
                get
                {
                    return base.TouchInfo;
                }
                set
                { }
            }
        }

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
        [Description("ButtonExtension SetTouchInfo.")]
        [Property("SPEC", "Tizen.NUI.Components.ButtonExtension.SetTouchInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ButtonExtensionSetTouchInfo()
        {
            tlog.Debug(tag, $"ScrollbarBaseUnparent START");

            var testingTarget = new ButtonExtensionImpl();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<ButtonExtension>(testingTarget, "Should return ButtonExtension instance.");

            try
            {
                using (Touch touch = new Touch())
                {
                    testingTarget.SetTouchInfo(touch);
                    tlog.Debug(tag, "TouchInfo : " + testingTarget.TouchInfoTest);
                }
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Assert Exception : Failed!");
            }

            tlog.Debug(tag, $"ScrollbarBaseUnparent END (OK)");
        }
    }
}
