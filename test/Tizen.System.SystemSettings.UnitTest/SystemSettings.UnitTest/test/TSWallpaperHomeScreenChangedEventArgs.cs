using System;
using System.Threading.Tasks;
using Tizen.System;


namespace SystemSettingsUnitTest
{
    //[TestFixture]
    //[Description("Tizen.System.WallpaperHomeScreenChangedEventArgs Tests")]
    public static class WallpaperHomeScreenChangedEventArgsTests
    {
        private static bool s_wallpaperHomeScreenCallbackCalled = false;
        private static readonly string s_wallpaperHomeScreenValue = SystemSettingsTestInput.GetStringValue((int)Tizen.System.SystemSettingsKeys.WallpaperHomeScreen);
        ////[Test]
        //[Category("P1")]
        //[Description("Check WallpaperHomeScreenChangedEventArgs Value property")]
        //[Property("SPEC", "Tizen.System.WallpaperHomeScreenChangedEventArgs.Value A")]
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
                Tizen.System.SystemSettings.WallpaperHomeScreenChanged += OnWallpaperHomeScreenChangedValue;

                string preValue = Tizen.System.SystemSettings.WallpaperHomeScreen;
                Tizen.System.SystemSettings.WallpaperHomeScreen = s_wallpaperHomeScreenValue;
                await Task.Delay(2000);
                Assert.IsTrue(s_wallpaperHomeScreenCallbackCalled, "Value_PROPERTY_READ_ONLY: EventHandler added. Not getting called");

                /*
                 * POSTCONDITION
                 * 1. Reset callback called flag
                 * 2. Remove event handler
                 * 3. Reset property value
                 */
                s_wallpaperHomeScreenCallbackCalled = false;
                Tizen.System.SystemSettings.WallpaperHomeScreenChanged -= OnWallpaperHomeScreenChangedValue;
                Tizen.System.SystemSettings.WallpaperHomeScreen = preValue;
                LogUtils.WriteOK();
            }
            catch (NotSupportedException)
            {
                bool isSupport = true;
                Information.TryGetValue<bool>("tizen.org/feature/systemsetting.home_screen", out isSupport);
                Assert.IsTrue(isSupport == false, "Invalid NotSupportedException");
                Tizen.Log.Debug("CS-SYSTEM-SETTINGS", ">>>>>> NotSupport(tizen.org/feature/systemsetting.home_screen)");
                LogUtils.NotSupport();
            }
        }
        private static void OnWallpaperHomeScreenChangedValue(object sender, Tizen.System.WallpaperHomeScreenChangedEventArgs e)
        {
            s_wallpaperHomeScreenCallbackCalled = true;
            /* TEST CODE */
            Assert.IsInstanceOf<string>(e.Value, "OnWallpaperHomeScreenChangedValue: WallpaperHomeScreen not an instance of string");
            Assert.IsTrue(s_wallpaperHomeScreenValue.CompareTo(e.Value) == 0, "OnWallpaperHomeScreenChangedValue: The callback should receive the latest value for the property.");
        }
    }
}
