using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/Gesture")]
    class PublicGestureTest
    {
        private const string tag = "NUITEST"; 
        private LongPressGesture longPressGesture;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            longPressGesture = new LongPressGesture(Gesture.StateType.Started);
        }

        [TearDown]
        public void Destroy()
        {
            longPressGesture?.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("Gesture constructor")]
        [Property("SPEC", "Tizen.NUI.Gesture.Gesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureConstructor()
        {
            tlog.Debug(tag, $"GestureConstructor START");
            
            var testingTarget = new Gesture(longPressGesture);
            Assert.IsNotNull(testingTarget, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(testingTarget, "Should be an instance of Gesture type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"GestureConstructor END (OK)");
            Assert.Pass("GestureConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Gesture type")]
        [Property("SPEC", "Tizen.NUI.Gesture.type A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureType()
        {
            tlog.Debug(tag, $"GestureType START");

            var testingTarget = new Gesture(longPressGesture);
            Assert.IsNotNull(testingTarget, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(testingTarget, "Should be an instance of Gesture type.");

            try
            {
                var type = testingTarget.Type;
                tlog.Debug(tag, "type : " + type);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, "Caught Exception" + e.ToString());                
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GestureType END (OK)");
            Assert.Pass("GestureType");
        }

        [Test]
        [Category("P1")]
        [Description("Gesture state")]
        [Property("SPEC", "Tizen.NUI.Gesture.state A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureState()
        {
            tlog.Debug(tag, $"GestureState START");

            var testingTarget = new Gesture(longPressGesture);
            Assert.IsNotNull(testingTarget, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(testingTarget, "Should be an instance of Gesture type.");

            try
            {
                var state = testingTarget.State;
                tlog.Debug(tag, "state : " + state);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GestureState END (OK)");
            Assert.Pass("GestureState");
        }

        [Test]
        [Category("P1")]
        [Description("Gesture time")]
        [Property("SPEC", "Tizen.NUI.Gesture.time A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureTime()
        {
            tlog.Debug(tag, $"GestureTime START");

            var testingTarget = new Gesture(longPressGesture);
            Assert.IsNotNull(testingTarget, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(testingTarget, "Should be an instance of Gesture type.");

            try
            {
                var time = testingTarget.Time;
                tlog.Debug(tag, "time : " + time);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"GestureTime END (OK)");
            Assert.Pass("GestureTime");
        }


        [Test]
        [Category("P1")]
        [Description("Gesture GetGestureFromPtr")]
        [Property("SPEC", "Tizen.NUI.Gesture.GetGestureFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GetstureGetGestureFromPtr()
        {
            tlog.Debug(tag, $"GetstureGetGestureFromPtr START");

            var testingTarget = Gesture.GetGestureFromPtr(longPressGesture.SwigCPtr.Handle);
            Assert.IsNotNull(testingTarget, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(testingTarget, "Should be an instance of Gesture type.");

            testingTarget.Dispose();

            tlog.Debug(tag, $"GetstureGetGestureFromPtr END (OK)");
            Assert.Pass("GetstureGetGestureFromPtr");
        }
    }
}
