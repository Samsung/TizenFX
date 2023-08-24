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
    [Description("public/BaseComponents/ViewAccessibilityEvent")]
    public class PublicViewAccessibilityEventTest
    {
        private const string tag = "NUITEST";

        private void OnAccessibilityDescriptionRequested(object sender, GetDescriptionEventArgs e) { }
        private void OnAccessibilityGestureInfoReceived(object sender, GestureInfoEventArgs e) { }
        private void OnAccessibilityNameRequested(object sender, GetNameEventArgs e) { }
        private void OnAccessibilityReadingStopped(object sender, EventArgs e) { }
        private void OnAccessibilityReadingCancelled(object sender, EventArgs e) { }
        private void OnAccessibilityReadingResumed(object sender, EventArgs e) { }
        private void OnAccessibilityReadingPaused(object sender, EventArgs e) { }
        private void OnAccessibilityReadingSkipped(object sender, EventArgs e) { }
        private void OnAccessibilityActivated(object sender, EventArgs e) { }

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
        [Description("GestureInfoType constructor.")]
        [Property("SPEC", "Tizen.NUI.GestureInfoType.GestureInfoType C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureInfoTypeConstructor()
        {
            tlog.Debug(tag, $"GestureInfoTypeConstructor START");

            var testingTarget = new GestureInfoType();
            Assert.IsNotNull(testingTarget, "Can't create success object GestureInfoType");
            Assert.IsInstanceOf<GestureInfoType>(testingTarget, "Should be an instance of GestureInfoType type.");

            testingTarget.Type = AccessibilityGesture.OneFingerFlickLeft;
            tlog.Debug(tag , "Type : " + testingTarget.Type);

            testingTarget.StartPositionX = 10;
            tlog.Debug(tag, "StartPositionX : " + testingTarget.StartPositionX);

            testingTarget.StartPositionY = 20;
            tlog.Debug(tag, "StartPositionY : " + testingTarget.StartPositionY);

            testingTarget.EndPositionX = 100;
            tlog.Debug(tag, "EndPositionX : " + testingTarget.EndPositionX);

            testingTarget.EndPositionY = 200;
            tlog.Debug(tag, "EndPositionY : " + testingTarget.EndPositionY);

            testingTarget.State = AccessibilityGestureState.Begin;
            tlog.Debug(tag, "State  : " + testingTarget.State);

            testingTarget.EventTime = 3;
            tlog.Debug(tag, "EventTime : " + testingTarget.EventTime);

            var result = testingTarget.Equals(new GestureInfoType());
            tlog.Debug(tag, "Equals : " + result);

            GestureInfoType dummy = new GestureInfoType();
            tlog.Debug(tag, "== :" + (testingTarget == dummy));
            tlog.Debug(tag, "!= :" + (testingTarget != dummy));

            tlog.Debug(tag, "hashcode : " + testingTarget.GetHashCode());

            tlog.Debug(tag, $"GestureInfoTypeConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GestureInfoEventArgs GestureInfo.")]
        [Property("SPEC", "Tizen.NUI.GestureInfoEventArgs.GestureInfo C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureInfoEventArgsGestureInfo()
        {
            tlog.Debug(tag, $"GestureInfoEventArgsGestureInfo START");

            var testingTarget = new GestureInfoEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object GestureInfoEventArgs");
            Assert.IsInstanceOf<GestureInfoEventArgs>(testingTarget, "Should be an instance of GestureInfoEventArgs type.");

            tlog.Debug(tag, "GestureInfo : " + testingTarget.GestureInfo);

            testingTarget.Consumed = true;
            tlog.Debug(tag, "Consumed : " + testingTarget.Consumed);

            tlog.Debug(tag, $"GestureInfoEventArgsGestureInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GetDescriptionEventArgs Description.")]
        [Property("SPEC", "Tizen.NUI.GetDescriptionEventArgs.Description C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GetDescriptionEventArgsDescription()
        {
            tlog.Debug(tag, $"GetDescriptionEventArgsDescription START");

            var testingTarget = new GetDescriptionEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object GetDescriptionEventArgs");
            Assert.IsInstanceOf<GetDescriptionEventArgs>(testingTarget, "Should be an instance of GetDescriptionEventArgs type.");

            testingTarget.Description = "description";
            tlog.Debug(tag, "Description : " + testingTarget.Description);

            tlog.Debug(tag, $"GetDescriptionEventArgsDescription END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("GetNameEventArgs Name.")]
        [Property("SPEC", "Tizen.NUI.GetNameEventArgs.Name C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GetNameEventArgsName()
        {
            tlog.Debug(tag, $"GetNameEventArgsName START");

            var testingTarget = new GetNameEventArgs();
            Assert.IsNotNull(testingTarget, "Can't create success object GetDescriptionEventArgs");
            Assert.IsInstanceOf<GetNameEventArgs>(testingTarget, "Should be an instance of GetNameEventArgs type.");

            testingTarget.Name = "accessibility";
            tlog.Debug(tag, "Name : " + testingTarget.Name);

            tlog.Debug(tag, $"GetNameEventArgsName END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("View AccessibilityDescriptionRequested.")]
        [Property("SPEC", "Tizen.NUI.View.AccessibilityDescriptionRequested A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ViewAccessibilityDescriptionRequested()
        {
            tlog.Debug(tag, $"ViewAccessibilityDescriptionRequested START");

            var testingTarget = new View()
            {
                Size = new Size(100, 50),
                Color = Color.Cyan
            };
            Assert.IsNotNull(testingTarget, "Can't create success object View");
            Assert.IsInstanceOf<View>(testingTarget, "Should be an instance of View type.");

            testingTarget.AccessibilityDescriptionRequested += OnAccessibilityDescriptionRequested;
            testingTarget.AccessibilityDescriptionRequested -= OnAccessibilityDescriptionRequested;

            testingTarget.AccessibilityGestureInfoReceived += OnAccessibilityGestureInfoReceived;
            testingTarget.AccessibilityGestureInfoReceived -= OnAccessibilityGestureInfoReceived;

            testingTarget.AccessibilityNameRequested += OnAccessibilityNameRequested;
            testingTarget.AccessibilityNameRequested -= OnAccessibilityNameRequested;

            testingTarget.AccessibilityActivated += OnAccessibilityActivated;
            testingTarget.AccessibilityActivated -= OnAccessibilityActivated;

            testingTarget.AccessibilityReadingSkipped += OnAccessibilityReadingSkipped;
            testingTarget.AccessibilityReadingSkipped -= OnAccessibilityReadingSkipped;

            testingTarget.AccessibilityReadingPaused += OnAccessibilityReadingPaused;
            testingTarget.AccessibilityReadingPaused -= OnAccessibilityReadingPaused;

            testingTarget.AccessibilityReadingResumed += OnAccessibilityReadingResumed;
            testingTarget.AccessibilityReadingResumed -= OnAccessibilityReadingResumed;

            testingTarget.AccessibilityReadingCancelled += OnAccessibilityReadingCancelled;
            testingTarget.AccessibilityReadingCancelled -= OnAccessibilityReadingCancelled;

            testingTarget.AccessibilityReadingStopped += OnAccessibilityReadingStopped;
            testingTarget.AccessibilityReadingStopped -= OnAccessibilityReadingStopped;

            testingTarget.Dispose();
            tlog.Debug(tag, $"ViewAccessibilityDescriptionRequested END (OK)");
        }
    }
}
