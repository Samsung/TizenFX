using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("public/Application/WatchTime")]
    public class PublicWatchTimeTest
    {
        private const string tag = "NUITEST";

        private bool IsWearable()
        {
            string value;
            
            var result = Tizen.System.Information.TryGetValue("tizen.org/feature/profile", out value);
            if (result && value.Equals("wearable"))
                return true;

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
        [Description("WatchTime constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.WatchTime C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeConstructor()
        {
            tlog.Debug(tag, $"WatchTimeConstructor START");

            using (ImageView view = new ImageView())
            {
                var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchTimeConstructor END (OK)"); 
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime DaylightSavingTimeStatus.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.DaylightSavingTimeStatus C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeDaylightSavingTimeStatus()
        {
            tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                try
                {
                    var result = testingTarget.DaylightSavingTimeStatus;
                    Assert.AreEqual(false, result, "Should be default value.");
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Pass("Caught Exception: Passed!");
                }
                testingTarget.Dispose();
            }
            else
                Assert.Pass("Not supported profile!");

            tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus END (OK)"); 
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime GetWatchTimeFromPtr.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.GetWatchTimeFromPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "MR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeGetWatchTimeFromPtr()
        {
            tlog.Debug(tag, $"WatchTimeGetWatchTimeFromPtr START");

            using (ImageView view = new ImageView())
            {
                var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                try
                {
                    WatchTime.GetWatchTimeFromPtr(testingTarget.SwigCPtr.Handle);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception: Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WatchTimeGetWatchTimeFromPtr END (OK)");
        }
    }
}
