using System.Threading.Tasks;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.MotionActivationSettingChangedEventArgs Tests")]
    public static class MotionActivationSettingChangedEventArgsTests
    {
        private static bool s_motionActivationCallbackCalled = false;
        private static bool s_motionActivationValue = !Tizen.System.SystemSettings.MotionActivationEnabled;
        ////[Test]
        //[Category("P1")]
        //[Description("Check MotionActivationSettingChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.MotionActivationSettingChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.MotionActivationSettingChanged += OnMotionActivationChangedValue;

            bool preValue = Tizen.System.SystemSettings.MotionActivationEnabled;
            Tizen.System.SystemSettings.MotionActivationEnabled = s_motionActivationValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_motionActivationCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_motionActivationCallbackCalled = false;
            Tizen.System.SystemSettings.MotionActivationSettingChanged -= OnMotionActivationChangedValue;
            Tizen.System.SystemSettings.MotionActivationEnabled = preValue;
            LogUtils.WriteOK();
        }
        private static void OnMotionActivationChangedValue(object sender, Tizen.System.MotionActivationSettingChangedEventArgs e)
        {
            s_motionActivationCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<bool>(e.Value, "OnMotionActivationChangedValue: MotionActivationEnabled not an instance of bool");
            Assert.IsTrue(e.Value == s_motionActivationValue, "OnMotionActivationChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
