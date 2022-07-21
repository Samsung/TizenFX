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

            Assert.AreEqual(false, testView.IsEnabled, "View IsEnabled should be changed by set value");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for View.PropagatableControlStates")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PropagatableControlStates")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "sh10233.lee@samsung.com")]
        public void PropagatableControlStates_GET_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            Assert.AreEqual(ControlState.All, testView.PropagatableControlStates, "View PropagatableControlStates should be ControlState.All by default");

            testView.PropagatableControlStates = ControlState.Disabled + ControlState.Selected;

            Assert.AreEqual(ControlState.Disabled + ControlState.Selected, testView.PropagatableControlStates, "View PropagatableControlStates should be ControlState.All by default");

            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("Update value test for View.PropagatableControlStates")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.PropagatableControlStates")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "sh10233.lee@samsung.com")]
        public void PropagatableControlStates_UPDATE_VALUE()
        {
            /* TEST CODE */
            View parentView = new View();
            View testView = new View();

            testView.PropagatableControlStates = ControlState.Disabled;

            parentView.Add(testView);
            parentView.EnableControlStatePropagation = true;
            parentView.EnableControlState = true;
            testView.EnableControlState = true;

            Assert.AreEqual(ControlState.Normal, testView.ControlState, "View ControlStates should be ControlState.Normal by default");

            parentView.IsEnabled = false;

            Assert.AreEqual(true, testView.ControlState.Contains(ControlState.Disabled), "View ControlStates should be ControlState.Disabled by parentView propagation");

            testView.PropagatableControlStates -= ControlState.Disabled;

            parentView.IsEnabled = true;

            Assert.AreEqual(true, testView.ControlState.Contains(ControlState.Disabled), "View ControlStates should be ControlState.Disabled as parentView propagation blocked");

            testView.Dispose();
        }
    }
}
