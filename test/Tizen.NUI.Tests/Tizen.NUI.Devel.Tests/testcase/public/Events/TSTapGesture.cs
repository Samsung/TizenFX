using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/TapGesture")]
    class PublicTapGestureTest
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
        [Description("TapGesture constructor")]
        [Property("SPEC", "Tizen.NUI.TapGesture.TapGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureConstructor()
        {
            tlog.Debug(tag, $"TapGestureConstructor START");

            var testingTarget = new TapGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGesture NumberOfTaps.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.NumberOfTaps A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureNumberOfTaps()
        {
            tlog.Debug(tag, $"TapGestureNumberOfTaps START");

            var testingTarget = new TapGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

            var result = testingTarget.NumberOfTaps;
            tlog.Debug(tag, "NumberOfTaps : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureNumberOfTaps END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGesture NumberOfTouches.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureNumberOfTouches()
        {
            tlog.Debug(tag, $"TapGestureNumberOfTouches START");

            var testingTarget = new TapGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

            var result = testingTarget.NumberOfTouches;
            tlog.Debug(tag, "NumberOfTouches : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureNumberOfTouches END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGesture ScreenPoint.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.ScreenPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureScreenPoint()
        {
            tlog.Debug(tag, $"TapGestureScreenPoint START");

            var testingTarget = new TapGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

            var result =  testingTarget.ScreenPoint;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureScreenPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGesture LocalPoint.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.LocalPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureLocalPoint()
        {
            tlog.Debug(tag, $"TapGestureLocalPoint START");

            var testingTarget = new TapGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

            var result = testingTarget.LocalPoint;
            Assert.IsInstanceOf<Vector2>(result, "Should be an instance of Vector2 type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureLocalPoint END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGesture SourceType.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.SourceType A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Obsolete]
        public void TapGestureSourceType()
        {
            tlog.Debug(tag, $"TapGestureSourceType START");

            var testingTarget = new TapGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

            var result = testingTarget.SourceType;
            tlog.Debug(tag, "SourceType : " + result);

            testingTarget.Dispose();
            tlog.Debug(tag, $"TapGestureSourceType END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TapGesture GetTapGestureFromPtr.")]
        [Property("SPEC", "Tizen.NUI.TapGesture.GetTapGestureFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TapGestureGetTapGestureFromPtr()
        {
            tlog.Debug(tag, $"TapGestureGetTapGestureFromPtr START");

            using (TapGesture gesture = new TapGesture())
            {
                var testingTarget = TapGesture.GetTapGestureFromPtr(gesture.SwigCPtr.Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<TapGesture>(testingTarget, "Should be an instance of TapGesture type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TapGestureGetTapGestureFromPtr END (OK)");
        }
    }
}