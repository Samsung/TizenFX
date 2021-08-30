using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/LongPressGesture")]
    internal class PublicLongPressGestureTest
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
        [Description("Create a LongPressGesture object.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.LongPressGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureConstructor()
        {
            tlog.Debug(tag, $"LongPressGestureConstructor START");

            var testingTarget = new LongPressGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGesture>(testingTarget, "Should be an instance of Hover type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureConstructor END (OK)");
            Assert.Pass("LongPressGestureConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfTouches property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureNumberOfTouches()
        {
            tlog.Debug(tag, $"LongPressGestureNumberOfTouches START");

            var testingTarget = new LongPressGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGesture>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "NumberOfTouches : " + testingTarget.NumberOfTouches);

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureNumberOfTouches END (OK)");
            Assert.Pass("LongPressGestureNumberOfTouches");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenPoint property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.ScreenPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureScreenPoint()
        {
            tlog.Debug(tag, $"LongPressGestureScreenPoint START");

            var testingTarget = new LongPressGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGesture>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "ScreenPoint : " + testingTarget.ScreenPoint);

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureScreenPoint END (OK)");
            Assert.Pass("LongPressGestureScreenPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalPoint property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.LocalPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureLocalPoint()
        {
            tlog.Debug(tag, $"LongPressGestureLocalPoint START");

            var testingTarget = new LongPressGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGesture>(testingTarget, "Should be an instance of Hover type.");

            tlog.Debug(tag, "LocalPoint : " + testingTarget.LocalPoint);

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGestureLocalPoint END (OK)");
            Assert.Pass("LongPressGestureLocalPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test getCPtr property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGesturegetCPtr()
        {
            tlog.Debug(tag, $"LongPressGesturegetCPtr START");

            var testingTarget = new LongPressGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<LongPressGesture>(testingTarget, "Should be an instance of Hover type.");

            try
            {
                LongPressGesture.getCPtr(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"LongPressGesturegetCPtr END (OK)");
            Assert.Pass("LongPressGestureLocalPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetLongPressGestureFromPtr property.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.GetLongPressGestureFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureGetLongPressGestureFromPtr()
        {
            tlog.Debug(tag, $"LongPressGestureGetLongPressGestureFromPtr START");

            using (LongPressGesture gestrue = new LongPressGesture(Gesture.StateType.Finished))
            {
                var testingTarget = LongPressGesture.GetLongPressGestureFromPtr(LongPressGesture.getCPtr(gestrue).Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<LongPressGesture>(testingTarget, "Should be an instance of Hover type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"LongPressGestureGetLongPressGestureFromPtr END (OK)");
            Assert.Pass("LongPressGestureGetLongPressGestureFromPtr");
        }
    }

}
