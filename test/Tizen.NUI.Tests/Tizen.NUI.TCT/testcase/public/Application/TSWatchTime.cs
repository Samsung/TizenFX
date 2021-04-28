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
        [Description("WatchTime constructor.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.WatchTime C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeConstructor()
        {
            tlog.Debug(tag, $"WatchTimeConstructor START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeConstructor END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeConstructor END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Day.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Day A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeDay()
        {
            tlog.Debug(tag, $"WatchTimeDay START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");
                
                int time = testingTarget.Day;
                Assert.IsTrue(time > 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeDay END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeDay END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime DaylightSavingTimeStatus.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.DaylightSavingTimeStatus A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeDaylightSavingTimeStatus()
        {
            tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");
                
                bool status = testingTarget.DaylightSavingTimeStatus;
                Assert.AreEqual(false, status, "Should be the default value");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime DayOfWeek.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.DayOfWeek A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeDayOfWeek()
        {
            tlog.Debug(tag, $"WatchTimeDayOfWeek START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int day = testingTarget.DayOfWeek;
                Assert.IsTrue(day > 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeDayOfWeek END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeDayOfWeek END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Hour.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Hour A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeHour()
        {
            tlog.Debug(tag, $"WatchTimeHour START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int hour = testingTarget.Hour;
                Assert.IsTrue(hour > 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeHour END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeHour END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Hour24.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Hour24 A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeHour24()
        {
            tlog.Debug(tag, $"WatchTimeHour24 START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int hour24 = testingTarget.Hour24;
                Assert.IsTrue(hour24 >= 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeHour24 END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeHour24 END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Millisecond.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Millisecond A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeMillisecond()
        {
            tlog.Debug(tag, $"WatchTimeMillisecond START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int millisecond = testingTarget.Millisecond;
                Assert.IsTrue(millisecond >= 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeMillisecond END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeMillisecond END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Minute.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Minute A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeMinute()
        {
            tlog.Debug(tag, $"WatchTimeMinute START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int minute = testingTarget.Minute;
                Assert.IsTrue(minute >= 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeMinute END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeMinute END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Month.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Month A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeMonth()
        {
            tlog.Debug(tag, $"WatchTimeMonth START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int month = testingTarget.Month;
                Assert.IsTrue(month > 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeMonth END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeMonth END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Second.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Second A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeSecond()
        {
            tlog.Debug(tag, $"WatchTimeSecond START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int second = testingTarget.Second;
                Assert.IsTrue(second >= 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeSecond END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeSecond END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime TimeZone.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.TimeZone A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeTimeZone()
        {
            tlog.Debug(tag, $"WatchTimeTimeZone START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                string zone = testingTarget.TimeZone;
                Assert.IsNotEmpty(zone, "TimeZone is empty");

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeTimeZone END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeTimeZone END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }

        [Test]
        [Category("P1")]
        [Description("WatchTime Year.")]
        [Property("SPEC", "Tizen.NUI.WatchTime.Year A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WatchTimeYear()
        {
            tlog.Debug(tag, $"WatchTimeYear START");

            if (IsWearable())
            {
                var testingTarget = new WatchTime();
                Assert.IsNotNull(testingTarget, "should be not null");
                Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

                int year = testingTarget.Year;
                Assert.IsTrue(year > 0.0f);

                testingTarget.Dispose();
                tlog.Debug(tag, $"WatchTimeYear END (OK)");
            }
            else
            {
                tlog.Debug(tag, $"WatchTimeYear END (OK)");
                Assert.Pass("Not Supported profile");
            }
        }
    }
}
