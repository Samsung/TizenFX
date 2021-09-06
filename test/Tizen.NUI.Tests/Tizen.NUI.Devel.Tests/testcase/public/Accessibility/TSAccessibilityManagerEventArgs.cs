using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Accessibility/AccessibilityManagerEventArgs")]
    public class PublicAccessibilityManagerEventArgsTest
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
        [Description("FocusChangedEventArgs ViewCurrent.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.FocusChangedEventArgs.ViewCurrent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusChangedEventArgsViewCurrent()
        {
            tlog.Debug(tag, $"FocusChangedEventArgsViewCurrent START");

            var testingTarget = new Accessibility.AccessibilityManager.FocusChangedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object FocusChangedEventArgs");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager.FocusChangedEventArgs>(testingTarget, "Should be an instance of FocusChangedEventArgs type.");

            using (View current = new View() { Size = new Size(100, 50) })
            {
                testingTarget.ViewCurrent = current;
                tlog.Debug(tag, "ViewCurrent : " + testingTarget.ViewCurrent);
            }

            using (View next = new View() { Size = new Size(100, 50) })
            {
                testingTarget.ViewNext = next;
                tlog.Debug(tag, "ViewNext : " + testingTarget.ViewNext);
            }

            tlog.Debug(tag, $"FocusChangedEventArgsViewCurrent END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusedViewActivatedEventArgs  View.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.FocusedViewActivatedEventArgs.View A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusedViewActivatedEventArgsView()
        {
            tlog.Debug(tag, $"FocusedViewActivatedEventArgsView START");

            var testingTarget = new Accessibility.AccessibilityManager.FocusedViewActivatedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object FocusedViewActivatedEventArgs");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager.FocusedViewActivatedEventArgs>(testingTarget, "Should be an instance of FocusedViewActivatedEventArgs type.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.View = view;
                tlog.Debug(tag, "View : " + testingTarget.View);
            }

            tlog.Debug(tag, $"FocusedViewActivatedEventArgsView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("FocusOvershotEventArgs CurrentFocusedView.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.FocusOvershotEventArgs.CurrentFocusedView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void FocusOvershotEventArgsViewCurrentFocusedView()
        {
            tlog.Debug(tag, $"FocusOvershotEventArgsCurrentFocusedView START");

            var testingTarget = new Accessibility.AccessibilityManager.FocusOvershotEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object FocusOvershotEventArgs");
            Assert.IsInstanceOf<Accessibility.AccessibilityManager.FocusOvershotEventArgs>(testingTarget, "Should be an instance of FocusOvershotEventArgs type.");

            using (View view = new View() { Size = new Size(100, 50) })
            {
                testingTarget.CurrentFocusedView = view;
                tlog.Debug(tag, "CurrentFocusedView : " + testingTarget.CurrentFocusedView);
            }

            testingTarget.FocusOvershotDirection = Accessibility.AccessibilityManager.FocusOvershotDirection.Next;
            tlog.Debug(tag, "FocusOvershotDirection : " + testingTarget.FocusOvershotDirection);

            tlog.Debug(tag, $"FocusOvershotEventArgsCurrentFocusedView END (OK)");
        }
    }
}
