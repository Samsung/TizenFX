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

        internal class MyComponentApplication : ComponentApplication
        {
            public MyComponentApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
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
        [Description("ComponentApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.ComponentApplication.ComponentApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationConstructor()
        {
            tlog.Debug(tag, $"ComponentApplicationConstructor START");

            ImageView view = new ImageView();
            var testingTarget = new ComponentApplication(view.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ComponentApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ComponentApplication constructor. With ComponentApplication.")]
        [Property("SPEC", "Tizen.NUI.ComponentApplication.ComponentApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationConstructorWithComponentApplication()
        {
            tlog.Debug(tag, $"ComponentApplicationConstructorWithComponentApplication START");

            ImageView view = new ImageView();
            ComponentApplication componentApplication = new ComponentApplication(view.SwigCPtr.Handle, false);
            Assert.IsNotNull(componentApplication, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(componentApplication, "should be an instance of testing target class!");

            var testingTarget = new ComponentApplication(componentApplication);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ComponentApplicationConstructorWithComponentApplication END (OK)");
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

            ImageView view = new ImageView();
            var testingTarget = new ComponentApplication(view.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            try
            {
                var result = testingTarget.CreateNativeSignal();
                Assert.IsNotNull(result, "should be not null");
                Assert.IsInstanceOf<ApplicationSignal>(result, "should be an instance of ApplicationSignal class!");
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            view.Dispose();
            testingTarget.Dispose();
            tlog.Debug(tag, $"ComponentApplicationCreateNativeSignal END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ComponentApplication Dispose.")]
        [Property("SPEC", "Tizen.NUI.ComponentApplication.Dispose M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationDispose()
        {
            tlog.Debug(tag, $"ComponentApplicationDispose START");

            ImageView view = new ImageView();
            var testingTarget = new MyComponentApplication(view.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.OnDispose(DisposeTypes.Explicit);
                testingTarget.OnDispose(DisposeTypes.Explicit);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            view.Dispose();
            tlog.Debug(tag, $"ComponentApplicationDispose END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("ComponentApplication Assign.")]
        [Property("SPEC", "Tizen.NUI.ComponentApplication.Assign M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationAssign()
        {
            tlog.Debug(tag, $"ComponentApplicationAssign START");

            ImageView view = new ImageView();
            var testingTarget = new ComponentApplication(view.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            try
            {
                testingTarget.Assign(testingTarget);
            }
            catch (Exception e)
            {
                tlog.Debug(tag, e.Message.ToString());
                Assert.Fail("Caught Exception: Failed!");
            }

            tlog.Debug(tag, $"ComponentApplicationAssign END (OK)");
        }
    }
}
