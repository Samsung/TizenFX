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

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime GetUtcTime.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.GetUtcTime M")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "MR")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeGetUtcTime()
        //{
        //    tlog.Debug(tag, $"WatchTimeGetUtcTime START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetUtcTime' in shared library 'libdali2-csharp-binder.so' */
        //            testingTarget.GetUtcTime();
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeGetUtcTime END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Day.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Day A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeDay()
        //{
        //    tlog.Debug(tag, $"WatchTimeDay START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetDay' in shared library 'libdali2-csharp-binder.so' */
        //            int time = testingTarget.Day;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeDay END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime DaylightSavingTimeStatus.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.DaylightSavingTimeStatus A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeDaylightSavingTimeStatus()
        //{
        //    tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetDaylightSavingTimeStatus' in shared library 'libdali2-csharp-binder.so' */
        //            bool status = testingTarget.DaylightSavingTimeStatus;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeDaylightSavingTimeStatus END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime DayOfWeek.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.DayOfWeek A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeDayOfWeek()
        //{
        //    tlog.Debug(tag, $"WatchTimeDayOfWeek START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetDayOfWeek' in shared library 'libdali2-csharp-binder.so' */
        //            int day = testingTarget.DayOfWeek;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeDayOfWeek END (OK)"); 
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Hour.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Hour A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeHour()
        //{
        //    tlog.Debug(tag, $"WatchTimeHour START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetHour' in shared library 'libdali2-csharp-binder.so' */
        //            int hour = testingTarget.Hour;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeHour END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Hour24.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Hour24 A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeHour24()
        //{
        //    tlog.Debug(tag, $"WatchTimeHour24 START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetHour24' in shared library 'libdali2-csharp-binder.so' */
        //            int hour24 = testingTarget.Hour24;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeHour24 END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Millisecond.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Millisecond A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeMillisecond()
        //{
        //    tlog.Debug(tag, $"WatchTimeMillisecond START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetMillisecond' in shared library 'libdali2-csharp-binder.so' */
        //            int millisecond = testingTarget.Millisecond;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeMillisecond END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Minute.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Minute A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeMinute()
        //{
        //    tlog.Debug(tag, $"WatchTimeMinute START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetMinute' in shared library 'libdali2-csharp-binder.so' */
        //            int minute = testingTarget.Minute;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeMinute END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Month.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Month A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeMonth()
        //{
        //    tlog.Debug(tag, $"WatchTimeMonth START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetMonth' in shared library 'libdali2-csharp-binder.so' */
        //            int month = testingTarget.Month;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeMonth END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Second.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Second A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeSecond()
        //{
        //    tlog.Debug(tag, $"WatchTimeSecond START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetSecond' in shared library 'libdali2-csharp-binder.so' */
        //            int second = testingTarget.Second;
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeSecond END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime TimeZone.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.TimeZone A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeTimeZone()
        //{
        //    tlog.Debug(tag, $"WatchTimeTimeZone START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetTimeZone' in shared library 'libdali2-csharp-binder.so' */
        //            string zone = testingTarget.TimeZone;
        //            Assert.IsNotEmpty(zone, "TimeZone is empty");
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeTimeZone END (OK)");
        //}

        //[Test]
        //[Category("P1")]
        //[Description("WatchTime Year.")]
        //[Property("SPEC", "Tizen.NUI.WatchTime.Year A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //public void WatchTimeYear()
        //{
        //    tlog.Debug(tag, $"WatchTimeYear START");

        //    using (ImageView view = new ImageView())
        //    {
        //        var testingTarget = new WatchTime(view.SwigCPtr.Handle, false);
        //        Assert.IsNotNull(testingTarget, "should be not null");
        //        Assert.IsInstanceOf<WatchTime>(testingTarget, "Should be an instance of WatchTime type.");

        //        try
        //        {
        //            /** Unable to find an entry point named 'CSharp_Dali_WatchTime_GetYear' in shared library 'libdali2-csharp-binder.so' */
        //            int year = testingTarget.Year;
        //            Assert.IsTrue(year > 0);
        //        }
        //        catch (Exception e)
        //        {
        //            tlog.Debug(tag, e.Message.ToString());
        //            Assert.Fail("Caught Exception: Failed!");
        //        }

        //        testingTarget.Dispose();
        //    }

        //    tlog.Debug(tag, $"WatchTimeYear END (OK)");
        //}
    }
}
