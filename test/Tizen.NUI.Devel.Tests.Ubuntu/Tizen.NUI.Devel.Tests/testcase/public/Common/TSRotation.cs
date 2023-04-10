using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/Rotation")]
    public class RotationTest
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
        [Description("Rotation constructor. With Euler Angles")]
        [Property("SPEC", "Tizen.NUI.Rotation.Rotation C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void RotationConstructorWithEulerAngle()
        {
            tlog.Debug(tag, $"RotationConstructorWithEulerAngle START");

            var testingTarget = new Rotation(new Radian(new Degree(30.0f)), new Radian(new Degree(45.0f)), new Radian(new Degree(60.0f)));
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation.");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationConstructorWithEulerAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation SetEulerAngle.")]
        [Property("SPEC", "Tizen.NUI.Rotation.SetEulerAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void RotationSetEulerAngle()
        {
            tlog.Debug(tag, $"RotationSetEulerAngle START");

            var testingTarget = new Rotation();
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation.");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            try
            {
                testingTarget.SetEulerAngle(new Radian(new Degree(30.0f)), new Radian(new Degree(45.0f)), new Radian(new Degree(60.0f)));
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationSetEulerAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Rotation GetEulerAngle.")]
        [Property("SPEC", "Tizen.NUI.Rotation.GetEulerAngle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "eunkiki.hong@samsung.com")]
        public void RotationGetEulerAngle()
        {
            tlog.Debug(tag, $"RotationGetEulerAngle START");

            var expectPitchRadian = new Radian(new Degree(30.0f));
            var expectYawRadian = new Radian(new Degree(45.0f));
            var expectRollRadian = new Radian(new Degree(60.0f));
            var testingTarget = new Rotation(expectPitchRadian, expectYawRadian, expectRollRadian);
            Assert.IsNotNull(testingTarget, "Can't create success object Rotation.");
            Assert.IsInstanceOf<Rotation>(testingTarget, "Should return Rotation instance.");

            try
            {
                using var pitch = new Radian();
                using var yaw = new Radian();
                using var roll = new Radian();
                testingTarget.GetEulerAngle(pitch, yaw, roll);

                Assert.AreEqual(expectPitchRadian.Value, pitch.Value, 0.001, "Pitch value should be same");
                Assert.AreEqual(expectYawRadian.Value, yaw.Value,  0.001, "Yaw value should be same");
                Assert.AreEqual(expectRollRadian.Value, roll.Value, 0.001, "Roll value should be same");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception : Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"RotationGetEulerAngle END (OK)");
        }
    }
}
