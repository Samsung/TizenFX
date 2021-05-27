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
        [Description("Gesture constructor")]
        [Property("SPEC", "Tizen.NUI.Gesture.Gesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GestureConstructor()
        {
            tlog.Debug(tag, $"GestureConstructor START");
            
            var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
            var gesture = new Gesture(longPressGesture);
			
            longPressGesture.Dispose();
            gesture.Dispose();
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
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
                var gesture = new Gesture(longPressGesture);
                Assert.IsNotNull(gesture, "Can't create success object Gesture");
                Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
                Gesture.GestureType type = gesture.Type;
                Assert.AreEqual(Gesture.GestureType.LongPress, type, "Should be same value");

                gesture.Dispose();
                longPressGesture.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());                
                Assert.Fail("Caught Exception" + e.ToString());
            }
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
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
                var gesture = new Gesture(longPressGesture);
                Assert.IsNotNull(gesture, "Can't create success object Gesture");
                Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
                Gesture.StateType state = gesture.State;
                Assert.AreEqual(Gesture.StateType.Cancelled, state, "Should be same value");

                gesture.Dispose();
                longPressGesture.Dispose();

            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                
                Assert.Fail("Caught Exception" + e.ToString());
            }
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
            try
            {
                var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);
                Assert.IsNotNull(longPressGesture, "Can't create success object LongPressGesture");
                var gesture = new Gesture(longPressGesture);
                Assert.IsNotNull(gesture, "Can't create success object Gesture");
                Assert.IsInstanceOf<Gesture>(gesture, "Should be an instance of Gesture type.");
                uint time = gesture.Time;
                Assert.GreaterOrEqual(time, 0, "Should be greater or equal 0");

                gesture.Dispose();
                longPressGesture.Dispose();
            }
            catch (Exception e)
            {
                Tizen.Log.Error(tag, "Caught Exception" + e.ToString());
                
                Assert.Fail("Caught Exception" + e.ToString());
            }
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
			
            var longPressGesture = new LongPressGesture(Gesture.StateType.Cancelled);            
            var gesture = new Gesture(longPressGesture);
			
            Gesture ret = Gesture.GetGestureFromPtr(Gesture.getCPtr(gesture).Handle);

            Assert.IsNotNull(ret, "Can't create success object Gesture");
            Assert.IsInstanceOf<Gesture>(ret, "Should be an instance of Gesture type.");
			
            ret.Dispose();
            gesture.Dispose();
            longPressGesture.Dispose();
			
            tlog.Debug(tag, $"GetstureGetGestureFromPtr END (OK)");
            Assert.Pass("GetstureGetGestureFromPtr");
        }
    }
}
