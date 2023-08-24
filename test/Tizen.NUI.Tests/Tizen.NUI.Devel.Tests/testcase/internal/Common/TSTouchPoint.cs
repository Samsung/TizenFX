using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TouchPoint")]
    public class InternalTouchPointTest
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
        [Description("TouchPoint constructor.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.TouchPoint C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructor()
        {
            tlog.Debug(tag, $"TouchPointConstructor START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPoint constructor.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.TouchPoint C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructorWithLocalValue()
        {
            tlog.Debug(tag, $"TouchPointConstructorWithLocalValue START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f, 1.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructorWithLocalValue END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPoint DeviceId.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.DeviceId A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructorDeviceId()
        {
            tlog.Debug(tag, $"TouchPointConstructorDeviceId START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f, 1.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            testingTarget.DeviceId = 1;
            Assert.AreEqual(1, testingTarget.DeviceId, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructorDeviceId END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPoint State.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.State A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructorState()
        {
            tlog.Debug(tag, $"TouchPointConstructorState START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f, 1.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            testingTarget.State = TouchPoint.StateType.Last;
            Assert.AreEqual(TouchPoint.StateType.Last, testingTarget.State, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructorState END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPoint HitView.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.HitView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructorHitView()
        {
            tlog.Debug(tag, $"TouchPointConstructorHitView START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f, 1.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            using (View view = new View())
            {
                testingTarget.HitView = view;
                Assert.AreEqual(view, testingTarget.HitView, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructorHitView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPoint Local.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.Local A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructorLocal()
        {
            tlog.Debug(tag, $"TouchPointConstructorLocal START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f, 1.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            using (Vector2 vector = new Vector2(0.0f, 0.0f))
            {
                testingTarget.Local = vector;
                Assert.AreEqual(0.0f, testingTarget.Local.X, "Should be equal!");
                Assert.AreEqual(0.0f, testingTarget.Local.Y, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructorLocal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TouchPoint Screen.")]
        [Property("SPEC", "Tizen.NUI.TouchPoint.Screen A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TouchPointConstructorScreen()
        {
            tlog.Debug(tag, $"TouchPointConstructorScreen START");

            var testingTarget = new TouchPoint(1, TouchPoint.StateType.Started, 0.0f, 0.0f, 1.0f, 2.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TouchPoint>(testingTarget, "Should be an Instance of TouchPoint!");

            using (Vector2 vector = new Vector2(1.0f, 2.0f))
            {
                testingTarget.Screen = vector;
                Assert.AreEqual(1.0f, testingTarget.Screen.X, "Should be equal!");
                Assert.AreEqual(2.0f, testingTarget.Screen.Y, "Should be equal!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"TouchPointConstructorScreen END (OK)");
        }
    }
}
