using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/AngleAxis")]
    public class InternalAngleAxisTest
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
        [Description("AngleAxis constructor.")]
        [Property("SPEC", "Tizen.NUI.AngleAxis.AngleAxis C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleAxisConstructor()
        {
            tlog.Debug(tag, $"AngleAxisConstructor START");

            var testingTarget = new AngleAxis();
            Assert.IsNotNull(testingTarget, "Can't create success object AngleAxis");
            Assert.IsInstanceOf<AngleAxis>(testingTarget, "Should be an instance of AngleAxis type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AngleAxisConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleAxis constructor. With Radian and Vector3.")]
        [Property("SPEC", "Tizen.NUI.AngleAxis.AngleAxis C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleAxisConstructorWithRadianAndVector3()
        {
            tlog.Debug(tag, $"AngleAxisConstructorWithRadianAndVector3 START");

            using (Radian radian = new Radian(0.3f))
            {
                using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
                {
                    var testingTarget = new AngleAxis(radian, vector);
                    Assert.IsNotNull(testingTarget, "Can't create success object AngleAxis");
                    Assert.IsInstanceOf<AngleAxis>(testingTarget, "Should be an instance of AngleAxis type.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"AngleAxisConstructorWithRadianAndVector3 END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleAxis constructor. angle.")]
        [Property("SPEC", "Tizen.NUI.AngleAxis.angle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleAxisAngle()
        {
            tlog.Debug(tag, $"AngleAxisAngle START");

            using (Radian radian = new Radian(0.3f))
            {
                using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
                {
                    var testingTarget = new AngleAxis(radian, vector);
                    Assert.IsNotNull(testingTarget, "Can't create success object AngleAxis");
                    Assert.IsInstanceOf<AngleAxis>(testingTarget, "Should be an instance of AngleAxis type.");

                    Assert.AreEqual(0.3f, testingTarget.angle.ConvertToFloat(), "Should be equal!");

                    testingTarget.angle = new Radian(0.8f);
                    Assert.AreEqual(0.8f, testingTarget.angle.ConvertToFloat(), "Should be equal!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"AngleAxisAngle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleAxis constructor. axis.")]
        [Property("SPEC", "Tizen.NUI.AngleAxis.axis A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleAxisAxis()
        {
            tlog.Debug(tag, $"AngleAxisAxis START");

            using (Radian radian = new Radian(0.3f))
            {
                using (Vector3 vector = new Vector3(1.0f, 2.0f, 3.0f))
                {
                    var testingTarget = new AngleAxis(radian, vector);
                    Assert.IsNotNull(testingTarget, "Can't create success object AngleAxis");
                    Assert.IsInstanceOf<AngleAxis>(testingTarget, "Should be an instance of AngleAxis type.");

                    Assert.AreEqual(1.0f, testingTarget.axis.X, "Should be equal!");
                    Assert.AreEqual(2.0f, testingTarget.axis.Y, "Should be equal!");
                    Assert.AreEqual(3.0f, testingTarget.axis.Z, "Should be equal!");

                    testingTarget.axis = new Vector3(3.0f, 2.0f, 1.0f);
                    Assert.AreEqual(3.0f, testingTarget.axis.X, "Should be equal!");
                    Assert.AreEqual(2.0f, testingTarget.axis.Y, "Should be equal!");
                    Assert.AreEqual(1.0f, testingTarget.axis.Z, "Should be equal!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"AngleAxisAxis END (OK)");
        }
    }
}
