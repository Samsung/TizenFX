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

        private delegate bool dummyCallback(IntPtr nuicorebackend);
        private bool OnDummyCallback(IntPtr data)
        {
            return false;
        }

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
        [Category("P1")]
        [Description("NUICoreBackend constructor.")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.NUICoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
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
        [Category("P1")]
        [Description("NUICoreBackend constructor. With stylesheet.")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.NUICoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
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
        [Category("P1")]
        [Description("NUICoreBackend constructor. With stylesheet and windowMode.")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.NUICoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
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
        [Category("P1")]
        [Description("NUICoreBackend constructor. With stylesheet, mode, size, position")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.NUICoreBackend C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendConstructorWithFourParameters()
        {
            tlog.Debug(tag, $"NUICoreBackendConstructorWithFourParameters START");

            var dummy = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "/style/Test_Style_Manager.json";
            var testingTarget = new NUICoreBackend(dummy, NUIApplication.WindowMode.Opaque, new Size(400, 400), new Position(200, 300));
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendConstructorWithFourParameters END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("NUICoreBackend AddEventHandler")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.AddEventHandler M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
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
        [Category("P1")]
        [Description("NUICoreBackend Dispose.")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
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
        [Category("P1")]
        [Description("NUICoreBackend Exit.")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.Exit M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
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

        [Test]
        [Category("P1")]
        [Description("NUICoreBackend ApplicationHandle.")]
        [Property("SPEC", "Tizen.NUI.NUICoreBackend.ApplicationHandle A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void NUICoreBackendApplicationHandle()
        {
            tlog.Debug(tag, $"NUICoreBackendApplicationHandle START");

            var testingTarget = new NUICoreBackend();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<NUICoreBackend>(testingTarget, "should be an instance of testing target class!");

            try
            {
                var result = testingTarget.ApplicationHandle;
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            testingTarget.Dispose();
            tlog.Debug(tag, $"NUICoreBackendApplicationHandle END (OK)");
        }
    }
}
