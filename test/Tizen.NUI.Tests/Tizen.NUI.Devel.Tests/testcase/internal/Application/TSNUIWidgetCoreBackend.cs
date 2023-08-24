using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;
using Tizen.Applications.CoreBackend;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/NUIWidgetCoreBackend")]
    public class InternalNUIWidgetCoreBackendTest
    {
        private const string tag = "NUITEST";
        private string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

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
        [Description("NUIWidgetCoreBackend constructor.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.NUIWidgetCoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendConstructor()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendConstructor START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend AddEventHandler.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.AddEventHandler A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendAddEventHandler()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendAddEventHandler START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.AddEventHandler(EventType.PreCreated, MyOnPreCreate);
                testingTarget.AddEventHandler<Tizen.Applications.LowBatteryEventArgs>(EventType.LowBattery, MyOnLowBattery);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendAddEventHandler END (OK)");
        }

        private void MyOnLowBattery(Tizen.Applications.LowBatteryEventArgs obj) { }
        private void MyOnPreCreate() { }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend constructor. With stylesheet")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.NUIWidgetCoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendConstructorWithStylesheet()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendConstructorWithStylesheet START");

            var dummy = resource + "style/Test_Style_Manager.json";
            var testingTarget = new NUIWidgetCoreBackend(dummy);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendConstructorWithStylesheet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend dispose.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendDispose()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendDispose START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUIWidgetCoreBackendDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend exit.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.Exit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendExit()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendExit START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.Exit();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendExit END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend RegisterWidgetInfo.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.RegisterWidgetInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendRegisterWidgetInfo()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendRegisterWidgetInfo START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            var widgetInfo = new Dictionary<global::System.Type, string>();
            testingTarget.RegisterWidgetInfo(widgetInfo);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendRegisterWidgetInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend AddWidgetInfo.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.AddWidgetInfo M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendAddWidgetInfo()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendAddWidgetInfo START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            var widgetInfo = new Dictionary<global::System.Type, string>();
            testingTarget.AddWidgetInfo(widgetInfo);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendAddWidgetInfo END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIWidgetCoreBackend WidgetApplicationHandle.")]
        [Property("SPEC", "Tizen.NUI.NUIWidgetCoreBackend.WidgetApplicationHandle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendWidgetApplicationHandle()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendWidgetApplicationHandle START");

            var testingTarget = new NUIWidgetCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                var result = testingTarget.WidgetApplicationHandle;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendWidgetApplicationHandle END (OK)");
        }
    }
}
