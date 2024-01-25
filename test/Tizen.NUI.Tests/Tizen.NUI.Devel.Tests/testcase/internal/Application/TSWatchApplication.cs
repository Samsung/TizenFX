using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using static Tizen.NUI.WatchApplication;
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/Application/WatchApplication")]
    public class InternalWatchApplicationTest
    {
        private const string tag = "NUITEST";
        private string resource = Tizen.Applications.Application.Current.DirectoryInfo.Resource;

        internal class MyWatchApplication : WatchApplication
        {
            public MyWatchApplication(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
        }

        private bool IsWearable()
        {
            string value;
            var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            if (result && value.Equals("wearable"))
            {
                return true;
            }

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
        [Description("WatchApplication constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.WatchApplication C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationConstructor()
        {
            tlog.Debug(tag, $"WatchApplicationConstructor START");

            using (ImageView imageView = new ImageView())
            {
                var testingTarget = new WatchApplication(imageView.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchApplicationConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.TimeTickEventArgs. Application.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsApplication()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplication START");

            var testingTarget = new TimeTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TimeTickEventArgs>(testingTarget, "should be an instance of testing target class!");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            testingTarget.Application = application;
            Assert.IsNotNull(testingTarget.Application, "should be not null.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.TimeTickEventArgs. WatchTime.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.WatchTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsWatchTime()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTime START");

            var testingTarget = new TimeTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<TimeTickEventArgs>(testingTarget, "should be an instance of testing target class!");

            Widget widget = new Widget();
            using (WatchTime time = new WatchTime(widget.GetIntPtr(), false))
            {
                testingTarget.WatchTime = time;
                Assert.IsNotNull(testingTarget.WatchTime);
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientTickEventArgs. Application.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.Application A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickEventArgsApplication()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplication START");

            var testingTarget = new AmbientTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientTickEventArgs>(testingTarget, "should be an instance of AmbientTickEventArgs class!");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            testingTarget.Application = application;
            Assert.IsNotNull(testingTarget.Application, "should be not null.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientTickEventArgs.WatchTime")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.AmbientTickEventArgs.WatchTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickArgsWatchTime()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickArgsWatchTime START");

            var testingTarget = new AmbientTickEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientTickEventArgs>(testingTarget, "should be an instance of testing target class!");

            Widget widget = new Widget();
            using (WatchTime time = new WatchTime(widget.GetIntPtr(), false))
            {
                testingTarget.WatchTime = time;
                Assert.IsNotNull(testingTarget.WatchTime);
            }

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationAmbientTickArgsWatchTime END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientChangedEventArgs. Application.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.TimeTickEventArgs.WatchTime A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsApplication()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplication START");

            var testingTarget = new AmbientChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientChangedEventArgs>(testingTarget, "should be an instance of AmbientChangedEventArgs class!");

            Widget widget = new Widget();
            var application = new WidgetApplication(widget.GetIntPtr(), false);
            testingTarget.Application = application;
            Assert.IsNotNull(testingTarget.Application, "should be not null.");

            widget.Dispose();
            widget = null;
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplication END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WatchApplication.AmbientChangedEventArgs. Changed.")]
        [Property("SPEC", "Tizen.NUI.WatchApplication.AmbientChangedEventArgs.Changed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsChangedSet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet START");

            var testingTarget = new AmbientChangedEventArgs();
            Assert.IsNotNull(testingTarget, "should be not null");
            Assert.IsInstanceOf<AmbientChangedEventArgs>(testingTarget, "should be an instance of AmbientChangedEventArgs class!");

            testingTarget.Changed = true;
            Assert.AreEqual(true, testingTarget.Changed, "Retrieved result should be equal to true. ");

            testingTarget.Changed = false;
            Assert.AreEqual(false, testingTarget.Changed, "Retrieved result should be equal to true. ");

            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet END (OK)");
        }
    }
}
