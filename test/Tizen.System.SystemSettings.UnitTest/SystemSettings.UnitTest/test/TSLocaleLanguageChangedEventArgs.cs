using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.LocaleLanguageChangedEventArgs Tests")]
    public static class LocaleLanguageChangedEventArgsTests
    {
        private static bool s_localeLanguageCallbackCalled = false;
        private static readonly string s_localeLanguageValue = "en_US";
        ////[Test]
        //[Category("P1")]
        //[Description("Check LocaleLanguageChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LocaleLanguageChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.LocaleLanguageChanged += OnLocaleLanguageChangedValue;

            string preValue = Tizen.System.SystemSettings.LocaleLanguage;
            Tizen.System.SystemSettings.LocaleLanguage = s_localeLanguageValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_localeLanguageCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_localeLanguageCallbackCalled = false;
            Tizen.System.SystemSettings.LocaleLanguageChanged -= OnLocaleLanguageChangedValue;
            Tizen.System.SystemSettings.LocaleLanguage = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLocaleLanguageChangedValue(object sender, Tizen.System.LocaleLanguageChangedEventArgs e)
        {
            s_localeLanguageCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnLocaleLanguageChangedValue: LocaleLanguage not an instance of string");
            Assert.IsTrue(s_localeLanguageValue.CompareTo(e.Value) == 0, "OnLocaleLanguageChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
