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
        [Description("ComponentApplication NewComponentApplication")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationNewComponentApplication()
        {
            tlog.Debug(tag, $"ComponentApplicationNewComponentApplication START");

            var args = new string[] { "Dali-demo" };
            var stylesheet = resource + "/style/Test_Style_Manager.json";
            var testingTarget = ComponentApplication.NewComponentApplication(args, stylesheet);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ComponentApplicationNewComponentApplication END (OK)");
        }

        [Test]
        [Description("ComponentApplication New")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationNew()
        {
            tlog.Debug(tag, $"ComponentApplicationNew START");

            var args = new string[] { "Dali-demo" };
            var stylesheet = resource + "/style/Test_Style_Manager.json";
            var testingTarget = ComponentApplication.New(args, stylesheet);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            testingTarget.Dispose();
            tlog.Debug(tag, $"ComponentApplicationNew END (OK)");
        }

        [Test]
        [Description("ComponentApplication connection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationConnection()
        {
            tlog.Debug(tag, $"ComponentApplicationConnection START");

            var args = new string[] { "Dali-demo" };
            var stylesheet = resource + "/style/Test_Style_Manager.json";
            var testingTarget = ComponentApplication.NewComponentApplication(args, stylesheet);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"ComponentApplicationConnection END (OK)");
        }

        [Test]
        [Description("ComponentApplication disconnection")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void ComponentApplicationDisconnection()
        {
            tlog.Debug(tag, $"ComponentApplicationDisconnection START");

            var args = new string[] { "Dali-demo" };
            var stylesheet = resource + "/style/Test_Style_Manager.json";
            var testingTarget = ComponentApplication.NewComponentApplication(args, stylesheet);
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<ComponentApplication>(testingTarget, "should be an instance of testing target class!");

            dummyCallback callback = OnDummyCallback;
            testingTarget.Connect(callback);
            testingTarget.Disconnect(callback);
            testingTarget.Dispose();

            tlog.Debug(tag, $"ComponentApplicationDisconnection END (OK)");
        }
    }
}
