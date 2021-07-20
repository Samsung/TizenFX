using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

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

        internal class MyApplication : Application
        {
            public MyApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("NUIApplicationInitEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationInitEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationInitEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationInitEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationTerminatingEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationTerminatingEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationTerminatingEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationTerminatingEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationPausedEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationPausedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationPausedEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationPausedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationResumedEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationResumedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationResumedEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationResumedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationResetEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationResetEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationResetEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationResetEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationLanguageChangedEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationLanguageChangedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationLanguageChangedEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationLanguageChangedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationRegionChangedEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationRegionChangedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationRegionChangedEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationRegionChangedEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationBatteryLowEventArgs BatteryStatus.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationBatteryLowEventArgs.BatteryStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationBatteryLowEventArgs BatteryStatus.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationBatteryLowEventArgs.BatteryStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationMemoryLowEventArgs MemoryStatus.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationMemoryLowEventArgs.MemoryStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationMemoryLowEventArgs MemoryStatus.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationMemoryLowEventArgs.MemoryStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationAppControlEventArgs Application.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationAppControlEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationAppControlEventArgs Application.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationAppControlEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationAppControlEventArgs VoidP.Get.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationAppControlEventArgs.VoidP A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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
        [Category("P1")]
        [Description("NUIApplicationAppControlEventArgs VoidP.Set.")]
        [Property("SPEC", "Tizen.NUI.Application.NUIApplicationAppControlEventArgs.VoidP A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
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

        [Test]
        [Category("P1")]
        [Description("GetResourcesProvider IResourcesProvider Get")]
        [Property("SPEC", "Tizen.NUI.GetResourcesProvider.IResourcesProvider.Get A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void GetResourcesProviderIResourcesProviderGet()
        {
            tlog.Debug(tag, $"GetResourcesProviderIResourcesProviderGet START");

            try
            {
                var testingTarget = GetResourcesProvider.Get();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Tizen.NUI.Binding.IResourcesProvider>(testingTarget, "should be an instance of testing target class!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"GetResourcesProviderIResourcesProviderGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application constructor.")]
        [Property("SPEC", "Tizen.NUI.Application.Application C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationConstructor()
        {
            tlog.Debug(tag, $"ApplicationConstructor START");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);

            try
            {
                var testingTarget = new Application(application);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Application>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"ApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application GetApplicationFromPtr.")]
        [Property("SPEC", "Tizen.NUI.Application.GetApplicationFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationGetApplicationFromPtr()
        {
            tlog.Debug(tag, $"ApplicationGetApplicationFromPtr START");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            
            try
            {
                Application.GetApplicationFromPtr(application.SwigCPtr.Handle);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"ApplicationGetApplicationFromPtr END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application SystemResources.")]
        [Property("SPEC", "Tizen.NUI.Application.SystemResources A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSystemResources()
        {
            tlog.Debug(tag, $"ApplicationSystemResources START");

            try
            {
                var result = Application.Instance.SystemResources;
                tlog.Debug(tag, "SystemResources : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationSystemResources END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application IsResourcesCreated.")]
        [Property("SPEC", "Tizen.NUI.Application.IsResourcesCreated A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationIsResourcesCreated()
        {
            tlog.Debug(tag, $"ApplicationIsResourcesCreated START");

            try
            {
                var result = Application.Instance.IsResourcesCreated;
                tlog.Debug(tag, "IsResourcesCreated : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationIsResourcesCreated END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Paused.")]
        [Property("SPEC", "Tizen.NUI.Application.Paused A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationPaused()
        {
            tlog.Debug(tag, $"ApplicationPaused START");

            try
            {
                Application.Instance.Paused += MyOnPaused;
                Application.Instance.Paused -= MyOnPaused;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationPaused END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Resumed.")]
        [Property("SPEC", "Tizen.NUI.Application.Paused A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationResumed()
        {
            tlog.Debug(tag, $"ApplicationResumed START");

            try
            {
                Application.Instance.Resumed += MyOnResumed;
                Application.Instance.Resumed -= MyOnResumed;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationResumed END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Reset.")]
        [Property("SPEC", "Tizen.NUI.Application.Reset A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationReset()
        {
            tlog.Debug(tag, $"ApplicationReset START");

            try
            {
                Application.Instance.Reset += MyOnReset;
                Application.Instance.Reset -= MyOnReset;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationReset END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application LanguageChanged.")]
        [Property("SPEC", "Tizen.NUI.Application.LanguageChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationLanguageChanged()
        {
            tlog.Debug(tag, $"ApplicationLanguageChanged START");

            try
            {
                Application.Instance.LanguageChanged += MyOnLanguageChanged;
                Application.Instance.LanguageChanged -= MyOnLanguageChanged;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationLanguageChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application AppControl.")]
        [Property("SPEC", "Tizen.NUI.Application.AppControl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationAppControl()
        {
            tlog.Debug(tag, $"ApplicationAppControl START");

            try
            {
                Application.Instance.AppControl += MyOnAppControl;
                Application.Instance.AppControl -= MyOnAppControl;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationAppControl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application MemoryLow.")]
        [Property("SPEC", "Tizen.NUI.Application.MemoryLow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationMemoryLow()
        {
            tlog.Debug(tag, $"ApplicationMemoryLow START");

            try
            {
                Application.Instance.MemoryLow += MyOnMemoryLow;
                Application.Instance.MemoryLow -= MyOnMemoryLow;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationMemoryLow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application BatteryLow.")]
        [Property("SPEC", "Tizen.NUI.Application.BatteryLow A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationBatteryLow()
        {
            tlog.Debug(tag, $"ApplicationBatteryLow START");

            try
            {
                Application.Instance.BatteryLow += MyOnBatteryLow;
                Application.Instance.BatteryLow -= MyOnBatteryLow;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationBatteryLow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application RegionChanged.")]
        [Property("SPEC", "Tizen.NUI.Application.RegionChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationRegionChanged()
        {
            tlog.Debug(tag, $"ApplicationRegionChanged START");

            try
            {
                Application.Instance.RegionChanged += MyOnRegionChanged;
                Application.Instance.RegionChanged -= MyOnRegionChanged;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationRegionChanged END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Terminating.")]
        [Property("SPEC", "Tizen.NUI.Application.Terminating A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationTerminating()
        {
            tlog.Debug(tag, $"ApplicationTerminating START");

            try
            {
                Application.Instance.Terminating += MyOnTerminating;
                Application.Instance.Terminating -= MyOnTerminating;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationTerminating END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Initialized.")]
        [Property("SPEC", "Tizen.NUI.Application.Initialized A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationInitialized()
        {
            tlog.Debug(tag, $"ApplicationInitialized START");

            try
            {
                Application.Instance.Initialized += MyOnInitialized;
                Application.Instance.Initialized -= MyOnInitialized;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationInitialized END (OK)");
        }

        private void MyOnPaused(object sender, NUIApplicationPausedEventArgs e) { }
        private void MyOnResumed(object sender, NUIApplicationResumedEventArgs e) { }
        private void MyOnReset(object sender, NUIApplicationResetEventArgs e) { }
        private void MyOnLanguageChanged(object sender, NUIApplicationLanguageChangedEventArgs e) { }
        private void MyOnAppControl(object sender, NUIApplicationAppControlEventArgs e) { }
        private void MyOnMemoryLow(object sender, NUIApplicationMemoryLowEventArgs e) { }
        private void MyOnBatteryLow(object sender, NUIApplicationBatteryLowEventArgs e) { }
        private void MyOnRegionChanged(object sender, NUIApplicationRegionChangedEventArgs e) { }
        private void MyOnTerminating(object sender, NUIApplicationTerminatingEventArgs e) { }
        private void MyOnInitialized(object sender, NUIApplicationInitEventArgs e) { }

        [Test]
        [Category("P1")]
        [Description("Application Dispose.")]
        [Property("SPEC", "Tizen.NUI.Application.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationDispose()
        {
            tlog.Debug(tag, $"ApplicationDispose START");

            try
            {
                var testingTarget = new MyApplication(Application.Instance.SwigCPtr.Handle, false);

                tlog.Debug(tag, "testingTarget : " + testingTarget);

                testingTarget.Initialized += MyOnInitialized;
                testingTarget.Terminating += MyOnTerminating;
                testingTarget.Paused += MyOnPaused;
                testingTarget.Resumed += MyOnResumed;
                testingTarget.Reset += MyOnReset;
                testingTarget.LanguageChanged += MyOnLanguageChanged;
                testingTarget.RegionChanged += MyOnRegionChanged;
                testingTarget.BatteryLow += MyOnBatteryLow;
                testingTarget.MemoryLow += MyOnMemoryLow;
                testingTarget.AppControl += MyOnAppControl;

                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application SetCurrentApplication")]
        [Property("SPEC", "Tizen.NUI.Application.SetCurrentApplication M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationSetCurrentApplication()
        {
            tlog.Debug(tag, $"ApplicationSetCurrentApplication START");

            try
            {
                Widget widget = new Widget();
                WidgetApplication application = new WidgetApplication(widget.GetIntPtr(), false);
                Application.SetCurrentApplication(application);

                tlog.Debug(tag, "Application.Current : " + Application.Current);

                widget.Dispose();
                widget = null;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationSetCurrentApplication END (OK)");
        }

        [Test]
        [Category("P2")]
        [Description("Application Current. With existing application.")]
        [Property("SPEC", "Tizen.NUI.Application.Current A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationCurrentSetWithExistingApplication()
        {
            tlog.Debug(tag, $"ApplicationCurrentSetWithExistingApplication START");

            Widget widget = new Widget();
            WidgetApplication application = new WidgetApplication(widget.GetIntPtr(), false);
            Application.SetCurrentApplication(application);

            try
            {
                Application.Current = application;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;

            tlog.Debug(tag, $"ApplicationCurrentSetWithExistingApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application XamlResources.")]
        [Property("SPEC", "Tizen.NUI.Application.XamlResources A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationXamlResources()
        {
            tlog.Debug(tag, $"ApplicationXamlResources START");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false) as Application;

            tlog.Debug(tag, "application.XamlResources : " + application.XamlResources);

            application.XamlResources = new Tizen.NUI.Binding.ResourceDictionary();
            tlog.Debug(tag, "application.XamlResources : " + application.XamlResources);

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"ApplicationXamlResources END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application IsApplicationOrNull.")]
        [Property("SPEC", "Tizen.NUI.Application.IsApplicationOrNull M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationIsApplicationOrNull()
        {
            tlog.Debug(tag, $"ApplicationIsApplicationOrNull START");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false) as Application;

            try
            {
                var result = Application.IsApplicationOrNull(application);
                Assert.IsTrue(result);
                tlog.Debug(tag, "result = " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"ApplicationIsApplicationOrNull END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application ResetSignal.")]
        [Property("SPEC", "Tizen.NUI.Application.ResetSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationResetSignal()
        {
            tlog.Debug(tag, $"ApplicationResetSignal START");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false) as Application;

            application.InitSignal();

            try
            {
                application.ResetSignal();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"ApplicationResetSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application GetResourcePath.")]
        [Property("SPEC", "Tizen.NUI.Application.GetResourcePath M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationGetResourcePath()
        {
            tlog.Debug(tag, $"ApplicationGetResourcePath START");

            try
            {
                Application.GetResourcePath();
                tlog.Debug(tag, "ResourcePath : " + Application.GetResourcePath());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationGetResourcePath END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application GetLanguage.")]
        [Property("SPEC", "Tizen.NUI.Application.GetLanguage M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationGetLanguage()
        {
            tlog.Debug(tag, $"ApplicationGetLanguage START");

            try
            {
                Application.Instance.GetLanguage();
                tlog.Debug(tag, "Language : " + Application.Instance.GetLanguage());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationGetLanguage END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application GetRegion.")]
        [Property("SPEC", "Tizen.NUI.Application.GetRegion M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationGetRegion()
        {
            tlog.Debug(tag, $"ApplicationGetRegion START");

            try
            {
                Application.Instance.GetRegion();
                tlog.Debug(tag, "Region : " + Application.Instance.GetRegion());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationGetRegion END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application GetWindow.")]
        [Property("SPEC", "Tizen.NUI.Application.GetWindow M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationGetWindow()
        {
            tlog.Debug(tag, $"ApplicationGetWindow START");

            try
            {
                Application.Instance.GetWindow();
                tlog.Debug(tag, "Region : " + Application.Instance.GetWindow());
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationGetWindow END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application AddIdle.")]
        [Property("SPEC", "Tizen.NUI.Application.AddIdle M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationAddIdle()
        {
            tlog.Debug(tag, $"ApplicationAddIdle START");

            try
            {
                SWIGTYPE_p_Dali__CallbackBase callback = new SWIGTYPE_p_Dali__CallbackBase(new ImageView().SwigCPtr.Handle);
                var result = Application.Instance.AddIdle(callback);
                tlog.Debug(tag, "result : " + result);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationAddIdle END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Lower.")]
        [Property("SPEC", "Tizen.NUI.Application.Lower M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationLower()
        {
            tlog.Debug(tag, $"ApplicationLower START");

            try
            {
                Application.Instance.Lower();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationLower END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application Assign.")]
        [Property("SPEC", "Tizen.NUI.Application.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationAssign()
        {
            tlog.Debug(tag, $"ApplicationAssign START");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false) as Application;

            try
            {
                var testingTarget = Application.Instance.Assign(application);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Application>(testingTarget, "should be an instance of testing target class!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"ApplicationAssign END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("Application GetWindowList.")]
        [Property("SPEC", "Tizen.NUI.Application.GetWindowList M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ApplicationGetWindowList()
        {
            tlog.Debug(tag, $"ApplicationGetWindowList START");

            try
            {
                Application.GetWindowList();
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ApplicationGetWindowList END (OK)");
        }
    }
}
