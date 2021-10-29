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
    [Description("Controls/TabButtonGroup")]
    public class TabButtonGroupTest
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
        [Category("P2")]
        [Description("TabButtonGroup Add.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButtonGroup.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabButtonGroupAddArgumentNullException()
        {
            tlog.Debug(tag, $"TabButtonGroupAddArgumentNullException START");

            var testingTarget = new TabButtonGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButtonGroup>(testingTarget, "Should return TabButtonGroup instance.");

            TabButton button = null;
            try
            {
                testingTarget.Add(button);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TabButtonGroupAddArgumentNullException END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("TabButtonGroup Remove.")]
        [Property("SPEC", "Tizen.NUI.Components.TabButtonGroup.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TabButtonGroupRemoveArgumentNullException()
        {
            tlog.Debug(tag, $"TabButtonGroupRemoveArgumentNullException START");

            var testingTarget = new TabButtonGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<TabButtonGroup>(testingTarget, "Should return TabButtonGroup instance.");

            TabButton button = null;
            try
            {
                testingTarget.Remove(button);
            }
            catch (ArgumentNullException e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TabButtonGroupRemoveArgumentNullException END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }
    }
}
