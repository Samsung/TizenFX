using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/NUICoreBackend")]
    public class InternalNUICoreBackendTest
    {
        private const string tag = "NUITEST";
        private event EventHandler Created;
        protected virtual void OnCreate()
        {
            Created?.Invoke(this, EventArgs.Empty);
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
        [Description("NUICoreBackend constructor")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendConstructor()
        {
            tlog.Debug(tag, $"NUICoreBackendConstructor START");

            var testingTarget = new NUICoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendConstructor END (OK)");
        }

        [Test]
        [Description("NUICoreBackend constructor with stylesheet")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendConstructorWithStylesheet()
        {
            tlog.Debug(tag, $"NUICoreBackendConstructorWithStylesheet START");

            var dummy = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/style/Test_Style_Manager.json";
            var testingTarget = new NUICoreBackend(dummy);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendConstructorWithStylesheet END (OK)");
        }

        [Test]
        [Description("NUICoreBackend constructor with stylesheet and windowMode")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendConstructorWithStylesheetAndWindowmode()
        {
            tlog.Debug(tag, $"NUICoreBackendConstructorWithStylesheetAndWindowmode START");

            var dummy = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/style/Test_Style_Manager.json";
            var testingTarget = new NUICoreBackend(dummy, NUIApplication.WindowMode.Opaque);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendConstructorWithStylesheetAndWindowmode END (OK)");
        }

        [Test]
        [Description("NUICoreBackend constructor with stylesheet, window mode, window size and window position")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendConstructorWithMoreArgs()
        {
            tlog.Debug(tag, $"NUICoreBackendConstructorWithMoreArgs START");

            var dummy = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/style/Test_Style_Manager.json";
            var testingTarget = new NUICoreBackend(dummy, NUIApplication.WindowMode.Opaque, new Size(400, 400), new Position(200, 300));
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendConstructorWithMoreArgs END (OK)");
        }

        [Test]
        [Description("NUICoreBackend AddEventHandler")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendAddEventHandler()
        {
            tlog.Debug(tag, $"NUICoreBackendAddEventHandler START");

            var testingTarget = new NUICoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.AddEventHandler(Tizen.Applications.CoreBackend.EventType.Created, OnCreate);

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendAddEventHandler END (OK)");
        }

        [Test]
        [Description("NUICoreBackend dispose")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendDispose()
        {
            tlog.Debug(tag, $"NUICoreBackendDispose START");

            var testingTarget = new NUICoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.Dispose();
            }
            catch (Exception e)
            {
                tlog.Error(tag, "Caught Exception" + e.ToString());
                Assert.Fail("Caught Exception" + e.ToString());
            }

            tlog.Debug(tag, $"NUICoreBackendDispose END (OK)");
        }

        [Test]
        [Description("NUICoreBackend exit")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendExit()
        {
            tlog.Debug(tag, $"NUICoreBackendExit START");

            var testingTarget = new NUICoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

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
            tlog.Debug(tag, $"NUICoreBackendExit END (OK)");
        }
    }
}
