using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Accessibility/AccessibilityManagerEvent")]
    public class PublicAccessibilityManagerEventTest
    {
        private const string tag = "NUITEST";
        private Accessibility.AccessibilityManager manager;

        private bool OnStatusChanged(object source, EventArgs e) { return true; }
        private bool OnActionNext(object source, EventArgs e) { return true; }
        private bool OnActionPrevious(object source, EventArgs e) { return true; }
        private bool OnActionActivate(object source, EventArgs e) { return true; }
        private bool OnActionRead(object source, EventArgs e) { return true; }
        private bool OnActionOver(object source, EventArgs e) { return true; }
        private bool OnActionReadNext(object source, EventArgs e) { return true; }
        private bool OnActionStartStop(object source, EventArgs e) { return true; }
        private bool OnActionReadPauseResume(object source, EventArgs e) { return true; }
        private bool OnActionZoom(object source, EventArgs e) { return true; }
        private bool OnActionReadFromNext(object source, EventArgs e) { return true; }
        private bool OnActionReadFromTop(object source, EventArgs e) { return true; }
        private bool OnActionMoveToLast(object source, EventArgs e) { return true; }
        private bool OnActionMoveToFirst(object source, EventArgs e) { return true; }
        private bool OnActionPageDown(object source, EventArgs e) { return true; }
        private bool OnActionPageUp(object source, EventArgs e) { return true; }
        private bool OnActionPageRight(object source, EventArgs e) { return true; }
        private bool OnActionPageLeft(object source, EventArgs e) { return true; }
        private bool OnActionScrollDown(object source, EventArgs e) { return true; }
        private bool OnActionScrollUp(object source, EventArgs e) { return true; }
        private bool OnActionBack(object source, EventArgs e) { return true; }
        private bool OnActionClearFocus(object source, EventArgs e) { return true; }
        private bool OnActionDown(object source, EventArgs e) { return true; }
        private bool OnActionUp(object source, EventArgs e) { return true; }
        private bool OnActionReadPrevious(object source, EventArgs e) { return true; }
        private void OnFocusOvershot(object sender, Accessibility.AccessibilityManager.FocusOvershotEventArgs e) { }
        private void OnFocusedViewActivated(object sender, Accessibility.AccessibilityManager.FocusedViewActivatedEventArgs e) { }
        private void OnFocusChanged(object sender, Accessibility.AccessibilityManager.FocusChangedEventArgs e) { }

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");

            manager = Accessibility.AccessibilityManager.Instance;
        }

        [TearDown]
        public void Destroy()
        {
            manager.Dispose();
            manager = null;

            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("AccessibilityManager events.")]
        [Property("SPEC", "Tizen.NUI.AccessibilityManager.StatusChanged... A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AccessibilityManagerEvents()
        {
            tlog.Debug(tag, $"AccessibilityManagerEvents START");

            manager.StatusChanged += OnStatusChanged;
            manager.StatusChanged -= OnStatusChanged;

            manager.ActionNext += OnActionNext;
            manager.ActionNext -= OnActionNext;

            manager.ActionPrevious += OnActionPrevious;
            manager.ActionPrevious -= OnActionPrevious;

            manager.ActionActivate += OnActionActivate;
            manager.ActionActivate -= OnActionActivate;

            manager.ActionRead += OnActionRead;
            manager.ActionRead -= OnActionRead;

            manager.ActionOver += OnActionOver;
            manager.ActionOver -= OnActionOver;

            manager.ActionReadNext += OnActionReadNext;
            manager.ActionReadNext -= OnActionReadNext;

            manager.ActionReadPrevious += OnActionReadPrevious;
            manager.ActionReadPrevious -= OnActionReadPrevious;

            manager.ActionUp += OnActionUp;
            manager.ActionUp -= OnActionUp;

            manager.ActionDown += OnActionDown;
            manager.ActionDown -= OnActionDown;
 
            manager.FocusOvershot += OnFocusOvershot;
            manager.FocusOvershot -= OnFocusOvershot;

            manager.ActionClearFocus += OnActionClearFocus;
            manager.ActionClearFocus -= OnActionClearFocus;

            manager.ActionBack += OnActionBack;
            manager.ActionBack -= OnActionBack;

            manager.FocusedViewActivated += OnFocusedViewActivated;
            manager.FocusedViewActivated -= OnFocusedViewActivated;

            manager.FocusChanged += OnFocusChanged;
            manager.FocusChanged -= OnFocusChanged;

            manager.ActionStartStop += OnActionStartStop;
            manager.ActionStartStop -= OnActionStartStop;

            manager.ActionReadPauseResume += OnActionReadPauseResume;
            manager.ActionReadPauseResume -= OnActionReadPauseResume;

            manager.ActionReadFromNext += OnActionReadFromNext;
            manager.ActionReadFromNext -= OnActionReadFromNext;

            manager.ActionPageDown += OnActionPageDown;
            manager.ActionPageDown -= OnActionPageDown;

            manager.ActionZoom += OnActionZoom;
            manager.ActionZoom -= OnActionZoom;

            manager.ActionScrollUp += OnActionScrollUp;
            manager.ActionScrollUp -= OnActionScrollUp;

            manager.ActionScrollDown += OnActionScrollDown;
            manager.ActionScrollDown -= OnActionScrollDown;

            manager.ActionPageLeft += OnActionPageLeft;
            manager.ActionPageLeft -= OnActionPageLeft;

            manager.ActionPageRight += OnActionPageRight;
            manager.ActionPageRight -= OnActionPageRight;

            manager.ActionReadFromTop += OnActionReadFromTop;
            manager.ActionReadFromTop -= OnActionReadFromTop;

            manager.ActionMoveToLast += OnActionMoveToLast;
            manager.ActionMoveToLast -= OnActionMoveToLast;

            manager.ActionMoveToFirst += OnActionMoveToFirst;
            manager.ActionMoveToFirst -= OnActionMoveToFirst;

            manager.ActionPageUp += OnActionPageUp;
            manager.ActionPageUp -= OnActionPageUp;

            tlog.Debug(tag, $"AccessibilityManagerEvents END (OK)");
        }
    }
}
