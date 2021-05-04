using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Collections.Generic;

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
        [Description("NUIWidgetCoreBackend constructor")]
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
        [Description("NUIWidgetCoreBackend constructor with stylesheet")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIWidgetCoreBackendConstructorWithStylesheet()
        {
            tlog.Debug(tag, $"NUIWidgetCoreBackendConstructorWithStylesheet START");

            var dummy = resource + "/style/Test_Style_Manager.json";
            var testingTarget = new NUIWidgetCoreBackend(dummy);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIWidgetCoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIWidgetCoreBackendConstructorWithStylesheet END (OK)");
        }

        [Test]
        [Description("NUIWidgetCoreBackend dispose")]
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
        [Description("NUIWidgetCoreBackend exit")]
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
        [Description("NUIWidgetCoreBackend register widget info")]
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
        [Description("NUIWidgetCoreBackend add widget info")]
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
    }
}
