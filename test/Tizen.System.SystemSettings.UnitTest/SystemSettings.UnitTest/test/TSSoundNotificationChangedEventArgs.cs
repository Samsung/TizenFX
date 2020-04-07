using System;
using System.Threading.Tasks;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.SoundNotificationChangedEventArgs Tests")]
    public static class SoundNotificationChangedEventArgsTests
    {
        private static bool s_soundNotificationCallbackCalled = false;
        private static readonly string s_soundNotificationValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.SoundNotification);
        ////[Test]
        //[Category("P1")]
        //[Description("Check SoundNotificationChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.SoundNotificationChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY()
        {
            try
            {
                LogUtils.StartTest();
                /*
                 * PRECONDITION
                 * 1. Assign event handler
                 */
                Tizen.System.SystemSettings.SoundNotificationChanged += OnSoundNotificationChangedValue;

                string preValue = Tizen.System.SystemSettings.SoundNotification;
                Tizen.System.SystemSettings.SoundNotification = s_soundNotificationValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_soundNotificationCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

                /*
                 * POSTCONDITION
                 * 1. Reset callback called flag
                 * 2. Remove event handler
                 * 3. Reset property value
                 */
                Tizen.System.SystemSettings.SoundNotificationChanged -= OnSoundNotificationChangedValue;
                Tizen.System.SystemSettings.SoundNotification = preValue;
                s_soundNotificationCallbackCalled = false;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.incoming_call", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.incoming_call)");
                LogUtils.NotSupport();
            }
        }
        private static void OnSoundNotificationChangedValue(object sender, Tizen.System.SoundNotificationChangedEventArgs e)
        {
            s_soundNotificationCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnSoundNotificationChangedValue: SoundNotification not an instance of string");
            Assert.IsTrue(s_soundNotificationValue.CompareTo(e.Value) == 0, "OnSoundNotificationChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
