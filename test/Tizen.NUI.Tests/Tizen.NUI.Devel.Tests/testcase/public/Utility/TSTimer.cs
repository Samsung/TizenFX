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
    [Description("public/Utility/Timer")]
    class PublicTimerTest
    {
        private const string tag = "NUITEST";

        internal class MyTimer : Timer
        {
            public MyTimer(uint milliSec) : base(milliSec)
            { }

            public void OnDispose(DisposeTypes type)
            {
                base.Dispose(type);
            }
        }

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
        [Description("Timer constructor. With Timer instance.")]
        [Property("SPEC", "Tizen.NUI.Timer.Timer C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerConstructorWithTimer()
        {
            tlog.Debug(tag, $"TimerConstructorWithTimer START");

            using (var timer = new Timer(100))
            {
                var testingTarget = new Timer(timer);
                Assert.IsNotNull(testingTarget, "Can't create success object Timer");
                Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"TimerConstructorWithTimer END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Timer Tick.")]
        [Property("SPEC", "Tizen.NUI.Timer.Tick A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerTick()
        {
            tlog.Debug(tag, $"TimerTick START");

            var testingTarget = new Timer(100);
            Assert.IsNotNull(testingTarget, "Can't create success object Timer");
            Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

            testingTarget.Tick += MyTickEvent;
            testingTarget.Tick -= MyTickEvent;

            testingTarget.Dispose();

            tlog.Debug(tag, $"TimerTick END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Timer SetInterval. Timer is disposed.")]
        [Property("SPEC", "Tizen.NUI.Timer.SetInterval M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerSetIntervalWithDisposedInstance()
        {
            tlog.Debug(tag, $"TimerSetIntervalWithDisposedInstance START");

            var testingTarget = new Timer(100);
            Assert.IsNotNull(testingTarget, "Can't create success object Timer");
            Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

            testingTarget.Dispose();

            try
            {
                testingTarget.SetInterval(100);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TimerSetIntervalWithDisposedInstance END (OK)");
                Assert.Pass("Caught Exception: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Timer GetInterval. Timer is disposed.")]
        [Property("SPEC", "Tizen.NUI.Timer.GetInterval M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerGetIntervalWithDisposedInstance()
        {
            tlog.Debug(tag, $"TimerGetIntervalWithDisposedInstance START");

            var testingTarget = new Timer(100);
            Assert.IsNotNull(testingTarget, "Can't create success object Timer");
            Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

            testingTarget.SetInterval(100);
            testingTarget.Dispose();

            try
            {
                testingTarget.GetInterval();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString()); 
                tlog.Debug(tag, $"TimerGetIntervalWithDisposedInstance END (OK)");
                Assert.Pass("Caught Exception: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Timer Start. Timer is disposed.")]
        [Property("SPEC", "Tizen.NUI.Timer.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerStartWithDisposedInstance()
        {
            tlog.Debug(tag, $"TimerStartWithDisposedInstance START");

            var testingTarget = new MyTimer(100);
            Assert.IsNotNull(testingTarget, "Can't create success object Timer");
            Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

            testingTarget.OnDispose(DisposeTypes.Explicit);

            try
            {
                testingTarget.Start();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TimerStartWithDisposedInstance END (OK)");
                Assert.Pass("Caught Exception: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Timer Stop. Timer is disposed.")]
        [Property("SPEC", "Tizen.NUI.Timer.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerStopWithDisposedInstance()
        {
            tlog.Debug(tag, $"TimerStopWithDisposedInstance START");

            var testingTarget = new MyTimer(100);
            Assert.IsNotNull(testingTarget, "Can't create success object Timer");
            Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

            testingTarget.OnDispose(DisposeTypes.Explicit);

            try
            {
                testingTarget.Stop();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TimerStopWithDisposedInstance END (OK)");
                Assert.Pass("Caught Exception: Passed!");
            }
        }

        [Test]
        [Category("P2")]
        [Description("Timer IsRunning. Timer is disposed.")]
        [Property("SPEC", "Tizen.NUI.Timer.Start M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void TimerIsRunningWithDisposedInstance()
        {
            tlog.Debug(tag, $"TimerIsRunningWithDisposedInstance START");

            var testingTarget = new MyTimer(100);
            Assert.IsNotNull(testingTarget, "Can't create success object Timer");
            Assert.IsInstanceOf<Timer>(testingTarget, "Should be an instance of Timer type.");

            testingTarget.Start();
            testingTarget.OnDispose(DisposeTypes.Explicit);

            try
            {
                var result = testingTarget.IsRunning();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                tlog.Debug(tag, $"TimerIsRunningWithDisposedInstance END (OK)");
                Assert.Pass("Caught Exception: Passed!");
            }
        }

        private bool MyTickEvent(object source, Timer.TickEventArgs e)
        {
            return false;
        }
    }
}
