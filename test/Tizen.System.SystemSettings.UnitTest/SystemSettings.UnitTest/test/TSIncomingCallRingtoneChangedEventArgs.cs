using System;
using System.Threading.Tasks;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.IncomingCallRingtoneChangedEventArgs Tests")]
    public static class IncomingCallRingtoneChangedEventArgsTests
    {
        private static bool s_incomingCallRingtoneCallbackCalled = false;
        private static readonly string s_incomingCallRingtoneValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.IncomingCallRingtone);
        ////[Test]
        //[Category("P1")]
        //[Description("Check IncomingCallRingtoneChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.IncomingCallRingtoneChangedEventArgs.Value A")]
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
                Tizen.System.SystemSettings.IncomingCallRingtoneChanged += OnIncomingCallRingtoneChangedValue;

                string preValue = Tizen.System.SystemSettings.IncomingCallRingtone;
                Tizen.System.SystemSettings.IncomingCallRingtone = s_incomingCallRingtoneValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_incomingCallRingtoneCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

                /*
                 * POSTCONDITION
                 * 1. Reset callback called flag
                 * 2. Remove event handler
                 * 3. Reset property value
                 */
                s_incomingCallRingtoneCallbackCalled = false;
                Tizen.System.SystemSettings.IncomingCallRingtoneChanged -= OnIncomingCallRingtoneChangedValue;
                Tizen.System.SystemSettings.IncomingCallRingtone = preValue;
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
        private static void OnIncomingCallRingtoneChangedValue(object sender, Tizen.System.IncomingCallRingtoneChangedEventArgs e)
        {
            s_incomingCallRingtoneCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnIncomingCallRingtoneChangedValue: IncomingCallRingtone not an instance of string");
            Assert.IsTrue(s_incomingCallRingtoneValue.CompareTo(e.Value) == 0, "OnIncomingCallRingtoneChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
