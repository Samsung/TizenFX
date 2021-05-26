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
        [Description("WatchApplication new")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationNew()
        {
            tlog.Debug(tag, $"WatchApplicationNew START");

            if (IsWearable())
            {
                var testingTarget = Tizen.NUI.WatchApplication.New();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationNew END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationNew END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication new with strings")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationNewWithStrings()
        {
            tlog.Debug(tag, $"WatchApplicationNewWithStrings START");

            if (IsWearable())
            {
                var dummy = new string[3];
                var testingTarget = Tizen.NUI.WatchApplication.New(dummy);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationNewWithStrings END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationNewWithStrings END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication new with strings and stylesheet")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationNewWithStringsAndStylesheet()
        {
            tlog.Debug(tag, $"WatchApplicationNewWithStringsAndStylesheet START");

            if (IsWearable())
            {
                var args = new string[] { "Dali-demo" };
                var stylesheet = resource + "/style/Test_Style_Manager.json";
                var testingTarget = Tizen.NUI.WatchApplication.New(args, stylesheet);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchApplication>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationNewWithStringsAndStylesheet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationNewWithStringsAndStylesheet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication TimeTickEventArgs:Application get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsApplicationGet()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplicationGet START");

            if (IsWearable())
            {
                TimeTickEventArgs dummy = new TimeTickEventArgs();
                var testingTarget = dummy.Application;
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Application>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplicationGet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplicationGet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication TimeTickEventArgs:Application set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsApplicationSet()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplicationSet START");

            if (IsWearable())
            {
                var dummyApplication = new Application();
                Assert.IsNotNull(dummyApplication, "should be not null");
                Assert.IsInstanceOf<Application>(dummyApplication, "should be an instance of testing target class!");

                TimeTickEventArgs testingTarget = new TimeTickEventArgs();
                testingTarget.Application = dummyApplication;

                var result = testingTarget.Application;
                Assert.IsNotNull(result, "should be not null.");
                Assert.AreEqual(dummyApplication, result, "Retrieved result should be equal to dummyApplication. ");

                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplicationSet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsApplicationSet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication TimeTickEventArgs:WatchTime get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsWatchTimeGet()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTimeGet START");

            if (IsWearable())
            {
                TimeTickEventArgs dummy = new TimeTickEventArgs();
                var testingTarget = dummy.WatchTime;
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTimeGet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTimeGet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication TimeTickEventArgs:WatchTime set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationTimeTickEventArgsWatchTimeSet()
        {
            tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTimeSet START");

            if (IsWearable())
            {
                var dummyWatchTime = new WatchTime();
                Assert.IsNotNull(dummyWatchTime, "should be not null");
                Assert.IsInstanceOf<WatchTime>(dummyWatchTime, "should be an instance of testing target class!");

                TimeTickEventArgs testingTarget = new TimeTickEventArgs();
                testingTarget.WatchTime = dummyWatchTime;

                var result = testingTarget.WatchTime;
                Assert.IsNotNull(result, "should be not null.");
                Assert.AreEqual(dummyWatchTime, result, "Retrieved result should be equal to dummyApplication. ");

                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTimeSet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationTimeTickEventArgsWatchTimeSet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientTickEventArgs:Application get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickEventArgsApplicationGet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplicationGet START");

            if (IsWearable())
            {
                AmbientTickEventArgs dummy = new AmbientTickEventArgs();
                var testingTarget = dummy.Application;
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Application>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplicationGet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplicationGet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientTickEventArgs:Application set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickEventArgsApplicationSet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplicationSet START");

            if (IsWearable())
            {
                var application = new Application();
                Assert.IsNotNull(application, "should be not null");
                Assert.IsInstanceOf<Application>(application, "should be an instance of testing target class!");

                AmbientTickEventArgs testingTarget = new AmbientTickEventArgs();
                testingTarget.Application = application;

                var result = testingTarget.Application;
                Assert.IsNotNull(result, "should be not null.");
                Assert.AreEqual(application, result, "Retrieved result should be equal to dummyApplication. ");

                application.Dispose();
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplicationSet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsApplicationSet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientTickEventArgs:WatchTime get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickEventArgsWatchTimeGet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsWatchTimeGet START");

            if (IsWearable())
            {
                AmbientTickEventArgs dummy = new AmbientTickEventArgs();
                var testingTarget = dummy.WatchTime;
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsWatchTimeGet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsWatchTimeGet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientTickEventArgs:WatchTime set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientTickEventArgsWatchTimeSet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsWatchTimeSet START");

            if (IsWearable())
            {
                var dummyWatchTime = new WatchTime();
                Assert.IsNotNull(dummyWatchTime, "should be not null");
                Assert.IsInstanceOf<WatchTime>(dummyWatchTime, "should be an instance of testing target class!");

                AmbientTickEventArgs testingTarget = new AmbientTickEventArgs();
                testingTarget.WatchTime = dummyWatchTime;

                var result = testingTarget.WatchTime;
                Assert.IsNotNull(result, "should be not null.");
                Assert.AreEqual(dummyWatchTime, result, "Retrieved result should be equal to dummyApplication. ");

                dummyWatchTime.Dispose();
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsWatchTimeSet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientTickEventArgsWatchTimeSet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientChangedEventArgs:Application get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsApplicationGet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplicationGet START");

            if (IsWearable())
            {
                AmbientChangedEventArgs dummy = new AmbientChangedEventArgs();
                var testingTarget = dummy.Application;
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<Application>(testingTarget, "should be an instance of testing target class!");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplicationGet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplicationGet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientChangedEventArgs:Application set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsApplicationSet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplicationSet START");

            if (IsWearable())
            {
                var dummyApplication = new Application();
                Assert.IsNotNull(dummyApplication, "should be not null");
                Assert.IsInstanceOf<Application>(dummyApplication, "should be an instance of testing target class!");

                AmbientChangedEventArgs testingTarget = new AmbientChangedEventArgs();
                testingTarget.Application = dummyApplication;

                var result = testingTarget.Application;
                Assert.IsNotNull(result, "should be not null.");
                Assert.AreEqual(dummyApplication, result, "Retrieved result should be equal to dummyApplication. ");

                dummyApplication.Dispose();
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplicationSet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsApplicationSet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientChangedEventArgs:Changed get")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsChangedGet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedGet START");

            if (IsWearable())
            {
                AmbientChangedEventArgs testingTarget = new AmbientChangedEventArgs();
                var result = testingTarget.Changed;
                Assert.IsNotNull(result, "should be not null");

                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedGet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedGet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Description("WatchApplication AmbientChangedEventArgs:Changed set")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchApplicationAmbientChangedEventArgsChangedSet()
        {
            tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet START");

            if (IsWearable())
            {
                AmbientChangedEventArgs testingTarget = new AmbientChangedEventArgs();
                testingTarget.Changed = true;

                var result = testingTarget.Changed;
                Assert.IsNotNull(result, "should be not null.");
                Assert.AreEqual(true, result, "Retrieved result should be equal to true. ");
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchApplicationAmbientChangedEventArgsChangedSet END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }
    }
}
