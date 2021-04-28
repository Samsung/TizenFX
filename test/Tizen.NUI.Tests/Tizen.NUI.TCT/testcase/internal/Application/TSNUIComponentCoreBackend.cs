using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

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
        [Description("NUIComponentCoreBackend constructor")]
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
        [Description("NUIComponentCoreBackend constructor with stylesheet")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendConstructorWithStylesheet()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendConstructorWithStylesheet START");

            var dummy = resource + "/style/Test_Style_Manager.json";
            var testingTarget = new NUIComponentCoreBackend(dummy);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUIComponentCoreBackendConstructorWithStylesheet END (OK)");
        }

        [Test]
        [Description("NUIComponentCoreBackend dispose")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUIComponentCoreBackendDispose()
        {
            tlog.Debug(tag, $"NUIComponentCoreBackendDispose START");

            var testingTarget = new NUIComponentCoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUIComponentCoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }
            
            tlog.Debug(tag, $"NUIComponentCoreBackendDispose END (OK)");
        }

        [Test]
        [Description("NUIComponentCoreBackend exit")]
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
