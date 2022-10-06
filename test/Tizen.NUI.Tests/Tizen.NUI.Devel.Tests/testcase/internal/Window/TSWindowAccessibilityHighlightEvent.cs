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
    [Description("internal/Window/WindowAccessibilityHighlightEvent")]
    public class InternalWindowAccessibilityHighlightEventTest
    {
        private const string tag = "NUITEST";

        private delegate bool dummyCallback(IntPtr signal);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
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
        [Description("WindowAccessibilityHighlightEvent GetConnectionCount.")]
        [Property("SPEC", "Tizen.NUI.WindowAccessibilityHighlightEvent.GetConnectionCount M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WindowAccessibilityHighlightEventGetConnectionCount()
        {
            tlog.Debug(tag, $"WindowAccessibilityHighlightEventGetConnectionCount START");

            var testingTarget = new WindowAccessibilityHighlightEvent(Window.Instance);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<WindowAccessibilityHighlightEvent>(testingTarget, "Should be an Instance of WindowAccessibilityHighlightEvent!");

            try
            {
                var result = testingTarget.GetConnectionCount();
                tlog.Debug(tag, "Connection count : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();

            tlog.Debug(tag, $"WindowAccessibilityHighlightEventGetConnectionCount END (OK)");
        }
	}
}