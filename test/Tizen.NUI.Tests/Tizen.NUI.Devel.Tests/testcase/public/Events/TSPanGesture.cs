using NUnit.Framework;
using NUnit.Framework.TUnit;
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Events/PanGesture")]
    public class PublicPanGestureTest
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
        [Description("Create a PanGesture object.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.PanGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureConstructor()
        {
            tlog.Debug(tag, $"PanGestureConstructor START");

            var testingTarget = new PanGesture();
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureConstructor END (OK)");
            Assert.Pass("PanGestureConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Create a PanGesture object.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.PanGesture C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureConstructorWithState()
        {
            tlog.Debug(tag, $"PanGestureConstructorWithState START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureConstructorWithState END (OK)");
            Assert.Pass("PanGestureConstructor");
        }

        [Test]
        [Category("P1")]
        [Description("Test Velocity property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.Velocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureVelocity()
        {
            tlog.Debug(tag, $"PanGestureVelocity START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "Velocity : " + testingTarget.Velocity);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureVelocity END (OK)");
            Assert.Pass("PanGestureVelocity");
        }

        [Test]
        [Category("P1")]
        [Description("Test Displacement property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.Displacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureDisplacement()
        {
            tlog.Debug(tag, $"PanGestureDisplacement START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "Displacement : " + testingTarget.Displacement);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureDisplacement END (OK)");
            Assert.Pass("PanGestureDisplacement");
        }

        [Test]
        [Category("P1")]
        [Description("Test Position property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.Position A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGesturePosition()
        {
            tlog.Debug(tag, $"PanGesturePosition START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "Position : " + testingTarget.Position);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGesturePosition END (OK)");
            Assert.Pass("PanGesturePosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenVelocity property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.ScreenVelocity A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureScreenVelocity()
        {
            tlog.Debug(tag, $"PanGestureScreenVelocity START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "ScreenVelocity : " + testingTarget.ScreenVelocity);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureScreenVelocity END (OK)");
            Assert.Pass("PanGestureScreenVelocity");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenDisplacement property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.ScreenDisplacement A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureScreenDisplacement()
        {
            tlog.Debug(tag, $"PanGestureScreenDisplacement START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "ScreenDisplacement : " + testingTarget.ScreenDisplacement);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureScreenDisplacement END (OK)");
            Assert.Pass("PanGestureScreenDisplacement");
        }

        [Test]
        [Category("P1")]
        [Description("Test ScreenPosition property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.ScreenPosition A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureScreenPosition()
        {
            tlog.Debug(tag, $"PanGestureScreenPosition START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "ScreenPosition : " + testingTarget.ScreenPosition);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureScreenPosition END (OK)");
            Assert.Pass("PanGestureScreenPosition");
        }

        [Test]
        [Category("P1")]
        [Description("Test NumberOfTouches property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.NumberOfTouches A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureNumberOfTouches()
        {
            tlog.Debug(tag, $"PanGestureNumberOfTouches START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "NumberOfTouches : " + testingTarget.NumberOfTouches);

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureNumberOfTouches END (OK)");
            Assert.Pass("PanGestureNumberOfTouches");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetSpeed property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureGetSpeed()
        {
            tlog.Debug(tag, $"PanGestureGetSpeed START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "GetSpeed : " + testingTarget.GetSpeed());

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureGetSpeed END (OK)");
            Assert.Pass("PanGestureGetSpeed");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetDistance property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureGetDistance()
        {
            tlog.Debug(tag, $"PanGestureGetDistance START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "GetDistance : " + testingTarget.GetDistance());

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureGetDistance END (OK)");
            Assert.Pass("PanGestureGetDistance");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScreenSpeed property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetScreenSpeed M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureGetScreenSpeed()
        {
            tlog.Debug(tag, $"PanGestureGetScreenSpeed START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "GetScreenSpeed : " + testingTarget.GetScreenSpeed());

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureGetScreenSpeed END (OK)");
            Assert.Pass("PanGestureGetScreenSpeed");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetScreenDistance property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetScreenDistance M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureGetScreenDistance()
        {
            tlog.Debug(tag, $"PanGestureGetScreenDistance START");

            var testingTarget = new PanGesture(Gesture.StateType.Finished);
            Assert.IsNotNull(testingTarget, "Can't create success object Hover");
            Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

            tlog.Debug(tag, "GetScreenDistance : " + testingTarget.GetScreenDistance());

            testingTarget.Dispose();
            tlog.Debug(tag, $"PanGestureGetScreenDistance END (OK)");
            Assert.Pass("PanGestureGetScreenDistance");
        }

        [Test]
        [Category("P1")]
        [Description("Test getCPtr property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGesturegetCPtr()
        {
            tlog.Debug(tag, $"PanGesturegetCPtr START");

            using (PanGesture gesture = new PanGesture())
            {
                try
                {
                    PanGesture.getCPtr(gesture);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }
            }

            tlog.Debug(tag, $"PanGesturegetCPtr END (OK)");
            Assert.Pass("PanGestureCPtr");
        }

        [Test]
        [Category("P1")]
        [Description("Test GetPanGestureFromPtr property.")]
        [Property("SPEC", "Tizen.NUI.PanGesture.GetPanGestureFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void PanGestureGetPanGestureFromPtr()
        {
            tlog.Debug(tag, $"PanGestureGetPanGestureFromPtr START");

            using (PanGesture gesture = new PanGesture())
            {
                var testingTarget = PanGesture.GetPanGestureFromPtr(PanGesture.getCPtr(gesture).Handle);
                Assert.IsNotNull(testingTarget, "Can't create success object Hover");
                Assert.IsInstanceOf<PanGesture>(testingTarget, "Should be an instance of PanGesture type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"PanGestureGetPanGestureFromPtr END (OK)");
            Assert.Pass("PanGestureGetPanGestureFromPtr");
        }
    }
}
