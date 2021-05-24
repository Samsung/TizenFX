using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Common/TimePeriod")]
    public class PublicTimePeriodTest
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
            Assert.IsNotNull(testingTarget, "Can't create success object TimePeriod");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should return TimePeriod instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePeriod constructor.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.TimePeriod C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodConstructorWithFloats()
        {
            tlog.Debug(tag, $"TimePeriodConstructorWithFloats START");

            var testingTarget = new TimePeriod(0, 300);
            Assert.IsNotNull(testingTarget, "Can't create success object TimePeriod");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should return TimePeriod instance.");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodConstructorWithFloats END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePeriod DelayMilliseconds.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.DelayMilliseconds A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodDelayMilliseconds()
        {
            tlog.Debug(tag, $"TimePeriodDelayMilliseconds START");

            var testingTarget = new TimePeriod(0, 300);
            Assert.IsNotNull(testingTarget, "Can't create success object TimePeriod");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should return TimePeriod instance.");

            testingTarget.DelayMilliseconds = 20;
            Assert.AreEqual(20, testingTarget.DelayMilliseconds, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodDelayMilliseconds END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("TimePeriod DurationMilliseconds.")]
        [Property("SPEC", "Tizen.NUI.TimePeriod.DurationMilliseconds A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimePeriodDurationMilliseconds()
        {
            tlog.Debug(tag, $"TimePeriodDurationMilliseconds START");

            var testingTarget = new TimePeriod(0, 300);
            Assert.IsNotNull(testingTarget, "Can't create success object TimePeriod");
            Assert.IsInstanceOf<TimePeriod>(testingTarget, "Should return TimePeriod instance.");

            testingTarget.DurationMilliseconds = 300;
            Assert.AreEqual(300, testingTarget.DurationMilliseconds, "Should be equal!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"TimePeriodDurationMilliseconds END (OK)");
        }
    }
}
