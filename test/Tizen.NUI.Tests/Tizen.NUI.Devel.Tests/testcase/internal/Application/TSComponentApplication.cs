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
        private Widget widget = null;
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

            widget = new Widget();
            tlog.Debug(tag, "widget.Id : " + widget.Id);
        }

        [TearDown]
        public void Destroy()
        {
            widget.Dispose();
            widget = null;

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

            var testingTarget = new ComponentApplication(widget.SwigCPtr.Handle, false);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

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

            ComponentApplication componentApplication = new ComponentApplication(widget.SwigCPtr.Handle, false);
            Assert.IsNotNull(componentApplication, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(componentApplication, "should be an instance of testing target class!");

            var testingTarget = new ComponentApplication(componentApplication);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

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

            var testingTarget = new ComponentApplication(widget.SwigCPtr.Handle, false);
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

            var testingTarget = new MyComponentApplication(widget.SwigCPtr.Handle, false);
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

            var testingTarget = new ComponentApplication(widget.SwigCPtr.Handle, false);
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

            testingTarget.Dispose();
            tlog.Debug(tag, $"ComponentApplicationAssign END (OK)");
        }

        //[Test]
        //[Category("P1")]
        //[Description("ComponentApplication CreateNative.")]
        //[Property("SPEC", "Tizen.NUI.ComponentApplication.CreateNative A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRW")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void ComponentApplicationCreateNative()
        //{
        //    tlog.Debug(tag, $"ComponentApplicationCreateNative START");

        //    var testingTarget = new ComponentApplication(widget.SwigCPtr.Handle, true);
        //    Assert.IsNotNull(testingTarget, "should be not null");
        //    Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

        //    testingTarget.CreateNative += OnApplicationCreateNative;
        //    testingTarget.CreateNative -= OnApplicationCreateNative;

        //    testingTarget.Dispose();
        //    tlog.Debug(tag, $"ComponentApplicationCreateNative END (OK)");
        //}

        //private IntPtr OnApplicationCreateNative()
        //{
        //    return IntPtr.Zero;
        //}
    }
}
