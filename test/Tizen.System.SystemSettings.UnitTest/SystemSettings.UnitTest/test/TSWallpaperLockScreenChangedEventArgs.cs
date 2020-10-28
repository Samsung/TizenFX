using System.Threading.Tasks;
using System;
using System.Threading;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.WallpaperLockScreenChangedEventArgs Tests")]
    public static class WallpaperLockScreenChangedEventArgsTests
    {
        private static bool s_wallpaperLockScreenCallbackCalled = false;
        private static readonly string s_wallpaperLockScreenValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperLockScreen);
        ////[Test]
        //[Category("P1")]
        //[Description("Check WallpaperLockScreenChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.WallpaperLockScreenChangedEventArgs.Value A")]
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
                Tizen.System.SystemSettings.WallpaperLockScreenChanged += OnWallpaperLockScreenChangedValue;

                string preValue = Tizen.System.SystemSettings.WallpaperLockScreen;
                Tizen.System.SystemSettings.WallpaperLockScreen = s_wallpaperLockScreenValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_wallpaperLockScreenCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

                /*
                 * POSTCONDITION
                 * 1. Reset callback called flag
                 * 2. Remove event handler
                 * 3. Reset property value
                 */
                s_wallpaperLockScreenCallbackCalled = false;
                Tizen.System.SystemSettings.WallpaperLockScreenChanged -= OnWallpaperLockScreenChangedValue;
                Tizen.System.SystemSettings.WallpaperLockScreen = preValue;
                LogUtils.WriteOK();
            } catch (NotSupportedException) {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.lock_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.lock_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnWallpaperLockScreenChangedValue(object sender, Tizen.System.WallpaperLockScreenChangedEventArgs e)
        {
            s_wallpaperLockScreenCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnWallpaperLockScreenChangedValue: WallpaperLockScreen not an instance of string");
            Assert.IsTrue(s_wallpaperLockScreenValue.CompareTo(e.Value) == 0, "OnWallpaperLockScreenChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
