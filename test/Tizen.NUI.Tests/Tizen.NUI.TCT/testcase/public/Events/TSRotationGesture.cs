using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/RotationGesture")]
    class PublicRotationGestureTest
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
        [Description("RotationGesture constructor")]
        [Property("SPEC", "Tizen.NUI.RotationGesture.RotationGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureConstructor()
        {
            tlog.Debug(tag, $"RotationGestureConstructor START");            

            Gesture.StateType state = Gesture.StateType.Finished;
            RotationGesture a2 = new RotationGesture(state);

            a2.Dispose();            

            
            tlog.Debug(tag, $"RotationGestureConstructor END (OK)");
            Assert.Pass("RotationGesture");
        }

        [Test]
        [Category("P1")]
        [Description("Test Rotation property.")]
        [Property("SPEC", "Tizen.NUI.RotationGesture.Rotation A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureRotation()
        {
            tlog.Debug(tag, $"RotationGestureRotation START");
            Gesture.StateType state = Gesture.StateType.Finished;
            RotationGesture a1 = new RotationGesture(state);

            float f1 = a1.Rotation;
            
            tlog.Debug(tag, $"RotationGestureRotation END (OK)");
            Assert.Pass("RotationGestureRotation");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenCenterPoint property.")]
        [Property("SPEC", "Tizen.NUI.RotationGesture.ScreenCenterPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureScreenCenterPoint()
        {
            tlog.Debug(tag, $"RotationGestureScreenCenterPoint START");
            Gesture.StateType state = Gesture.StateType.Finished;
            RotationGesture a1 = new RotationGesture(state);

            Vector2 v1 = a1.ScreenCenterPoint;
            
            tlog.Debug(tag, $"RotationGestureScreenCenterPoint END (OK)");
            Assert.Pass("RotationGestureScreenCenterPoint");
        }

        [Test]
        [Category("P1")]
        [Description("Test LocalCenterPoint property.")]
        [Property("SPEC", "Tizen.NUI.RotationGesture.LocalCenterPoint A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureLocalCenterPoint()
        {
            tlog.Debug(tag, $"RotationGestureLocalCenterPoint START");
            Gesture.StateType state = Gesture.StateType.Finished;
            RotationGesture a1 = new RotationGesture(state);

            Vector2 v1 = a1.LocalCenterPoint;
            
            tlog.Debug(tag, $"RotationGestureLocalCenterPoint END (OK)");
            Assert.Pass("RotationGestureLocalCenterPoint");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGesture getCPtr")]
        [Property("SPEC", "Tizen.NUI.RotationGesture.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGesturegetCPtr()
        {
            tlog.Debug(tag, $"RotationGesturegetCPtr START");
            Gesture.StateType state = Gesture.StateType.Finished;
            RotationGesture a1 = new RotationGesture(state);
            global::System.Runtime.InteropServices.HandleRef r1 = RotationGesture.getCPtr(a1);
            
            tlog.Debug(tag, $"RotationGesturegetCPtr END (OK)");
            Assert.Pass("RotationGesturegetCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("RotationGesture GetRotationGestureFromPtr")]
        [Property("SPEC", "Tizen.NUI.RotationGesture.GetRotationGestureFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void RotationGestureGetRotationGestureFromPtr()
        {
            tlog.Debug(tag, $"RotationGestureGetRotationGestureFromPtr START");
            Gesture.StateType state = Gesture.StateType.Finished;
            RotationGesture a2 = new RotationGesture(state);         		
            RotationGesture a1 = RotationGesture.GetRotationGestureFromPtr(RotationGesture.getCPtr(a2).Handle);
            
            a2.Dispose();            
            tlog.Debug(tag, $"RotationGestureGetRotationGestureFromPtr END (OK)");
            Assert.Pass("RotationGestureGetRotationGestureFromPtr");
        }
    }

}