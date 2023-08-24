using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/PinchGesture")]
    class PublicPinchGestureTest
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
        [Description("PinchGesture constructor")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.PinchGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureConstructor()
        {
            tlog.Debug(tag, $"PinchGestureConstructor START");
            
            Gesture.StateType state = Gesture.StateType.Finished;
            PinchGesture a2 = new PinchGesture(state);

            a2.Dispose();            
            
            tlog.Debug(tag, $"PinchGestureConstructor END (OK)");
            Assert.Pass("PinchGestureConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test Scale property.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.Scale A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureScale()
        {
            tlog.Debug(tag, $"PinchGestureScale START");
            Gesture.StateType state = Gesture.StateType.Finished;
            PinchGesture a1 = new PinchGesture(state);

            float f1 = a1.Scale;
            
            tlog.Debug(tag, $"PinchGestureScale END (OK)");
            Assert.Pass("PinchGestureScale");
        }

        [Test]
        [Category("P1")]
        [Description("Test Speed property.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.Speed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureSpeed()
        {
            tlog.Debug(tag, $"PinchGestureSpeed START");
            Gesture.StateType state = Gesture.StateType.Finished;
            PinchGesture a1 = new PinchGesture(state);

            float f1 = a1.Speed;
            
            tlog.Debug(tag, $"PinchGestureSpeed END (OK)");
            Assert.Pass("PinchGestureSpeed");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenCenterPoint property.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.ScreenCenterPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureScreenCenterPoint()
        {
            tlog.Debug(tag, $"PinchGestureScreenCenterPoint START");
            Gesture.StateType state = Gesture.StateType.Finished;
            PinchGesture a1 = new PinchGesture(state);

            Vector2 v1 = a1.ScreenCenterPoint;
            
            tlog.Debug(tag, $"PinchGestureScreenCenterPoint END (OK)");
            Assert.Pass("ScreenCenterPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalCenterPoint property.")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.LocalCenterPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureLocalCenterPoint()
        {
            tlog.Debug(tag, $"PinchGestureLocalCenterPoint START");
            Gesture.StateType state = Gesture.StateType.Finished;
            PinchGesture a1 = new PinchGesture(state);

            Vector2 v1 = a1.LocalCenterPoint;
            
            tlog.Debug(tag, $"PinchGestureLocalCenterPoint END (OK)");
            Assert.Pass("LocalCenterPoint");
        }
        [Test]
        [Category("P1")]
        [Description("PinchGesture GetPinchGestureFromPtr")]
        [Property("SPEC", "Tizen.NUI.PinchGesture.GetPinchGestureFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PinchGestureGetPinchGestureFromPtr()
        {
            tlog.Debug(tag, $"PinchGestureGetPinchGestureFromPtr START");
			
            Gesture.StateType state = Gesture.StateType.Finished;
            PinchGesture a2 = new PinchGesture(state);			
            
            PinchGesture a1 = PinchGesture.GetPinchGestureFromPtr(a2.SwigCPtr.Handle);
            
            a2.Dispose();
            tlog.Debug(tag, $"PinchGestureGetPinchGestureFromPtr END (OK)");
            Assert.Pass("PinchGestureGetPinchGestureFromPtr");
        }
    }
}
