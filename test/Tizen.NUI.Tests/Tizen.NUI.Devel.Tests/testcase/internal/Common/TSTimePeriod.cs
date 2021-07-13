using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Common/TimePeriod")]
    public class InternalTimePeriodTest
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
        [Description("TimePeriod constructor.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.TimePeriod C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodConstructor()
        {
            tlog.Debug(tag, $"TimePeriodConstructor START");

            var testingTarget = new TimePeriod(300);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should be an Instance of TimePeriod!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePeriod constructor. With delayMilliSeconds.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.TimePeriod C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodConstructorWithDelayMilliSeconds()
        {
            tlog.Debug(tag, $"TimePeriodConstructorWithDelayMilliSeconds START");

            var testingTarget = new TimePeriod(0.3f, 1.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should be an Instance of TimePeriod!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodConstructorWithDelayMilliSeconds END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePeriod DelayMilliseconds.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.DelayMilliseconds A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodConstructorDelayMilliseconds()
        {
            tlog.Debug(tag, $"TimePeriodConstructorDelayMilliseconds START");

            var testingTarget = new TimePeriod(0.3f, 1.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should be an Instance of TimePeriod!");

            testingTarget.DelayMilliseconds = 20;
            Assert.AreEqual(20, testingTarget.DelayMilliseconds, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodConstructorDelayMilliseconds END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePeriod DurationMilliseconds.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.DurationMilliseconds A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodConstructorDurationMilliseconds()
        {
            tlog.Debug(tag, $"TimePeriodConstructorDurationMilliseconds START");

            var testingTarget = new TimePeriod(0.3f, 1.0f);
            Assert.IsNotNull(testingTarget, "Should be not null!");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should be an Instance of TimePeriod!");

            testingTarget.DurationMilliseconds = 150;
            Assert.AreEqual(150, testingTarget.DurationMilliseconds, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodConstructorDurationMilliseconds END (OK)");
        }
    }
}
