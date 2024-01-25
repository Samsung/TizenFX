using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/ViewAccessibilityProperties")]
    public class PublicViewAccessibilityPropertiesTest
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
        [Description("ViewAccessibilityProperties AccessibilityName.")]
        [Property("SPEC", "Tizen.NUI.ViewAccessibilityProperties.AccessibilityName A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityProperties()
        {
            tlog.Debug(tag, $"ViewAccessibilityProperties START");

            var view = new View()
            {
                Size = new Size2D(100, 100),
                PositionUsesPivotPoint = true,
                ParentOrigin = ParentOrigin.TopCenter,
                PivotPoint = PivotPoint.TopCenter,
                BackgroundColor = Color.AquaMarine,
            };
            NUIApplication.GetDefaultWindow().Add(view);

            view.AccessibilityName = "accessibiliy";
            Assert.AreEqual("accessibiliy", view.AccessibilityName, "Should be equal!");

            view.AccessibilityDescription = "view's accessibility";
            Assert.AreEqual("view's accessibility", view.AccessibilityDescription, "Should be equal!");

            view.AccessibilityTranslationDomain = "0, 100";
            Assert.AreEqual("0, 100", view.AccessibilityTranslationDomain, "Should be equal!");

            Role role = new Role();
            view.AccessibilityRole = role;
            tlog.Debug(tag, "Role : " + view.AccessibilityRole);

            view.AccessibilityHighlightable = true;
            Assert.AreEqual(true, view.AccessibilityHighlightable, "Should be equal!");

            view.AutomationId = "automation";
            Assert.AreEqual("automation", view.AutomationId, "Should be equal!");

            NUIApplication.GetDefaultWindow().Remove(view);

            view.Unparent();
            view.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityProperties END (OK)");
        }
    }
}
