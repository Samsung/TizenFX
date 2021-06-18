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
    [Description("public/Utility/ScrollViewEvent")]
    public class PublicScrollViewEventTest
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
        [Description("ScrollViewEvent.SnapEvent constructor.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapEvent.SnapEvent C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapEventConstructor()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapEventConstructor START");

            var testingTarget = new ScrollView.SnapEvent();
            Assert.IsNotNull(testingTarget, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(testingTarget, "Should be an instance of SnapEvent type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEventSnapEventConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEvent.SnapEvent SnapStarted.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapEvent.SnapStarted A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapEventSnapStarted()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapEventSnapStarted START");

            var testingTarget = new ScrollView();
            Assert.IsNotNull(testingTarget, "Can't create success object ScrollView");
            Assert.IsInstanceOf<ScrollView>(testingTarget, "Should be an instance of ScrollView type.");

            testingTarget.SnapStarted += OnSnapStarted;
            testingTarget.SnapStarted -= OnSnapStarted;

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEventSnapEventSnapStarted END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEvent.SnapEvent position.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapEvent.position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapEventPosition()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapEventPosition START");

            var testingTarget = new ScrollView.SnapEvent();
            Assert.IsNotNull(testingTarget, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(testingTarget, "Should be an instance of SnapEvent type.");

            testingTarget.position = new Vector2(20, 30);
            Assert.AreEqual(20, testingTarget.position.X, "Should be equal!");
            Assert.AreEqual(30, testingTarget.position.Y, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEventSnapEventPosition END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEvent.SnapEvent duration.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapEvent.duration A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapEventDuration()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapEventDuration START");

            var testingTarget = new ScrollView.SnapEvent();
            Assert.IsNotNull(testingTarget, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(testingTarget, "Should be an instance of SnapEvent type.");

            testingTarget.duration = 0.5f;
            Assert.AreEqual(0.5f, testingTarget.duration, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEventSnapEventDuration END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEvent.SnapEvent type.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapEvent.type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapEventType()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapEventType START");

            var testingTarget = new ScrollView.SnapEvent();
            Assert.IsNotNull(testingTarget, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(testingTarget, "Should be an instance of SnapEvent type.");

            testingTarget.type = SnapType.Snap;
            Assert.AreEqual(SnapType.Snap, testingTarget.type, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEventSnapEventType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEvent.SnapEvent GetSnapEventFromPtr.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapEvent.GetSnapEventFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapEventGetSnapEventFromPtr()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapEventGetSnapEventFromPtr START");

            var testingTarget = new ScrollView.SnapEvent();
            Assert.IsNotNull(testingTarget, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(testingTarget, "Should be an instance of SnapEvent type.");

            var result = ScrollView.SnapEvent.GetSnapEventFromPtr(testingTarget.SwigCPtr.Handle);
            Assert.IsNotNull(result, "Can't create success object SnapEvent");
            Assert.IsInstanceOf<ScrollView.SnapEvent>(result, "Should be an instance of SnapEvent type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ScrollViewEventSnapEventGetSnapEventFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ScrollViewEvent.SnapStartedEventArgs SnapEventInfo.")]
        [Property("SPEC", "Tizen.NUI.ScrollViewEvent.SnapStartedEventArgs.SnapEventInfo A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ScrollViewEventSnapStartedEventArgsSnapEventInfo()
        {
            tlog.Debug(tag, $"ScrollViewEventSnapStartedEventArgsSnapEventInfo START");

            var testingTarget = new ScrollView.SnapStartedEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object SnapStartedEventArgs");
            Assert.IsInstanceOf<ScrollView.SnapStartedEventArgs>(testingTarget, "Should be an instance of SnapStartedEventArgs type.");

            testingTarget.SnapEventInfo = new ScrollView.SnapEvent();
            Assert.IsNotNull(testingTarget.SnapEventInfo);

            tlog.Debug(tag, $"ScrollViewEventSnapStartedEventArgsSnapEventInfo END (OK)");
        }

        private void OnSnapStarted(object sender, ScrollView.SnapStartedEventArgs e)
        {  }
    }
}
