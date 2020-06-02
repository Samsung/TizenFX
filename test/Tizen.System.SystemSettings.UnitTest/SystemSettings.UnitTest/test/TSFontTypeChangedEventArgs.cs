using System.Threading.Tasks;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.FontTypeChangedEventArgs Tests")]
    public static class FontTypeChangedEventArgsTests
    {
        private static bool s_fontTypeCallbackCalled = false;
        private static readonly string s_fontTypeValue = Tizen.System.SystemSettings.DefaultFontType;
        ////[Test]
        //[Category("P1")]
        //[Description("Check FontTypeChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.FontTypeChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.FontTypeChanged += OnFontTypeChangedValue;

            string preValue = Tizen.System.SystemSettings.FontType;
            Tizen.System.SystemSettings.FontType = s_fontTypeValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_fontTypeCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_fontTypeCallbackCalled = false;
            Tizen.System.SystemSettings.FontTypeChanged -= OnFontTypeChangedValue;
            Tizen.System.SystemSettings.FontType = preValue;
            LogUtils.WriteOK();
        }
        private static void OnFontTypeChangedValue(object sender, Tizen.System.FontTypeChangedEventArgs e)
        {
            s_fontTypeCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnFontTypeChangedValue: FontType not an instance of string");
            Assert.IsTrue(s_fontTypeValue.CompareTo(e.Value) == 0, "OnFontTypeChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
