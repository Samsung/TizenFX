using System.Threading.Tasks;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.LockStateChangedEventArgs Tests")]
    public static class LockStateChangedEventArgsTests
    {
        private static bool s_lockStateLockCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check LockStateChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LockStateChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_LOCK()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedLockValue;

            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.Lock;
            await Task.Delay(2000);
            Assert.IsTrue(s_lockStateLockCallbackCalled, "Value_ENUM_LOCK: EventHandler added. Not getting called");
            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedLockValue;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedLockValue(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_lockStateLockCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedLockValue: LockState nota na instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.Lock, "OnLockStateChangedLockValue: The callback should receive the latest value for the property.");
        }

        private static bool s_lockStateUnlockCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check LockStateChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LockStateChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRE")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_UNLOCK()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedUnlockValue;

            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.Unlock;
            await Task.Delay(2000);
            Assert.IsTrue(s_lockStateUnlockCallbackCalled, "Value_ENUM_UNLOCK: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedUnlockValue;
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedUnlockValue(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_lockStateUnlockCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedUnlockValue: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.Unlock, "OnLockStateChangedUnlockValue: The callback should receive the latest value for the property.");
        }

        private static bool s_lockStateLaunchingLockCallbackCalled = false;
        ////[Test]
        //[Category("P1")]
        //[Description("Check LockStateChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.LockStateChangedEventArgs.Value A")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "PRO")]
        //[Property("AUTHOR", "Aditya Aswani, a.aswani@samsung.com")]
        public static async Task Value_ENUM_LAUNCHING_LOCK()
        {
            LogUtils.StartTest();
            /*
                * PRECONDITION
                * 1. Assign event handler
                */
            Tizen.System.SystemSettings.LockStateChanged += OnLockStateChangedLaunchingLockValue;

            SystemSettingsIdleLockState preValue = Tizen.System.SystemSettings.LockState;
            Tizen.System.SystemSettings.LockState = Tizen.System.SystemSettingsIdleLockState.LaunchingLock;
            await Task.Delay(2000);
            Assert.IsTrue(s_lockStateLaunchingLockCallbackCalled, "Value_ENUM_LAUNCHING_LOCK: EventHandler added. Not getting called");

            /*
                * POSTCONDITION
                * 1. Reset callback called flag
                * 2. Remove event handler
                * 3. Reset property value
                */
            Tizen.System.SystemSettings.LockStateChanged -= OnLockStateChangedLaunchingLockValue;
            s_lockStateLockCallbackCalled = false;
            Tizen.System.SystemSettings.LockState = preValue;
            LogUtils.WriteOK();
        }
        private static void OnLockStateChangedLaunchingLockValue(object sender, Tizen.System.LockStateChangedEventArgs e)
        {
            s_lockStateLaunchingLockCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<Tizen.System.SystemSettingsIdleLockState>(e.Value, "OnLockStateChangedLaunchingLockValue: LockState not an instance of SystemSettingsIdleLockState");
            Assert.IsTrue(e.Value == Tizen.System.SystemSettingsIdleLockState.LaunchingLock, "OnLockStateChangedLaunchingLockValue: The callback should receive the latest value for the property.");
        }
    }
}
