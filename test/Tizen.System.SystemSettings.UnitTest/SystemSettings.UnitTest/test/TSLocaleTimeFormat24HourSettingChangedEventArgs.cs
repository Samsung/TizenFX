using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.LocaleTimeFormat24HourSettingChangedEventArgs Tests")]
    public static class LocaleTimeFormat24HourSettingChangedEventArgsTests
    {
        private static bool s_timeFormatCallbackCalled = false;
        private static readonly bool s_localeTimeformat24HourValue = !Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check LocaleTimeFormat24HourSettingChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LocaleTimeFormat24HourSettingChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged += OnLocaleTimeformat24HourChangedValue;

            bool preValue = Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = s_localeTimeformat24HourValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_timeFormatCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_timeFormatCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourSettingChanged -= OnLocaleTimeformat24HourChangedValue;
            Tizen.System.SystemSettings.LocaleTimeFormat24HourEnabled = preValue;
            LogUtils.WriteOK();
        }

        private static void OnLocaleTimeformat24HourChangedValue(object sender, Tizen.System.LocaleTimeFormat24HourSettingChangedEventArgs e)
        {
            s_timeFormatCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(e.Value, "OnLocaleTimeformat24HourChangedValue: LocaleTimeFormat24HourEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_localeTimeformat24HourValue, "OnLocaleTimeformat24HourChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
