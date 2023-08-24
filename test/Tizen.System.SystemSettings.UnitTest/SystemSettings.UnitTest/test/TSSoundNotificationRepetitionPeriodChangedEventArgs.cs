using System.Threading.Tasks;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.SoundNotificationRepetitionPeriodChangedEventArgs Tests")]
    public static class SoundNotificationRepetitionPeriodChangedEventArgsTests
    {
        private static bool s_soundNotificationRepetitionPeriodCallbackCalled = false;
        private static readonly int s_soundNotificationRepetitionPeriodValue = 300;
        ////[Test]
        //[Category("P1")]
        //[Description("Check SoundNotificationRepetitionPeriodChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.SoundNotificationRepetitionPeriodChangedEventArgs.Value A")]
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
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged += OnSoundNotificationRepetitionPeriodChangedValue;

            int preValue = Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = s_soundNotificationRepetitionPeriodValue;
            await Task.Delay(2000);
            Assert.IsTrue(s_soundNotificationRepetitionPeriodCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_soundNotificationRepetitionPeriodCallbackCalled = false;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriodChanged -= OnSoundNotificationRepetitionPeriodChangedValue;
            Tizen.System.SystemSettings.SoundNotificationRepetitionPeriod = preValue;
            LogUtils.WriteOK();
        }
        private static void OnSoundNotificationRepetitionPeriodChangedValue(object sender, Tizen.System.SoundNotificationRepetitionPeriodChangedEventArgs e)
        {
            s_soundNotificationRepetitionPeriodCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<int>(e.Value, "OnSoundNotificationRepetitionPeriodChangedValue: EventHandler added. Not getting called");
            Assert.IsTrue(s_soundNotificationRepetitionPeriodValue.CompareTo(e.Value) == 0, "OnSoundNotificationRepetitionPeriodChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
