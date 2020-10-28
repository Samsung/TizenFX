using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.LockscreenAppChangedEventArgs Tests")]
    public static class LockscreenAppChangedEventArgsTests
    {
        private static bool s_lockScreenAppCallbackCalled = false;
        private static readonly string s_lockscreenAppValue = "org.tizen.lockscreen";
        ////[Test]
        //[Category("P1")]
        //[Description("Check LockscreenAppChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LockscreenAppChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_PROPERTY_READ_ONLY()
        {
            try {
                LogUtils.StartTest();
                /*
                 * PRECONDITION
                 * 1. Assign event handler
                 */
                Tizen.System.SystemSettings.LockScreenAppChanged += OnLockscreenAppChangedValue;

                string preValue = Tizen.System.SystemSettings.LockScreenApp;
                Tizen.System.SystemSettings.LockScreenApp = s_lockscreenAppValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_lockScreenAppCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

                /*
                 * POSTCONDITION
                 * 1. Reset callback called flag
                 * 2. Remove event handler
                 * 3. Reset property value
                 */
                s_lockScreenAppCallbackCalled = false;
                Tizen.System.SystemSettings.LockScreenAppChanged -= OnLockscreenAppChangedValue;
                Tizen.System.SystemSettings.LockScreenApp = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnLockscreenAppChangedValue(object sender, Tizen.System.LockScreenAppChangedEventArgs e)
        {
            s_lockScreenAppCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnLockscreenAppChangedValue: LockscreenApp not an instance of string");
            Assert.IsTrue(s_lockscreenAppValue.CompareTo(e.Value) == 0, "OnLockscreenAppChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
