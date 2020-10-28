using System;
using System.Threading.Tasks;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.EmailAlertRingtoneChangedEventArgs Tests")]
    public static class EmailAlertRingtoneChangedEventArgsTests
    {
        private static bool s_emailAlertRingtoneCallbackCalled = false;
        private static readonly string s_emailAlertRingtoneValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.EmailAlertRingtone);
        ////[Test]
        //[Category("P1")]
        //[Description("Check EmailAlertRingtoneChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.EmailAlertRingtoneChangedEventArgs.Value A")]
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
                Tizen.System.SystemSettings.EmailAlertRingtoneChanged += OnEmailAlertRingtoneChangedValue;

                string preValue = Tizen.System.SystemSettings.EmailAlertRingtone;
                Tizen.System.SystemSettings.EmailAlertRingtone = s_emailAlertRingtoneValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_emailAlertRingtoneCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

                /*
                 * POSTCONDITION
                 * 1. Reset callback called flag
                 * 2. Remove event handler
                 * 3. Reset property value
                 */
                s_emailAlertRingtoneCallbackCalled = false;
                Tizen.System.SystemSettings.EmailAlertRingtoneChanged -= OnEmailAlertRingtoneChangedValue;
                Tizen.System.SystemSettings.EmailAlertRingtone = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.notification_email", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.notification_email)");
                LogUtils.NotSupport();
            }
        }
        private static void OnEmailAlertRingtoneChangedValue(object sender, Tizen.System.EmailAlertRingtoneChangedEventArgs e)
        {
            s_emailAlertRingtoneCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnEmailAlertRingtoneChangedValue: EmailAlertRingtone not an instance of string");
            Assert.IsTrue(s_emailAlertRingtoneValue.CompareTo(e.Value) == 0, "OnEmailAlertRingtoneChanged: The callback should receive the latest value for the property.");
        }

    }
}
