using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/ComponentApplication")]
    public class InternalComponentApplicationTest
    {
        private const string tag = "NUITEST";
        private string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;
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
        [Category("P1")]
        [Description("ComponentApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.ComponentApplication.ComponentApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationConstructor()
        {
            tlog.Debug(tag, $"ComponentApplicationConstructor START");

            using (Widget widget = new Widget())
            {
                var testingTarget = new ComponentApplication(widget.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ComponentApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ComponentApplication CreateNativeSignal.")]
        [Property("SPEC", "Tizen.NUI.ComponentApplication.CreateNativeSignal M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationCreateNativeSignal()
        {
            tlog.Debug(tag, $"ComponentApplicationCreateNativeSignal START");

            using (Widget widget = new Widget())
            {
                var testingTarget = new ComponentApplication(widget.SwigCPtr.Handle, true);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

                var result = testingTarget.CreateNativeSignal();
                Assert.IsNotNull(result, "should be not null");
                Assert.IsInstanceOf<ApplicationSignal>(result, "should be an instance of ApplicationSignal class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"ComponentApplicationCreateNativeSignal END (OK)");
        }
    }
}
