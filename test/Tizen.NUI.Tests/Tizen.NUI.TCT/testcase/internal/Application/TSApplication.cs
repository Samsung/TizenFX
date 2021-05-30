using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/Application")]
    public class InternalApplicationTest
    {
        private const string tag = "NUITEST";
        private delegate bool dummyCallback(IntPtr application);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
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
        [Description("NUIApplicationInitEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationInitEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationInitEventArgsGet START");

            var testingTarget = new NUIApplicationInitEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationInitEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationInitEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationInitEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationInitEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationInitEventArgsSet START");

            var testingTarget = new NUIApplicationInitEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationInitEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationInitEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationTerminatingEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationTerminatingEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationTerminatingEventArgsGet START");

            var testingTarget = new NUIApplicationTerminatingEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationTerminatingEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationTerminatingEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationTerminatingEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationTerminatingEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationTerminatingEventArgsSet START");

            var testingTarget = new NUIApplicationTerminatingEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationTerminatingEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationTerminatingEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationPausedEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationPausedEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationPausedEventArgsGet START");

            var testingTarget = new NUIApplicationPausedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationPausedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationPausedEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationPausedEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationPausedEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationPausedEventArgsSet START");

            var testingTarget = new NUIApplicationPausedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationPausedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationPausedEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationResumedEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationResumedEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationResumedEventArgsGet START");

            var testingTarget = new NUIApplicationResumedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationResumedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationResumedEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationResumedEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationResumedEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationResumedEventArgsSet START");

            var testingTarget = new NUIApplicationResumedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationResumedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationResumedEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationResetEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationResetEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationResetEventArgsGet START");

            var testingTarget = new NUIApplicationResetEventArgs();
            Assert.IsNotNull(testingTarget);
            Assert.IsInstanceOf<NUIApplicationResetEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationResetEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationResetEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationResetEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationResetEventArgsSet START");

            var testingTarget = new NUIApplicationResetEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationResetEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationResetEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationLanguageChangedEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationLanguageChangedEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationLanguageChangedEventArgsGet START");

            var testingTarget = new NUIApplicationLanguageChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationLanguageChangedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationLanguageChangedEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationLanguageChangedEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationLanguageChangedEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationLanguageChangedEventArgsSet START");

            var testingTarget = new NUIApplicationLanguageChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationLanguageChangedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationLanguageChangedEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationRegionChangedEventArgs Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationRegionChangedEventArgsGet()
        {
            tlog.Debug(tag, $"NUIApplicationRegionChangedEventArgsGet START");

            var testingTarget = new NUIApplicationRegionChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationRegionChangedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result);

            tlog.Debug(tag, $"NUIApplicationRegionChangedEventArgsGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationRegionChangedEventArgs Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationRegionChangedEventArgsSet()
        {
            tlog.Debug(tag, $"NUIApplicationRegionChangedEventArgsSet START");

            var testingTarget = new NUIApplicationRegionChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationRegionChangedEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationRegionChangedEventArgsSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationBatteryLowEventArgs BatteryStatus Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationBatteryLowEventArgsBatteryStatusGet()
        {
            tlog.Debug(tag, $"NUIApplicationBatteryLowEventArgsBatteryStatusGet START");

            var testingTarget = new NUIApplicationBatteryLowEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationBatteryLowEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.BatteryStatus;
            Assert.IsNotNull(result, "should be not null");

            tlog.Debug(tag, $"NUIApplicationBatteryLowEventArgsBatteryStatusGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationBatteryLowEventArgs BatteryStatus Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationBatteryLowEventArgsBatteryStatusSet()
        {
            tlog.Debug(tag, $"NUIApplicationBatteryLowEventArgsBatteryStatusSet START");

            var testingTarget = new NUIApplicationBatteryLowEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationBatteryLowEventArgs>(testingTarget, "should be an instance of testing target class!");

            var status = Application.BatteryStatus.Normal;
            testingTarget.BatteryStatus = status;

            var result = testingTarget.BatteryStatus;
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.AreEqual(status, result, "Retrieved result should be equal to status.");

            tlog.Debug(tag, $"NUIApplicationBatteryLowEventArgsBatteryStatusSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationMemoryLowEventArgs MemoryStatus Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationMemoryLowEventArgsMemoryStatusGet()
        {
            tlog.Debug(tag, $"NUIApplicationMemoryLowEventArgsMemoryStatusGet START");

            var testingTarget = new NUIApplicationMemoryLowEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationMemoryLowEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.MemoryStatus;
            Assert.IsNotNull(result, "should be not null");

            tlog.Debug(tag, $"NUIApplicationMemoryLowEventArgsMemoryStatusGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationMemoryLowEventArgs MemoryStatus Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationMemoryLowEventArgsMemoryStatusSet()
        {
            tlog.Debug(tag, $"NUIApplicationMemoryLowEventArgsMemoryStatusSet START");

            var testingTarget = new NUIApplicationMemoryLowEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationMemoryLowEventArgs>(testingTarget, "should be an instance of testing target class!");

            var status = Application.MemoryStatus.Normal;
            testingTarget.MemoryStatus = status;

            var result = testingTarget.MemoryStatus;
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.AreEqual(status, result, "Retrieved result should be equal to status.");

            tlog.Debug(tag, $"NUIApplicationMemoryLowEventArgsMemoryStatusSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationAppControlEventArgs Application Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationAppControlEventArgsApplicationGet()
        {
            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsApplicationGet START");

            var testingTarget = new NUIApplicationAppControlEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationAppControlEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.Application;
            Assert.IsNull(result, "should be null");

            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsApplicationGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationAppControlEventArgs Application Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationAppControlEventArgsApplicationSet()
        {
            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsApplicationSet START");

            var testingTarget = new NUIApplicationAppControlEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationAppControlEventArgs>(testingTarget, "should be an instance of testing target class!");

            var g_result = testingTarget.Application;
            Assert.IsNull(g_result);

            testingTarget.Application = Application.Current;
            var s_result = testingTarget.Application;
            Assert.IsNotNull(s_result);

            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsApplicationSet END (OK)");
        }

        [Test]
        [Description("NUIApplicationAppControlEventArgs VoidP Get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationAppControlEventArgsVoidPGet()
        {
            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsVoidPGet START");

            var testingTarget = new NUIApplicationAppControlEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationAppControlEventArgs>(testingTarget, "should be an instance of testing target class!");

            var result = testingTarget.VoidP;
            Assert.IsNotNull(result, "should be not null");

            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsVoidPGet END (OK)");
        }

        [Test]
        [Description("NUIApplicationAppControlEventArgs VoidP Set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIApplicationAppControlEventArgsVoidPSet()
        {
            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsVoidPSet START");

            var dummy = new global::System.IntPtr(0);
            var testingTarget = new NUIApplicationAppControlEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIApplicationAppControlEventArgs>(testingTarget, "should be an instance of testing target class!");

            testingTarget.VoidP = dummy;

            var result = testingTarget.VoidP;
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.AreEqual(dummy, result, "Retrieved result should be equal to dummy.");

            tlog.Debug(tag, $"NUIApplicationAppControlEventArgsVoidPSet END (OK)");
        }
    }
}
