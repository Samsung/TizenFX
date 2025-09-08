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

        [Test]
        [Category("P1")]
        [Description("Get value test for View.ColorRed")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorRed")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ColorRed_GET_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            Assert.AreEqual(1.0f, testView.ColorRed, "Default red value is 1.0f");

            testView.ColorRed = 0.5f;

            Assert.AreEqual(0.5f, testView.ColorRed, "ColorRed set");
            Assert.AreEqual(new Color(0.5f, 1.0f, 1.0f, 1.0f), testView.Color, "ColorRed should change View.Color");

            testView.Color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

            Assert.AreEqual(new Color(0.0f, 0.0f, 0.0f, 0.5f), testView.Color, "Color set");
            Assert.AreEqual(0.0f, testView.ColorRed, "Color should change View.ColorRed");

            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("Get value test for View.ColorGreen")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorGreen")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ColorGreen_GET_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            Assert.AreEqual(1.0f, testView.ColorGreen, "Default green value is 1.0f");

            testView.ColorGreen = 0.5f;

            Assert.AreEqual(0.5f, testView.ColorGreen, "ColorGreen set");
            Assert.AreEqual(new Color(1.0f, 0.5f, 1.0f, 1.0f), testView.Color, "ColorGreen should change View.Color");

            testView.Color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

            Assert.AreEqual(new Color(0.0f, 0.0f, 0.0f, 0.5f), testView.Color, "Color set");
            Assert.AreEqual(0.0f, testView.ColorGreen, "Color should change View.ColorGreen");

            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("Get value test for View.ColorBlue")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ColorBlue")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ColorBlue_GET_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            Assert.AreEqual(1.0f, testView.ColorBlue, "Default blue value is 1.0f");

            testView.ColorBlue = 0.5f;

            Assert.AreEqual(0.5f, testView.ColorBlue, "ColorBlue set");
            Assert.AreEqual(new Color(1.0f, 1.0f, 0.5f, 1.0f), testView.Color, "ColorBlue should change View.Color");

            testView.Color = new Color(0.0f, 0.0f, 0.0f, 0.5f);

            Assert.AreEqual(new Color(0.0f, 0.0f, 0.0f, 0.5f), testView.Color, "Color set");
            Assert.AreEqual(0.0f, testView.ColorBlue, "Color should change View.ColorBlue");

            testView.Dispose();
        }


        [Test]
        [Category("P1")]
        [Description("Get value test for View.ToolTipText")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.ToolTipText")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void ToolTipText_GET_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            testView.TooltipText = "tooltipText";
            Assert.AreEqual("tooltipText", testView.TooltipText, "Should get equal string value what we set before");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Verify SetAccessibilityStatesV2 and GetAccessibilityStatesV2 functionality")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetAccessibilityStatesV2 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "seoyeon2.kim@samsung.com")]
        public void AccessibilityStatesV2_SetAndGet_ReturnsCorrectState()
        {
            /* TEST CODE */
            var testView = new View();
            testView.SetAccessibilityStatesV2(AccessibilityStatesV2.Enabled);

            var actualStates = testView.GetAccessibilityStatesV2();
            Assert.AreEqual(AccessibilityStatesV2.Enabled, actualStates, "View AccessibilityStatesV2.Enabled should be true.");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Verify SetAccessibilityRoleV2 and GetAccessibilityRoleV2 functionality")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.GetAccessibilityRoleV2 M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "seoyeon2.kim@samsung.com")]
        public void AccessibilityRoleV2_SetAndGet_ReturnsCorrectRole()
        {
            /* TEST CODE */
            var testView = new View();
            testView.SetAccessibilityRoleV2(AccessibilityRoleV2.Button);

            var actualRole = testView.GetAccessibilityRoleV2();
            Assert.AreEqual(AccessibilityRoleV2.Button, actualRole, "actualRole should be AccessibilityRoleV2.Button.");

            testView.Dispose();
        }

        [Test]
        [Category("P1")]
        [Description("Get value test for View.AccessibilityIsModal")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.View.AccessibilityIsModal")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "seoyeon2.kim@samsung.com")]
        public void AccessibilityIsModal_GET_SET_VALUE()
        {
            /* TEST CODE */
            View testView = new View();

            testView.AccessibilityIsModal = true;
            Assert.AreEqual(true, testView.AccessibilityIsModal, "Should get equal bool value what we set before");

            testView.Dispose();
        }
    }
}
