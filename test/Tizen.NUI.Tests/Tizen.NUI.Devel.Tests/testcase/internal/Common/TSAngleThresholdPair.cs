using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/AngleThresholdPair")]
    public class InternalAngleThresholdPairTest
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
        [Description("AngleThresholdPair constructor.")]
        [Property("SPEC", "Tizen.NUI.AngleThresholdPair.AngleThresholdPair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleThresholdPairConstructor()
        {
            tlog.Debug(tag, $"AngleThresholdPairConstructor START");

            var testingTarget = new AngleThresholdPair();
            Assert.IsNotNull(testingTarget, "Can't create success object AngleThresholdPair");
            Assert.IsInstanceOf<AngleThresholdPair>(testingTarget, "Should be an instance of AngleThresholdPair type.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"AngleThresholdPairConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleThresholdPair constructor. With Radians.")]
        [Property("SPEC", "Tizen.NUI.AngleThresholdPair.AngleThresholdPair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleThresholdPairConstructorWithRadians()
        {
            tlog.Debug(tag, $"AngleThresholdPairConstructorWithRadians START");

            using (Radian t = new Radian(0.3f))
            {
                using (Radian u = new Radian(0.8f))
                {
                    var testingTarget = new AngleThresholdPair(t, u);
                    Assert.IsNotNull(testingTarget, "Can't create success object AngleThresholdPair");
                    Assert.IsInstanceOf<AngleThresholdPair>(testingTarget, "Should be an instance of AngleThresholdPair type.");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"AngleThresholdPairConstructorWithRadians END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleThresholdPair constructor. With AngleThresholdPair.")]
        [Property("SPEC", "Tizen.NUI.AngleThresholdPair.AngleThresholdPair C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleThresholdPairConstructorWithAngleThresholdPair()
        {
            tlog.Debug(tag, $"AngleThresholdPairConstructorWithAngleThresholdPair START");

            using (Radian t = new Radian(0.3f))
            {
                using (Radian u = new Radian(0.8f))
                {
                    using (AngleThresholdPair angleThresholdPair = new AngleThresholdPair(t, u))
                    {
                        var testingTarget = new AngleThresholdPair(angleThresholdPair);
                        Assert.IsNotNull(testingTarget, "Can't create success object AngleThresholdPair");
                        Assert.IsInstanceOf<AngleThresholdPair>(testingTarget, "Should be an instance of AngleThresholdPair type.");

                        testingTarget.Dispose();
                    }
                }
            }

            tlog.Debug(tag, $"AngleThresholdPairConstructorWithAngleThresholdPair END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleThresholdPair constructor. second.")]
        [Property("SPEC", "Tizen.NUI.AngleThresholdPair.second A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleThresholdPairSecond()
        {
            tlog.Debug(tag, $"AngleThresholdPairSecond START");

            using (Radian t = new Radian(0.3f))
            {
                using (Radian u = new Radian(0.8f))
                {
                    var testingTarget = new AngleThresholdPair(t, u);
                    Assert.IsNotNull(testingTarget, "Can't create success object AngleThresholdPair");
                    Assert.IsInstanceOf<AngleThresholdPair>(testingTarget, "Should be an instance of AngleThresholdPair type.");

                    Assert.AreEqual(0.8f, testingTarget.second.ConvertToFloat(), "Should be equal!");

                    testingTarget.second = new Radian(0.9f);
                    Assert.AreEqual(0.9f, testingTarget.second.ConvertToFloat(), "Should be equal!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"AngleThresholdPairSecond END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("AngleThresholdPair first.")]
        [Property("SPEC", "Tizen.NUI.AngleThresholdPair.first A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void AngleThresholdPairFirst()
        {
            tlog.Debug(tag, $"AngleThresholdPairFirst START");

            using (Radian t = new Radian(0.3f))
            {
                using (Radian u = new Radian(0.8f))
                {
                    var testingTarget = new AngleThresholdPair(t, u);
                    Assert.IsNotNull(testingTarget, "Can't create success object AngleThresholdPair");
                    Assert.IsInstanceOf<AngleThresholdPair>(testingTarget, "Should be an instance of AngleThresholdPair type.");

                    Assert.AreEqual(0.3f, testingTarget.first.ConvertToFloat(), "Should be equal!");

                    testingTarget.first = new Radian(0.4f);
                    Assert.AreEqual(0.4f, testingTarget.first.ConvertToFloat(), "Should be equal!");

                    testingTarget.Dispose();
                }
            }

            tlog.Debug(tag, $"AngleThresholdPairFirst END (OK)");
        }
    }
}
