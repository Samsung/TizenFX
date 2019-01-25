using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.LocaleTimeZoneChangedEventArgs Tests")]
    public static class LocaleTimeZoneChangedEventArgsTests
    {
        private static bool s_localeTimeZoneCallbackCalled = false;
        private static readonly string s_localeTimeZoneValue = "Asia/Seoul";
        ////[Test]
        //[Category("P1")]
        //[Description("Check LocaleTimeZoneChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LocaleTimeZoneChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.LocaleTimeZoneChanged += OnLocaleTimeZoneChangedValue;

            string preValue = Tizen.System.SystemSettings.LocaleTimeZone;
            Tizen.System.SystemSettings.LocaleTimeZone = s_localeTimeZoneValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_localeTimeZoneCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_localeTimeZoneCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleTimeZoneChanged -= OnLocaleTimeZoneChangedValue;
            Tizen.System.SystemSettings.LocaleTimeZone = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleTimeZoneChangedValue(object sender, Tizen.System.LocaleTimeZoneChangedEventArgs e)
        {
            s_localeTimeZoneCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "LocaleTimeZone not an instance of string");
            Assert.IsTrue(s_localeTimeZoneValue.CompareTo(e.Value) == 0, "OnLocaleTimeZoneChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
