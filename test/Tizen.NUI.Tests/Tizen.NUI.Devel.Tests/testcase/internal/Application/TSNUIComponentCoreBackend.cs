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
    [Description("internal/Application/NUIComponentCoreBackend")]
    public class InternalNUIComponentCoreBackendTest
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
        [Description("NUIComponentCoreBackend constructor.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentCoreBackend.NUIComponentCoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendConstructor()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendConstructor START");

            var testingTarget = new NUIComponentCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentCoreBackendConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentCoreBackend ComponentFactories. Get.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentCoreBackend.ComponentFactories A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendComponentFactoriesGet()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendComponentFactoriesGet START");

            var testingTarget = new NUIComponentCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                var result = testingTarget.ComponentFactories;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentCoreBackendComponentFactoriesGet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentCoreBackend ComponentFactories. Set.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentCoreBackend.ComponentFactories A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendComponentFactoriesSet()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendComponentFactoriesSet START");

            var testingTarget = new NUIComponentCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.ComponentFactories = null;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentCoreBackendComponentFactoriesSet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentCoreBackend AddEventHandler.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentCoreBackend.AddEventHandler A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendAddEventHandler()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendAddEventHandler START");

            var testingTarget = new NUIComponentCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.AddEventHandler(EventType.PreCreated, MyOnPreCreate);
                testingTarget.AddEventHandler<Tizen.Applications.LowBatteryEventArgs >(EventType.LowBattery, MyOnLowBattery);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentCoreBackendAddEventHandler END (OK)");
        }

        private void MyOnLowBattery(Tizen.Applications.LowBatteryEventArgs obj) { }
        private void MyOnPreCreate() { }

        [Test]
        [Category("P1")]
        [Description("NUIComponentCoreBackend constructor. With stylesheet")]
        [Property("SPEC", "Tizen.NUI.NUIComponentCoreBackend.NUIComponentCoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendConstructorWithStylesheet()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendConstructorWithStylesheet START");

            var dummy = resource + "style/Test_Style_Manager.json";
            var testingTarget = new NUIComponentCoreBackend(dummy);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentCoreBackendConstructorWithStylesheet END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUIComponentCoreBackend exit.")]
        [Property("SPEC", "Tizen.NUI.NUIComponentCoreBackend.Exit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendExit()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendExit START");

            var testingTarget = new NUIComponentCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

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
            tlog.Debug(tag, $"NUIComponentCoreBackendExit END (OK)");
        }
    }
}
