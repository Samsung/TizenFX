using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/BaseComponents/CustomView")]
    public class PublicCustomViewTest
    {
        private const string tag = "NUITEST";

        internal class MyCustomView : CustomView
        {
            public MyCustomView(string typeName, CustomViewBehaviour behaviour) : base(typeName, behaviour)
            {  }

            public void OnAccessibilityDoAction(string name)
            {
                base.AccessibilityDoAction(name);
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
        [Description("CustomView constructor.")]
        [Property("SPEC", "Tizen.NUI.CustomView.CustomView C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomViewConstructor()
        {
            tlog.Debug(tag, $"CustomViewConstructor START");

            ViewStyle style = new ViewStyle()
            {
                Padding = new Extents(3, 3, 3, 3),
            };

            var testingTarget = new CustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault, style);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<CustomView>(testingTarget, "Should be an instance of CustomView type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomViewConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomView FocusNavigationSupport.")]
        [Property("SPEC", "Tizen.NUI.CustomView.FocusNavigationSupport A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomViewFocusNavigationSupport()
        {
            tlog.Debug(tag, $"CustomViewFocusNavigationSupport START");

            ViewStyle style = new ViewStyle()
            {
                Padding = new Extents(3, 3, 3, 3),
            };

            var testingTarget = new CustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault, style);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<CustomView>(testingTarget, "Should be an instance of CustomView type.");

            Assert.AreEqual(false, testingTarget.FocusNavigationSupport, "Should be equal!");

            testingTarget.FocusNavigationSupport = true;
            Assert.AreEqual(true, testingTarget.FocusNavigationSupport, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomViewFocusNavigationSupport END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomView FocusGroup.")]
        [Property("SPEC", "Tizen.NUI.CustomView.FocusGroup A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomViewFocusGroup()
        {
            tlog.Debug(tag, $"CustomViewFocusGroup START");

            ViewStyle style = new ViewStyle()
            {
                Padding = new Extents(3, 3, 3, 3),
            };

            var testingTarget = new CustomView("CustomView", CustomViewBehaviour.ViewBehaviourDefault, style);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<CustomView>(testingTarget, "Should be an instance of CustomView type.");

            Assert.AreEqual(false, testingTarget.FocusGroup, "Should be equal!");

            testingTarget.FocusGroup = true;
            Assert.AreEqual(true, testingTarget.FocusGroup, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomViewFocusGroup END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("CustomView AccessibilityDoAction.")]
        [Property("SPEC", "Tizen.NUI.CustomView.AccessibilityDoAction M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void CustomViewAccessibilityDoAction()
        {
            tlog.Debug(tag, $"CustomViewAccessibilityDoAction START");

            var testingTarget = new MyCustomView("CustomView", CustomViewBehaviour.RequiresKeyboardNavigationSupport);
            Assert.IsNotNull(testingTarget, "Can't create success object CustomView");
            Assert.IsInstanceOf<CustomView>(testingTarget, "Should be an instance of CustomView type.");

            testingTarget.OnAccessibilityDoAction("activate");

            testingTarget.OnAccessibilityDoAction("ReadingSkipped");

            testingTarget.OnAccessibilityDoAction("ReadingCancelled");

            testingTarget.OnAccessibilityDoAction("ReadingStopped");

            testingTarget.OnAccessibilityDoAction("ReadingPaused");

            testingTarget.OnAccessibilityDoAction("ReadingResumed");

            testingTarget.Dispose();
            tlog.Debug(tag, $"CustomViewAccessibilityDoAction END (OK)");
        }
    }
}
