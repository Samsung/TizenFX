using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/View")]
    public class ViewTest
    {
        private const string tag = "NUITEST";
        private const int testSize = 100;
        private const int testPosition = 100;

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
        [Description("Get default value test for View.IsEnabled")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.IsEnabled")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "sh10233.lee@samsung.com")]
        public void IsEnabled_CHECK_DEFAULT_VALUE()
        {
            /* TEST CODE */
            View testView = new View();
            var isEnabled = testView.IsEnabled;

            Assert.AreEqual(true, isEnabled, "View IsEnabled should be true by default");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Set value test for View.IsEnabled")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.IsEnabled")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "sh10233.lee@samsung.com")]
        public void IsEnabled_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();
            var isEnabled = testView.IsEnabled;

            Assert.AreEqual(true, isEnabled, "View IsEnabled should be true by default");

            testView.IsEnabled = false;

            Assert.AreEqual(false, isEnabled, "View IsEnabled should be changed by set value");

            testView.Dispose();
        }

    }
}
