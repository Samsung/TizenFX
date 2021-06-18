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
        [Description("Create a LongPressGesture object. Check whether LongPressGesture is successfully created or not.")]
        [Property("SPEC", "Tizen.NUI.LongPressGesture.LongPressGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void LongPressGestureConstructor()
        {
            tlog.Debug(tag, $"LongPressGestureConstructor START");
            Gesture.StateType state = Gesture.StateType.Finished;
            LongPressGesture ret1 = new LongPressGesture(state);                      

            ret1.Dispose();
            
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
            Gesture.StateType state = Gesture.StateType.Finished;
            LongPressGesture ret1 = new LongPressGesture(state);

            uint num = ret1.NumberOfTouches;
            
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
            Gesture.StateType state = Gesture.StateType.Finished;
            LongPressGesture ret1 = new LongPressGesture(state);

            Vector2 v = ret1.ScreenPoint;
            ret1.Dispose();
            
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
            Gesture.StateType state = Gesture.StateType.Finished;
            LongPressGesture ret1 = new LongPressGesture(state);

            Vector2 v = ret1.LocalPoint;

            ret1.Dispose();
            
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
            Gesture.StateType state = Gesture.StateType.Finished;
            LongPressGesture ret1 = new LongPressGesture(state);

            global::System.Runtime.InteropServices.HandleRef a = LongPressGesture.getCPtr(ret1);
            
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
            Gesture.StateType state = Gesture.StateType.Finished;
            LongPressGesture ret1 = new LongPressGesture(state);  		
			
            LongPressGesture ret = LongPressGesture.GetLongPressGestureFromPtr(LongPressGesture.getCPtr(ret1).Handle);
			
            ret1.Dispose();
            ret.Dispose();

            
            tlog.Debug(tag, $"LongPressGestureGetLongPressGestureFromPtr END (OK)");
            Assert.Pass("LongPressGestureGetLongPressGestureFromPtr");
        }
    }

}
