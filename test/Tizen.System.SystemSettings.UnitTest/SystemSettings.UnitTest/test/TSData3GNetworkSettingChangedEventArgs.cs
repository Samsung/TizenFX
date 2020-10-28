using System.Threading.Tasks;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.Data3GNetworkSettingChangedEventArgs Tests")]
    public static class Data3GNetworkSettingChangedEventArgsTests
    {
        private static bool s_data3GNetworkCallbackCalled = false;
        private static bool s_data3GNetworkSettingValue = !Tizen.System.SystemSettings.Data3GNetworkEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check Data3GNetworkSettingChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.Data3GNetworkSettingChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.Data3GNetworkSettingChanged += OnData3GNetworkSettingChangedValue;

            bool preValue = Tizen.System.SystemSettings.Data3GNetworkEnabled;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = s_data3GNetworkSettingValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_data3GNetworkCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
            * POSTCONDITION
            * 1. Reset callback called flag
            * 2. Remove event handler
            * 3. Reset property value
            */
            s_data3GNetworkCallbackCalled = false;
            Tizen.System.SystemSettings.Data3GNetworkSettingChanged -= OnData3GNetworkSettingChangedValue;
            Tizen.System.SystemSettings.Data3GNetworkEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnData3GNetworkSettingChangedValue(object sender, Tizen.System.Data3GNetworkSettingChangedEventArgs e)
        {
            s_data3GNetworkCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(e.Value, "OnData3GNetworkSettingChangedValue: Data3GNetworkEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_data3GNetworkSettingValue, "OnData3GNetworkSettingChanged: The callback should receive the latest value for the property.");
        }
    }
}
