using System.Threading.Tasks;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.LocaleCountryChangedEventArgs Tests")]
    public static class LocaleCountryChangedEventArgsTests
    {
        private static bool s_localeCountryCallbackCalled = false;
        private static readonly string s_localeCountryValue = "en_US";
        ////[Test]
        //[Category("P1")]
        //[Description("Check LocaleCountryChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LocaleCountryChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.LocaleCountryChanged += OnLocaleCountryChangedValue;

            string preValue = Tizen.System.SystemSettings.LocaleCountry;
            Tizen.System.SystemSettings.LocaleCountry = s_localeCountryValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_localeCountryCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_localeCountryCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleCountryChanged -= OnLocaleCountryChangedValue;
            Tizen.System.SystemSettings.LocaleCountry = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleCountryChangedValue(object sender, Tizen.System.LocaleCountryChangedEventArgs e)
        {
            s_localeCountryCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnLocaleCountryChangedValue: LocaleCountry not an instance of string");
            Assert.IsTrue(s_localeCountryValue.CompareTo(e.Value) == 0, "OnLocaleCountryChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
