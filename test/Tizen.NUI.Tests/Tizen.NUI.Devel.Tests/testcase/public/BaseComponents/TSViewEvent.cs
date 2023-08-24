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
    [Description("public/BaseComponents/ViewEvent")]
    public class PublicViewEventTest
    {
        private const string tag = "NUITEST";

        private bool OnKeyEvent(object source, View.KeyEventArgs e)
        {
            return true;
        }

        private bool OnInterceptTouchEvent(object source, View.TouchEventArgs e)
        {
            return true;
        }

        private bool OnWheelEvent(object source, View.WheelEventArgs e)
        {
            return true;
        }

        private bool OnHoverEvent(object source, View.HoverEventArgs e)
        {
            return true;
        }

        private bool OnTouchEvent(object source, View.TouchEventArgs e)
        {
            return true;
        }

        private void OnBackgroundResourceLoaded(object sender, View.BackgroundResourceLoadedEventArgs e) { }

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
        [Description("ViewEvent KeyEvent.")]
        [Property("SPEC", "Tizen.NUI.ViewEvent.KeyEvent A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewEventKeyEvent()
        {
            tlog.Debug(tag, $"ViewEventKeyEvent START");

            var testingTarget = new View();
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.KeyEvent += OnKeyEvent;
            testingTarget.KeyEvent -= OnKeyEvent;

            testingTarget.InterceptTouchEvent += OnInterceptTouchEvent;
            testingTarget.InterceptTouchEvent -= OnInterceptTouchEvent;

            testingTarget.TouchEvent += OnTouchEvent;
            testingTarget.TouchEvent -= OnTouchEvent;

            testingTarget.HoverEvent += OnHoverEvent;
            testingTarget.HoverEvent -= OnHoverEvent;

            testingTarget.WheelEvent += OnWheelEvent;
            testingTarget.WheelEvent -= OnWheelEvent;

            testingTarget.BackgroundResourceLoaded += OnBackgroundResourceLoaded;
            testingTarget.BackgroundResourceLoaded -= OnBackgroundResourceLoaded;

            tlog.Debug(tag, $"ViewEventKeyEvent END (OK)");
        }
    }
}
