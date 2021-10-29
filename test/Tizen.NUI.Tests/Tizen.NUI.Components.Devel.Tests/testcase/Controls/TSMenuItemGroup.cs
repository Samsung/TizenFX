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
    [Description("Controls/MenuItemGroup")]
    public class MenuItemGroupTest
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
        [Description("MenuItemGroup Add.")]
        [Property("SPEC", "Tizen.NUI.Components.MenuItemGroup.Add M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuItemGroupAdd()
        {
            tlog.Debug(tag, $"MenuItemGroupAdd START");

            var testingTarget = new MenuItemGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MenuItemGroup>(testingTarget, "Should return MenuItemGroup instance.");

            try
            {
                MenuItem item = null;
                testingTarget.Add(item);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"MenuItemGroupAdd END (OK)");
                Assert.Pass("Caught ArgumentNullException : Passed!");
            }
        }

        [Test]
        [Category("P1")]
        [Description("MenuItemGroup Remove.")]
        [Property("SPEC", "Tizen.NUI.Components.MenuItemGroup.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuItemGroupRemove()
        {
            tlog.Debug(tag, $"MenuItemGroupRemove START");

            var testingTarget = new MenuItemGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MenuItemGroup>(testingTarget, "Should return MenuItemGroup instance.");

            MenuItem item = new MenuItem()
            {
                BackgroundColor = Color.Cyan,
            };
            testingTarget.Add(item);

            try
            {
                testingTarget.Remove(item);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            tlog.Debug(tag, $"MenuItemGroupRemove END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("MenuItemGroup Remove.")]
        [Property("SPEC", "Tizen.NUI.Components.MenuItemGroup.Remove M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void MenuItemGroupRemoveNullMenuItem()
        {
            tlog.Debug(tag, $"MenuItemGroupRemoveNullMenuItem START");

            var testingTarget = new MenuItemGroup();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<MenuItemGroup>(testingTarget, "Should return MenuItemGroup instance.");

            try
            {
                MenuItem item = null;
                testingTarget.Remove(item);
            }
            catch (ArgumentNullException)
            {
                tlog.Debug(tag, $"MenuItemGroupAdd END (OK)");
                Assert.Pass("Caught MenuItemGroupRemoveNullMenuItem : Passed!");
            }
        }
    }
}
